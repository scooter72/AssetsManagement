using AssetsManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetsManagementForms.Action
{
    class LoginAction : ActionBase
    {
        private const string ErrorMessage = "Wrong user name or password";

        public override Entity Execute(ActionContext context)
        {
            Entity entity = null;
            LoginForm form = new LoginForm();
            User[] users = context.AssetManager.GetUsers();
            
            form.DialogOK += (s, e) => 
            {
                entity = users.FirstOrDefault
                (
                  u => u.Username.Equals(form.Username) && u.Password.Equals(ComputeHash(form.Password))
                );

                if (entity != null)
                {
                    form.Close();
                }
                else
                {
                    form.SetErrorText(ErrorMessage);
                }
            };

            form.ShowDialog(context.WindowOwner);

            return entity;
        }
        private string ComputeHash(string input)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {

                try
                {
                    byte[] hashValue = mySHA256.ComputeHash(
                        new System.IO.MemoryStream(
                            Encoding.ASCII.GetBytes(input)));

                    return Convert.ToBase64String(hashValue, 0, hashValue.Length,
                                     Base64FormattingOptions.None);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return null;
        }

    }
}
