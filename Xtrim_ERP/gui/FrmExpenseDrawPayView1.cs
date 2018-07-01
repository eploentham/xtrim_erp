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

namespace Xtrim_ERP.gui
{
    public partial class FrmExpenseDrawPayView1 : Form
    {
        XtrimControl xC;
        ExpensesDraw expn;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colDesc = 3, colRemark = 4, colAmt = 5, colStatus = 6;
        int colCID = 1, colCSubNameT = 2, colCMtp = 3, colCItmNameT = 4, colCDrawDate = 5, colCAmt = 6, colCBank=7, colCChequeNo=8, colChequeDate=9, colCChequepayname=10;
        int colBID = 1, colBNameT = 2, colBAmt = 3;
        C1FlexGrid grfView, grfChequeView, grfChequePre, grfChequeMake, grfChequeBnk, grfChequeView1;
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

            sB1.Text = "";

            btnChequeAdd.Click += BtnChequeAdd_Click;
            btnChequeDel.Click += BtnChequeDel_Click;
            btnChequeOk.Click += BtnChequeOk_Click;
            chkViewFmtp.Click += ChkViewFmtp_Click;
            chkViewDraw.Click += ChkViewDraw_Click;
            chkAppvWait.Click += ChkAppvWait_Click;
            chkViewAll.Click += ChkViewAll_Click;
            chkAppvOk.Click += ChkAppvOk_Click;
            btnChequeSave.Click += BtnChequeSave_Click;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
            chkViewDraw.Checked = true;

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
            tC1.SelectedTab = tabCheque;
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
            grfView.DataSource = xC.xtDB.expndDB.selectAll1(cboYear.Text, chkAppvWait.Checked ? objdb.ExpensesDrawDB.StatusPay.waitappv : chkAppvOk.Checked ? objdb.ExpensesDrawDB.StatusPay.appv : objdb.ExpensesDrawDB.StatusPay.all);
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
            for (int i = 1; i < grfView.Rows.Count; i++)
            {
                grfView[i, 0] = i;
                if (i % 2 == 0)
                    grfView.Rows[i].StyleNew.BackColor = color;
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfView.Cols[colID].Visible = false;
        }
        private void setGrfViewFmtp()
        {
            //grfDept.Rows.Count = 7;
            //grfView.Tree = 
            DataSet ds = new DataSet();
            ds = xC.xtDB.expndDB.selectAllFmtp(cboYear.Text, chkAppvWait.Checked ? objdb.ExpensesDrawDB.StatusPay.waitappv : chkAppvOk.Checked ? objdb.ExpensesDrawDB.StatusPay.appv : objdb.ExpensesDrawDB.StatusPay.all);
            grfView.DataSource = ds.Tables[0];
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
            for (int i = 1; i < grfView.Rows.Count; i++)
            {
                grfView[i, 0] = i;
                if (i % 2 == 0)
                    grfView.Rows[i].StyleNew.BackColor = color;
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

            grfChequeView1 = new C1FlexGrid();
            grfChequeView1.Font = fEdit;
            grfChequeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            grfChequeView1.Location = new System.Drawing.Point(0, 0);
            gbChequeView.Controls.Add(grfChequeView1);
            //FilterRow fr = new FilterRow(grfView);            


        }
        private void setGrfChequeView()
        {
            //grfDept.Rows.Count = 7;
            DataTable dt = new DataTable();
            dt = xC.xtDB.expnddDB.selectByChequeAppv("2");
            grfChequeView1.DataSource = dt;
            grfChequeView.Cols.Count = dt.Columns.Count+1;
            grfChequeView.Rows.Count = dt.Rows.Count + 1;
            TextBox txt = new TextBox();

            grfChequeView.Cols[colCode].Editor = txt;
            grfChequeView.Cols[colDesc].Editor = txt;
            grfChequeView.Cols[colRemark].Editor = txt;

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
                grfChequeView[i+1, 0] = i;
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
            grfChequeMake.Cols.Count = 11;
            TextBox txt = new TextBox();
            C1ComboBox cbo = new C1ComboBox();
            xC.xtDB.bnkDB.setCboItem(cbo);
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

            theme1.SetTheme(grfChequeMake, "Office2013Red");
        }
        private void setGrfChequeBnk()
        {
            grfChequeBnk.Rows.Count = 1;
            grfChequeBnk.DataSource = xC.xtDB.bnkDB.selectAll1();
            //grfChequeBnk.Cols.Count = 7;
            TextBox txt = new TextBox();

            grfChequeBnk.Cols[colBID].Editor = txt;
            grfChequeBnk.Cols[colBNameT].Editor = txt;
            grfChequeBnk.Cols[colBAmt].Editor = txt;

            grfChequeBnk.Cols[colBNameT].Width = 220;
            grfChequeBnk.Cols[colBAmt].Width = 80;            

            grfChequeBnk.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfChequeBnk.Cols[colBNameT].Caption = "ธนาคาร";
            grfChequeBnk.Cols[colBAmt].Caption = "จำนวนเงิน";
            
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
        private void BtnChequeAdd_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            int row = grfChequeView.Row;
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
                grfChequeMake[row, 0] = row;
                grfChequeMake[row, colCID] = grfChequePre[row, colCID];
                grfChequeMake[row, colCSubNameT] = grfChequePre[row, colCSubNameT];
                grfChequeMake[row, colCMtp] = grfChequePre[row, colCMtp];
                grfChequeMake[row, colCItmNameT] = grfChequePre[row, colCItmNameT];
                grfChequeMake[row, colCDrawDate] = grfChequePre[row, colCDrawDate];
                grfChequeMake[row, colCAmt] = grfChequePre[row, colCAmt];
            }
        }
        private void BtnChequeSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

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
