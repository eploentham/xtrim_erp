﻿using C1.Win.C1FlexGrid;
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

namespace Xtrim_ERP.gui
{
    public partial class FrmJobImpNew : Form
    {
        JobImport jim;
        JobImportBl jbl;
        JobImportInv jin;
        JobImportExpn jei;
        XtrimControl xC;
        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        String dateStart = "";
        int colInvId = 0, colInvNo = 1, colInvDate = 2, colInvAmt=3, colInvSuppNameT=4, colCurrNameT=5, colInvRemark = 6;
        int colInvCnt = 7;
        int colExpnId = 0, colExpnRowNo = 1, colExpnDate = 2, colExpnNameT = 3, colExpnMtpNameT = 4;
        int colExpnCnt = 5;

        C1FlexGrid grfInv, grfExpn;

        public FrmJobImpNew(XtrimControl x)
        {
            dateStart = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            InitializeComponent();
            xC = x;
            initConfig();
            
        }
        private void initConfig()
        {
            jim = new JobImport();
            jbl = new JobImportBl();
            jin = new JobImportInv();
            jei = new JobImportExpn();
            bg = txtCusNameT.BackColor;
            fc = txtCusNameT.ForeColor;
            ff = txtCusNameT.Font;
            ComboBoxItem a1 = new ComboBoxItem();
            a1.Value = "1";
            a1.Text = "1-ทางเรือ (Sea)";
            ComboBoxItem a2 = new ComboBoxItem();
            a2.Value = "2";
            a2.Text = "2-รถไฟ (Rail)";
            ComboBoxItem a3 = new ComboBoxItem();
            a3.Value = "3";
            a3.Text = "3-รถยนต์ (Road)";
            ComboBoxItem a4 = new ComboBoxItem();
            a4.Value = "4";
            a4.Text = "4-เครื่องบิน (Air)";
            ComboBoxItem a5 = new ComboBoxItem();
            a5.Value = "5";
            a5.Text = "5-ไปรษณีย์ (Mail)";
            ComboBoxItem a6 = new ComboBoxItem();
            a6.Value = "6";
            a6.Text = "6-อื่นฯ (Other)";

            ComboBoxItem b1 = new ComboBoxItem();
            b1.Value = "1";
            b1.Text = "1=ชำระภาษีปกติ";
            ComboBoxItem b2 = new ComboBoxItem();
            b2.Value = "2";
            b2.Text = "2=ธนาคารค้ำประกัน";

            ComboBoxItem c1 = new ComboBoxItem();
            c1.Value = "1";
            c1.Text = "1=LCL เข้าโกดัง";
            ComboBoxItem c2 = new ComboBoxItem();
            c2.Value = "2";
            c2.Text = "2=FCL ลากตู้";

            ComboBoxItem d1 = new ComboBoxItem();
            d1.Value = "1";
            d1.Text = "Manual";
            ComboBoxItem d2 = new ComboBoxItem();
            d2.Value = "2";
            d2.Text = "Green Line";
            ComboBoxItem d3 = new ComboBoxItem();
            d3.Value = "3";
            d3.Text = "Red Line";

            //ComboBoxItem d1 = new ComboBoxItem();
            //d1.Value = "1";
            //d1.Text = "1=LCL เข้าโกดัง";
            //ComboBoxItem d2 = new ComboBoxItem();
            //d2.Value = "2";
            //d2.Text = "2=FCL ลากตู้";
            //a1.Add("1-ทางเรือ (Sea)");
            //a1.Add("2-รถไฟ (Rail)");
            //a1.Add("3-รถยนต์ (Road)");2=FCL ลากตู้
            //a1.Add("4-เครื่องบิน (Air)");
            //a1.Add("5-ไปรษณีย์ (Mail)");
            //a1.Add("6-อื่นฯ (Other)");
            //cboTransMode.Items.Add("1-ทางเรือ (Sea)");
            //cboTransMode.Items.Add("2-รถไฟ (Rail)");
            //cboTransMode.Items.Add("3-รถยนต์ (Road)");
            //cboTransMode.Items.Add("4-เครื่องบิน (Air)");
            //cboTransMode.Items.Add("5-ไปรษณีย์ (Mail)");
            //cboTransMode.Items.Add("6-อื่นฯ (Other)");
            cboTransMode.Items.Add(a1);
            cboTransMode.Items.Add(a2);
            cboTransMode.Items.Add(a3);
            cboTransMode.Items.Add(a4);
            cboTransMode.Items.Add(a5);
            cboTransMode.Items.Add(a6);

            cboTaxMethod.Items.Add(b1);
            cboTaxMethod.Items.Add(b2);

            cboChkExam.Items.Add(c1);
            cboChkExam.Items.Add(c2);

            cboEdiResp.Items.Add(d1);
            cboEdiResp.Items.Add(d2);
            cboEdiResp.Items.Add(d3);

            setControl();
            setFocusColor();
            //setGrdViewInv();
            //setGrdViewExpn();
            initGrfInvH();
            setGrfInvH();
            initGrfExpnH();
            setGrfExpnH();

            //txtCusCode += even
            this.txtCusNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            this.txtImpNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            this.txtFwdNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            this.txtEttNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            this.txtPvlNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            this.txtPolNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);

