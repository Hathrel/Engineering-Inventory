namespace Engineering_Inventory
{
    partial class EditPartWindow
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
            EditPartBanner = new Label();
            PartNumberBox = new TextBox();
            PartNumberLabel = new Label();
            MinnBox = new TextBox();
            MinnLabel = new Label();
            MaxxLabel = new Label();
            MaxxBox = new TextBox();
            DescriptionBox = new TextBox();
            LeadTimeBox = new TextBox();
            SupplierBox = new TextBox();
            DescriptionLabel = new Label();
            LeadTimeLabel = new Label();
            SupplierLabel = new Label();
            CommentBox = new TextBox();
            PriceBox = new TextBox();
            PurchaseLinkBox = new TextBox();
            CommentLabel = new Label();
            PriceLabel = new Label();
            PurchaseLinkLabel = new Label();
            SubmitButton = new Button();
            ResetButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // EditPartBanner
            // 
            EditPartBanner.AutoSize = true;
            EditPartBanner.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            EditPartBanner.Location = new Point(160, 9);
            EditPartBanner.Name = "EditPartBanner";
            EditPartBanner.Size = new Size(128, 37);
            EditPartBanner.TabIndex = 0;
            EditPartBanner.Text = "Edit Part";
            // 
            // PartNumberBox
            // 
            PartNumberBox.Location = new Point(12, 82);
            PartNumberBox.Name = "PartNumberBox";
            PartNumberBox.Size = new Size(100, 23);
            PartNumberBox.TabIndex = 1;
            PartNumberBox.KeyPress += PartNumberBox_KeyPress;
            // 
            // PartNumberLabel
            // 
            PartNumberLabel.AutoSize = true;
            PartNumberLabel.Location = new Point(12, 64);
            PartNumberLabel.Name = "PartNumberLabel";
            PartNumberLabel.Size = new Size(75, 15);
            PartNumberLabel.TabIndex = 2;
            PartNumberLabel.Text = "Part Number";
            // 
            // MinnBox
            // 
            MinnBox.Enabled = false;
            MinnBox.Location = new Point(12, 126);
            MinnBox.Name = "MinnBox";
            MinnBox.Size = new Size(100, 23);
            MinnBox.TabIndex = 3;
            // 
            // MinnLabel
            // 
            MinnLabel.AutoSize = true;
            MinnLabel.Location = new Point(12, 108);
            MinnLabel.Name = "MinnLabel";
            MinnLabel.Size = new Size(109, 15);
            MinnLabel.TabIndex = 4;
            MinnLabel.Text = "Minimum Quantity";
            // 
            // MaxxLabel
            // 
            MaxxLabel.AutoSize = true;
            MaxxLabel.Location = new Point(12, 152);
            MaxxLabel.Name = "MaxxLabel";
            MaxxLabel.Size = new Size(111, 15);
            MaxxLabel.TabIndex = 5;
            MaxxLabel.Text = "Maximum Quantity";
            // 
            // MaxxBox
            // 
            MaxxBox.Enabled = false;
            MaxxBox.Location = new Point(12, 170);
            MaxxBox.Name = "MaxxBox";
            MaxxBox.Size = new Size(100, 23);
            MaxxBox.TabIndex = 5;
            // 
            // DescriptionBox
            // 
            DescriptionBox.Enabled = false;
            DescriptionBox.Location = new Point(118, 82);
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.Size = new Size(312, 23);
            DescriptionBox.TabIndex = 2;
            // 
            // LeadTimeBox
            // 
            LeadTimeBox.Enabled = false;
            LeadTimeBox.Location = new Point(12, 214);
            LeadTimeBox.Name = "LeadTimeBox";
            LeadTimeBox.Size = new Size(100, 23);
            LeadTimeBox.TabIndex = 8;
            // 
            // SupplierBox
            // 
            SupplierBox.Enabled = false;
            SupplierBox.Location = new Point(118, 126);
            SupplierBox.Name = "SupplierBox";
            SupplierBox.Size = new Size(100, 23);
            SupplierBox.TabIndex = 4;
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(124, 64);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(67, 15);
            DescriptionLabel.TabIndex = 10;
            DescriptionLabel.Text = "Description";
            // 
            // LeadTimeLabel
            // 
            LeadTimeLabel.AutoSize = true;
            LeadTimeLabel.Location = new Point(12, 196);
            LeadTimeLabel.Name = "LeadTimeLabel";
            LeadTimeLabel.Size = new Size(61, 15);
            LeadTimeLabel.TabIndex = 11;
            LeadTimeLabel.Text = "Lead Time";
            // 
            // SupplierLabel
            // 
            SupplierLabel.AutoSize = true;
            SupplierLabel.Location = new Point(135, 108);
            SupplierLabel.Name = "SupplierLabel";
            SupplierLabel.Size = new Size(50, 15);
            SupplierLabel.TabIndex = 12;
            SupplierLabel.Text = "Supplier";
            // 
            // CommentBox
            // 
            CommentBox.Enabled = false;
            CommentBox.Location = new Point(118, 214);
            CommentBox.Name = "CommentBox";
            CommentBox.Size = new Size(312, 23);
            CommentBox.TabIndex = 9;
            // 
            // PriceBox
            // 
            PriceBox.Enabled = false;
            PriceBox.Location = new Point(118, 170);
            PriceBox.Name = "PriceBox";
            PriceBox.Size = new Size(100, 23);
            PriceBox.TabIndex = 6;
            // 
            // PurchaseLinkBox
            // 
            PurchaseLinkBox.Enabled = false;
            PurchaseLinkBox.Location = new Point(224, 170);
            PurchaseLinkBox.Name = "PurchaseLinkBox";
            PurchaseLinkBox.Size = new Size(206, 23);
            PurchaseLinkBox.TabIndex = 7;
            // 
            // CommentLabel
            // 
            CommentLabel.AutoSize = true;
            CommentLabel.Location = new Point(124, 196);
            CommentLabel.Name = "CommentLabel";
            CommentLabel.Size = new Size(61, 15);
            CommentLabel.TabIndex = 16;
            CommentLabel.Text = "Comment";
            // 
            // PriceLabel
            // 
            PriceLabel.AutoSize = true;
            PriceLabel.Location = new Point(135, 152);
            PriceLabel.Name = "PriceLabel";
            PriceLabel.Size = new Size(33, 15);
            PriceLabel.TabIndex = 17;
            PriceLabel.Text = "Price";
            // 
            // PurchaseLinkLabel
            // 
            PurchaseLinkLabel.AutoSize = true;
            PurchaseLinkLabel.Location = new Point(224, 152);
            PurchaseLinkLabel.Name = "PurchaseLinkLabel";
            PurchaseLinkLabel.Size = new Size(80, 15);
            PurchaseLinkLabel.TabIndex = 18;
            PurchaseLinkLabel.Text = "Purchase Link";
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(12, 243);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(75, 23);
            SubmitButton.TabIndex = 10;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.MouseClick += SubmitButton_MouseClick;
            // 
            // ResetButton
            // 
            ResetButton.Location = new Point(93, 243);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(75, 23);
            ResetButton.TabIndex = 11;
            ResetButton.Text = "Reset";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Click += ResetButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(174, 243);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 12;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // EditPartWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 277);
            Controls.Add(CancelButton);
            Controls.Add(ResetButton);
            Controls.Add(SubmitButton);
            Controls.Add(PurchaseLinkLabel);
            Controls.Add(PriceLabel);
            Controls.Add(CommentLabel);
            Controls.Add(PurchaseLinkBox);
            Controls.Add(PriceBox);
            Controls.Add(CommentBox);
            Controls.Add(SupplierLabel);
            Controls.Add(LeadTimeLabel);
            Controls.Add(DescriptionLabel);
            Controls.Add(SupplierBox);
            Controls.Add(LeadTimeBox);
            Controls.Add(DescriptionBox);
            Controls.Add(MaxxBox);
            Controls.Add(MaxxLabel);
            Controls.Add(MinnLabel);
            Controls.Add(MinnBox);
            Controls.Add(PartNumberLabel);
            Controls.Add(PartNumberBox);
            Controls.Add(EditPartBanner);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "EditPartWindow";
            Text = "Edit Part";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label EditPartBanner;
        private TextBox PartNumberBox;
        private Label PartNumberLabel;
        private TextBox MinnBox;
        private Label MinnLabel;
        private Label MaxxLabel;
        private TextBox MaxxBox;
        private TextBox DescriptionBox;
        private TextBox LeadTimeBox;
        private TextBox SupplierBox;
        private Label DescriptionLabel;
        private Label LeadTimeLabel;
        private Label SupplierLabel;
        private TextBox CommentBox;
        private TextBox PriceBox;
        private TextBox PurchaseLinkBox;
        private Label CommentLabel;
        private Label PriceLabel;
        private Label PurchaseLinkLabel;
        private Button SubmitButton;
        private Button ResetButton;
        private Button CancelButton;
    }
}