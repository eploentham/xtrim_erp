using C1.Win.C1FlexGrid;
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

namespace Xtrim_ERP.gui
{
    public partial class FrmDepartment1 : Form
    {
        XtrimControl xC;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colName = 3, colRemark = 4, colE = 5, colS = 6, coledit = 7, colCnt = 7;

        C1FlexGrid grfDept;
        C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();        

        public FrmDepartment1(XtrimControl x)
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

            initGrfDept();
            setGrfDeptH();
            sB1.Text = "";
        }
        private void initGrfDept()
        {
            grfDept = new C1FlexGrid();
            grfDept.Font = fEdit;
            grfDept.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDept.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfDept);

            grfDept.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfDept_AfterRowColChange);
            grfDept.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            grfDept.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            
            panel1.Controls.Add(this.grfDept);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfDept, theme);
        }
        private void setGrfDeptH()
        {

            //grfDept.Rows.Count = 7;

            grfDept.DataSource = xC.xtDB.deptDB.selectAll1();
            grfDept.Cols.Count = colCnt;
            CellStyle cs = grfDept.Styles.Add("btn");
            cs.DataType = typeof(Button);
            //cs.ComboList = "|Tom|Dick|Harry";
            cs.ForeColor = Color.Navy;
            cs.Font = new Font(Font, FontStyle.Bold);
            cs = grfDept.Styles.Add("date");
            cs.DataType = typeof(DateTime);
            cs.Format = "dd-MMM-yy";
            cs.ForeColor = Color.DarkGoldenrod;

            grfDept.Cols[colE].Style = grfDept.Styles["btn"];
            grfDept.Cols[colS].Style = grfDept.Styles["date"];

            grfDept.Cols[colID].Width = 60;
            //grfDept.Cols[colCode].Width = 100;
            //grfDept.Cols[colNameT].Width = 100;
            //grfDept.Cols[colNameE].Width = 100;
            //grfDept.Cols[colRemark].Width = 100;
            //grfDept.Cols[coledit].Width = 100;
            grfDept.Cols[colE].Width = 100;
            grfDept.Cols[colS].Width = 100;
            //grfAddr.Cols[colAddrTele].Width = 100;
            //grfAddr.Cols[colAddrMobile].Width = 100;
            //grfAddr.Cols[colAddrRemark].Width = 100;
            //grfAddr.Cols[colAddrRemark2].Width = 100;
            grfDept.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";
            //grfDept.Cols[colNameT].Caption = "ชื่อธนาคาร";
            //grfDept.Cols[colNameE].Caption = "name bank";
            //grfBank.Cols[colRemark].Caption = "หมายเหตุ";
            //grfBank.Cols[coledit].Caption = "flag";
            grfDept.Cols[colE].Caption = "edit";
            grfDept.Cols[colS].Caption = "save";
            //grfAddr.Cols[colAddrTele].Caption = "tele";
            //grfAddr.Cols[colAddrMobile].Caption = "mobile";
            //grfAddr.Cols[colAddrRemark].Caption = "หมายเหตุ";
            //grfAddr.Cols[colAddrRemark2].Caption = "หมายเหตุ2";

            //grfDept.Cols[coledit].Visible = false;
            CellRange rg = grfDept.GetCellRange(2, colE);
            rg.Style = grfDept.Styles["btn"];
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfBank.Cols[colE]. = false;
        }
        private void grfDept_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String addrId = "";
            addrId = grfDept[e.NewRange.r1, colID] != null ? grfDept[e.NewRange.r1, colID].ToString() : "";
            
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
        }
        private void grfDept_CellButtonClick(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {

        }
        private void grfDept_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (e.Row == 0) return;
            CellStyle cs = grfDept.Styles.Add("text");
            cs.BackColor = Color.DimGray;
            sB1.Text = grfDept[e.Row, e.Col].ToString();
            //grfDept[e.Row, coledit] = "1";
            grfDept.Rows[e.Row].Style = cs;
            if((e.Row+1) == ((RowCollection)grfDept.Rows).Count)
            {
                ((RowCollection)grfDept.Rows).Count = ((RowCollection)grfDept.Rows).Count + 1;
            }
        }
        private void FrmDepartment1_Load(object sender, EventArgs e)
        {

        }
    }
}
