using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xtrim_ERP.gui
{
    public partial class Login : Form
    {
        public String LogonSuccessful = "";
        public Login()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            LogonSuccessful = "1";
            //MainMenu frm = new MainMenu();
            //frm.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LogonSuccessful = "0";
            //Application.Exit();
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
