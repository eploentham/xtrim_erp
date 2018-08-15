using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
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
    public partial class FrmCusTaxInvoice : Form
    {
        XtrimControl xC;
        CustomerTaxInvoice cusT;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "";
        public FrmCusTaxInvoice(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            cusT = new CustomerTaxInvoice();
            bg = txtRemark.BackColor;
            fc = txtRemark.ForeColor;
            ff = txtRemark.Font;

            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            bg = txtRemark.BackColor;
            fc = txtRemark.ForeColor;
            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;
            chkVoid.Click += ChkVoid_Click;

            theme1.SetTheme(sB, "BeigeOne");
            sB1.Text = "";
            setControl(xC.custID);
            setControlEnable(false);
            setFocusColor();
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
        }
        
        private void setControlEnable(Boolean flag)
        {
            txtTaxInvoiceNameT.Enabled = flag;
            txtTaxInvoiceNameE.Enabled = flag;
            btnSave.Enabled = flag;
            txtTaxId.Enabled = flag;
            txtRemark.Enabled = flag;
            
            chkVoid.Enabled = flag;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }

        private void setControl(String cusRId)
        {
            cusT = xC.iniDB.custDB.selectByPk1(cusRId);
            txtID.Value = cusT.tax_invoice_id;
            txtRemark.Value = cusT.remark;
            txtTaxId.Value = cusT.tax_id;
            txtTaxInvoiceNameE.Value = cusT.tax_invoice_name_e;
            txtTaxInvoiceNameT.Value = cusT.tax_invoice_name_t;
        }        

        private void setCustomerTaxInvoice()
        {
            cusT.tax_invoice_id = txtID.Text;
            cusT.cust_id = xC.cusID;
            cusT.tax_id = txtTaxId.Text;

            cusT.remark = txtRemark.Text;
            cusT.tax_invoice_name_e = txtTaxInvoiceNameE.Text;
            cusT.tax_invoice_name_t = txtTaxInvoiceNameT.Text;
            cusT.active = "1";
        }
        private void setFocusColor()
        {
            this.txtTaxInvoiceNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTaxInvoiceNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTaxInvoiceNameE.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTaxInvoiceNameE.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTaxId.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTaxId.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtRemark2.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtRemark2.Enter += new System.EventHandler(this.textBox_Enter);
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
        private void TxtPasswordVoid_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                userIdVoid = xC.xtDB.stfDB.selectByPasswordAdmin(txtPasswordVoid.Text.Trim());
                if (userIdVoid.Length > 0)
                {
                    txtPasswordVoid.Hide();
                    btnVoid.Show();
                    stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> รหัสผ่านถูกต้อง", btnVoid);
                }
                else
                {
                    sep.SetError(txtPasswordVoid, "333");
                }
            }
        }
        private void ChkVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (btnVoid.Visible)
            {
                btnVoid.Hide();
            }
            else
            {
                txtPasswordVoid.Show();
                txtPasswordVoid.Focus();
                stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> กรุณาป้อนรหัสผ่าน", txtPasswordVoid);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setCustomerTaxInvoice();
                String re = xC.iniDB.custDB.insertCustomerTaxInvoice(cusT);
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

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ ยกเลิกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                xC.iniDB.custDB.VoidTaxInvoice(txtID.Text, userIdVoid);
                this.Dispose();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            flagEdit = flagEdit ? false : true;
            setControlEnable(flagEdit);
        }
        private void FrmCustTaxInvoice_Load(object sender, EventArgs e)
        {

        }
    }
}
