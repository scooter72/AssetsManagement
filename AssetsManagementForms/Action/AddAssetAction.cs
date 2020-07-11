using AssetsManagement.BLL;
using AssetsManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetsManagementForms.Action
{
    public class AddAssetAction : ActionBase
    {
        public override Entity Execute(ActionContext context)
        {

            AddAssetForm form = new AddAssetForm(
                context.AssetManager.GetCities(), 
                context.AssetManager.GetOwners(), 
                context.AssetManager.GetAssets());

            if (form.ShowDialog(context.WindowOwner) == DialogResult.OK)
            {
                Asset asset = form.Asset;
                asset.Id = context.AssetManager.AddAsset(asset);

                
                context.Status = $"Asset with ID: '{asset.Id}' added to repositoy";
                return form.Asset;
            }

            return null;
        }
    }
}
