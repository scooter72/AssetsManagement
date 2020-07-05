using AssetsManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetsManagementForm
{
    public partial class AddAssetForm : Form
    {
        public AddAssetForm(City[] cities, Owner[] owners)
        {
            InitializeComponent();
            //data binding
            comboBoxCities.DataSource = cities;
            comboBoxCities.DisplayMember = "Name"; // Column Name
            comboBoxCities.ValueMember = "Symbol";  // Column Name
            comboBoxOwners.DataSource = owners;
            comboBoxOwners.DisplayMember = "Name"; // Column Name
            comboBoxOwners.ValueMember = "Id";  // Column Name
        }

        public Asset Asset
        {
            get
            {
                return new Asset
                {
                    Owner = (Owner)comboBoxOwners.SelectedItem,
                    Address = new Address
                    {
                        City = (City)comboBoxCities.SelectedItem,
                        Street = textBoxStreet.Text.Trim(),
                        HouseNumber = int.Parse(textBoxHouseNumber.Text)
                    }
                };
            }
        }

        private void textBoxStreet_TextChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = textBoxHouseNumber.Text.Length > 0 && textBoxStreet.Text.Length > 0;
        }

        private void textBoxHouseNumber_TextChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = textBoxHouseNumber.Text.Length > 0 && textBoxStreet.Text.Length > 0;
        }

        private void textBoxHouseNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            List<Keys> allowdKeys = new List<Keys>() 
            { 
                Keys.Tab, 
                Keys.Right, 
                Keys.Left, 
                Keys.Home, 
                Keys.End, 
                Keys.Delete, 
                Keys.Back, 
                Keys.Shift 
            };

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) 
                && !allowdKeys.Contains((Keys)e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
