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
            theme1.SetTheme(sB, "BeigeOne");
            sB1.Text = "";
            setControl(xC.custID);
        }

        

        private void setControl(String cusRId)
        {
            cusT = xC.xtDB.custDB.selectByPk1(cusRId);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setCustomerTaxInvoice();
                String re = xC.xtDB.custDB.insertCustomerTaxInvoice(cusT);
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

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
        private void FrmCustTaxInvoice_Load(object sender, EventArgs e)
        {

        }
    }
}
