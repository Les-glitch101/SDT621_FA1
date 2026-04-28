using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FavouriteLanguagesApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Set placeholder when form loads
            SetPlaceholder();
        }

        private void SetPlaceholder()
        {
            textBox1.Text = "Enter programming language";
            textBox1.ForeColor = Color.Gray;

            // Attach events
            textBox1.Enter += RemovePlaceholder;
            textBox1.Leave += AddPlaceholder;
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter programming language")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void AddPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Enter programming language";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newLanguage = textBox1.Text.Trim();

            // Prevent empty input (ignore placeholder text too)
            if (string.IsNullOrEmpty(newLanguage) || newLanguage == "Enter programming language")
            {
                MessageBox.Show("⚠️ Please enter a programming language.");
                return;
            }

            // Prevent duplicates
            foreach (var item in listBox1.Items)
            {
                if (item.ToString().Equals(newLanguage, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("⚠️ This language is already in the list.");
                    return;
                }
            }

            // Add language
            listBox1.Items.Add(newLanguage);
            textBox1.Clear();
            AddPlaceholder(null, null); // Reset placeholder after adding
    }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string removedLanguage = listBox1.SelectedItem.ToString();
                listBox1.Items.Remove(listBox1.SelectedItem);

                // Display removal message with timestamp
                label2.Text = $"Removed '{removedLanguage}' at {DateTime.Now:dd MMM yyyy HH:mm:ss}";
            }
            else
            {
                MessageBox.Show("⚠️ Please select a language to remove.");
            }
        }
    }
}
