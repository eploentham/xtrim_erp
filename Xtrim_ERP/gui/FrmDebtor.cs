using C1.Win.C1FlexGrid;
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
    public partial class FrmDebtor : Form
    {
        XtrimControl xC;
        
        Company cop;
        
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        C1FlexGrid grfDtr;
        int colID = 1, colCusNameT = 2, colAmt = 3, colCusId=4;

        public FrmDebtor(XtrimControl x)
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
            cop = new Company();
            cop = xC.xtDB.copDB.selectByCode1("001");
            initGrfJob();
            setGrfJob();
        }
        private void initGrfJob()
        {
            grfDtr = new C1FlexGrid();
            grfDtr.Font = fEdit;
            grfDtr.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDtr.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpnD);

            //grfDtr.AfterRowColChange += GrfJob_AfterRowColChange;
            //grfDtr.DoubleClick += GrfJob_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //grfDtr.CellChanged += GrfExpnD_CellChanged;
            panel2.Controls.Add(grfDtr);
            grfDtr.Clear();
            grfDtr.Rows.Count = 2;
            grfDtr.Cols.Count = 5;
            grfDtr.Cols[colCusNameT].Width = 200;
            grfDtr.Cols[colAmt].Width = 120;
            //grfDtr.Cols[colDesc].Width = 200;
            //grfDtr.Cols[colRemark].Width = 100;
            grfDtr.Cols[colCusNameT].Caption = "ลูกหนี้";
            grfDtr.Cols[colAmt].Caption = "ยอดหนี้";
            //grfDtr.Cols[colDesc].Caption = "รายละเอียด";
            //grfDtr.Cols[colRemark].Caption = "หมายเหตุ";
            grfDtr.Cols[colID].Visible = false;

            theme1.SetTheme(grfDtr, "Office2013Red");
        }
        private void setGrfJob()
        {
            grfDtr.DataSource = null;
            grfDtr.Rows.Count = 2;
            grfDtr.Clear();
            //if (cusid.Equals("")) return;
            DataTable dt = new DataTable();
            dt = xC.xtDB.dtrDB.selectDebtor();
            //grfDtr.DataSource = xC.xtDB.jimDB.selectJimJblByJobYear2(cusid);
            //grfDtr.Cols.Count = dt.Columns.Count;
            grfDtr.Rows.Count = dt.Rows.Count + 1;

            grfDtr.Cols.Count = 5;
            TextBox txt = new TextBox();

            grfDtr.Cols[colCusNameT].Editor = txt;
            grfDtr.Cols[colAmt].Editor = txt;
            //grfDtr.Cols[colRemark].Editor = txt;
            //grfDtr.Cols[colAmt].Editor = txt;

            grfDtr.Cols[colCusNameT].Width = 200;
            grfDtr.Cols[colAmt].Width = 100;
            //grfDtr.Cols[colDesc].Width = 200;
            //grfDtr.Cols[colRemark].Width = 100;

            grfDtr.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";
            grfDtr.Cols[colCusNameT].Caption = "ลูกหนี้";
            grfDtr.Cols[colAmt].Caption = "ยอดหนี้";
            //grfDtr.Cols[colDesc].Caption = "รายละเอียด";
            //grfDtr.Cols[colRemark].Caption = "หมายเหตุ";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfDtr[i + 1, 0] = i+1;
                if (i % 2 == 0)
                    grfDtr.Rows[i].StyleNew.BackColor = color;
                //grfDtr[i + 1, colID] = dt.Rows[i][xC.xtDB.dtrDB.dtr.debtor_id].ToString();
                grfDtr[i + 1, colCusNameT] = dt.Rows[i][xC.xtDB.cusDB.cus.cust_name_t].ToString();
                grfDtr[i + 1, colAmt] = dt.Rows[i][xC.xtDB.dtrDB.dtr.amount].ToString();
                //grfDtr[i + 1, colRemark] = dt.Rows[i][xC.xtDB.jimDB.jim.remark1].ToString();
                //grfDtr[i + 1, colAmt] = dt.Rows[i][xC.xtDB.jimDB.jim.job_import_id].ToString();
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfDtr.Cols[colID].Visible = false;

        }
        private void FrmDebtor_Load(object sender, EventArgs e)
        {

        }
    }
}
