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
using Xtrim_ERP.Properties;

namespace Xtrim_ERP.gui
{
    public partial class FrmBilling : Form
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
        int colID = 1, colCode = 2, colDesc = 3, colRemark = 4, colAmt = 5, colStatus = 6;
        int colCID = 1, colCChk=2, colCSubNameT = 3, colCMtp = 4, colCItmNameT = 5, colCDrawDate = 6, colCAmt = 7, colCBank = 8, colCChequeNo = 9, colChequeDate = 10, colCChequepayname = 11, colCpayID = 12;
        int colBID = 1, colBItmNameT = 2, colBExpn=3,colBimcome=4,colBitmId=5, colBexpnddId=6;
        int colVBllDoc = 1, colVJobNo = 2, colVAmt = 3, colVbllId=4;

        C1FlexGrid grfJob, grfBill, grfDraw, grfCover;
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
            theme1.SetTheme(tC1, "Office2010Green");

            //btnNew.Click += BtnNew_Click;
            txtCusNameT1.KeyUp += TxtCusNameT1_KeyUp;
            btnCashOk.Click += BtnCashOk_Click;
            btnBNew.Click += BtnBNew_Click;
            btnBSave.Click += BtnBSave_Click;
            btnPrnRcp.Click += BtnPrnRcp_Click;
            btnPrnCover.Click += BtnPrnCover_Click;

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
            txtBIvat.Value = cop.vat;
            txtBEvat.Value = cop.vat;
            txtEvat.Value = cop.vat;

            stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;

