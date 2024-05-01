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
            insertButton = new Button();
            welcomeLabel = new Label();
            actionsBox.SuspendLayout();
            SuspendLayout();
            // 
            // actionsBox
            // 
            actionsBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            actionsBox.Controls.Add(insertButton);
            actionsBox.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            actionsBox.Location = new Point(12, 29);
            actionsBox.Name = "actionsBox";
            actionsBox.Size = new Size(198, 409);
            actionsBox.TabIndex = 0;
            actionsBox.TabStop = false;
            actionsBox.Text = "Actions";
            // 
            // insertButton
            // 
            insertButton.Font = new Font("Segoe UI", 9F);
            insertButton.Location = new Point(6, 22);
            insertButton.Name = "insertButton";
            insertButton.Size = new Size(106, 26);
            insertButton.TabIndex = 0;
            insertButton.Text = "Insert Inventory";
            insertButton.TextAlign = ContentAlignment.MiddleLeft;
            insertButton.UseVisualStyleBackColor = true;
            insertButton.Click += insertButton_Click;
            // 
            // welcomeLabel
            // 
            welcomeLabel.AutoSize = true;
            welcomeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            welcomeLabel.Location = new Point(12, 9);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(60, 15);
            welcomeLabel.TabIndex = 1;
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
            Load += MainForm_Load;
            actionsBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBox1;
        private GroupBox actionsBox;
        private Button insertButton;
        private Label welcomeLabel;
    }
}