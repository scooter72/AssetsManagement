using AssetsManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetsManagementForms.Action
{
    public class DeleteCityAction : ActionBase
    {
        public override Entity Execute(ActionContext context)
        {
            City city = context.Entity as City;

            if (city != null)
            {
                bool cityInUse = context.AssetManager.GetAssets().Any(a => a.Address.City.Symbol == city.Symbol);

                if (cityInUse)
                {
                    MessageBox.Show(context.WindowOwner,
                        "City in use, first delete the related assets.",
                        "Cannot Delete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return null;


                }
                else if (MessageBox.Show(context.WindowOwner,
                       $"Are you sure you want to delete '{city.Name}'?",
                       "Confirm Deletion",
                       MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    context.AssetManager.DeleteCity(city.Symbol);
                    return city;
                }
            }

            return null;
        }
    }
}