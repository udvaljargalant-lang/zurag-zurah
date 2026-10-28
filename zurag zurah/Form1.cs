using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace zurag_zurah
{
    public partial class Form1 : Form
    {
        private List<Point> points = new List<Point>();
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            points.Add(e.Location);
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen pen = new Pen(Color.Black, 2); // Шугамын өнгө, өргөн
            Brush brush = Brushes.Red;          // Цэгийн өнгө

            int pointRadius = 4; // Цэгийн хэмжээ (радиус)

            // 1. Цэгүүдийг хооронд нь шугамаар холбож зурах
            if (points.Count > 1)
            {
                e.Graphics.DrawLines(pen, points.ToArray());
            }
            foreach (var pt in points)
            {
                e.Graphics.FillEllipse(brush, pt.X - pointRadius, pt.Y - pointRadius, pointRadius * 2, pointRadius * 2);
            }
        }
    }
}