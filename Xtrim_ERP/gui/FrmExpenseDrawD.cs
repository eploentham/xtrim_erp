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
using Xtrim_ERP.object1;

namespace Xtrim_ERP.gui
{
    public partial class FrmExpenseDrawD : Form
    {
        XtrimControl xC;
        ExpensesDrawDatail expnDd;

        Color bg, fc;
        Font ff, ffB;
        Font fEdit, fEditB;

        String drawdId = "";
        C1FlexGrid grfExpnD;
        int colID = 1, colCode = 2, colNameT = 3, colPrice1 = 4, colPrice2 = 5, colPrice3 = 6, colTypeSub = 7;

        public FrmExpenseDrawD(XtrimControl x, String id)
        {
            InitializeComponent();
            xC = x;
            drawdId = id;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel1.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }

            bg = txtQty.BackColor;
            fc = txtQty.ForeColor;
            ff = txtQty.Font;

            xC.xtDB.itmDB.setC1CboItem(cboItm);
            xC.xtDB.utpDB.setC1CboUtp(cboUtp, "");
            initGrfDept();
            setGrfDeptH();
        }
        private void initGrfDept()
        {
            grfExpnD = new C1FlexGrid();
            grfExpnD.Font = fEdit;
            grfExpnD.Dock = System.Windows.Forms.DockStyle.Fill;
            grfExpnD.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfExpnD);

            grfExpnD.AfterRowColChange += GrfExpnD_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //grfExpnD.CellChanged += GrfExpnD_CellChanged;
            panel2.Controls.Add(grfExpnD);

            theme1.SetTheme(grfExpnD, "Office2013Red");
        }

        private void GrfExpnD_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void setGrfDeptH()
        {
            grfExpnD.Clear();
            //if (txtID.Text.Equals("")) return;

            grfExpnD.DataSource = xC.xtDB.itmDB.selectAll1();
            C1TextBox txt = new C1TextBox();
            txt.DataType = txtID.DataType;

            grfExpnD.Cols[colID].Editor = txt;
            grfExpnD.Cols[colCode].Editor = txt;
            grfExpnD.Cols[colNameT].Editor = txt;
            grfExpnD.Cols[colPrice1].Editor = txt;
            grfExpnD.Cols[colPrice2].Editor = txt;
            grfExpnD.Cols[colPrice3].Editor = txt;
            grfExpnD.Cols[colTypeSub].Editor = txt;

            grfExpnD.Cols[colCode].Width = 80;
            grfExpnD.Cols[colNameT].Width = 80;
            grfExpnD.Cols[colPrice1].Width = 80;
            grfExpnD.Cols[colPrice2].Width = 80;
            grfExpnD.Cols[colPrice3].Width = 80;
            grfExpnD.Cols[colTypeSub].Width = 120;
            grfExpnD.ShowCursor = true;
            grfExpnD.Cols[colCode].Caption = "รหัส";
            grfExpnD.Cols[colNameT].Caption = "ชื่อ";
            grfExpnD.Cols[colPrice1].Caption = "ราคา1";
            grfExpnD.Cols[colPrice2].Caption = "ราคา2";
            grfExpnD.Cols[colPrice3].Caption = "ราคา3";
            grfExpnD.Cols[colTypeSub].Caption = "ประเภทย่อย";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 1; i < grfExpnD.Rows.Count; i++)
            {
                grfExpnD[i, 0] = i;
                if (i % 2 == 0)
                    grfExpnD.Rows[i].StyleNew.BackColor = color;
            }
            grfExpnD.Cols[colID].Visible = false;
        }
        private void FrmExpenseDrawD_Load(object sender, EventArgs e)
        {

        }
    }
}
