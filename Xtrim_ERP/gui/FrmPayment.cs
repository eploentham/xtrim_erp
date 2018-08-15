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
    public partial class FrmPayment : Form
    {
        XtrimControl xC;
        C1FlexGrid grfJob, grfBill, grfBillD;

        Company cop;
        Customer cus;
        JobImport jim;
        Billing bll;
        Font fEdit, fEditB;

        int colID = 1, colCode = 2, colDesc = 3, colRemark = 4, colAmt = 5, colStatus = 6;
        int colBID = 1, colBDocNo = 2, colBAmt = 3, colBBillDate = 4, colBremark = 5;
        int colBdID = 1, colBdNameT = 2, colBdAmtD = 3, colBdAmtI = 4;

        Color bg, fc;
        Font ff, ffB;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "", cusId = "";

        public FrmPayment(XtrimControl x)
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

            sB1.Text = "";
            cop = new Company();
            cop = xC.xtDB.copDB.selectByCode1("001");
            //bll = new Billing();
            cus = new Customer();
            jim = new JobImport();
            bll = new Billing();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            txtCusNameT.KeyUp += TxtCusNameT_KeyUp;

            initGrfJob();
            initGrfBill();
            initGrfBillD();
        }
        private void initGrfJob()
        {
            grfJob = new C1FlexGrid();
            grfJob.Font = fEdit;
            grfJob.Dock = System.Windows.Forms.DockStyle.Fill;
            grfJob.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpnD);

            //grfJob.AfterRowColChange += GrfJob_AfterRowColChange;
            grfJob.DoubleClick += GrfJob_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //grfJob.CellChanged += GrfExpnD_CellChanged;
            panelJob.Controls.Add(grfJob);
            grfJob.Clear();
            grfJob.Rows.Count = 2;
            grfJob.Cols.Count = 6;
            grfJob.Cols[colAmt].Width = 80;
            grfJob.Cols[colCode].Width = 100;
            grfJob.Cols[colDesc].Width = 200;
            grfJob.Cols[colRemark].Width = 100;
            grfJob.Cols[colAmt].Caption = "ยอดเงิน";
            grfJob.Cols[colCode].Caption = "เลขที่  job no";
            grfJob.Cols[colDesc].Caption = "รายละเอียด";
            grfJob.Cols[colRemark].Caption = "หมายเหตุ";
            grfJob.Cols[colID].Visible = false;

            theme1.SetTheme(grfJob, "Office2013Red");
        }
        private void setGrfJob(String cusid)
        {
            grfJob.DataSource = null;
            grfJob.Rows.Count = 2;
            grfJob.Clear();
            if (cusid.Equals("")) return;
            DataTable dt = new DataTable();
            dt = xC.manDB.jimDB.selectJimJblByJobYear2(cusid);
            //grfJob.DataSource = xC.xtDB.jimDB.selectJimJblByJobYear2(cusid);
            //grfJob.Cols.Count = dt.Columns.Count;
            grfJob.Rows.Count = dt.Rows.Count + 1;

            grfJob.Cols.Count = 6;
            TextBox txt = new TextBox();

            grfJob.Cols[colCode].Editor = txt;
            grfJob.Cols[colDesc].Editor = txt;
            grfJob.Cols[colRemark].Editor = txt;
            grfJob.Cols[colAmt].Editor = txt;

            grfJob.Cols[colAmt].Width = 80;
            grfJob.Cols[colCode].Width = 100;
            grfJob.Cols[colDesc].Width = 200;
            grfJob.Cols[colRemark].Width = 100;

            grfJob.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";
            grfJob.Cols[colAmt].Caption = "ยอดเงิน";
            grfJob.Cols[colCode].Caption = "เลขที่ job no";
            grfJob.Cols[colDesc].Caption = "รายละเอียด";
            grfJob.Cols[colRemark].Caption = "หมายเหตุ";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfJob[i + 1, 0] = i;
                if (i % 2 == 0)
                    grfJob.Rows[i].StyleNew.BackColor = color;
                grfJob[i + 1, colID] = dt.Rows[i][xC.manDB.jimDB.jim.job_import_id].ToString();
                grfJob[i + 1, colCode] = dt.Rows[i][xC.manDB.jimDB.jim.job_import_code].ToString();
                grfJob[i + 1, colDesc] = dt.Rows[i][xC.manDB.jblDB.jbl.description].ToString();
                grfJob[i + 1, colRemark] = dt.Rows[i][xC.manDB.jimDB.jim.remark1].ToString();
                //grfJob[i + 1, colAmt] = dt.Rows[i][xC.xtDB.jimDB.jim.job_import_id].ToString();
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfJob.Cols[colID].Visible = false;

        }
        private void GrfJob_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            cus = xC.sCus;
            jim = new JobImport();
            jim = xC.manDB.jimDB.selectByPk1(grfJob[grfJob.Row, colID].ToString());
            txtJobId.Value = jim.job_import_id;
            //txtCusNameT.Value = cus.cust_name_t;
            txtJobCode.Value = jim.job_import_code;

            setGrfBillView(jim.job_import_id);
        }
        private void initGrfBill()
        {
            grfBill = new C1FlexGrid();
            grfBill.Font = fEdit;
            grfBill.Dock = System.Windows.Forms.DockStyle.Fill;
            grfBill.Location = new System.Drawing.Point(0, 0);
            grfBill.Rows.Count = 1;
            grfBill.Cols[colBDocNo].Width = 100;
            grfBill.Cols[colBAmt].Width = 100;
            grfBill.Cols[colBBillDate].Width = 100;
            grfBill.Cols[colBremark].Width = 200;
            //grfBill.Cols[colCAmt].Width = 100;
            grfBill.Cols[colBDocNo].Caption = "เลขที่";
            grfBill.Cols[colBAmt].Caption = "ยอดเงินรวม";
            grfBill.Cols[colBBillDate].Caption = "วันที่วางบิล";
            grfBill.Cols[colBremark].Caption = "หมายเหตุ";
            //grfBill.Cols[colCAmt].Caption = "รวมเงิน";

            grfBill.DoubleClick += GrfBill_DoubleClick;

            panelBill.Controls.Add(grfBill);

            theme1.SetTheme(grfBill, "VS2013Green");
            grfBill.Cols[colBID].Visible = false;
        }
        private void setGrfBillView(String jimId)
        {
            grfBill.Clear();
            grfBill.Cols[colBDocNo].Width = 100;
            grfBill.Cols[colBAmt].Width = 100;
            grfBill.Cols[colBBillDate].Width = 100;
            grfBill.Cols[colBremark].Width = 200;
            //grfBill.Cols[colCAmt].Width = 100;
            grfBill.Cols[colBDocNo].Caption = "เลขที่";
            grfBill.Cols[colBAmt].Caption = "ยอดเงินรวม";
            grfBill.Cols[colBBillDate].Caption = "วันที่วางบิล";
            grfBill.Cols[colBremark].Caption = "หมายเหตุ";
            grfBill.Cols[colBID].Visible = false;

            DataTable dt = new DataTable();
            dt = xC.accDB.bllDB.selectByJobId(jimId);
            //grfChequeView1.DataSource = dt;
            grfBill.Cols.Count = 6;
            grfBill.Rows.Count = dt.Rows.Count + 1;
            TextBox txt = new TextBox();

            grfBill.Cols[colBID].Editor = txt;
            grfBill.Cols[colBDocNo].Editor = txt;
            grfBill.Cols[colBAmt].Editor = txt;
            grfBill.Cols[colBBillDate].Editor = txt;
            grfBill.Cols[colBremark].Editor = txt;
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfBill[i + 1, 0] = i + 1;
                if (i % 2 == 0)
                    grfBill.Rows[i + 1].StyleNew.BackColor = color;
                grfBill[i + 1, colBID] = dt.Rows[i][xC.accDB.bllDB.bll.billing_id].ToString();
                grfBill[i + 1, colBDocNo] = dt.Rows[i][xC.accDB.bllDB.bll.billing_code].ToString();
                grfBill[i + 1, colBAmt] = dt.Rows[i][xC.accDB.bllDB.bll.amount].ToString();
                grfBill[i + 1, colBBillDate] = xC.dateDBtoShow(dt.Rows[i][xC.accDB.bllDB.bll.billing_date].ToString());
                grfBill[i + 1, colBremark] = dt.Rows[i][xC.accDB.bllDB.bll.remark].ToString();
            }

        }
        private void initGrfBillD()
        {
            grfBillD = new C1FlexGrid();
            grfBillD.Font = fEdit;
            grfBillD.Dock = System.Windows.Forms.DockStyle.Fill;
            grfBillD.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpnD);

            //grfJob.AfterRowColChange += GrfJob_AfterRowColChange;
            
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //grfJob.CellChanged += GrfExpnD_CellChanged;
            panelBllD.Controls.Add(grfBillD);
            grfBillD.Clear();
            grfBillD.Rows.Count = 2;
            grfBillD.Cols.Count = 5;
            grfBillD.Cols[colBdNameT].Width = 200;
            grfBillD.Cols[colBdAmtD].Width = 100;
            grfBillD.Cols[colBdAmtI].Width = 100;
            //grfBillD.Cols[colRemark].Width = 100;
            grfBillD.Cols[colBdNameT].Caption = "รายการ";
            grfBillD.Cols[colBdAmtD].Caption = "ค่าใช้จ่าย";
            grfBillD.Cols[colBdAmtI].Caption = "รายได้";
            //grfBillD.Cols[colRemark].Caption = "หมายเหตุ";
            grfBillD.Cols[colBdID].Visible = false;

            theme1.SetTheme(grfBillD, "VS2013Purple");
        }
        private void setGrfBillViewD(String blldId)
        {
            grfBillD.Clear();
            grfBillD.Cols[colBdNameT].Width = 200;
            grfBillD.Cols[colBdAmtD].Width = 100;
            grfBillD.Cols[colBdAmtI].Width = 100;
            //grfBillD.Cols[colBremark].Width = 200;
            //grfBill.Cols[colCAmt].Width = 100;
            grfBillD.Cols[colBdNameT].Caption = "รายการ";
            grfBillD.Cols[colBdAmtD].Caption = "ค่าใช้จ่าย";
            grfBillD.Cols[colBdAmtI].Caption = "รายได้";
            //grfBillD.Cols[colBremark].Caption = "หมายเหตุ";
            grfBillD.Cols[colBID].Visible = false;

            DataTable dt = new DataTable();
            dt = xC.accDB.blldDB.selectByBillId(blldId);
            //grfChequeView1.DataSource = dt;
            grfBillD.Cols.Count = 5;
            grfBillD.Rows.Count = dt.Rows.Count + 1;
            TextBox txt = new TextBox();

            grfBillD.Cols[colBdID].Editor = txt;
            grfBillD.Cols[colBdNameT].Editor = txt;
            grfBillD.Cols[colBdAmtD].Editor = txt;
            grfBillD.Cols[colBdAmtI].Editor = txt;
            //grfBillD.Cols[colBremark].Editor = txt;
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfBillD[i + 1, 0] = i + 1;
                if (i % 2 == 0)
                    grfBillD.Rows[i + 1].StyleNew.BackColor = color;
                grfBillD[i + 1, colBdID] = dt.Rows[i][xC.accDB.blldDB.blld.billing_detail_id].ToString();
                grfBillD[i + 1, colBdNameT] = dt.Rows[i][xC.accDB.blldDB.blld.item_name_t].ToString();
                grfBillD[i + 1, colBdAmtD] = dt.Rows[i][xC.accDB.blldDB.blld.amount_draw].ToString();
                grfBillD[i + 1, colBdAmtI] = dt.Rows[i][xC.accDB.blldDB.blld.amount_income].ToString();
                //grfBillD[i + 1, colBremark] = dt.Rows[i][xC.xtDB.bllDB.bll.remark].ToString();
            }

        }
        private void GrfBill_DoubleClick(object sender, EventArgs e)
        {
            if (grfBill[grfBill.Row, colBID] == null) return;
            String bllId = "";
            bllId = grfBill[grfBill.Row, colBID].ToString();
            setGrfBillViewD(bllId);
        }
        private void TxtCusNameT_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.F2)
            {
                if (sender.Equals(txtCusNameT))
                {
                    //setKeyUpF2Cus();
                    setKeyUpF2Cus();
                    setGrfJob(cusId);
                }
            }
        }
        private void setKeyUpF2Cus()
        {
            Point pp = txtCusNameT.Location;
            pp.Y = pp.Y + 120 + 20;
            pp.X = pp.X - 20 + panelCus.Left;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Customer, pp);
            frm.ShowDialog(this);
            setKeyUpF2Cus1(xC.sCus);
        }
        private void setKeyUpF2Cus1(Customer cus)
        {
            txtCusNameT.Value = cus.cust_name_t;
            cusId = cus.cust_id;
        }
        private void FrmPayment_Load(object sender, EventArgs e)
        {

        }
    }
}
