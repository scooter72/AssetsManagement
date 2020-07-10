using AssetsManagement.BLL;
using AssetsManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetsManagementForms
{
    public partial class MainForm : Form
    {
        private readonly IAssetManager assetManager;
        private readonly List<AssetRow> assetGridDataSource = new List<AssetRow>();

        public MainForm(IAssetManager assetManager)
        {
            this.assetManager = assetManager;
            InitializeComponent();
            SetAssetGridDataSource(assetManager.GetAssets());
            dataGridViewAssets.DataSource = assetGridDataSource;
        }



        private void buttonAddCity_Click(object sender, EventArgs e)
        {
            AddCityForm form = new AddCityForm(assetManager.GetCities());
            
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                City city = form.City;
                assetManager.AddCity(city);
                SetStatus($"City added to repositoy");
            }
        }

        private void buttonAddOwner_Click(object sender, EventArgs e)
        {
            AddOwnerForm form = new AddOwnerForm();

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Owner owner = form.AssetOwner;
                assetManager.AddOwner(owner);
               SetStatus($"Owner added to repositoy");
            }
        }

        private void buttonAddTenant_Click(object sender, EventArgs e)
        {
            AddTenantForm form = new AddTenantForm();

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Tenant tenant = form.Tenant;
                assetManager.AddTenant(tenant);
               SetStatus($"Tenant added to repositoy");
            }
        }


        private void SetStatus(string message)
        {
            labelStatus.Text = message;
        }

        private void buttonAddAsset_Click(object sender, EventArgs e)
        {
            AddAssetForm form = new AddAssetForm(assetManager.GetCities(), assetManager.GetOwners());
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Asset asset = form.Asset;
                asset.Id = assetManager.AddAsset(asset);
                assetGridDataSource.Add(new AssetRow
                {
                    Id = asset.Id,
                    City = asset.Address.City.Name,
                    Owner = asset.Owner.Name,
                    Street = asset.Address.Street,
                    HouseNumber = asset.Address.HouseNumber
                });
                dataGridViewAssets.DataSource = null;
                dataGridViewAssets.DataSource = assetGridDataSource;
                SetStatus($"Asset added to repositoy");
            }
        }

        private void SetAssetGridDataSource(Asset[] assets)
        {
            assetGridDataSource.Clear();

            foreach (var asset in assets)
            {
                assetGridDataSource.Add(
                    new AssetRow 
                    { 
                        Id = asset.Id, 
                        City = asset.Address.City.Name, 
                        Owner = asset.Owner.Name, 
                        Street = asset.Address.Street, 
                        HouseNumber = asset.Address.HouseNumber 
                    }
                );
            }
        }

        private void buttonAddRentalAgreement_Click(object sender, EventArgs e)
        {
            AddRentalAgreementtForm form = new AddRentalAgreementtForm(assetManager.GetAssets(), assetManager.GetTenats());
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                RentalAgreement rentalAgreement = form.RentalAgreement;
                assetManager.AddRentalAgreement(rentalAgreement);
                SetStatus($"Rental agreement added to repositoy");
            }
        }

        class AssetRow 
        {
            public int Id { get; set; }
            public String Owner { get; set; }
            public String City { get; set; }
            public String Street { get; set; }
            public int HouseNumber { get; set; }
        }

        private void dataGridViewAssets_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewAssets.SelectedRows.Count > 0)
            {
                labelRentalAgreementTenant.Text = string.Empty;
                labelStartRentalAgreemnt.Text = string.Empty;
                labelRentalAgreemntEnd.Text = string.Empty;

                AssetRow row = assetGridDataSource[dataGridViewAssets.SelectedRows[0].Index];
                RentalAgreement rentalAgreement = assetManager.FindRentalAgreement(row.Id);
                if (rentalAgreement != null)
                {
                    Tenant tenant = assetManager.FindTenantById(rentalAgreement.Tenant);
                    labelRentalAgreementTenant.Text = tenant.Name;
                    labelStartRentalAgreemnt.Text = rentalAgreement.Start.ToString("dd/MM/yyyy");
                    labelRentalAgreemntEnd.Text = rentalAgreement.End.ToString("dd/MM/yyyy");
                }
            }
        }
    }
}
