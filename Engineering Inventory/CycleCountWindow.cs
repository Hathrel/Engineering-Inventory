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

                PartsBox.Controls.Clear();

                if (parts.Count == 0)
                {
                    TextBox emptyTextBox = new TextBox();
                    emptyTextBox.Location = new Point(120, 20); 
                    emptyTextBox.Text = "EMPTY";
                    emptyTextBox.Enabled = false;
                    PartsBox.Controls.Add(emptyTextBox);

                    Label instructionLabel = new Label();
                    instructionLabel.Text = "No parts found. Click 'Found Inventory' and enter found parts, or enter next location.";
                    instructionLabel.Location = new Point(250, 20);
                    instructionLabel.AutoSize = true;
                    PartsBox.Controls.Add(instructionLabel);


                    SubmitQuantityButton.Tag = Tuple.Create(location, new List<(string partNumber, string quantity)> { ("EMPTY", "") }); //Maybe later implement a soluction to enter "EMPTY' as a count
                    SubmitQuantityButton.Visible = true;
                    FoundButton.Visible = true;
                }
                else
                {
                    int yPos = 20;
                    foreach (var part in parts)
                    {
                        Label partNumberLabel = new Label();
                        partNumberLabel.Text = part.partNumber;
                        partNumberLabel.Location = new Point(20, yPos);
                        partNumberLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        PartsBox.Controls.Add(partNumberLabel);

                        TextBox quantityTextBox = new TextBox();
                        quantityTextBox.Location = new Point(120, yPos);
                        quantityTextBox.Tag = part.partNumber;
                        PartsBox.Controls.Add(quantityTextBox);

                        Label descriptionLabel = new Label();
                        descriptionLabel.Text = part.description;
                        descriptionLabel.Location = new Point(250, yPos);
                        descriptionLabel.AutoSize = true;
                        PartsBox.Controls.Add(descriptionLabel);

                        yPos += 30;
                    }

                    // Initialize partQuantities with part number and "0" as default quantity
                    List<(string partNumber, string quantity)> partQuantities = parts.Select(p => (p.partNumber, "0")).ToList();
                    SubmitQuantityButton.Tag = Tuple.Create(location, partQuantities);
                    SubmitQuantityButton.Visible = true;
                    FoundButton.Visible = true;
                }
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
                    string quantity = textBox.Text;  // Directly use the text from the TextBox

                    if (!string.IsNullOrEmpty(quantity))
                    {
                        try
                        {
                            Program.pI.CycleCountSubmit(location, partNumber, quantity);
                        }
                        catch (Exception ex)
                        {
                            overallSuccess = false;
                            errorMessage = $"Error processing part {partNumber}: {ex.Message}";
                            break;
                        }
                    }
                    else
                    {
                        overallSuccess = false;
                        errorMessage = $"Quantity must be entered for part {partNumber}.";
                        break;
                    }
                }
            }
            if (overallSuccess)
            {
                ;
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
            SubmitQuantityButton.Visible = false;
            FoundButton.Visible = false;
        }

        private void FoundButton_Click(object sender, EventArgs e)
        {
            if(LocationBox.Text == "")
            {
                MessageBox.Show("Please enter a location.");
            }
            else
            {
                AddFoundWindow addFound = new(LocationBox.Text);
                addFound.ShowDialog();
            }
        }
    }
}
