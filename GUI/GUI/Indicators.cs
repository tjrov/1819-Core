using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI
{
    public class HeadingIndicator : Panel
    {
        private double heading;
        private int markedHeading = 0;
        public double Heading
        {
            get
            {
                return heading;
            }
            set
            {
                if (value < 0)
                {
                    heading = 0;
                }
                if (value > 360)
                {
                    heading = 360;
                }
                heading = value;
                Invalidate();
            }
        }
        public void MarkHeading()
        {
            markedHeading = (int)heading;
        }
        public HeadingIndicator()
        {
            //reduce flickering
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            Size = new Size(500, 500);
        }
        //from here:
        //https://www.codeproject.com/Articles/788611/A-simple-Compass
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            //g.DrawImage(DrawCompass(heading, new Size(400, 400)), 0, 0);
            double maxRadius = Size.Width > Size.Height ? Size.Height / 2 : Size.Width / 2;

            double sizeMultiplier = maxRadius / 200;


            Brush drawBrushBlack = Brushes.Black;// new SolidBrush(Color.FromArgb(255, 244, 255));
            double outerradius = (((maxRadius - sizeMultiplier * 60) / maxRadius) * maxRadius);
            double innerradius = (((maxRadius - sizeMultiplier * 90) / maxRadius) * maxRadius);
            double degreeRadius = outerradius + 37 * sizeMultiplier;
            double dirRadius = innerradius - 30 * sizeMultiplier;
            double TriRadius = outerradius + 20 * sizeMultiplier;
            using (Font font2 = new Font("Arial", 42))
            {
                using (Font font1 = new Font("Arial", 16))
                {
                    using (Pen pen1 = new Pen(Color.FromArgb(0, 0, 0), (int)(sizeMultiplier * 4)))
                    {
                        using (Pen pen2 = new Pen(Color.FromArgb(0, 0, 0), ((int)(sizeMultiplier) < 1 ? 1 : (int)(sizeMultiplier))))
                        {
                            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                            // Calculate some image information.
                            double sourcewidth = Size.Width;
                            double sourceheight = Size.Height;

                            int xcenterpoint = (int)(Size.Width / 2);
                            int ycenterpoint = (int)((Size.Height / 2));// maxRadius;

                            Point pA1 = new Point(xcenterpoint, ycenterpoint - (int)(sizeMultiplier * 45));
                            Point pB1 = new Point(xcenterpoint - (int)(sizeMultiplier * 7), ycenterpoint - (int)(sizeMultiplier * 45));
                            Point pC1 = new Point(xcenterpoint, ycenterpoint - (int)(sizeMultiplier * 90));
                            Point pB2 = new Point(xcenterpoint + (int)(sizeMultiplier * 7), ycenterpoint - (int)(sizeMultiplier * 45));

                            Point[] a2 = new Point[] { pA1, pB1, pC1 };
                            Point[] a3 = new Point[] { pA1, pB2, pC1 };

                            double[] Cos = new double[360];
                            double[] Sin = new double[360];

                            //prep here because need before and after for red triangle.
                            for (int d = 0; d < 360; d++)
                            {
                                //   map[y] = new long[src.Width];
                                double angleInRadians = ((((double)d) + 270d) - heading) / 180F * Math.PI;
                                Cos[d] = Math.Cos(angleInRadians);
                                Sin[d] = Math.Sin(angleInRadians);
                            }

                            for (int d = 0; d < 360; d++)
                            {


                                Point p1 = new Point((int)(outerradius * Cos[d]) + xcenterpoint, (int)(outerradius * Sin[d]) + ycenterpoint);
                                Point p2 = new Point((int)(innerradius * Cos[d]) + xcenterpoint, (int)(innerradius * Sin[d]) + ycenterpoint);

                                //Draw Degree labels
                                if (d % 30 == 0)
                                {
                                    g.DrawLine(pen1, p1, p2);

                                    Point p3 = new Point((int)(degreeRadius * Cos[d]) + xcenterpoint, (int)(degreeRadius * Sin[d]) + ycenterpoint);
                                    SizeF s1 = g.MeasureString(d.ToString(), font1);
                                    p3.X = p3.X - (int)(s1.Width / 2);
                                    p3.Y = p3.Y - (int)(s1.Height / 2);

                                    g.DrawString(d.ToString(), font1, drawBrushBlack, p3);
                                    Point pA = new Point((int)(TriRadius * Cos[d]) + xcenterpoint, (int)(TriRadius * Sin[d]) + ycenterpoint);

                                    int width = (int)(sizeMultiplier * 3);
                                    int dp = d + width > 359 ? d + width - 360 : d + width;
                                    int dm = d - width < 0 ? d - width + 360 : d - width;

                                    Point pB = new Point((int)((TriRadius - (15 * sizeMultiplier)) * Cos[dm]) + xcenterpoint, (int)((TriRadius - (15 * sizeMultiplier)) * Sin[dm]) + ycenterpoint);
                                    Point pC = new Point((int)((TriRadius - (15 * sizeMultiplier)) * Cos[dp]) + xcenterpoint, (int)((TriRadius - (15 * sizeMultiplier)) * Sin[dp]) + ycenterpoint);
                                }
                                else if (d % 2 == 0)
                                    g.DrawLine(pen2, p1, p2);

                                //Draw marked heading
                                if (d == markedHeading)
                                {
                                    g.DrawLine(new Pen(Color.Blue, (float)sizeMultiplier * 4), p1, p2);
                                }

                                //draw N,E,S,W
                                if (d % 90 == 0)
                                {
                                    string dir = (d == 0 ? "N" : (d == 90 ? "E" : (d == 180 ? "S" : "W")));
                                    Point p4 = new Point((int)(dirRadius * Cos[d]) + xcenterpoint, (int)(dirRadius * Sin[d]) + ycenterpoint);
                                    SizeF s2 = g.MeasureString(dir, font1);
                                    p4.X = p4.X - (int)(s2.Width / 2);
                                    p4.Y = p4.Y - (int)(s2.Height / 2);

                                    g.DrawString(dir, font1, drawBrushBlack, p4);

                                    //}
                                    ////Draw red triangle at 0 degrees
                                    //if (d == 0)
                                    //{

                                }

                            }
                            //draw course

                            //g.DrawLine(pen1, new Point(xcenterpoint, ycenterpoint - (int)innerradius), new Point(xcenterpoint, ycenterpoint - ((int)outerradius + (int)(sizeMultiplier * 50))));


                            String deg = Math.Round(heading, 0).ToString("000");
                            SizeF s3 = g.MeasureString(deg, font2);

                            g.DrawString(deg, font2, drawBrushBlack, new Point(xcenterpoint - (int)(s3.Width / 2), ycenterpoint - (int)(s3.Height / 2)));

                            String markeddeg = markedHeading.ToString("[000]");
                            SizeF s4 = g.MeasureString(markeddeg, font1);

                            g.DrawString(markeddeg, font1, Brushes.Blue, new Point(xcenterpoint - (int)(s4.Width / 2), ycenterpoint + (int)(sizeMultiplier * 20)));

                            g.DrawString("[LOCK]", font1, Brushes.Blue, new Point(0, Size.Height - 50));
                        }
                    }
                }
            }
        }
    }
    public class DepthIndicator : Panel
    {
        private double depth;
        private Bitmap backBitmap = new Bitmap(Properties.Resources.depth_back);
        //private Bitmap frontBitmap = new Bitmap(Properties.Resources.depth_front);
        public double Depth
        {
            get
            {
                return depth;
            }
            set
            {
                depth = value;
                if (depth > 10.0f)
                {
                    depth = 10.0f;
                }
                else if (depth < 0.0f)
                {
                    depth = 0.0f;
                }
                Invalidate();
            }
        }
        public DepthIndicator()
        {
            //reduce flickering
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            Size = new Size(75, 500);

            backBitmap = CreateBackBitmap();
        }
        private Bitmap CreateBackBitmap()
        {
            Bitmap bmp = new Bitmap(Size.Width, 2000);
            Graphics g = Graphics.FromImage(bmp);
            Pen pen1 = new Pen(Color.FromArgb(0, 0, 0), 1);
            Pen pen2 = new Pen(Color.FromArgb(0, 0, 0), 3);
            //fade from light to dark blue as depth increases
            LinearGradientBrush background = new LinearGradientBrush(new Point(0, 0), new Point(bmp.Width, bmp.Height), Color.LightBlue, Color.DarkBlue);
            g.FillRectangle(background, 0, 0, bmp.Width, bmp.Height);
            int center = bmp.Width / 2;

            Font font1 = new Font("Arial", 16);

            for (int y = 0; y < bmp.Height; y+=20)
            {
                if (y % 200 == 0)
                {
                    g.DrawLine(pen2, 0, y, bmp.Width, y);
                    g.DrawString(""+y / 200, font1, Brushes.Black, 2, y + 2);
                } else if(y % 100 == 0)
                { 
                    g.DrawLine(pen2, center - 20, y, center + 20, y);
                } else
                {
                    g.DrawLine(pen1, center - 2, y, center + 2, y);
                }
            }

            return bmp;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit; //text looks nicer
            g.SmoothingMode = SmoothingMode.HighQuality;

            g.Clear(Color.Black);

            g.DrawImage(backBitmap, 0, 0, new Rectangle(0, (int)(depth * 200) - Size.Height / 2,
                Size.Width, Size.Height), GraphicsUnit.Pixel);

            //g.DrawImage(frontBitmap, 0, 0);

            Font font1 = new Font("Arial", 12);
            g.DrawString("[LOCK]", font1, Brushes.Blue, new Point(0, 465));
        }
    }
    //borrowed from
    //http://www.nuclearprojects.com/ins/attitude_indicator.shtml
    public class AttitudeIndicator : Panel
    {
        // Load images
        Bitmap horizonBitmap = new Bitmap(Properties.Resources.horizon);
        Bitmap bezelBitmap = new Bitmap(Properties.Resources.bezel);
        Bitmap headingBitmap = new Bitmap(Properties.Resources.heading);
        Bitmap editedHeadingBitmap;
        Bitmap wingsBitmap = new Bitmap(Properties.Resources.wings);

        //Pen myPen;

        double pitchAngle = 0;
        double rollAngle = 0;
        double yawAngle = 0;
        private double ConvertAngle(double angle)
        {
            if (angle > 180)
            {
                angle -= 360;
            }
            return angle;
        }
        public double PitchAngle
        {
            set
            {
                pitchAngle = ConvertAngle(value);
                Invalidate();
            }
        }
        public double RollAngle
        {
            set
            {
                rollAngle = ConvertAngle(value) * Math.PI / 180;
                Invalidate();
            }
        }
        public double YawAngle
        {
            set
            {
                yawAngle = -ConvertAngle(value) * Math.PI / 180;
                Invalidate();
            }
        }

        Point ptBoule = new Point(-33, -546); //Ground-Sky initial location //(-25, 410)
        Point ptHeading = new Point(-789, 200); // Heading ticks
        Point ptRotation = new Point(200, 200); // Point of rotation

        public AttitudeIndicator()
        {
            Size = new Size(400, 400);
            bezelBitmap.MakeTransparent(Color.Yellow); // Sets image transparency
            headingBitmap.MakeTransparent(Color.Black); // Sets image transparency
            wingsBitmap.MakeTransparent(Color.Yellow); // Sets image transparency
            editedHeadingBitmap = headingBitmap;
            //reduce flickering
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        // OnPaint takes care of drawing all graphics to the screen automatically
        protected override void OnPaint(PaintEventArgs paintEvnt)
        {
            // Calling the base class OnPaint
            base.OnPaint(paintEvnt);

            paintEvnt.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit; //text looks better


            // Clipping mask for Attitude Indicator
            paintEvnt.Graphics.Clip = new Region(new Rectangle(0, 0, 400, 400));
            paintEvnt.Graphics.FillRegion(Brushes.Black, paintEvnt.Graphics.Clip);


            // Make sure lines are drawn smoothly
            paintEvnt.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            // Create the graphics object
            Graphics gfx = paintEvnt.Graphics;

            // Adjust and draw horizon image
            RotateAndTranslate(paintEvnt, horizonBitmap, rollAngle, 0, ptBoule, (double)(4 * pitchAngle), ptRotation, 1);

            //draw the heading mthing
            RotateAndTranslate2(paintEvnt, editedHeadingBitmap, yawAngle, rollAngle, 0, ptHeading, (double)(4 * pitchAngle), ptRotation, 1);



            // Draw a mask
            //Pen maskPen = new Pen(this.BackColor, 220); // width of mask
            //gfx.DrawRectangle(maskPen, -100, -100, 500, 500); // size of mask

            gfx.DrawImage(bezelBitmap, 0, 0); // Draw bezel image
            gfx.DrawImage(wingsBitmap, 100, 166); // Draw wings image

            //myPen = new Pen(System.Drawing.Color.Green, 3);
            //gfx.DrawLine(myPen, 200, 20, 20, 210); // Draw a line

            // The sliders are updated from the Pitch, Roll & Yaw values (calculated first from serial data)
            //slider1.Value = Convert.ToInt16(PitchAngle); //Update sliders
            //slider2.Value = Convert.ToInt16((-1.0 * RollAngle / Math.PI) * 180);  //with values from
            //slider3.Value = Convert.ToInt16((YawAngle / Math.PI) * 180);   //serial data (if available)           

            // Update text boxes with angles (if we have any)


            //show lock symbol
            Font font1 = new Font("Arial", 12);
            paintEvnt.Graphics.DrawString("[LOCK]", font1, Brushes.Blue, new Point(0, 365));

        }

        protected void RotateAndTranslate(PaintEventArgs pe, Image img, Double alphaRot, Double alphaTrs, Point ptImg, double deltaPx, Point ptRot, float scaleFactor)
        {
            double beta = 0;
            double d = 0;
            float deltaXRot = 0;
            float deltaYRot = 0;
            float deltaXTrs = 0;
            float deltaYTrs = 0;

            // Rotation

            if (ptImg != ptRot)
            {
                // Internals coeffs
                if (ptRot.X != 0)
                {
                    beta = Math.Atan((double)ptRot.Y / (double)ptRot.X);
                }

                d = Math.Sqrt((ptRot.X * ptRot.X) + (ptRot.Y * ptRot.Y));

                // Computed offset
                deltaXRot = (float)(d * (Math.Cos(alphaRot - beta) - Math.Cos(alphaRot) * Math.Cos(alphaRot + beta) - Math.Sin(alphaRot) * Math.Sin(alphaRot + beta)));
                deltaYRot = (float)(d * (Math.Sin(beta - alphaRot) + Math.Sin(alphaRot) * Math.Cos(alphaRot + beta) - Math.Cos(alphaRot) * Math.Sin(alphaRot + beta)));
            }

            // Translation

            // Computed offset
            deltaXTrs = (float)(deltaPx * (Math.Sin(alphaTrs)));
            deltaYTrs = (float)(-deltaPx * (-Math.Cos(alphaTrs)));

            // Rotate image support
            pe.Graphics.RotateTransform((float)(alphaRot * 180 / Math.PI));

            // Dispay image
            pe.Graphics.DrawImage(img, (ptImg.X + deltaXRot + deltaXTrs) * scaleFactor, (ptImg.Y + deltaYRot + deltaYTrs) * scaleFactor, img.Width * scaleFactor, img.Height * scaleFactor);

            // Put image support as found
            pe.Graphics.RotateTransform((float)(-alphaRot * 180 / Math.PI));
        }

        protected void RotateAndTranslate2(PaintEventArgs pe, Image img, Double yawRot, Double alphaRot, Double alphaTrs, Point ptImg, double deltaPx, Point ptRot, float scaleFactor)
        {
            double beta = 0;
            double d = 0;
            float deltaXRot = 0;
            float deltaYRot = 0;
            float deltaXTrs = 0;
            float deltaYTrs = 0;

            // Rotation

            if (ptImg != ptRot)
            {
                // Internals coeffs
                if (ptRot.X != 0)
                {
                    beta = Math.Atan((double)ptRot.Y / (double)ptRot.X);
                }

                d = Math.Sqrt((ptRot.X * ptRot.X) + (ptRot.Y * ptRot.Y));

                // Computed offset
                deltaXRot = (float)(d * (Math.Cos(alphaRot - beta) - Math.Cos(alphaRot) * Math.Cos(alphaRot + beta) - Math.Sin(alphaRot) * Math.Sin(alphaRot + beta) + yawRot));
                deltaYRot = (float)(d * (Math.Sin(beta - alphaRot) + Math.Sin(alphaRot) * Math.Cos(alphaRot + beta) - Math.Cos(alphaRot) * Math.Sin(alphaRot + beta)));
            }

            // Translation

            // Computed offset
            deltaXTrs = (float)(deltaPx * (Math.Sin(alphaTrs)));
            deltaYTrs = (float)(-deltaPx * (-Math.Cos(alphaTrs)));

            // Rotate image support
            pe.Graphics.RotateTransform((float)(alphaRot * 180 / Math.PI));

            // Dispay image
            pe.Graphics.DrawImage(img, (ptImg.X + deltaXRot + deltaXTrs) * scaleFactor, (ptImg.Y + deltaYRot + deltaYTrs) * scaleFactor, img.Width * scaleFactor, img.Height * scaleFactor);

            // Put image support as found
            pe.Graphics.RotateTransform((float)(-alphaRot * 180 / Math.PI));
        }
    }
}