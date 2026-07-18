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

        private const int MarkerAreaWidth = 20;
        private const int BarWidth = 40;

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int barLeft = MarkerAreaWidth;
            int barTop = 0;
            int barHeight = Height;

            int range = Maximum - Minimum;
            if (range <= 0)
                return;

            // Background of whole control
            g.FillRectangle(Brushes.Black, 0, 0, Width, Height);

            // Bar background
            g.FillRectangle(Brushes.LightGray, barLeft, barTop, BarWidth, barHeight);

            int clampedValue = System.Math.Max(Minimum, System.Math.Min(Maximum, Value));
            int fillHeight = Height * (clampedValue - Minimum) / range;

            using (var brush = new SolidBrush(BarColor))
            {
                g.FillRectangle(
                    brush,
                    barLeft,
                    Height - fillHeight,
                    BarWidth,
                    fillHeight);
            }

            // Border around actual bar only
            g.DrawRectangle(
                Pens.DimGray,
                barLeft,
                barTop,
                BarWidth - 1,
                barHeight - 1);

            if (SPHH.HasValue) DrawSetpoint(g, SPHH.Value, Color.Red);
            if (SPH.HasValue) DrawSetpoint(g, SPH.Value, Color.Yellow);
            if (SPL.HasValue) DrawSetpoint(g, SPL.Value, Color.Yellow);
            if (SPLL.HasValue) DrawSetpoint(g, SPLL.Value, Color.Red);
        }

        private void DrawSetpoint(Graphics g, int value, Color color)
        {
            if (value < Minimum || value > Maximum)
                return;

            int range = Maximum - Minimum;
            if (range <= 0)
                return;

            int y = Height - Height * (value - Minimum) / range;

            int markerStartX = 0;
            int markerEndX = MarkerAreaWidth;

            using (var pen = new Pen(color, 2f))
            {
                g.DrawLine(pen, markerStartX, y, markerEndX, y);
            }
        }
    }
}