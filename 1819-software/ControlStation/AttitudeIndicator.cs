using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStation
{
    //borrowed from
    //http://www.nuclearprojects.com/ins/attitude_indicator.shtml
    public class AttitudeIndicator : Panel
    {
        // Load images
        Bitmap horizonBitmap = new Bitmap(Properties.Resources.horizon);
        Bitmap bezelBitmap = new Bitmap(Properties.Resources.rov_backview);
        Bitmap headingBitmap = new Bitmap(Properties.Resources.heading);
        Bitmap editedHeadingBitmap;
        Bitmap wingsBitmap = new Bitmap(Properties.Resources.wings);

        //Pen myPen;

        double pitchAngle = 0;
        double rollAngle = 0;
        double yawAngle = 0;
        private double ConvertAngle(double angle)
        {
            if(angle > 180)
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
            }
        }
        public double RollAngle
        {
            set
            {
                rollAngle = ConvertAngle(value) * Math.PI / 180;
            }
        }
        public double YawAngle
        {
            get
            {
                return yawAngle;
            }
            set
            {
                yawAngle = -ConvertAngle(value) * Math.PI / 180;
            }
        }

        Point ptBoule = new Point(-25, -410); //Ground-Sky initial location
        Point ptHeading = new Point(-592, 150); // Heading ticks
        Point ptRotation = new Point(150, 150); // Point of rotation

        public AttitudeIndicator()
        {
            Size = new Size(300, 300);
            bezelBitmap.MakeTransparent(Color.White); // Sets image transparency
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


            // Clipping mask for Attitude Indicator
            paintEvnt.Graphics.Clip = new Region(new Rectangle(0, 0, 300, 300));
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
            gfx.DrawImage(wingsBitmap, 75, 125); // Draw wings image

            //myPen = new Pen(System.Drawing.Color.Green, 3);
            //gfx.DrawLine(myPen, 200, 20, 20, 210); // Draw a line

            // The sliders are updated from the Pitch, Roll & Yaw values (calculated first from serial data)
            //slider1.Value = Convert.ToInt16(PitchAngle); //Update sliders
            //slider2.Value = Convert.ToInt16((-1.0 * RollAngle / Math.PI) * 180);  //with values from
            //slider3.Value = Convert.ToInt16((YawAngle / Math.PI) * 180);   //serial data (if available)           

            // Update text boxes with angles (if we have any)

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