            this.btnCusSF4.Click += new System.EventHandler(this.btnCusAdd_Click);
            this.btnImpSF2.Click += new System.EventHandler(this.btnCusAdd_Click);
            this.btnFwdAdd.Click += new System.EventHandler(this.btnCusAdd_Click);
            this.btnEttAdd.Click += new System.EventHandler(this.btnCusAdd_Click);
            this.btnPvlAdd.Click += new System.EventHandler(this.btnCusAdd_Click);
            this.btnPolAdd.Click += new System.EventHandler(this.btnCusAdd_Click);

            lbCus.Click += new System.EventHandler(this.lbCus_Click);
            //grdInv.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.grdInv_CellClick);
            //grdExpn.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.grdExpn_CellClick);

            sepCusNameT.SetError(txtCusNameT, xC.GetInfoMessageSEP("This is a required field", "Must be at least 4 characters"));
            //sttCusNameT.SetToolTip(txtCusNameT, "here it is");
            sttCusNameT.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
            //sttCusNameT.Show(txtCusNameT,sttCusNameT.h);
        }
        //private void setGrdViewHExpn()
        //{
        //    FarPoint.Win.Spread.EnhancedInterfaceRenderer outlinelook = new FarPoint.Win.Spread.EnhancedInterfaceRenderer();
        //    outlinelook.RangeGroupBackgroundColor = Color.LightGreen;
        //    outlinelook.RangeGroupButtonBorderColor = Color.Red;
        //    outlinelook.RangeGroupLineColor = Color.Blue;
        //    grdExpn.InterfaceRenderer = outlinelook;
        //    grdExpn.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

        //    grdExpn.BorderStyle = BorderStyle.None;
        //    grdExpn.Sheets[0].Columns[colInvNo, colInvRemark].AllowAutoFilter = true;
        //    grdExpn.Sheets[0].Columns[colInvNo, colInvRemark].AllowAutoSort = true;
        //    grdExpn.Sheets[0].AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu;

        //    FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();
        //    FarPoint.Win.Spread.CellType.ButtonCellType buttoncell = new FarPoint.Win.Spread.CellType.ButtonCellType();

        //    grdExpn.Sheets[0].ColumnCount = colExpnCnt;
        //    grdExpn.Sheets[0].RowCount = 1;
        //    grdExpn.Font = fEdit;

        //    grdExpn.Sheets[0].Columns[colExpnId].CellType = objTextCell;
        //    grdExpn.Sheets[0].Columns[colExpnRowNo].CellType = objTextCell;
        //    grdExpn.Sheets[0].Columns[colExpnDate].CellType = objTextCell;
        //    grdExpn.Sheets[0].Columns[colExpnNameT].CellType = objTextCell;
        //    grdExpn.Sheets[0].Columns[colExpnMtpNameT].CellType = objTextCell;
        //    //grdInv.Sheets[0].Columns[colInvRemark].CellType = objTextCell;
        //    //grdInv.Sheets[0].Columns[colCurrNameT].CellType = objTextCell;

        //    grdExpn.Sheets[0].ColumnHeader.Cells[0, colExpnId].Text = "id";
        //    grdExpn.Sheets[0].ColumnHeader.Cells[0, colExpnRowNo].Text = "no";
        //    grdExpn.Sheets[0].ColumnHeader.Cells[0, colExpnDate].Text = "date";
        //    grdExpn.Sheets[0].ColumnHeader.Cells[0, colExpnNameT].Text = "expenses name";
        //    grdExpn.Sheets[0].ColumnHeader.Cells[0, colExpnMtpNameT].Text = "method payment";
        //    //grdInv.Sheets[0].ColumnHeader.Cells[0, colInvRemark].Text = "remark";
        //    //grdInv.Sheets[0].ColumnHeader.Cells[0, colCurrNameT].Text = "currency";

        //    grdExpn.Sheets[0].Columns[colExpnRowNo].Width = 50;
        //    grdExpn.Sheets[0].Columns[colExpnDate].Width = 80;
        //    grdExpn.Sheets[0].Columns[colExpnNameT].Width = 200;
        //    grdExpn.Sheets[0].Columns[colExpnMtpNameT].Width = 200;
        //    //grdInv.Sheets[0].Columns[colInvRemark].Width = 200;
        //    //grdInv.Sheets[0].Columns[colCurrNameT].Width = 120;

