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
    public partial class StudentForm : Form
    {
        #region Fields

        private FormManager Forms = new FormManager();
        private FormManager PParent;

        #endregion Fields

        #region Constructors

        public StudentForm(FormManager parent)
        {
            PParent = parent;
            InitializeComponent();
        }

        #endregion Constructors



        #region Methods

        private void button3_Click(object sender, EventArgs e)
        {
            PParent.CloseForm();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
        }

        #endregion Methods
    }
}