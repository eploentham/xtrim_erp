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
    public partial class FrmSetPassword : Form
    {
        Staff stf;
        XtrimControl xC;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        public FrmSetPassword(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            stf = new Staff();
            foreach (Control c in panel1.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }
            txtPassword.KeyUp += TxtPassword_KeyUp;
            txtCPassword.KeyUp += TxtCPassword_KeyUp;
            btnSave.Enabled = false;
        }

        private void TxtCPassword_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCPassword.Text.Equals(txtPassword.Text))
                {
                    btnSave.Focus();
                    btnSave.Enabled = true;
                }
                else
                {
                    MessageBox.Show("รหัสผ่าน ไม่เหมือนกัน", "error");
                }
            }
        }

        private void TxtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                txtCPassword.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String re = xC.xtDB.stfDB.updatePassword(xC.stfID, txtPassword.Text.Trim());
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                //setGrdView();
                this.Dispose();
            }
        }
        private void FrmSetPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
