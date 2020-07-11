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
    public class AddOwnerAction : ActionBase
    {
        public override Entity Execute(ActionContext context)
        {
            AddOwnerForm form = new AddOwnerForm(context.AssetManager.GetOwners());

            if (form.ShowDialog(context.WindowOwner) == DialogResult.OK)
            {
                Owner owner = form.AssetOwner;
                context.AssetManager.AddOwner(owner);
                context.Status = $"Owner '{owner.Name}' added to repositoy";
                return form.AssetOwner;
            }

            return null;
        }
    }
}
