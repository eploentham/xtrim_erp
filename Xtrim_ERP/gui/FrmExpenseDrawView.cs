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
    public partial class FrmExpenseDrawView : Form
    {
        XtrimControl xC;
        MainMenu4 menu;
        ExpensesDraw expn;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colDesc = 3, colRemark = 4, colAmt = 5, colStatus = 6;
        C1FlexGrid grfExpn;
        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "", flagForm="";
        public enum flagForm2 { Cash, Cheque };
        flagForm2 flagfom2;

        public FrmExpenseDrawView(XtrimControl x, MainMenu4 m, flagForm2 flagform)
        {
            InitializeComponent();
            xC = x;
            menu = m;
            flagfom2 = flagform;
            initConfig();
        }
        private void initConfig()
        {            
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");

            btnNew.Click += BtnNew_Click;
            chkAll.Click += ChkAll_Click;
            chkAppvOk.Click += ChkAppvOk_Click;
            chkAppvWait.Click += ChkAppvWait_Click;

            sB1.Text = "";

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;

            chkAll.Checked = true;
            xC.setCboYear(cboYear);
            initGrfDept();
            setGrfDeptH();
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
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfExpn.ContextMenu = menuGw;
            panel2.Controls.Add(grfExpn);

            theme1.SetTheme(grfExpn, "Office2013Red");
        }
        private void setGrfDeptH()
        {
            //grfDept.Rows.Count = 7;
            grfExpn.Clear();
            DataTable dt = new DataTable();
            if (chkAll.Checked)
            {
                dt = xC.xtDB.expndDB.selectAll1(cboYear.Text, objdb.ExpensesDrawDB.StatusPay.all);
            }
            else if (chkAppvWait.Checked)
            {
                dt = xC.xtDB.expndDB.selectAll1(cboYear.Text, objdb.ExpensesDrawDB.StatusPay.waitappv);
            }
            else if (chkAppvOk.Checked)
            {
                dt = xC.xtDB.expndDB.selectAll1(cboYear.Text, objdb.ExpensesDrawDB.StatusPay.appv);
            }
            //grfExpn.DataSource = xC.xtDB.expndDB.selectAll1(cboYear.Text);
            grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfExpn.Cols.Count = 7;
            TextBox txt = new TextBox();

            grfExpn.Cols[colCode].Editor = txt;
            grfExpn.Cols[colDesc].Editor = txt;
            grfExpn.Cols[colRemark].Editor = txt;

            grfExpn.Cols[colCode].Width = 100;
            grfExpn.Cols[colDesc].Width = 200;
            grfExpn.Cols[colRemark].Width = 200;
            grfExpn.Cols[colAmt].Width = 80;
            grfExpn.Cols[colStatus].Width = 80;

            grfExpn.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfExpn.Cols[colCode].Caption = "เลขที่ใบเบิก";
            grfExpn.Cols[colDesc].Caption = "รายละเอียดใบเบิก";
            grfExpn.Cols[colRemark].Caption = "หมายเหตุ";
            grfExpn.Cols[colStatus].Caption = "สถานะ";
            grfExpn.Cols[colAmt].Caption = "รวมเงิน";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfExpn[i, 0] = i;
                if (i % 2 == 0)
                    grfExpn.Rows[i].StyleNew.BackColor = color;
                grfExpn[i + 1, colID] = dt.Rows[i][xC.xtDB.expndDB.expnC.expenses_draw_id].ToString();
                grfExpn[i + 1, colCode] = dt.Rows[i][xC.xtDB.expndDB.expnC.expenses_draw_code].ToString();
                grfExpn[i + 1, colDesc] = dt.Rows[i][xC.xtDB.expndDB.expnC.desc1].ToString();
                grfExpn[i + 1, colRemark] = dt.Rows[i][xC.xtDB.expndDB.expnC.remark].ToString();
                grfExpn[i + 1, colAmt] = dt.Rows[i][xC.xtDB.expndDB.expnC.amount].ToString();
                if (dt.Rows[i][xC.xtDB.expndDB.expnC.status_appv].ToString().Equals("1"))
                {
                    grfExpn[i + 1, colStatus] = "รอออนุมัติ";
                }
                else if (dt.Rows[i][xC.xtDB.expndDB.expnC.status_appv].ToString().Equals("2"))
                {
                    grfExpn[i + 1, colStatus] = "อนุมัติแล้ว";
                }
                else if (dt.Rows[i][xC.xtDB.expndDB.expnC.status_appv].ToString().Equals("0"))
                {
                    grfExpn[i + 1, colStatus] = "ป้อนใหม่";
                }
                else
                {
                    grfExpn[i + 1, colStatus] = "-";
                }
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfExpn.Cols[colID].Visible = false;
        }
        //private void grfDept_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        //{
            
        //}
        private void ContextMenu_edit(object sender, System.EventArgs e)
        {
            if (grfExpn.Row == null) return;
            if (grfExpn.Row < 0) return;

            String deptId = "";
            xC.drawID = grfExpn[grfExpn.Row, colID] != null ? grfExpn[grfExpn.Row, colID].ToString() : "";
            FrmExpenseDraw frm = new FrmExpenseDraw(xC, xC.drawID, (FrmExpenseDraw.flagForm2)flagfom2, FrmExpenseDraw.flagAction.draw);
            //frm.drawId = xC.drawID;
            //frm.flagForm = "view";
            //frm.ShowDialog(this);
            String txt = "";
            if (flagfom2 == flagForm2.Cash)
            {
                txt = "ใบเบิกเงิน จ่ายพนักงาน(เงินสด) ป้อนใหม่";
            }
            else
            {
                txt = "ใบเบิกเงิน จ่ายพนักงาน(cheque) ป้อนใหม่";
            }
            frm.FormBorderStyle = FormBorderStyle.None;
            menu.AddNewTab(frm, txt + xC.drawID);
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            xC.drawID = "";
            FrmExpenseDraw frm = new FrmExpenseDraw(xC, "", (FrmExpenseDraw.flagForm2)flagfom2, FrmExpenseDraw.flagAction.draw);
            //frm.drawId = "";
            //frm.flagForm = "new";
            //frm.ShowDialog(this);
            //frm.WindowState = FormWindowState.Normal;
            //frm.StartPosition = FormStartPosition.CenterScreen;
            String txt = "";
            if (flagfom2 == flagForm2.Cash)
            {
                txt = "ใบเบิกเงิน จ่ายพนักงาน(เงินสด) ป้อนใหม่";
            }
            else
            {
                txt = "ใบเบิกเงิน จ่ายพนักงาน(cheque) ป้อนใหม่";
            }
            frm.FormBorderStyle = FormBorderStyle.None;
            menu.AddNewTab(frm, txt);
        }
        private void FrmExpenseDrawView_Load(object sender, EventArgs e)
        {
            
            
        }
    }
}
