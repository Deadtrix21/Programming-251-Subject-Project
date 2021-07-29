using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Prg251_Porject_01.apps
{
    public partial class Login : Form
    {
        #region Constructors

        private FormManager Forms = new FormManager();
        private FormManager PParent;

        public Login(FormManager parent)
        {
            PParent = parent;
            InitializeComponent();
        }

        #endregion Constructors



        #region Methods

        private void button1_Click(object sender, EventArgs e)
        {
            DBManager DB = Properties.Settings.Default.DBManagerDelta1;
            Dictionary<string, dynamic> abuse;
            if (checkBox1.Checked == true)
            {
                abuse = DB.LoginSql(true, textBox1.Text);
                Admin.AdminInternal block_a = abuse["class"];
                if (block_a != null)
                {
                    if (block_a.Administrator_Password == textBox2.Text)
                    {
                        Properties.Settings.Default.Adminaccount = block_a;
                        MessageBox.Show("Welcome Back {0}", block_a.Administrator_Name);
                        loginPanl.Hide();
                        Forms.OpenFormInLable(panel2, new apps.AdminForm(Forms), sender);
                    }
                    else { MessageBox.Show("Incorect password"); }
                }
                else { MessageBox.Show("There is no such email"); }
            }
            else
            {
                abuse = DB.LoginSql(false, textBox1.Text);
                Student.StudentInternal block_b = abuse["class"];
                if (block_b != null)
                {
                    if (block_b.Student_Password == textBox2.Text)
                    {
                        Properties.Settings.Default.Studentaccount = block_b;
                        MessageBox.Show("Welcome Back {0}", block_b.Student_Name);
                        loginPanl.Hide();
                        Forms.OpenFormInLable(panel2, new apps.StudentForm(Forms), sender);
                    }
                    else { MessageBox.Show("Incorect password"); }
                }
                else { MessageBox.Show("There is no such email"); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PParent.CloseForm();
        }

        private void Emailbox_TextChanged(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        #endregion Methods



        #region Methods

        private void createCustom()
        {
            TextBox UserEmail = new TextBox();
            UserEmail.Location = new Point(277, 97);
            UserEmail.Multiline = true;
            UserEmail.Width = 251;
            UserEmail.Height = 40;
            panel1.Controls.Add(UserEmail);
        }

        #endregion Methods

        #region Methods

        private void Login_Load(object sender, EventArgs e)
        {
        }

        #endregion Methods
    }
}