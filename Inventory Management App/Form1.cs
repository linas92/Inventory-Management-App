using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management_App
{
    public partial class InvintoryManagementStudio : Form
    {
        DataTable inventory = new DataTable();
        public InvintoryManagementStudio()
        {
            InitializeComponent();
        }

        /*  i fucked up and double clicked :(
        private void button2_Click(object sender, EventArgs e)
        {

        }*/

        private void newButton_Click(object sender, EventArgs e)
        {
            skuTextBox.Text = string.Empty;
            nameTextBox.Text = string.Empty;
            priceTextBox.Text = string.Empty;
            quantityTextBox.Text = string.Empty;
            descriptionTextBox.Text = string.Empty;
            categoryTextBox.SelectedIndex = -1;
            
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // good to use try and catch with "deletes" because of trying to delete empty n stuff
            try
            {
                inventory.Rows[dataGridView1.CurrentCell.RowIndex].Delete();
            }
            catch (Exception error)
            {
                Console.WriteLine($"Error: {error}");
                //throw;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // save all the values from our fields into variables
            String sku = skuTextBox.Text;
            String name = nameTextBox.Text;
            String price = priceTextBox.Text;
            String quantity = quantityTextBox.Text;
            String description = descriptionTextBox.Text;
            String category = (string)categoryTextBox.SelectedItem;

            // Add these values to the datatable
            inventory.Rows.Add(sku, name, category, price, description, quantity);

            // Clears the textbox fields after save
            newButton_Click(sender, e);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                skuTextBox.Text = inventory.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[0].ToString();
                nameTextBox.Text = inventory.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[1].ToString();
                priceTextBox.Text = inventory.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[3].ToString();
                descriptionTextBox.Text = inventory.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[4].ToString();
                quantityTextBox.Text = inventory.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[5].ToString();

                String itemToLookFor = inventory.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[2].ToString();
                categoryTextBox.SelectedIndex = categoryTextBox.Items.IndexOf(itemToLookFor);


            }
            catch (Exception error)
            {
                Console.WriteLine($"There has been an error: {error}");
                //throw;
            }
        }

        private void InvintoryManagementStudio_Load(object sender, EventArgs e)
        {
            inventory.Columns.Add("SKU");
            inventory.Columns.Add("NAME");
            inventory.Columns.Add("CATEGORY");
            inventory.Columns.Add("PRICE");
            inventory.Columns.Add("DESCRIPTION");
            inventory.Columns.Add("QUANTITY");

            dataGridView1.DataSource = inventory;
        }
    }
}
