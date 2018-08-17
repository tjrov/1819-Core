using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ControlStation
{
    public class DataLabel : Label
    {
        public string Info = "", Unit = "", Format = "#";
        public double Value
        {
            set
            {
                base.Text = string.Format("{0}: {1}{2}", 
                    Info, string.Format(Format, "" + value), Unit);
            }
        }
        public new string Text
        {
            set
            {
                base.Text = string.Format("{0}: {1}", Info, value);
            }
        }
    }
    public class BarGraph : FlowLayoutPanel
    {
        private ProgressBar pb, pb2;
        private DataLabel lb;
        private double min, max;
        public BarGraph(string label, string format, string unit, Color barColor, double min, double max, int width)
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowOnly;
            this.min = min;
            this.max = max;
            pb = new ProgressBar()
            {
                ForeColor = barColor,
                Minimum = 0,
                Maximum = (int)(max * 10),
                Width = width,
            };
            pb2 = new ProgressBar()
            {
                ForeColor = barColor,
                Minimum = 0,
                Maximum = (int)(-min * 10),
                Width = width / 2
            };
            if (min < 0)
            {
                pb.Width /= 2;
            }
            lb = new DataLabel()
            {
                AutoSize = true,
                Info = label,
                Format = format,
                Unit = unit
            };
            Controls.Add(lb);
            if (min < 0)
            {
                Controls.Add(pb2);
            }
            Controls.Add(pb);
        }
        public double Value
        {
            set
            {
                if (value < 0)
                {
                    pb.Value = 0;
                    pb2.Value = (int)(-value * 10);
                }
                else
                {
                    pb2.Value = 0;
                    pb.Value = (int)(value * 10);
                }
                //display the numeric value
                lb.Value = value;
            }
        }
    }
}