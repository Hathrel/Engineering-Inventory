namespace Engineering_Inventory
{
    partial class loginWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            usernameText = new Label();
            passwordText = new Label();
            usernameBox = new TextBox();
            passwordBox = new TextBox();
            logInButton = new Button();
            SuspendLayout();
            // 
            // usernameText
            // 
            usernameText.AutoSize = true;
            usernameText.Location = new Point(27, 9);
            usernameText.Name = "usernameText";
            usernameText.Size = new Size(65, 15);
            usernameText.TabIndex = 0;
            usernameText.Text = "User Name";
            // 
            // passwordText
            // 
            passwordText.AutoSize = true;
            passwordText.Location = new Point(27, 53);
            passwordText.Name = "passwordText";
            passwordText.Size = new Size(57, 15);
            passwordText.TabIndex = 1;
            passwordText.Text = "Password";
            // 
            // usernameBox
            // 
            usernameBox.Location = new Point(12, 27);
            usernameBox.Name = "usernameBox";
            usernameBox.Size = new Size(100, 23);
            usernameBox.TabIndex = 1;
            usernameBox.KeyPress += usernameBox_KeyPress;
            usernameBox.DpiChangedAfterParent += b;
            // 
            // passwordBox
            // 
            passwordBox.Location = new Point(12, 71);
            passwordBox.Name = "passwordBox";
            passwordBox.PasswordChar = '*';
            passwordBox.Size = new Size(100, 23);
            passwordBox.TabIndex = 2;
            passwordBox.KeyPress += passwordBox_KeyPress;
            // 
            // logInButton
            // 
            logInButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            logInButton.Location = new Point(12, 100);
            logInButton.Name = "logInButton";
            logInButton.Size = new Size(100, 32);
            logInButton.TabIndex = 3;
            logInButton.Text = "Log In";
            logInButton.UseVisualStyleBackColor = true;
            logInButton.Click += logInButton_Click;
            logInButton.KeyPress += logInButton_KeyPress;
            // 
            // loginWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(128, 139);
            Controls.Add(logInButton);
            Controls.Add(passwordBox);
            Controls.Add(usernameBox);
            Controls.Add(passwordText);
            Controls.Add(usernameText);
            Name = "loginWindow";
            Text = "Log In";
            KeyPress += loginWindow_KeyPress;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label usernameText;
        private Label passwordText;
        private TextBox usernameBox;
        private TextBox passwordBox;
        private Button logInButton;
    }
}
