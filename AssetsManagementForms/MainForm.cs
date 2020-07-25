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
        private enum View { Assets, Cities }
        private View currentView = View.Assets;
        User user;

        public MainForm(IAssetManager assetManager)
        {
            this.assetManager = assetManager;
            Login();
            InitializeComponent();
            BuildAssetGridDataSource(assetManager.GetAssets());
            dataGridViewAssets.DataSource = assetGridDataSource;
            toolStripButtonNew.Enabled = assetGridDataSource.Count > 0;
            Text = $"{Text} - [{user.Username}]";
        }

        private void Login()
        {
            user = ExecuteAction(new LoginAction()) as User;

            if (user == null)
            {
                Load += (s, e) => Close();
                return;
            }
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
            var entity = ExecuteAction(new AddCityAction());

            if (entity != null && (View)tabControl1.SelectedIndex == View.Cities)
            {
                dataGridViewCities.DataSource = null;
                dataGridViewCities.DataSource = assetManager.GetCities();
            }
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
            AddNewEntity();
        }

        private void AddNewEntity()
        {
            switch ((View)tabControl1.SelectedIndex)
            {
                case View.Assets:
                    AddNewAsset();
                    break;
                case View.Cities:
                    AddNewCity();
                    break;
            }
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

        private Entity ExecuteAction(ActionBase action, Entity entity = null)
        {
            var context = new ActionContext { AssetManager = assetManager, WindowOwner = this, Entity = entity };
            var returnEntity = action.Execute(context);
            if (toolStripStatusLabel1 != null)
            {
                SetStatus(context.Status);
            }
            return returnEntity;
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
                UpdateRentalAgreementPane();
            }
        }

        private void UpdateRentalAgreementPane()
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            switch (currentView) 
            {
                case View.Assets:
                    DeleteAsset();
                    break;
                case View.Cities:
                    DeleteCity();
                    break;
            }
        }

        private void DeleteCity()
        {
            var entity = ExecuteAction(new DeleteCityAction(), (Entity)dataGridViewCities.SelectedRows[0].DataBoundItem);

            if (entity != null)
            {
                dataGridViewCities.DataSource = null;
                dataGridViewCities.DataSource = assetManager.GetCities();
            }
        }

        private void DeleteAsset()
        {
            AssetRow row = assetGridDataSource[dataGridViewAssets.SelectedRows[0].Index];

            if (ExecuteAction(new DeleteAssetAction(), new Asset { Id = row.Id }) != null)
            {
                SetAssetsGridDataSource();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentView = (View)tabControl1.SelectedIndex;

            switch (currentView) 
            {
                case View.Assets:
                    BuildAssetGridDataSource(assetManager.GetAssets());
                    break;
                case View.Cities:
                    dataGridViewCities.DataSource = null;
                    dataGridViewCities.DataSource = assetManager.GetCities();
                    break;
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

        private void SetAssetsGridDataSource()
        {
            dataGridViewAssets.DataSource = null;
            BuildAssetGridDataSource(assetManager.GetAssets());
            dataGridViewAssets.DataSource = assetGridDataSource;
        }

        class AssetRow
        {
            public int Id { get; set; }
            public String Owner { get; set; }
            public String City { get; set; }
            public String Street { get; set; }
            public int HouseNumber { get; set; }
        }

    }
}
