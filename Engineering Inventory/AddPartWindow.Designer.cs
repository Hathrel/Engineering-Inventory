namespace Engineering_Inventory
{
    partial class AddPartWindow
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
            PartNumberBox = new TextBox();
            PartNumberLabel = new Label();
            DescriptionLabel = new Label();
            PartDescBox = new TextBox();
            MinnLabel = new Label();
            MinnBox = new TextBox();
            MaxxBox = new TextBox();
            LeadTimeBox = new TextBox();
            SupplierBox = new TextBox();
            PriceBox = new TextBox();
            CommentsBox = new TextBox();
            PurchaseLinkBox = new TextBox();
            label4 = new Label();
            LeadTimeLabel = new Label();
            SupplierLabel = new Label();
            PriceLabel = new Label();
            CommentLabel = new Label();
            PurchaseLinkLabel = new Label();
            SubmitButton = new Button();
            CancelButton = new Button();
            AddPartBanner = new Label();
            HelperLabel = new Label();
            SuspendLayout();
            // 
            // PartNumberBox
            // 
            PartNumberBox.Location = new Point(12, 64);
            PartNumberBox.Name = "PartNumberBox";
            PartNumberBox.Size = new Size(100, 23);
            PartNumberBox.TabIndex = 1;
            PartNumberBox.KeyPress += PartNumberBox_KeyPress;
            // 
            // PartNumberLabel
            // 
            PartNumberLabel.AutoSize = true;
            PartNumberLabel.Location = new Point(23, 46);
            PartNumberLabel.Name = "PartNumberLabel";
            PartNumberLabel.Size = new Size(80, 15);
            PartNumberLabel.TabIndex = 1;
            PartNumberLabel.Text = "Part Number*";
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(118, 46);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(96, 15);
            DescriptionLabel.TabIndex = 2;
            DescriptionLabel.Text = "Part Description*";
            // 
            // PartDescBox
            // 
            PartDescBox.Location = new Point(118, 64);
            PartDescBox.Name = "PartDescBox";
            PartDescBox.Size = new Size(100, 23);
            PartDescBox.TabIndex = 2;
            PartDescBox.KeyPress += PartDescBox_KeyPress;
            // 
            // MinnLabel
            // 
            MinnLabel.AutoSize = true;
            MinnLabel.Location = new Point(222, 46);
            MinnLabel.Name = "MinnLabel";
            MinnLabel.Size = new Size(109, 15);
            MinnLabel.TabIndex = 4;
            MinnLabel.Text = "Minimum Quantity";
            // 
            // MinnBox
            // 
            MinnBox.Location = new Point(224, 64);
            MinnBox.Name = "MinnBox";
            MinnBox.Size = new Size(100, 23);
            MinnBox.TabIndex = 3;
            MinnBox.KeyPress += MinnBox_KeyPress;
            // 
            // MaxxBox
            // 
            MaxxBox.Location = new Point(330, 64);
            MaxxBox.Name = "MaxxBox";
            MaxxBox.Size = new Size(100, 23);
            MaxxBox.TabIndex = 4;
            MaxxBox.KeyPress += MaxxBox_KeyPress;
            // 
            // LeadTimeBox
            // 
            LeadTimeBox.Location = new Point(436, 64);
            LeadTimeBox.Name = "LeadTimeBox";
            LeadTimeBox.Size = new Size(100, 23);
            LeadTimeBox.TabIndex = 5;
            LeadTimeBox.KeyPress += LeadTimeBox_KeyPress;
            // 
            // SupplierBox
            // 
            SupplierBox.Location = new Point(12, 109);
            SupplierBox.Name = "SupplierBox";
            SupplierBox.Size = new Size(100, 23);
            SupplierBox.TabIndex = 6;
            SupplierBox.KeyPress += SupplierBox_KeyPress;
            // 
            // PriceBox
            // 
            PriceBox.Location = new Point(118, 109);
            PriceBox.Name = "PriceBox";
            PriceBox.Size = new Size(100, 23);
            PriceBox.TabIndex = 7;
            PriceBox.KeyPress += PriceBox_KeyPress;
            // 
            // CommentsBox
            // 
            CommentsBox.Location = new Point(224, 109);
            CommentsBox.Name = "CommentsBox";
            CommentsBox.Size = new Size(100, 23);
            CommentsBox.TabIndex = 8;
            CommentsBox.KeyPress += CommentsBox_KeyPress;
            // 
            // PurchaseLinkBox
            // 
            PurchaseLinkBox.Location = new Point(330, 109);
            PurchaseLinkBox.Name = "PurchaseLinkBox";
            PurchaseLinkBox.Size = new Size(100, 23);
            PurchaseLinkBox.TabIndex = 9;
            PurchaseLinkBox.KeyPress += PurchaseLinkBox_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(330, 46);
            label4.Name = "label4";
            label4.Size = new Size(111, 15);
            label4.TabIndex = 12;
            label4.Text = "Maximum Quantity";
            // 
            // LeadTimeLabel
            // 
            LeadTimeLabel.AutoSize = true;
            LeadTimeLabel.Location = new Point(447, 46);
            LeadTimeLabel.Name = "LeadTimeLabel";
            LeadTimeLabel.Size = new Size(61, 15);
            LeadTimeLabel.TabIndex = 13;
            LeadTimeLabel.Text = "Lead Time";
            // 
            // SupplierLabel
            // 
            SupplierLabel.AutoSize = true;
            SupplierLabel.Location = new Point(33, 91);
            SupplierLabel.Name = "SupplierLabel";
            SupplierLabel.Size = new Size(50, 15);
            SupplierLabel.TabIndex = 14;
            SupplierLabel.Text = "Supplier";
            // 
            // PriceLabel
            // 
            PriceLabel.AutoSize = true;
            PriceLabel.Location = new Point(146, 90);
            PriceLabel.Name = "PriceLabel";
            PriceLabel.Size = new Size(33, 15);
            PriceLabel.TabIndex = 15;
            PriceLabel.Text = "Price";
            // 
            // CommentLabel
            // 
            CommentLabel.AutoSize = true;
            CommentLabel.Location = new Point(239, 90);
            CommentLabel.Name = "CommentLabel";
            CommentLabel.Size = new Size(66, 15);
            CommentLabel.TabIndex = 16;
            CommentLabel.Text = "Comments";
            // 
            // PurchaseLinkLabel
            // 
            PurchaseLinkLabel.AutoSize = true;
            PurchaseLinkLabel.Location = new Point(339, 90);
            PurchaseLinkLabel.Name = "PurchaseLinkLabel";
            PurchaseLinkLabel.Size = new Size(80, 15);
            PurchaseLinkLabel.TabIndex = 17;
            PurchaseLinkLabel.Text = "Purchase Link";
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(165, 138);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(100, 23);
            SubmitButton.TabIndex = 18;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(271, 138);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(100, 23);
            CancelButton.TabIndex = 19;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // AddPartBanner
            // 
            AddPartBanner.AutoSize = true;
            AddPartBanner.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            AddPartBanner.Location = new Point(204, 9);
            AddPartBanner.Name = "AddPartBanner";
            AddPartBanner.Size = new Size(131, 37);
            AddPartBanner.TabIndex = 20;
            AddPartBanner.Text = "Add Part";
            // 
            // HelperLabel
            // 
            HelperLabel.AutoSize = true;
            HelperLabel.Location = new Point(465, 109);
            HelperLabel.Name = "HelperLabel";
            HelperLabel.Size = new Size(59, 15);
            HelperLabel.TabIndex = 23;
            HelperLabel.Text = "*Required";
            // 
            // AddPartWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 171);
            Controls.Add(HelperLabel);
            Controls.Add(AddPartBanner);
            Controls.Add(CancelButton);
            Controls.Add(SubmitButton);
            Controls.Add(PurchaseLinkLabel);
            Controls.Add(CommentLabel);
            Controls.Add(PriceLabel);
            Controls.Add(SupplierLabel);
            Controls.Add(LeadTimeLabel);
            Controls.Add(label4);
            Controls.Add(PurchaseLinkBox);
            Controls.Add(CommentsBox);
            Controls.Add(PriceBox);
            Controls.Add(SupplierBox);
            Controls.Add(LeadTimeBox);
            Controls.Add(MaxxBox);
            Controls.Add(MinnBox);
            Controls.Add(MinnLabel);
            Controls.Add(PartDescBox);
            Controls.Add(DescriptionLabel);
            Controls.Add(PartNumberLabel);
            Controls.Add(PartNumberBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "AddPartWindow";
            Text = "Add Part";
            Load += AddPartWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox PartNumberBox;
        private Label PartNumberLabel;
        private Label DescriptionLabel;
        private TextBox PartDescBox;
        private Label MinnLabel;
        private TextBox MinnBox;
        private TextBox MaxxBox;
        private TextBox LeadTimeBox;
        private TextBox SupplierBox;
        private TextBox PriceBox;
        private TextBox CommentsBox;
        private TextBox PurchaseLinkBox;
        private Label label4;
        private Label LeadTimeLabel;
        private Label SupplierLabel;
        private Label PriceLabel;
        private Label CommentLabel;
        private Label PurchaseLinkLabel;
        private Button SubmitButton;
        private Button CancelButton;
        private Label AddPartBanner;
        private Label HelperLabel;
    }
}