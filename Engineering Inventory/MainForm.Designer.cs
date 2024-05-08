namespace Engineering_Inventory
{
    partial class MainForm
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
            actionsBox = new GroupBox();
            CycleCount = new Button();
            BinMove = new Button();
            PickingButton = new Button();
            insertButton = new Button();
            MainStatusLabel = new Label();
            AddPartButton = new Button();
            PartEditBox = new GroupBox();
            EditPartButton = new Button();
            DeletePartButton = new Button();
            DeleteLocationButton = new Button();
            AddLocationButton = new Button();
            AdminActionsBox = new GroupBox();
            EditUserButton = new Button();
            DeleteUserButton = new Button();
            AddUserButton = new Button();
            LocationEditBox = new GroupBox();
            actionsBox.SuspendLayout();
            PartEditBox.SuspendLayout();
            AdminActionsBox.SuspendLayout();
            LocationEditBox.SuspendLayout();
            SuspendLayout();
            // 
            // actionsBox
            // 
            actionsBox.Controls.Add(CycleCount);
            actionsBox.Controls.Add(BinMove);
            actionsBox.Controls.Add(PickingButton);
            actionsBox.Controls.Add(insertButton);
            actionsBox.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            actionsBox.Location = new Point(12, 29);
            actionsBox.Name = "actionsBox";
            actionsBox.Size = new Size(231, 84);
            actionsBox.TabIndex = 0;
            actionsBox.TabStop = false;
            actionsBox.Text = "Inventory Actions";
            actionsBox.Visible = false;
            // 
            // CycleCount
            // 
            CycleCount.Font = new Font("Segoe UI", 9F);
            CycleCount.Location = new Point(119, 54);
            CycleCount.Name = "CycleCount";
            CycleCount.Size = new Size(106, 26);
            CycleCount.TabIndex = 3;
            CycleCount.Text = "Cycle Counts";
            CycleCount.UseVisualStyleBackColor = true;
            CycleCount.MouseClick += CycleCount_MouseClick;
            // 
            // BinMove
            // 
            BinMove.Font = new Font("Segoe UI", 9F);
            BinMove.Location = new Point(6, 54);
            BinMove.Name = "BinMove";
            BinMove.Size = new Size(106, 26);
            BinMove.TabIndex = 2;
            BinMove.Text = "Move Inventory";
            BinMove.UseVisualStyleBackColor = true;
            BinMove.Click += BinMove_Click;
            // 
            // PickingButton
            // 
            PickingButton.Font = new Font("Segoe UI", 9F);
            PickingButton.Location = new Point(118, 22);
            PickingButton.Name = "PickingButton";
            PickingButton.Size = new Size(106, 26);
            PickingButton.TabIndex = 1;
            PickingButton.Text = "Pick Inventory";
            PickingButton.UseVisualStyleBackColor = true;
            PickingButton.Click += PickingButton_Click;
            // 
            // insertButton
            // 
            insertButton.Font = new Font("Segoe UI", 9F);
            insertButton.Location = new Point(6, 22);
            insertButton.Name = "insertButton";
            insertButton.Size = new Size(106, 26);
            insertButton.TabIndex = 0;
            insertButton.Text = "Insert Inventory";
            insertButton.UseVisualStyleBackColor = true;
            insertButton.Click += insertButton_Click;
            // 
            // MainStatusLabel
            // 
            MainStatusLabel.AutoSize = true;
            MainStatusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            MainStatusLabel.Location = new Point(12, 9);
            MainStatusLabel.Name = "MainStatusLabel";
            MainStatusLabel.Size = new Size(40, 15);
            MainStatusLabel.TabIndex = 1;
            MainStatusLabel.Text = "label1";
            // 
            // AddPartButton
            // 
            AddPartButton.Font = new Font("Segoe UI", 9F);
            AddPartButton.Location = new Point(6, 22);
            AddPartButton.Name = "AddPartButton";
            AddPartButton.Size = new Size(106, 23);
            AddPartButton.TabIndex = 2;
            AddPartButton.Text = "Add New Part";
            AddPartButton.UseVisualStyleBackColor = true;
            AddPartButton.Click += AddPartButton_Click;
            // 
            // PartEditBox
            // 
            PartEditBox.Controls.Add(EditPartButton);
            PartEditBox.Controls.Add(DeletePartButton);
            PartEditBox.Controls.Add(AddPartButton);
            PartEditBox.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            PartEditBox.Location = new Point(12, 121);
            PartEditBox.Name = "PartEditBox";
            PartEditBox.Size = new Size(231, 80);
            PartEditBox.TabIndex = 3;
            PartEditBox.TabStop = false;
            PartEditBox.Text = "Part Actions";
            PartEditBox.Visible = false;
            // 
            // EditPartButton
            // 
            EditPartButton.Font = new Font("Segoe UI", 9F);
            EditPartButton.Location = new Point(6, 51);
            EditPartButton.Name = "EditPartButton";
            EditPartButton.Size = new Size(106, 23);
            EditPartButton.TabIndex = 5;
            EditPartButton.Text = "Edit Existing Part";
            EditPartButton.UseVisualStyleBackColor = true;
            // 
            // DeletePartButton
            // 
            DeletePartButton.Font = new Font("Segoe UI", 9F);
            DeletePartButton.Location = new Point(118, 22);
            DeletePartButton.Name = "DeletePartButton";
            DeletePartButton.Size = new Size(106, 23);
            DeletePartButton.TabIndex = 4;
            DeletePartButton.Text = "Delete Part";
            DeletePartButton.UseVisualStyleBackColor = true;
            // 
            // DeleteLocationButton
            // 
            DeleteLocationButton.Font = new Font("Segoe UI", 9F);
            DeleteLocationButton.Location = new Point(118, 22);
            DeleteLocationButton.Name = "DeleteLocationButton";
            DeleteLocationButton.Size = new Size(106, 23);
            DeleteLocationButton.TabIndex = 6;
            DeleteLocationButton.Text = "Delete Location";
            DeleteLocationButton.UseVisualStyleBackColor = true;
            // 
            // AddLocationButton
            // 
            AddLocationButton.Font = new Font("Segoe UI", 9F);
            AddLocationButton.Location = new Point(6, 22);
            AddLocationButton.Name = "AddLocationButton";
            AddLocationButton.Size = new Size(106, 23);
            AddLocationButton.TabIndex = 5;
            AddLocationButton.Text = "Add New Loc";
            AddLocationButton.UseVisualStyleBackColor = true;
            // 
            // AdminActionsBox
            // 
            AdminActionsBox.Controls.Add(EditUserButton);
            AdminActionsBox.Controls.Add(DeleteUserButton);
            AdminActionsBox.Controls.Add(AddUserButton);
            AdminActionsBox.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            AdminActionsBox.Location = new Point(12, 293);
            AdminActionsBox.Name = "AdminActionsBox";
            AdminActionsBox.Size = new Size(231, 81);
            AdminActionsBox.TabIndex = 4;
            AdminActionsBox.TabStop = false;
            AdminActionsBox.Text = "Admin Actions";
            AdminActionsBox.Visible = false;
            // 
            // EditUserButton
            // 
            EditUserButton.Font = new Font("Segoe UI", 9F);
            EditUserButton.Location = new Point(6, 51);
            EditUserButton.Name = "EditUserButton";
            EditUserButton.Size = new Size(106, 23);
            EditUserButton.TabIndex = 2;
            EditUserButton.Text = "Edit User";
            EditUserButton.UseVisualStyleBackColor = true;
            // 
            // DeleteUserButton
            // 
            DeleteUserButton.Font = new Font("Segoe UI", 9F);
            DeleteUserButton.Location = new Point(119, 22);
            DeleteUserButton.Name = "DeleteUserButton";
            DeleteUserButton.Size = new Size(106, 23);
            DeleteUserButton.TabIndex = 1;
            DeleteUserButton.Text = "Delete User";
            DeleteUserButton.UseVisualStyleBackColor = true;
            // 
            // AddUserButton
            // 
            AddUserButton.Font = new Font("Segoe UI", 9F);
            AddUserButton.Location = new Point(6, 22);
            AddUserButton.Name = "AddUserButton";
            AddUserButton.Size = new Size(106, 23);
            AddUserButton.TabIndex = 0;
            AddUserButton.Text = "Add User";
            AddUserButton.UseVisualStyleBackColor = true;
            // 
            // LocationEditBox
            // 
            LocationEditBox.Controls.Add(AddLocationButton);
            LocationEditBox.Controls.Add(DeleteLocationButton);
            LocationEditBox.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            LocationEditBox.Location = new Point(12, 207);
            LocationEditBox.Name = "LocationEditBox";
            LocationEditBox.Size = new Size(231, 80);
            LocationEditBox.TabIndex = 7;
            LocationEditBox.TabStop = false;
            LocationEditBox.Text = "Location Actions";
            LocationEditBox.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(258, 381);
            Controls.Add(LocationEditBox);
            Controls.Add(AdminActionsBox);
            Controls.Add(PartEditBox);
            Controls.Add(MainStatusLabel);
            Controls.Add(actionsBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "MainForm";
            Text = "Engineering Inventory Interface v1";
            Load += MainForm_Load;
            actionsBox.ResumeLayout(false);
            PartEditBox.ResumeLayout(false);
            AdminActionsBox.ResumeLayout(false);
            LocationEditBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox actionsBox;
        private Button insertButton;
        private Label welcomeLabel;
        private Button PickingButton;
        private Button BinMove;
        private Button CycleCount;
        private Label MainStatusLabel;
        private Button AddPartButton;
        private GroupBox PartEditBox;
        private Button AddLocationButton;
        private Button EditPartButton;
        private Button DeletePartButton;
        private Button DeleteLocationButton;
        private GroupBox AdminActionsBox;
        private Button EditUserButton;
        private Button DeleteUserButton;
        private Button AddUserButton;
        private GroupBox LocationEditBox;
    }
}