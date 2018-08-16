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
    public partial class FrmDebtorView : Form
    {
        XtrimControl xC;
        MainMenu4 menu;
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
        String userIdVoid = "", flagForm = "";

        public enum flagForm2 { DebtorAdd, DebtorMinus };
        flagForm2 flagfom2;
        public FrmDebtorView(XtrimControl x, MainMenu4 m, flagForm2 flagform)
        {
            InitializeComponent();
            xC = x;
            menu = m;
            flagfom2 = flagform;
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

            xC.setCboYear(cboYear);

        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            
            //FrmExpenseDraw frm = new FrmExpenseDraw(xC, "", (FrmExpenseDraw.flagForm2)flagfom2, FrmExpenseDraw.flagAction.draw);
            //frm.drawId = "";
            //frm.flagForm = "new";
            //frm.ShowDialog(this);
            //frm.WindowState = FormWindowState.Normal;
            //frm.StartPosition = FormStartPosition.CenterScreen;
            String txt = "";
            if (flagfom2 == flagForm2.DebtorAdd)
            {
                FrmDebtorAdd frm = new FrmDebtorAdd(xC);
                txt = "ใบเพิ่มหนี้";
                frm.FormBorderStyle = FormBorderStyle.None;
                menu.AddNewTab(frm, txt);
            }
            else
            {
                FrmDebtorDeduct frm = new FrmDebtorDeduct(xC);
                txt = "ใบลดหนี้";
                frm.FormBorderStyle = FormBorderStyle.None;
                menu.AddNewTab(frm, txt);
            }
            
        }
        private void FrmDebtorView_Load(object sender, EventArgs e)
        {

        }
    }
}
