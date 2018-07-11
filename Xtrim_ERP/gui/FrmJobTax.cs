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
    public partial class FrmJobTax : Form
    {
        XtrimControl xC;
        ExpensesPay expnp;
        Tax tax;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        int colTID = 1, colTItemNameT = 2, colTtaxdate = 3, colTAmt = 4, colTtaxamt = 5, colTitemid = 6, colTbtaxid = 7, colTbtaxnamet = 8, colTftaxid = 9;
        C1FlexGrid grfTax, grfTaxView;

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

            tax = new Tax();
            DateTime jobDate = DateTime.Now;
            txtPayerTaxDate.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");
            txtTaxDate.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");
            sB1.Text = "";

            initGrfTax();
            setGrfTax("");
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
                Decimal amt = 0, amttax = 0, rate = 3;
                if (Decimal.TryParse(grfTax[e.Row, e.Col] != null ? grfTax[e.Row, e.Col].ToString() : "0", out amt))
                {
                    String item = "", bname = "";
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
            txt.DataType = txtCusNameT.DataType;
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
            txt.DataType = txtCusNameT.DataType;
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
        private void FrmJobTax_Load(object sender, EventArgs e)
        {

        }
    }
}
