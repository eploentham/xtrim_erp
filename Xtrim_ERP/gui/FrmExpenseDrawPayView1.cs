using C1.Win.C1FlexGrid;
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
    public partial class FrmExpenseDrawPayView1 : Form
    {
        XtrimControl xC;
        ExpensesPay expnp;
        Company cop;
        Tax tax;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colDesc = 3, colRemark = 4, colAmt = 5, colStatus = 6, colFlagForm = 7, colStatusPay = 8;
        int colCID = 1, colCSubNameT = 2, colCMtp = 3, colCItmNameT = 4, colCDrawDate = 5, colCAmt = 6, colCBank=7, colCChequeNo=8, colChequeDate=9, colCChequepayname=10, colCpayID=11;
        int colBID = 1, colBNameT = 2, colBbranch=3, colBaccnumber=4, colBAmt = 5;
        int colPID = 1, colPNameT = 2, colPbranch = 3, colPaccnumber = 4, colPAmt = 5, colPchequeNo=6, colPchequeDate=7, colPchequePayName=8, colPstatuschequeaccPay=9;
        int colTID = 1, colTItemNameT = 2, colTtaxdate = 3, colTAmt = 4, colTtaxamt = 5, colTitemid = 6, colTbtaxid = 7, colTbtaxnamet = 8, colTftaxid=9;
        C1FlexGrid grfView, grfChequeView, grfChequePre, grfChequeMake, grfChequeBnk, grfTax, grfChequePrn, grfCashView, grfCashPre, grfCashMake, grfTaxView;
        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "";
        

        public FrmExpenseDrawPayView1(XtrimControl x)
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
            expnp = new ExpensesPay();
            tax = new Tax();
            DateTime jobDate = DateTime.Now;
            cop = new Company();
            cop = xC.xtDB.copDB.selectByCode1("001");
            txtDate.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");
            txtTaxDate.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");
            txtPayerTaxDate.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");

            sB1.Text = "";

            btnChequeAdd.Click += BtnChequeAdd_Click;
            btnChequeDel.Click += BtnChequeDel_Click;
            btnChequeOk.Click += BtnChequeOk_Click;
            btnCashAdd.Click += BtnCashAdd_Click;
            btnCashDel.Click += BtnCashDel_Click;
            btnCashOk.Click += BtnCashOk_Click;
            btnCashSave.Click += BtnCashSave_Click;
            btnTaxSave.Click += BtnTaxSave_Click;
            btnTaxPrn.Click += BtnTaxPrn_Click;

            chkViewFmtp.Click += ChkViewFmtp_Click;
            chkViewDraw.Click += ChkViewDraw_Click;
            chkAppvWait.Click += ChkAppvWait_Click;
            chkViewAll.Click += ChkViewAll_Click;
            chkAppvOk.Click += ChkAppvOk_Click;
            btnChequeSave.Click += BtnChequeSave_Click;
            tabCash.TabClick += TabCash_TabClick;
            txtCusTaxNameT.KeyUp += TxtCusTaxNameT_KeyUp;
            txtPayerTaxNameT.KeyUp += TxtCusTaxNameT_KeyUp;
            chkTax.Click += ChkTax_Click;
            chkItem.Click += ChkItem_Click;


            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
            chkViewDraw.Checked = true;
            chkItem.Checked = true;
            chkViewAll.Checked = true;

            xC.setCboYear(cboYear);
            initGrfView();
            setGrfView();
            initGrfChequeView();
            setGrfChequeView();
            initGrfChequePre();
            setGrfChequePre();
            initGrfChequeMake();
            setGrfChequeMake();
            initGrfChequeBnk();
            setGrfChequeBnk();
            initGrfChequePrn();
            initGrfCashView();
            setGrfCashView();
            initGrfCashPre();
            setGrfCashPre();
            initGrfCashMake();
            setGrfCashMake();
            initGrfTax();
            setGrfTax("");
            tC1.SelectedTab = tabCheque;
            tCCheque.SelectedTab = tabChequeView;
            theme1.SetTheme(tC1, "Office2010Black");
            theme1.SetTheme(tabCash1, "Office2010Blue");
            theme1.SetTheme(panel28, "Office2010Green");
            theme1.SetTheme(panel24, "Office2010Green");
            theme1.SetTheme(groupBox1, "Office2010Green");
            theme1.SetTheme(groupBox2, "Office2010Green");
            theme1.SetTheme(groupBox3, "Office2010Green");
            theme1.SetTheme(groupBox4, "Office2010Green");
            foreach (Control con in panel24.Controls)
            {
                theme1.SetTheme(con, "Office2010Green");
                if(con is GroupBox)
                {
                    foreach (Control con1 in con.Controls)
                    {
                        theme1.SetTheme(con1, "Office2010Green");
                        if (con1 is Panel)
                        {
                            foreach (Control con2 in con1.Controls)
                            {
                                theme1.SetTheme(con2, "Office2010Green");
                            }
                        }
                    }
                }
                else if (con is Panel)
                {
                    
                }
            }
            //foreach (Control con in groupBox1.Controls)
            //{
            //    theme1.SetTheme(con, "Office2010Green");
            //}
            //foreach (Control con in groupBox2.Controls)
            //{
            //    theme1.SetTheme(con, "Office2010Green");
            //}
            //foreach (Control con in groupBox3.Controls)
            //{
            //    theme1.SetTheme(con, "Office2010Green");
            //}
            //foreach (Control con in groupBox4.Controls)
            //{
            //    theme1.SetTheme(con, "Office2010Green");
            //}
            txtAmtReserve.Value = cop.amount_reserve;
        }
        
        private void ChkItem_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfTaxView.Hide();
            grfTax.Show();
        }

        private void ChkTax_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            showGrfTaxView();
        }

        private void TxtCusTaxNameT_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.F2)
            {
                if (sender.Equals(txtCusTaxNameT))
                {
                    //setKeyUpF2Cus();
                    setKeyUpF2Cus();
                    //setGrfJob(cusId);
                }
                else if (sender.Equals(txtPayerTaxNameT))
                {
                    setKeyUpF2Payer();
                }
            }
        }
        private void setKeyUpF2Cus()
        {
            Point pp = txtCusTaxNameT.Location;
            pp.Y = pp.Y + 120 + 20;
            pp.X = pp.X - 20 + panel4.Left;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Customer, pp);
            frm.ShowDialog(this);
            setKeyUpF2Cus1(xC.sCus);
        }
        private void setKeyUpF2Payer()
        {
            Point pp = txtCusTaxNameT.Location;
            pp.Y = pp.Y + 120 + 20;
            pp.X = pp.X - 20 + panel4.Left;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Customer, pp);
            frm.ShowDialog(this);
            setKeyUpF2Payer1(xC.sCus);
        }
        private void setKeyUpF2Cus1(Customer cus)
        {
            Company cop = new Company();
            cop = xC.xtDB.copDB.selectByCode1("001");
            txtCusTaxNameT.Value = cus.cust_name_t;
            txtCusTaxId.Value = cus.cust_id;
            txtAgentTaxId.Value = cop.comp_id;
            txtAgentTaxNameT.Value = cop.comp_name_t;
        }
        private void setKeyUpF2Payer1(Customer cus)
        {
            Address addr = new Address();
            addr = xC.xtDB.addrDB.selectStatusTaxByCusId1(cus.cust_id);
            txtPayerTaxId.Value = cus.cust_id;
            txtPayerTaxNameT.Value = cus.cust_name_t;
            txtPayerTaxAddr.Value = addr.line_t1;
            txtPayerTaxTele.Value = cus.tele;
            txtPayerTaxTaxid.Value = cus.tax_id;
        }
        private void TabCash_TabClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            tabCash1.SelectedTab = tabCashView;
        }
        
        private void initGrfView()
        {
            grfView = new C1FlexGrid();
            grfView.Font = fEdit;
            grfView.Dock = System.Windows.Forms.DockStyle.Fill;
            grfView.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfView);
            //grfView.AfterDataRefresh += GrfView_AfterDataRefresh;
            //grfExpn.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfDept_AfterRowColChange);
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);

            panel4.Controls.Add(grfView);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&จ่ายเงิน รายการเบิก", new EventHandler(ContextMenu_appv));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfView.ContextMenu = menuGw;

            theme1.SetTheme(grfView, "Office2013Red");
        }
        private void setGrfView()
        {
            //grfDept.Rows.Count = 7;
            DataTable dt = new DataTable();
            dt = xC.xtDB.expndDB.selectToPayAll1(cboYear.Text, chkAppvWait.Checked ? objdb.ExpensesDrawDB.StatusPay.waitappv : chkAppvOk.Checked ? objdb.ExpensesDrawDB.StatusPay.appv : objdb.ExpensesDrawDB.StatusPay.all, objdb.ExpensesDrawDB.StatusPayType.all);
            grfView.Cols.Count = dt.Columns.Count+1;
            grfView.Rows.Count = dt.Rows.Count + 2;
            TextBox txt = new TextBox();

            grfView.Cols[colCode].Editor = txt;
            grfView.Cols[colDesc].Editor = txt;
            grfView.Cols[colRemark].Editor = txt;

            grfView.Cols[colCode].Width = 100;
            grfView.Cols[colDesc].Width = 200;
            grfView.Cols[colRemark].Width = 200;
            grfView.Cols[colAmt].Width = 80;
            grfView.Cols[colStatus].Width = 80;
            grfView.Cols[colStatusPay].Width = 80;
            grfView.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfView.Cols[colCode].Caption = "เลขที่ใบเบิก";
            grfView.Cols[colDesc].Caption = "รายละเอียดใบเบิก";
            grfView.Cols[colRemark].Caption = "หมายเหตุ";
            grfView.Cols[colStatus].Caption = "สถานะ";
            grfView.Cols[colStatusPay].Caption = "การจ่าย";
            grfView.Cols[colFlagForm].Caption = "การเบิก";
            grfView.Cols[colAmt].Caption = "รวมเงิน";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfView[i+2, 0] = i+1;
                if (i % 2 == 0)
                    grfView.Rows[i].StyleNew.BackColor = color;
                grfView[i + 2, colID] = dt.Rows[i][xC.xtDB.expndDB.expnC.expenses_draw_id].ToString();
                grfView[i + 2, colCode] = dt.Rows[i][xC.xtDB.expndDB.expnC.expenses_draw_code].ToString();
                grfView[i + 2, colDesc] = dt.Rows[i][xC.xtDB.expndDB.expnC.desc1].ToString();
                grfView[i +2, colRemark] = dt.Rows[i][xC.xtDB.expndDB.expnC.remark].ToString();
                grfView[i + 2, colAmt] = dt.Rows[i][xC.xtDB.expndDB.expnC.amount].ToString();
                grfView[i + 2, colAmt] = dt.Rows[i][xC.xtDB.expndDB.expnC.amount].ToString();
                if (dt.Rows[i][xC.xtDB.expndDB.expnC.status_appv].ToString().Equals("2"))
                {
                    grfView[i + 2, colStatus] = "อนุมัติแล้ว";
                }
                else if (dt.Rows[i][xC.xtDB.expndDB.expnC.status_appv].ToString().Equals("1"))
                {
                    grfView[i + 2, colStatus] = "รออนุมัติ";
                }
                else
                {
                    grfView[i + 2, colStatusPay] = dt.Rows[i][xC.xtDB.expndDB.expnC.status_appv].ToString();
                }
                if (dt.Rows[i][xC.xtDB.expndDB.expnC.status_pay].ToString().Equals("2"))
                {
                    grfView[i + 2, colStatusPay] = "จ่ายแล้ว";
                }
                else if (dt.Rows[i][xC.xtDB.expndDB.expnC.status_pay].ToString().Equals("1"))
                {
                    grfView[i + 2, colStatusPay] = "รอจ่าย";
                }
                else
                {
                    grfView[i + 2, colStatusPay] = dt.Rows[i][xC.xtDB.expndDB.expnC.status_pay].ToString();
                }
                if (dt.Rows[i][xC.xtDB.expndDB.expnC.status_pay_type].ToString().Equals("1"))
                {
                    grfView[i + 2, colFlagForm] = "Cash";
                }
                else if (dt.Rows[i][xC.xtDB.expndDB.expnC.status_pay_type].ToString().Equals("2"))
                {
                    grfView[i + 2, colFlagForm] = "Cheque";
                }
                else
                {
                    grfView[i + 2, colFlagForm] = "-";
                }
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfView.Cols[colID].Visible = false;
        }
        private void setGrfViewFmtp()
        {
            //grfDept.Rows.Count = 7;
            //grfView.Tree = 
            DataTable dt = new DataTable();
            dt = xC.xtDB.expndDB.selectAllFmtp1(cboYear.Text, chkAppvWait.Checked ? objdb.ExpensesDrawDB.StatusPay.waitappv : chkAppvOk.Checked ? objdb.ExpensesDrawDB.StatusPay.appv : objdb.ExpensesDrawDB.StatusPay.all);
            //grfView.DataSource = ds.Tables[0];
            grfView.Rows.Count = 1;
            grfView.Cols.Count = 7;
            TextBox txt = new TextBox();

            grfView.Cols[colCode].Editor = txt;
            grfView.Cols[colDesc].Editor = txt;
            grfView.Cols[colRemark].Editor = txt;

            grfView.Cols[colCode].Width = 100;
            grfView.Cols[colDesc].Width = 200;
            grfView.Cols[colRemark].Width = 200;
            grfView.Cols[colAmt].Width = 80;
            grfView.Cols[colStatus].Width = 80;

            grfView.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfView.Cols[colCode].Caption = "เลขที่ใบเบิก";
            grfView.Cols[colDesc].Caption = "รายละเอียดใบเบิก";
            grfView.Cols[colRemark].Caption = "หมายเหตุ";
            grfView.Cols[colStatus].Caption = "สถานะ";
            grfView.Cols[colAmt].Caption = "รวมเงิน";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfView[i, 0] = i+1;
                Row row = grfView.Rows.Add();
                if (i % 2 == 0)
                    grfView.Rows[i].StyleNew.BackColor = color;
                row[1] = dt.Rows[i]["f_method_payment_name_t"].ToString();
                row[2] = dt.Rows[i]["item_type_sub_name_t"].ToString();
                row[3] = dt.Rows[i]["amt"].ToString();
                //row[1] = dt.Rows[i]["f_method_payment_name_t"].ToString();
            }
            updateDataTree();
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfView.Cols[colID].Visible = false;
        }
        void updateDataTree()
        {
            // sort the recordset when the user drags columns
            // this will cause a date refresh, removing all subtotals and
            // firing the AfterDataRefresh event, which rebuilds the subtotals.
            string strSort = grfView.Cols[1].Name + ", " + grfView.Cols[2].Name + ", " + grfView.Cols[3].Name;
            DataTable dt = grfView.DataSource as DataTable;
            if (dt != null)
                dt.DefaultView.Sort = strSort;
        }
        private void initGrfChequeView()
        {
            grfChequeView = new C1FlexGrid();
            grfChequeView.Font = fEdit;
            grfChequeView.Dock = System.Windows.Forms.DockStyle.Fill;
            grfChequeView.Location = new System.Drawing.Point(0, 0);
            //FilterRow fr = new FilterRow(grfView);            

            gbChequeView.Controls.Add(grfChequeView);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfChequeView.ContextMenu = menuGw;

            theme1.SetTheme(grfChequeView, "Office2013Red");

            //grfChequeView1 = new C1FlexGrid();
            //grfChequeView1.Font = fEdit;
            //grfChequeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            //grfChequeView1.Location = new System.Drawing.Point(0, 0);
            //gbChequeView.Controls.Add(grfChequeView1);
            //FilterRow fr = new FilterRow(grfView);

        }
        private void setGrfChequeView()
        {
            //grfDept.Rows.Count = 7;
            DataTable dt = new DataTable();
            dt = xC.xtDB.expnddDB.selectByChequeAppv("2");
            //grfChequeView1.DataSource = dt;
            grfChequeView.Cols.Count = dt.Columns.Count+1;
            grfChequeView.Rows.Count = dt.Rows.Count + 1;
            TextBox txt = new TextBox();

            grfChequeView.Cols[colCSubNameT].Editor = txt;
            grfChequeView.Cols[colCMtp].Editor = txt;
            grfChequeView.Cols[colCItmNameT].Editor = txt;

            grfChequeView.Cols[colCSubNameT].Width = 220;
            grfChequeView.Cols[colCMtp].Width = 80;
            grfChequeView.Cols[colCItmNameT].Width = 220;
            grfChequeView.Cols[colCDrawDate].Width = 100;
            grfChequeView.Cols[colCAmt].Width = 100;

            grfChequeView.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfChequeView.Cols[colCSubNameT].Caption = "ประเภทย่อย";
            grfChequeView.Cols[colCMtp].Caption = "วิธีการจ่าย";
            grfChequeView.Cols[colCItmNameT].Caption = "รายการ";
            grfChequeView.Cols[colCDrawDate].Caption = "วันที่";
            grfChequeView.Cols[colCAmt].Caption = "รวมเงิน";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < grfChequeView.Rows.Count-1; i++)
            {
                grfChequeView[i+1, 0] = i+1;
                if (i % 2 == 0)
                    grfChequeView.Rows[i + 1].StyleNew.BackColor = color;
                grfChequeView[i + 1, colCID] = dt.Rows[i][colCID-1].ToString();
                grfChequeView[i + 1, colCSubNameT] = dt.Rows[i][colCSubNameT - 1].ToString();
                grfChequeView[i + 1, colCMtp] = dt.Rows[i][colCMtp - 1].ToString();
                grfChequeView[i + 1, colCItmNameT] = dt.Rows[i][colCItmNameT - 1].ToString();
                grfChequeView[i + 1, colCAmt] = dt.Rows[i][colCAmt - 1].ToString();
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfChequeView.Cols[colCID].Visible = false;
        }
        private void initGrfChequePre()
        {
            grfChequePre = new C1FlexGrid();
            grfChequePre.Font = fEdit;
            grfChequePre.Dock = System.Windows.Forms.DockStyle.Fill;
            grfChequePre.Location = new System.Drawing.Point(0, 0);
            //FilterRow fr = new FilterRow(grfView);            

            gBChequeMake.Controls.Add(grfChequePre);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfChequePre.ContextMenu = menuGw;

            theme1.SetTheme(grfChequePre, "Office2013Red");
        }
        private void setGrfChequePre()
        {
            grfChequePre.Rows.Count = 1;
            //grfChequeMake.DataSource = xC.xtDB.expnddDB.selectByChequeAppv("2");
            grfChequePre.Cols.Count = 7;
            TextBox txt = new TextBox();

            grfChequePre.Cols[colCode].Editor = txt;
            grfChequePre.Cols[colDesc].Editor = txt;
            grfChequePre.Cols[colRemark].Editor = txt;

            grfChequePre.Cols[colCSubNameT].Width = 220;
            grfChequePre.Cols[colCMtp].Width = 80;
            grfChequePre.Cols[colCItmNameT].Width = 220;
            grfChequePre.Cols[colCDrawDate].Width = 100;
            grfChequePre.Cols[colCAmt].Width = 100;

            grfChequePre.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfChequePre.Cols[colCSubNameT].Caption = "ประเภทย่อย";
            grfChequePre.Cols[colCMtp].Caption = "วิธีการจ่าย";
            grfChequePre.Cols[colCItmNameT].Caption = "รายการ";
            grfChequePre.Cols[colCDrawDate].Caption = "วันที่";
            grfChequePre.Cols[colCAmt].Caption = "ยอดเงิน";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 1; i < grfChequePre.Rows.Count; i++)
            {
                grfChequePre[i, 0] = i;
                if (i % 2 == 0)
                    grfChequePre.Rows[i].StyleNew.BackColor = color;
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfChequePre.Cols[colCID].Visible = false;
        }
        private void initGrfChequeMake()
        {
            grfChequeMake = new C1FlexGrid();
            grfChequeMake.Font = fEdit;
            grfChequeMake.Dock = System.Windows.Forms.DockStyle.Fill;
            grfChequeMake.Location = new System.Drawing.Point(0, 0);
            //FilterRow fr = new FilterRow(grfView);            

            panel13.Controls.Add(grfChequeMake);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfChequeMake.ContextMenu = menuGw;

            theme1.SetTheme(grfChequeMake, "Office2013Red");
        }
        private void setGrfChequeMake()
        {
            grfChequeMake.Rows.Count = 1;
            //grfChequeMake.DataSource = xC.xtDB.expnddDB.selectByChequeAppv("2");
            grfChequeMake.Cols.Count = 12;
            TextBox txt = new TextBox();
            C1ComboBox cbo = new C1ComboBox();
            xC.xtDB.copbDB.setC1CboItem(cbo);
            //C1DateEdit dtpDate = new C1DateEdit();
            txtDate.Value = DateTime.Now;
            //dtpDate.EditFormat = FormatInfo. 

            grfChequeMake.Cols[colCSubNameT].Editor = txt;
            grfChequeMake.Cols[colCMtp].Editor = txt;
            grfChequeMake.Cols[colCItmNameT].Editor = txt;
            grfChequeMake.Cols[colCDrawDate].Editor = txt;
            grfChequeMake.Cols[colCAmt].Editor = txt;
            grfChequeMake.Cols[colCChequeNo].Editor = txt;
            grfChequeMake.Cols[colCChequepayname].Editor = txt;
            grfChequeMake.Cols[colCBank].Editor = cbo;
            grfChequeMake.Cols[colChequeDate].Editor = txtDate;

            grfChequeMake.Cols[colCSubNameT].Width = 220;
            grfChequeMake.Cols[colCMtp].Width = 80;
            grfChequeMake.Cols[colCItmNameT].Width = 220;
            grfChequeMake.Cols[colCDrawDate].Width = 100;
            grfChequeMake.Cols[colCAmt].Width = 100;
            grfChequeMake.Cols[colCChequeNo].Width = 100;
            grfChequeMake.Cols[colCChequepayname].Width = 200;
            grfChequeMake.Cols[colCBank].Width = 140;
            grfChequeMake.Cols[colChequeDate].Width = 100;

            grfChequeMake.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfChequeMake.Cols[colCSubNameT].Caption = "ประเภทย่อย";
            grfChequeMake.Cols[colCMtp].Caption = "วิธีการจ่าย";
            grfChequeMake.Cols[colCItmNameT].Caption = "รายการ";
            grfChequeMake.Cols[colCDrawDate].Caption = "วันที่";
            grfChequeMake.Cols[colCAmt].Caption = "ยอดเงิน";
            grfChequeMake.Cols[colCBank].Caption = "ธนาคาร";
            grfChequeMake.Cols[colCChequeNo].Caption = "เช๊คเลขที่";
            grfChequeMake.Cols[colChequeDate].Caption = "เช็ควันที่";
            grfChequeMake.Cols[colCChequepayname].Caption = "ชื่อผู้รับเงิน";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 1; i < grfChequeMake.Rows.Count; i++)
            {
                grfChequeMake[i, 0] = i;
                if (i % 2 == 0)
                    grfChequeMake.Rows[i].StyleNew.BackColor = color;
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfChequeMake.Cols[colCID].Visible = false;
            grfChequeMake.Cols[colCpayID].Visible = false;
        }
        private void initGrfChequeBnk()
        {
            grfChequeBnk = new C1FlexGrid();
            grfChequeBnk.Font = fEdit;
            grfChequeBnk.Dock = System.Windows.Forms.DockStyle.Fill;
            grfChequeBnk.Location = new System.Drawing.Point(0, 0);
            //FilterRow fr = new FilterRow(grfView);            

            panel14.Controls.Add(grfChequeBnk);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfChequeBnk.ContextMenu = menuGw;

            theme1.SetTheme(grfChequeBnk, "Office2013LightGray");
        }
        
        private void setGrfChequeBnk()
        {
            Company cop = new Company();
            cop = xC.xtDB.copDB.selectByCode1("001");
            DataTable dt = new DataTable();
            dt = xC.xtDB.copbDB.selectBankByCop(cop.comp_id);

            grfChequeBnk.Cols.Count = 6;
            grfChequeBnk.Rows.Count = dt.Rows.Count + 2;
            //grfChequeBnk.Cols.Count = 7;
            TextBox txt = new TextBox();

            grfChequeBnk.Cols[colBID].Editor = txt;
            grfChequeBnk.Cols[colBNameT].Editor = txt;
            grfChequeBnk.Cols[colBAmt].Editor = txt;
            grfChequeBnk.Cols[colBbranch].Editor = txt;
            grfChequeBnk.Cols[colBaccnumber].Editor = txt;

            grfChequeBnk.Cols[colBNameT].Width = 220;
            grfChequeBnk.Cols[colBAmt].Width = 80;
            grfChequeBnk.Cols[colBbranch].Width = 150;
            grfChequeBnk.Cols[colBaccnumber].Width = 100;

            grfChequeBnk.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfChequeBnk.Cols[colBNameT].Caption = "ธนาคาร";
            grfChequeBnk.Cols[colBAmt].Caption = "จำนวนเงิน";
            grfChequeBnk.Cols[colBbranch].Caption = "สาขา";
            grfChequeBnk.Cols[colBaccnumber].Caption = "เลขที่บัญชี";

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                grfChequeBnk[i + 1, colBID] = dt.Rows[i][xC.xtDB.copbDB.copB.comp_bank_id].ToString();
                grfChequeBnk[i + 1, colBNameT] = dt.Rows[i][xC.xtDB.copbDB.copB.comp_bank_name_t].ToString();
                grfChequeBnk[i + 1, colBbranch] = dt.Rows[i][xC.xtDB.copbDB.copB.comp_bank_branch].ToString();
                grfChequeBnk[i + 1, colBaccnumber] = dt.Rows[i][xC.xtDB.copbDB.copB.acc_number].ToString();
                grfChequeBnk[i + 1, colBAmt] = "0.00";
            }
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 1; i < grfChequeBnk.Rows.Count; i++)
            {
                grfChequeBnk[i, 0] = i;
                if (i % 2 == 0)
                    grfChequeBnk.Rows[i].StyleNew.BackColor = color;
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfChequeBnk.Cols[colBID].Visible = false;
        }
        
        private void initGrfChequePrn()
        {
            grfChequePrn = new C1FlexGrid();
            grfChequePrn.Font = fEdit;
            grfChequePrn.Dock = System.Windows.Forms.DockStyle.Fill;
            grfChequePrn.Location = new System.Drawing.Point(0, 0);
            //FilterRow fr = new FilterRow(grfView);            

            panel8.Controls.Add(grfChequePrn);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&พิมพ์ Cheque", new EventHandler(ContextMenu_grfChequePrn_Print));
            grfChequePrn.ContextMenu = menuGw;

            theme1.SetTheme(grfChequePrn, "Office2016Colorful");
        }
        private void initGrfCashView()
        {
            grfCashView = new C1FlexGrid();
            grfCashView.Font = fEdit;
            grfCashView.Dock = System.Windows.Forms.DockStyle.Fill;
            grfCashView.Location = new System.Drawing.Point(0, 0);
            //FilterRow fr = new FilterRow(grfView);            

            gbCashView.Controls.Add(grfCashView);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfCashView.ContextMenu = menuGw;

            theme1.SetTheme(grfCashView, "Office2010Green");

            //grfChequeView1 = new C1FlexGrid();
            //grfChequeView1.Font = fEdit;
            //grfChequeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            //grfChequeView1.Location = new System.Drawing.Point(0, 0);
            //gbChequeView.Controls.Add(grfChequeView1);
            //FilterRow fr = new FilterRow(grfView);

        }
        private void setGrfCashView()
        {
            //grfDept.Rows.Count = 7;
            DataTable dt = new DataTable();
            dt = xC.xtDB.expnddDB.selectByCashAppv("2");
            //grfChequeView1.DataSource = dt;
            grfCashView.Cols.Count = dt.Columns.Count + 1;
            grfCashView.Rows.Count = dt.Rows.Count + 1;
            TextBox txt = new TextBox();

            grfCashView.Cols[colCode].Editor = txt;
            grfCashView.Cols[colDesc].Editor = txt;
            grfCashView.Cols[colRemark].Editor = txt;

            grfCashView.Cols[colCSubNameT].Width = 220;
            grfCashView.Cols[colCMtp].Width = 80;
            grfCashView.Cols[colCItmNameT].Width = 220;
            grfCashView.Cols[colCDrawDate].Width = 100;
            grfCashView.Cols[colCAmt].Width = 100;

            grfCashView.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfCashView.Cols[colCSubNameT].Caption = "ประเภทย่อย";
            grfCashView.Cols[colCMtp].Caption = "วิธีการจ่าย";
            grfCashView.Cols[colCItmNameT].Caption = "รายการ";
            grfCashView.Cols[colCDrawDate].Caption = "วันที่";
            grfCashView.Cols[colCAmt].Caption = "รวมเงิน";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfCashView[i + 1, 0] = i+1;
                if (i % 2 == 0)
                    grfCashView.Rows[i + 1].StyleNew.BackColor = color;
                grfCashView[i + 1, colCID] = dt.Rows[i][colCID - 1].ToString();
                grfCashView[i + 1, colCSubNameT] = dt.Rows[i][colCSubNameT - 1].ToString();
                grfCashView[i + 1, colCMtp] = dt.Rows[i][colCMtp - 1].ToString();
                grfCashView[i + 1, colCItmNameT] = dt.Rows[i][colCItmNameT - 1].ToString();
                grfCashView[i + 1, colCAmt] = dt.Rows[i][colCAmt - 1].ToString();
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfCashView.Cols[colCID].Visible = false;
        }
        private void initGrfCashPre()
        {
            grfCashPre = new C1FlexGrid();
            grfCashPre.Font = fEdit;
            grfCashPre.Dock = System.Windows.Forms.DockStyle.Fill;
            grfCashPre.Location = new System.Drawing.Point(0, 0);
            //FilterRow fr = new FilterRow(grfView);            

            gbCashPre.Controls.Add(grfCashPre);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfCashPre.ContextMenu = menuGw;

            theme1.SetTheme(grfCashPre, "Office2010Barbie");
        }
        private void setGrfCashPre()
        {
            grfCashPre.Rows.Count = 1;
            //grfChequeMake.DataSource = xC.xtDB.expnddDB.selectByChequeAppv("2");
            grfCashPre.Cols.Count = 7;
            TextBox txt = new TextBox();

            grfCashPre.Cols[colCode].Editor = txt;
            grfCashPre.Cols[colDesc].Editor = txt;
            grfCashPre.Cols[colRemark].Editor = txt;

            grfCashPre.Cols[colCSubNameT].Width = 220;
            grfCashPre.Cols[colCMtp].Width = 80;
            grfCashPre.Cols[colCItmNameT].Width = 220;
            grfCashPre.Cols[colCDrawDate].Width = 100;
            grfCashPre.Cols[colCAmt].Width = 100;

            grfCashPre.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfCashPre.Cols[colCSubNameT].Caption = "ประเภทย่อย";
            grfCashPre.Cols[colCMtp].Caption = "วิธีการจ่าย";
            grfCashPre.Cols[colCItmNameT].Caption = "รายการ";
            grfCashPre.Cols[colCDrawDate].Caption = "วันที่";
            grfCashPre.Cols[colCAmt].Caption = "ยอดเงิน";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 1; i < grfCashPre.Rows.Count; i++)
            {
                grfCashPre[i, 0] = i;
                if (i % 2 == 0)
                    grfCashPre.Rows[i].StyleNew.BackColor = color;
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfCashPre.Cols[colCID].Visible = false;
        }
        private void initGrfCashMake()
        {
            grfCashMake = new C1FlexGrid();
            grfCashMake.Font = fEdit;
            grfCashMake.Dock = System.Windows.Forms.DockStyle.Fill;
            grfCashMake.Location = new System.Drawing.Point(0, 0);
            //FilterRow fr = new FilterRow(grfView);            

            panel23.Controls.Add(grfCashMake);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfCashMake.ContextMenu = menuGw;

            theme1.SetTheme(grfCashMake, "Office2010Red");
        }
        private void setGrfCashMake()
        {
            grfCashMake.Rows.Count = 1;
            //grfChequeMake.DataSource = xC.xtDB.expnddDB.selectByChequeAppv("2");
            grfCashMake.Cols.Count = 12;
            TextBox txt = new TextBox();
            C1ComboBox cbo = new C1ComboBox();
            xC.xtDB.copbDB.setC1CboItem(cbo);
            //C1DateEdit dtpDate = new C1DateEdit();
            txtDate.Value = DateTime.Now;
            //dtpDate.EditFormat = FormatInfo. 

            grfCashMake.Cols[colCSubNameT].Editor = txt;
            grfCashMake.Cols[colCMtp].Editor = txt;
            grfCashMake.Cols[colCItmNameT].Editor = txt;
            grfCashMake.Cols[colCDrawDate].Editor = txt;
            grfCashMake.Cols[colCAmt].Editor = txt;
            grfCashMake.Cols[colCChequeNo].Editor = txt;
            grfCashMake.Cols[colCChequepayname].Editor = txt;
            grfCashMake.Cols[colCBank].Editor = cbo;
            grfCashMake.Cols[colChequeDate].Editor = txtDate;

            grfCashMake.Cols[colCSubNameT].Width = 220;
            grfCashMake.Cols[colCMtp].Width = 80;
            grfCashMake.Cols[colCItmNameT].Width = 220;
            grfCashMake.Cols[colCDrawDate].Width = 100;
            grfCashMake.Cols[colCAmt].Width = 100;
            grfCashMake.Cols[colCChequeNo].Width = 100;
            grfCashMake.Cols[colCChequepayname].Width = 200;
            grfCashMake.Cols[colCBank].Width = 140;
            grfCashMake.Cols[colChequeDate].Width = 100;

            grfCashMake.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfCashMake.Cols[colCSubNameT].Caption = "ประเภทย่อย";
            grfCashMake.Cols[colCMtp].Caption = "วิธีการจ่าย";
            grfCashMake.Cols[colCItmNameT].Caption = "รายการ";
            grfCashMake.Cols[colCDrawDate].Caption = "วันที่";
            grfCashMake.Cols[colCAmt].Caption = "ยอดเงิน";
            grfCashMake.Cols[colCBank].Caption = "ธนาคาร";
            grfCashMake.Cols[colCChequeNo].Caption = "เช๊คเลขที่";
            grfCashMake.Cols[colChequeDate].Caption = "เช็ควันที่";
            grfCashMake.Cols[colCChequepayname].Caption = "ชื่อผู้รับเงิน";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 1; i < grfCashMake.Rows.Count; i++)
            {
                grfCashMake[i, 0] = i;
                if (i % 2 == 0)
                    grfCashMake.Rows[i].StyleNew.BackColor = color;
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfCashMake.Cols[colCID].Visible = false;
            grfCashMake.Cols[colCpayID].Visible = false;
        }
        private void initGrfTax()
        {
            grfTax = new C1FlexGrid();
            grfTax.Font = fEdit;
            grfTax.Dock = System.Windows.Forms.DockStyle.Fill;
            grfTax.Location = new System.Drawing.Point(0, 0);

            grfTaxView = new C1FlexGrid();
            grfTaxView.Font = fEdit;
            grfTaxView.Dock = System.Windows.Forms.DockStyle.Fill;
            grfTax.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfView);            
            //grfTax.LeaveCell += GrfTax_LeaveCell;
            grfTax.AfterEdit += GrfTax_AfterEdit;
            panel28.Controls.Add(grfTax);
            panel28.Controls.Add(grfTaxView);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfTax.ContextMenu = menuGw;
            grfTaxView.Hide();

            theme1.SetTheme(grfTax, "Office2010Green");
        }

        private void GrfTax_AfterEdit(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Col == colTAmt)
            {
                Decimal amt = 0, amttax = 0,rate=3;
                if (Decimal.TryParse(grfTax[e.Row, e.Col] != null ? grfTax[e.Row, e.Col].ToString() : "0", out amt))
                {
                    String item = "", bname="";
                    item = grfTax[e.Row, colTItemNameT].ToString();
                    Items itm = new Items();
                    BTax btax = new BTax();
                    itm = xC.xtDB.itmDB.selectByNameT1(item);
                    if (!itm.tax_id.Equals(""))
                    {
                        btax = xC.xtDB.btaxDB.selectByPk1(itm.tax_id);
                        bname = btax.b_tax_name_t;
                        if (!Decimal.TryParse(btax.rate1, out rate))
                        {
                            MessageBox.Show("ไม่พบ อัตราภาษี", "Error");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบ ข้อมูลภาษี", "Error");
                        if (itm.tax_id.Equals("")) return;
                    }

                    grfTax[e.Row, colTtaxamt] = (amt * (rate / 100));
                    grfTax[e.Row, colTbtaxid] = itm.tax_id;
                    grfTax[e.Row, colTbtaxnamet] = bname;
                    if (grfTax.Rows.Count == e.Row + 1)
                    {
                        if (grfTax[e.Row, colTItemNameT] != null) grfTax.Rows.Add();
                    }
                }
            }
        }

        private void GrfTax_LeaveCell(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if(grfTax.Col == colTAmt)
            //{
            //    Decimal amt = 0, amttax = 0;
            //    if (Decimal.TryParse(grfTax[grfTax.Row, grfTax.Col] != null ?  grfTax[grfTax.Row, grfTax.Col].ToString() : "0", out amt))
            //    {
            //        grfTax[grfTax.Row, colTtaxamt] = (amt * (3/100));
            //        if (grfTax.Rows.Count == grfTax.Row)
            //        {
            //            grfTax.Rows.Add();
            //        }
            //    }
            //}
        }

        private void setGrfTax(String expnpdid)
        {
            Company cop = new Company();
            cop = xC.xtDB.copDB.selectByCode1("001");
            DataTable dt = new DataTable();
            dt = xC.xtDB.expnpdDB.selectPrintCheque(expnpdid);
            grfTax.Clear();
            grfTax.Cols.Count = 10;
            if (dt.Rows.Count > 0)
            {
                grfTax.Rows.Count = dt.Rows.Count + 1;
            }
            else
            {
                grfTax.Rows.Count = 2;
            }
            //grfChequeBnk.Cols.Count = 7;
            CellStyle cs = grfTax.Styles.Add("date");
            cs.DataType = typeof(DateTime);
            cs.Format = "dd-MM-yyyy";

            C1TextBox txt = new C1TextBox();
            txt.DataType = txtCusTaxNameT.DataType;
            C1TextBox txt1 = new C1TextBox();
            txt1.DataType = txtAmt.DataType;
            C1ComboBox cbo = new C1ComboBox();
            xC.xtDB.itmDB.setC1CboItem(cbo);
            C1TextBox txt2 = new C1TextBox();
            txt2.DataType = txtTaxDate.DataType;

            grfTax.Cols[colTItemNameT].Editor = cbo;
            grfTax.Cols[colTtaxdate].Style = cs;
            grfTax.Cols[colTAmt].Editor = txt1;
            grfTax.Cols[colTtaxamt].Editor = txt1;

            grfTax.Cols[colTItemNameT].Width = 240;
            grfTax.Cols[colTtaxdate].Width = 100;
            grfTax.Cols[colTAmt].Width = 100;
            grfTax.Cols[colTtaxamt].Width = 100;

            grfTax.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfTax.Cols[colTItemNameT].Caption = "รายการ";
            grfTax.Cols[colTtaxdate].Caption = "วันที่จ่ายเงิน";
            grfTax.Cols[colTAmt].Caption = "ยอดเงินที่จ่าย";
            grfTax.Cols[colTtaxamt].Caption = "ภาษีหัก ณ ที่จ่าย";
            

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfTax[i + 1, colTItemNameT] = dt.Rows[i][xC.xtDB.expnpdDB.expnP.pay_to_cus_name_t].ToString();
                grfTax[i + 1, colTtaxdate] = dt.Rows[i][xC.xtDB.expnpdDB.expnP.pay_bank_date].ToString();
                grfTax[i + 1, colTAmt] = dt.Rows[i][xC.xtDB.copbDB.copB.comp_bank_name_t].ToString();
                grfTax[i + 1, colTtaxamt] = dt.Rows[i][xC.xtDB.copbDB.copB.comp_bank_branch].ToString();
                grfTax[i + 1, colTID] = dt.Rows[i][xC.xtDB.copbDB.copB.acc_number].ToString();
                grfTax[i + 1, colTitemid] = dt.Rows[i][xC.xtDB.expnpdDB.expnP.pay_amount].ToString();
                grfTax[i + 1, colTbtaxid] = dt.Rows[i][xC.xtDB.expnpdDB.expnP.pay_amount].ToString();
            }
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 1; i < grfTax.Rows.Count; i++)
            {
                grfTax[i, 0] = i;
                if (i % 2 == 0)
                    grfTax.Rows[i].StyleNew.BackColor = color;
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfTax.Cols[colTID].Visible = false;
            grfTax.Cols[colTitemid].Visible = false;
            grfTax.Cols[colTbtaxid].Visible = false;
            grfTax.Cols[colTftaxid].Visible = false;
        }
        private void setGrfTaxView()
        {
            CellStyle cs = grfTaxView.Styles.Add("date");
            cs.DataType = typeof(DateTime);
            cs.Format = "dd-MM-yyyy";

            C1TextBox txt = new C1TextBox();
            txt.DataType = txtCusTaxNameT.DataType;
            C1TextBox txt1 = new C1TextBox();
            txt1.DataType = txtAmt.DataType;
            C1ComboBox cbo = new C1ComboBox();
            xC.xtDB.itmDB.setC1CboItem(cbo);
            C1TextBox txt2 = new C1TextBox();
            txt2.DataType = txtTaxDate.DataType;
            grfTaxView.Cols.Count = 10;
            grfTaxView.Rows.Count = 1;

            grfTaxView.Cols[colTItemNameT].Editor = txt;
            grfTaxView.Cols[colTtaxdate].Editor = txt;
            grfTaxView.Cols[colTAmt].Editor = txt;
            grfTaxView.Cols[colTtaxamt].Editor = txt;

            grfTaxView.Cols[colTItemNameT].Width = 240;
            grfTaxView.Cols[colTtaxdate].Width = 100;
            grfTaxView.Cols[colTAmt].Width = 100;
            grfTaxView.Cols[colTtaxamt].Width = 100;

            grfTaxView.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfTaxView.Cols[colTItemNameT].Caption = "รายการ";
            grfTaxView.Cols[colTtaxdate].Caption = "วันที่จ่ายเงิน";
            grfTaxView.Cols[colTAmt].Caption = "ยอดเงินที่จ่าย";
            grfTaxView.Cols[colTtaxamt].Caption = "ภาษีหัก ณ ที่จ่าย";
            grfTaxView.Cols[colTID].Visible = false;
            grfTaxView.Cols[colTitemid].Visible = false;
            grfTaxView.Cols[colTbtaxid].Visible = false;
            grfTaxView.Cols[colTbtaxnamet].Visible = false;
            grfTaxView.Cols[colTftaxid].Visible = false;
        }
        private void ContextMenu_grfChequePrn_Print(object sender, System.EventArgs e)
        {
            String chk = "", name="", no="";
            chk = grfChequePrn[grfChequePrn.Row, colPID] != null ? grfChequePrn[grfChequePrn.Row, colPID].ToString() : "";
            name = grfChequePrn[grfChequePrn.Row, colPNameT] != null ? grfChequePrn[grfChequePrn.Row, colPNameT].ToString() : "";
            no = grfChequePrn[grfChequePrn.Row, colPchequeNo] != null ? grfChequePrn[grfChequePrn.Row, colPchequeNo].ToString() : "";
            if (MessageBox.Show("ต้องการ พิมพ์ Cheque   \n  รายการ " + chk+" "+ name+" "+ no, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                //grfExpnD.Rows.Remove(grfExpnD.Row);
            }
        }
        private void setGrfChequePrn(String expnpdid)
        {
            Company cop = new Company();
            cop = xC.xtDB.copDB.selectByCode1("001");
            DataTable dt = new DataTable();
            dt = xC.xtDB.expnpdDB.selectPrintCheque(expnpdid);

            grfChequePrn.Cols.Count = 11;
            grfChequePrn.Rows.Count = dt.Rows.Count + 2;
            //grfChequeBnk.Cols.Count = 7;
            TextBox txt = new TextBox();

            grfChequePrn.Cols[colPID].Editor = txt;
            grfChequePrn.Cols[colPNameT].Editor = txt;
            grfChequePrn.Cols[colPbranch].Editor = txt;
            grfChequePrn.Cols[colPaccnumber].Editor = txt;
            grfChequePrn.Cols[colPAmt].Editor = txt;
            grfChequePrn.Cols[colPchequeNo].Editor = txt;
            grfChequePrn.Cols[colPchequeDate].Editor = txt;
            grfChequePrn.Cols[colPchequePayName].Editor = txt;
            grfChequePrn.Cols[colPstatuschequeaccPay].Editor = txt;
            //grfChequePrn.Cols[colBaccnumber].Editor = txt;

            grfChequePrn.Cols[colPNameT].Width = 220;
            grfChequePrn.Cols[colPbranch].Width = 80;
            grfChequePrn.Cols[colPaccnumber].Width = 150;
            grfChequePrn.Cols[colPAmt].Width = 100;
            grfChequePrn.Cols[colPchequeNo].Width = 100;
            grfChequePrn.Cols[colPchequeDate].Width = 100;
            grfChequePrn.Cols[colPchequePayName].Width = 100;
            grfChequePrn.Cols[colPstatuschequeaccPay].Width = 100;
            //grfChequePrn.Cols[colBaccnumber].Width = 100;

            grfChequePrn.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfChequePrn.Cols[colPNameT].Caption = "ธนาคาร";
            grfChequePrn.Cols[colPbranch].Caption = "สาขา";
            grfChequePrn.Cols[colPaccnumber].Caption = "เลขที่บัญชี";
            grfChequePrn.Cols[colPAmt].Caption = "จำนวนเงิน";
            grfChequePrn.Cols[colPchequeNo].Caption = "เลขที่cheque";
            grfChequePrn.Cols[colPchequeDate].Caption = "วันที่ในcheque";
            grfChequePrn.Cols[colPchequePayName].Caption = "ชื่อผู้รับเงิน";
            grfChequePrn.Cols[colPstatuschequeaccPay].Caption = "acc only";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfChequePrn[i + 1, colPchequePayName] = dt.Rows[i][xC.xtDB.expnpdDB.expnP.pay_to_cus_name_t].ToString();
                grfChequePrn[i + 1, colPchequeDate] = dt.Rows[i][xC.xtDB.expnpdDB.expnP.pay_bank_date].ToString();
                grfChequePrn[i + 1, colPNameT] = dt.Rows[i][xC.xtDB.copbDB.copB.comp_bank_name_t].ToString();
                grfChequePrn[i + 1, colPbranch] = dt.Rows[i][xC.xtDB.copbDB.copB.comp_bank_branch].ToString();
                grfChequePrn[i + 1, colPaccnumber] = dt.Rows[i][xC.xtDB.copbDB.copB.acc_number].ToString();
                grfChequePrn[i + 1, colPAmt] = dt.Rows[i][xC.xtDB.expnpdDB.expnP.pay_amount].ToString();
            }
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 1; i < grfChequePrn.Rows.Count; i++)
            {
                grfChequePrn[i, 0] = i;
                if (i % 2 == 0)
                    grfChequePrn.Rows[i].StyleNew.BackColor = color;
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfChequePrn.Cols[colPID].Visible = false;
        }
        private void showGrfTaxView()
        {
            grfTaxView.Clear();
            setGrfTaxView();
            foreach(Row row in grfTax.Rows)
            {
                String btaxid = "";
                Boolean chk = false;
                btaxid = row[colTbtaxid] != null ? row[colTbtaxid].ToString() : "";
                if (btaxid.Equals("")) continue;
                foreach (Row rowT in grfTaxView.Rows)
                {
                    String btaxidT = "";
                    btaxidT = rowT[colTbtaxid] != null ? rowT[colTbtaxid].ToString() : "";
                    if (btaxid.Equals(btaxidT))
                    {
                        chk = true;
                    }
                }
                if (!chk)
                {
                    BTax btax = new BTax();
                    btax = xC.xtDB.btaxDB.selectByPk1(btaxid);
                    Row rowA = grfTaxView.Rows.Add();
                    rowA[colTItemNameT] = btax.b_tax_name_t;
                    rowA[colTtaxdate] = row[colTtaxdate];
                    rowA[colTbtaxid] = row[colTbtaxid];
                    rowA[colTftaxid] = btax.f_tax_type_id;
                }
            }
            foreach (Row rowT in grfTaxView.Rows)
            {
                String btaxidT = "";
                Boolean chk = false;
                btaxidT = rowT[colTbtaxid] != null ? rowT[colTbtaxid].ToString() : "";
                if (btaxidT.Equals("")) continue;
                Decimal amt = 0, tax=0;
                foreach (Row row in grfTax.Rows)
                {
                    String btaxid = "";
                    Decimal amt1 = 0, tax1=0;
                    btaxid = row[colTbtaxid] != null ? row[colTbtaxid].ToString() : "";
                    if (btaxid.Equals(btaxidT))
                    {
                        rowT[colTtaxdate] = row[colTtaxdate];
                        if (Decimal.TryParse(row[colTAmt] != null ? row[colTAmt].ToString() : "0", out amt1))
                        {
                            amt += amt1;
                        }
                        if (Decimal.TryParse(row[colTtaxamt] != null ? row[colTtaxamt].ToString() : "0", out tax1))
                        {
                            tax += tax1;
                        }
                    }
                }
                rowT[colTAmt] = amt;
                rowT[colTtaxamt] = tax;
            }
            grfTaxView.Show();
            grfTax.Hide();
        }
        private void BtnCashAdd_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            int row = grfCashView.Row;
            if (row < 1) return;
            //int row = grfChequePre.Rows.Count++;
            //Row rr = grfChequeView.Rows[grfChequeView.Row];
            Row rrr = grfCashPre.Rows.Add();
            rrr[colCID] = grfCashView[row, colCID].ToString();
            rrr[colCSubNameT] = grfCashView[row, colCSubNameT].ToString();
            rrr[colCMtp] = grfCashView[row, colCMtp].ToString();
            rrr[colCItmNameT] = grfCashView[row, colCItmNameT].ToString();
            rrr[colCAmt] = grfCashView[row, colCAmt].ToString();

            grfCashView.Rows.Remove(grfCashView.Row);
        }
        private void BtnCashDel_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            int row = 0;
            row = grfCashPre.Row;
            Row rrr = grfCashView.Rows.Add();
            rrr[colCID] = grfCashPre[row, colCID].ToString();
            rrr[colCSubNameT] = grfCashPre[row, colCSubNameT].ToString();
            rrr[colCMtp] = grfCashPre[row, colCMtp].ToString();
            rrr[colCItmNameT] = grfCashPre[row, colCItmNameT].ToString();
            rrr[colCAmt] = grfCashPre[row, colCAmt].ToString();

            grfCashPre.Rows.Remove(row);
        }
        private void BtnCashOk_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            
            Decimal draw = 0, reserve=0;
            cop = xC.xtDB.copDB.selectByCode1("001");
            Decimal.TryParse(cop.amount_reserve, out reserve);
            txtAmtReserve.Value = reserve;
            tabCash1.SelectedTab = tabCashMake;
            grfCashMake.Rows.Count = grfCashPre.Rows.Count;
            for (int row = 1; row < grfCashPre.Rows.Count; row++)
            {
                String id = "";
                id = grfCashPre[row, colCID] != null ? grfCashPre[row, colCID].ToString() : "";
                ExpensesDrawDatail dd = new ExpensesDrawDatail();
                dd = xC.xtDB.expnddDB.selectByPk1(id);
                grfCashMake[row, 0] = row;
                grfCashMake[row, colCID] = id;
                grfCashMake[row, colCSubNameT] = grfCashPre[row, colCSubNameT];
                grfCashMake[row, colCMtp] = grfCashPre[row, colCMtp];
                grfCashMake[row, colCItmNameT] = grfCashPre[row, colCItmNameT];
                grfCashMake[row, colCDrawDate] = grfCashPre[row, colCDrawDate];
                grfCashMake[row, colCAmt] = grfCashPre[row, colCAmt];
                grfCashMake[row, colCChequepayname] = dd.pay_to_cus_name_t;
                Decimal amt = 0;
                Decimal.TryParse(grfCashPre[row, colCAmt].ToString(), out amt);
                draw += amt;
            }
            txtDraw.Value = draw;
            txtOnhand.Value = reserve - draw;
        }
        private void BtnChequeAdd_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            int row = grfChequeView.Row;
            if (row < 1) return;
            //int row = grfChequePre.Rows.Count++;
            //Row rr = grfChequeView.Rows[grfChequeView.Row];
            Row rrr = grfChequePre.Rows.Add();
            rrr[colCID] = grfChequeView[row, colCID].ToString();
            rrr[colCSubNameT] = grfChequeView[row, colCSubNameT].ToString();
            rrr[colCMtp] = grfChequeView[row, colCMtp].ToString();
            rrr[colCItmNameT] = grfChequeView[row, colCItmNameT].ToString();
            rrr[colCAmt] = grfChequeView[row, colCAmt].ToString();

            //grfChequePre[row, 0] = row;
            //grfChequePre[row, colCID] = grfChequeView1[row1,colCID].ToString();
            //grfChequePre[row, colCSubNameT] = grfChequeView1[row1, colCSubNameT].ToString();
            //grfChequePre[row, colCMtp] = grfChequeView1[row1, colCMtp].ToString();
            //grfChequePre[row, colCItmNameT] = grfChequeView1[row1, colCItmNameT].ToString();
            //grfChequePre[row, colCDrawDate] = grfChequeView1[row1, colCDrawDate].ToString();
            //grfChequePre[row, colCAmt] = grfChequeView1[row1, colCAmt].ToString();

            grfChequeView.Rows.Remove(grfChequeView.Row);
        }
        private void BtnChequeDel_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            int row = 0;
            row = grfChequePre.Row;
            Row rrr = grfChequeView.Rows.Add();
            rrr[colCID] = grfChequePre[row, colCID].ToString();
            rrr[colCSubNameT] = grfChequePre[row, colCSubNameT].ToString();
            rrr[colCMtp] = grfChequePre[row, colCMtp].ToString();
            rrr[colCItmNameT] = grfChequePre[row, colCItmNameT].ToString();
            rrr[colCAmt] = grfChequePre[row, colCAmt].ToString();

            grfChequePre.Rows.Remove(row);

            //grfChequeView[grfChequePre.Row, colCID] = dt.Rows[grfChequePre.Row-1][colCID - 1].ToString();
            //grfChequeView[grfChequePre.Row, colCSubNameT] = dt.Rows[grfChequePre.Row - 1][colCSubNameT - 1].ToString();
            //grfChequeView[grfChequePre.Row, colCMtp] = dt.Rows[grfChequePre.Row - 1][colCMtp - 1].ToString();
            //grfChequeView[grfChequePre.Row, colCItmNameT] = dt.Rows[grfChequePre.Row - 1][colCItmNameT - 1].ToString();
            //grfChequeView[grfChequePre.Row, colCAmt] = dt.Rows[grfChequePre.Row - 1][colCAmt - 1].ToString();
        }

        private void BtnChequeOk_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            tCCheque.SelectedTab = tabChequeMake;
            grfChequeMake.Rows.Count = grfChequePre.Rows.Count;
            for (int row = 1; row < grfChequePre.Rows.Count; row++)
            {
                String id = "";
                id = grfChequePre[row, colCID] != null ? grfChequePre[row, colCID].ToString() : "";
                ExpensesDrawDatail dd = new ExpensesDrawDatail();
                dd = xC.xtDB.expnddDB.selectByPk1(id);
                grfChequeMake[row, 0] = row;
                grfChequeMake[row, colCID] = id;
                grfChequeMake[row, colCSubNameT] = grfChequePre[row, colCSubNameT];
                grfChequeMake[row, colCMtp] = grfChequePre[row, colCMtp];
                grfChequeMake[row, colCItmNameT] = grfChequePre[row, colCItmNameT];
                grfChequeMake[row, colCDrawDate] = grfChequePre[row, colCDrawDate];
                grfChequeMake[row, colCAmt] = grfChequePre[row, colCAmt];
                grfChequeMake[row, colCChequepayname] = dd.pay_to_cus_name_t;
            }
        }
        private Boolean setTax()
        {
            Boolean chk = true;
            String re = "";

            Customer cus = new Customer();
            Address addr = new Address();
            Customer agent = new Customer();
            Address agentaddr = new Address();
            Customer payer = new Customer();
            Address payeraddr = new Address();

            showGrfTaxView();

            tax.tax_id = "";
            tax.tax_code = xC.xtDB.copDB.genTaxDoc();
            txtTaxCode.Value = tax.tax_code;
            tax.tax_date = xC.datetoDB(txtTaxDate.Text);
            tax.job_id = "";
            tax.job_code = "";
            tax.expenses_pay_detail_id = "";
            tax.active = "1";
            tax.remark = "";
            tax.date_create = "";
            tax.date_modi = "";
            tax.date_cancel = "";
            tax.user_create = "";
            tax.user_modi = "";
            tax.user_cancel = "";
            tax.cust_id = txtCusTaxId.Text;
            cus = xC.xtDB.cusDB.selectByPk1(tax.cust_id);
            addr = xC.xtDB.addrDB.selectStatusTaxByCusId1(cus.cust_id);
            tax.year_id = "";

            tax.cust_name_t = txtCusTaxNameT.Text;
            tax.cust_addr = addr.line_t1;
            tax.cust_tele = cus.tele;
            tax.cust_tax_id = cus.tax_id;

            tax.agent_id = txtAgentTaxId.Text;
            agent = xC.xtDB.cusDB.selectByPk1(tax.agent_id);
            agentaddr = xC.xtDB.addrDB.selectStatusTaxByCusId1(agent.cust_id);
            tax.agent_name_t = txtAgentTaxNameT.Text;
            tax.agent_addr = agentaddr.line_t1;
            tax.agent_tele = agent.tele;
            tax.agent_tax_id = agent.tax_id;

            tax.payer_id = txtPayerTaxId.Text;
            payer = xC.xtDB.cusDB.selectByPk1(tax.agent_id);
            payeraddr = xC.xtDB.addrDB.selectStatusTaxByCusId1(payer.cust_id);
            tax.payer_name_t = txtPayerTaxNameT.Text;
            tax.payer_addr = payeraddr.line_t1;
            tax.payer_tax_id = payer.tax_id;

            tax.payer_tele = payer.tele;

            tax.status_tax_type = chkTax3.Checked ? "1" : chkTax53.Checked ? "2" : chkTax1.Checked ? "3" : "0";
            if (tax.status_tax_type.Equals("0"))
            {
                MessageBox.Show("ไม่พบ แบบยื่นภาษี", "error");
            }
            tax.row_no = txtRowNo.Text;
            tax.status_payer = chkStatusTax1.Checked ? "1" : chkStatusTax2.Checked ? "2" : chkStatusTax3.Checked ? "3" : chkStatusTax4.Checked ? "4" : "0";
            if (tax.status_payer.Equals("0"))
            {
                MessageBox.Show("ไม่พบ ผู้จ่ายเงิน", "error");
            }
            tax.payer_other = txtPayerOther.Text;
            tax.status_tax_normal = chkStatusTaxNormal.Checked ? "1" : chkStatusTaxAdd.Checked ? "2" : "0";
            if (tax.status_tax_normal.Equals("0"))
            {
                MessageBox.Show("ไม่พบ แบบยื่นภาษี กรณี", "error");
            }
            tax.tax_add_no = txtStatusTaxAdd.Text;
            tax.ref1 = txtReceiptDoc.Text;

            foreach(Row row in grfTax.Rows)
            {
                String ftaxid = "";
                ftaxid = row[colTftaxid] != null ? row[colTftaxid].ToString() : "";
                if (ftaxid.Equals("1700000000"))
                {
                    tax.line1_date = row[colTtaxdate] != null ? row[colTtaxdate].ToString() : "";
                    tax.line1_amount = row[colTAmt] != null ? row[colTAmt].ToString() : "";
                    tax.line1_tax = row[colTtaxamt] != null ? row[colTtaxamt].ToString() : "";
                }
                else if (ftaxid.Equals("1700000001"))
                {
                    tax.line2_date = row[colTtaxdate] != null ? row[colTtaxdate].ToString() : "";
                    tax.line2_amount = row[colTAmt] != null ? row[colTAmt].ToString() : "";
                    tax.line2_tax = row[colTtaxamt] != null ? row[colTtaxamt].ToString() : "";
                }
                else if (ftaxid.Equals("1700000002"))
                {
                    tax.line3_date = row[colTtaxdate] != null ? row[colTtaxdate].ToString() : "";
                    tax.line3_amount = row[colTAmt] != null ? row[colTAmt].ToString() : "";
                    tax.line3_tax = row[colTtaxamt] != null ? row[colTtaxamt].ToString() : "";
                }
                else if (ftaxid.Equals("1700000003"))
                {
                    tax.line41_date = row[colTtaxdate] != null ? row[colTtaxdate].ToString() : "";
                    tax.line41_amount = row[colTAmt] != null ? row[colTAmt].ToString() : "";
                    tax.line41_tax = row[colTtaxamt] != null ? row[colTtaxamt].ToString() : "";
                    tax.line41_text = row[colTItemNameT] != null ? row[colTItemNameT].ToString() : "";

                }
                else if (ftaxid.Equals("1700000004"))
                {
                    tax.line421_date = row[colTtaxdate] != null ? row[colTtaxdate].ToString() : "";
                    tax.line421_amount = row[colTAmt] != null ? row[colTAmt].ToString() : "";
                    tax.line421_tax = row[colTtaxamt] != null ? row[colTtaxamt].ToString() : "";
                    tax.line421_text = row[colTItemNameT] != null ? row[colTItemNameT].ToString() : "";

                    tax.line422_date = "";
                    tax.line422_amount = "";
                    tax.line422_tax = "";
                    tax.line422_text = "";
                    tax.line423_date = "";

                    tax.line423_amount = "";
                    tax.line423_tax = "";
                    tax.line423_text = "";
                }
                else if (ftaxid.Equals("1700000005"))
                {
                    tax.line5_date = row[colTtaxdate] != null ? row[colTtaxdate].ToString() : "";
                    tax.line5_amount = row[colTAmt] != null ? row[colTAmt].ToString() : "";
                    tax.line5_tax = row[colTtaxamt] != null ? row[colTtaxamt].ToString() : "";
                    tax.line5_text = row[colTItemNameT] != null ? row[colTItemNameT].ToString() : "";
                }
                else if (ftaxid.Equals("1700000006"))
                {
                    tax.line6_date = row[colTtaxdate] != null ? row[colTtaxdate].ToString() : "";
                    tax.line6_amount = row[colTAmt] != null ? row[colTAmt].ToString() : "";
                    tax.line6_tax = row[colTtaxamt] != null ? row[colTtaxamt].ToString() : "";
                    tax.line6_text = row[colTItemNameT] != null ? row[colTItemNameT].ToString() : "";
                }
                else
                {
                    MessageBox.Show("มีรายการไม่ตรงกลุ่ม", "error");
                }
            }
                       
            tax.status_page = "1";
            return chk;
        }
        private void BtnTaxPrn_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            DataTable dt = new DataTable();
            dt = xC.xtDB.taxDB.selectByPk(txtTaxId.Text);
            //dt = xC.xtDB.taxDB.selectByPk("1700000003");
            FrmReport frm = new FrmReport(xC);
            frm.setReportTax(dt);
            frm.ShowDialog(this);
        }
        private void BtnTaxSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setTax();
                String re = xC.xtDB.taxDB.insertTax(tax, xC.user.staff_id);
                int chk = 0, chkD = 0;
                if (int.TryParse(re, out chk))
                {
                    txtTaxId.Value = re;
                    btnTaxSave.Image = Resources.accept_database24;
                }
            }
        }
        private void BtnChequeSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setExpensesPay("2");
                String re = xC.xtDB.expnpDB.insertExpensesPay(expnp, xC.user.staff_id);
                int chk = 0, chkD=0;
                if (int.TryParse(re, out chk))
                {
                    txtExpnpID.Value = re;
                    for (int i = 1; i < grfChequeMake.Rows.Count; i++)
                    {
                        ExpensesPayDetail expnPd = new ExpensesPayDetail();
                        ExpensesDrawDatail expndd = new ExpensesDrawDatail();
                        String expnddid = "";
                        //JobImport jim = new JobImport();
                        //jim = xC.xtDB.jimDB.selectByPk1(jobId);
                        expnddid = grfChequeMake[i, colCID].ToString();
                        expndd = xC.xtDB.expnddDB.selectByPk1(expnddid);

                        expnPd.expenses_pay_detail_id = grfChequeMake[i, colCpayID] != null ? grfChequeMake[i, colCpayID].ToString() : "";//colCChequeNo
                        expnPd.expenses_pay_id = txtExpnpID.Text;
                        expnPd.item_id = expndd.item_id;
                        expnPd.status_pay_type = "2";
                        expnPd.active = "1";
                        expnPd.remark = "";
                        expnPd.user_cancel = "";
                        expnPd.user_create = "";
                        expnPd.user_modi = "";
                        expnPd.date_cancel = "";
                        expnPd.date_create = "";
                        expnPd.date_modi = "";

                        expnPd.item_name_t = expndd.item_name_t;
                        expnPd.job_id = expndd.job_id;
                        expnPd.pay_amount = expndd.amount;
                        expnPd.pay_to_cus_id = expndd.pay_to_cus_id;
                        expnPd.pay_to_cus_name_t = grfChequeMake[i, colCChequepayname] != null ? grfChequeMake[i, colCChequepayname].ToString() : "";
                        expnPd.pay_to_cus_addr = expndd.pay_to_cus_addr;
                        expnPd.pay_to_cus_tax = expndd.pay_to_cus_tax;
                        expnPd.pay_cheque_no = grfChequeMake[i, colCChequeNo] != null ? grfChequeMake[i, colCChequeNo].ToString() : "";
                        expnPd.pay_cheque_bank_id = grfChequeMake[i, colCBank] != null ? xC.xtDB.copbDB.getIdByName(grfChequeMake[i, colCBank].ToString()) : "";
                        expnPd.pay_staff_id = xC.userId;
                        expnPd.pay_date = xC.datetoDB(txtDate.Text);
                        expnPd.comp_bank_id = grfChequeMake[i, colCBank] != null ? xC.xtDB.copbDB.getIdByName(grfChequeMake[i, colCBank].ToString()) : "";
                        expnPd.pay_bank_date = grfChequeMake[i, colChequeDate] != null ? xC.datetoDB(grfChequeMake[i, colChequeDate].ToString()) : "";
                        expnPd.expenses_draw_detail_id = expndd.expenses_draw_detail_id;

                        expndd.status_pay_type = "2";
                        expndd.pay_amount = expnPd.pay_amount;
                        expndd.pay_date = expnPd.pay_date;
                        expndd.pay_cheque_no = expnPd.pay_cheque_no;
                        expndd.comp_bank_id = expnPd.comp_bank_id;
                        expndd.pay_staff_id = expnPd.pay_staff_id;
                        expndd.pay_bank_date = expnPd.pay_bank_date;
                        
                        String re1 = xC.xtDB.expnpdDB.insertExpensesPayDetail(expnPd, xC.userId);
                        expndd.expenses_pay_detail_id = re1;
                        String re2 = xC.xtDB.expnddDB.updatePay(expndd, xC.userId);
                        xC.updateStatusPay(expndd.expense_draw_id);
                        if (int.TryParse(re1, out chk))
                        {
                            chkD++;
                        }
                    }
                    if(chkD == (grfChequeMake.Rows.Count-1))
                    {
                        btnChequeSave.Image = Resources.accept_database24;
                        tCCheque.SelectedTab = tabChequePrint;
                        
                        setGrfChequePrn(txtExpnpID.Text);
                    }
                }
                else
                {
                    btnChequeSave.Image = Resources.accept_database24;
                }
                
                //setGrdView();
                //this.Dispose();
            }
        }
        private void BtnCashSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setExpensesPay("1");
                String re = xC.xtDB.expnpDB.insertExpensesPay(expnp, xC.user.staff_id);
                int chk = 0, chkD = 0;
                if (int.TryParse(re, out chk))
                {
                    txtExpnpID.Value = re;
                    for (int i = 1; i < grfCashMake.Rows.Count; i++)
                    {
                        ExpensesPayDetail expnPd = new ExpensesPayDetail();
                        ExpensesDrawDatail expndd = new ExpensesDrawDatail();
                        ReserveCash rsc = new ReserveCash();
                        String expnddid = "";
                        expnddid = grfCashMake[i, colCID].ToString();
                        expndd = xC.xtDB.expnddDB.selectByPk1(expnddid);

                        expnPd.expenses_pay_detail_id = grfCashMake[i, colCpayID] != null ? grfCashMake[i, colCpayID].ToString() : "";//colCChequeNo
                        expnPd.expenses_pay_id = txtExpnpID.Text;
                        expnPd.item_id = expndd.item_id;
                        expnPd.status_pay_type = "1";
                        expnPd.active = "1";
                        expnPd.remark = "";
                        expnPd.user_cancel = "";
                        expnPd.user_create = "";
                        expnPd.user_modi = "";
                        expnPd.date_cancel = "";
                        expnPd.date_create = "";
                        expnPd.date_modi = "";

                        expnPd.item_name_t = expndd.item_name_t;
                        expnPd.job_id = expndd.job_id;
                        expnPd.pay_amount = expndd.amount;
                        expnPd.pay_to_cus_id = expndd.pay_to_cus_id;
                        expnPd.pay_to_cus_name_t = grfCashMake[i, colCChequepayname] != null ? grfCashMake[i, colCChequepayname].ToString() : "";
                        expnPd.pay_to_cus_addr = expndd.pay_to_cus_addr;
                        expnPd.pay_to_cus_tax = expndd.pay_to_cus_tax;
                        expnPd.pay_cheque_no = grfCashMake[i, colCChequeNo] != null ? grfCashMake[i, colCChequeNo].ToString() : "";
                        expnPd.pay_cheque_bank_id = grfCashMake[i, colCBank] != null ? xC.xtDB.copbDB.getIdByName(grfCashMake[i, colCBank].ToString()) : "";
                        expnPd.pay_staff_id = xC.userId;
                        expnPd.pay_date = xC.datetoDB(txtDate.Text);
                        expnPd.comp_bank_id = grfCashMake[i, colCBank] != null ? xC.xtDB.copbDB.getIdByName(grfCashMake[i, colCBank].ToString()) : "";
                        expnPd.pay_bank_date = grfCashMake[i, colChequeDate] != null ? xC.datetoDB(grfCashMake[i, colChequeDate].ToString()) : "";
                        expnPd.expenses_draw_detail_id = expndd.expenses_draw_detail_id;

                        expndd.status_pay_type = "2";
                        expndd.pay_amount = expnPd.pay_amount;
                        expndd.pay_date = expnPd.pay_date;
                        expndd.pay_cheque_no = expnPd.pay_cheque_no;
                        expndd.comp_bank_id = expnPd.comp_bank_id;
                        expndd.pay_staff_id = expnPd.pay_staff_id;
                        expndd.pay_bank_date = expnPd.pay_bank_date;

                        String re1 = xC.xtDB.expnpdDB.insertExpensesPayDetail(expnPd, xC.userId);
                        expndd.expenses_pay_detail_id = re1;
                        String re2 = xC.xtDB.expnddDB.updatePay(expndd, xC.userId);
                        xC.updateStatusPay(expndd.expense_draw_id);
                        if (int.TryParse(re1, out chk))
                        {
                            chkD++;
                            xC.xtDB.updateOnhand(re1, xC.userId, expnPd.pay_amount);
                        }
                    }
                    if (chkD == (grfCashMake.Rows.Count - 1))
                    {
                        btnCashSave.Image = Resources.accept_database24;
                        //tCCheque.SelectedTab = tabChequePrint;

                        //setGrfChequePrn(txtExpnpID.Text);
                    }
                }
                else
                {
                    btnCashSave.Image = Resources.accept_database24;
                }

                //setGrdView();
                //this.Dispose();
            }
        }
        private void setExpensesPay(String paytype)
        {
            expnp.expenses_pay_id = txtExpnpID.Text;
            expnp.expenses_pay_code = "";
            expnp.expenses_pay_date = xC.datetoDB(txtDate.Text);
            expnp.status_pay_type = paytype;//1=cash;2=cheque
            expnp.active = "1";
            expnp.remark = txtRemark.Text;
            expnp.user_cancel = "";
            expnp.user_create = "";
            expnp.user_modi = "";
            expnp.date_cancel = "";
            expnp.date_create = "";
            expnp.date_modi = "";
        }
        private void setChkView()
        {
            if (chkViewFmtp.Checked)
            {
                setGrfViewFmtp();
            }
            else if (chkViewDraw.Checked)
            {
                setGrfView();
            }
        }
        private void ChkViewFmtp_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setChkView();
        }
        private void ChkViewDraw_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setChkView();
        }
        private void ChkAppvWait_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setChkView();
        }
        private void ChkViewAll_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setChkView();
        }
        private void ChkAppvOk_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setChkView();
        }
        private void FrmExpenseDrawPayView1_Load(object sender, EventArgs e)
        {

        }
    }
}
