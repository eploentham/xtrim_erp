using C1.Win.C1FlexGrid;
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

namespace Xtrim_ERP.gui
{
    public partial class FrmDebtorAdd : Form
    {
        XtrimControl xC;
        Billing bll;
        Receipt rcp;
        BillingCover bllC;
        Company cop;
        Customer cus;
        JobImport jim;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colItemNameT = 2, colExpn = 3, colimcome = 4, colItemId = 5;
        
        C1FlexGrid grfBill, grfAdd;
        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "", cusId = "";
        public FrmDebtorAdd(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");

            //btnNew.Click += BtnNew_Click;
            txtCusNameT.KeyUp += TxtCusNameT1_KeyUp;
            txtBllCode.KeyUp += TxtBllCode_KeyUp;
            //btnCashOk.Click += BtnCashOk_Click;
            //btnBNew.Click += BtnBNew_Click;
            //btnBSave.Click += BtnBSave_Click;
            //btnPrnRcp.Click += BtnPrnRcp_Click;
            //btnPrnCover.Click += BtnPrnCover_Click;

            DateTime billDate = DateTime.Now;
            txtBillDate.Value = billDate.Year.ToString() + "-" + billDate.ToString("MM-dd");

            sB1.Text = "";
            cop = new Company();
            cop = xC.xtDB.copDB.selectByCode1("001");
            bll = new Billing();
            cus = new Customer();
            jim = new JobImport();
            bllC = new BillingCover();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            txtVat.Value = cop.vat;
            txtOldvat.Value = cop.vat;
            //txtOldvat.Value = cop.vat;

            stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;

            //chkAll.Checked = true;
            //xC.setCboYear(cboYear);

            initGrfBill();
            initGrfAdd();
            //setGrfDeptH();
        }

        private void TxtBllCode_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void initGrfBill()
        {
            grfBill = new C1FlexGrid();
            grfBill.Font = fEdit;
            grfBill.Dock = System.Windows.Forms.DockStyle.Fill;
            grfBill.Location = new System.Drawing.Point(0, 0);
            grfBill.Rows.Count = 1;
            grfBill.Cols.Count = 6;
            grfBill.Cols[colItemNameT].Width = 220;
            grfBill.Cols[colExpn].Width = 100;
            grfBill.Cols[colimcome].Width = 100;
            //grfBill.Cols[colCDrawDate].Width = 100;
            //grfBill.Cols[colCAmt].Width = 100;
            grfBill.Cols[colItemNameT].Caption = "รายการ";
            grfBill.Cols[colExpn].Caption = "ค่าใช้จ่าย";
            grfBill.Cols[colimcome].Caption = "รายได้";
            //grfBill.Cols[colCDrawDate].Caption = "วันที่";
            //grfBill.Cols[colCAmt].Caption = "รวมเงิน";

            panel2.Controls.Add(grfBill);

            theme1.SetTheme(grfBill, "VS2013Red");
            grfBill.Cols[colID].Visible = false;
            grfBill.Cols[colItemId].Visible = false;
        }
        private void initGrfAdd()
        {
            grfAdd = new C1FlexGrid();
            grfAdd.Font = fEdit;
            grfAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            grfAdd.Location = new System.Drawing.Point(0, 0);
            grfAdd.Rows.Count = 1;
            grfAdd.Cols.Count = 6;
            grfAdd.Cols[colItemNameT].Width = 220;
            grfAdd.Cols[colExpn].Width = 100;
            grfAdd.Cols[colimcome].Width = 100;
            //grfBill.Cols[colCDrawDate].Width = 100;
            //grfBill.Cols[colCAmt].Width = 100;
            grfAdd.Cols[colItemNameT].Caption = "รายการ";
            grfAdd.Cols[colExpn].Caption = "ค่าใช้จ่าย";
            grfAdd.Cols[colimcome].Caption = "รายได้";
            //grfBill.Cols[colCDrawDate].Caption = "วันที่";
            //grfBill.Cols[colCAmt].Caption = "รวมเงิน";

            panel3.Controls.Add(grfAdd);

            theme1.SetTheme(grfAdd, "VS2013Green");
            grfAdd.Cols[colID].Visible = false;
            grfAdd.Cols[colItemId].Visible = false;
        }
        private void setKeyUpF2Cus()
        {
            Point pp = txtCusNameT.Location;
            pp.Y = pp.Y + 120 + 20;
            pp.X = pp.X - 20 + panel2.Left;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Customer, pp);
            frm.ShowDialog(this);
            setKeyUpF2Cus1(xC.sCus);
        }
        private void setKeyUpF2Cus1(Customer cus)
        {
            this.cus = cus;
            txtCusNameT.Value = this.cus.cust_name_t;
            cusId = this.cus.cust_id;
        }
        private void TxtCusNameT1_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.F2)
            {
                if (sender.Equals(txtCusNameT))
                {
                    //setKeyUpF2Cus();
                    setKeyUpF2Cus();
                    //setGrfJob(cusId);
                }
            }
        }
        private void FrmDebtorAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
