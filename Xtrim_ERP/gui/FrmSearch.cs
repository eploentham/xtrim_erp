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
        C1FlexGrid grfFlex, grfAddr;
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
            Currency,
            Truck, 
            TruckCop,
            AddressPlaceAddr,
            AddressContainerYard,
            ContainerYard,
            Items
        };
        Search flag;
        //private CellStyle _style;
        //private int _row = -1;          // index of filter row (-1 if none)
        //private int _col = -1;			// index of filter row cell being edited (-1 if none)
        
        Font fEdit, fEditB;
        int colNo = 0, colID = 1, colNameT = 2, colNameE = 3, colRemark = 4, coledit = 5;
        int colCnt = 6;
        String txtS = "", flagAddr="";
        
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
        public FrmSearch(XtrimControl x, Search f, Point pp, String flagaddr)
        {
            xC = x;
            flag = f;
            flagAddr = flagaddr;
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
            if (flag == Search.AddressPlaceAddr)
            {
                this.Size = new System.Drawing.Size(800, 600);
            }
            else
            {
                this.Size = new System.Drawing.Size(800, 400);
            }
            
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
            grfFlex = new C1FlexGrid();
            grfAddr = new C1FlexGrid();
            grfFlex.Font = fEdit;
            grfAddr.Font = fEdit;
            grfFlex.Dock = System.Windows.Forms.DockStyle.Fill;
            grfFlex.Location = new System.Drawing.Point(0, 0);
            // initialize grid
            //grdFlex.Styles = new C1FlexGrid.CellStyleCollection(@"Fixed{BackColor:Control;ForeColor:ControlText;Border:Flat,1,ControlDark,Both;}	Highlight{BackColor:Highlight;ForeColor:HighlightText;}	Search{BackColor:Highlight;ForeColor:HighlightText;}	Frozen{BackColor:Beige;}	EmptyArea{BackColor:AppWorkspace;Border:Flat,1,ControlDarkDark,Both;}	GrandTotal{BackColor:Black;ForeColor:White;}	Subtotal0{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal1{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal2{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal3{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal4{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal5{BackColor:ControlDarkDark;ForeColor:White;}	");
            //grdFlex.DataSource = xC.xtDB.cusDB.lCus;
            if (flag == Search.Customer)
            {
                grfFlex.DataSource = xC.xtDB.cusDB.selectCusAll();
            }
            else if(flag == Search.Importer)
            {
                grfFlex.DataSource = xC.xtDB.cusDB.selectImpAll();
            }
            else if (flag == Search.Forwarder)
            {
                grfFlex.DataSource = xC.xtDB.fwdDB.dtFwd;
            }
            else if (flag == Search.EntryType)
            {
                grfFlex.DataSource = xC.xtDB.ettDB.selectAll();
            }
            else if (flag == Search.PortOfLoading)
            {
                grfFlex.DataSource = xC.xtDB.polDB.selectAll();
            }
            else if (flag == Search.Privilege)
            {
                grfFlex.DataSource = xC.xtDB.pvlDB.selectAll();
            }
            else if (flag == Search.Staff)
            {
                grfFlex.DataSource = xC.xtDB.stfDB.selectAll1();
            }
            else if (flag == Search.Country)
            {
                grfFlex.DataSource = xC.xtDB.cotDB.selectAll();
            }
            else if (flag == Search.EntryType)
            {
                grfFlex.DataSource = xC.xtDB.ettDB.selectAll();
            }
            else if (flag == Search.PortImport)
            {
                grfFlex.DataSource = xC.xtDB.ptiDB.selectAll();
            }
            else if (flag == Search.IncoTerm)
            {
                grfFlex.DataSource = xC.xtDB.ictDB.selectAll();
            }
            else if (flag == Search.TermPayment)
            {
                grfFlex.DataSource = xC.xtDB.tpmDB.selectAll();
            }
            else if (flag == Search.Insurance)
            {
                grfFlex.DataSource = xC.xtDB.cusDB.selectInsrAll();
            }
            else if (flag == Search.Currency)
            {
                grfFlex.DataSource = xC.xtDB.currDB.selectAll();
            }
            else if (flag == Search.Truck)
            {
                grfFlex.DataSource = xC.xtDB.trkDB.selectAll();
            }
            else if (flag == Search.TruckCop)
            {
                grfFlex.DataSource = xC.xtDB.cusDB.selectTrkCopAll();
            }
            else if (flag == Search.AddressPlaceAddr)
            {
                grfFlex.DataSource = xC.xtDB.cusDB.selectImpAll();
            }
            else if (flag == Search.AddressContainerYard)
            {
                grfFlex.DataSource = xC.xtDB.cusDB.selectContainerYardAll();
            }
            else if (flag == Search.ContainerYard)
            {
                grfFlex.DataSource = xC.xtDB.cusDB.selectContainerYardAll();
            }
            else if (flag == Search.Items)
            {
                grfFlex.DataSource = xC.xtDB.itmDB.selectAll1("1");
            }
            grfFlex.Cols[colID].Width = 60;
            grfFlex.Cols[colNameT].Width = 20;
            //grdFlex.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            grfFlex.Cols[colID].Caption = "code";
            grfFlex.Cols[colNameT].Caption = "name t";

            FilterRow fr = new FilterRow(grfFlex);

            sB = new StatusBar();
            //sB.AutoSizeElement = C1.Framework.AutoSizeElement.Width;
            sB.Location = new System.Drawing.Point(0, 228);
            sB.Name = "c1StatusBar1";
            sB.Size = new System.Drawing.Size(440, 23);

            grfFlex.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(grfFlex_AfterRowColChange);
            grfFlex.AfterDataRefresh += new System.ComponentModel.ListChangedEventHandler(this.c1StatusBar_AfterDataRefresh);
            grfFlex.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdFlex_CellChanged);
            grfFlex.LeaveCell += new System.EventHandler(this.grdFlex_LeaveCell);
            //c1StatusBar.Dock
            // create styles with data types, formats, etc
            //CellStyle cs = _flex.Styles.Add("emp");
            //cs.DataType = typeof(string);
            //cs.ComboList = "|Tom|Dick|Harry";
            //cs.ForeColor = Color.Navy;
            //cs.Font = new Font(Font, FontStyle.Bold);
            //_flex[r, 1]

            Panel panel1 = new Panel();
            if (!txtS.Equals(""))
            {
                grfFlex[1, colNameT] = txtS;
            }
            if ((flag == Search.AddressPlaceAddr) || (flag == Search.ContainerYard))
            {

                Panel panel2 = new Panel();
                panel2.Dock = DockStyle.Bottom;
                panel2.Height = 180;
                Controls.Add(panel2);
                panel1.Dock = DockStyle.Top;
                panel1.Height = this.Height - sB.Height - panel2.Height - 45;
                grfAddr.Dock = DockStyle.Fill;
                grfAddr.Location = new System.Drawing.Point(0, 0);
                panel2.Controls.Add(grfAddr);
                
            }
            else
            {
                panel1.Dock = DockStyle.Fill;
            }
            
            panel1.Controls.Add(grfFlex);
            
            Controls.Add(panel1);
            Controls.Add(sB);
        }

        private void grfFlex_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            String cusId = "";
            cusId = grfFlex[e.NewRange.r1, colID] != null ? grfFlex[e.NewRange.r1, colID].ToString() : "";
            grfAddr.DataSource = xC.xtDB.addrDB.selectByTableId1(cusId);
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
            int cnt = grfFlex.Rows.Count - grfFlex.Rows.Fixed;
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
                if (grfFlex[grfFlex.Row, colID] == null) return true;
                if (flag == Search.Customer)
                {
                    xC.sCus = new Customer();
                    xC.sCus = xC.xtDB.cusDB.selectByPk1(grfFlex[grfFlex.Row, colID].ToString());                        
                }
                else if (flag == Search.Importer)
                {
                    xC.sImp = new Customer();
                    xC.sImp = xC.xtDB.cusDB.selectByPk1(grfFlex[grfFlex.Row, colID].ToString());
                }
                else if (flag == Search.Forwarder)
                {
                    xC.sFwd = new Customer();
                    xC.sFwd = xC.xtDB.cusDB.selectByPk1(grfFlex[grfFlex.Row, colID].ToString());
                }
                else if (flag == Search.EntryType)
                {
                    xC.sEtt = new EntryType();
                    xC.sEtt = xC.xtDB.ettDB.selectByPk1(grfFlex[grfFlex.Row, colID].ToString());
                }
                else if (flag == Search.PortOfLoading)
                {
                    xC.sPol = new PortOfLoading();
                    xC.sPol = xC.xtDB.polDB.selectByPk1(grfFlex[grfFlex.Row, colID].ToString());
                }
                else if (flag == Search.Privilege)
                {
                    xC.sPvl = new Privilege();
                    xC.sPvl = xC.xtDB.pvlDB.selectByPk1(grfFlex[grfFlex.Row, colID].ToString());
                }
                else if (flag == Search.Staff)
                {
                    xC.sStf = new Staff();
                    xC.sStf = xC.xtDB.stfDB.selectByPk1(grfFlex[grfFlex.Row, colID].ToString());
                }
                else if (flag == Search.Country)
                {
                    xC.sCot = new Country();
                    xC.sCot = xC.xtDB.cotDB.selectByPk1(grfFlex[grfFlex.Row, colID].ToString());
                }
                else if (flag == Search.EntryType)
                {
                    xC.sCot = new Country();
                    xC.sEtt = xC.xtDB.ettDB.selectByPk1(grfFlex[grfFlex.Row, colID].ToString());
                }
                else if (flag == Search.PortImport)
                {
                    xC.sCot = new Country();
                    xC.sPti = xC.xtDB.ptiDB.selectByPk1(grfFlex[grfFlex.Row, colID].ToString());
                }
                else if (flag == Search.IncoTerm)
                {
                    xC.sIct = new IncoTerms();
                    xC.sIct = xC.xtDB.ictDB.selectByPk1(grfFlex[grfFlex.Row, colID].ToString());
                }
                else if (flag == Search.TermPayment)
                {
                    xC.sTpm = new TermPayment();
                    xC.sTpm = xC.xtDB.tpmDB.selectByPk1(grfFlex[grfFlex.Row, colID].ToString());
                }
                else if (flag == Search.Insurance)
                {
                    xC.sInsr = new Customer();
                    xC.sInsr = xC.xtDB.cusDB.selectByPk1(grfFlex[grfFlex.Row, colID].ToString());
                }
                else if (flag == Search.Currency)
                {
                    xC.sCurr = new Currency();
                    xC.sCurr = xC.xtDB.currDB.selectByPk1(grfFlex[grfFlex.Row, colID].ToString());
                }
                else if (flag == Search.Truck)
                {
                    xC.sTrk = new Truck();
                    xC.sTrk = xC.xtDB.trkDB.selectByPk1(grfFlex[grfFlex.Row, colID].ToString());
                }
                else if (flag == Search.TruckCop)
                {
                    xC.sTrkCop = new Customer();
                    xC.sTrkCop = xC.xtDB.cusDB.selectByPk1(grfFlex[grfFlex.Row, colID].ToString());
                }
                else if (flag == Search.AddressPlaceAddr)
                {
                    xC.sAddr = new Address();
                    xC.sAddr = xC.xtDB.addrDB.selectByPk1(grfAddr[grfAddr.Row, colID].ToString());
                }
                else if (flag == Search.AddressContainerYard)
                {
                    xC.sAddr = new Address();
                    xC.sAddr = xC.xtDB.addrDB.selectByPk1(grfAddr[grfAddr.Row, colID].ToString());
                }
                else if (flag == Search.ContainerYard)
                {
                    xC.sConY = new Customer();
                    xC.sConY = xC.xtDB.cusDB.selectByPk1(grfFlex[grfFlex.Row, colID].ToString());
                    xC.sAddr = new Address();
                    xC.sAddr = xC.xtDB.addrDB.selectByPk1(grfAddr[grfAddr.Row, colID].ToString());
                }
                else if (flag == Search.Items)
                {
                    xC.sItm = new Items();
                    xC.sItm = xC.xtDB.itmDB.selectByPk1(grfFlex[grfFlex.Row, colID].ToString());
                }
                Close();
                return true;
                //}
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
