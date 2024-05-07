﻿namespace Engineering_Inventory
{
    partial class CycleCounts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CycleCountBanner = new Label();
            CycleCountStatus = new Label();
            SubmitButton = new Button();
            CancelButton = new Button();
            LocationBox = new TextBox();
            LocationLabel = new Label();
            PartsBox = new Panel();
            SuspendLayout();
            // 
            // CycleCountBanner
            // 
            CycleCountBanner.AutoSize = true;
            CycleCountBanner.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            CycleCountBanner.Location = new Point(12, 9);
            CycleCountBanner.Name = "CycleCountBanner";
            CycleCountBanner.Size = new Size(181, 37);
            CycleCountBanner.TabIndex = 0;
            CycleCountBanner.Text = "Cycle Counts";
            // 
            // CycleCountStatus
            // 
            CycleCountStatus.AutoSize = true;
            CycleCountStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CycleCountStatus.Location = new Point(12, 46);
            CycleCountStatus.Name = "CycleCountStatus";
            CycleCountStatus.Size = new Size(40, 15);
            CycleCountStatus.TabIndex = 1;
            CycleCountStatus.Text = "label1";
            // 
            // SubmitButton
            // 
            SubmitButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            SubmitButton.Location = new Point(12, 109);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(75, 23);
            SubmitButton.TabIndex = 3;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CancelButton.Location = new Point(93, 109);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 4;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // LocationBox
            // 
            LocationBox.Location = new Point(12, 80);
            LocationBox.Name = "LocationBox";
            LocationBox.Size = new Size(155, 23);
            LocationBox.TabIndex = 5;
            LocationBox.KeyPress += LocationBox_KeyPress;
            // 
            // LocationLabel
            // 
            LocationLabel.AutoSize = true;
            LocationLabel.Location = new Point(63, 62);
            LocationLabel.Name = "LocationLabel";
            LocationLabel.Size = new Size(53, 15);
            LocationLabel.TabIndex = 6;
            LocationLabel.Text = "Location";
            // 
            // PartsBox
            // 
            PartsBox.AutoSize = true;
            PartsBox.Location = new Point(12, 138);
            PartsBox.Name = "PartsBox";
            PartsBox.Size = new Size(453, 300);
            PartsBox.TabIndex = 7;
            // 
            // CycleCounts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(474, 450);
            Controls.Add(PartsBox);
            Controls.Add(LocationLabel);
            Controls.Add(LocationBox);
            Controls.Add(CancelButton);
            Controls.Add(SubmitButton);
            Controls.Add(CycleCountStatus);
            Controls.Add(CycleCountBanner);
            Name = "CycleCounts";
            Text = "Cycle Counts";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CycleCountBanner;
        private Label CycleCountStatus;
        private Button SubmitButton;
        private Button CancelButton;
        private TextBox LocationBox;
        private Label LocationLabel;
        private Panel PartsBox;
    }
}