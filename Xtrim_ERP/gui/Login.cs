using C1.Win.C1SuperTooltip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xtrim_ERP.control;
using Xtrim_ERP.object1;
using Xtrim_ERP.Properties;

namespace Xtrim_ERP.gui
{
    public partial class Login : Form
    {
        XtrimControl xC;
        Staff stf;
        public String LogonSuccessful = "";

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        FrmSplash splash;
        public Login(XtrimControl x, FrmSplash splash)
        {
            InitializeComponent();
            xC = x;
            this.splash = splash;
            initConfig();
        }
        private void initConfig()
        {
            txtUserName.KeyUp += TxtUserName_KeyUp;
            txtUserName.LostFocus += TxtUserName_LostFocus;
            txtPassword.KeyUp += TxtPassword_KeyUp;
            foreach(Control c in panel1.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }
            theme1.SetTheme(panel1, "Office2013Red");
            //theme1.SetTheme(label2, "Office2010Blue");
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
            //stt.
        }

        private void TxtUserName_LostFocus(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            chkLogin();
        }

        private void TxtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                btnOk.Focus();
            }
        }

        private void TxtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                chkLogin();
            }
        }
        private void chkLogin()
        {
            Staff stf1 = new Staff();
            stf1 = xC.xtDB.stfDB.selectByUsername(txtUserName.Text);
            if (stf1.staff_fname_t.Length > 0)
            {
                btnOk.Image = Resources.Accept_Male_User24;
                //stt.Show("<p><b>สวัสดี</b></p>คุณ " + stf1.staff_fname_t + " " + stf1.staff_lname_t + "<br> กรุณา ป้อนรหัสผ่าน", txtUserName);

                //stt.SetToolTip(txtUserName, "<p><b>สวัสดี</b></p>คุณ " + stf1.staff_fname_t + " " + stf1.staff_lname_t + "<br> กรุณา ป้อนรหัสผ่าน");
                sep.Clear();
                txtPassword.Focus();
            }
            else
            {
                btnOk.Image = Resources.Male_User_Warning24;
                //stt.Show("ไม่พบ username ", txtUserName);
                //stt.SetToolTip(txtUserName, "ไม่พบ username ");
                sep.SetError(txtUserName, "333");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            stf = xC.xtDB.stfDB.selectByLogin(txtUserName.Text, txtPassword.Text);
            if (stf.staff_fname_t.Length > 0)
            {
                xC.userId = stf.staff_id;
                xC.user = stf;
                xC.conn.user = stf;
                LogonSuccessful = "1";
                this.Dispose();
            }
            else
            {
                //stt.Show("ไม่พบ username หรือ password", txtPassword);
                sep.SetError(txtPassword, "333");
                LogonSuccessful = "0";
            }
            //MainMenu frm = new MainMenu();
            //frm.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LogonSuccessful = "0";
            //Application.Exit();
            this.Dispose();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.splash.Dispose();
            txtUserName.Focus();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
