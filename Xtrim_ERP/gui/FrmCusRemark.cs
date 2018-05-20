using C1.Win.C1FlexGrid;
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
    public partial class FrmCusRemark : Form
    {
        XtrimControl xC;
        CustomerRemark cusR;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        //C1FlexGrid grfCusR;
        Boolean flagEdit = false;

        public FrmCusRemark(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            cusR = new CustomerRemark();
            bg = txtRemark.BackColor;
            fc = txtRemark.ForeColor;
            ff = txtRemark.Font;

            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            bg = txtRemark.BackColor;
            fc = txtRemark.ForeColor;
            theme1.SetTheme(sB, "BeigeOne");
            sB1.Text = "";
            setControl(xC.cusrID);
            setControlEnable(false);
            setFocusColor();
            btnVoid.Hide();
        }
        
        private void setControl(String cusRId)
        {
            cusR = xC.xtDB.cusrDB.selectByPk1(cusRId);
            txtID.Value = cusR.remark_id;
            txtRemark.Value = cusR.remark;
            txtRemark2.Value = cusR.remark2;
            //txtContFNameE.Value = cont.cont_fname_e;
            //txtContLNameE.Value = cont.cont_lname_e;
            //txtNickName.Value = cont.nick_name;
            //txtPosiName.Value = cont.posi_name;
            //txtRemark.Value = cont.remark;
            //txtWorkResponse.Value = cont.work_response;
        }
        private void setControlEnable(Boolean flag)
        {
            txtRemark.Enabled = flag;
            txtRemark2.Enabled = flag;
            btnSave.Enabled = flag;
            chkStatus1.Enabled = flag;
            chkStatus2.Enabled = flag;
            chkStatus3.Enabled = flag;
            chkStatus4.Enabled = flag;

            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }
        private void setCustomerRemark()
        {
            cusR.remark_id = txtID.Text;
            cusR.cust_id = xC.cusID;
            cusR.remark_id = txtID.Text;

            cusR.remark = txtRemark.Text;
            cusR.remark2 = txtRemark2.Text;
            cusR.active = "1";
        }
        private void setFocusColor()
        {
            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark2.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = xC.cTxtFocus;
            a.Font = new Font(ff, FontStyle.Bold);
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = bg;
            a.ForeColor = fc;
            a.Font = new Font(ff, FontStyle.Regular);
        }
        private void btnVoid_Click(object sender, EventArgs e)
        {

        }

        private void chkVoid_Click(object sender, EventArgs e)
        {
            btnVoid.Visible = chkVoid.Checked ? true : false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            flagEdit = flagEdit ? false : true;
            setControlEnable(flagEdit);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setCustomerRemark();
                String re = xC.xtDB.cusrDB.insertCustomerRemark(cusR);
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
        private void FrmCusRemark_Load(object sender, EventArgs e)
        {

        }
    }
}
