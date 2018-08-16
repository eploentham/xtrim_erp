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
    public partial class FrmExpenseDrawAppvView : Form
    {
        XtrimControl xC;
        ExpensesDraw expn;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colDesc = 3, colRemark = 4, colAmt = 5, colStatus = 6, colFlagForm=7, colStatusPay=8, cola=9;
        C1FlexGrid grfExpn;
        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "";

        public FrmExpenseDrawAppvView(XtrimControl x)
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
            chkAll.Click += ChkAll_Click;
            chkAppvOk.Click += ChkAppvOk_Click;
            chkAppvWait.Click += ChkAppvWait_Click;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;

            chkAll.Checked = true;
            xC.setCboYear(cboYear);
            initGrfDept();
            setGrfDeptH();

            chkAppvWait.Checked = true;
        }
        private void ChkAppvWait_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfDeptH();
        }

        private void ChkAppvOk_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfDeptH();
        }

        private void ChkAll_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfDeptH();
        }
        private void initGrfDept()
        {
            grfExpn = new C1FlexGrid();
            grfExpn.Font = fEdit;
            grfExpn.Dock = System.Windows.Forms.DockStyle.Fill;
            grfExpn.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfExpn);

            //grfExpn.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfDept_AfterRowColChange);
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);

            panel2.Controls.Add(grfExpn);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&อนุมัติ รายการเบิก", new EventHandler(ContextMenu_appv));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfExpn.ContextMenu = menuGw;

            theme1.SetTheme(grfExpn, "Office2013Red");
        }
        
        private void setGrfDeptH()
        {
            //grfDept.Rows.Count = 7;
            grfExpn.Clear();
            DataTable dt = new DataTable();
            dt = xC.accDB.expndDB.selectToPayAll1(cboYear.Text, chkAppvWait.Checked ? objdb.ExpensesDrawDB.StatusPay.waitappv : chkAppvOk.Checked ? objdb.ExpensesDrawDB.StatusPay.appv : objdb.ExpensesDrawDB.StatusPay.all, objdb.ExpensesDrawDB.StatusPayType.all);
            grfExpn.Cols.Count = 10;
            grfExpn.Rows.Count = 1;
            TextBox txt = new TextBox();

            grfExpn.Cols[colCode].Editor = txt;
            grfExpn.Cols[colDesc].Editor = txt;
            grfExpn.Cols[colRemark].Editor = txt;

            grfExpn.Cols[colCode].Width = 100;
            grfExpn.Cols[colDesc].Width = 200;
            grfExpn.Cols[colRemark].Width = 200;
            grfExpn.Cols[colAmt].Width = 80;
            grfExpn.Cols[colStatus].Width = 80;
            grfExpn.Cols[colFlagForm].Width = 80;
            grfExpn.Cols[colStatusPay].Width = 80;

            grfExpn.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfExpn.Cols[colCode].Caption = "เลขที่ใบเบิก";
            grfExpn.Cols[colDesc].Caption = "รายละเอียดใบเบิก";
            grfExpn.Cols[colRemark].Caption = "หมายเหตุ";
            grfExpn.Cols[colStatus].Caption = "สถานะ";
            grfExpn.Cols[colAmt].Caption = "รวมเงิน";
            grfExpn.Cols[colFlagForm].Caption = "การเบิก";
            grfExpn.Cols[colStatusPay].Caption = "การจ่าย";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Row row = grfExpn.Rows.Add();
                row[0] = (i+1);
                if (i % 2 == 0)
                    grfExpn.Rows[i+1].StyleNew.BackColor = color;
                row[colID] = dt.Rows[i][xC.accDB.expndDB.expnC.expenses_draw_id].ToString();
                row[cola] = dt.Rows[i][xC.accDB.expndDB.expnC.expenses_draw_id].ToString();
                row[colCode] = dt.Rows[i][xC.accDB.expndDB.expnC.expenses_draw_code].ToString();
                row[colDesc] = dt.Rows[i][xC.accDB.expndDB.expnC.desc1].ToString();
                row[colRemark] = dt.Rows[i][xC.accDB.expndDB.expnC.remark].ToString();
                row[colAmt] = dt.Rows[i][xC.accDB.expndDB.expnC.amount].ToString();
                if (dt.Rows[i][xC.accDB.expndDB.expnC.status_appv].ToString().Equals("1"))
                {
                    row[colStatus] = "รอออนุมัติ";
                }
                else if (dt.Rows[i][xC.accDB.expndDB.expnC.status_appv].ToString().Equals("2"))
                {
                    row[colStatus] = "อนุมัติแล้ว";
                }
                else if (dt.Rows[i][xC.accDB.expndDB.expnC.status_appv].ToString().Equals("0"))
                {
                    row[colStatus] = "ป้อนใหม่";
                }
                else
                {
                    row[colStatus] = "-";
                }
                if (dt.Rows[i][xC.accDB.expndDB.expnC.status_pay_type].ToString().Equals("1"))
                {
                    row[colFlagForm] = "Cash";
                }
                else if (dt.Rows[i][xC.accDB.expndDB.expnC.status_pay_type].ToString().Equals("2"))
                {
                    row[colFlagForm] = "Cheque";
                }
                else
                {
                    row[colFlagForm] = "-";
                }
                if (dt.Rows[i][xC.accDB.expndDB.expnC.status_pay].ToString().Equals("1"))
                {
                    row[colStatusPay] = "รอจ่าย";
                }
                else if (dt.Rows[i][xC.accDB.expndDB.expnC.status_pay].ToString().Equals("2"))
                {
                    row[colStatusPay] = "จ่ายแล้ว";
                }
                else
                {
                    row[colStatusPay] = "-";
                }
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfExpn.Cols[colID].Visible = false;
            grfExpn.Cols[cola].Visible = false;
        }
        //private void grfDept_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        //{
            
            
        //}
        private void ContextMenu_appv(object sender, System.EventArgs e)
        {
            if (grfExpn.Row == null) return;
            if (grfExpn.Row < 0) return;
            
            String deptId = "";
            xC.drawID = grfExpn[grfExpn.Row, cola] != null ? grfExpn[grfExpn.Row, cola].ToString() : "";
            ExpensesDraw expn = new ExpensesDraw();
            FrmExpenseDraw frm;
            expn = xC.accDB.expndDB.selectByPk1(xC.drawID);
            if (expn.status_pay_type.Equals("1"))
            {
                frm = new FrmExpenseDraw(xC, xC.drawID, FrmExpenseDraw.flagForm2.Cash, FrmExpenseDraw.flagAction.appv);
            }
            else
            {
                frm = new FrmExpenseDraw(xC, xC.drawID, FrmExpenseDraw.flagForm2.Cheque, FrmExpenseDraw.flagAction.appv);
            }
            //frm.drawId = xC.drawID;
            //frm.flagForm = "appv";
            frm.WindowState = FormWindowState.Normal;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);
        }
        private void FrmExpenseDrawAppvView_Load(object sender, EventArgs e)
        {

        }
    }
}
