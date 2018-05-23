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

        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        String userIdVoid = "";
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

            //theme1.SetTheme(tC1, "BeigeOne");
            //theme1.SetTheme(tC2, "BeigeOne");
            theme1.SetTheme(sB, "BeigeOne");
        }
        private void FrmJobImpNew1_Load(object sender, EventArgs e)
        {

        }
    }
}
