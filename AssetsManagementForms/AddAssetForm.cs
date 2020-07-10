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

namespace AssetsManagementForms
{
    public partial class AddAssetForm : Form
    {
        private Asset[] assets;
        private const string AddressIsInUse = "Address is in use";

        public AddAssetForm(City[] cities, Owner[] owners, Asset[] assets)
        {
            InitializeComponent();
            //data binding
            comboBoxCities.DataSource = cities;
            comboBoxCities.DisplayMember = "Name"; // Column Name
            comboBoxCities.ValueMember = "Symbol";  // Column Name
            comboBoxOwners.DataSource = owners;
            comboBoxOwners.DisplayMember = "Name"; // Column Name
            comboBoxOwners.ValueMember = "Id";  // Column Name
            this.assets = assets;
        }

        public Asset Asset
        {
            get
            {
                return new Asset
                {
                    Owner = (Owner)comboBoxOwners.SelectedItem,
                    Address = Address
                };
            }
        }

        private Address Address
        { 
            get => new Address
                {
                    City = (City)comboBoxCities.SelectedItem,
                    Street = textBoxStreet.Text.Trim(),
                    HouseNumber = textBoxHouseNumber.Text.Length > 0 ? int.Parse(textBoxHouseNumber.Text) : -1
                };
        }

        private void textBoxStreet_TextChanged(object sender, EventArgs e)
        {
            InputTextChanged();
        }

        private void textBoxHouseNumber_TextChanged(object sender, EventArgs e)
        {
            InputTextChanged();
        }

        private void InputTextChanged()
        {
            buttonOK.Enabled = IsStreetValid && IsHouseNumberValid && !(IsAddressInUse);
            SetErrorText();
        }


        private bool IsStreetValid { get => textBoxStreet.Text.Length > 0; }

        private bool IsHouseNumberValid { get => textBoxHouseNumber.Text.Length > 0; }

        private bool IsAddressInUse { get => assets.Select(a => a.Address).Any(a => a.CompareTo(Address) == 0); }

        private void SetErrorText()
        {
            var address = assets.Select(a => a.Address).FirstOrDefault(a => a.CompareTo(Address) == 0);
            labelError.Text = string.Empty;
            if (IsAddressInUse)
            {
                labelError.Text = AddressIsInUse;
            }
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
