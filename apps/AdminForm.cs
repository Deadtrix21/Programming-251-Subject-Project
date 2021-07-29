using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prg251_Porject_01.apps
{
    public partial class AdminForm : Form
    {
        #region Fields

        private FormManager Forms = new FormManager();
        private FormManager PParent;

        #endregion Fields

        #region Constructors

        public AdminForm(FormManager parent)
        {
            InitializeComponent();
            PParent = parent;
            if (Properties.Settings.Default.Adminaccount.SuperAdmin == "1" ||
                Properties.Settings.Default.Adminaccount.SuperAdmin == "2" ||
                Properties.Settings.Default.Adminaccount.SuperAdmin == "3")
            { button2.Show(); }
            else { button2.Hide(); }
        }

        #endregion Constructors



        #region Methods

        private void button1_Click(object sender, EventArgs e)
        {
            //search student
            Forms.OpenFormInLable(panel2, new apps.EditStudent(Forms), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //create admin
            Forms.OpenFormInLable(panel2, new apps.CreateAdmin(Forms), sender);
        }

        #endregion Methods

        private void button3_Click(object sender, EventArgs e)
        {
            PParent.CloseForm();
        }
    }
}