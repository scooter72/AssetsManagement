using AssetsManagement.BLL;
using AssetsManagement.Model;
using AssetsManagementForms.Action;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AssetsManagementForms
{
    public partial class MainForm : Form
    {
        private readonly IAssetManager assetManager;
        private readonly List<AssetRow> assetGridDataSource = new List<AssetRow>();
        private enum View { Assets }
        private View currentView = View.Assets;

        public MainForm(IAssetManager assetManager)
        {
            this.assetManager = assetManager;
            InitializeComponent();
            BuildAssetGridDataSource(assetManager.GetAssets());
            dataGridViewAssets.DataSource = assetGridDataSource;
        }

        private void buttonAddCity_Click(object sender, EventArgs e)
        {
            AddNewCity();
        }

        private void cityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewCity();
        }

        private void AddNewCity()
        {
            ExecuteAction(new AddCityAction());
        }

        private void ownerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewOwner();
        }

        private void buttonAddOwner_Click(object sender, EventArgs e)
        {
            AddNewOwner();
        }

        private void AddNewOwner()
        {
            ExecuteAction(new AddOwnerAction());
        }

        private void buttonAddTenant_Click(object sender, EventArgs e)
        {
            AddNewTenant();
        }

        private void tenantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewTenant();
        }

        private void AddNewTenant()
        {
            ExecuteAction(new AddOwnerAction());
        }

        private void buttonAddAsset_Click(object sender, EventArgs e)
        {
            AddNewAsset();
        }


        private void assetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewAsset();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddNewAsset();
        }

        private void AddNewAsset()
        {
            var entity = ExecuteAction(new AddAssetAction());

            if (entity != null)
            {
                Asset asset = entity as Asset;
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
            }
        }

        private void buttonAddRentalAgreement_Click(object sender, EventArgs e)
        {
            AddNewRentalAgreement();
        }

        private void rentalAgreementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewRentalAgreement();
        }

        private void AddNewRentalAgreement()
        {
            ExecuteAction(new AddRentalAgreementAction());
        }

        private Entity ExecuteAction(ActionBase action)
        {
            var context = new ActionContext { AssetManager = assetManager, WindowOwner = this };
            var entity = action.Execute(context);
            SetStatus(context.Status);
            return entity;
        }

        private void SetStatus(string message)
        {
            toolStripStatusLabel1.Text = message;
        }

        private void dataGridViewAssets_SelectionChanged(object sender, EventArgs e)
        {
            toolStripButtonDelete.Enabled = dataGridViewAssets.SelectedRows.Count > 0;

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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

 


        class AssetRow
        {
            public int Id { get; set; }
            public String Owner { get; set; }
            public String City { get; set; }
            public String Street { get; set; }
            public int HouseNumber { get; set; }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            switch (currentView) 
            {
                case View.Assets:
                    DeleteAsset();
                    break;
            }
        }

        private void DeleteAsset()
        {
            AssetRow row = assetGridDataSource[dataGridViewAssets.SelectedRows[0].Index];
            RentalAgreement rentalAgreement = assetManager.FindRentalAgreement(row.Id);

            if (rentalAgreement != null)
            {
                if (MessageBox.Show(this,
                    "Asset is rented, are you sure you want to delete the asset?",
                    "Asset is Rented",
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    assetManager.DeleteAsset(row.Id);
                    dataGridViewAssets.DataSource = null;
                    BuildAssetGridDataSource(assetManager.GetAssets());
                    dataGridViewAssets.DataSource = assetGridDataSource;
                }
            }
        }


        private void BuildAssetGridDataSource(Asset[] assets)
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

    }
}
