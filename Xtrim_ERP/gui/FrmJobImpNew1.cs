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

namespace Xtrim_ERP.gui
{
    public partial class FrmJobImpNew1 : Form
    {
        XtrimControl xC;
        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colJobNo = 1, colimpJob = 2, colJobDate = 3, colImpDate = 4, colBL = 5, colImporter = 8, colVslName = 6, colHouseBL = 5, colNameT = 9, colNameE = 10;

        Boolean flagEdit = false;
        Boolean flagsearch = false;
        C1FlexGrid grfSearch;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        String userIdVoid = "";
        Point locationPanelJob;
        Size sizePanelJob;
        public FrmJobImpNew1(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            grfSearch = new C1FlexGrid();

            //theme1.SetTheme(tC1, "BeigeOne");
            //theme1.SetTheme(tC2, "BeigeOne");
            theme1.SetTheme(sB, "BeigeOne");
            btnJobSearch.Click += BtnJobSearch_Click;
            chkCatiria.Click += ChkCatiria_Click;

            panelCatiria.Hide();
            //locationPanelJob = panelJob.Location;
            //sizePanelJob = panelJob.Size;
        }

        private void ChkCatiria_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkCatiria.Checked)
            {
                DateTime st = DateTime.Now;
                txtDateStart.Enabled = true;
                txtDateEnd.Enabled = true;
                btnSearch.Enabled = true;
                txtDateStart.Value = st.AddDays(-30);
                txtDateEnd.Value = DateTime.Now;
            }
            else
            {
                txtDateStart.Enabled = false;
                txtDateEnd.Enabled = false;
                btnSearch.Enabled = false;
            }
            
        }

        private void BtnJobSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            flagsearch = flagsearch ? false : true;
            setPanelSearch(flagsearch);
        }
        private void setPanelSearch(Boolean flag)
        {
            if (flag)
            {
                grfSearch = new C1FlexGrid();
                //panelJob.Dock = DockStyle.Fill;
                grfSearch.Dock = DockStyle.Bottom;
                grfSearch.Size = new System.Drawing.Size(0, panel4.Height - txtJobCode.Height - 20);
                panel4.Controls.Add(grfSearch);
                panel11.Hide();
                txtCusNameT.Hide();
                btnCusSF2.Hide();
                btnCusSF4.Hide();
                lbCus.Hide();
                tabInv.Enabled = false;
                
                panelCatiria.Show();
                panelCatiria.Left = lbCus.Left;
                panelCatiria.Top = lbCus.Top-15;
                txtDateStart.Enabled = false;
                txtDateEnd.Enabled = false;
                btnSearch.Enabled = false;
                chkCatiria.Checked = false;
                setGrfSearch(chkCatiria.Checked);
            }
            else
            {
                //panelJob.Dock = DockStyle.None;
                grfSearch.Dispose();
                panel11.Show();
                txtCusNameT.Show();
                btnCusSF2.Show();
                btnCusSF4.Show();
                lbCus.Show();
                tabInv.Enabled = true;
                panelCatiria.Hide();
                //tabInv.Show();
                //panelJob.Size = new System.Drawing.Size(350, 29);
                //panelJob.Location = locationPanelJob;
                //panelJob.Size = sizePanelJob;
                //panelJob.SuspendLayout();
                //panelJob.ResumeLayout(false);
                //panelJob.PerformLayout();
            }
        }
        private void setGrfSearch(Boolean flag)
        {
            grfSearch.DataSource = !flag ? xC.xtDB.mioDB.selectJobNoImport() : xC.xtDB.mioDB.selectJobNoImport();
            grfSearch.Cols[colJobNo].Width = 100;
            grfSearch.Cols[colimpJob].Width = 100;
            grfSearch.Cols[colJobDate].Width = 100;
            grfSearch.Cols[colImpDate].Width = 100;
            grfSearch.Cols[colBL].Width = 100;
            grfSearch.Cols[colImporter].Width = 60;
            grfSearch.Cols[colVslName].Width = 60;
            grfSearch.Cols[colHouseBL].Width = 60;
            grfSearch.Cols[colNameT].Width = 60;
            //grfSearch.Cols[colNameE].Width = 60;
            grfSearch.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            grfSearch.Cols[colJobNo].Caption = "job no";
            grfSearch.Cols[colJobDate].Caption = "job date";
            grfSearch.Cols[colImpDate].Caption = "import date";
            grfSearch.Cols[colBL].Caption = "Bill Landing";
            grfSearch.Cols[colVslName].Caption = "vsl name";
            grfSearch.Cols[colHouseBL].Caption = "house bl";
            grfSearch.Cols[colImporter].Caption = "importer";
            grfSearch.Cols[colNameT].Caption = "ชื่อ importer";
            //grfSearch.Cols[colNameE].Caption = "ชื่อที่อยู่";

            grfSearch.Cols[colimpJob].Visible = false;
        }

        private void FrmJobImpNew1_Load(object sender, EventArgs e)
        {

        }
    }
}
