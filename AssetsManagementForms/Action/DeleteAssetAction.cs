using AssetsManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetsManagementForms.Action
{
    public class DeleteAssetAction : ActionBase
    {
        public override Entity Execute(ActionContext context)
        {
            Asset asset = context.Entity as Asset;

            if (asset != null)
            {
                RentalAgreement rentalAgreement = context.AssetManager.FindRentalAgreement(asset.Id);

                if (rentalAgreement != null)
                {
                    if (MessageBox.Show(context.WindowOwner,
                        "Asset is rented, are you sure you want to delete the asset entry?",
                        "Asset is Rented",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        context.AssetManager.DeleteAsset(asset.Id);
                        return asset;
                    }

                }
                else if (MessageBox.Show(context.WindowOwner,
                       "Are you sure you want to delete the asset entry?",
                       "Confirm Deletion",
                       MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    context.AssetManager.DeleteAsset(asset.Id);
                    return asset;
                }

            }

            return null;
        }
    }
}