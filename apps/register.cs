using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prg251_Porject_01.apps
{
    public partial class register : Form
    {
        #region Constructors

        private FormManager parent;

        public register(FormManager form)
        {
            InitializeComponent();
            parent = form;
        }

        #endregion Constructors



        #region Methods

        private void Createbtn_Click(object sender, EventArgs e)
        {
            DBManager block = Properties.Settings.Default.DBManagerDelta1;
            NameValueCollection data = new NameValueCollection();
            data["name"] = textBox2.Text;
            data["email"] = textBox1.Text;
            data["pass"] = textBox3.Text;
            data["sa"] = textBox6.Text;
            data["campus"] = comboBox1.Text;
            data["gender"] = "Not implmented";
            data["type"] = Convert.ToString(comboBox2.SelectedIndex);
            data["home"] = comboBox3.Text;
            block.CreateSql(false, data);
            MessageBox.Show("Account was made");
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        #endregion Methods

        private void button1_Click(object sender, EventArgs e)
        {
            parent.CloseForm();
        }
    }
}