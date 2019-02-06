/*
 * @author: Shreepa Parthaje
 */

using System;
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

        public MainForm() {
            InitializeComponent();
            top.PlaceHolderText = "Percent off the top";
            bottom.PlaceHolderText = "Percent off the bottom";
            left.PlaceHolderText = "Percent off the left";
            right.PlaceHolderText = "Percent offg the right";
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

                double ratioAmount;
                double.TryParse(ratioValue.Text, out ratioAmount);

                for (int i = 0; i < contours.Size; i++) {
                    var contour = contours[i];
                    double perimeter = CvInvoke.ArcLength(contour, true);
                    VectorOfPoint approx = new VectorOfPoint();
                    CvInvoke.ApproxPolyDP(contour, approx, approxAmount * perimeter, true);
                    
                    CvInvoke.DrawContours(final, contours, i, new MCvScalar(0, 0, 255), 1);
                    finalImage.Image = final.Bitmap;

                    if (approx.Size == 3) {
                        int current;
                        int.TryParse(triangleNum.Text, out current);
                        current += 1;
                        triangleNum.Text = current.ToString();
                    } else if (approx.Size == 4) {
                        Rectangle rectangle = CvInvoke.BoundingRectangle(contour);
                        double ratio = ((double)rectangle.Width) / rectangle.Height;
                        int current;

                        if (ratio > ratioAmount) {
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
    }
}
