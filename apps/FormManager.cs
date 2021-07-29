using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prg251_Porject_01.apps
{
    public class FormManager
    {
        #region Fields

        private Form ActiveFormOnPage;

        #endregion Fields



        #region Methods

        public void CloseForm()
        {
            if (ActiveFormOnPage != null) { ActiveFormOnPage.Close(); }
        }

        public void OpenFormInLable(Panel form, Form ChildForm, object btnsender)
        {
            //destroy old if there is one
            CloseForm();
            //create the new one
            ActiveFormOnPage = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            //add the form now
            form.Controls.Add(ChildForm);
            form.Tag = ChildForm;
            //Bring it to the front
            ChildForm.BringToFront();
            //Show it
            ChildForm.Show();
        }

        #endregion Methods
    }
}