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
    public partial class AddCityForm : Form
    {
        public AddCityForm()
        {
            InitializeComponent();
        }

        internal City City
        {
            get { return new City { Symbol = Symbol, Name = CityName }; }
            set 
            {
                textBoxSymbol.Text = value.Symbol.ToString();
                textBoxName.Text = value.Name; 
            } 
        }

        private int Symbol { get => int.Parse(textBoxSymbol.Text); set => textBoxSymbol.Text = value.ToString(); }
        private string CityName { get => textBoxName.Text; set => textBoxName.Text = value; }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = textBoxSymbol.Text.Length > 0 && textBoxName.Text.Length > 0;
        }

        private void textBoxSymbol_TextChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = textBoxSymbol.Text.Length > 0 && textBoxName.Text.Length > 0;
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
