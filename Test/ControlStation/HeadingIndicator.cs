using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStation
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
            Size = new Size(400, 400);
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
            using (Font font2 = new Font("Arial", 30))
            {
                using (Font font1 = new Font("Arial", 12))
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

                            g.DrawString("[LOCK]", font1, Brushes.Black, new Point(0, 365));
                        }
                    }
                }
            }
        }
    }
}