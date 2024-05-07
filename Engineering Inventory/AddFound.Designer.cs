namespace Engineering_Inventory
{
    partial class AddFound
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
            AddFoundBanner = new Label();
            AddFoundStatus = new Label();
            AddMoreBox = new CheckBox();
            PartBox = new TextBox();
            QtyBox = new TextBox();
            SubmitButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // AddFoundBanner
            // 
            AddFoundBanner.AutoSize = true;
            AddFoundBanner.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            AddFoundBanner.Location = new Point(12, 9);
            AddFoundBanner.Name = "AddFoundBanner";
            AddFoundBanner.Size = new Size(233, 30);
            AddFoundBanner.TabIndex = 0;
            AddFoundBanner.Text = "Add Found Inventory";
            // 
            // AddFoundStatus
            // 
            AddFoundStatus.AutoSize = true;
            AddFoundStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            AddFoundStatus.Location = new Point(12, 39);
            AddFoundStatus.Name = "AddFoundStatus";
            AddFoundStatus.Size = new Size(111, 15);
            AddFoundStatus.TabIndex = 1;
            AddFoundStatus.Text = "Found inventory in";
            // 
            // AddMoreBox
            // 
            AddMoreBox.AutoSize = true;
            AddMoreBox.Location = new Point(12, 115);
            AddMoreBox.Name = "AddMoreBox";
            AddMoreBox.Size = new Size(159, 19);
            AddMoreBox.TabIndex = 2;
            AddMoreBox.Text = "Add another found item?";
            AddMoreBox.UseVisualStyleBackColor = true;
            // 
            // PartBox
            // 
            PartBox.Location = new Point(12, 57);
            PartBox.Name = "PartBox";
            PartBox.Size = new Size(100, 23);
            PartBox.TabIndex = 3;
            PartBox.KeyPress += PartBox_KeyPress;
            // 
            // QtyBox
            // 
            QtyBox.Location = new Point(118, 57);
            QtyBox.Name = "QtyBox";
            QtyBox.Size = new Size(100, 23);
            QtyBox.TabIndex = 4;
            QtyBox.KeyPress += QtyBox_KeyPress;
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(12, 86);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(75, 23);
            SubmitButton.TabIndex = 5;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(93, 86);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 6;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // AddFound
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(241, 145);
            Controls.Add(CancelButton);
            Controls.Add(SubmitButton);
            Controls.Add(QtyBox);
            Controls.Add(PartBox);
            Controls.Add(AddMoreBox);
            Controls.Add(AddFoundStatus);
            Controls.Add(AddFoundBanner);
            Name = "AddFound";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AddFoundBanner;
        private Label AddFoundStatus;
        private CheckBox AddMoreBox;
        private TextBox PartBox;
        private TextBox QtyBox;
        private Button SubmitButton;
        private Button CancelButton;
    }
}