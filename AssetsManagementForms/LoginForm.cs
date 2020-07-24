using AssetsManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetsManagementForms
{
    public partial class LoginForm : Form
    {
        private User[] users;
        private const string ErrorMessage = "Wromg user name or password";

        public LoginForm(User[] users)
        {
            this.users = users == null ? new User[0] : users;
            InitializeComponent();
        }

        internal User User
        {
            get;
            set; 
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            InputTextChanged();
        }
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            InputTextChanged();
        }

        private void InputTextChanged()
        {
            buttonOK.Enabled = IsNameValid && IsPasswordValid;
            SetErrorText(string.Empty);
        }


        private bool IsNameValid 
        { 
            get => textBoxName.Text.Length > 0; 
        }

        private string UserName
        {
            get => textBoxName.Text.Trim();
        }

        private string Password
        {
            get => ComputeHash(textBoxPassword.Text.Trim());
        }

        private string ComputeHash(string input) 
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {

                try
                {
                    byte[] hashValue = mySHA256.ComputeHash(
                        new MemoryStream(
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

        private bool IsPasswordValid
        {
            get => textBoxPassword.Text.Length > 0;
        }

        private void SetErrorText(string errorMessage)
        {
            labelError.Text = errorMessage;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            User user = users.FirstOrDefault
                        (
                          u => u.Username.Equals(UserName) && u.Password.Equals(Password)
                        );

            if (User != null)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                SetErrorText(ErrorMessage);
            }
        }
    }
}
