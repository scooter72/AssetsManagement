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

namespace AssetsManagementForm
{
    public partial class AddAssetForm : Form
    {
        public AddAssetForm (City[] cities, Owner[] owners)
        {
            InitializeComponent();
            comboBox2.DataSource = cities;
            comboBox2.DisplayMember = "Name"; // Column Name
            comboBox2.ValueMember = "Symbol";  // Column Name
            comboBox1.DataSource = owners;
            comboBox1.DisplayMember = "Name"; // Column Name
            comboBox1.ValueMember = "Id";  // Column Name
        }

        public int Id { get => int.Parse(textBoxId.Text); set => textBoxId.Text = value.ToString(); }
        public string TeanatName { get => textBoxName.Text; set => textBoxName.Text = value; }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = textBoxId.Text.Length > 0 && textBoxName.Text.Length > 0;
        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = textBoxId.Text.Length > 0 && textBoxName.Text.Length > 0;
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
