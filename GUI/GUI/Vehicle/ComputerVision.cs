using GUI;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;

using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Controls;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace GUI {

    public abstract class SpeciesFinder {
        private Bitmap Bmap;
        public int Triangles;
        public int Squares;
        public int Lines;
        public int Circles;
        public abstract Bitmap[] FindSpecies();
    }

    public class EmguSpeciesFinder : SpeciesFinder {

        private Bitmap Bmap;
        public int Triangles = 0;
        public int Squares = 0;
        public int Lines = 0;
        public int Circles = 0;

        private const int BlurAmount = 5;
        private const int ThresholdMin = 88;
        private const int ThresholdMax = 255;
        private const double ApproxAmount = 0.05;
        private const double MinRatio = 0.8; // 0.973
        private const double MaxRatio = 1 / MinRatio;
        private const double MinArea = 150;
        private const double BorderCutoff = 5;

        public EmguSpeciesFinder(Bitmap b) {
            Bmap = b;
        }

        public override Bitmap[] FindSpecies() {
            #region Processing
            Image<Bgr, Byte> source = new Image<Bgr, Byte>(Bmap);
            var temp = source.SmoothGaussian(BlurAmount).Convert<Gray, byte>().ThresholdBinaryInv(new Gray(ThresholdMin), new Gray(ThresholdMax));
            #endregion

            #region Find contours
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(temp, contours, new Mat(), RetrType.External, ChainApproxMethod.ChainApproxSimple);
            #endregion

            #region guess shapes
            Image<Bgr, byte> final = source.Copy();
            Image<Bgr, byte> finalProcessed = new Image<Bgr, byte>(temp.ToBitmap());

            Bgr boundsColor = new Bgr(204, 0, 204);
            MCvScalar triangleColor = new MCvScalar(0, 0, 255);
            MCvScalar squareColor = new MCvScalar(0, 255, 0);
            MCvScalar lineColor = new MCvScalar(255, 0, 0);
            MCvScalar circleColor = new MCvScalar(128, 255, 0);

            for (int i = 0; i < contours.Size; i++) {
                var contour = contours[i];
                double perimeter = CvInvoke.ArcLength(contour, true);
                VectorOfPoint approx = new VectorOfPoint();
                CvInvoke.ApproxPolyDP(contour, approx, ApproxAmount * perimeter, true);
                Rectangle bounds = CvInvoke.BoundingRectangle(contour);

                final.Draw(bounds, boundsColor);
                finalProcessed.Draw(bounds, boundsColor);

                double area = CvInvoke.ContourArea(contour);

                if (!(bounds.X > BorderCutoff && bounds.X < final.Width - BorderCutoff)) {
                    continue;
                }

                if (!(bounds.Y > BorderCutoff && bounds.Y < final.Height - BorderCutoff)) {
                    continue;
                }

                if (area < MinArea) {
                    continue;
                }

                if (approx.Size == 3) {
                    Triangles += 1;
                    CvInvoke.DrawContours(final, contour, i, triangleColor, 1);
                    CvInvoke.DrawContours(finalProcessed, contour, i, triangleColor, 1);
                } else if (approx.Size == 4) {
                    System.Drawing.Point[] test = approx.ToArray();

                    System.Drawing.Point a = test[0];
                    System.Drawing.Point b = test[1];
                    System.Drawing.Point c = test[2];

                    double width = Math.Sqrt((((double)(a.X - b.X)) * ((double)(a.X - b.X))) + (((double)(a.Y - b.Y)) * ((double)(a.Y - b.Y))));
                    double height = Math.Sqrt((((double)(c.X - b.X)) * ((double)(c.X - b.X))) + (((double)(c.Y - b.Y)) * ((double)(c.Y - b.Y))));

                    double ratio = width / height;
                    if (ratio > MinRatio && ratio < MaxRatio) {
                        Squares += 1;
                        CvInvoke.DrawContours(final, contour, i, squareColor, 1);
                        CvInvoke.DrawContours(finalProcessed, contour, i, squareColor, 1);
                    } else {
                        Lines += 1;
                        CvInvoke.DrawContours(final, contour, i, lineColor, 1);
                        CvInvoke.DrawContours(finalProcessed, contour, i, lineColor, 1);
                    }
                } else {
                    Circles += 1;
                    CvInvoke.DrawContours(final, contour, i, circleColor, 1);
                    CvInvoke.DrawContours(finalProcessed, contour, i, circleColor, 1);
                }
            }

            #endregion

            return new Bitmap[] { final.ToBitmap(), finalProcessed.ToBitmap() };
        }

    }

    public class AForgeSpeciesFinder : SpeciesFinder {
        private Bitmap Bmap;
        public int Triangles = 0;
        public int Squares = 0;
        public int Lines = 0;
        public int Circles = 0;

        public AForgeSpeciesFinder(Bitmap b) {
            Bmap = b;
        }

        public override Bitmap[] FindSpecies() {
            // lock image
            BitmapData bitmapData = Bmap.LockBits(
                new Rectangle(0, 0, Bmap.Width, Bmap.Height),
                ImageLockMode.ReadWrite, Bmap.PixelFormat);

            // step 1 - turn background to black
            ColorFiltering colorFilter = new ColorFiltering();

            colorFilter.Red = new IntRange(0, 64);
            colorFilter.Green = new IntRange(0, 64);
            colorFilter.Blue = new IntRange(0, 64);
            colorFilter.FillOutsideRange = false;

            colorFilter.ApplyInPlace(bitmapData);

            // step 2 - locating objects
            BlobCounter blobCounter = new BlobCounter();

            blobCounter.FilterBlobs = true;
            blobCounter.MinHeight = 5;
            blobCounter.MinWidth = 5;

            blobCounter.ProcessImage(bitmapData);
            Blob[] blobs = blobCounter.GetObjectsInformation();
            Bmap.UnlockBits(bitmapData);

            // step 3 - check objects' type and highlight
            SimpleShapeChecker shapeChecker = new SimpleShapeChecker();

            Graphics g = Graphics.FromImage(Bmap);

            for (int i = 0, n = blobs.Length; i < n; i++) {
                List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);

                AForge.Point center;
                float radius;

                // is circle ?
                if (shapeChecker.IsCircle(edgePoints, out center, out radius)) {
                    Circles++;
                } else {
                    List<IntPoint> corners;

                    // is triangle or quadrilateral
                    if (shapeChecker.IsConvexPolygon(edgePoints, out corners)) {
                        // get sub-type
                        PolygonSubType subType = shapeChecker.CheckPolygonSubType(corners);
                        if (subType == PolygonSubType.Square) {
                            Squares++;
                        } else if (subType == PolygonSubType.EquilateralTriangle) {
                            Triangles++;
                        } else {
                            Lines++;
                        }
                    }
                }
            }
            g.Dispose();
            
            return new Bitmap[] { Bmap, Bmap };
        }

    }

}