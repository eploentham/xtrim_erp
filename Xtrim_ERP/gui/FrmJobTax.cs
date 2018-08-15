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
    public partial class FrmJobTax : Form
    {
        XtrimControl xC;
        ExpensesPay expnp;
        JobImport jim;
        Tax tax;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        int colTID = 1, colTItemNameT = 2, colTtaxdate = 3, colTAmt = 4, colTtaxamt = 5, colTitemid = 6, colTbtaxid = 7, colTbtaxnamet = 8, colTftaxid = 9;
        int colVID = 1, colVCode = 2, colVCusNameT = 3, colVPayerNameT = 4, colVTaxDate=5, colCAmt=6;
        C1FlexGrid grfTax, grfTaxView, grfTaxJob;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "";

        public FrmJobTax(XtrimControl x)
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

            txtJobCode.KeyUp += TxtJobCode_KeyUp;
            btnTaxSave.Click += BtnTaxSave_Click;
            txtNum.ValueChanged += TxtNum_ValueChanged;
            txtPayerTaxNameT.KeyUp += TxtPayerTaxNameT_KeyUp;
            

            tax = new Tax();
            jim = new JobImport();
            DateTime jobDate = DateTime.Now;
            txtPayerTaxDate.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");
            txtTaxDate.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");
            sB1.Text = "";
            txtNum.Value = 1;

            initGrfTax();
            initGrfTaxJob();
            setGrfTax("");
        }

        private void TxtPayerTaxNameT_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.F2)
            {
                setKeyUpF2Payer();
            }
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
        private void setKeyUpF2Payer1(Customer cus)
        {
            Address addr = new Address();
            addr = xC.iniDB.addrDB.selectStatusTaxByCusId1(cus.cust_id);
            txtPayerTaxId.Value = cus.cust_id;
            txtPayerTaxNameT.Value = cus.cust_name_t;
            txtPayerTaxAddr.Value = addr.line_t1;
            txtPayerTaxTele.Value = cus.tele;
            txtPayerTaxTaxid.Value = cus.tax_id;
        }
        private void TxtNum_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfTax == null) return;
            if (grfTaxView == null) return;
            if (int.Parse(txtNum.Text) == 1)
            {
                grfTax.Enabled = false;
                grfTaxView.Enabled = false;
                theme1.SetTheme(grfTax, "Office2010Black");
                theme1.SetTheme(grfTaxView, "Office2010Black");
            }
            else
            {
                grfTax.Enabled = true;
                grfTaxView.Enabled = true;
                theme1.SetTheme(grfTaxView, "Office2010Red");
                theme1.SetTheme(grfTax, "Office2010Red");
            }
        }

        private void showGrfTaxView()
        {
            grfTaxView.Clear();
            setGrfTaxView();
            foreach (Row row in grfTax.Rows)
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
                    btax = xC.iniDB.btaxDB.selectByPk1(btaxid);
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
                Decimal amt = 0, tax = 0;
                foreach (Row row in grfTax.Rows)
                {
                    String btaxid = "";
                    Decimal amt1 = 0, tax1 = 0;
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
            tax.job_id = txtJobId.Text;
            tax.job_code = txtJobCode.Text.Replace(xC.FixJobCode,"");
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
            cus = xC.iniDB.cusDB.selectByPk1(tax.cust_id);
            addr = xC.iniDB.addrDB.selectStatusTaxByCusId1(cus.cust_id);
            tax.year_id = "";

            tax.cust_name_t = txtCusTaxNameT.Text;
            tax.cust_addr = addr.line_t1;
            tax.cust_tele = cus.tele;
            tax.cust_tax_id = cus.tax_id;

            tax.agent_id = txtAgentTaxId.Text;
            agent = xC.iniDB.cusDB.selectByPk1(tax.agent_id);
            agentaddr = xC.iniDB.addrDB.selectStatusTaxByCusId1(agent.cust_id);
            tax.agent_name_t = txtAgentTaxNameT.Text;
            tax.agent_addr = agentaddr.line_t1;
            tax.agent_tele = agent.tele;
            tax.agent_tax_id = agent.tax_id;

            tax.payer_id = txtPayerTaxId.Text;
            payer = xC.iniDB.cusDB.selectByPk1(tax.agent_id);
            payeraddr = xC.iniDB.addrDB.selectStatusTaxByCusId1(payer.cust_id);
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

            foreach (Row row in grfTax.Rows)
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
        private void BtnTaxSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                for(int i = 1; i < int.Parse(txtNum.Text); i++)
                {
                    setTax();
                    String re = xC.iniDB.taxDB.insertTax(tax, xC.user.staff_id);
                    int chk = 0, chkD = 0;
                    if (int.TryParse(re, out chk))
                    {
                        txtTaxId.Value = re;
                        btnTaxSave.Image = Resources.accept_database24;
                    }
                }
            }
        }

        private void TxtJobCode_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                txtJobCode.Text = txtJobCode.Text.Replace(xC.FixJobCode, "");
                jim = xC.manDB.jimDB.selectByJobCode(txtJobCode.Text);
                txtJobId.Value = jim.job_import_id;
                txtJobCode.Value = xC.FixJobCode + jim.job_import_code;
                Customer cus = new Customer();
                cus = xC.iniDB.cusDB.selectByPk1(jim.cust_id);
                txtCusTaxId.Value = cus.cust_id;
                txtCusTaxNameT.Value = cus.cust_name_t;
                Company cop = new Company();
                cop = xC.xtDB.copDB.selectByCode1("001");
                txtAgentTaxNameT.Value = cop.comp_name_t;
                txtAgentTaxId.Value = cop.comp_id;
                setGrfTaxJob(txtJobId.Text);
            }
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
            panel28.Controls.Add(grfTaxView);
            panel28.Controls.Add(grfTax);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfTax.ContextMenu = menuGw;
            grfTaxView.Hide();
            theme1.SetTheme(grfTax, "Office2010Silver");
            theme1.SetTheme(grfTax, "Office2010Red");
        }
        private void initGrfTaxJob()
        {
            grfTaxJob = new C1FlexGrid();
            grfTaxJob.Font = fEdit;
            grfTaxJob.Dock = System.Windows.Forms.DockStyle.Fill;
            grfTaxJob.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfView);            
            //grfTax.LeaveCell += GrfTax_LeaveCell;
            grfTaxJob.AfterEdit += GrfTax_AfterEdit;
            grfTaxJob.Cols.Count = 7;
            grfTaxJob.Rows.Count = 1;
            gbTax.Controls.Add(grfTaxJob);
            
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfTaxJob.ContextMenu = menuGw;
            

            theme1.SetTheme(grfTaxJob, "Office2010Blue");
        }
        private void GrfTax_AfterEdit(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Col == colTAmt)
            {
                Decimal amt = 0, amttax = 0, rate = 3;
                if (Decimal.TryParse(grfTax[e.Row, e.Col] != null ? grfTax[e.Row, e.Col].ToString() : "0", out amt))
                {
                    String item = "", bname = "";
                    item = grfTax[e.Row, colTItemNameT].ToString();
                    Items itm = new Items();
                    BTax btax = new BTax();
                    itm = xC.iniDB.itmDB.selectByNameT1(item);
                    if (!itm.tax_id.Equals(""))
                    {
                        btax = xC.iniDB.btaxDB.selectByPk1(itm.tax_id);
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
        private void setGrfTax(String expnpdid)
        {
            Company cop = new Company();
            cop = xC.xtDB.copDB.selectByCode1("001");
            DataTable dt = new DataTable();
            dt = xC.accDB.expnpdDB.selectPrintCheque(expnpdid);
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
            xC.iniDB.itmDB.setC1CboItem(cbo);
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
                grfTax[i + 1, colTItemNameT] = dt.Rows[i][xC.accDB.expnpdDB.expnP.pay_to_cus_name_t].ToString();
                grfTax[i + 1, colTtaxdate] = dt.Rows[i][xC.accDB.expnpdDB.expnP.pay_bank_date].ToString();
                grfTax[i + 1, colTAmt] = dt.Rows[i][xC.iniDB.copbDB.copB.comp_bank_name_t].ToString();
                grfTax[i + 1, colTtaxamt] = dt.Rows[i][xC.iniDB.copbDB.copB.comp_bank_branch].ToString();
                grfTax[i + 1, colTID] = dt.Rows[i][xC.iniDB.copbDB.copB.acc_number].ToString();
                grfTax[i + 1, colTitemid] = dt.Rows[i][xC.accDB.expnpdDB.expnP.pay_amount].ToString();
                grfTax[i + 1, colTbtaxid] = dt.Rows[i][xC.accDB.expnpdDB.expnP.pay_amount].ToString();
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
            xC.iniDB.itmDB.setC1CboItem(cbo);
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
        private void setGrfTaxJob(String jobId)
        {
            Company cop = new Company();
            cop = xC.xtDB.copDB.selectByCode1("001");
            DataTable dt = new DataTable();
            dt = xC.iniDB.taxDB.selectByJobId(jobId);
            grfTaxJob.Clear();
            grfTaxJob.Cols.Count = 7;

                //grfTaxJob.Rows.Count = 2;

            //grfChequeBnk.Cols.Count = 7;
            CellStyle cs = grfTax.Styles.Add("date");
            cs.DataType = typeof(DateTime);
            cs.Format = "dd-MM-yyyy";

            C1TextBox txt = new C1TextBox();
            txt.DataType = txtCusTaxNameT.DataType;
            //C1TextBox txt1 = new C1TextBox();
            //txt1.DataType = txtAmt.DataType;
            //C1ComboBox cbo = new C1ComboBox();
            ////xC.xtDB.itmDB.setC1CboItem(cbo);
            //C1TextBox txt2 = new C1TextBox();
            //txt2.DataType = txtTaxDate.DataType;

            grfTaxJob.Cols[colVCode].Editor = txt;
            grfTaxJob.Cols[colVCusNameT].Editor = txt;
            grfTaxJob.Cols[colVPayerNameT].Editor = txt;
            grfTaxJob.Cols[colVTaxDate].Editor = txt;
            grfTaxJob.Cols[colCAmt].Editor = txt;

            grfTaxJob.Cols[colVCode].Width = 100;
            grfTaxJob.Cols[colVCusNameT].Width = 200;
            grfTaxJob.Cols[colVPayerNameT].Width = 200;
            grfTaxJob.Cols[colVTaxDate].Width = 100;
            grfTaxJob.Cols[colCAmt].Width = 100;

            grfTaxJob.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfTaxJob.Cols[colVCode].Caption = "เลขที่ใบหักภาษี";
            grfTaxJob.Cols[colVCusNameT].Caption = "ชื่อลูกค้า";
            grfTaxJob.Cols[colVPayerNameT].Caption = "ผู้ถูกหักภาษี";
            grfTaxJob.Cols[colVTaxDate].Caption = "วันที่หักภาษี";
            grfTaxJob.Cols[colCAmt].Caption = "ภาษีหัก ณ ที่จ่าย";

            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Row row = grfTaxJob.Rows.Add();
                row[0] = i+1;
                if (i % 2 == 0)
                    row.StyleNew.BackColor = color;
                row[colVCode] = dt.Rows[i][xC.iniDB.taxDB.tax.tax_code].ToString();
                row[colVCusNameT] = dt.Rows[i][xC.iniDB.taxDB.tax.cust_name_t].ToString();
                row[colVPayerNameT] = dt.Rows[i][xC.iniDB.taxDB.tax.payer_name_t].ToString();
                row[colVTaxDate] = dt.Rows[i][xC.iniDB.taxDB.tax.tax_date].ToString();
                row[colCAmt] = dt.Rows[i][xC.iniDB.taxDB.tax.line6_tax].ToString();
                row[colVID] = dt.Rows[i][xC.iniDB.taxDB.tax.tax_id].ToString();
                
            }
            
            for (int i = 1; i < grfTaxJob.Rows.Count; i++)
            {
                
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfTaxJob.Cols[colVID].Visible = false;
            //grfTaxJob.Cols[colTitemid].Visible = false;
            //grfTaxJob.Cols[colTbtaxid].Visible = false;
            //grfTaxJob.Cols[colTftaxid].Visible = false;
        }
        private void FrmJobTax_Load(object sender, EventArgs e)
        {

        }
    }
}
