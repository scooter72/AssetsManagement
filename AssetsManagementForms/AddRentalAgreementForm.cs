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
    public partial class AddRentalAgreementtForm : Form
    {
        public AddRentalAgreementtForm(Asset[] assets, Tenant[] tenants)
        {
            InitializeComponent();
            //data binding
            comboBoxTenants.DataSource = tenants;
            comboBoxTenants.DisplayMember = "Name"; // Column Name
            comboBoxTenants.ValueMember = "Id";  // Column Name
            comboBoxAssets.DataSource = assets.Select(a => new AssetRow(a)).ToArray();
            comboBoxAssets.DisplayMember = "Address"; // Column Name
            comboBoxAssets.ValueMember = "Id";  // Column Name
            dateTimePickerEnd.Value = DateTime.Now.AddYears(1);
        }

        public RentalAgreement RentalAgreement
        {
            get
            {
                return new RentalAgreement
                { 
                    AssetId = (int)comboBoxAssets.SelectedValue,
                    Tenant = (int)comboBoxTenants.SelectedValue,
                    Start  = dateTimePickerStart.Value,
                    End  = dateTimePickerEnd.Value,
                };
            }
        }


        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        class AssetRow
        {
            internal AssetRow(Asset asset) 
            {
                Id = asset.Id;
                Address = $"{asset.Address.City.Name}, {asset.Address.Street}, {asset.Address.HouseNumber}";
            }
        
            public int Id { get; set; }
            public string Address { get; set; }
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerStart.Value >= dateTimePickerEnd.Value)
            {
                MessageBox.Show("Invalid start date");
                buttonOK.Enabled = false;
            }
            else
            {
                buttonOK.Enabled = true;
            }
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerEnd.Value <= dateTimePickerStart.Value)
            {
                MessageBox.Show("Invalid end date");
                buttonOK.Enabled = false;
            }
            else
            {
                buttonOK.Enabled = true;
            }
        }
    }
}
