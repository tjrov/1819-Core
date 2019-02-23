/*
 * @author: Shreepa Parthaje
 */

using System;
using System.Timers;
using System.Drawing;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.VideoStab;

namespace EmguCVShapeDetectionTest {
    public partial class MainForm : Form {

        Image<Bgr, byte> source;
        Image<Bgr, byte> original;
        CaptureFrameSource cfs;
        System.Timers.Timer t;

        public MainForm() {
            InitializeComponent();
            top.PlaceHolderText = "Percent off the top";
            bottom.PlaceHolderText = "Percent off the bottom";
            left.PlaceHolderText = "Percent off the left";
            right.PlaceHolderText = "Percent offg the right";
        }

        private void updateFrames(object source, ElapsedEventArgs e) {
            MethodInvoker mi = delegate () {
                int vS;
                int.TryParse(videoSource.Text, out vS);

                int width;
                int height;
                int.TryParse(widthText.Text, out width);
                int.TryParse(heightText.Text, out height);

                try {
                    cfs = new CaptureFrameSource(new VideoCapture(vS));
                    Mat nextFrame = cfs.NextFrame();
                    Image<Bgr, byte> temp = nextFrame.ToImage<Bgr, byte>().Resize(width, height, Inter.Nearest);
                    imageOriginal.Image = temp.Bitmap;
                } catch (Exception exc) {
                    MessageBox.Show(exc.Message);
                }
            };
            this.Invoke(mi);
        }

        private void openFile_Click(object sender, EventArgs e) {
            try {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK) {
                    source = new Image<Bgr, byte>(dialog.FileName);
                    original = source.Copy();
                    imageOriginal.Image = source.Bitmap;
                }
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        private void contours_Click(object sender, EventArgs e) {
            if (source == null) {
                MessageBox.Show("Please open an image.");
                return;
            }

            #region reset UI
            squareNum.Text = "0";
            triangleNum.Text = "0";
            circleNum.Text = "0";
            lineNum.Text = "0";
            #endregion

            try {
                #region image manipulation

                int sg;
                int.TryParse(smoothGaussian.Text, out sg);

                int lowerBound;
                int.TryParse(lower.Text, out lowerBound);

                int upperBound;
                int.TryParse(upper.Text, out upperBound);

                var temp = source.SmoothGaussian(sg).Convert<Gray, byte>().ThresholdBinary(new Gray(lowerBound), new Gray(upperBound)); ;

                if (inverse.Checked) {
                    temp = source.SmoothGaussian(sg).Convert<Gray, byte>().ThresholdBinaryInv(new Gray(lowerBound), new Gray(upperBound));
                }
                if (pyr.Checked) {
                    CvInvoke.PyrDown(temp, temp);
                    CvInvoke.PyrUp(temp, temp);
                }
                processedImage.Image = temp.Bitmap;
                
                #endregion

                #region find contours

                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

                CvInvoke.FindContours(temp, contours, new Mat(), RetrType.External, ChainApproxMethod.ChainApproxSimple);
                
                #endregion

                #region guess shapes

                Image<Bgr, byte> final = source.Copy();

                double approxAmount;
                double.TryParse(approxValue.Text, out approxAmount);

                double minRatio;
                double maxRatio;
                double minArea;
                double.TryParse(ratioValue.Text, out minRatio);
                double.TryParse(marea.Text, out minArea);
                maxRatio = 1 / minRatio;

                double bx;
                double.TryParse(bounding.Text, out bx);

                for (int i = 0; i < contours.Size; i++) {
                    var contour = contours[i];
                    double perimeter = CvInvoke.ArcLength(contour, true);
                    VectorOfPoint approx = new VectorOfPoint();
                    CvInvoke.ApproxPolyDP(contour, approx, approxAmount * perimeter, true);

                    CvInvoke.DrawContours(final, contours, i, new MCvScalar(0, 0, 255), 1);
                    Rectangle bounds = CvInvoke.BoundingRectangle(contour);
                    final.Draw(bounds, new Bgr(255, 0, 0));
                    finalImage.Image = final.Bitmap;

                    double area = CvInvoke.ContourArea(contour);

                    if (!(bounds.X > bx && bounds.X < final.Width - bx)) {
                        if (messages.Checked) { MessageBox.Show("Not in bounds"); }
                        continue;
                    }

                    if (!(bounds.Y > bx && bounds.Y < final.Height - bx)) {
                        if (messages.Checked) { MessageBox.Show("Not in bounds"); }
                        continue;
                    }

                    if (area < minArea) {
                        if (messages.Checked) { MessageBox.Show("Not large enough"); }
                        continue;
                    }

                    if (approx.Size == 3) {
                        int current;
                        int.TryParse(triangleNum.Text, out current);
                        current += 1;
                        triangleNum.Text = current.ToString();
                    } else if (approx.Size == 4) {
                        Point[] test = approx.ToArray();

                        Point a = test[0];
                        Point b = test[1];
                        Point c = test[2];

                        double width = Math.Sqrt((((double)(a.X - b.X)) * ((double)(a.X - b.X))) + (((double)(a.Y - b.Y)) * ((double)(a.Y - b.Y))));
                        double height = Math.Sqrt((((double)(c.X - b.X)) * ((double)(c.X - b.X))) + (((double)(c.Y - b.Y)) * ((double)(c.Y - b.Y))));

                        double ratio = width / height;
                        int current;
                        if (ratio > minRatio && ratio < maxRatio) {
                            int.TryParse(squareNum.Text, out current);
                            current += 1;
                            squareNum.Text = current.ToString();
                        } else {
                            int.TryParse(lineNum.Text, out current);
                            current += 1;
                            lineNum.Text = current.ToString();
                        }
                    } else {
                        int current;
                        int.TryParse(circleNum.Text, out current);
                        current += 1;
                        circleNum.Text = current.ToString();
                    }
                    if (messages.Checked) {
                        MessageBox.Show("Current shape: " + approx.Size.ToString());
                    }

                }
                
                #endregion


            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        private void frame_Click(object sender, EventArgs e) {
            int vS;
            int.TryParse(videoSource.Text, out vS);

            int width;
            int height;
            int.TryParse(widthText.Text, out width);
            int.TryParse(heightText.Text, out height);

            try {
                cfs = new CaptureFrameSource(new VideoCapture(vS));
                Mat nextFrame = cfs.NextFrame();
                source = nextFrame.ToImage<Bgr, byte>().Resize(width, height, Inter.Nearest);
                original = source.Copy();
                imageOriginal.Image = source.Bitmap;
            } catch (Exception exc) {
                MessageBox.Show(exc.Message);
            }
        }

        private void cropByPercentage_Click(object sender, EventArgs e) {
            double x;
            double r;
            double y;
            double b;

            double.TryParse(top.Text, out y);
            double.TryParse(bottom.Text, out b);
            double.TryParse(right.Text, out r);
            double.TryParse(left.Text, out x);

            x = (x / 100) * original.Width;
            r = (r / 100) * original.Width;
            y = (y / 100) * original.Height;
            b = (b / 100) * original.Height;

            int width = (original.Width - (int)r) - (int)x;
            int height = (original.Height - (int)b) - (int)y;

            source.ROI = new Rectangle((int) x, (int) y, (int) width, (int) height);
            imageOriginal.Image = source.Bitmap;

        }

        private void record_Click(object sender, EventArgs e) {
            t = new System.Timers.Timer();
            t.Elapsed += new ElapsedEventHandler(updateFrames);
            t.Interval = 100;
            t.Enabled = true;
        }
    }
}
