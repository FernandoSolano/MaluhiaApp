using Maluhia.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Maluhia
{
    /// <summary>
    /// Main application form.
    /// 
    /// "Maluhia" means "peace" or "tranquility" in Hawaiian.
    /// The purpose of this application is to automate mouse clicks within a user-defined area,
    /// allowing users to perform repetitive tasks effortlessly and with less stress,
    /// thus promoting a more peaceful and relaxed workflow.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly Clicker clicker = new();
        private Rectangle selectedArea = Rectangle.Empty;
        private bool isClicking = false;

        public MainForm()
        {
            InitializeComponent();

            // Apply the Hawaiian theme to all controls
            ApplyHawaiianTheme(this);

            clicker.StatusChanged += msg =>
            {
                if (InvokeRequired)
                    Invoke(() => statusLabel.Text = msg);
                else
                    statusLabel.Text = msg;
            };
            radioFixed.Checked = true;

            // Set the initial visibility of interval controls
            labelFixed.Visible = numericFixed.Visible = radioFixed.Checked;
            labelMin.Visible = numericMin.Visible = radioRandom.Checked;
            labelMax.Visible = numericMax.Visible = radioRandom.Checked;

            UpdateIntervalControls();
            UpdateButtonStates();

            // Attach event handlers (if not set in the designer)
            startButton.Click += StartButton_Click;
            stopButton.Click += StopButton_Click;
            selectAreaButton.Click += SelectAreaButton_Click;
            radioFixed.CheckedChanged += IntervalTypeChanged;
            radioRandom.CheckedChanged += IntervalTypeChanged;

            // Prevent window resizing
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        /// <summary>
        /// Applies the Hawaiian color theme and font to all controls recursively.
        /// </summary>
        private void ApplyHawaiianTheme(Control root)
        {
            var mainFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            root.Font = mainFont;
            root.BackColor = Color.FromArgb(224, 242, 241);
            root.ForeColor = Color.FromArgb(33, 94, 104);

            foreach (Control ctrl in root.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = btn.Enabled
                        ? Color.FromArgb(178, 235, 242)
                        : Color.FromArgb(200, 213, 219);
                    btn.ForeColor = btn.Enabled
                        ? Color.FromArgb(33, 94, 104)
                        : Color.FromArgb(120, 144, 156);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = btn.Enabled
                        ? Color.FromArgb(255, 213, 153)
                        : Color.FromArgb(220, 220, 220);
                    btn.FlatAppearance.BorderSize = 1;
                    btn.AutoSize = true;
                    btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    btn.EnabledChanged += (s, e) =>
                    {
                        var b = (Button)s;
                        b.BackColor = b.Enabled
                            ? Color.FromArgb(178, 235, 242)
                            : Color.FromArgb(200, 213, 219);
                        b.ForeColor = b.Enabled
                            ? Color.FromArgb(33, 94, 104)
                            : Color.FromArgb(120, 144, 156);
                        b.FlatAppearance.BorderColor = b.Enabled
                            ? Color.FromArgb(255, 213, 153)
                            : Color.FromArgb(220, 220, 220);
                    };
                }
                else if (ctrl is Label lbl)
                {
                    lbl.ForeColor = Color.FromArgb(33, 94, 104);
                }
                else if (ctrl is RadioButton rb)
                {
                    rb.ForeColor = Color.FromArgb(33, 94, 104);
                    rb.BackColor = Color.FromArgb(224, 242, 241);
                }
                else if (ctrl is NumericUpDown nud)
                {
                    nud.BackColor = Color.FromArgb(255, 251, 230);
                    nud.ForeColor = Color.FromArgb(33, 94, 104);
                }
                if (ctrl.HasChildren)
                {
                    ApplyHawaiianTheme(ctrl);
                }
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (selectedArea == Rectangle.Empty)
            {
                statusLabel.Text = "Please select an area first.";
                selectAreaButton.Focus();
                return;
            }

            if (radioFixed.Checked)
            {
                if (numericFixed.Value < 1)
                {
                    statusLabel.Text = "Interval must be at least 1 second.";
                    numericFixed.Focus();
                    return;
                }
                clicker.SetInterval((int)numericFixed.Value, (int)numericFixed.Value);
            }
            else
            {
                int min = (int)numericMin.Value;
                int max = (int)numericMax.Value;
                if (min > max)
                {
                    statusLabel.Text = "Minimum interval cannot be greater than maximum interval.";
                    numericMin.Focus();
                    return;
                }
                clicker.SetInterval(min, max);
            }

            clicker.SetArea(selectedArea);
            clicker.Start();
            isClicking = true;
            UpdateButtonStates();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            clicker.Stop();
            isClicking = false;
            UpdateButtonStates();
        }

        private void SelectAreaButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var overlay = new AreaOverlayForm())
            {
                if (overlay.ShowDialog() == DialogResult.OK)
                {
                    selectedArea = overlay.SelectedArea;
                    statusLabel.Text = $"Area selected: {selectedArea.Width}x{selectedArea.Height} at ({selectedArea.X},{selectedArea.Y})";
                }
                else
                {
                    statusLabel.Text = "Area selection cancelled.";
                }
            }
            this.Show();
            UpdateButtonStates();
        }

        private void IntervalTypeChanged(object sender, EventArgs e)
        {
            // Show fixed interval controls only if radioFixed is selected
            labelFixed.Visible = numericFixed.Visible = radioFixed.Checked;

            // Show random interval controls only if radioRandom is selected
            labelMin.Visible = numericMin.Visible = radioRandom.Checked;
            labelMax.Visible = numericMax.Visible = radioRandom.Checked;

            UpdateIntervalControls();

            // Automatically resize the form when switching interval type
            this.SuspendLayout();
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.ResumeLayout();
        }

        private void UpdateIntervalControls()
        {
            numericFixed.Enabled = radioFixed.Checked && !isClicking;
            labelFixed.Enabled = radioFixed.Checked && !isClicking;

            numericMin.Enabled = radioRandom.Checked && !isClicking;
            labelMin.Enabled = radioRandom.Checked && !isClicking;
            numericMax.Enabled = radioRandom.Checked && !isClicking;
            labelMax.Enabled = radioRandom.Checked && !isClicking;
        }

        private void UpdateButtonStates()
        {
            startButton.Enabled = !isClicking && selectedArea != Rectangle.Empty;
            stopButton.Enabled = isClicking;
            selectAreaButton.Enabled = !isClicking;

            radioFixed.Enabled = !isClicking;
            radioRandom.Enabled = !isClicking;
            UpdateIntervalControls();
        }
    }
}