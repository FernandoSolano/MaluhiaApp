using System;
using System.Drawing;
using System.Windows.Forms;

namespace Maluhia
{
    /// <summary>
    /// Overlay form for selecting an area on the screen with improved UX.
    /// </summary>
    [System.ComponentModel.DesignerCategory("Code")]
    public partial class AreaOverlayForm : Form
    {
        private Point startPoint;
        private Rectangle selectedArea;
        private bool isDragging = false;
        private readonly Font helpFont = new Font("Segoe UI", 14, FontStyle.Bold);
        private bool showHelp = true;

        public Rectangle SelectedArea => selectedArea;

        public AreaOverlayForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            Opacity = 0.3;
            BackColor = Color.Blue;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            DoubleBuffered = true;
            Cursor = Cursors.Cross;
            KeyPreview = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Activate();
            Focus();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = e.Location;
                selectedArea = new Rectangle(e.Location, new Size(0, 0));
                showHelp = false;
                Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isDragging)
            {
                int x = Math.Min(startPoint.X, e.X);
                int y = Math.Min(startPoint.Y, e.Y);
                int width = Math.Abs(startPoint.X - e.X);
                int height = Math.Abs(startPoint.Y - e.Y);
                selectedArea = new Rectangle(x, y, width, height);
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (isDragging)
            {
                isDragging = false;
                if (selectedArea.Width > 5 && selectedArea.Height > 5)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    selectedArea = Rectangle.Empty;
                    Invalidate();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (selectedArea != Rectangle.Empty)
            {
                using var fillBrush = new SolidBrush(Color.FromArgb(80, Color.Red));
                e.Graphics.FillRectangle(fillBrush, selectedArea);
                using var pen = new Pen(Color.Red, 3);
                e.Graphics.DrawRectangle(pen, selectedArea);
            }
            if (showHelp)
            {
                string helpText = "Click and drag to select an area.\nPress Esc to cancel.";
                SizeF textSize = e.Graphics.MeasureString(helpText, helpFont);
                var rect = new RectangleF(
                    (Width - textSize.Width) / 2,
                    40,
                    textSize.Width + 20,
                    textSize.Height + 20
                );
                using var bgBrush = new SolidBrush(Color.FromArgb(180, Color.Black));
                e.Graphics.FillRectangle(bgBrush, rect);
                using var textBrush = new SolidBrush(Color.White);
                e.Graphics.DrawString(helpText, helpFont, textBrush, rect.Left + 10, rect.Top + 10);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                selectedArea = Rectangle.Empty;
                DialogResult = DialogResult.Cancel;
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}