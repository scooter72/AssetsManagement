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
        private City[] cities;
        private const string NameInUse = "Name in use";
        private const string SymbolInUse = "Symbol in use";

        public AddCityForm(City[] cities)
        {
            this.cities = cities == null ? new City[0] : cities;
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
            InputTextChanged();
        }
        private void textBoxSymbol_TextChanged(object sender, EventArgs e)
        {
            InputTextChanged();
        }

        private void InputTextChanged()
        {
            buttonOK.Enabled = IsNameValid && IsSymbolValid;
            SetErrorTest();
        }


        private bool IsNameValid 
        { 
            get => textBoxSymbol.Text.Length > 0 && !(IsNameInUse); 
        }

        private bool IsNameInUse
        {
            get => cities.Any(c => c.Name.Equals(textBoxName.Text));
        }

        private bool IsSymbolValid
        {
            get => textBoxSymbol.Text.Length > 0 && !(IsSymbolInUse);
        }

        private bool IsSymbolInUse
        {
            get => cities.Any(c => c.Symbol.ToString().Equals(textBoxSymbol.Text));
        }

        private void SetErrorTest()
        {
            labelError.Text = string.Empty;
            if (IsNameInUse || IsSymbolInUse)
            {
                labelError.Text = IsNameInUse ? NameInUse : SymbolInUse;
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
