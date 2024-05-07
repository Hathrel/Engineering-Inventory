using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engineering_Inventory
{
    public partial class CycleCounts : Form
    {
        public CycleCounts()
        {
            InitializeComponent();
            CycleCountStatus.Text = $"Welcome {Program.user_name}, you are working in {Program.user_site}";
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string location = LocationBox.Text;
            if (!string.IsNullOrEmpty(location))
            {
                List<(string partNumber, int quantity, string description)> parts = Program.pI.CycleCountPull(location);
                // Clear existing controls in PartsBox
                PartsBox.Controls.Clear();

                // Create controls for each part
                int yPos = 20; // Initial y-position
                foreach (var part in parts)
                {
                    // Create label for part number
                    Label partNumberLabel = new Label();
                    partNumberLabel.Text = part.partNumber;
                    partNumberLabel.Location = new Point(20, yPos);
                    PartsBox.Controls.Add(partNumberLabel);

                    // Create text box for quantity
                    TextBox quantityTextBox = new TextBox();
                    quantityTextBox.Location = new Point(150, yPos);
                    PartsBox.Controls.Add(quantityTextBox);
                    int actualQty = part.quantity;

                    // Create label for description
                    Label descriptionLabel = new Label();
                    descriptionLabel.Text = part.description;
                    descriptionLabel.Location = new Point(250, yPos);
                    descriptionLabel.AutoSize = true; // Set autosize to true
                    PartsBox.Controls.Add(descriptionLabel);

                    yPos += 30; // Increment y-position for next control
                }

                // Resize the form to fit the controls
                int formHeight = PartsBox.Controls.Count * 30 + 200; // Calculate form height based on number of controls
                this.ClientSize = new Size(this.ClientSize.Width, formHeight);
            }
            else
            {
                LocationBox.Select();
                MessageBox.Show("Please enter a location.");
            }
        }


        private void LocationBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SubmitButton_Click(sender, e);
            }
        }
    }
}
