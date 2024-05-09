namespace Engineering_Inventory
{
    partial class AddUserWindow
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
            AddUserBanner = new Label();
            PasswordBox = new TextBox();
            UserNameBox = new TextBox();
            PasswordLabel = new Label();
            UsernameLabel = new Label();
            CVG2Box = new CheckBox();
            LEX1Box = new CheckBox();
            SitePermissionsLabel = new Label();
            YYZBox = new CheckBox();
            SwedesBox = new CheckBox();
            WestChesterBox = new CheckBox();
            OtherPermissionsLabel = new Label();
            EditInventoryBox = new CheckBox();
            EditPartsBox = new CheckBox();
            EditLocationsBox = new CheckBox();
            AdminBox = new CheckBox();
            SubmitButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // AddUserBanner
            // 
            AddUserBanner.AutoSize = true;
            AddUserBanner.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            AddUserBanner.Location = new Point(89, 9);
            AddUserBanner.Name = "AddUserBanner";
            AddUserBanner.Size = new Size(135, 37);
            AddUserBanner.TabIndex = 0;
            AddUserBanner.Text = "Add User";
            // 
            // PasswordBox
            // 
            PasswordBox.Location = new Point(118, 65);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.Size = new Size(100, 23);
            PasswordBox.TabIndex = 2;
            PasswordBox.KeyPress += PasswordBox_KeyPress;
            // 
            // UserNameBox
            // 
            UserNameBox.Location = new Point(7, 65);
            UserNameBox.Name = "UserNameBox";
            UserNameBox.Size = new Size(100, 23);
            UserNameBox.TabIndex = 1;
            UserNameBox.KeyPress += UserNameBox_KeyPress;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(118, 47);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(57, 15);
            PasswordLabel.TabIndex = 3;
            PasswordLabel.Text = "Password";
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(7, 47);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(60, 15);
            UsernameLabel.TabIndex = 4;
            UsernameLabel.Text = "Username";
            // 
            // CVG2Box
            // 
            CVG2Box.AutoSize = true;
            CVG2Box.Location = new Point(7, 109);
            CVG2Box.Name = "CVG2Box";
            CVG2Box.Size = new Size(55, 19);
            CVG2Box.TabIndex = 3;
            CVG2Box.Text = "CVG2";
            CVG2Box.UseVisualStyleBackColor = true;
            // 
            // LEX1Box
            // 
            LEX1Box.AutoSize = true;
            LEX1Box.Location = new Point(7, 134);
            LEX1Box.Name = "LEX1Box";
            LEX1Box.Size = new Size(51, 19);
            LEX1Box.TabIndex = 4;
            LEX1Box.Text = "LEX1";
            LEX1Box.UseVisualStyleBackColor = true;
            // 
            // SitePermissionsLabel
            // 
            SitePermissionsLabel.AutoSize = true;
            SitePermissionsLabel.Location = new Point(7, 91);
            SitePermissionsLabel.Name = "SitePermissionsLabel";
            SitePermissionsLabel.Size = new Size(92, 15);
            SitePermissionsLabel.TabIndex = 8;
            SitePermissionsLabel.Text = "Site Permissions";
            // 
            // YYZBox
            // 
            YYZBox.AutoSize = true;
            YYZBox.Location = new Point(7, 159);
            YYZBox.Name = "YYZBox";
            YYZBox.Size = new Size(47, 19);
            YYZBox.TabIndex = 5;
            YYZBox.Text = "YYZ";
            YYZBox.UseVisualStyleBackColor = true;
            // 
            // SwedesBox
            // 
            SwedesBox.AutoSize = true;
            SwedesBox.ImageAlign = ContentAlignment.BottomRight;
            SwedesBox.Location = new Point(64, 109);
            SwedesBox.Name = "SwedesBox";
            SwedesBox.Size = new Size(124, 19);
            SwedesBox.TabIndex = 6;
            SwedesBox.Text = "SWEDESBORO_117";
            SwedesBox.UseVisualStyleBackColor = true;
            // 
            // WestChesterBox
            // 
            WestChesterBox.AutoSize = true;
            WestChesterBox.Location = new Point(64, 134);
            WestChesterBox.Name = "WestChesterBox";
            WestChesterBox.Size = new Size(131, 19);
            WestChesterBox.TabIndex = 7;
            WestChesterBox.Text = "WESTCHESTER_1305";
            WestChesterBox.UseVisualStyleBackColor = true;
            // 
            // OtherPermissionsLabel
            // 
            OtherPermissionsLabel.AutoSize = true;
            OtherPermissionsLabel.Location = new Point(224, 91);
            OtherPermissionsLabel.Name = "OtherPermissionsLabel";
            OtherPermissionsLabel.Size = new Size(103, 15);
            OtherPermissionsLabel.TabIndex = 13;
            OtherPermissionsLabel.Text = "Other Permissions";
            // 
            // EditInventoryBox
            // 
            EditInventoryBox.AutoSize = true;
            EditInventoryBox.Checked = true;
            EditInventoryBox.CheckState = CheckState.Checked;
            EditInventoryBox.Location = new Point(196, 109);
            EditInventoryBox.Name = "EditInventoryBox";
            EditInventoryBox.Size = new Size(99, 19);
            EditInventoryBox.TabIndex = 8;
            EditInventoryBox.Text = "Edit Inventory";
            EditInventoryBox.UseVisualStyleBackColor = true;
            // 
            // EditPartsBox
            // 
            EditPartsBox.AutoSize = true;
            EditPartsBox.Location = new Point(301, 109);
            EditPartsBox.Name = "EditPartsBox";
            EditPartsBox.Size = new Size(75, 19);
            EditPartsBox.TabIndex = 9;
            EditPartsBox.Text = "Edit Parts";
            EditPartsBox.UseVisualStyleBackColor = true;
            // 
            // EditLocationsBox
            // 
            EditLocationsBox.AutoSize = true;
            EditLocationsBox.Location = new Point(196, 134);
            EditLocationsBox.Name = "EditLocationsBox";
            EditLocationsBox.Size = new Size(100, 19);
            EditLocationsBox.TabIndex = 10;
            EditLocationsBox.Text = "Edit Locations";
            EditLocationsBox.UseVisualStyleBackColor = true;
            // 
            // AdminBox
            // 
            AdminBox.AutoSize = true;
            AdminBox.Location = new Point(302, 134);
            AdminBox.Name = "AdminBox";
            AdminBox.Size = new Size(62, 19);
            AdminBox.TabIndex = 11;
            AdminBox.Text = "Admin";
            AdminBox.UseVisualStyleBackColor = true;
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(7, 184);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(75, 23);
            SubmitButton.TabIndex = 14;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(88, 184);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 15;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // AddUserWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 209);
            Controls.Add(CancelButton);
            Controls.Add(SubmitButton);
            Controls.Add(AdminBox);
            Controls.Add(EditLocationsBox);
            Controls.Add(EditPartsBox);
            Controls.Add(EditInventoryBox);
            Controls.Add(OtherPermissionsLabel);
            Controls.Add(WestChesterBox);
            Controls.Add(SwedesBox);
            Controls.Add(YYZBox);
            Controls.Add(SitePermissionsLabel);
            Controls.Add(LEX1Box);
            Controls.Add(CVG2Box);
            Controls.Add(UsernameLabel);
            Controls.Add(PasswordLabel);
            Controls.Add(UserNameBox);
            Controls.Add(PasswordBox);
            Controls.Add(AddUserBanner);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "AddUserWindow";
            Text = "Add User";
            Load += AddUserWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AddUserBanner;
        private TextBox PasswordBox;
        private TextBox UserNameBox;
        private Label PasswordLabel;
        private Label UsernameLabel;
        private CheckBox CVG2Box;
        private CheckBox LEX1Box;
        private Label SitePermissionsLabel;
        private CheckBox YYZBox;
        private CheckBox SwedesBox;
        private CheckBox WestChesterBox;
        private Label OtherPermissionsLabel;
        private CheckBox EditInventoryBox;
        private CheckBox EditPartsBox;
        private CheckBox EditLocationsBox;
        private CheckBox AdminBox;
        private Button SubmitButton;
        private Button CancelButton;
    }
}