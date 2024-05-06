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
            PickingButton = new Button();
            insertButton = new Button();
            welcomeLabel = new Label();
            BinMove = new Button();
            actionsBox.SuspendLayout();
            SuspendLayout();
            // 
            // actionsBox
            // 
            actionsBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            actionsBox.Controls.Add(BinMove);
            actionsBox.Controls.Add(PickingButton);
            actionsBox.Controls.Add(insertButton);
            actionsBox.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            actionsBox.Location = new Point(12, 29);
            actionsBox.Name = "actionsBox";
            actionsBox.Size = new Size(231, 409);
            actionsBox.TabIndex = 0;
            actionsBox.TabStop = false;
            actionsBox.Text = "Actions";
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
            // welcomeLabel
            // 
            welcomeLabel.AutoSize = true;
            welcomeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            welcomeLabel.Location = new Point(12, 9);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(0, 15);
            welcomeLabel.TabIndex = 1;
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(welcomeLabel);
            Controls.Add(actionsBox);
            Name = "MainForm";
            Text = "Engineering Inventory";
            actionsBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox actionsBox;
        private Button insertButton;
        private Label welcomeLabel;
        private Button PickingButton;
        private Button BinMove;
    }
}