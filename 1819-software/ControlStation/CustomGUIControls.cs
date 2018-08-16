using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ControlStation
{
    public class BarGraph : FlowLayoutPanel
    {
        private string label, unit;
        private ProgressBar pb, pb2;
        private Label lb;
        private double min, max;
        public BarGraph(string label, string unit, Color barColor, double min, double max, int width)
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.label = label;
            this.unit = unit;
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
            lb = new Label()
            {
                AutoSize = true,
                Text = string.Format("{0}: {1:0.#}{2}", label, 0, unit)
            };
            Controls.Add(lb);
            if (min < 0)
            {
                Controls.Add(pb2);
            }
            Controls.Add(pb);
        }
        private double value;
        public double Value
        {
            get
            {
                return value;
            }
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
                lb.Text = string.Format("{0}: {1:0.#}{2}", label, value, unit);
                this.value = value;
            }
        }
    }
}