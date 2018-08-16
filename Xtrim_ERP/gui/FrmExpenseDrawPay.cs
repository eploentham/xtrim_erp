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
using Xtrim_ERP.object1;

namespace Xtrim_ERP.gui
{
    public partial class FrmExpenseDrawPay : Form
    {
        XtrimControl xC;
        ExpensesDraw expnD;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colDesc = 3, colRemark = 4;
        int colDid = 1, colDdesc1 = 2, colDdesc2 = 3, colDamt = 4, colDremark = 5;
        C1FlexGrid grfExpnD, grfExpnD1;
        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "", jobId = "";
        public String drawId = "", flagForm = "";

        public FrmExpenseDrawPay(XtrimControl x, String drawid, String flagform)
        {
            InitializeComponent();
            xC = x;
            drawId = drawid;
            flagForm = flagform;
            initConfig();
        }
        private void initConfig()
        {
            expnD = new ExpensesDraw();
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel3.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }

            bg = txtDrawCode.BackColor;
            fc = txtDrawCode.ForeColor;
            ff = txtDrawCode.Font;
            //xC.xtDB.expndDB.setC1CboExpnC(cboStaff, "");
            //DateTime jobDate = DateTime.Now;
            //txtExpndDrawDate.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");
            //jobDate = jobDate.AddDays(7);
            //txtDrawDate.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");

            

            sB1.Text = "";
            
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
        }
        private void FrmExpenseDrawPay_Load(object sender, EventArgs e)
        {

        }
    }
}
