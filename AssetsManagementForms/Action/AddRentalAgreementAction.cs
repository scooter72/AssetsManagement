using AssetsManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetsManagementForms.Action
{
    class AddRentalAgreementAction : ActionBase
    {
        public override Entity Execute(ActionContext context)
        {
            AddRentalAgreementtForm form = new AddRentalAgreementtForm(
                 context.AssetManager.GetAssets(),
                 context.AssetManager.GetTenats(),
                 context.AssetManager.GetRentalAgreements()
             ); 

            if (form.ShowDialog(context.WindowOwner) == DialogResult.OK)
            {
                RentalAgreement rentalAgreement = form.RentalAgreement;
                context.AssetManager.AddRentalAgreement(rentalAgreement);
                context.Status = $"Rental agreement with ID: '{rentalAgreement.Id}' added to repositoy";
                return rentalAgreement;
            }

            return null;
        }
    }
}
