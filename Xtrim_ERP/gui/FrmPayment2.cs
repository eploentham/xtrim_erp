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
    public partial class FrmPayment2 : Form
    {
        XtrimControl xC;
        C1FlexGrid grfJob, grfBill, grfBillD, grfPay;

        Company cop;
        Customer cus;
        JobImport jim;
        Billing bll;
        Payment pyt;
        Font fEdit, fEditB;

        int colID = 1, colCode = 2, colDesc = 3, colRemark = 4, colAmt = 5, colStatus = 6;
        int colBID = 1, colBDocNo = 2, colBAmt = 3, colBBillDate = 4, colBremark = 5;
        int colBdID = 1, colBdNameT = 2, colBdAmtD = 3, colBdAmtI = 4;
        int colPdID = 1, colPdJobNo=2, colPdBillDoc = 3, colPdItmNameT = 4, colPdAmtE = 5, colPdAmtI=6, colPdDbID=7, colPdJobId=8, colPdItmId=9, colPdBllId=10, colPdBlldId=11;
        Color bg, fc;
        Font ff, ffB;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "", cusId = "";
        enum flagModule {Job, Cus };

        public FrmPayment2(XtrimControl x)
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

            DateTime pytDate = DateTime.Now;
            txtPytDate.Value = pytDate.Year.ToString() + "-" + pytDate.ToString("MM-dd");

            btnSave.Click += BtnSave_Click;

            sB1.Text = "";
            cop = new Company();
            cop = xC.xtDB.copDB.selectByCode1("001");
            //bll = new Billing();
            cus = new Customer();
            jim = new JobImport();
            bll = new Billing();
            pyt = new Payment();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            txtCusNameT.KeyUp += TxtCusNameT_KeyUp;

            initGrfJob();
            initGrfBill();
            initGrfBillD();
            initGrfPay();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Boolean chk1 = setPayment();
            if(chk1 == false)
            {
                MessageBox.Show("", "Error");
                return;
            }
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String re = "";
                re = xC.accDB.pytDB.insertPayment(pyt, xC.userId);
                int chk = 0, chkD = 0;
                if (int.TryParse(re, out chk))
                {
                    foreach (Row rowB in grfPay.Rows)
                    {
                        if (rowB[colPdID] == null) continue;
                        Decimal amtE = 0, amtI = 0;
                        PaymentDetail pytd = new PaymentDetail();
                        Decimal.TryParse(rowB[colPdAmtE].ToString(), out amtE);
                        Decimal.TryParse(rowB[colPdAmtI].ToString(), out amtI);
                        amtE += amtI;
                        pytd.payment_detail_id = "";
                        pytd.payment_id = re;
                        pytd.billing_id = rowB[colPdBllId].ToString();
                        pytd.job_id = rowB[colPdJobId].ToString();
                        pytd.job_code = rowB[colPdJobNo].ToString();
                        pytd.amount = amtE.ToString();
                        pytd.active = "1";
                        pytd.remark = "";
                        pytd.date_create = "";
                        pytd.date_modi = "";
                        pytd.date_cancel = "";
                        pytd.user_create = "";
                        pytd.user_modi = "";
                        pytd.user_cancel = "";
                        pytd.billing_detail_id = rowB[colPdBlldId].ToString();
                        String re1 = "";
                        re1 = xC.accDB.pytdDB.insertPaymentDetail(pytd, xC.userId);
                        if (int.TryParse(re1, out chk))
                        {
                            chkD++;
                            Debtor dtr = new Debtor();
                            dtr.debtor_id = "";
                            dtr.cus_id = cus.cust_id;
                            if (!pytd.amount.Equals("0"))
                            {
                                dtr.amount = pytd.amount;
                            }
                            else
                            {
                                dtr.amount = "0";
                            }

                            dtr.billing_detail_id = "";
                            dtr.payment_detail_id = re1;
                            dtr.job_id = pytd.job_id;
                            dtr.remark = "";
                            dtr.status_debtor = "2";        // รับชำระ
                            dtr.comp_id = cop.comp_id;
                            xC.accDB.dtrDB.insertDebtor(dtr, xC.userId);
                        }
                    }
                }
            }
            
        }
        private Boolean setPayment()
        {
            Boolean chk = true;
            pyt.payment_id = "";
            pyt.payment_code = "";
            pyt.payment_date = xC.datetoDB(txtPytDate.Text);
            pyt.job_id = "";
            pyt.job_code = "";
            pyt.amount = txtAmt.Text.Replace("$","").Replace(",","");
            pyt.active = "1";
            pyt.remark = txtRemark.Text;
            pyt.date_create = "";
            pyt.date_modi = "";
            pyt.date_cancel = "";
            pyt.user_create = "";
            pyt.user_modi = "";
            pyt.user_cancel = "";
            pyt.status_pay_type = "";
            pyt.cust_id = cus.cust_id;

            if (pyt.cust_id == null || pyt.cust_id.Equals(""))
            {
                chk = false;
            }
            return chk;
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

            setGrfBillView(jim.job_import_id, flagModule.Job);
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

            panelBll.Controls.Add(grfBill);

            theme1.SetTheme(grfBill, "VS2013Green");
            grfBill.Cols[colBID].Visible = false;
        }
        private void setGrfBillView(String jimId, flagModule flag)
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
            if (flag == flagModule.Job)
            {
                dt = xC.accDB.bllDB.selectByJobId(jimId);
            }
            else
            {
                dt = xC.accDB.bllDB.selectByCusId(jimId);
            }
            
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
            grfBillD.DoubleClick += GrfBillD_DoubleClick;
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
                    setGrfBillView(cusId, flagModule.Cus);
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
        private void initGrfPay()
        {
            grfPay = new C1FlexGrid();
            grfPay.Font = fEdit;
            grfPay.Dock = System.Windows.Forms.DockStyle.Fill;
            grfPay.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpnD);

            //grfJob.AfterRowColChange += GrfJob_AfterRowColChange;
            grfPay.DoubleClick += GrfJob_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //grfJob.CellChanged += GrfExpnD_CellChanged;
            panelPay.Controls.Add(grfPay);
            grfPay.Clear();
            grfPay.Rows.Count = 1;
            grfPay.Cols.Count = 12;
            grfPay.Cols[colPdJobNo].Width = 80;
            grfPay.Cols[colPdBillDoc].Width = 100;
            grfPay.Cols[colPdItmNameT].Width = 250;
            grfPay.Cols[colPdAmtE].Width = 100;
            grfPay.Cols[colPdAmtI].Width = 100;
            grfPay.Cols[colPdJobNo].Caption = "job no";
            grfPay.Cols[colPdBillDoc].Caption = "เลขที่ ใบวางบิล";
            grfPay.Cols[colPdItmNameT].Caption = "รายการ";
            grfPay.Cols[colPdAmtE].Caption = "ค่าใช้จ่าย";
            grfPay.Cols[colPdAmtI].Caption = "รายได้";
            grfPay.Cols[colPdID].Visible = false;
            grfPay.Cols[colPdDbID].Visible = false;
            grfPay.Cols[colPdJobId].Visible = false;
            grfPay.Cols[colPdItmId].Visible = false;
            //grfPay.Cols[colPdBlldId].Visible = false;
            //grfPay.Cols[colPdBllId].Visible = false;

            theme1.SetTheme(grfPay, "ShinyBlue");
        }
        private void GrfBillD_DoubleClick(object sender, EventArgs e)
        {
            if (grfBillD[grfBillD.Row, colBdID] == null) return;
            String blldId = "";
            blldId = grfBillD[grfBillD.Row, colBdID] != null ? grfBillD[grfBillD.Row, colBdID].ToString() : "";
            
            setRowGrfPay(blldId);
        }
        private void setRowGrfPay(String blldid)
        {
            if (blldid == null) return;
            if (blldid.Equals("")) return;
            BillingDetail blld = new BillingDetail();
            Billing bll = new Billing();
            blld = xC.accDB.blldDB.selectByPk1(blldid);
            bll = xC.accDB.bllDB.selectByPk1(blld.billing_id);
            Row rowB = grfPay.Rows.Add();
            rowB[0] = grfPay.Rows.Count-1;
            rowB[colPdID] = "";
            rowB[colPdJobNo] = bll.job_code;
            rowB[colPdJobId] = bll.job_id;
            rowB[colPdBillDoc] = blld.item_name_t;
            rowB[colPdItmNameT] = blld.item_name_t;
            rowB[colPdItmId] = blld.item_id;
            rowB[colPdAmtE] = blld.amount_draw;
            rowB[colPdBillDoc] = bll.billing_code;
            rowB[colPdAmtI] = blld.amount_income;
            rowB[colPdBlldId] = blld.billing_detail_id;
            rowB[colPdBllId] = blld.billing_id;
            calAmt();
        }
        private void calAmt()
        {
            Decimal amt = 0, chk = 0;
            for(int i = 1; i < grfPay.Rows.Count; i++)
            {
                String chk1 = "";
                chk1 = grfPay[i, colPdAmtE] != null ? grfPay[i, colPdAmtE].ToString() : "0";
                if(Decimal.TryParse(chk1, out chk))
                {
                    amt += chk;
                }
                chk1 = grfPay[i, colPdAmtI] != null ? grfPay[i, colPdAmtI].ToString() : "0";
                if (Decimal.TryParse(chk1, out chk))
                {
                    amt += chk;
                }
            }
            txtAmt.Value = amt;
        }
        private void FrmPayment2_Load(object sender, EventArgs e)
        {

        }
    }
}
