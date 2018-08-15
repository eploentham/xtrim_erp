using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
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
    public partial class FrmReserveCash : Form
    {
        XtrimControl xC;
        Font fEdit, fEditB;
        Company cop;

        Color bg, fc;
        Font ff, ffB;

        C1FlexGrid grfView;
        int colDate = 1, colType = 2, colAmt = 3, colDesc = 4;

        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "";

        public FrmReserveCash(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");

            cop = new Company();
            cop = xC.xtDB.copDB.selectByCode1("001");

            initGrfView();
            setGrfView();

            txtAmtReserve.Value = cop.amount_reserve;

            sB1.Text = "";
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
        }
        private void initGrfView()
        {
            grfView = new C1FlexGrid();
            grfView.Font = fEdit;
            grfView.Dock = System.Windows.Forms.DockStyle.Fill;
            grfView.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfView);
            //grfView.AfterDataRefresh += GrfView_AfterDataRefresh;
            //grfExpn.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfDept_AfterRowColChange);
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);

            panel3.Controls.Add(grfView);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&จ่ายเงิน รายการเบิก", new EventHandler(ContextMenu_appv));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfView.ContextMenu = menuGw;

            theme1.SetTheme(grfView, "Office2013Red");
        }
        private void setGrfView()
        {
            //grfDept.Rows.Count = 7;
            //DataTable dtP = new DataTable();
            DataTable dtC = new DataTable();
            //dtP = xC.xtDB.rspDB.selectAll();
            dtC = xC.accDB.rscDB.selectAll();
            grfView.Cols.Count = 5;
            grfView.Rows.Count = 1;
            C1TextBox txt = new C1TextBox();
            
            grfView.Cols[colDate].Editor = txt;
            grfView.Cols[colType].Editor = txt;
            grfView.Cols[colAmt].Editor = txt;
            grfView.Cols[colDesc].Editor = txt;

            grfView.Cols[colDate].Width = 150;
            grfView.Cols[colType].Width = 100;
            grfView.Cols[colAmt].Width = 100;
            grfView.Cols[colDesc].Width = 300;
            //grfView.Cols[colStatus].Width = 80;
            //grfView.Cols[colStatusPay].Width = 80;
            grfView.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfView.Cols[colDate].Caption = "วันที่";
            grfView.Cols[colType].Caption = "ประเภท";
            grfView.Cols[colAmt].Caption = "จำนวนเงิน";
            grfView.Cols[colDesc].Caption = "รายการ";
            
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dtC.Rows.Count; i++)
            {
                Row row = grfView.Rows.Add();
                row[0] = (i + 1);
                if (i % 2 == 0)
                    row.StyleNew.BackColor = color;
                String date = "";
                date= dtC.Rows[i][xC.accDB.rscDB.rsc.date_create].ToString();
                row[colDate] = date;
                if (!dtC.Rows[i][xC.accDB.rscDB.rsc.expenses_pay_detail_id].ToString().Equals("0"))
                {
                    row[colType] = "จ่าย";
                }
                else
                {
                    row[colType] = "เบิกเงิน";
                }
                
                row[colAmt] = dtC.Rows[i][xC.accDB.rscDB.rsc.amount].ToString();
                row[colDesc] = dtC.Rows[i][xC.accDB.rscDB.rsc.desc1].ToString();
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfView.Cols[colID].Visible = false;
        }
        private void FrmReserveCash_Load(object sender, EventArgs e)
        {

        }
    }
}
