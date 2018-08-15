using C1.Win.C1FlexGrid;
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
    public partial class FrmJobImpView : Form
    {
        JobImport jim;
        XtrimControl xC;
        Font fEdit, fEditB;

        int colID = 1, colCode = 2, colCusT = 3, colImpT = 4, colRemark = 5, colTmn=6, colFwd=7, colJblDesc=8;
        int colCnt = 13;
        C1FlexGrid grfView;
        MainMenu4 menu;

        public FrmJobImpView(XtrimControl x, MainMenu4 m)
        {
            InitializeComponent();
            //grdView.Top = grdView.Top-30;
            xC = x;
            menu = m;
            initConfig();
        }
        private void initConfig()
        {
            jim = new JobImport();
            //fEdit = grdView.Font;
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Bold);
            initGrfView();
            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(panel1, theme1.Theme);

            cboYear.SelectedIndexChanged += CboYear_SelectedIndexChanged;
            //ContextMenu custommenu = new ContextMenu();
            //custommenu.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_void));
            //custommenu.MenuItems.Add("&ยกเลิก";
            //grdView.ContextMenu = custommenu;


        }

        private void CboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            string value = ((KeyValuePair<string, string>)cboYear.SelectedItem).Value;
            string key = ((KeyValuePair<string, string>)cboYear.SelectedItem).Key;
            setGrfView(key);
        }

        private void ContextMenu_void(object sender, System.EventArgs e)
        {
            //FarPoint.Win.Spread.Row row = grdView.ActiveSheet.ActiveRow;
            //FarPoint.Win.Spread.Column c;
            //c = grdView.ActiveSheet.ActiveColumn;
            //String aa = grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colCode].Value == null ? "" : grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colCode].Value.ToString();
            //if (MessageBox.Show("ต้องการ ยกเลิก \nรายการ" + aa, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //    String re = xC.xtDB.banDB.voidBank(grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colID].Value == null ? "" : grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colID].Value.ToString());
            //    if (re.Equals("1"))
            //    {
            //        grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[grdView.ActiveSheet.ActiveRow.Index, 0, grdView.ActiveSheet.ActiveRow.Index, colCnt - 1].BackColor = Color.Gray;
            //    }
            //}
        }
        private void initGrfView()
        {
            grfView = new C1FlexGrid();
            grfView.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();

            grfView.Cols[colID].Editor = txt;
            grfView.Cols[colCode].Editor = txt;
            grfView.Cols[colCusT].Editor = txt;
            grfView.Cols[colImpT].Editor = txt;
            grfView.Cols[colRemark].Editor = txt;
            grfView.Cols[colTmn].Editor = txt;
            grfView.Cols[colFwd].Editor = txt;
            grfView.Cols[colJblDesc].Editor = txt;
            //grfView.Cols[colCntInv].Editor = txt;
            //grfView.Cols[colCntExpn].Editor = txt;
            grfView.Cols[colCode].Caption = "import job no";
            grfView.Cols[colCusT].Caption = "Customer";
            grfView.Cols[colImpT].Caption = "Importer";
            grfView.Cols[colRemark].Caption = "Remark";
            grfView.Cols[colTmn].Caption = "marsk";
            grfView.Cols[colFwd].Caption = "Forwarder";
            grfView.Cols[colJblDesc].Caption = "Description";
            //grfView.Cols[colCntInv].Caption = "inv";
            //grfView.Cols[colCntExpn].Caption = "expn";

            panel2.Controls.Add(grfView);
            //grfView.Rows.Count = 2;
            //grfView.Cols.Count = 3;
            grfView.Cols[colCode].Width = 200;
            grfView.Cols[colCusT].Width = 200;
            grfView.Cols[colImpT].Width = 200;
            grfView.Cols[colRemark].Width = 200;
            grfView.Cols[colTmn].Width = 200;
            grfView.Cols[colFwd].Width = 200;
            grfView.Cols[colJblDesc].Width = 200;
            //grfView.Cols[colCntInv].Width = 80;
            //grfView.Cols[colCntExpn].Width = 80;
            
            grfView.Cols[colID].Visible = false;

            grfView.DoubleClick += GrfView_DoubleClick;

        }

        private void GrfView_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //MessageBox.Show("","111");
            xC.jobID = grfView[grfView.Row, colID].ToString();
            FrmJobImpNew3 frm = new FrmJobImpNew3(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            menu.AddNewTab(frm, "Import Job Detail");
        }

        private void setGrfView(String year)
        {
            if (year.Equals("")) return;
            DataTable dt = new DataTable();
            dt = xC.manDB.jimDB.selectJimJblByJobYear1(year);
            grfView.DataSource = dt;
            grfView.Cols[colCode].Caption = "import job no";
            grfView.Cols[colCusT].Caption = "Customer";
            grfView.Cols[colImpT].Caption = "Importer";
            grfView.Cols[colRemark].Caption = "Remark";
            grfView.Cols[colTmn].Caption = "marsk";
            grfView.Cols[colFwd].Caption = "Forwarder";
            grfView.Cols[colJblDesc].Caption = "Description";
            grfView.Cols[colID].Visible = false;
            for (int i = 1; i < grfView.Rows.Count; i++)
            {
                grfView[i, 0] = i;
                if (i % 2 == 0)
                    grfView.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            }
            //grfView.Rows.Count = dt.Rows.Count;
            //initGrfView();
        }
        //private void setGrdViewH()
        //{
        //    FarPoint.Win.Spread.EnhancedInterfaceRenderer outlinelook = new FarPoint.Win.Spread.EnhancedInterfaceRenderer();
        //    outlinelook.RangeGroupBackgroundColor = Color.LightGreen;
        //    outlinelook.RangeGroupButtonBorderColor = Color.Red;
        //    outlinelook.RangeGroupLineColor = Color.Blue;
        //    grdView.InterfaceRenderer = outlinelook;
        //    grdView.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

        //    grdView.BorderStyle = BorderStyle.None;
        //    grdView.Sheets[0].Columns[colCode, colRemark].AllowAutoFilter = true;
        //    grdView.Sheets[0].Columns[colCode, colRemark].AllowAutoSort = true;
        //    grdView.Sheets[0].AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu;

        //    FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();
        //    FarPoint.Win.Spread.CellType.ButtonCellType buttoncell = new FarPoint.Win.Spread.CellType.ButtonCellType();

        //    grdView.Sheets[0].ColumnCount = colCnt;
        //    grdView.Sheets[0].RowCount = 1;
        //    grdView.Font = fEdit;

        //    grdView.Sheets[0].Columns[colID].CellType = objTextCell;
        //    grdView.Sheets[0].Columns[colE].CellType = buttoncell;
        //    grdView.Sheets[0].Columns[colS].CellType = buttoncell;
        //    grdView.Sheets[0].Columns[colCode].CellType = objTextCell;
        //    grdView.Sheets[0].Columns[colCusT].CellType = objTextCell;
        //    grdView.Sheets[0].Columns[colImpT].CellType = objTextCell;
        //    grdView.Sheets[0].Columns[colRemark].CellType = objTextCell;
        //    grdView.Sheets[0].Columns[coledit].CellType = objTextCell;
        //    grdView.Sheets[0].Columns[colTmn].CellType = objTextCell;
        //    grdView.Sheets[0].Columns[colJblDesc].CellType = objTextCell;
        //    grdView.Sheets[0].Columns[colCntInv].CellType = objTextCell;
        //    grdView.Sheets[0].Columns[colCntExpn].CellType = objTextCell;

        //    grdView.Sheets[0].ColumnHeader.Cells[0, colE].Text = "edit";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colS].Text = "save";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colCode].Text = "code";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colCusT].Text = "Customer";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colImpT].Text = "Importer";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colRemark].Text = "หมายเหตุ";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colTmn].Text = "Terminal";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colFwd].Text = "Forwarder";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colJblDesc].Text = "Description";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colCntInv].Text = "invoice ";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colCntExpn].Text = "Expenses ";

        //    grdView.Sheets[0].Columns[colE].Width = 50;
        //    grdView.Sheets[0].Columns[colS].Width = 50;
        //    grdView.Sheets[0].Columns[colCode].Width = 80;
        //    grdView.Sheets[0].Columns[colCusT].Width = 200;
        //    grdView.Sheets[0].Columns[colImpT].Width = 200;
        //    grdView.Sheets[0].Columns[colRemark].Width = 200;
        //    grdView.Sheets[0].Columns[colTmn].Width = 200;
        //    grdView.Sheets[0].Columns[colFwd].Width = 200;
        //    grdView.Sheets[0].Columns[colJblDesc].Width = 200;
        //    grdView.Sheets[0].Columns[colCntInv].Width = 50;
        //    grdView.Sheets[0].Columns[colCntExpn].Width = 50;

        //    grdView.Sheets[0].Columns[colID].Visible = false;
        //    grdView.Sheets[0].Columns[coledit].Visible = false;
        //    grdView.Sheets[0].Columns[colE].Visible = false;
        //    grdView.Sheets[0].Columns[colS].Visible = false;

        //    grdView.AllowColumnMove = true;
        //}
        //private void setGrdView(String year)
        //{
        //    DataTable dt = new DataTable();
        //    int i = 0;
        //    FarPoint.Win.Spread.Column columnobj;
        //    columnobj = grdView.ActiveSheet.Columns[colCode, colRemark];

        //    //dt = xC.xtDB.jimDB.selectAll();

        //    dt = xC.xtDB.jimDB.selectJimJblByJobYear1(year);

        //    grdView.Sheets[0].Rows.Clear();
        //    setGrdViewH();
        //    grdView.Sheets[0].RowCount = dt.Rows.Count + 1;
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        grdView.Sheets[0].Cells[i, colID].Value = row[xC.xtDB.jimDB.jim.job_import_id] == null ? "" : row[xC.xtDB.jimDB.jim.job_import_id].ToString();
        //        grdView.Sheets[0].Cells[i, colCode].Value = row[xC.xtDB.jimDB.jim.job_import_code].ToString();
        //        //grdView.Sheets[0].Cells[i, colCusT].Value = xC.xtDB.cusDB.getNameTById(row[xC.xtDB.jimDB.jim.cust_id].ToString());
        //        //grdView.Sheets[0].Cells[i, colImpT].Value = xC.xtDB.impDB.getNameTById(row[xC.xtDB.jimDB.jim.imp_id].ToString());
        //        grdView.Sheets[0].Cells[i, colCusT].Value = row[xC.xtDB.cusDB.cus.cust_name_t].ToString();
        //        grdView.Sheets[0].Cells[i, colImpT].Value = row[xC.xtDB.impDB.imp.imp_name_t].ToString();
        //        grdView.Sheets[0].Cells[i, colRemark].Value = row[xC.xtDB.jimDB.jim.remark].ToString();
        //        grdView.Sheets[0].Cells[i, colTmn].Value = row[xC.xtDB.tmnDB.tmn.terminal_name_t].ToString();
        //        grdView.Sheets[0].Cells[i, colFwd].Value = row[xC.xtDB.fwdDB.fwd.forwarder_name_t].ToString();
        //        grdView.Sheets[0].Cells[i, colJblDesc].Value = row[xC.xtDB.jblDB.jbl.description].ToString();
        //        grdView.Sheets[0].Cells[i, colCntInv].Value = row["cntinv"].ToString();
        //        //grdView.Sheets[0].Cells[i, colCntExpn].Value = row["cntexpn"].ToString();

        //        grdView.Sheets[0].Cells[i, coledit].Value = "0";
        //        if (i % 2 != 0)
        //        {
        //            grdView.Sheets[0].Cells[i, 0, i, colCnt - 1].BackColor = System.Drawing.Color.FromArgb(235, 241, 222);
        //        }

        //        columnobj.Locked = true;

        //        i++;
        //    }
        //}

        private void cboProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = ((KeyValuePair<string, string>)cboYear.SelectedItem).Value;
            string key = ((KeyValuePair<string, string>)cboYear.SelectedItem).Key;
            //setGrdView(key);
        }

        private void FrmJobImpView_Load(object sender, EventArgs e)
        {
            //grdView.Top = grdView.Top - 30;

            //grdView.Top = cboYear.Top+20;

            cboYear.DataSource = new BindingSource(xC.manDB.jimDB.getlJobYear(), null);
            cboYear.DisplayMember = "Value";
            cboYear.ValueMember = "Key";

            String year = "";
            year = xC.manDB.jimDB.getYearCurr();
            cboYear.Text = year;
            //setGrdView(year);
        }
        //private void grdView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        //{
        //    xC.jobID = grdView.Sheets[0].Cells[e.Row, colID].Value == null ? "" : grdView.Sheets[0].Cells[e.Row, colID].Value.ToString();
        //    if (!xC.jobID.Equals(""))
        //    {
        //        FrmJobImpNew frm = new FrmJobImpNew(xC);
        //        frm.FormBorderStyle = FormBorderStyle.None;
        //        menu.AddNewTab(frm, "Import Job Detail");
        //    }
        //}

    }
}
