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
    public partial class EditStudent : Form
    {
        #region Fields

        private FormManager parent;

        #endregion Fields

        #region Constructors

        public EditStudent(FormManager form)
        {
            InitializeComponent();
            parent = form;
            parent.CloseForm();
        }

        #endregion Constructors



        #region Methods

        private void EditStudent_Load(object sender, EventArgs e)
        {
        }

        #endregion Methods
    }
}