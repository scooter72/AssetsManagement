using AssetsManagement.Model;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AssetsManagementForms
{
    public partial class AddRentalAgreementtForm : Form
    {
        private RentalAgreement[] rentalAgreements;
        private readonly string InvalidStartDate = "Invalid start date";
        private readonly string InvalidEndtDate = "Invalid end date";
        private readonly string AssetIsRented = "Asset is rented";

        public AddRentalAgreementtForm(Asset[] assets, Tenant[] tenants, RentalAgreement[] rentalAgreements)
        {
            InitializeComponent();
            this.rentalAgreements = rentalAgreements;
            //data binding
            comboBoxTenants.DataSource = tenants;
            comboBoxTenants.DisplayMember = "Name"; // Column Name
            comboBoxTenants.ValueMember = "Id";  // Column Name
            comboBoxAssets.DataSource = assets.Select(a => new AssetRow(a)).ToArray();
            comboBoxAssets.DisplayMember = "Address"; // Column Name
            comboBoxAssets.ValueMember = "Id";  // Column Name
            dateTimePickerEnd.Value = DateTime.Now.AddYears(1);
            ValidateSelectedAsset();
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
            labelError.Text = string.Empty;

            if (dateTimePickerStart.Value >= dateTimePickerEnd.Value)
            {
                labelError.Text = InvalidStartDate;
                buttonOK.Enabled = false;
            }
            else
            {
                buttonOK.Enabled = true;
            }
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            labelError.Text = string.Empty;
          
            if (dateTimePickerEnd.Value <= dateTimePickerStart.Value)
            {
                labelError.Text = InvalidEndtDate;
                buttonOK.Enabled = false;
            }
            else
            {
                buttonOK.Enabled = true;
            }
        }

        private void comboBoxAssets_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateSelectedAsset(); 
        }

        private void ValidateSelectedAsset()
        { 
            var asset = comboBoxAssets.SelectedItem as AssetRow;
            labelError.Text = string.Empty;
            
            if (rentalAgreements.Any(i => i.AssetId == asset.Id))
            {
                labelError.Text = AssetIsRented;
                buttonOK.Enabled = false;
            }
            else
            {
                buttonOK.Enabled = true;
            }

        }
    }
}
