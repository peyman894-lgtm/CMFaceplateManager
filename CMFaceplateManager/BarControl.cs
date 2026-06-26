using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CMFaceplateManager
{
    public class VerticalBar : Control
    {
        public int Minimum { get; set; } = 0;
        public int Maximum { get; set; } = 100;
        public int Value { get; set; } = 50;
        public Color BarColor { get; set; } = Color.LimeGreen;

        public int? SPHH { get; set; } = null;
        public int? SPH { get; set; } = null;
        public int? SPL { get; set; } = null;
        public int? SPLL { get; set; } = null;

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.FillRectangle(Brushes.LightGray, 0, 0, Width, Height);

            int range = Maximum - Minimum;
            if (range <= 0)
                return;

            int clampedValue = System.Math.Max(Minimum, System.Math.Min(Maximum, Value));
            int fillHeight = Height * (clampedValue - Minimum) / range;

            using (var brush = new SolidBrush(BarColor))
                g.FillRectangle(brush, 0, Height - fillHeight, Width, fillHeight);

            g.DrawRectangle(Pens.DimGray, 0, 0, Width - 1, Height - 1);

            if (SPHH.HasValue) DrawSetpoint(g, SPHH.Value, Color.Red, "");
            if (SPH.HasValue) DrawSetpoint(g, SPH.Value, Color.Yellow, "");
            if (SPL.HasValue) DrawSetpoint(g, SPL.Value, Color.Yellow, "");
            if (SPLL.HasValue) DrawSetpoint(g, SPLL.Value, Color.Red, "");
        }

        private void DrawSetpoint(Graphics g, int value, Color color, string label)
        {
            if (value < Minimum || value > Maximum)
                return;

            int range = Maximum - Minimum;
            if (range <= 0)
                return;

            int y = Height - Height * (value - Minimum) / range;

            using (var pen = new Pen(color, 2f))
                g.DrawLine(pen, 0, y, Width, y);

            using (var brush = new SolidBrush(color))
                g.DrawString(label, Font, brush, 2, y - Font.Height / 2f);
        }
    }
}