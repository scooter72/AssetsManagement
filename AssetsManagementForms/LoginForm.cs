using AssetsManagement.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AssetsManagementForms
{
    public partial class LoginForm : Form
    {
        internal event EventHandler DialogOK;

        public LoginForm()
        {
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

        internal string Username
        {
            get => textBoxName.Text.Trim();
        }

        internal string Password
        {
            get => textBoxPassword.Text.Trim();
        }



        private bool IsPasswordValid
        {
            get => textBoxPassword.Text.Length > 0;
        }

        internal void SetErrorText(string errorMessage)
        {
            labelError.Text = errorMessage;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogOK?.Invoke(this, EventArgs.Empty);
        }
    }
}
