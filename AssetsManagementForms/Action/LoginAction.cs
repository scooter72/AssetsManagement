using AssetsManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetsManagementForms.Action
{
    class LoginAction : ActionBase
    {
        public override Entity Execute(ActionContext context)
        {
            LoginForm form = new LoginForm(context.AssetManager.GetUsers());

            if (form.ShowDialog(context.WindowOwner) == DialogResult.OK)
            {
                return form.User;
            }

            return null;
        }
    }
}
