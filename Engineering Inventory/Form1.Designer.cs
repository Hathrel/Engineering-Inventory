namespace Engineering_Inventory
{
    partial class EditLocationWindow
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
            AddLocLabel = new Label();
            LocLabel = new Label();
            LocBox = new TextBox();
            SubmitButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // AddLocLabel
            // 
            AddLocLabel.AutoSize = true;
            AddLocLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            AddLocLabel.Location = new Point(12, 9);
            AddLocLabel.Name = "AddLocLabel";
            AddLocLabel.Size = new Size(188, 37);
            AddLocLabel.TabIndex = 0;
            AddLocLabel.Text = "Add Location";
            // 
            // LocLabel
            // 
            LocLabel.AutoSize = true;
            LocLabel.Location = new Point(12, 46);
            LocLabel.Name = "LocLabel";
            LocLabel.Size = new Size(83, 15);
            LocLabel.TabIndex = 1;
            LocLabel.Text = "Enter Location";
            // 
            // LocBox
            // 
            LocBox.Location = new Point(12, 64);
            LocBox.Name = "LocBox";
            LocBox.Size = new Size(100, 23);
            LocBox.TabIndex = 2;
            LocBox.KeyPress += LocBox_KeyPress;
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
            // EditLocationWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CancelButton);
            Controls.Add(SubmitButton);
            Controls.Add(LocBox);
            Controls.Add(LocLabel);
            Controls.Add(AddLocLabel);
            Name = "EditLocationWindow";
            Text = "Add Location";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AddLocLabel;
        private Label LocLabel;
        private TextBox LocBox;
        private Button SubmitButton;
        private Button CancelButton;
    }
}