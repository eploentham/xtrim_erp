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
    public partial class FrmJobImpCheckListExp : C1.Win.C1Ribbon.C1RibbonForm
    {
        XtrimControl xC;
        Font fEdit, fEditB;
        Color bg, fc, cgrfOld;
        Font ff, ffB;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        public FrmJobImpCheckListExp(XtrimControl x)
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
            theme1.SetTheme(panel1, "VS2013Light");

            foreach(Control c in panel1.Controls)
            {
                theme1.SetTheme(c, "VS2013Light");
            }
        }

        private void FrmJobImpCheckListExp_Load(object sender, EventArgs e)
        {


        }
    }
}
