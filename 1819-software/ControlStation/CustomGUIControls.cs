using System;
using System.Windows.Forms;
using System.Drawing;

namespace ControlStation
{
    public class BarGraphLabel : Label
    {
        public double Min, Max;
        public string Label, Unit;
        public Color BarColor;
        private double value;
        public void UpdateBarGraph(double value)
        {
            if(value < Min || value > Max)
            {
                throw new Exception("Bar graph set to value that was out of range");
            }
            this.value = value;
            //display the numeric value
            Text = Label + ": " + value + Unit;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackColor);
            g.DrawRectangle(new Pen(BarColor), 0, 0, (float)((value - Min) / (Max - Min) * Width), Height);
        }
    }
}