            //chkAll.Checked = true;
            //xC.setCboYear(cboYear);
            initGrfJob();
            initGrfDrawView();
            initGrfBill();
            initGrfCover();
            tC1.SelectedTab = tabMake;
            tC2.SelectedTab = tabDraw;
            //setGrfDeptH();
        }
        
        private void setBilling()
        {
            bll = new Billing();
            Decimal amtE = 0, amtI = 0, amt=0;
            Decimal.TryParse(txtBEamt.Text.Replace("$", "").Replace(",", ""), out amtE);
            Decimal.TryParse(txtBIamt.Text.Replace("$", "").Replace(",", ""), out amtI);
            amt = amtE + amtI;
            bll.billing_id = "";
            bll.billing_code = xC.xtDB.copDB.genBillingDoc();
            bll.billing_date = xC.datetoDB(txtBillDate.Text);
            bll.job_id = txtJobId.Text;
            bll.job_code = txtJobCode.Text;
            bll.amount = amt.ToString();
            bll.active = "";
            bll.remark = txtRemark.Text;
            bll.date_create = "";
            bll.date_modi = "";
            bll.date_cancel = "";
            bll.user_create = "";
            bll.user_modi = "";
            bll.user_cancel = "";
            bll.cust_id = cus.cust_id;
        }
        private void setReceipt()
        {
            rcp = new Receipt();
            Decimal amtE = 0, amtI = 0, amt = 0;
            Decimal.TryParse(txtBEamt.Text.Replace("$", "").Replace(",", ""), out amtE);
            Decimal.TryParse(txtBIamt.Text.Replace("$", "").Replace(",", ""), out amtI);
            amt = amtE + amtI;

            rcp.receipt_id = "";
            rcp.receipt_code = xC.xtDB.copDB.genReceiptDoc();
            rcp.receipt_date = xC.datetoDB(txtBillDate.Text);
            rcp.job_id = txtJobId.Text;
            rcp.job_code = txtJobCode.Text;
            rcp.billing_id = txtBllId.Text;
            rcp.active = "1";
            rcp.remark = "";
            rcp.date_create = "";
            rcp.date_modi = "";
            rcp.date_cancel = "";
            rcp.user_create = "";
            rcp.user_modi = "";
            rcp.user_cancel = "";
            rcp.payment_id = "";
            rcp.payment_detail_id = "";
        }
        private void setBillingCover()
        {
            bllC = new BillingCover();
            bllC.billing_cover_id = "";
            bllC.billing_cover_code = xC.xtDB.copDB.genBillingCoverDoc();
            bllC.remark1 = txtRemark1.Text;
            bllC.remark2 = txtRemark2.Text;
            bllC.active = "1";
            bllC.remark = "";
            bllC.date_create = "";
            bllC.date_modi = "";
            bllC.date_cancel = "";
            bllC.user_create = "";
            bllC.user_modi = "";
            bllC.user_cancel = "";
            bllC.job_id = txtJobId.Text;
            bllC.cust_id = cus.cust_id;
        }
        private void BtnPrnCover_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setBillingCover();
                String re = xC.xtDB.bllcDB.insertBillingCover(bllC, xC.userId);
                int chk = 0, chkD = 0;
                if (int.TryParse(re, out chk))
                {
                    foreach (Row rowV in grfCover.Rows)
                    {
                        if (rowV[colVbllId] == null) continue;
                        String bllId = "";
                        bllId = rowV[colVbllId].ToString();
                        String re1 = "";
                        re1 = xC.xtDB.bllDB.updateBillingCover(bllId, bllC.billing_cover_code);
                        if (int.TryParse(re1, out chk))
                        {
                            chkD++;
                        }
                    }
                    if (chkD == (grfCover.Rows.Count - 1))
                    {
                        txtBllCover.Value = bllC.billing_cover_code;
                        btnPrnCover.Image = Resources.accept_database24;
                    }
                }
            }
        }
        private void BtnPrnRcp_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setReceipt();
                String re = xC.xtDB.rcpDB.insertReceipt(rcp, xC.userId);
                int chk = 0, chkD = 0;
                if (int.TryParse(re, out chk))
                {
                    foreach (Row rowB in grfBill.Rows)
                    {
                        if (rowB[colBitmId] == null) continue;
                        
                        Decimal amtE = 0, amtI = 0;
                        ReceiptDetail rcpD = new ReceiptDetail();
                        Decimal.TryParse(rowB[colBExpn] != null ? rowB[colBExpn].ToString() : "0", out amtE);
                        Decimal.TryParse(rowB[colBimcome] != null ? rowB[colBimcome].ToString() : "0", out amtI);
                        amtE += amtI;

                        rcpD.receipt_detail_id = "";
                        rcpD.receipt_id = rcp.receipt_id;
                        rcpD.item_id = rowB[colBitmId].ToString();
                        rcpD.job_id = jim.job_import_id;
                        rcpD.job_code = "";
                        rcpD.amount = amtE.ToString();
                        rcpD.active = "1";
                        rcpD.remark = "";
                        rcpD.date_create = "";
                        rcpD.date_modi = "";
                        rcpD.date_cancel = "";
                        rcpD.user_create = "";
                        rcpD.user_modi = "";
                        rcpD.user_cancel = "";
                        rcpD.item_name_t = rowB[colBItmNameT].ToString();
                        rcpD.qty = "0";
                        rcpD.price = "0";
                        rcpD.billing_detail_id = "";
                        String re1 = "";
                        re1 = xC.xtDB.rcpdDB.insertReceiptDetail(rcpD, xC.userId);
                        if (int.TryParse(re1, out chk))
                        {
                            chkD++;
                        }
                    }
                    if (chkD == (grfBill.Rows.Count - 1))
                    {
                        txtRcpCode.Value = rcp.receipt_code;
                        btnPrnRcp.Image = Resources.accept_database24;
                    }
                }
            }
        }
        private void BtnBSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setBilling();
                String re = xC.xtDB.bllDB.insertBilling(bll, xC.userId);
                int chk = 0, chkD=0;
                if (int.TryParse(re, out chk))
                {
                    txtBllId.Value = re;
                    foreach(Row rowB in grfBill.Rows)
                    {
                        if (rowB[colBitmId] == null) continue;
                        BillingDetail blld = new BillingDetail();
                        blld.billing_id = re;
                        blld.billing_detail_id = "";
                        blld.expenses_draw_detail_id = rowB[colBexpnddId] != null ? rowB[colBexpnddId].ToString() : "";
                        blld.item_id = rowB[colBitmId].ToString();
                        blld.item_name_t = rowB[colBItmNameT].ToString();
                        blld.amount_draw = rowB[colBExpn] != null ? rowB[colBExpn].ToString() : "0";
                        blld.active = "";
                        blld.remark = "";
                        blld.date_create = "";
                        blld.date_modi = "";
                        blld.date_cancel = "";
                        blld.user_create = "";
                        blld.user_modi = "";
                        blld.user_cancel = "";
                        blld.amount_income = rowB[colBimcome] != null ? rowB[colBimcome].ToString() : "0";
                        String re1 = "";
                        re1 = xC.xtDB.blldDB.insertBillingDetail(blld, xC.userId);
                        if (int.TryParse(re1, out chk))
                        {
                            chkD++;

                            Debtor dtr = new Debtor();
                            dtr.debtor_id = "";
                            dtr.cus_id = cus.cust_id;
                            if (!blld.amount_income.Equals("0"))
                            {
                                dtr.amount = blld.amount_income;
                            }
                            else if (!blld.amount_draw.Equals("0"))
                            {
                                dtr.amount = blld.amount_draw;
                            }
                            else
                            {
                                dtr.amount = "0";
                            }
                            
                            dtr.billing_detail_id = re1;
                            dtr.payment_detail_id = "";
                            dtr.job_id = jim.job_import_id;
                            dtr.remark = "";
                            dtr.status_debtor = "1";
                            dtr.comp_id = cop.comp_id;
                            xC.xtDB.dtrDB.insertDebtor(dtr, xC.userId);
                        }
                    }
                    if (chkD == (grfBill.Rows.Count-1))
                    {
                        txtBllCode.Value = bll.billing_code;
                        Row row = grfCover.Rows.Add();
                        row[colVBllDoc] = bll.billing_code;
                        row[colVJobNo] = bll.job_code;
                        row[colVAmt] = bll.amount;
                        row[colVbllId] = txtBllId.Value;

                        btnBSave.Image = Resources.accept_database24;
                    }
                }
                else
                {
                    btnBSave.Image = Resources.accept_database24;
                }
                
            }
        }

        private void BtnBNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmExpenseDrawD frm = new FrmExpenseDrawD(xC, "", "", "", "", "",FrmExpenseDrawD.StatusPage.AppvPay,  FrmExpenseDrawD.StatusPayType.All);
            frm.ShowDialog(this);
            setRowGrfBill(xC.sItm);
            calAmtGrfBill();
            //setExpnDD(0, "");
        }

        private void BtnCashOk_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfBill.Clear();
            grfBill.Rows.Count = 1;
            grfBill.Cols[colBItmNameT].Width = 220;
            grfBill.Cols[colBExpn].Width = 100;
            grfBill.Cols[colBimcome].Width = 100;
            //grfBill.Cols[colCDrawDate].Width = 100;
            //grfBill.Cols[colCAmt].Width = 100;
            grfBill.Cols[colBItmNameT].Caption = "รายการ";
            grfBill.Cols[colBExpn].Caption = "ค่าใช้จ่าย";
            grfBill.Cols[colBimcome].Caption = "รายได้";
            grfBill.Cols[colBID].Visible = false;
            foreach ( Row rowD in grfDraw.Rows)
            {
                if (rowD[colCChk] == null) continue;
                if ((Boolean)rowD[colCChk])
                {
                    String ddid = "";
                    ExpensesDrawDatail expndd = new ExpensesDrawDatail();
                    Items itm = new Items();
                    ItemsType itmt = new ItemsType();
                    ItemsTypeSub itmts = new ItemsTypeSub();
                    ddid = rowD[colCID].ToString();
                    expndd = xC.xtDB.expnddDB.selectByPk1(ddid);
                    itm = xC.xtDB.itmDB.selectByPk1(expndd.item_id);
                    if (itm.item_group_id.Equals(""))
                    {
                        itmts = xC.xtDB.itmtsDB.selectByPk1(itm.item_type_sub_id);
                        itmt = xC.xtDB.itmtDB.selectByPk1(itmts.item_type_id);
                        itm.item_group_id = itmt.item_group_id;
                    }
                    itm.item_name_t = rowD[colCItmNameT].ToString();
                    itm.amt = rowD[colCAmt].ToString();
                    itm.cust_id = expndd.expenses_draw_detail_id;       //ฝาก 
                    setRowGrfBill(itm);

                }
            }
            calAmtGrfBill();
            tC2.SelectedTab = tabBill;
        }
        private void setRowGrfBill(Items itm)
        {
            if (itm.item_name_t == null) return;
            Row rowB = grfBill.Rows.Add();
            rowB[colBID] = "";
            rowB[colBitmId] = itm.item_id;
            rowB[colBItmNameT] = itm.item_name_t;
            rowB[colBexpnddId] = itm.cust_id;
            if (itm.item_group_id.Equals("1540000001"))
            {
                rowB[colBExpn] = itm.amt;
            }
            else if (itm.item_group_id.Equals("1540000000"))
            {
                rowB[colBimcome] = itm.amt;
            }
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
            panel4.Controls.Add(grfJob);
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
            dt = xC.xtDB.jimDB.selectJimJblByJobYear2(cusid);
            //grfJob.DataSource = xC.xtDB.jimDB.selectJimJblByJobYear2(cusid);
            //grfJob.Cols.Count = dt.Columns.Count;
            grfJob.Rows.Count = dt.Rows.Count+1;

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
                grfJob[i+1, 0] = i;
                if (i % 2 == 0)
                    grfJob.Rows[i].StyleNew.BackColor = color;
                grfJob[i + 1, colID] = dt.Rows[i][xC.xtDB.jimDB.jim.job_import_id].ToString();
                grfJob[i + 1, colCode] = dt.Rows[i][xC.xtDB.jimDB.jim.job_import_code].ToString();
                grfJob[i + 1, colDesc] = dt.Rows[i][xC.xtDB.jblDB.jbl.description].ToString();
                grfJob[i + 1, colRemark] = dt.Rows[i][xC.xtDB.jimDB.jim.remark1].ToString();
                //grfJob[i + 1, colAmt] = dt.Rows[i][xC.xtDB.jimDB.jim.job_import_id].ToString();
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
            grfBill.Rows.Count = 1;
            grfBill.Cols[colBItmNameT].Width = 220;
            grfBill.Cols[colBExpn].Width = 100;
            grfBill.Cols[colBimcome].Width = 100;
            //grfBill.Cols[colCDrawDate].Width = 100;
            //grfBill.Cols[colCAmt].Width = 100;
            grfBill.Cols[colBItmNameT].Caption = "รายการ";
            grfBill.Cols[colBExpn].Caption = "ค่าใช้จ่าย";
            grfBill.Cols[colBimcome].Caption = "รายได้";
            //grfBill.Cols[colCDrawDate].Caption = "วันที่";
            //grfBill.Cols[colCAmt].Caption = "รวมเงิน";

            panel12.Controls.Add(grfBill);

            theme1.SetTheme(grfBill, "VS2013Red");
            grfBill.Cols[colBID].Visible = false;
        }
        private void initGrfDrawView()
        {
            grfDraw = new C1FlexGrid();
            grfDraw.Font = fEdit;
            grfDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDraw.Location = new System.Drawing.Point(0, 0);
            //FilterRow fr = new FilterRow(grfView);            
            grfDraw.Rows.Count = 2;
            grfDraw.Cols[colCChk].Width = 50;
            grfDraw.Cols[colCSubNameT].Width = 220;
            grfDraw.Cols[colCMtp].Width = 80;
            grfDraw.Cols[colCItmNameT].Width = 220;
            grfDraw.Cols[colCDrawDate].Width = 100;
            grfDraw.Cols[colCAmt].Width = 100;
            grfDraw.Cols[colCSubNameT].Caption = "ประเภทย่อย";
            grfDraw.Cols[colCMtp].Caption = "วิธีการจ่าย";
            grfDraw.Cols[colCItmNameT].Caption = "รายการ";
            grfDraw.Cols[colCDrawDate].Caption = "วันที่";
            grfDraw.Cols[colCAmt].Caption = "รวมเงิน";

            grfDraw.CellChecked += GrfDraw_CellChecked;

            panel9.Controls.Add(grfDraw);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDraw.ContextMenu = menuGw;

            theme1.SetTheme(grfDraw, "Office2013Red");

        }
        private void initGrfCover()
        {
            grfCover = new C1FlexGrid();
            grfCover.Font = fEdit;
            grfCover.Dock = System.Windows.Forms.DockStyle.Fill;
            grfCover.Location = new System.Drawing.Point(0, 0);
            grfCover.Rows.Count = 1;
            grfCover.Cols.Count = 5;
            grfCover.Cols[colVBllDoc].Width = 220;
            grfCover.Cols[colVJobNo].Width = 100;
            grfCover.Cols[colVAmt].Width = 100;
            //grfBill.Cols[colCDrawDate].Width = 100;
            //grfBill.Cols[colCAmt].Width = 100;
            grfCover.Cols[colVBllDoc].Caption = "เลขที่ใบวางบิล";
            grfCover.Cols[colVJobNo].Caption = "job no";
            grfCover.Cols[colVAmt].Caption = "จำนวนเงิน";
            //grfBill.Cols[colCDrawDate].Caption = "วันที่";
            //grfBill.Cols[colCAmt].Caption = "รวมเงิน";

            panel15.Controls.Add(grfCover);

            theme1.SetTheme(grfCover, "Windows8Blue");
            //grfCover.Cols[colBID].Visible = false;
        }
        private void GrfDraw_CellChecked(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            calAmtGrfDraw();
        }
        private void calAmtGrfDraw()
        {
            Decimal amtE = 0, amtI = 0;
            foreach (Row rowD in grfDraw.Rows)
            {
                Decimal amt = 0;
                if (rowD[colCChk] == null) continue;
                if ((Boolean)rowD[colCChk])
                {
                    Decimal.TryParse(rowD[colCAmt].ToString(), out amt);
                    amtE += amt;
                }
            }
            txtEamt.Value = amtE;
        }
        private void calAmtGrfBill()
        {
            Decimal amtE = 0, amtI = 0;
            foreach (Row rowB in grfBill.Rows)
            {
                Decimal amt = 0, amt1=0;
                
                if (rowB[colBExpn] != null)
                {
                    Decimal.TryParse(rowB[colBExpn].ToString(), out amt);
                    amtE += amt;
                }
                if (rowB[colBimcome] != null)
                {
                    Decimal.TryParse(rowB[colBimcome].ToString(), out amt1);
                    amtI += amt1;
                }
            }
            txtBEamt.Value = amtE;
            txtBIamt.Value = amtI;
            txtBInettotal.Value = amtI + (amtI * (Decimal.Parse(txtBIvat.Value.ToString()) / 100));
        }

        private void setGrfDrawView(String jimId)
        {
            grfDraw.Clear();
            //grfDept.Rows.Count = 7;
            DataTable dt = new DataTable();
            dt = xC.xtDB.expnddDB.selectAllAppvByJobId(jimId);
            //grfChequeView1.DataSource = dt;
            grfDraw.Cols.Count = dt.Columns.Count + 2;
            grfDraw.Rows.Count = dt.Rows.Count + 1;
            TextBox txt = new TextBox();
            //CheckBox chk = new CheckBox();
            CellStyle chk;
            chk = grfDraw.Styles.Add("bool");
            chk.DataType = typeof(bool);
            chk.TextAlign = TextAlignEnum.LeftCenter;
            chk.UserData = "เลือก";

            grfDraw.Cols[colCChk].Style = chk;
            grfDraw.Cols[colCSubNameT].Editor = txt;
            grfDraw.Cols[colCMtp].Editor = txt;
            grfDraw.Cols[colCItmNameT].Editor = txt;

            grfDraw.Cols[colCSubNameT].Width = 220;
            grfDraw.Cols[colCMtp].Width = 80;
            grfDraw.Cols[colCItmNameT].Width = 220;
            grfDraw.Cols[colCDrawDate].Width = 100;
            grfDraw.Cols[colCAmt].Width = 100;

            grfDraw.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDraw.Cols[colCSubNameT].Caption = "ประเภทย่อย";
            grfDraw.Cols[colCMtp].Caption = "วิธีการจ่าย";
            grfDraw.Cols[colCItmNameT].Caption = "รายการ";
            grfDraw.Cols[colCDrawDate].Caption = "วันที่";
            grfDraw.Cols[colCAmt].Caption = "รวมเงิน";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                grfDraw[i + 1, 0] = i+1;
                if (i % 2 == 0)
                    grfDraw.Rows[i + 1].StyleNew.BackColor = color;
                grfDraw[i + 1, colCID] = dt.Rows[i][xC.xtDB.expnddDB.expnC.expenses_draw_detail_id].ToString();
                grfDraw[i + 1, colCChk] = "เลือก";
                grfDraw[i + 1, colCSubNameT] = dt.Rows[i][xC.xtDB.itmtsDB.itmtS.item_type_sub_name_t].ToString();
                grfDraw[i + 1, colCMtp] = dt.Rows[i][xC.xtDB.fmtpDB.fmtp.method_payment_name_t].ToString();
                grfDraw[i + 1, colCItmNameT] = dt.Rows[i][xC.xtDB.itmDB.itm.item_name_t].ToString();
                grfDraw[i + 1, colCAmt] = dt.Rows[i][xC.xtDB.expnddDB.expnC.pay_amount].ToString();
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfDraw.Cols[colCID].Visible = false;
        }
        private void GrfJob_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            cus = xC.sCus;
            jim = new JobImport();
            jim = xC.xtDB.jimDB.selectByPk1(grfJob[grfJob.Row, colID].ToString());
            txtJobId.Value = jim.job_import_id;
            txtCusNameT.Value = cus.cust_name_t;
            txtJobCode.Value = jim.job_import_code;
            tC2.SelectedTab = tabDraw;
            setGrfDrawView(jim.job_import_id);
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
                    setGrfJob(cusId);
                }
            }
        }

        private void FrmBilling_Load(object sender, EventArgs e)
        {

        }
    }
}
