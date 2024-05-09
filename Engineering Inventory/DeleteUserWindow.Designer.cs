namespace Engineering_Inventory
{
    partial class DeleteUserWindow
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
            DeleteUserBanner = new Label();
            UsernameLabel = new Label();
            UsernameBox = new TextBox();
            SubmitButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // DeleteUserBanner
            // 
            DeleteUserBanner.AutoSize = true;
            DeleteUserBanner.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            DeleteUserBanner.Location = new Point(12, 9);
            DeleteUserBanner.Name = "DeleteUserBanner";
            DeleteUserBanner.Size = new Size(166, 37);
            DeleteUserBanner.TabIndex = 0;
            DeleteUserBanner.Text = "Delete User";
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(12, 46);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(60, 15);
            UsernameLabel.TabIndex = 1;
            UsernameLabel.Text = "Username";
            // 
            // UsernameBox
            // 
            UsernameBox.Location = new Point(12, 64);
            UsernameBox.Name = "UsernameBox";
            UsernameBox.Size = new Size(100, 23);
            UsernameBox.TabIndex = 2;
            UsernameBox.KeyPress += UsernameBox_KeyPress;
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(12, 93);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(75, 23);
            SubmitButton.TabIndex = 3;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(93, 93);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 4;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // DeleteUserWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(202, 141);
            Controls.Add(CancelButton);
            Controls.Add(SubmitButton);
            Controls.Add(UsernameBox);
            Controls.Add(UsernameLabel);
            Controls.Add(DeleteUserBanner);
            Name = "DeleteUserWindow";
            Text = "Delete User";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label DeleteUserBanner;
        private Label UsernameLabel;
        private TextBox UsernameBox;
        private Button SubmitButton;
        private Button CancelButton;
    }
}