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
        }

        private void FrmExpenseDrawD_Load(object sender, EventArgs e)
        {

        }
    }
}
