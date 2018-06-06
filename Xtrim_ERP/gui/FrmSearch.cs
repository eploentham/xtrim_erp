using C1.Win.C1FlexGrid;
using C1.Win.C1Ribbon;

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
        //FpSpread grdView;
        C1FlexGrid grdFlex;
        StatusBar sB;

        //int colID = 1;
        
        public enum Search
        {
            Customer,
            Importer,
            Forwarder,
            EntryType,
            PortOfLoading,
            Privilege,
            Staff,
            Country,
            EntryType1,
            PortImport,
            IncoTerm,
            TermPayment,
            Insurance,
            Currency
        };
        Search flag;
        //private CellStyle _style;
        //private int _row = -1;          // index of filter row (-1 if none)
        //private int _col = -1;			// index of filter row cell being edited (-1 if none)


        Font fEdit, fEditB;
        int colNo = 0, colID = 1, colNameT = 2, colNameE = 3, colRemark = 4, coledit = 5;
        int colCnt = 6;
        String txtS = "";


        public FrmSearch(XtrimControl x, Search f)
        {
            xC = x;
            flag = f;
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            initConfig();
            //initConfigSpreadGrd();
            initConfigFlexGrd();
        }
        public FrmSearch(XtrimControl x, Search f, String txt)
        {
            xC = x;
            flag = f;
            this.txtS = txt;
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            initConfig();
            //initConfigSpreadGrd();
            initConfigFlexGrd();
        }
        public FrmSearch(XtrimControl x, Search f,Point pp)
        {
            xC = x;
            flag = f;
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            //this.Top = top+10;
            
            initConfig(pp);
            //initConfigSpreadGrd();
            initConfigFlexGrd();
        }
        private void initConfig()
        {
            initConfig(new Point(0,0));
        }
        private void initConfig(Point pp)
        {
            //Set up the form.
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Size = new System.Drawing.Size(800, 400);
            this.Location = pp;
            this.Text = "Run-time Controls";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.Manual;
            //this.StartPosition = FormStartPosition.CenterParent;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmSearch
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FrmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);

        }

        //private void initConfigSpreadGrd()
        //{
        //    grdView = new FpSpread();
        //    grdView.Font = fEdit;

        //    FarPoint.Win.Spread.EnhancedInterfaceRenderer outlinelook = new FarPoint.Win.Spread.EnhancedInterfaceRenderer();
        //    outlinelook.RangeGroupBackgroundColor = Color.LightGreen;
        //    outlinelook.RangeGroupButtonBorderColor = Color.Red;
        //    outlinelook.RangeGroupLineColor = Color.Blue;
        //    grdView.InterfaceRenderer = outlinelook;
        //    grdView.AccessibleDescription = "";
        //    grdView.Dock = System.Windows.Forms.DockStyle.Fill;
        //    grdView.Location = new System.Drawing.Point(0, 0);
        //    grdView.Sheets.Count = 1;
        //    grdView.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;

        //    grdView.BorderStyle = BorderStyle.None;
        //    grdView.Sheets[0].Columns[colID, colRemark].AllowAutoFilter = true;
        //    grdView.Sheets[0].Columns[colID, colRemark].AllowAutoSort = true;
        //    grdView.Sheets[0].AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu;
        //    grdView.Sheets[0].ColumnCount = colCnt;
        //    grdView.Sheets[0].RowCount = 1;

        //    FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();

        //    Controls.Add(grdView);
        //}
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
                grdFlex.DataSource = xC.xtDB.cusDB.selectCusAll();
            }
            else if(flag == Search.Importer)
            {
                grdFlex.DataSource = xC.xtDB.cusDB.selectImpAll();
            }
            else if (flag == Search.Forwarder)
            {
                grdFlex.DataSource = xC.xtDB.fwdDB.dtFwd;
            }
            else if (flag == Search.EntryType)
            {
                grdFlex.DataSource = xC.xtDB.ettDB.selectAll();
            }
            else if (flag == Search.PortOfLoading)
            {
                grdFlex.DataSource = xC.xtDB.polDB.selectAll();
            }
            else if (flag == Search.Privilege)
            {
                grdFlex.DataSource = xC.xtDB.pvlDB.selectAll();
            }
            else if (flag == Search.Staff)
            {
                grdFlex.DataSource = xC.xtDB.stfDB.selectAll1();
            }
            else if (flag == Search.Country)
            {
                grdFlex.DataSource = xC.xtDB.cotDB.selectAll();
            }
            else if (flag == Search.EntryType)
            {
                grdFlex.DataSource = xC.xtDB.ettDB.selectAll();
            }
            else if (flag == Search.PortImport)
            {
                grdFlex.DataSource = xC.xtDB.ptiDB.selectAll();
            }
            else if (flag == Search.IncoTerm)
            {
                grdFlex.DataSource = xC.xtDB.ictDB.selectAll();
            }
            else if (flag == Search.TermPayment)
            {
                grdFlex.DataSource = xC.xtDB.tpmDB.selectAll();
            }
            else if (flag == Search.Insurance)
            {
                grdFlex.DataSource = xC.xtDB.cusDB.selectInsrAll();
            }
            else if (flag == Search.Currency)
            {
                grdFlex.DataSource = xC.xtDB.currDB.selectAll();
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

            if (!txtS.Equals(""))
            {
                grdFlex[1, colNameT] = txtS;
            }

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
                //if(grdFlex.Row != grdFlex.Rows.Fixed)
                //{
                if (grdFlex[grdFlex.Row, colID] == null) return true;
                if (flag == Search.Customer)
                {
                    xC.sCus = new Customer();
                    xC.sCus = xC.xtDB.cusDB.selectByPk1(grdFlex[grdFlex.Row, colID].ToString());                        
                }
                else if (flag == Search.Importer)
                {
                    xC.sImp = new Customer();
                    xC.sImp = xC.xtDB.cusDB.selectByPk1(grdFlex[grdFlex.Row, colID].ToString());
                }
                else if (flag == Search.Forwarder)
                {
                    xC.sFwd = new Customer();
                    xC.sFwd = xC.xtDB.cusDB.selectByPk1(grdFlex[grdFlex.Row, colID].ToString());
                }
                else if (flag == Search.EntryType)
                {
                    xC.sEtt = new EntryType();
                    xC.sEtt = xC.xtDB.ettDB.selectByPk1(grdFlex[grdFlex.Row, colID].ToString());
                }
                else if (flag == Search.PortOfLoading)
                {
                    xC.sPol = new PortOfLoading();
                    xC.sPol = xC.xtDB.polDB.selectByPk1(grdFlex[grdFlex.Row, colID].ToString());
                }
                else if (flag == Search.Privilege)
                {
                    xC.sPvl = new Privilege();
                    xC.sPvl = xC.xtDB.pvlDB.selectByPk1(grdFlex[grdFlex.Row, colID].ToString());
                }
                else if (flag == Search.Staff)
                {
                    xC.sStf = new Staff();
                    xC.sStf = xC.xtDB.stfDB.selectByPk1(grdFlex[grdFlex.Row, colID].ToString());
                }
                else if (flag == Search.Country)
                {
                    xC.sCot = new Country();
                    xC.sCot = xC.xtDB.cotDB.selectByPk1(grdFlex[grdFlex.Row, colID].ToString());
                }
                else if (flag == Search.EntryType)
                {
                    xC.sCot = new Country();
                    xC.sEtt = xC.xtDB.ettDB.selectByPk1(grdFlex[grdFlex.Row, colID].ToString());
                }
                else if (flag == Search.PortImport)
                {
                    xC.sCot = new Country();
                    xC.sPti = xC.xtDB.ptiDB.selectByPk1(grdFlex[grdFlex.Row, colID].ToString());
                }
                else if (flag == Search.IncoTerm)
                {
                    xC.sIct = new IncoTerms();
                    xC.sIct = xC.xtDB.ictDB.selectByPk1(grdFlex[grdFlex.Row, colID].ToString());
                }
                else if (flag == Search.TermPayment)
                {
                    xC.sTpm = new TermPayment();
                    xC.sTpm = xC.xtDB.tpmDB.selectByPk1(grdFlex[grdFlex.Row, colID].ToString());
                }
                else if (flag == Search.Insurance)
                {
                    xC.sInsr = new Customer();
                    xC.sInsr = xC.xtDB.cusDB.selectByPk1(grdFlex[grdFlex.Row, colID].ToString());
                }
                else if (flag == Search.Currency)
                {
                    xC.sCurr = new Currency();
                    xC.sCurr = xC.xtDB.currDB.selectByPk1(grdFlex[grdFlex.Row, colID].ToString());
                }
                Close();
                return true;
                //}
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
