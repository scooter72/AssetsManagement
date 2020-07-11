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
    public class AddCityAction : ActionBase
    {
        public override Entity Execute(ActionContext context)
        {
            AddCityForm form = new AddCityForm(context.AssetManager.GetCities());

            if (form.ShowDialog(context.WindowOwner) == DialogResult.OK)
            {
                City city = form.City;
                context.AssetManager.AddCity(city);
                context.Status= $"City: '{city.Name}' added to repositoy";
                return form.City;
            }

            return null;
        }
    }
}
