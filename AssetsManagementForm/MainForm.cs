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

namespace AssetsManagementForm
{
    public partial class MainForm : Form
    {
        private readonly IAssetManager assetManager;

        public MainForm(IAssetManager assetManager)
        {
            this.assetManager = assetManager;
            InitializeComponent();
        }

        private void buttonAddCity_Click(object sender, EventArgs e)
        {
            AddCityForm form = new AddCityForm();
            
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                City city = form.City;
                assetManager.AddCity(city);
                SetStatus($"{city} added to repositoy");
            }
        }

        private void buttonAddOwner_Click(object sender, EventArgs e)
        {
            AddOwnerForm form = new AddOwnerForm();

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Owner owner = form.AssetOwner;
                assetManager.AddOwner(owner);
               SetStatus($"{owner} added to repositoy");
            }
        }

        private void buttonAddTenant_Click(object sender, EventArgs e)
        {
            AddTenantForm form = new AddTenantForm();

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Tenant tenant = form.Tenant;
                assetManager.AddTenant(tenant);
               SetStatus($"{tenant} added to repositoy");
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
                assetManager.AddAsset(asset);
                SetStatus($"{asset} added to repositoy");
            }
        }

        private void buttonAddRentalAgreement_Click(object sender, EventArgs e)
        {

        }
    }
}
