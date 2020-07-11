using AssetsManagement.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetsManagementForms.Action
{
    public class ActionContext
    {
        public ActionContext()
        {
            Status = string.Empty;
        }

        internal IWin32Window WindowOwner { get; set; }
        
        internal IAssetManager AssetManager { get; set; }

        internal string Status { get; set; }
    }
}
