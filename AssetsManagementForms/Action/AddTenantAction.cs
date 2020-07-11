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
    public class AddTenantAction : ActionBase
    {
        public override Entity Execute(ActionContext context)
        {
            AddTenantForm form = new AddTenantForm(context.AssetManager.GetTenats());

            if (form.ShowDialog(context.WindowOwner) == DialogResult.OK)
            {
                Tenant tenant = form.Tenant;
                context.AssetManager.AddTenant(tenant);
                context.Status= $"Tenant: '{tenant.Name}' added to repositoy";
                return form.Tenant;
            }

            return null;
        }
    }
}
