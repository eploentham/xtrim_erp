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
    public partial class FrmBilling : Form
    {
        XtrimControl xC;
        ExpensesDraw expn;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colDesc = 3, colRemark = 4, colAmt = 5, colStatus = 6;
        C1FlexGrid grfJob, grfBill;
        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "", cusId="";

        public FrmBilling(XtrimControl x)
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
            txtCusNameT1.KeyUp += TxtCusNameT1_KeyUp;

            sB1.Text = "";

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;

            //chkAll.Checked = true;
            //xC.setCboYear(cboYear);
            initGrfJob();
            initGrfBill();
            //setGrfDeptH();
        }
        private void initGrfJob()
        {
            grfJob = new C1FlexGrid();
            grfJob.Font = fEdit;
            grfJob.Dock = System.Windows.Forms.DockStyle.Fill;
            grfJob.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpnD);

            grfJob.AfterRowColChange += GrfJob_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //grfJob.CellChanged += GrfExpnD_CellChanged;
            panel4.Controls.Add(grfJob);

            theme1.SetTheme(grfJob, "Office2013Red");
        }
        private void setGrfJob()
        {
            grfJob.DataSource = null;
            grfJob.Rows.Count = 2;
            grfJob.Clear();
            if (cusId.Equals("")) return;
            grfJob.DataSource = xC.xtDB.jimDB.selectJimJblByJobYear2(cusId);

            grfJob.Cols.Count = 9;
            TextBox txt = new TextBox();

            grfJob.Cols[colCode].Editor = txt;
            grfJob.Cols[colDesc].Editor = txt;
            grfJob.Cols[colRemark].Editor = txt;
            grfJob.Cols[colAmt].Editor = txt;

            grfJob.Cols[colAmt].Width = 80;
            grfJob.Cols[colCode].Width = 60;
            grfJob.Cols[colDesc].Width = 200;
            grfJob.Cols[colRemark].Width = 100;

            grfJob.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";
            grfJob.Cols[colAmt].Caption = "ยอดเงิน";
            grfJob.Cols[colCode].Caption = "เลขที่ใบเบิก";
            grfJob.Cols[colDesc].Caption = "รายละเอียด";
            grfJob.Cols[colRemark].Caption = "หมายเหตุ";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 1; i < grfJob.Rows.Count; i++)
            {
                grfJob[i, 0] = i;
                if (i % 2 == 0)
                    grfJob.Rows[i].StyleNew.BackColor = color;
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfJob.Cols[colID].Visible = false;

        }
        private void initGrfBill()
        {
            grfBill = new C1FlexGrid();
            grfBill.Font = fEdit;
            grfBill.Dock = System.Windows.Forms.DockStyle.Fill;
            grfBill.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpnD);

            //grfBill.AfterRowColChange += GrfJob_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //grfJob.CellChanged += GrfExpnD_CellChanged;
            grfJob.DoubleClick += GrfJob_DoubleClick;
            panel6.Controls.Add(grfBill);

            theme1.SetTheme(grfBill, "VS2013Red");
        }

        private void GrfJob_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Customer cus = xC.sCus;
            JobImport jim = new JobImport();
            jim = xC.xtDB.jimDB.selectByPk1(grfJob[grfJob.Row, grfJob.Col].ToString());
            txtCusNameT.Value = cus.cust_name_t;
            txtJobCode.Value = jim.job_import_code;

        }

        private void GrfJob_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setKeyUpF2Cus()
        {
            Point pp = txtCusNameT.Location;
            pp.Y = pp.Y + 120 + 20;
            pp.X = pp.X - 20 + panel4.Left;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Customer, pp);
            frm.ShowDialog(this);
            setKeyUpF2Cus1(xC.sCus);
        }
        private void setKeyUpF2Cus1(Customer cus)
        {
            txtCusNameT1.Value = cus.cust_name_t;
            cusId = cus.cust_id;
        }
        private void TxtCusNameT1_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.F2)
            {
                if (sender.Equals(txtCusNameT1))
                {
                    //setKeyUpF2Cus();
                    setKeyUpF2Cus();
                    setGrfJob();
                }
            }
        }

        private void FrmBilling_Load(object sender, EventArgs e)
        {

        }
    }
}
