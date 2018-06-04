using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using C1.Win.Calendar;
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
using Xtrim_ERP.Properties;

namespace Xtrim_ERP.gui
{
    public partial class FrmJobImpNew1 : Form
    {
        XtrimControl xC;
        JobImport jim;
        Font fEdit, fEditB;
        Color bg, fc, grfOld;
        Font ff, ffB;
        int colJobNo = 1, colimpJob = 2, colJobDate = 3, colImpDate = 4, colBL = 5, colImporter = 6, colVslName = 7, colHouseBL = 8, colNameT = 9, colNameE = 10;
        int colvslnamerem = 11, colOrigin = 12, colConsignmnt = 13, colLoaded = 14, colLoadedName = 15, colRelease = 16, colReleaseName = 17, colOutReplease = 18;
        int colOutRepleaseName=19, colApproval=20, colApprovalName=21;
        int grfRowOld = 0;

        int colExpenId = 1, colExpenDate = 2, colExpenItem = 3, colExpenPayment = 4, colExpenTaxDate = 5, colExpenTax = 6, colExpenAmt = 7, colExpenReceipt = 8, colExpenSplit=9, colExpenRemark=10;

        Boolean flagEdit = false;
        Boolean flagsearch = false, flagTabInv=false;
        C1FlexGrid grfSearch, grfExpen;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        String userIdVoid = "";
        Point locationPanelJob;
        Size sizePanelJob;
        public FrmJobImpNew1(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            grfSearch = new C1FlexGrid();
            jim = new JobImport();
            initGrfExpen();

            //theme1.SetTheme(tC1, "BeigeOne");
            //theme1.SetTheme(tC2, "BeigeOne");
            theme1.SetTheme(sB, "BeigeOne");

            xC.setCboTransMode(cboTransMode);
            xC.setCboTaxMethod(cboTaxMethod);
            xC.xtDB.ittDB.setCboImporterType(cboItt);
            xC.xtDB.cemDB.setCboCheckExam(cboChkExam);
            xC.xtDB.dctDB.setCboDocType(cboDocType);

            btnJobSearch.Click += BtnJobSearch_Click;
            chkCatiria.Click += ChkCatiria_Click;
            tabExpen.DoubleClick += TabExpen_DoubleClick;
            tabExpen.TabClick += TabExpen_TabClick;
            btnPrint.Click += BtnPrint_Click;
            btnSave.Click += BtnSave_Click;
            btnEdit.Click += BtnEdit_Click;

            txtCusNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtImpNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtStaffCS.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtPvlNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtPolNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtConsignmnt.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtEttNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtFwdNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);

            panel4.Height = txtJobCode.Height + 30;
            panel11.Height = 580;
            panel3.Height = this.Height - panel4.Height - panel11.Height-30;
            tC2.Height = this.Height - panel4.Height - panel11.Height - 30;

