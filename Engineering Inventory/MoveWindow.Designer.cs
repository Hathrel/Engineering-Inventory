namespace Engineering_Inventory
{
    partial class BinMoveInventory
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
            BinMoveBanner = new Label();
            qtyBox = new TextBox();
            partBox = new TextBox();
            OldLocBox = new TextBox();
            PartNumberLabel = new Label();
            QuantityLabel = new Label();
            LocationLabel = new Label();
            SubmitButton = new Button();
            CancelButton = new Button();
            BinMoveStatus = new Label();
            NewLocBox = new TextBox();
            NewLocLabel = new Label();
            SuspendLayout();
            // 
            // BinMoveBanner
            // 
            BinMoveBanner.AutoSize = true;
            BinMoveBanner.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            BinMoveBanner.ImageAlign = ContentAlignment.TopCenter;
            BinMoveBanner.Location = new Point(-2, 0);
            BinMoveBanner.Name = "BinMoveBanner";
            BinMoveBanner.Size = new Size(275, 46);
            BinMoveBanner.TabIndex = 0;
            BinMoveBanner.Text = "Move Inventory";
            BinMoveBanner.TextAlign = ContentAlignment.TopCenter;
            // 
            // qtyBox
            // 
            qtyBox.Location = new Point(85, 113);
            qtyBox.Name = "qtyBox";
            qtyBox.Size = new Size(100, 23);
            qtyBox.TabIndex = 2;
            qtyBox.KeyPress += qtyBox_KeyPress;
            // 
            // partBox
            // 
            partBox.Location = new Point(85, 84);
            partBox.Name = "partBox";
            partBox.Size = new Size(100, 23);
            partBox.TabIndex = 1;
            partBox.KeyPress += partBox_KeyPress;
            // 
            // OldLocBox
            // 
            OldLocBox.Location = new Point(85, 142);
            OldLocBox.Name = "OldLocBox";
            OldLocBox.Size = new Size(100, 23);
            OldLocBox.TabIndex = 3;
            OldLocBox.KeyPress += OldLocBox_KeyPress;
            // 
            // PartNumberLabel
            // 
            PartNumberLabel.AutoSize = true;
            PartNumberLabel.Location = new Point(41, 87);
            PartNumberLabel.Name = "PartNumberLabel";
            PartNumberLabel.Size = new Size(38, 15);
            PartNumberLabel.TabIndex = 7;
            PartNumberLabel.Text = "Part#:";
            // 
            // QuantityLabel
            // 
            QuantityLabel.AutoSize = true;
            QuantityLabel.Location = new Point(50, 116);
            QuantityLabel.Name = "QuantityLabel";
            QuantityLabel.Size = new Size(29, 15);
            QuantityLabel.TabIndex = 8;
            QuantityLabel.Text = "Qty:";
            // 
            // LocationLabel
            // 
            LocationLabel.AutoSize = true;
            LocationLabel.Location = new Point(1, 145);
            LocationLabel.Name = "LocationLabel";
            LocationLabel.Size = new Size(78, 15);
            LocationLabel.TabIndex = 9;
            LocationLabel.Text = "Old Location:";
            // 
            // SubmitButton
            // 
            SubmitButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            SubmitButton.Location = new Point(61, 200);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(75, 23);
            SubmitButton.TabIndex = 5;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CancelButton.Location = new Point(142, 200);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 6;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // BinMoveStatus
            // 
            BinMoveStatus.AutoSize = true;
            BinMoveStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BinMoveStatus.Location = new Point(-2, 46);
            BinMoveStatus.Name = "BinMoveStatus";
            BinMoveStatus.Size = new Size(40, 15);
            BinMoveStatus.TabIndex = 10;
            BinMoveStatus.Text = "label1";
            // 
            // NewLocBox
            // 
            NewLocBox.Location = new Point(85, 171);
            NewLocBox.Name = "NewLocBox";
            NewLocBox.Size = new Size(100, 23);
            NewLocBox.TabIndex = 4;
            NewLocBox.KeyPress += NewLocBox_KeyPress;
            // 
            // NewLocLabel
            // 
            NewLocLabel.AutoSize = true;
            NewLocLabel.Location = new Point(-2, 174);
            NewLocLabel.Name = "NewLocLabel";
            NewLocLabel.Size = new Size(83, 15);
            NewLocLabel.TabIndex = 9;
            NewLocLabel.Text = "New Location:";
            // 
            // BinMoveInventory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(271, 227);
            Controls.Add(NewLocLabel);
            Controls.Add(NewLocBox);
            Controls.Add(BinMoveStatus);
            Controls.Add(CancelButton);
            Controls.Add(SubmitButton);
            Controls.Add(LocationLabel);
            Controls.Add(QuantityLabel);
            Controls.Add(PartNumberLabel);
            Controls.Add(OldLocBox);
            Controls.Add(partBox);
            Controls.Add(qtyBox);
            Controls.Add(BinMoveBanner);
            Name = "BinMoveInventory";
            Text = "Move Inventory";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label BinMoveBanner;
        private TextBox qtyBox;
        private TextBox partBox;
        private TextBox OldLocBox;
        private Label PartNumberLabel;
        private Label QuantityLabel;
        private Label LocationLabel;
        private Button SubmitButton;
        private Button CancelButton;
        private Label BinMoveStatus;
        private TextBox NewLocBox;
        private Label NewLocLabel;
    }
}