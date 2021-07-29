using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Prg251_Porject_01.apps;

namespace Prg251_Porject_01
{
    public partial class Main : Form
    {
        #region Fields

        private FormManager Forms = new FormManager();

        [DllImport("user32")]
        private static extern bool ReleaseCapture();

        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wp, int lp);

        #endregion Fields

        #region Constructors

        public Main()
        {
            InitializeComponent();
            DBManager db = Properties.Settings.Default.DBManagerDelta1;
            db.Path = Environment.CurrentDirectory;
            db.create_tbl();
        }

        #endregion Constructors



        #region Methods

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion Methods

        private void button2_Click(object sender, EventArgs e)
        {
            Forms.OpenFormInLable(panel2, new apps.register(Forms), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Forms.OpenFormInLable(panel2, new apps.Login(Forms), sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Forms.CloseForm();
        }

        private void MoveApp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 161, 2, 0);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}