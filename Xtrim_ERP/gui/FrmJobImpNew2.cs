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
    public partial class FrmJobImpNew2 : Form
    {
        XtrimControl xC;
        Font fEdit, fEditB;
        Color bg, fc, cgrfOld;
        Font ff, ffB;
        C1FlexGrid grfMarsk, grfPkg, grfGw, grfContain, grfRemark;
        int colMarskId = 1, colMarskDesc = 2;
        int colRemarkId = 1, colRemarkDesc = 2;
        int colContainId = 1, colContainQty = 2, colContainContainId=3;
        int colGwId = 1, colGwQty = 2, colGwGwId = 3;
        int colPKGId = 1, colPKGQty = 2, colPKGPkgId = 3;

        public FrmJobImpNew2(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            theme1.SetTheme(tC2, "VS2013Light");
            btnJobSearch.Click += BtnJobSearch_Click;

            initGrfMarsk();
            initGrfRemark();
            initGrfContain();
            initGrfGw();
            initGrfPKG();
        }

        private void BtnJobSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Form3 frm = new Form3();
            frm.Show();
        }

        private void initGrfMarsk()
        {
            grfMarsk = new C1FlexGrid();
            grfMarsk.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();

            grfMarsk.Cols[colMarskId].Editor = txt;
            grfMarsk.Cols[colMarskDesc].Editor = txt;
            grfMarsk.Cols[colMarskDesc].Caption = "marsk";

            gBMarsk.Controls.Add(grfMarsk);
            grfMarsk.Rows.Count = 2;
            grfMarsk.Cols.Count = 3;
            grfMarsk.Cols[colMarskDesc].Width = 200;
            grfMarsk.Cols[colMarskId].Visible = false;

            grfMarsk.CellChanged += GrfMarsk_CellChanged;
        }
        private void initGrfRemark()
        {
            grfRemark = new C1FlexGrid();
            grfRemark.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();

            grfRemark.Cols[colRemarkId].Editor = txt;
            grfRemark.Cols[colRemarkDesc].Editor = txt;
            grfRemark.Cols[colRemarkDesc].Caption = "remark";

            gBRemark.Controls.Add(grfRemark);
            grfRemark.Rows.Count = 2;
            grfRemark.Cols.Count = 3;
            grfRemark.Cols[colRemarkDesc].Width = 200;
            
            grfRemark.Cols[colRemarkId].Visible = false;
            grfRemark.AfterRowColChange += GrfRemark_AfterRowColChange;
            grfRemark.CellChanged += GrfRemark_CellChanged;
                        
        }        

        private void initGrfContain()
        {
            grfContain = new C1FlexGrid();
            grfContain.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();
            C1ComboBox combo = new C1ComboBox();
            combo = xC.xtDB.dctDB.setCboContainer(combo);

            grfContain.Cols[colContainId].Editor = txt;
            grfContain.Cols[colContainQty].Editor = txt;
            grfContain.Cols[colContainContainId].Editor = combo;
            grfContain.Cols[colContainQty].Caption = "qty";
            grfContain.Cols[colContainContainId].Caption = "TYPE";

            gBContain.Controls.Add(grfContain);
            grfContain.Rows.Count = 2;
            grfContain.Cols.Count = 4;
            grfContain.Cols[colContainQty].Width = 60;
            grfContain.Cols[colContainContainId].Width = 150;
            grfContain.Cols[colContainId].Visible = false;

            grfContain.CellChanged += GrfContain_CellChanged;
        }
        private void initGrfGw()
        {
            grfGw = new C1FlexGrid();
            grfGw.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();
            C1ComboBox combo = new C1ComboBox();
            combo = xC.xtDB.dctDB.setCboGW(combo);

            grfGw.Cols[colGwId].Editor = txt;
            grfGw.Cols[colGwQty].Editor = txt;
            grfGw.Cols[colGwGwId].Editor = combo;
            grfGw.Cols[colGwQty].Caption = "qty";
            grfGw.Cols[colGwGwId].Caption = "GW & VOLUME";

            gBGw.Controls.Add(grfGw);
            grfGw.Rows.Count = 2;
            grfGw.Cols.Count = 4;
            grfGw.Cols[colGwQty].Width = 60;
            grfGw.Cols[colGwGwId].Width = 150;
            grfGw.Cols[colGwId].Visible = false;

            grfGw.CellChanged += GrfGw_CellChanged;
        }
        private void initGrfPKG()
        {
            grfPkg = new C1FlexGrid();
            grfPkg.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();
            C1ComboBox combo = new C1ComboBox();
            combo = xC.xtDB.dctDB.setCboGW(combo);

            grfPkg.Cols[colPKGId].Editor = txt;
            grfPkg.Cols[colPKGQty].Editor = txt;
            grfPkg.Cols[colPKGPkgId].Editor = combo;
            grfPkg.Cols[colPKGQty].Caption = "qty";
            grfPkg.Cols[colPKGPkgId].Caption = "PKG";

            gBPkg.Controls.Add(grfPkg);
            grfPkg.Rows.Count = 2;
            grfPkg.Cols.Count = 4;
            grfPkg.Cols[colPKGQty].Width = 60;
            grfPkg.Cols[colPKGPkgId].Width = 150;
            grfPkg.Cols[colPKGId].Visible = false;

            grfPkg.CellChanged += GrfPkg_CellChanged;
        }
        private void GrfRemark_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfRemark.Row == grfRemark.Rows.Count)
            {
                grfRemark.Rows.Count = grfRemark.Rows.Count + 1;
            }
        }
        private void GrfGw_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            grfGw.Rows.Count = (grfGw.Row == grfGw.Rows.Count - 1) ? (grfGw.Rows.Count = grfGw.Rows.Count + 1) : grfGw.Rows.Count;
        }

        private void GrfContain_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            grfContain.Rows.Count = (grfContain.Row == grfContain.Rows.Count - 1) ? (grfContain.Rows.Count = grfContain.Rows.Count + 1) : grfContain.Rows.Count;
        }

        private void GrfMarsk_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            grfMarsk.Rows.Count = (grfMarsk.Row == grfMarsk.Rows.Count - 1) ? (grfMarsk.Rows.Count = grfMarsk.Rows.Count + 1) : grfMarsk.Rows.Count;
        }

        private void GrfPkg_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            grfPkg.Rows.Count = (grfPkg.Row == grfPkg.Rows.Count - 1) ? (grfPkg.Rows.Count = grfPkg.Rows.Count + 1) : grfPkg.Rows.Count;
        }

        private void GrfRemark_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfRemark.Row == grfRemark.Rows.Count - 1)
            {
                grfRemark.Rows.Count = grfRemark.Rows.Count + 1;
            }
        }

        private void FrmJobImpNew2_Load(object sender, EventArgs e)
        {
            Size s = new Size(panel2.Width, 500);
            panel2.Size = s;
        }
    }
}
