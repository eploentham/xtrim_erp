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
    public partial class FrmInitial : Form
    {
        XtrimControl xC;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        public FrmInitial(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            //bg = txtCusCode.BackColor;
            //fc = txtCusCode.ForeColor;
            //ff = txtCusCode.Font;
            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            //theme1.SetTheme(txtCusCode, theme1.Theme);
            //bg = txtCusCode.BackColor;
            //fc = txtCusCode.ForeColor;
            theme1.SetTheme(sB, "BeigeOne");
        }

        private void FrmInitial_Load(object sender, EventArgs e)
        {

        }
    }
}
