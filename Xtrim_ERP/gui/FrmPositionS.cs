using C1.Win.C1Input;
using C1.Win.C1Themes;
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
    public partial class FrmPositionS : Form
    {
        XtrimControl xC;
        Position posi;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        Boolean flagEdit = false;
        public FrmPositionS(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            posi = new Position();
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel1.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }

            bg = txtPosiCode.BackColor;
            fc = txtPosiCode.ForeColor;
            ff = txtPosiCode.Font;

            //initGrfPosi();
            //setGrfPosi();
            setControlEnable(false);
            setFocusColor();
            sB1.Text = "";
            btnVoid.Hide();
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = xC.cTxtFocus;
            a.Font = new Font(ff, FontStyle.Bold);
        }
        private void setFocusColor()
        {
            this.txtPosiCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPosiCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPosiNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPosiNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = bg;
            a.ForeColor = fc;
            a.Font = new Font(ff, FontStyle.Regular);
        }
        private void setControl(String posiId)
        {
            posi = xC.xtDB.posiDB.selectByPk1(posiId);
            txtID.Value = posi.posi_id;
            txtPosiCode.Value = posi.posi_code;
            txtPosiNameT.Value = posi.posi_name_t;
            txtRemark.Value = posi.remark;
        }
        private void setControlEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            txtPosiCode.Enabled = flag;
            txtPosiNameT.Enabled = flag;
            txtRemark.Enabled = flag;
        }
        private void setDeptment()
        {
            posi.posi_id = txtID.Text;
            posi.posi_code = txtPosiCode.Text;
            posi.posi_name_t = txtPosiNameT.Text;
            //posi.posi_name_e = txtPosiNameE.Text;
            posi.remark = txtRemark.Text;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtID.Value = "";
            txtPosiCode.Value = "";
            txtPosiNameT.Value = "";
            txtRemark.Value = "";
            chkVoid.Checked = false;
            btnVoid.Hide();
            setControlEnable(true);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            flagEdit = flagEdit ? false : true;
            setControlEnable(flagEdit);
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setDeptment();
                String re = xC.xtDB.posiDB.insertPosition(posi);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                //setGrfPosi();
                //setGrdView();
                //this.Dispose();
            }
        }

        private void chkVoid_Click(object sender, EventArgs e)
        {
            if (btnVoid.Visible)
            {
                btnVoid.Hide();
            }
            else
            {
                btnVoid.Show();
            }
        }

        private void FrmPositionS_Load(object sender, EventArgs e)
        {

        }
    }
}
