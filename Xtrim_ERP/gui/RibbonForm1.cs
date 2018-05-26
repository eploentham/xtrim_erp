using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xtrim_ERP.control;

namespace Xtrim_ERP.gui
{
    public partial class RibbonForm1 : C1.Win.C1Ribbon.C1RibbonForm
    {
        XtrimControl xC;
        Font fEdit, fEditB;
        Color bg, fc, grfOld;
        Font ff, ffB;
        int colInvNo = 1, colInvDate = 2, colInvShipping = 3;

        C1FlexGrid grfInv;
        C1SuperTooltip stt;

        C1SuperErrorProvider sep;        

        String jobNo = "";

        public RibbonForm1(XtrimControl x, String jobno)
        {
            InitializeComponent();
            xC = x;
            jobNo = jobno;
            initConfig();
        }
        private void initConfig()
        {
            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            grfInv = new C1FlexGrid();
            //panelJob.Dock = DockStyle.Fill;
            grfInv.Dock = DockStyle.Bottom;
            //grfInv.Size = new System.Drawing.Size(0, panel4.Height - txtJobCode.Height - 20);
            //grfInv.AfterRowColChange += GrfSearch_AfterRowColChange;
            //grfInv.DoubleClick += GrfSearch_DoubleClick;
            FilterRow fr = new FilterRow(grfInv);
            panel2.Controls.Add(grfInv);
            //panel2.Height = 300;
            grfInv.Height = 200;
            foreach (Control c in panel1.Controls)
            {
                theme1.SetTheme(c, "Office2010Blue");
            }
            foreach(Control c in groupBox1.Controls)
            {
                theme1.SetTheme(c, "Office2010Blue");
            }
            theme1.SetTheme(panel1, "Office2010Blue");
            theme1.SetTheme(panel2, "Office2010Blue");
            theme1.SetTheme(sB, "Office2010Blue");
            theme1.SetTheme(grfInv, "Office2010Blue");
            theme1.SetTheme(tC1, "Office2010Blue");
            xC.setCboTransMode(cboTransMode);
            tabJob.Text = "นำเข้า Job";
            TabImporter.Text = "นำเข้า Importer";
            tabInit.Text = "นำเข้า Master";
            sB1.Text = "";
            setControl();
            setGrfInv();
            //panel1.BackColor = Color.Blue;
        }
        private void setControl()
        {
            DataTable dt = new DataTable();
            dt = xC.xtDB.mioDB.selectJobNoImport(jobNo);
            txtJobCode.Value = dt.Rows[0]["jobno"].ToString();
            txtMbl.Value = dt.Rows[0]["bl"].ToString();
            txtHbl.Value = dt.Rows[0]["housebl"].ToString();
            txtMves.Value = dt.Rows[0]["vslname"].ToString();
            txtTotalP.Value = dt.Rows[0]["nopkg"].ToString();
            txtGw.Value = dt.Rows[0]["grsww"].ToString();
            txtImpNameT.Value = dt.Rows[0]["tname"].ToString();
            txtLoaded.Value = dt.Rows[0]["loaded_name"].ToString();
            txtReleased.Value = dt.Rows[0]["name_repleased"].ToString();
            txtOutReleased.Value = dt.Rows[0]["name_out_repleased"].ToString();
            txtApproval.Value = dt.Rows[0]["name_approval"].ToString();
            txtOrigin.Value = dt.Rows[0]["origin"].ToString();
            txtConsignmnt.Value = dt.Rows[0]["consignmnt"].ToString();
            txtVslname.Value = dt.Rows[0]["vslname"].ToString();
            txtVslnamerem.Value = dt.Rows[0]["vslnamerem"].ToString();
            txtNetww.Value = dt.Rows[0]["netww"].ToString();
            //cboTransMode.SelectedItem = dt.Rows[0]["transmode"].ToString();
            xC.setC1Combo(cboTransMode, dt.Rows[0]["transmode"].ToString());
        }
        private void setGrfInv()
        {
            DataTable dt = new DataTable();
            dt = xC.xtDB.mioDB.selectJobInvNoImport(jobNo);
            grfInv.DataSource = dt;
            //grfInv.Cols.Count = 3;
            //grfInv.Rows.Count = 2;
            grfInv.Cols[colInvNo].Width = 100;

            grfInv.Cols[colInvNo].Caption = "job no";
            grfInv.Cols[colInvNo].Caption = "job no";
            grfInv.Cols[colInvNo].Caption = "job no";
            grfInv.Cols[colInvNo].Caption = "job no";

            //grfInv.Cols[colimpJob].Visible = false;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ...
            if (keyData == (Keys.Escape))
            {
                //if (MessageBox.Show("ต้องการออกจากโปรแกรม", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                //{
                    Close();
                    return true;
                //}
            }
            else
            {
                //keyData
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

        }
        private void RibbonForm1_Load(object sender, EventArgs e)
        {

        }
    }
}