        //    grdExpn.Sheets[0].Columns[colExpnId].Visible = false;
        //}
        //private void setGrdViewExpn()
        //{
        //    //DataTable dt = new DataTable();
        //    int i = 0;
        //    FarPoint.Win.Spread.Column columnobj;
        //    columnobj = grdExpn.ActiveSheet.Columns[colExpnId, colExpnMtpNameT];
        //    DataTable dtExpn = xC.xtDB.jieDB.selectByJobId(xC.jobID);
        //    grdExpn.Sheets[0].Rows.Clear();
        //    setGrdViewHExpn();
        //    grdExpn.Sheets[0].RowCount = dtExpn.Rows.Count + 1;
        //    foreach (DataRow row in dtExpn.Rows)
        //    {
        //        grdExpn.Sheets[0].Cells[i, colExpnId].Value = row[xC.xtDB.jieDB.jie.job_import_expenses_id] == null ? "" : row[xC.xtDB.jieDB.jie.job_import_expenses_id].ToString();
        //        grdExpn.Sheets[0].Cells[i, colExpnRowNo].Value = row[xC.xtDB.jieDB.jie.row_no].ToString();
        //        grdExpn.Sheets[0].Cells[i, colExpnDate].Value = row[xC.xtDB.jieDB.jie.expenses_date].ToString();
        //        grdExpn.Sheets[0].Cells[i, colExpnNameT].Value = row[xC.xtDB.expnDB.expn.expenses_name_t].ToString();
        //        grdExpn.Sheets[0].Cells[i, colExpnMtpNameT].Value = row[xC.xtDB.mtpDB.mtp.method_payment_name_t].ToString();
        //        //grdInv.Sheets[0].Cells[i, colInvRemark].Value = row[xC.xtDB.jinDB.jin.remark].ToString();
        //        //grdInv.Sheets[0].Cells[i, colCurrNameT].Value = row[xC.xtDB.jinDB.jin.currNameT].ToString();
        //        //grdInv.Sheets[0].Cells[i, colJblDesc].Value = row[xC.xtDB.jblDB.jbl.description].ToString();

        //        //grdInv.Sheets[0].Cells[i, coledit].Value = "0";
        //        if (i % 2 != 0)
        //        {
        //            grdExpn.Sheets[0].Cells[i, 0, i, colExpnMtpNameT - 1].BackColor = System.Drawing.Color.FromArgb(235, 241, 222);
        //        }

        //        columnobj.Locked = true;

        //        i++;
        //    }
        //}
        private void initGrfInvH()
        {
            grfInv = new C1FlexGrid();
            grfInv.Font = fEdit;
            grfInv.Dock = System.Windows.Forms.DockStyle.Fill;
            grfInv.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfInv);
                        