            panelCatiria.Hide();
            tC2.SelectedTab = tabAgent;
            //splitContainer1.SplitterDistance = 480;
            //setPanelSearch(false);
            //locationPanelJob = panelJob.Location;
            //sizePanelJob = panelJob.Size;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setJobImport();
                String re = xC.xtDB.jimDB.insertJobImport(jim);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                //setGrdView();
                this.Dispose();
            }
        }

        private void txtCusCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (sender.Equals(txtCusNameT))
                {
                    Point pp = txtCusNameT.Location;
                    pp.Y = pp.Y + 120;
                    pp.X = pp.X - 20;
                    
                    FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Customer, pp);
                    frm.ShowDialog(this);
                    lbCusAddr.Value = xC.sCus.taddr1 + "\n" + xC.sCus.taddr2 + "\n" + xC.sCus.taddr3 + "\n" + xC.sCus.taddr4;
                    txtCusNameT.Value = xC.sCus.cust_name_t;
                }
                else if (sender.Equals(txtImpNameT))
                {
                    Point pp = txtImpNameT.Location;
                    pp.Y = pp.Y + 120;
                    pp.X = pp.X - 20;
                    
                    FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Importer, pp);
                    frm.ShowDialog(this);
                    lbImpAddr.Value = xC.sImp.taddr1 + "\n" + xC.sImp.taddr2 + "\n" + xC.sImp.taddr3 + "\n" + xC.sImp.taddr4;
                    txtImpNameT.Value = xC.sImp.cust_name_t;
                }
                else if (sender.Equals(txtStaffCS))
                {
                    Point pp = txtStaffCS.Location;
                    pp.Y = pp.Y + 120;
                    pp.X = pp.X - 20;
                    
                    FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Staff, pp);
                    frm.ShowDialog(this);
                    txtStaffCS.Value = xC.sStf.staff_fname_t;
                }
                else if (sender.Equals(txtPvlNameT))
                {
                    Point pp = txtPvlNameT.Location;
                    pp.Y = pp.Y + 120;
                    pp.X = pp.X - 20;

                    FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Privilege, pp);
                    frm.ShowDialog(this);
                    txtPvlNameT.Value = xC.sPvl.desc1;
                }
                else if (sender.Equals(txtFwdNameT))
                {
                    Point pp = txtFwdNameT.Location;
                    pp.Y = pp.Y + 120;
                    pp.X = pp.X - 20;

                    FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Forwarder, pp);
                    frm.ShowDialog(this);
                    txtFwdNameT.Value = xC.sFwd.cust_name_t;
                }
                else if (sender.Equals(txtPolNameT))
                {
                    Point pp = txtPolNameT.Location;
                    pp.Y = pp.Y + 120;
                    pp.X = pp.X - 20;

                    FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.PortOfLoading, pp);
                    frm.ShowDialog(this);
                    txtPolNameT.Value = xC.sPol.port_of_loading_t;
                }
                else if (sender.Equals(txtConsignmnt))
                {
                    Point pp = txtConsignmnt.Location;
                    pp.Y = pp.Y + 120;
                    pp.X = pp.X - 20;

                    FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Consignmnt, pp);
                    frm.ShowDialog(this);
                    txtConsignmnt.Value = xC.sCot.cou_name;
                }
                else if (sender.Equals(txtEttNameT))
                {
                    Point pp = txtEttNameT.Location;
                    pp.Y = pp.Y + 120;
                    pp.X = pp.X - 20;

                    FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.EntryType, pp);
                    frm.ShowDialog(this);
                    txtEttNameT.Value = xC.sEtt.entry_type_name_t;
                }
            }
        }
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport();
            frm.Show(this);
        }

        private void TabExpen_TabClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            flagTabInv = flagTabInv == true ? false : true;
            setTabInv(flagTabInv);
        }
        private void setJobImport()
        {
            jim = new JobImport();
            jim.job_import_id = "";
            jim.job_import_code = txtJobCode.Text;
            jim.job_import_date = ((DateTime)txtImpDate.Value).ToString("yyyy-MM-dd");
            jim.cust_id = "";
            jim.imp_id = "";
            jim.transport_mode = ((ComboBoxItem)(cboTransMode.SelectedItem)).Value;
            jim.staff_id = "";
            jim.entry_type_id = "";
            jim.privi_id = "";
            jim.ref_1 = "";
            jim.ref_2 = "";
            jim.ref_3 = "";
            jim.ref_4 = "";
            jim.ref_5 = "";
            jim.ref_edi = "";
            jim.imp_entry = "";
            jim.edi_response = "";
            jim.tax_method_id = "";
            jim.check_exam_id = "";
            jim.inv_date = "";
            jim.tax_amt = "";
            jim.insr_date = "";
            jim.insr_id = "";
            jim.policy_no = "";
            jim.premium = "";
            jim.policy_date = "";
            jim.policy_clause = "";
            jim.job_year = "";
            jim.date_create = "";
            jim.date_modi = "";
            jim.date_cancel = "";
            jim.user_create = "";
            jim.user_modi = "";
            jim.user_cancel = "";
            jim.active = "1";
            jim.remark3 = "";
            jim.remark1 = "";
            jim.remark2 = "";
            jim.jobno = "";
            jim.job_date = "";
            jim.imp_date = "";
            jim.bl = "";

        }
        private void setTabInv(Boolean flag)
        {
            if (flag)
            {
                splitContainer1.SplitterDistance = 80;
                //tabJob.Height = 100;
                panel11.Hide();
            }
            else
            {
                splitContainer1.SplitterDistance = 480;
                //tabJob.Height = 100;
                panel11.Show();
            }
        }
        private void TabExpen_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //grfExpen.Height = this.Height - lbCus.Top - 100;
        }

        private void ChkCatiria_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkCatiria.Checked)
            {
                DateTime st = DateTime.Now;
                txtDateStart.Enabled = true;
                txtDateEnd.Enabled = true;
                btnSearch.Enabled = true;
                txtDateStart.Value = st.AddDays(-30);
                txtDateEnd.Value = DateTime.Now;
            }
            else
            {
                txtDateStart.Enabled = false;
                txtDateEnd.Enabled = false;
                btnSearch.Enabled = false;
            }
            
        }

        private void BtnJobSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            flagsearch = flagsearch ? false : true;
            setPanelSearch(flagsearch);
            //if (flagsearch)
            //{
            //    splitContainer1.SplitterDistance = 480;
            //}
            //else
            //{

            //}
            //flagTabInv = false;
            //setTabInv(flagTabInv);
        }
        private void setPanelSearch(Boolean flag)
        {
            if (flag)
            {
                grfSearch = new C1FlexGrid();
                //panelJob.Dock = DockStyle.Fill;
                grfSearch.Dock = DockStyle.Bottom;
                grfSearch.Size = new System.Drawing.Size(0, panel4.Height - txtJobCode.Height - 20);
                grfSearch.AfterRowColChange += GrfSearch_AfterRowColChange;
                grfSearch.DoubleClick += GrfSearch_DoubleClick;
                FilterRow fr = new FilterRow(grfSearch);
                panel4.Controls.Add(grfSearch);
                panel11.Hide();
                txtCusNameT.Hide();
                btnCusSF2.Hide();
                btnCusSF4.Hide();
                lbCus.Hide();
                tabInv.Enabled = false;
                
                panelCatiria.Show();
                panelCatiria.Left = lbCus.Left;
                panelCatiria.Top = lbCus.Top-15;
                txtDateStart.Enabled = false;
                txtDateEnd.Enabled = false;
                btnSearch.Enabled = false;
                chkCatiria.Checked = false;
                setGrfSearch(chkCatiria.Checked);
            }
            else
            {
                //panelJob.Dock = DockStyle.None;
                grfSearch.Dispose();
                panel11.Show();
                panel11.Height = 620;
                txtCusNameT.Show();
                btnCusSF2.Show();
                btnCusSF4.Show();
                lbCus.Show();
                tabInv.Enabled = true;
                panelCatiria.Hide();
                //tabInv.Show();
                //panelJob.Size = new System.Drawing.Size(350, 29);
                //panelJob.Location = locationPanelJob;
                //panelJob.Size = sizePanelJob;
                //panelJob.SuspendLayout();
                //panelJob.ResumeLayout(false);
                //panelJob.PerformLayout();
            }
        }

        private void GrfSearch_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //MessageBox.Show(String.Format("Button clicked in - Row : {0}, column : {1}.", grfSearch.MouseRow.ToString(), grfSearch.MouseCol.ToString()));
            if (grfSearch[grfSearch.Row, colJobNo] == null) return;
            grfSearch.Rows[grfSearch.MouseRow].StyleNew.BackColor = Color.Red;
            RibbonForm1 frm = new RibbonForm1(xC,grfSearch[grfSearch.Row, colJobNo].ToString());
            frm.ShowDialog(this);
        }

        private void GrfSearch_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            String aaa = "";
            sB1.Text = e.NewRange.r1.ToString()+" old "+e.OldRange.r1;
            if (e.NewRange.Data == null) return;
            if (e.OldRange.r1 < 0) return;
            //grfOld = grfSearch.Rows[e.NewRange.r1].StyleNew.BackColor;

            grfSearch.Rows[e.NewRange.r1].StyleNew.BackColor = Color.Gray;
            if (e.OldRange.r1 % 2 == 0)
                grfSearch.Rows[e.OldRange.r1].StyleNew.BackColor = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            else
                grfSearch.Rows[e.OldRange.r1].StyleNew.BackColor = grfOld;
        }
        private void initGrfExpen()
        {
            grfExpen = new C1FlexGrid();
            grfExpen.Dock = DockStyle.Fill;
            C1.Win.Calendar.C1DateEdit date = new C1.Win.Calendar.C1DateEdit();
            C1ComboBox combo = new C1ComboBox();
            combo = xC.xtDB.expnDB.setCboExpen(combo);
            grfExpen.Cols[colExpenDate].Editor = date;
            grfExpen.Cols[colExpenItem].Editor = combo;
            grfExpen.Cols[colExpenPayment].Editor = combo;
            //grfExpen.Size = new System.Drawing.Size(0, panel4.Height - txtJobCode.Height - 20);
            //grfSearch.AfterRowColChange += GrfSearch_AfterRowColChange;
            //grfSearch.DoubleClick += GrfSearch_DoubleClick;
            FilterRow fr = new FilterRow(grfExpen);
            panelExpen.Controls.Add(grfExpen);
            grfExpen.Rows.Count = 3;
            grfExpen.Cols[colExpenId].Visible = false;
        }
        private void setGrfSearch(Boolean flag)
        {
            grfSearch.DataSource = !flag ? xC.xtDB.mioDB.selectJobNoImport() : xC.xtDB.mioDB.selectJobNoImport();
            grfSearch.Cols[colJobNo].Width = 100;
            grfSearch.Cols[colimpJob].Width = 100;
            grfSearch.Cols[colJobDate].Width = 100;
            grfSearch.Cols[colImpDate].Width = 100;
            grfSearch.Cols[colBL].Width = 100;
            grfSearch.Cols[colImporter].Width = 60;
            grfSearch.Cols[colVslName].Width = 200;
            grfSearch.Cols[colHouseBL].Width = 60;
            grfSearch.Cols[colNameT].Width = 200;
            grfSearch.Cols[colNameE].Width = 200;
            grfSearch.Cols[colLoadedName].Width = 200;
            grfSearch.Cols[colReleaseName].Width = 200;
            grfSearch.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            grfSearch.Cols[colJobNo].Caption = "job no";
            grfSearch.Cols[colJobDate].Caption = "job date";
            grfSearch.Cols[colImpDate].Caption = "import date";
            grfSearch.Cols[colBL].Caption = "Bill Lading";
            grfSearch.Cols[colVslName].Caption = "ชื่อยานพาหนะ ";
            grfSearch.Cols[colHouseBL].Caption = "HB/L HAWB ";
            grfSearch.Cols[colImporter].Caption = "importer";
            grfSearch.Cols[colNameT].Caption = "ชื่อ importer";
            grfSearch.Cols[colNameE].Caption = "name importer";
            grfSearch.Cols[colvslnamerem].Caption = "vslnamerem";
            grfSearch.Cols[colOrigin].Caption = "Origin";
            grfSearch.Cols[colConsignmnt].Caption = "Consignmnt";
            grfSearch.Cols[colLoaded].Caption = "load code";
            grfSearch.Cols[colLoadedName].Caption = "load name";
            grfSearch.Cols[colRelease].Caption = "release";
            grfSearch.Cols[colReleaseName].Caption = "release name";
            grfSearch.Cols[colOutReplease].Caption = "out release";
            grfSearch.Cols[colOutRepleaseName].Caption = "out repease name";
            grfSearch.Cols[colApproval].Caption = "approval";
            grfSearch.Cols[colApprovalName].Caption = "approval name";

            grfSearch.Cols[colimpJob].Visible = false;
            //grfSearch.Cols[colID].Visible = false;
            
            for (int i = 1; i < grfSearch.Rows.Count; i++)
            {
                grfSearch[i, 0] = i;
                if (i % 2 == 0)
                    grfSearch.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            }
            grfOld = grfSearch.Rows[1].StyleNew.BackColor;
        }

        private void FrmJobImpNew1_Load(object sender, EventArgs e)
        {

        }
    }
}
