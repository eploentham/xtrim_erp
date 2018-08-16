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
    public partial class FrmPaymentView : Form
    {
        XtrimControl xC;
        ExpensesDraw expn;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colDesc = 3, colRemark = 4, colAmt = 5, colStatus = 6;
        C1FlexGrid grfExpn;
        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "";

        MainMenu4 menu;

        public FrmPaymentView(XtrimControl x, MainMenu4 m)
        {
            InitializeComponent();
            xC = x;
            menu = m;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");

            btnNew.Click += BtnNew_Click;

            sB1.Text = "";

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;

            chkAll.Checked = true;
            xC.setCboYear(cboYear);

        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            xC.drawID = "";

            FrmPayment2 frm = new FrmPayment2(xC);
            //frm.drawId = "";
            //frm.flagForm = "new";
            //frm.ShowDialog(this);
            frm.FormBorderStyle = FormBorderStyle.None;
            menu.AddNewTab(frm, "รับชำระ ใหม่");
            //frm.WindowState = FormWindowState.Normal;
            //frm.StartPosition = FormStartPosition.CenterScreen;
        }
        private void FrmPaymentView_Load(object sender, EventArgs e)
        {

        }
    }
}
