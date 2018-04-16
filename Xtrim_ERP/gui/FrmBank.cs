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
using Xtrim_ERP.objdb;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.gui
{
    public partial class FrmBank : Form
    {
        Bank ban;
        XtrimControl xC;
        Font fEdit, fEditB;

        int colID = 0, colE = 1, colS = 2, colCode = 3, colNameT = 4, colNameE = 5, colRemark = 6, coledit=7;

        

        int colCnt = 8;

        public FrmBank(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            ban = new Bank();
            fEdit = grdView.Font;
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Bold);

            ContextMenu custommenu = new ContextMenu();
            custommenu.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_void));
            //custommenu.MenuItems.Add("&ยกเลิก";
            grdView.ContextMenu = custommenu;
            
            setGrdView();
        }
        private void ContextMenu_void(object sender, System.EventArgs e)
        {
            FarPoint.Win.Spread.Row row = grdView.ActiveSheet.ActiveRow;
            FarPoint.Win.Spread.Column c;
            c = grdView.ActiveSheet.ActiveColumn;
            String aa = grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colCode].Value == null ? "" : grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colCode].Value.ToString();
            if (MessageBox.Show("ต้องการ ยกเลิก \nรายการ" + aa, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String re = xC.xtDB.banDB.voidBank(grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colID].Value == null ? "" : grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colID].Value.ToString());
                if (re.Equals("1"))
                {
                    grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[grdView.ActiveSheet.ActiveRow.Index, 0, grdView.ActiveSheet.ActiveRow.Index, colCnt - 1].BackColor = Color.Gray;
                }
            }
        }
        private void setGrdViewH()
        {
            FarPoint.Win.Spread.EnhancedInterfaceRenderer outlinelook = new FarPoint.Win.Spread.EnhancedInterfaceRenderer();
            outlinelook.RangeGroupBackgroundColor = Color.LightGreen;
            outlinelook.RangeGroupButtonBorderColor = Color.Red;
            outlinelook.RangeGroupLineColor = Color.Blue;
            grdView.InterfaceRenderer = outlinelook;
            grdView.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

            grdView.BorderStyle = BorderStyle.None;
            grdView.Sheets[0].Columns[colCode, colRemark].AllowAutoFilter = true;
            grdView.Sheets[0].Columns[colCode, colRemark].AllowAutoSort = true;
            grdView.Sheets[0].AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu;

            FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttoncell = new FarPoint.Win.Spread.CellType.ButtonCellType();

            grdView.Sheets[0].ColumnCount = colCnt;
            grdView.Sheets[0].RowCount = 1;
            grdView.Font = fEdit;

            grdView.Sheets[0].Columns[colID].CellType = objTextCell;
            grdView.Sheets[0].Columns[colE].CellType = buttoncell;
            grdView.Sheets[0].Columns[colS].CellType = buttoncell;
            grdView.Sheets[0].Columns[colCode].CellType = objTextCell;
            grdView.Sheets[0].Columns[colNameT].CellType = objTextCell;
            grdView.Sheets[0].Columns[colNameE].CellType = objTextCell;
            grdView.Sheets[0].Columns[colRemark].CellType = objTextCell;
            grdView.Sheets[0].Columns[coledit].CellType = objTextCell;

            grdView.Sheets[0].ColumnHeader.Cells[0, colE].Text = "edit";
            grdView.Sheets[0].ColumnHeader.Cells[0, colS].Text = "save";
            grdView.Sheets[0].ColumnHeader.Cells[0, colCode].Text = "code";
            grdView.Sheets[0].ColumnHeader.Cells[0, colNameT].Text = "ชื่อภาษาไทย";
            grdView.Sheets[0].ColumnHeader.Cells[0, colNameE].Text = "ชื่อภาษาอังกฤษ";
            grdView.Sheets[0].ColumnHeader.Cells[0, colRemark].Text = "หมายเหตุ";

            grdView.Sheets[0].Columns[colE].Width = 50;
            grdView.Sheets[0].Columns[colS].Width = 50;
            grdView.Sheets[0].Columns[colCode].Width = 80;
            grdView.Sheets[0].Columns[colNameT].Width = 200;
            grdView.Sheets[0].Columns[colNameE].Width = 200;
            grdView.Sheets[0].Columns[colRemark].Width = 200;

            grdView.Sheets[0].Columns[colID].Visible = false;
            grdView.Sheets[0].Columns[coledit].Visible = false;

            grdView.AllowColumnMove = true;
        }
        private void setGrdView()
        {
            DataTable dt = new DataTable();
            int i = 0;
            FarPoint.Win.Spread.Column columnobj;
            columnobj = grdView.ActiveSheet.Columns[colCode, colRemark];

            dt = xC.xtDB.banDB.selectAll();
            grdView.Sheets[0].Rows.Clear();
            setGrdViewH();
            grdView.Sheets[0].RowCount = dt.Rows.Count+1;
            foreach (DataRow row in dt.Rows)
            {
                grdView.Sheets[0].Cells[i, colID].Value = row[xC.xtDB.banDB.ban.bank_id] == null ? "" : row[xC.xtDB.banDB.ban.bank_id].ToString();
                grdView.Sheets[0].Cells[i, colCode].Value = row[xC.xtDB.banDB.ban.bank_code].ToString();
                grdView.Sheets[0].Cells[i, colNameT].Value = row[xC.xtDB.banDB.ban.bank_name_t].ToString();
                grdView.Sheets[0].Cells[i, colNameE].Value = row[xC.xtDB.banDB.ban.bank_name_e].ToString();
                grdView.Sheets[0].Cells[i, colRemark].Value = row[xC.xtDB.banDB.ban.remark].ToString();

                grdView.Sheets[0].Cells[i, coledit].Value = "0";
                if (i % 2 != 0)
                {
                    grdView.Sheets[0].Cells[i, 0, i, colCnt - 1].BackColor = System.Drawing.Color.FromArgb(235, 241, 222);
                }
                
                columnobj.Locked = true;

                i++;
            }
        }
        private void grdView_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, coledit].Value = "1";
            grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, e.Column].Font = fEdit;
            grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, e.Column].ForeColor = Color.Red;
            
        }
        private void grdView_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == colE)
            {
                grdView.Sheets[grdView.ActiveSheet.SheetName].OperationMode = FarPoint.Win.Spread.OperationMode.Normal;
                FarPoint.Win.Spread.Cell cellobj;
                cellobj = grdView.ActiveSheet.Cells[e.Row, colCode, e.Row, colRemark];
                cellobj.Locked = false;
                //grdView.Sheets[0].Rows.
            }
            else if (e.Column == colS)
            {
                //for (int i = 0; i < grdView.Sheets[grdView.ActiveSheet.SheetName].RowCount; i++)
                //{
                String edit = "";
                if (grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, coledit].Value.Equals("1"))
                {
                    if(grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, colCode].Value == null)
                    {
                        MessageBox.Show("รหัส ไม่มีค่า", "error");
                        return;
                    }
                    Bank ban = new Bank();
                    ban.active = "1";
                    ban.bank_id = grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, colID].Value == null ? "" :  grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, colID].Value.ToString().Trim();
                    ban.bank_code= grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, colCode].Value == null ? "" : grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, colCode].Value.ToString().Trim();
                    ban.bank_name_e = grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, colNameE].Value == null ? "" : grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, colNameE].Value.ToString().Trim();
                    ban.bank_name_t = grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, colNameT].Value == null ? "" : grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, colNameT].Value.ToString().Trim();
                    ban.remark = grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, colRemark].Value == null ? "" : grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, colRemark].Value.ToString().Trim();
                    String re = xC.xtDB.banDB.insertBank(ban);
                    int re1 = 0;
                    if(int.TryParse(re, out re1))
                    {
                        grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[e.Row, 0, e.Row, colCnt - 1].BackColor = Color.GreenYellow;
                        if((e.Row+1) == grdView.Sheets[0].RowCount)
                        {
                            grdView.Sheets[0].RowCount++;
                        }
                    }
                }
                //}
            }
        }
        private void FrmBank_Load(object sender, EventArgs e)
        {

        }
    }
}
