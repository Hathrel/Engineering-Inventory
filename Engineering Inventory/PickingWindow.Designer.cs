namespace Engineering_Inventory
{
    partial class PickingInventory
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
            PickingBanner = new Label();
            qtyBox = new TextBox();
            partBox = new TextBox();
            locBox = new TextBox();
            PartNumberLabel = new Label();
            QuantityLabel = new Label();
            LocationLabel = new Label();
            SubmitButton = new Button();
            CancelButton = new Button();
            PickingStatus = new Label();
            SuspendLayout();
            // 
            // PickingBanner
            // 
            PickingBanner.AutoSize = true;
            PickingBanner.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            PickingBanner.ImageAlign = ContentAlignment.TopCenter;
            PickingBanner.Location = new Point(-2, 0);
            PickingBanner.Name = "PickingBanner";
            PickingBanner.Size = new Size(303, 46);
            PickingBanner.TabIndex = 0;
            PickingBanner.Text = "Picking Inventory";
            PickingBanner.TextAlign = ContentAlignment.TopCenter;
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
            // locBox
            // 
            locBox.Location = new Point(85, 142);
            locBox.Name = "locBox";
            locBox.Size = new Size(100, 23);
            locBox.TabIndex = 3;
            locBox.KeyPress += locBox_KeyPress;
            // 
            // PartNumberLabel
            // 
            PartNumberLabel.AutoSize = true;
            PartNumberLabel.Location = new Point(41, 87);
            PartNumberLabel.Name = "PartNumberLabel";
            PartNumberLabel.Size = new Size(38, 15);
            PartNumberLabel.TabIndex = 4;
            PartNumberLabel.Text = "Part#:";
            // 
            // QuantityLabel
            // 
            QuantityLabel.AutoSize = true;
            QuantityLabel.Location = new Point(50, 116);
            QuantityLabel.Name = "QuantityLabel";
            QuantityLabel.Size = new Size(29, 15);
            QuantityLabel.TabIndex = 5;
            QuantityLabel.Text = "Qty:";
            // 
            // LocationLabel
            // 
            LocationLabel.AutoSize = true;
            LocationLabel.Location = new Point(26, 145);
            LocationLabel.Name = "LocationLabel";
            LocationLabel.Size = new Size(56, 15);
            LocationLabel.TabIndex = 6;
            LocationLabel.Text = "Location:";
            // 
            // SubmitButton
            // 
            SubmitButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            SubmitButton.Location = new Point(60, 171);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(75, 23);
            SubmitButton.TabIndex = 4;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CancelButton.Location = new Point(141, 171);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 5;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // PickingStatus
            // 
            PickingStatus.AutoSize = true;
            PickingStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            PickingStatus.Location = new Point(-2, 46);
            PickingStatus.Name = "PickingStatus";
            PickingStatus.Size = new Size(40, 15);
            PickingStatus.TabIndex = 7;
            PickingStatus.Text = "label1";
            // 
            // PickingInventory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(298, 227);
            Controls.Add(PickingStatus);
            Controls.Add(CancelButton);
            Controls.Add(SubmitButton);
            Controls.Add(LocationLabel);
            Controls.Add(QuantityLabel);
            Controls.Add(PartNumberLabel);
            Controls.Add(locBox);
            Controls.Add(partBox);
            Controls.Add(qtyBox);
            Controls.Add(PickingBanner);
            Name = "PickingInventory";
            Text = "Picking Inventory";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PickingBanner;
        private TextBox qtyBox;
        private TextBox partBox;
        private TextBox locBox;
        private Label PartNumberLabel;
        private Label QuantityLabel;
        private Label LocationLabel;
        private Button SubmitButton;
        private Button CancelButton;
        private Label PickingStatus;
    }
}