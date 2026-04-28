using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HomeAffairsDigitalIdentityProcessor
{
    public partial class Form1 : Form
    {
        // Holds the currently processed citizen profile
        private CitizenProfile currentProfile;

        public Form1()
        {
            InitializeComponent(); // Initialize form components
        }

        // Runs when the form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            // Populate citizenship options in the combo box
            comboBox1.Items.Add("South African");
            comboBox1.Items.Add("Permanent Resident");
            comboBox1.Items.Add("Visitor");

            // Default selection is "South African"
            comboBox1.SelectedIndex = 0;
        }

        // Handles the Validate button click
        private void button1_Click(object sender, EventArgs e)
        {
            // Collect user input from textboxes and dropdown
            string name = textBox1.Text;
            string id = textBox3.Text;
            string status = comboBox1.SelectedItem.ToString();

            // Create a new citizen profile with the provided details
            currentProfile = new CitizenProfile(name, id, status);

            // Validate the ID number using CitizenProfile logic
            string result = currentProfile.ValidateID();

            // Display validation result in label4
            label4.Text = result;
        }

        // Handles the Generate Summary button click
        private void button2_Click(object sender, EventArgs e)
        {
            // Ensure a profile has been validated before generating summary
            if (currentProfile == null)
            {
                MessageBox.Show("Please validate ID first.");
                return;
            }

            // Build a formatted summary string with citizen details
            string summary =
                "==== DIGITAL CITIZEN SUMMARY ====\r\n" +
                $"Name: {currentProfile.FullName}\r\n" +
                $"ID Number: {currentProfile.IDNumber}\r\n" +
                $"Age: {currentProfile.Age}\r\n" +
                $"Citizenship: {currentProfile.CitizenshipStatus}\r\n" +
                $"Validation: {currentProfile.ValidateID()}\r\n" +
                $"Processed at: Home Affairs Digital Desk\r\n" +
                $"Timestamp: {DateTime.Now}";

            // Display summary in textBox2
            textBox2.Text = summary;
        }

        // Restricts input in textBox2 to digits only
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (like backspace) and digits only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block non-digit input
            }
        }
    }
}
