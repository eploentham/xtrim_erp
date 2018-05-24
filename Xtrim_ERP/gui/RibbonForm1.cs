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
            theme1.SetTheme(sB, "BeigeOne");
            theme1.SetTheme(grfInv, "Office2010Blue");
            setControl();
            setGrfInv();
            //panel1.BackColor = Color.Blue;
        }
        private void setControl()
        {
            DataTable dt = new DataTable();
            dt = xC.xtDB.mioDB.selectJobNoImport(jobNo);
            txtJobCode.Value = dt.Rows[0]["jobno"].ToString();
            txtJobCode.Value = dt.Rows[0]["jobno"].ToString();
            txtJobCode.Value = dt.Rows[0]["jobno"].ToString();
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
    }
}