            grfInv.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfInv_AfterRowColChange);
            grfInv.DoubleClick += new System.EventHandler(this.grfInv_DoubleClick);
            
            panelInv.Controls.Add(this.grfInv);
            
            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfInv, theme);
        }
        private void initGrfExpnH()
        {
            grfExpn = new C1FlexGrid();
            grfExpn.Font = fEdit;
            grfExpn.Dock = System.Windows.Forms.DockStyle.Fill;
            grfExpn.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfExpn);

            grfExpn.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfExpn_AfterRowColChange);
            grfExpn.DoubleClick += new System.EventHandler(this.grfInv_DoubleClick);

            panelExpn.Controls.Add(this.grfExpn);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfInv, theme);
        }
        private void setGrfInvH()
        {
            //grfInv.DataSource = xC.xtDB.addrDB.selectByTableId1(custId);

            grfInv.Cols[colInvId].Width = 60;
            grfInv.Cols[colInvNo].Width = 100;
            grfInv.Cols[colInvDate].Width = 100;
            grfInv.Cols[colInvAmt].Width = 100;
            grfInv.Cols[colInvSuppNameT].Width = 100;
            grfInv.Cols[colCurrNameT].Width = 100;
            grfInv.Cols[colInvRemark].Width = 100;
            //grfAddr.Cols[colAddrEmail2].Width = 100;
            //grfAddr.Cols[colAddrTele].Width = 100;
            //grfAddr.Cols[colAddrMobile].Width = 100;
            //grfAddr.Cols[colAddrRemark].Width = 100;
            //grfAddr.Cols[colAddrRemark2].Width = 100;
            grfInv.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            grfInv.Cols[colInvId].Caption = "ชื่อที่อยู่";
            grfInv.Cols[colInvNo].Caption = "ที่อยู่ 1";
            grfInv.Cols[colInvDate].Caption = "ที่อยู่ 2";
            grfInv.Cols[colInvAmt].Caption = "ที่อยู่ 3";
            grfInv.Cols[colInvSuppNameT].Caption = "ที่อยู่ 4";
            grfInv.Cols[colCurrNameT].Caption = "email";
            grfInv.Cols[colInvRemark].Caption = "email2";
            //grfAddr.Cols[colAddrTele].Caption = "tele";
            //grfAddr.Cols[colAddrMobile].Caption = "mobile";
            //grfAddr.Cols[colAddrRemark].Caption = "หมายเหตุ";
            //grfAddr.Cols[colAddrRemark2].Caption = "หมายเหตุ2";
        }
        private void setGrfExpnH()
        {
            //grfInv.DataSource = xC.xtDB.addrDB.selectByTableId1(custId);

            grfExpn.Cols[colInvId].Width = 60;
            grfExpn.Cols[colInvNo].Width = 100;
            grfExpn.Cols[colInvDate].Width = 100;
            grfExpn.Cols[colInvAmt].Width = 100;
            grfExpn.Cols[colInvSuppNameT].Width = 100;
            grfExpn.Cols[colCurrNameT].Width = 100;
            grfExpn.Cols[colInvRemark].Width = 100;
            //grfAddr.Cols[colAddrEmail2].Width = 100;
            //grfAddr.Cols[colAddrTele].Width = 100;
            //grfAddr.Cols[colAddrMobile].Width = 100;
            //grfAddr.Cols[colAddrRemark].Width = 100;
            //grfAddr.Cols[colAddrRemark2].Width = 100;
            grfExpn.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            grfExpn.Cols[colInvId].Caption = "ชื่อที่อยู่";
            grfExpn.Cols[colInvNo].Caption = "ที่อยู่ 1";
            grfExpn.Cols[colInvDate].Caption = "ที่อยู่ 2";
            grfExpn.Cols[colInvAmt].Caption = "ที่อยู่ 3";
            grfExpn.Cols[colInvSuppNameT].Caption = "ที่อยู่ 4";
            grfExpn.Cols[colCurrNameT].Caption = "email";
            grfExpn.Cols[colInvRemark].Caption = "email2";
            //grfAddr.Cols[colAddrTele].Caption = "tele";
            //grfAddr.Cols[colAddrMobile].Caption = "mobile";
            //grfAddr.Cols[colAddrRemark].Caption = "หมายเหตุ";
            //grfAddr.Cols[colAddrRemark2].Caption = "หมายเหตุ2";
        }
        //private void setGrdViewHInv()
        //{
        //    FarPoint.Win.Spread.EnhancedInterfaceRenderer outlinelook = new FarPoint.Win.Spread.EnhancedInterfaceRenderer();
        //    outlinelook.RangeGroupBackgroundColor = Color.LightGreen;
        //    outlinelook.RangeGroupButtonBorderColor = Color.Red;
        //    outlinelook.RangeGroupLineColor = Color.Blue;
        //    grdInv.InterfaceRenderer = outlinelook;
        //    grdInv.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

        //    grdInv.BorderStyle = BorderStyle.None;
        //    grdInv.Sheets[0].Columns[colInvNo, colInvRemark].AllowAutoFilter = true;
        //    grdInv.Sheets[0].Columns[colInvNo, colInvRemark].AllowAutoSort = true;
        //    grdInv.Sheets[0].AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu;

        //    FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();
        //    FarPoint.Win.Spread.CellType.ButtonCellType buttoncell = new FarPoint.Win.Spread.CellType.ButtonCellType();

        //    grdInv.Sheets[0].ColumnCount = colInvCnt;
        //    grdInv.Sheets[0].RowCount = 1;
        //    grdInv.Font = fEdit;

        //    grdInv.Sheets[0].Columns[colInvId].CellType = objTextCell;
        //    grdInv.Sheets[0].Columns[colInvNo].CellType = objTextCell;
        //    grdInv.Sheets[0].Columns[colInvDate].CellType = objTextCell;
        //    grdInv.Sheets[0].Columns[colInvAmt].CellType = objTextCell;
        //    grdInv.Sheets[0].Columns[colInvSuppNameT].CellType = objTextCell;
        //    grdInv.Sheets[0].Columns[colInvRemark].CellType = objTextCell;
        //    grdInv.Sheets[0].Columns[colCurrNameT].CellType = objTextCell;

        //    grdInv.Sheets[0].ColumnHeader.Cells[0, colInvId].Text = "id";
        //    grdInv.Sheets[0].ColumnHeader.Cells[0, colInvNo].Text = "inv no";
        //    grdInv.Sheets[0].ColumnHeader.Cells[0, colInvDate].Text = "inv date";
        //    grdInv.Sheets[0].ColumnHeader.Cells[0, colInvAmt].Text = "amount";
        //    grdInv.Sheets[0].ColumnHeader.Cells[0, colInvSuppNameT].Text = "supplier";
        //    grdInv.Sheets[0].ColumnHeader.Cells[0, colInvRemark].Text = "remark";
        //    grdInv.Sheets[0].ColumnHeader.Cells[0, colCurrNameT].Text = "currency";

        //    grdInv.Sheets[0].Columns[colInvNo].Width = 120;
        //    grdInv.Sheets[0].Columns[colInvDate].Width = 120;
        //    grdInv.Sheets[0].Columns[colInvAmt].Width = 100;
        //    grdInv.Sheets[0].Columns[colInvSuppNameT].Width =200;
        //    grdInv.Sheets[0].Columns[colInvRemark].Width = 200;
        //    grdInv.Sheets[0].Columns[colCurrNameT].Width = 120;

        //    grdInv.Sheets[0].Columns[colInvId].Visible = false;
        //}
        //private void setGrdViewInv()
        //{
        //    //DataTable dt = new DataTable();
        //    int i = 0;
        //    FarPoint.Win.Spread.Column columnobj;
        //    columnobj = grdInv.ActiveSheet.Columns[colInvId, colInvRemark];
        //    DataTable dtInv = xC.xtDB.jinDB.selectByJobId(xC.jobID);
        //    grdInv.Sheets[0].Rows.Clear();
        //    setGrdViewHInv();
        //    grdInv.Sheets[0].RowCount = dtInv.Rows.Count + 1;
        //    foreach (DataRow row in dtInv.Rows)
        //    {
        //        grdInv.Sheets[0].Cells[i, colInvId].Value = row[xC.xtDB.jinDB.jin.job_import_inv_id] == null ? "" : row[xC.xtDB.jinDB.jin.job_import_inv_id].ToString();
        //        grdInv.Sheets[0].Cells[i, colInvNo].Value = row[xC.xtDB.jinDB.jin.inv_no].ToString();
        //        grdInv.Sheets[0].Cells[i, colInvDate].Value = row[xC.xtDB.jinDB.jin.invoice_date].ToString();
        //        grdInv.Sheets[0].Cells[i, colInvAmt].Value = row[xC.xtDB.jinDB.jin.amount].ToString();
        //        grdInv.Sheets[0].Cells[i, colInvSuppNameT].Value = row[xC.xtDB.jinDB.jin.SuppNameT].ToString();
        //        grdInv.Sheets[0].Cells[i, colInvRemark].Value = row[xC.xtDB.jinDB.jin.remark].ToString();
        //        grdInv.Sheets[0].Cells[i, colCurrNameT].Value = row[xC.xtDB.jinDB.jin.currNameT].ToString();
        //        //grdInv.Sheets[0].Cells[i, colJblDesc].Value = row[xC.xtDB.jblDB.jbl.description].ToString();

        //        //grdInv.Sheets[0].Cells[i, coledit].Value = "0";
        //        if (i % 2 != 0)
        //        {
        //            grdInv.Sheets[0].Cells[i, 0, i, colInvCnt - 1].BackColor = System.Drawing.Color.FromArgb(235, 241, 222);
        //        }

        //        columnobj.Locked = true;

        //        i++;
        //    }
        //}
        private void setControl()
        {
            if (xC.jobID.Equals("")) return;
            jim = xC.xtDB.jimDB.selectByPk1(xC.jobID);
            jbl = xC.xtDB.jblDB.selectByJobId(xC.jobID);
            //DataTable dtInv = xC.xtDB.jinDB.selectByJobId(xC.jobID);

            txtID.Value = jim.imp_id;
            txtJobCode.Value = jim.job_import_code;
            txtJobDate.Value = jim.job_import_date;
            //xC.xtDB.cusDB.setCboCus(cboCus, jim.cust_id);
            txtCusNameT.Value = jim.cusNameT;
            txtImpNameT.Value = jim.impNameT;
            txtFwdNameT.Value = jbl.fwdNameT;
            txtEttNameT.Value = jim.ettNameT;
            txtPvlNameT.Value = jim.pvlNameT;
            txtPolNameT.Value = jbl.polNameT;
            txtTmnNameT.Value = jbl.tmnNameT;
            txtPtiNameT.Value = jbl.ptiNameT;

            //txtInvNo.Value = jin.inv_no;
            //txtInvDate1.Value = jin.invoice_date;
            //txtInvSuppNameT.Value = jin.SuppNameT;
            //txtJobIncoNameT.Value = jin.ictNameT;
            //txtInvAmt.Value = jin.amount;
            //InvTPayNameT.Value = 


            //lbCusNameT.Value = jim.cusNameT;
            //lbImpNameT.Value = jim.impNameT;
            //lbFwdNameT.Value = jbl.fwdNameT;
            //lbEttNameT.Value = jim.ettNameT;
            //lbPvlNameT.Value = jim.pvlNameT;
            //lbPolNameT.Value = jbl.polNameT;
            //lbTmnNameT.Value = jbl.tmnNameT;
            //xC.xtDB.impDB.setCboImp(cboImp, jim.imp_id);
            //cboTransMode.Value = "1";
            txtRef1.Value = jim.ref_1;
            txtRef2.Value = jim.ref_2;
            txtRef3.Value = jim.ref_3;
            txtRef4.Value = jim.ref_4;
            txtRef5.Value = jim.ref_5;
            lbCusAddr.Value = jim.cusAddr;
            lbImpAddr.Value = jim.impAddr;
            txtJobDate.Value = jim.job_import_date;
            //xC.xtDB.ettDB.setCboEtt(cboEtt, jim.entry_type);
            //xC.xtDB.pvlDB.setCboPvl(/*cboPvl*/, jim.privi_id);
            //xC.xtDB.fwdDB.setCboFwd(cboFwd, jbl.forwarder_id);
            //xC.xtDB.ptiDB.setCboPti(cboPti, jbl.port_imp_id);
            //xC.xtDB.tmnDB.setCboTmn(cboTmn, jbl.terminal_id);
            //xC.xtDB.ugwDB.setC1CboUgw(cboUgw, jbl.gw_unit_id);
            //cboUgw.SelectedText = jbl.ugwNameT;
            xC.xtDB.ugwDB.setC1CboUgw(cboUgw, jbl.gw_unit_id);
            xC.xtDB.utpDB.setC1CboUtp(cboUtp, jbl.unit_package_id);
            //cboUtp.SelectedText = jbl.utpNameT;
            xC.xtDB.ugwDB.setCboUgw(cboUgw1, jbl.gw_unit_id);
            xC.xtDB.utpDB.setCboUtp(cboUtp1, jbl.unit_package_id);
            xC.setCboC1(cboTransMode, jim.transport_mode);
            xC.setCboC1(cboChkExam, jim.check_exam_id);
            xC.setCboC1(cboTaxMethod, jim.tax_method_id);
            //xC.xtDB.polDB.setCboPol(cboPol, jbl.port_of_loading_id);
            //xC.xtDB.utpDB.setCboUtp(cboUtp, jbl.unit_package_id);
            //cboUtp1 = cboUtp;
            //cboUgw1 = cboUgw;
            //cboUtp1.SelectedItem = cboUtp.SelectedItem;
            //cboUgw1.SelectedItem = cboUgw.SelectedItem;
            txtGw.Value = jbl.gw;
            txtGw1.Value = jbl.gw;
            txtTotalP.Value = jbl.total_packages;
            txtTotalP1.Value = jbl.total_packages;
            txtVolume.Value = jbl.volume1;
            txtTotal20.Value = jbl.total_con20;
            txtTotal40.Value = jbl.total_con40;
            txtMbl.Value = jbl.mbl_mawb;
            txtMbl1.Value = jbl.mbl_mawb;
            txtHbl.Value = jbl.hbl_hawb;
            txtHbl1.Value = jbl.hbl_hawb;
            txtMves.Value = jbl.m_vessel;
            txtMves1.Value = jbl.m_vessel;
            txtEtd.Value = jbl.etd;
            txtEtd1.Value = jbl.etd;
            txtInsurDate.Value = jim.insr_date;
            txtFves.Value = jbl.f_vessel;
            txtEta.Value = jbl.eta;
            txtRemark1.Value = jim.remark;
            txtRemark2.Value = jbl.remark;
            txtDeliRemark.Value = jbl.delivery_remark;
            txtEdiRef.Value = jim.ref_edi;
            txtTaxAmt.Value = jim.tax_amt;
            txtImpEntry.Value = jim.imp_entry;
            txtInvDate.Value = jim.inv_date;
            txtPolicyDate.Value = jim.policy_date;
            txtPolicyNo.Value = jim.policy_no;
            txtPremium.Value = jim.premium;

            txtDesc.Value = jbl.description;
            txtDesc1.Value = jbl.description;
        }
        private void setFocusColor()
        {
            this.txtCusNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCusNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtImpNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtImpNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtJobCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtJobCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtJobDate.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtJobDate.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRef1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRef1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRef2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRef2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRef3.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRef3.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRef4.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRef4.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRef5.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRef5.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEttNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEttNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPvlNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPvlNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtFwdNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtFwdNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMbl.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMbl.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtHbl.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtHbl.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMves.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMves.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEtd.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEtd.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPolNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPolNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtFves.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtFves.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEta.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEta.Enter += new System.EventHandler(this.textBox_Enter);

        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = Color.DarkCyan;
            a.Font = new Font(ff, FontStyle.Bold);

            //a.ForeColor = Color.Black;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = bg;
            a.ForeColor = fc;
            a.Font = new Font(ff, FontStyle.Regular);
        }
        private void txtCusCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (sender.Equals(txtCusNameT))
                {
                    int top = 0, leftg = 0;
                    top = txtCusNameT.Top+24+24+10;
                    
                    leftg = txtCusNameT.Left;
                    FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Customer, top, leftg);
                    frm.ShowDialog(this);
                    lbCusAddr.Value = xC.sCus.taddr1 + "\n" + xC.sCus.taddr2 + "\n" + xC.sCus.taddr3 + "\n" + xC.sCus.taddr4;
                    txtCusNameT.Value = xC.sCus.cust_name_t;
                    //lbCusNameT.Value = xC.sCus.cust_name_t;
                }
                else if (sender.Equals(txtImpNameT))
                {
                    FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Importer);
                    frm.ShowDialog(this);
                    lbImpAddr.Value = xC.sImp.taddr1 + "\n" + xC.sImp.taddr2 + "\n" + xC.sImp.taddr3 + "\n" + xC.sImp.taddr4;
                    txtImpNameT.Value = xC.sImp.imp_name_t;
                    //lbImpNameT.Value = xC.sImp.imp_name_t;
                }
                else if (sender.Equals(txtFwdNameT))
                {
                    FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Forwarder);
                    frm.ShowDialog(this);
                    //lbFwdAddr.Value = xC.sFwd.taddr1 + "\n" + xC.sFwd.taddr2 + "\n" + xC.sFwd.taddr3 + "\n" + xC.sFwd.taddr4;
                    txtFwdNameT.Value = xC.sFwd.forwarder_name_t;
                    //lbFwdNameT.Value = xC.sFwd.forwarder_name_t;
                }
                else if (sender.Equals(txtEttNameT))
                {
                    FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.EntryType);
                    frm.ShowDialog(this);
                    //lbFwdAddr.Value = xC.sFwd.taddr1 + "\n" + xC.sFwd.taddr2 + "\n" + xC.sFwd.taddr3 + "\n" + xC.sFwd.taddr4;
                    txtEttNameT.Value = xC.sEtt.entry_type_name_t;
                    //lbEttNameT.Value = xC.sEtt.entry_type_name_t;
                }
                else if (sender.Equals(txtPvlNameT))
                {
                    FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Privilege);
                    frm.ShowDialog(this);
                    //lbFwdAddr.Value = xC.sFwd.taddr1 + "\n" + xC.sFwd.taddr2 + "\n" + xC.sFwd.taddr3 + "\n" + xC.sFwd.taddr4;
                    txtPvlNameT.Value = xC.sPvl.code;
                    //lbPvlNameT.Value = xC.sPvl.desc1;
                }
                else if (sender.Equals(txtPolNameT))
                {
                    FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.PortOfLoading);
                    frm.ShowDialog(this);
                    //lbFwdAddr.Value = xC.sFwd.taddr1 + "\n" + xC.sFwd.taddr2 + "\n" + xC.sFwd.taddr3 + "\n" + xC.sFwd.taddr4;
                    txtPolNameT.Value = xC.sPol.port_of_loading_t;
                    //lbPolNameT.Value = xC.sPol.port_of_loading_t;
                }
                //else if (sender.Equals(txtPtiCode))
                //{

                //}

                //dt.Rows[0]["taddr1"].ToString() + "\n" + dt.Rows[0]["taddr2"].ToString() + "\n" + dt.Rows[0]["taddr3"].ToString() + "\n" + dt.Rows[0]["taddr4"].ToString();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (sender.Equals(txtCusNameT))
                {
                    if (txtCusNameT.Text.Length>=2)
                    {
                        DataTable dt = new DataTable();
                        dt = xC.xtDB.cusDB.selectByCodeLike(txtCusNameT.Text);
                        if (dt.Rows.Count==1)
                        {
                            txtCusNameT.Value = dt.Rows[0][xC.xtDB.cusDB.cus.cust_name_t];
                        }
                        else if(dt.Rows.Count>1)
                        {
                            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Customer, txtCusNameT.Text);
                            frm.ShowDialog(this);
                            lbCusAddr.Value = xC.sCus.taddr1 + "\n" + xC.sCus.taddr2 + "\n" + xC.sCus.taddr3 + "\n" + xC.sCus.taddr4;
                            txtCusNameT.Value = xC.sCus.cust_name_t;
                        }
                        //MessageBox.Show("1111", "11");
                    }
                }
                else if (sender.Equals(txtImpNameT))
                {
                    if (txtImpNameT.Text.Length >= 2)
                    {
                        DataTable dt = new DataTable();
                        dt = xC.xtDB.impDB.selectByPk(txtImpNameT.Text);
                        if (dt.Rows.Count == 1)
                        {
                            txtImpNameT.Value = dt.Rows[0][xC.xtDB.impDB.imp.imp_name_t];
                        }
                        else if (dt.Rows.Count > 1)
                        {
                            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Customer, txtImpNameT.Text);
                            frm.ShowDialog(this);
                            lbImpAddr.Value = xC.sImp.taddr1 + "\n" + xC.sImp.taddr2 + "\n" + xC.sImp.taddr3 + "\n" + xC.sImp.taddr4;
                            txtImpNameT.Value = xC.sImp.imp_name_t;
                        }
                        //MessageBox.Show("1111", "11");
                    }
                }
            }
        }
        private void c1Label16_Click(object sender, EventArgs e)
        {

        }

        private void FrmJobImpNew_Load(object sender, EventArgs e)
        {
            //cboCus.DropDownWidth = GetDropDownWidth(cboCus);
            //cboImp.DropDownWidth = GetDropDownWidth(cboImp);
            //setControl();
            //cboCus.DroppedDown = true;
            lbStart.Value = dateStart;
            lbEnd.Value = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
        
        private void btnCusAdd_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnCusSF4))
            {
                FrmCustomer frm = new FrmCustomer(xC);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
            else if (sender.Equals(btnImpSF2))
            {
                FrmImporter frm = new FrmImporter(xC);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
            else if (sender.Equals(btnFwdAdd))
            {
                //FrmForwarder frm = new FrmForwarder(xC);
                //frm.StartPosition = FormStartPosition.CenterParent;
                //frm.ShowDialog(this);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void lbCus_Click(object sender, EventArgs e)
        {
            if (sender.Equals(lbCus))
            {
                FrmCustomer frm = new FrmCustomer(xC);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void grfInv_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String addrId = "";
            addrId = grfInv[e.NewRange.r1, colInvId] != null ? grfInv[e.NewRange.r1, colInvId].ToString() : "";
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
        }
        private void grfExpn_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String addrId = "";
            addrId = grfInv[e.NewRange.r1, colInvId] != null ? grfInv[e.NewRange.r1, colInvId].ToString() : "";
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
        }
        private void grfInv_DoubleClick(object sender, EventArgs e)
        {
            String addrId = "";
            addrId = grfInv[grfInv.Row, colInvId].ToString();
        }
        private void setControlInv()
        {

        }
        //private void grdExpn_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        //{
        //    if (grdExpn.Sheets[0].Cells[e.Row, colInvId].Value == null) return;
        //    String expnId = grdExpn.Sheets[0].Cells[e.Row, colInvId].Value != null ? grdExpn.Sheets[0].Cells[e.Row, colInvId].Value.ToString() : "";
        //    JobImportExpn inv = new JobImportExpn();
        //    inv = xC.xtDB.jieDB.selectByPk1(expnId);
        //    //txtInvNo.Value = inv.inv_no;
        //    //txtInvDate1.Value = inv.invoice_date;
        //    //txtInvSuppNameT.Value = inv.SuppNameT;
        //    //txtJobIncoNameT.Value = inv.ictNameT;
        //    //txtInvAmt.Value = inv.amount;
        //    //InvTPayNameT.Value = inv.tpmNameT;
        //    //txtInvCurrNameT.Value = inv.currNameT;
        //    //txtInvRemark.Value = inv.remark;
        //}
        
        private int GetDropDownWidth(ComboBox combo)
        {
            object[] items = new object[combo.Items.Count];
            combo.Items.CopyTo(items, 0);
            return items.Select(obj => TextRenderer.MeasureText(combo.GetItemText(obj), combo.Font).Width).Max();
        }
        // add Html tooltips to items in a toolstrip
        //private void AddTipsToToolStrip(ToolStrip toolStrip)
        //{
        //    // do not show the default tooltips
        //    toolStrip.ShowItemToolTips = false;

        //    // att Html tooltips to each item in the toolStrip
        //    foreach (ToolStripItem item in toolStrip.Items)
        //    {
        //        // get tooltip text
        //        string text = item.ToolTipText;
        //        if (text != null && text.Length > 0)
        //        {
        //            // get tooltip image
        //            string image = string.Empty;
        //            if (item.Image != null)
        //            {
        //                string imageName = item.Name + ".Image";
        //                image = "res://" + imageName;
        //            }

        //            // build tip
        //            StringBuilder tip = new StringBuilder();
        //            tip.AppendFormat("<table><tr><td><img src='{0}'><td style='font:bold 11pt Tahoma'>{1}</table>",
        //                image,
        //                text);

        //            // append general 'get help' tip
        //            if (item != this.helpToolStripButton)
        //            {
        //                tip.Append("<hr noshade size=1 color=lightBlue>");
        //                tip.AppendFormat("<table><tr><td><img src='{0}'><td>{1}</table>",
        //                    "res://helpToolStripButton.Image",
        //                    "Press <b>F1</b> for more help.");
        //            }

        //            // assign tooltip to item
        //            sttCusNameT.SetToolTip(item, tip.ToString());
        //        }
        //    }
        //}
    }
}
