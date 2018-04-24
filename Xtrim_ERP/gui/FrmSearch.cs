using C1.Win.C1FlexGrid;
using C1.Win.C1Ribbon;
using FarPoint.Win.Spread;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xtrim_ERP.control;
using static Xtrim_ERP.control.XtrimControl;

namespace Xtrim_ERP.object1
{
    public class FrmSearch : Form
    {
        XtrimControl xC;
        FpSpread grdView;
        C1FlexGrid grdFlex;
        StatusBar sB;

        //int colID = 1;
        
        public enum Search
        {
            Customer,
            Importer,
            Regular,
            Important,
            Critical
        };
        Search flag;
        //private CellStyle _style;
        //private int _row = -1;          // index of filter row (-1 if none)
        //private int _col = -1;			// index of filter row cell being edited (-1 if none)


        Font fEdit, fEditB;
        int colNo = 0, colID = 1, colNameT = 2, colNameE = 3, colRemark = 4, coledit = 5;
        int colCnt = 6;


        public FrmSearch(XtrimControl x, Search f)
        {
            xC = x;
            flag = f;
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            initConfig();
            //initConfigSpreadGrd();
            initConfigFlexGrd();
        }
        private void initConfig()
        {
            //Set up the form.
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Size = new System.Drawing.Size(800, 400);
            this.Text = "Run-time Controls";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void initConfigSpreadGrd()
        {
            grdView = new FpSpread();
            grdView.Font = fEdit;

            FarPoint.Win.Spread.EnhancedInterfaceRenderer outlinelook = new FarPoint.Win.Spread.EnhancedInterfaceRenderer();
            outlinelook.RangeGroupBackgroundColor = Color.LightGreen;
            outlinelook.RangeGroupButtonBorderColor = Color.Red;
            outlinelook.RangeGroupLineColor = Color.Blue;
            grdView.InterfaceRenderer = outlinelook;
            grdView.AccessibleDescription = "";
            grdView.Dock = System.Windows.Forms.DockStyle.Fill;
            grdView.Location = new System.Drawing.Point(0, 0);
            grdView.Sheets.Count = 1;
            grdView.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;

            grdView.BorderStyle = BorderStyle.None;
            grdView.Sheets[0].Columns[colID, colRemark].AllowAutoFilter = true;
            grdView.Sheets[0].Columns[colID, colRemark].AllowAutoSort = true;
            grdView.Sheets[0].AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu;
            grdView.Sheets[0].ColumnCount = colCnt;
            grdView.Sheets[0].RowCount = 1;

            FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();

            Controls.Add(grdView);
        }
        private void initConfigFlexGrd()
        {
            grdFlex = new C1FlexGrid();
            grdFlex.Font = fEdit;
            grdFlex.Dock = System.Windows.Forms.DockStyle.Fill;
            grdFlex.Location = new System.Drawing.Point(0, 0);
            // initialize grid
            //grdFlex.Styles = new C1FlexGrid.CellStyleCollection(@"Fixed{BackColor:Control;ForeColor:ControlText;Border:Flat,1,ControlDark,Both;}	Highlight{BackColor:Highlight;ForeColor:HighlightText;}	Search{BackColor:Highlight;ForeColor:HighlightText;}	Frozen{BackColor:Beige;}	EmptyArea{BackColor:AppWorkspace;Border:Flat,1,ControlDarkDark,Both;}	GrandTotal{BackColor:Black;ForeColor:White;}	Subtotal0{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal1{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal2{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal3{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal4{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal5{BackColor:ControlDarkDark;ForeColor:White;}	");
            //grdFlex.DataSource = xC.xtDB.cusDB.lCus;
            if (flag == Search.Customer)
            {
                grdFlex.DataSource = xC.xtDB.cusDB.dtCus;
            }else if(flag == Search.Importer)
            {
                grdFlex.DataSource = xC.xtDB.impDB.dtImp;
            }
            
            grdFlex.Cols[colID].Width = 60;
            grdFlex.Cols[colNameT].Width = 20;
            //grdFlex.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            grdFlex.Cols[colID].Caption = "code";
            grdFlex.Cols[colNameT].Caption = "name t";

            FilterRow fr = new FilterRow(grdFlex);

            sB = new StatusBar();
            //sB.AutoSizeElement = C1.Framework.AutoSizeElement.Width;
            sB.Location = new System.Drawing.Point(0, 228);
            sB.Name = "c1StatusBar1";
            sB.Size = new System.Drawing.Size(440, 23);

            grdFlex.AfterDataRefresh += new System.ComponentModel.ListChangedEventHandler(this.c1StatusBar_AfterDataRefresh);
            grdFlex.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdFlex_CellChanged);
            grdFlex.LeaveCell += new System.EventHandler(this.grdFlex_LeaveCell);
            //c1StatusBar.Dock
            // create styles with data types, formats, etc
            //CellStyle cs = _flex.Styles.Add("emp");
            //cs.DataType = typeof(string);
            //cs.ComboList = "|Tom|Dick|Harry";
            //cs.ForeColor = Color.Navy;
            //cs.Font = new Font(Font, FontStyle.Bold);
            //_flex[r, 1]

            Controls.Add(grdFlex);
            Controls.Add(sB);
        }
        private void grdFlex_LeaveCell(object sender, EventArgs e)
        {
            
        }
        private void grdFlex_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            //sB.Text = grdFlex.Rows[e.Row].ToString();
        }
        void c1StatusBar_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            int cnt = grdFlex.Rows.Count - grdFlex.Rows.Fixed;
            sB.Text = cnt.ToString() + " rows in data source";
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ...
            if (keyData == (Keys.Escape))
            {
                //if (MessageBox.Show("ต้องการออกจากโปรแกรม", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                //{
                Close();
                return true;
                //}
            }
            else if (keyData == (Keys.F12))
            {
                
                if(grdFlex.Row != grdFlex.Rows.Fixed)
                {
                    if (flag == Search.Customer)
                    {
                        xC.sCus = new Customer();
                        xC.sCus = xC.xtDB.cusDB.selectByPk1(grdFlex[grdFlex.Row, colID].ToString());                        
                    }else if (flag == Search.Importer)
                    {
                        xC.sImp = new Importer();
                        xC.sImp = xC.xtDB.impDB.selectByPk1(grdFlex[grdFlex.Row, colID].ToString());
                    }
                    Close();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
