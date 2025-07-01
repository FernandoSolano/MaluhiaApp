using System.Windows.Forms;

namespace Maluhia
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.GroupBox groupBoxInterval;
        private System.Windows.Forms.Label labelFixed;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.NumericUpDown numericFixed;
        private System.Windows.Forms.NumericUpDown numericMin;
        private System.Windows.Forms.NumericUpDown numericMax;
        private System.Windows.Forms.RadioButton radioFixed;
        private System.Windows.Forms.RadioButton radioRandom;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button selectAreaButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Panel statusPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxInterval = new System.Windows.Forms.GroupBox();
            this.labelFixed = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelMax = new System.Windows.Forms.Label();
            this.numericFixed = new System.Windows.Forms.NumericUpDown();
            this.numericMin = new System.Windows.Forms.NumericUpDown();
            this.numericMax = new System.Windows.Forms.NumericUpDown();
            this.radioFixed = new System.Windows.Forms.RadioButton();
            this.radioRandom = new System.Windows.Forms.RadioButton();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.selectAreaButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusPanel = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.numericFixed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMax)).BeginInit();

            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(4);

            // 
            // groupBoxInterval
            // 
            this.groupBoxInterval.Text = "Interval Settings";
            this.groupBoxInterval.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxInterval.AutoSize = true;
            this.groupBoxInterval.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxInterval.Margin = new System.Windows.Forms.Padding(2, 2, 2, 4);
            this.groupBoxInterval.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);

            // Interval Layout
            var intervalLayout = new System.Windows.Forms.TableLayoutPanel();
            intervalLayout.ColumnCount = 2;
            intervalLayout.RowCount = 4;
            intervalLayout.Dock = System.Windows.Forms.DockStyle.Top;
            intervalLayout.AutoSize = true;
            intervalLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            intervalLayout.Margin = new System.Windows.Forms.Padding(0);
            intervalLayout.Padding = new System.Windows.Forms.Padding(0);
            intervalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            intervalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));

            // Row 0: Radio buttons
            this.radioFixed.Name = "radioFixed";
            this.radioFixed.Text = "Fixed interval";
            this.radioFixed.AutoSize = true;
            this.radioFixed.Margin = new System.Windows.Forms.Padding(2, 2, 8, 2);
            this.radioRandom.Name = "radioRandom";
            this.radioRandom.Text = "Random interval";
            this.radioRandom.AutoSize = true;
            this.radioRandom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            intervalLayout.Controls.Add(this.radioFixed, 0, 0);
            intervalLayout.Controls.Add(this.radioRandom, 1, 0);

            // Row 1: Fixed interval
            this.labelFixed.Name = "labelFixed";
            this.labelFixed.Text = "Interval (seconds):";
            this.labelFixed.AutoSize = true;
            this.labelFixed.Margin = new System.Windows.Forms.Padding(2, 2, 8, 2);
            this.numericFixed.Name = "numericFixed";
            this.numericFixed.Minimum = 1;
            this.numericFixed.Maximum = 3600;
            this.numericFixed.Value = 5;
            this.numericFixed.Width = 80;
            this.numericFixed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            intervalLayout.Controls.Add(this.labelFixed, 0, 1);
            intervalLayout.Controls.Add(this.numericFixed, 1, 1);

            // Row 2: Min interval
            this.labelMin.Name = "labelMin";
            this.labelMin.Text = "Min interval (seconds):";
            this.labelMin.AutoSize = true;
            this.labelMin.Margin = new System.Windows.Forms.Padding(2, 2, 8, 2);
            this.numericMin.Name = "numericMin";
            this.numericMin.Minimum = 1;
            this.numericMin.Maximum = 3600;
            this.numericMin.Value = 5;
            this.numericMin.Width = 80;
            this.numericMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            intervalLayout.Controls.Add(this.labelMin, 0, 2);
            intervalLayout.Controls.Add(this.numericMin, 1, 2);

            // Row 3: Max interval
            this.labelMax.Name = "labelMax";
            this.labelMax.Text = "Max interval (seconds):";
            this.labelMax.AutoSize = true;
            this.labelMax.Margin = new System.Windows.Forms.Padding(2, 2, 8, 2);
            this.numericMax.Name = "numericMax";
            this.numericMax.Minimum = 1;
            this.numericMax.Maximum = 3600;
            this.numericMax.Value = 10;
            this.numericMax.Width = 80;
            this.numericMax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            intervalLayout.Controls.Add(this.labelMax, 0, 3);
            intervalLayout.Controls.Add(this.numericMax, 1, 3);

            this.groupBoxInterval.Controls.Add(intervalLayout);

            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Text = "Actions";
            this.groupBoxActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxActions.AutoSize = true;
            this.groupBoxActions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxActions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxActions.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);

            // Actions Layout
            var actionsLayout = new System.Windows.Forms.TableLayoutPanel();
            actionsLayout.ColumnCount = 3;
            actionsLayout.RowCount = 2;
            actionsLayout.Dock = System.Windows.Forms.DockStyle.Top;
            actionsLayout.AutoSize = true;
            actionsLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            actionsLayout.Margin = new System.Windows.Forms.Padding(0);
            actionsLayout.Padding = new System.Windows.Forms.Padding(0);
            actionsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            actionsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            actionsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));

            // Row 0: Select area and status panel
            this.selectAreaButton.Name = "selectAreaButton";
            this.selectAreaButton.Text = "Select Area";
            this.selectAreaButton.Margin = new System.Windows.Forms.Padding(2, 2, 8, 2);

            // statusPanel with border for statusLabel
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusPanel.Padding = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.statusPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.statusPanel.AutoSize = true;
            this.statusPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Text = "Ready.";
            this.statusLabel.AutoSize = true;
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;

            this.statusPanel.Controls.Add(this.statusLabel);

            actionsLayout.Controls.Add(this.selectAreaButton, 0, 0);
            actionsLayout.Controls.Add(this.statusPanel, 1, 0);

            // Row 1: Start and Stop
            this.startButton.Name = "startButton";
            this.startButton.Text = "Start";
            this.startButton.Margin = new System.Windows.Forms.Padding(2, 2, 8, 2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Text = "Stop";
            this.stopButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            actionsLayout.Controls.Add(this.startButton, 0, 1);
            actionsLayout.Controls.Add(this.stopButton, 1, 1);

            this.groupBoxActions.Controls.Add(actionsLayout);

            // Add group boxes to tableLayoutPanel
            this.tableLayoutPanel.Controls.Add(this.groupBoxInterval, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.groupBoxActions, 0, 1);

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 220);
            this.MinimumSize = new System.Drawing.Size(400, 220);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "MainForm";
            this.Text = "Maluhia";

            ((System.ComponentModel.ISupportInitialize)(this.numericFixed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMax)).EndInit();
            this.ResumeLayout(false);
        }
    }
}