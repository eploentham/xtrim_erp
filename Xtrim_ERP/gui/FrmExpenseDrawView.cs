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
        String userIdVoid = "";

        public FrmExpenseDrawView(XtrimControl x)
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

            btnNew.Click += BtnNew_Click;

            sB1.Text = "";

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;

            chkAll.Checked = true;
            xC.setCboYear(cboYear);
            initGrfDept();
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
            grfExpn.DataSource = xC.xtDB.expndDB.selectAll1(cboYear.Text);
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
            for (int i = 1; i < grfExpn.Rows.Count; i++)
            {
                grfExpn[i, 0] = i;
                if (i % 2 == 0)
                    grfExpn.Rows[i].StyleNew.BackColor = color;
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
            FrmExpenseDraw frm = new FrmExpenseDraw(xC, xC.drawID, "view");
            //frm.drawId = xC.drawID;
            //frm.flagForm = "view";
            frm.ShowDialog(this);
            frm.WindowState = FormWindowState.Normal;
            frm.StartPosition = FormStartPosition.CenterScreen;
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            xC.drawID = "";
            FrmExpenseDraw frm = new FrmExpenseDraw(xC, "", "new");
            //frm.drawId = "";
            //frm.flagForm = "new";
            frm.ShowDialog(this);
            frm.WindowState = FormWindowState.Normal;
            frm.StartPosition = FormStartPosition.CenterScreen;
        }
        private void FrmExpenseDrawView_Load(object sender, EventArgs e)
        {
            
            
        }
    }
}
