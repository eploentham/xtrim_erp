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
        Color bg, fc, grfOld;
        Font ff, ffB;
        int colJobNo = 1, colimpJob = 2, colJobDate = 3, colImpDate = 4, colBL = 5, colImporter = 8, colVslName = 6, colHouseBL = 5, colNameT = 9, colNameE = 10;
        int colvslnamerem = 11, colOrigin = 12, colConsignmnt = 13, colLoaded = 14, colLoadedName = 15, colRelease = 16, colReleaseName = 17, colOutReplease = 18;
        int colOutRepleaseName=19, colApproval=20, colApprovalName=21;
        int grfRowOld = 0;

        Boolean flagEdit = false;
        Boolean flagsearch = false;
        C1FlexGrid grfSearch, grfExpen;
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
            initGrfExpen();

            //theme1.SetTheme(tC1, "BeigeOne");
            //theme1.SetTheme(tC2, "BeigeOne");
            theme1.SetTheme(sB, "BeigeOne");
            btnJobSearch.Click += BtnJobSearch_Click;
            chkCatiria.Click += ChkCatiria_Click;
            tabExpen.DoubleClick += TabExpen_DoubleClick;
            tabExpen.TabClick += TabExpen_TabClick;

            panel4.Top = lbCus.Top + 10;
            
            
            panelCatiria.Hide();
            //locationPanelJob = panelJob.Location;
            //sizePanelJob = panelJob.Size;
        }

        private void TabExpen_TabClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            tabJob.Height =  100;
            panel11.Hide();
        }

        private void TabExpen_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //grfExpen.Height = this.Height - lbCus.Top - 100;
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
                grfSearch.AfterRowColChange += GrfSearch_AfterRowColChange;
                grfSearch.DoubleClick += GrfSearch_DoubleClick;
                FilterRow fr = new FilterRow(grfSearch);
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

        private void GrfSearch_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //MessageBox.Show(String.Format("Button clicked in - Row : {0}, column : {1}.", grfSearch.MouseRow.ToString(), grfSearch.MouseCol.ToString()));
            if (grfSearch[grfSearch.Row, colJobNo] == null) return;
            grfSearch.Rows[grfSearch.MouseRow].StyleNew.BackColor = Color.Red;
            RibbonForm1 frm = new RibbonForm1(xC,grfSearch[grfSearch.Row, colJobNo].ToString());
            frm.ShowDialog(this);
        }

        private void GrfSearch_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            String aaa = "";
            sB1.Text = e.NewRange.r1.ToString()+" old "+e.OldRange.r1;
            if (e.NewRange.Data == null) return;
            if (e.OldRange.r1 < 0) return;
            //grfOld = grfSearch.Rows[e.NewRange.r1].StyleNew.BackColor;

            grfSearch.Rows[e.NewRange.r1].StyleNew.BackColor = Color.Gray;
            if (e.OldRange.r1 % 2 == 0)
                grfSearch.Rows[e.OldRange.r1].StyleNew.BackColor = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            else
                grfSearch.Rows[e.OldRange.r1].StyleNew.BackColor = grfOld;
        }
        private void initGrfExpen()
        {
            grfExpen = new C1FlexGrid();
            grfExpen.Dock = DockStyle.Fill;
            //grfExpen.Size = new System.Drawing.Size(0, panel4.Height - txtJobCode.Height - 20);
            //grfSearch.AfterRowColChange += GrfSearch_AfterRowColChange;
            //grfSearch.DoubleClick += GrfSearch_DoubleClick;
            FilterRow fr = new FilterRow(grfExpen);
            panelExpen.Controls.Add(grfExpen);
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
            grfSearch.Cols[colVslName].Width = 200;
            grfSearch.Cols[colHouseBL].Width = 60;
            grfSearch.Cols[colNameT].Width = 200;
            grfSearch.Cols[colNameE].Width = 200;
            grfSearch.Cols[colLoadedName].Width = 200;
            grfSearch.Cols[colReleaseName].Width = 200;
            grfSearch.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            grfSearch.Cols[colJobNo].Caption = "job no";
            grfSearch.Cols[colJobDate].Caption = "job date";
            grfSearch.Cols[colImpDate].Caption = "import date";
            grfSearch.Cols[colBL].Caption = "Bill Landing";
            grfSearch.Cols[colVslName].Caption = "ชื่อยานพาหนะ ";
            grfSearch.Cols[colHouseBL].Caption = "HB/L HAWB ";
            grfSearch.Cols[colImporter].Caption = "importer";
            grfSearch.Cols[colNameT].Caption = "ชื่อ importer";
            grfSearch.Cols[colNameE].Caption = "name importer";
            grfSearch.Cols[colvslnamerem].Caption = "vslnamerem";
            grfSearch.Cols[colOrigin].Caption = "Origin";
            grfSearch.Cols[colConsignmnt].Caption = "Consignmnt";
            grfSearch.Cols[colLoaded].Caption = "load code";
            grfSearch.Cols[colLoadedName].Caption = "load name";
            grfSearch.Cols[colRelease].Caption = "release";
            grfSearch.Cols[colReleaseName].Caption = "release name";
            grfSearch.Cols[colOutReplease].Caption = "out release";
            grfSearch.Cols[colOutRepleaseName].Caption = "out repease name";
            grfSearch.Cols[colApproval].Caption = "approval";
            grfSearch.Cols[colApprovalName].Caption = "approval name";

            grfSearch.Cols[colimpJob].Visible = false;
            //grfSearch.Cols[colID].Visible = false;
            
            for (int i = 1; i < grfSearch.Rows.Count; i++)
            {
                grfSearch[i, 0] = i;
                if (i % 2 == 0)
                    grfSearch.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            }
            grfOld = grfSearch.Rows[1].StyleNew.BackColor;
        }

        private void FrmJobImpNew1_Load(object sender, EventArgs e)
        {

        }
    }
}
