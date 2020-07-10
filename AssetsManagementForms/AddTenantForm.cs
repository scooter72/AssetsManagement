using AssetsManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetsManagementForms
{
    public partial class AddTenantForm : Form
    {
        private Tenant[] tenants;
        private const string IdInUse = "Id in use";

        public AddTenantForm(Tenant[] tenants)
        {
            InitializeComponent();
            this.tenants = tenants;
        }

        internal Tenant Tenant
        {
            get { return new Tenant { Id = Id, Name = TenantName }; }
            set
            {
                textBoxId.Text = value.Id.ToString();
                textBoxName.Text = value.Name.ToString();
            }
        }
        private int Id { get => int.Parse(textBoxId.Text); set => textBoxId.Text = value.ToString(); }
        private string TenantName { get => textBoxName.Text; set => textBoxName.Text = value; }


        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            InputTextChanged();
        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            InputTextChanged();
        }

        private void InputTextChanged()
        {
            buttonOK.Enabled = IsNameValid && IsIdlValid;
            SetErrorText();
        }


        private bool IsNameValid
        {
            get => textBoxName.Text.Length > 0;
        }


        private bool IsIdlValid
        {
            get => textBoxId.Text.Length > 0 && !(IsIdInUse);
        }

        private bool IsIdInUse
        {
            get => tenants.Any(c => c.Id.ToString().Equals(textBoxId.Text));
        }

        private void SetErrorText()
        {
            labelError.Text = string.Empty;
            if (IsIdInUse)
            {
                labelError.Text = IdInUse;
            }
        }

        private void textBoxSymbol_KeyPress(object sender, KeyPressEventArgs e)
        {
            List<Keys> allowdKeys = new List<Keys>() 
            { 
                Keys.Tab, 
                Keys.Right, 
                Keys.Left, 
                Keys.Home, 
                Keys.End, 
                Keys.Delete, 
                Keys.Back, 
                Keys.Shift 
            };

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) 
                && !allowdKeys.Contains((Keys)e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
