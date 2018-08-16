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
    public class DepthIndicator : Panel
    {
        private double depth;
        private Bitmap backBitmap = new Bitmap(Properties.Resources.depth_back);
        private Bitmap frontBitmap = new Bitmap(Properties.Resources.depth_front);
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

            Size = new Size(40, 250);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            if (depth > 8.5f)
            {
                g.FillRectangle(new SolidBrush(Color.OrangeRed), 0, 0, 40, 250);
            }
            g.DrawImage(backBitmap, 0, 0, new Rectangle(0, (int)(depth * 100) - 125, 
                40, 250), GraphicsUnit.Pixel);

            g.DrawImage(frontBitmap, 0, 0);
        }
    }
}
