using System;
using System.Windows.Forms;
using System.Drawing;

namespace ControlStation
{
    public class BarGraph : FlowLayoutPanel
    {
        private double min, max;
        private string label, unit;
        private ProgressBar pb;
        private Label lb;
        public BarGraph(string label, string unit, Color barColor, double min, double max, int width)
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.label = label;
            this.unit = unit;
            pb = new ProgressBar()
            {
                ForeColor = barColor,
                Minimum = (int)(min * 10),
                Maximum = (int)(max * 10),
                Width = width,
            };
            lb = new Label()
            {
                AutoSize = true,
                Text = string.Format("{0}: {1:0.#}{2}", label, 0, unit)
            };
            Controls.Add(lb);
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
                //display the numeric value
                lb.Text = string.Format("{0}: {1:0.#}{2}", label, value, unit);
                pb.Value = (int)(value * 10);
                this.value = value;
            }
        }
    }
}