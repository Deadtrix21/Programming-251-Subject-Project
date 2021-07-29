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
    public partial class CreateAdmin : Form
    {
        #region Constructors

        private FormManager parent;

        public CreateAdmin(FormManager form)
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
            if (checkBox1.Checked == true)
            {
                data["sa"] = "1";
                if (checkBox2.Checked) { data["lock"] = "2"; }
            }
            else
            {
                data["sa"] = "0";
                if (checkBox2.Checked) { data["lock"] = "1"; }
                else { data["lock"] = "0"; }
            }

            block.CreateSql(true, data);
            MessageBox.Show("account was made");
            parent.CloseForm();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        #endregion Methods

        private void button1_Click(object sender, EventArgs e)
        {
            parent.CloseForm();
        }
    }
}