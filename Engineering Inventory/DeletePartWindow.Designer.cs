namespace Engineering_Inventory
{
    partial class DeletePartWindow
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
            DeletePartBanner = new Label();
            PartNumberLabel = new Label();
            PartNumberBox = new TextBox();
            DescriptionBox = new TextBox();
            DescriptionLabel = new Label();
            SubmitButton = new Button();
            CancelButton = new Button();
            DeleteButton = new Button();
            SuspendLayout();
            // 
            // DeletePartBanner
            // 
            DeletePartBanner.AutoSize = true;
            DeletePartBanner.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            DeletePartBanner.Location = new Point(118, 9);
            DeletePartBanner.Name = "DeletePartBanner";
            DeletePartBanner.Size = new Size(162, 37);
            DeletePartBanner.TabIndex = 0;
            DeletePartBanner.Text = "Delete Part";
            // 
            // PartNumberLabel
            // 
            PartNumberLabel.AutoSize = true;
            PartNumberLabel.Location = new Point(26, 49);
            PartNumberLabel.Name = "PartNumberLabel";
            PartNumberLabel.Size = new Size(75, 15);
            PartNumberLabel.TabIndex = 1;
            PartNumberLabel.Text = "Part Number";
            // 
            // PartNumberBox
            // 
            PartNumberBox.Location = new Point(12, 67);
            PartNumberBox.Name = "PartNumberBox";
            PartNumberBox.Size = new Size(100, 23);
            PartNumberBox.TabIndex = 3;
            PartNumberBox.KeyPress += PartNumberBox_KeyPress;
            // 
            // DescriptionBox
            // 
            DescriptionBox.Enabled = false;
            DescriptionBox.Location = new Point(118, 67);
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.Size = new Size(416, 23);
            DescriptionBox.TabIndex = 4;
            DescriptionBox.Visible = false;
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(306, 49);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(67, 15);
            DescriptionLabel.TabIndex = 5;
            DescriptionLabel.Text = "Description";
            DescriptionLabel.Visible = false;
            // 
            // SubmitButton
            // 
            SubmitButton.Font = new Font("Segoe UI", 9F);
            SubmitButton.Location = new Point(12, 96);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(75, 23);
            SubmitButton.TabIndex = 6;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.MouseClick += SubmitButton_MouseClick;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(93, 96);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 7;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DeleteButton.Location = new Point(458, 96);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 8;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Visible = false;
            DeleteButton.MouseClick += DeleteButton_MouseClick;
            // 
            // DeletePartWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 135);
            Controls.Add(DeleteButton);
            Controls.Add(CancelButton);
            Controls.Add(SubmitButton);
            Controls.Add(DescriptionLabel);
            Controls.Add(DescriptionBox);
            Controls.Add(PartNumberBox);
            Controls.Add(PartNumberLabel);
            Controls.Add(DeletePartBanner);
            Name = "DeletePartWindow";
            Text = "Delete Part";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label DeletePartBanner;
        private Label PartNumberLabel;
        private TextBox PartNumberBox;
        private TextBox DescriptionBox;
        private Label DescriptionLabel;
        private Button SubmitButton;
        private Button CancelButton;
        private Button DeleteButton;
    }
}