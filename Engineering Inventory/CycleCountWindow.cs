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
                    quantityTextBox.Tag = part.partNumber; // Associate the TextBox with the part number
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

                // Show SubmitQuantityButton
                SubmitQuantityButton.Visible = true;

                // Pass location and parts data to SubmitQuantityButton Click event handler
                List<(string partNumber, int quantity)> partQuantities = parts.Select(p => (p.partNumber, 0)).ToList(); // Initialize quantities as 0
                SubmitQuantityButton.Tag = Tuple.Create(location, partQuantities);
            }
            else
            {
                LocationBox.Select();
                MessageBox.Show("Please enter a location.");
            }
        }
        private void SubmitQuantityButton_Click(object sender, EventArgs e)
        {
            string location = LocationBox.Text;  // Assuming LocationBox.Text contains the location data
            bool overallSuccess = true;
            string errorMessage = "";

            foreach (Control control in PartsBox.Controls)
            {
                if (control is TextBox textBox)
                {
                    string partNumber = textBox.Tag as string;
                    int quantity;

                    if (int.TryParse(textBox.Text, out quantity))
                    {
                        // Call the CycleCountSubmit method for each part and quantity
                        try
                        {
                            Program.pI.CycleCountSubmit(location, partNumber, quantity);
                        }
                        catch (Exception ex)
                        {
                            overallSuccess = false;
                            errorMessage = $"Error processing part {partNumber}: {ex.Message}";
                            break;  // Optionally stop processing after the first error
                        }
                    }
                    else
                    {
                        overallSuccess = false;
                        errorMessage = $"Invalid quantity entered for part {partNumber}.";
                        break;  // Optionally stop processing after the first error
                    }
                }
            }

            // Handle the overall result
            if (overallSuccess)
            {
                MessageBox.Show("All cycle counts successfully submitted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CycleCounts_Load(object sender, EventArgs e)
        {
            LocationBox.Select();
        }

        private void FoundButton_Click(object sender, EventArgs e)
        {
            AddFound addFound = new(LocationBox.Text);
        }
    }
}
