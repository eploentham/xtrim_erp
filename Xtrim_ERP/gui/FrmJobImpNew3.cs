using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xtrim_ERP.control;
using Xtrim_ERP.object1;
using Xtrim_ERP.Properties;

namespace Xtrim_ERP.gui
{
    public partial class FrmJobImpNew3 : Form
    {
        XtrimControl xC;
        JobImport jim;
        JobImportBl jbl;
        JobImportInv jin;
        Font fEdit, fEditB;
        Color bg, fc, cgrfOld;
        Font ff, ffB;
        C1FlexGrid grfInv, grfPkg, grfGw, grfContain, grfRemark;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String cusId = "", impId="", fwdId="", polId="", ptiId="", stfId="", cstId="", ettId="", pvlId="", ictId="";
        int colJobInvId = 1, colJobInvNo = 2, colJobInvDate = 3, colJobInvCons = 4, colJobInvIncoTerm = 5, colJobInvTermPayment = 6, colJobInvAmt = 7, colJobInvCurr = 8;

        int colMarskId = 1, colMarskDesc = 2;
        int colRemarkId = 1, colRemarkDesc = 2;
        int colContainId = 1, colContainQty = 2, colContainContainId = 3;
        int colGwId = 1, colGwQty = 2, colGwGwId = 3;
        int colPKGId = 1, colPKGQty = 2, colPKGPkgId = 3;

        public enum BodyType
        {
            PlainText,
            RTF,
            HTML
        }

        public FrmJobImpNew3(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            jim = new JobImport();
            jbl = new JobImportBl();

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            theme1.SetTheme(tC2, "VS2013Light");
            theme1.SetTheme(panel8, "VS2013Light");
            btnJobSearch.Click += BtnJobSearch_Click;
            btnSave.Click += BtnSave_Click;
            btnInvNew.Click += BtnInvNew_Click;
            btnInvSave.Click += BtnInvSave_Click;
            btnEmail.Click += BtnEmail_Click;
            btnSend.Click += BtnSend_Click;

            txtCusNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtImpNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtFwdNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtPolNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtPtiNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtConsignmnt.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtStaffCS.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtPvlNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtEttNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtJobCode.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtIctNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtTpmNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtCurrCode.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtInsrNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);

            txtPkg1.KeyUp += new KeyEventHandler(TxtPkg1_KeyUp);
            txtPkg2.KeyUp += new KeyEventHandler(TxtPkg1_KeyUp);
            txtPkg3.KeyUp += new KeyEventHandler(TxtPkg1_KeyUp);
            txtPkg4.KeyUp += new KeyEventHandler(TxtPkg1_KeyUp);
            txtPkg5.KeyUp += new KeyEventHandler(TxtPkg1_KeyUp);

            xC.setCboTransMode(cboTransMode);
            xC.setCboTaxMethod(cboTaxMethod);
            //xC.xtDB.ittDB.setCboImporterType(cboItt);
            xC.xtDB.cemDB.setCboCheckExam(cboChkExam,"");
            xC.xtDB.dctDB.setC1CboBLTYPE(cboBlType, "");
            //xC.xtDB.dctDB.setC1CboBLTYPE1(cboBlType,"");
            xC.xtDB.dctDB.setC1CboContain(cboContain1,"");
            xC.xtDB.dctDB.setC1CboContain(cboContain2, "");
            xC.xtDB.dctDB.setC1CboContain(cboContain3, "");
            xC.xtDB.dctDB.setC1CboContain(cboContain4, "");
            xC.xtDB.dctDB.setC1CboContain(cboContain5, "");
            xC.xtDB.dctDB.setC1CboContain(cboContain6, "");

            xC.xtDB.ugwDB.setC1CboUgw(cboUgw, "");
            xC.xtDB.ugwDB.setC1CboUgw(cboVolume, "");
            xC.xtDB.utpDB.setC1CboUtp(cboUtp1, "");
            xC.xtDB.utpDB.setC1CboUtp(cboUtp2, "");
            xC.xtDB.utpDB.setC1CboUtp(cboUtp3, "");
            xC.xtDB.utpDB.setC1CboUtp(cboUtp4, "");
            xC.xtDB.utpDB.setC1CboUtp(cboUtp5, "");
                        
            //initGrfMarsk();
            //initGrfRemark();
            //initGrfContain();
            //initGrfGw();
            //initGrfPKG();

            tC1.SelectedTab = tabJob;
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Silver;
            setLabelRed();
            tC2.AutoHiding = true;
            tC2.CanAutoHide = true;
            setControl();
            initGrfInv();
            //txtJobCode.Enabled = false;
        }
        
        private void setLabelRed()
        {
            label4.ForeColor = Color.Red;
            label33.ForeColor = Color.Red;
            label14.ForeColor = Color.Red;
            //label34.ForeColor = Color.Red;
            //label35.ForeColor = Color.Red;
            label36.ForeColor = Color.Red;
            label13.ForeColor = Color.Red;
            label19.ForeColor = Color.Red;
            label41.ForeColor = Color.Red;
            label20.ForeColor = Color.Red;
            label18.ForeColor = Color.Red;
            label11.ForeColor = Color.Red;
            btnBlReceive.ForeColor = Color.Red;
            label17.ForeColor = Color.Red;
            label22.ForeColor = Color.Red;
            label21.ForeColor = Color.Red;
            label23.ForeColor = Color.Red;
            //label16.ForeColor = Color.Red;
            label25.ForeColor = Color.Red;
            label24.ForeColor = Color.Red;
            label15.ForeColor = Color.Red;
        }
        
        private void initGrfInv()
        {
            grfInv = new C1FlexGrid();
            panel7.Controls.Add(grfInv);
            grfInv.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();
            //DataTable dt = new DataTable();
            //dt = xC.xtDB.jinDB.selectByJobId1(txtID.Text);
            grfInv.DataSource = xC.xtDB.jinDB.selectByJobId1(txtID.Text);
            grfInv.Cols[colJobInvId].Editor = txt;
            grfInv.Cols[colJobInvNo].Editor = txt;
            grfInv.Cols[colJobInvDate].Editor = txt;
            grfInv.Cols[colJobInvCons].Editor = txt;
            grfInv.Cols[colJobInvIncoTerm].Editor = txt;
            grfInv.Cols[colJobInvTermPayment].Editor = txt;
            grfInv.Cols[colJobInvAmt].Editor = txt;
            grfInv.Cols[colJobInvCurr].Editor = txt;

            

            grfInv.Cols[colJobInvId].Caption = "id";
            grfInv.Cols[colJobInvNo].Caption = "Invoice no";
            grfInv.Cols[colJobInvDate].Caption = "inv date";
            grfInv.Cols[colJobInvCons].Caption = "supplier";
            grfInv.Cols[colJobInvIncoTerm].Caption = "inco term";
            grfInv.Cols[colJobInvTermPayment].Caption = "payment";
            grfInv.Cols[colJobInvAmt].Caption = "amount";
            grfInv.Cols[colJobInvCurr].Caption = "currency";

            
            //grfInv.Rows.Count = 2;
            //grfInv.Cols.Count = 3;
            grfInv.Cols[colMarskDesc].Width = 200;
            grfInv.Cols[colJobInvDate].Width = 100;
            grfInv.Cols[colJobInvId].Visible = false;

            grfInv.CellChanged += GrfMarsk_CellChanged;

            //ContextMenu menuMarsk = new ContextMenu();
            //menuMarsk.MenuItems.Add("&เพิ่มใหม่", new EventHandler(ContextMenu_Marsk_new));
            //menuMarsk.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Marsk_Edit));
            //menuMarsk.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Marsk_Cancel));
            //grfMarsk.ContextMenu = menuMarsk;
        }
        private void initGrfRemark()
        {
            grfRemark = new C1FlexGrid();
            grfRemark.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();

            grfRemark.Cols[colRemarkId].Editor = txt;
            grfRemark.Cols[colRemarkDesc].Editor = txt;
            grfRemark.Cols[colRemarkDesc].Caption = "remark";

            gBRemark.Controls.Add(grfRemark);
            grfRemark.Rows.Count = 2;
            grfRemark.Cols.Count = 3;
            grfRemark.Cols[colRemarkDesc].Width = 200;

            grfRemark.Cols[colRemarkId].Visible = false;
            grfRemark.AfterRowColChange += GrfRemark_AfterRowColChange;
            grfRemark.CellChanged += GrfRemark_CellChanged;

            //ContextMenu menuRemark = new ContextMenu();
            //menuRemark.MenuItems.Add("&เพิ่มใหม่", new EventHandler(ContextMenu_Remark_new));
            //menuRemark.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Remark_Edit));
            //menuRemark.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Remark_Cancel));
            //grfRemark.ContextMenu = menuRemark;
        }
        private void initGrfContain()
        {
            grfContain = new C1FlexGrid();
            grfContain.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();
            C1ComboBox combo = new C1ComboBox();
            combo = xC.xtDB.dctDB.setCboContainer(combo);

            grfContain.Cols[colContainId].Editor = txt;
            grfContain.Cols[colContainQty].Editor = txt;
            grfContain.Cols[colContainContainId].Editor = combo;
            grfContain.Cols[colContainQty].Caption = "qty";
            grfContain.Cols[colContainContainId].Caption = "TYPE";

            gBContain.Controls.Add(grfContain);
            grfContain.Rows.Count = 2;
            grfContain.Cols.Count = 4;
            grfContain.Cols[colContainQty].Width = 60;
            grfContain.Cols[colContainContainId].Width = 150;
            grfContain.Cols[colContainId].Visible = false;

            grfContain.CellChanged += GrfContain_CellChanged;

            //ContextMenu menuContain = new ContextMenu();
            //menuContain.MenuItems.Add("&เพิ่มใหม่", new EventHandler(ContextMenu_Contain_new));
            //menuContain.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Contain_Edit));
            //menuContain.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Contain_Cancel));
            //grfContain.ContextMenu = menuContain;
        }
        private void initGrfGw()
        {
            grfGw = new C1FlexGrid();
            grfGw.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();
            C1ComboBox combo = new C1ComboBox();
            combo = xC.xtDB.dctDB.setCboGW(combo);

            grfGw.Cols[colGwId].Editor = txt;
            grfGw.Cols[colGwQty].Editor = txt;
            grfGw.Cols[colGwGwId].Editor = combo;
            grfGw.Cols[colGwQty].Caption = "qty";
            grfGw.Cols[colGwGwId].Caption = "GW & VOLUME";

            gBGw.Controls.Add(grfGw);
            grfGw.Rows.Count = 2;
            grfGw.Cols.Count = 4;
            grfGw.Cols[colGwQty].Width = 60;
            grfGw.Cols[colGwGwId].Width = 150;
            grfGw.Cols[colGwId].Visible = false;

            grfGw.CellChanged += GrfGw_CellChanged;

            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&เพิ่มใหม่", new EventHandler(ContextMenu_Gw_new));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            //grfGw.ContextMenu = menuGw;
        }
        private void initGrfPKG()
        {
            grfPkg = new C1FlexGrid();
            grfPkg.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();
            C1ComboBox combo = new C1ComboBox();
            combo = xC.xtDB.dctDB.setCboGW(combo);

            grfPkg.Cols[colPKGId].Editor = txt;
            grfPkg.Cols[colPKGQty].Editor = txt;
            grfPkg.Cols[colPKGPkgId].Editor = combo;
            grfPkg.Cols[colPKGQty].Caption = "qty";
            grfPkg.Cols[colPKGPkgId].Caption = "PKG";

            gBPkg.Controls.Add(grfPkg);
            grfPkg.Rows.Count = 2;
            grfPkg.Cols.Count = 4;
            grfPkg.Cols[colPKGQty].Width = 60;
            grfPkg.Cols[colPKGPkgId].Width = 150;
            grfPkg.Cols[colPKGId].Visible = false;

            grfPkg.CellChanged += GrfPkg_CellChanged;

            //ContextMenu menuPkg = new ContextMenu();
            //menuPkg.MenuItems.Add("&เพิ่มใหม่", new EventHandler(ContextMenu_Pkg_new));
            //menuPkg.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Pkg_Edit));
            //menuPkg.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Pkg_Cancel));
            //grfPkg.ContextMenu = menuPkg;
        }
        private void GrfRemark_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfRemark.Row == grfRemark.Rows.Count)
            {
                grfRemark.Rows.Count = grfRemark.Rows.Count + 1;
            }
        }
        private void GrfGw_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            grfGw.Rows.Count = (grfGw.Row == grfGw.Rows.Count - 1) ? (grfGw.Rows.Count = grfGw.Rows.Count + 1) : grfGw.Rows.Count;
        }

        private void GrfContain_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            grfContain.Rows.Count = (grfContain.Row == grfContain.Rows.Count - 1) ? (grfContain.Rows.Count = grfContain.Rows.Count + 1) : grfContain.Rows.Count;
        }

        private void GrfMarsk_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            grfInv.Rows.Count = (grfInv.Row == grfInv.Rows.Count - 1) ? (grfInv.Rows.Count = grfInv.Rows.Count + 1) : grfInv.Rows.Count;
        }

        private void GrfPkg_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            grfPkg.Rows.Count = (grfPkg.Row == grfPkg.Rows.Count - 1) ? (grfPkg.Rows.Count = grfPkg.Rows.Count + 1) : grfPkg.Rows.Count;
        }

        private void GrfRemark_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfRemark.Row == grfRemark.Rows.Count - 1)
            {
                grfRemark.Rows.Count = grfRemark.Rows.Count + 1;
            }
        }
        //private void ContextMenu_Marsk_new(object sender, System.EventArgs e)
        //{
            
        //}
        //private void ContextMenu_Marsk_Edit(object sender, System.EventArgs e)
        //{

        //}
        //private void ContextMenu_Marsk_Cancel(object sender, System.EventArgs e)
        //{

        //}
        private void ContextMenu_Remark_new(object sender, System.EventArgs e)
        {

        }
        private void ContextMenu_Remark_Edit(object sender, System.EventArgs e)
        {

        }
        private void ContextMenu_Remark_Cancel(object sender, System.EventArgs e)
        {

        }
        private void ContextMenu_Contain_new(object sender, System.EventArgs e)
        {

        }
        private void ContextMenu_Contain_Edit(object sender, System.EventArgs e)
        {

        }
        private void ContextMenu_Contain_Cancel(object sender, System.EventArgs e)
        {

        }
        //private void ContextMenu_Gw_new(object sender, System.EventArgs e)
        //{

        //}
        //private void ContextMenu_Gw_Edit(object sender, System.EventArgs e)
        //{

        //}
        //private void ContextMenu_Gw_Cancel(object sender, System.EventArgs e)
        //{

        //}
        //private void ContextMenu_Pkg_new(object sender, System.EventArgs e)
        //{

        //}
        //private void ContextMenu_Pkg_Edit(object sender, System.EventArgs e)
        //{

        //}
        //private void ContextMenu_Pkg_Cancel(object sender, System.EventArgs e)
        //{

        //}
        private void BtnJobSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Form3 frm = new Form3();
            frm.Show();
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
                    //if (txtID.Value.Equals(""))
                    //{
                    //    txtID.Value = re;
                    //}
                    
                    setJobImportBl();
                    String re1 = xC.xtDB.jblDB.insertJobImportBl(jbl);
                    btnSave.Image = Resources.accept_database24;
                    if (txtJobCode.Text.Equals(""))
                    {
                        if (re.Length > 6)
                        {
                            String code = re.Substring(re.Length - 6);
                            txtJobCode.Value = xC.FixJobCode + code;
                        }
                    }
                }
                else
                {
                    btnSave.Image = Resources.DeleteTable_small;
                }
                //setGrdView();
                //this.Dispose();
            }
        }
        private void BtnInvSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("ข้อมูล job ยังไม่มีข้อมูล","");
                return;
            }
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setInvoice();

                String re = xC.xtDB.jinDB.insertJobImportInv(jin);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.DeleteTable_small;
                }
                //setGrdView();
                //this.Dispose();
            }
        }
        private void BtnSend_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            sendEmailViaOutlook("eploentham@xtrim-logistics.com", txtTo.Text, "", txtSubject.Text, txtBody.Text, BodyType.HTML, null, null);
        }
        private void BtnEmail_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Company com = new Company();
            com = xC.xtDB.copDB.selectByPk1("1020000001");
            Customer insr = new Customer();
            //cus = xC.xtDB.cusDB.selectByPk1(txtID.Text);
            insr = xC.xtDB.cusDB.selectInsurByPk1(cusId);
            Contact c = new Contact();
            c = xC.xtDB.contDB.selectByCusId1(insr.cust_id);
            txtTo.Text = c.email;
            txtSubject.Text = "จาก "+com.comp_name_t+" เรียน คุณ "+c.cont_fname_t + " "+c.cont_lname_t ;
        }
        private void BtnInvNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setControlInvNew();
        }
        private void setKeyUpF2Cus()
        {
            Point pp = txtCusNameT.Location;
            pp.Y = pp.Y + 120 + 20;
            pp.X = pp.X - 20 + groupBox1.Left;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Customer, pp);
            frm.ShowDialog(this);
            setKeyUpF2Cus1(xC.sCus);
        }
        private void setKeyUpF2Cus1(Customer cus)
        {
            txtCusAddr.Value = cus.taddr1 + Environment.NewLine + cus.taddr2 + Environment.NewLine + cus.taddr3 + Environment.NewLine + cus.taddr4 + Environment.NewLine + cus.cust_code + Environment.NewLine + cus.remark;
            txtCusNameT.Value = cus.cust_name_t;
            txtCusContactNameT.Value = cus.contact_name1 + " " + cus.contact_name1_tel;
            cusId = cus.cust_id;
        }
        private void setKeyUpF2Imp()
        {
            Point pp = txtImpNameT.Location;
            pp.Y = pp.Y + 120 + 20;
            pp.X = pp.X - 20 + groupBox2.Left;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Importer, pp);
            frm.ShowDialog(this);
            setKeyUpF2Imp1(xC.sImp);
        }
        private void setKeyUpF2Imp1(Customer imp)
        {
            txtImpAddr.Value = imp.taddr1 + Environment.NewLine + imp.taddr2 + Environment.NewLine + imp.taddr3 + Environment.NewLine + imp.taddr4 + Environment.NewLine + imp.cust_code + Environment.NewLine + imp.remark;
            txtImpNameT.Value = imp.cust_name_t;
            txtImpContactNameT.Value = imp.contact_name1 + " " + imp.contact_name1_tel;
            impId = imp.cust_id;
        }
        private void setKeyUpF2Fwd()
        {
            Point pp = txtFwdNameT.Location;
            pp.Y = pp.Y + 120;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Forwarder, pp);
            frm.ShowDialog(this);
            setKeyUpF2Fwd1(xC.sFwd);
        }
        private void setKeyUpF2Fwd1(Customer fwd)
        {
            //txtImpAddr.Value = xC.sImp.taddr1 + Environment.NewLine + xC.sImp.taddr2 + Environment.NewLine + xC.sImp.taddr3 + Environment.NewLine + xC.sImp.taddr4 + Environment.NewLine + xC.sImp.cust_code + Environment.NewLine + xC.sImp.remark;
            txtFwdNameT.Value = xC.sFwd.cust_name_t;
            //txtImpContactNameT.Value = xC.sImp.contact_name1 + " " + xC.sImp.contact_name1_tel;
            fwdId = xC.sFwd.cust_id;
        }
        private void setKeyUpF2Pol()
        {
            Point pp = txtPolNameT.Location;
            pp.Y = pp.Y + 120;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.PortOfLoading, pp);
            frm.ShowDialog(this);
            setKeyUpF2Pol1(xC.sPol);
        }
        private void setKeyUpF2Pol1(PortOfLoading pol)
        {
            txtPolNameT.Value = pol.port_of_loading_t;
            txtCntryCode.Value = pol.cntrycode;
            polId = pol.port_of_loading_id;
        }
        private void setKeyUpF2Pti()
        {
            Point pp = txtPtiNameT.Location;
            pp.Y = pp.Y + 120;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.PortImport, pp);
            frm.ShowDialog(this);
            setKeyUpF2Pti1(xC.sPti);
        }
        private void setKeyUpF2Pti1(PortImport pti)
        {
            txtPtiNameT.Value = pti.port_import_name_t;
            ptiId = pti.port_import_id;
        }
        private void setKeyUpF2Cot()
        {
            // Consignmnt = country
            Point pp = txtConsignmnt.Location;
            pp.Y = pp.Y + 120;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Country, pp);
            frm.ShowDialog(this);
            setKeyUpF2Cot1(xC.sCot);
        }
        private void setKeyUpF2Cot1(Country cst)
        {
            txtConsignmnt.Value = cst.cou_name;
            cstId = cst.cou_id;
        }
        private void setKeyUpF2StfCS()
        {
            Point pp = txtStaffCS.Location;
            pp.Y = pp.Y + 120;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Staff, pp);
            frm.ShowDialog(this);
            setKeyUpF2StfCS1(xC.sStf);
        }
        private void setKeyUpF2StfCS1(Staff stf)
        {
            txtStaffCS.Value = stf.staff_fname_t + " " + stf.staff_lname_t;
            stfId = stf.staff_id;
        }
        private void setKeyUpF2Pvl()
        {
            Point pp = txtPvlNameT.Location;
            pp.Y = pp.Y + 120;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Privilege, pp);
            frm.ShowDialog(this);
            setKeyUpF2Pvl1(xC.sPvl);
        }
        private void setKeyUpF2Pvl1(Privilege pvl)
        {
            txtPvlNameT.Value = pvl.desc1;
            pvlId = pvl.priv_id;
        }
        private void setKeyUpF2Ett()
        {
            Point pp = txtEttNameT.Location;
            pp.Y = pp.Y + 120;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.EntryType, pp);
            frm.ShowDialog(this);
            setKeyUpF2Ett1(xC.sEtt);
        }
        private void setKeyUpF2Ett1(EntryType ett)
        {
            txtEttNameT.Value = ett.entry_type_name_t;
            ettId = ett.entry_type_id;
        }
        private void setKeyUpF2Ict()
        {
            Point pp = txtIctNameT.Location;
            pp.Y = pp.Y + 120;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.IncoTerm, pp);
            frm.ShowDialog(this);
            setKeyUpF2Ict1(xC.sIct);
        }
        private void setKeyUpF2Ict1(IncoTerms ict)
        {
            txtIctNameT.Value = ict.inco_terms_name_t;
            ictId = ict.inco_terms_id;
        }
        private void setKeyUpF2Tpm()
        {
            Point pp = txtTpmNameT.Location;
            pp.Y = pp.Y + 120;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.TermPayment, pp);
            frm.ShowDialog(this);
            setKeyUpF2Tpm1(xC.sTpm);
        }
        private void setKeyUpF2Tpm1(TermPayment tpm)
        {
            txtTpmNameT.Value = tpm.term_payment_name_t;
            ictId = tpm.term_payment_id;
        }
        private void setKeyUpF2Curr()
        {
            Point pp = txtCurrCode.Location;
            pp.Y = pp.Y + 120;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Currency, pp);
            frm.ShowDialog(this);
            setKeyUpF2Curr1(xC.sCurr);
        }
        private void setKeyUpF2Curr1(Currency curr)
        {
            txtCurrCode.Value = curr.curr_code;
            //ictId = curr.term_payment_id;
        }
        private void setKeyUpF2Insr()
        {
            Point pp = txtInsrNameT.Location;
            pp.Y = pp.Y + 120;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Insurance, pp);
            frm.ShowDialog(this);
            setKeyUpF2Insr1(xC.sInsr);
        }
        private void setKeyUpF2Insr1(Customer insr)
        {
            txtInsrNameT.Value = insr.cust_name_t;
        }

        private void setFeyEnterPol()
        {
            if (txtPolNameT.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.polDB.selectByCodeLike(txtPolNameT.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sPol = new PortOfLoading();
                    xC.sPol = xC.xtDB.polDB.setPortOfLoading(dt);
                    setKeyUpF2Pol1(xC.sPol);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2Ett();
                }
            }
        }
        private void setKeyEnterEtt()
        {
            if (txtEttNameT.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.ettDB.selectByCodeLike(txtEttNameT.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sEtt = new EntryType();
                    xC.sEtt = xC.xtDB.ettDB.setEntryType(dt);
                    setKeyUpF2Ett1(xC.sEtt);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2Ett();
                }
            }
        }
        private void setKeyEnterConsignmnt()
        {
            if (txtConsignmnt.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.cotDB.selectByCodeLike(txtConsignmnt.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sCot = new Country();
                    xC.sCot = xC.xtDB.cotDB.setCountry(dt);
                    setKeyUpF2Cot1(xC.sCot);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2Cot();
                }
            }
        }
        private void setKeyEnterStaffCS()
        {
            if (txtStaffCS.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.stfDB.selectCSByCodeLike(txtStaffCS.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sStf = new Staff();
                    xC.sStf = xC.xtDB.stfDB.setStaff(dt);
                    setKeyUpF2StfCS1(xC.sStf);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2StfCS();
                }
            }
        }
        private void setKeyEnterFwd()
        {
            if (txtFwdNameT.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.cusDB.selectFwsIdByCodeLike(txtFwdNameT.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sFwd = new Customer();
                    xC.sFwd = xC.xtDB.cusDB.setCustomer(dt);
                    setKeyUpF2Fwd1(xC.sFwd);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2Fwd();
                }
            }
        }
        private void setKeyEnterImp()
        {
            if (txtImpNameT.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.cusDB.selectImpIdByCodeLike(txtImpNameT.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sImp = new Customer();
                    xC.sImp = xC.xtDB.cusDB.setCustomer(dt);
                    setKeyUpF2Imp1(xC.sImp);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2Imp();
                }
            }
        }
        private void setKeyEnterCus()
        {
            if (txtCusNameT.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.cusDB.selectCusByCodeLike(txtCusNameT.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sCus = new Customer();
                    xC.sCus = xC.xtDB.cusDB.setCustomer(dt);
                    setKeyUpF2Cus1(xC.sCus);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2Cus();
                }
                //MessageBox.Show("1111", "11");
            }
        }
        private void setKeyEnterPvl()
        {
            if (txtPvlNameT.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.pvlDB.selectByCodeLike(txtPvlNameT.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sPvl = new Privilege();
                    xC.sPvl = xC.xtDB.pvlDB.setPrivilege(dt);
                    setKeyUpF2Pvl1(xC.sPvl);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2Pvl();
                }
                //MessageBox.Show("1111", "11");
            }
        }
        private void setKeyEnterPti()
        {
            if (txtPtiNameT.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.ptiDB.selectByCodeLike(txtPtiNameT.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sPti = new PortImport();
                    xC.sPti = xC.xtDB.ptiDB.setPortImport(dt);
                    setKeyUpF2Pti1(xC.sPti);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2Pti();
                }
                //MessageBox.Show("1111", "11");
            }
        }
        private void setKeyEnterIct()
        {
            if (txtIctNameT.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.ictDB.selectByCodeLike(txtIctNameT.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sIct = new IncoTerms();
                    xC.sIct = xC.xtDB.ictDB.setIncoTeams(dt);
                    setKeyUpF2Ict1(xC.sIct);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2Ict();
                }
                //MessageBox.Show("1111", "11");
            }
        }
        private void setKeyEnterTpm()
        {
            if (txtTpmNameT.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.tpmDB.selectByCodeLike(txtTpmNameT.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sTpm = new TermPayment();
                    xC.sTpm = xC.xtDB.tpmDB.setTermPayment(dt);
                    setKeyUpF2Tpm1(xC.sTpm);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2Tpm();
                }
                //MessageBox.Show("1111", "11");
            }
        }
        private void setKeyEnterCurr()
        {
            if (txtCurrCode.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.currDB.selectByCodeLike(txtCurrCode.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sCurr = new Currency();
                    xC.sCurr = xC.xtDB.currDB.setCurr(dt);
                    setKeyUpF2Curr1(xC.sCurr);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2Curr();
                }
                //MessageBox.Show("1111", "11");
            }
        }
        private void setKeyEnterInsr()
        {
            if (txtInsrNameT.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.cusDB.selectInsrIdByCodeLike(txtInsrNameT.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sInsr = new Customer();
                    xC.sInsr = xC.xtDB.cusDB.setCustomer(dt);
                    setKeyUpF2Curr1(xC.sCurr);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2Insr();
                }
                //MessageBox.Show("1111", "11");
            }
        }
        private void TxtPkg1_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            Decimal pkg1 = 0, pkg2 = 0, pkg3 = 0, pkg4 = 0, pkg5 = 0;
            Decimal.TryParse(txtPkg1.Text, out pkg1);
            Decimal.TryParse(txtPkg2.Text, out pkg2);
            Decimal.TryParse(txtPkg3.Text, out pkg3);
            Decimal.TryParse(txtPkg4.Text, out pkg4);
            Decimal.TryParse(txtPkg5.Text, out pkg5);
            txtPkgTotal.Value = pkg1 + pkg2 + pkg3 + pkg4 + pkg5;
        }
        private void txtCusCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (sender.Equals(txtCusNameT))
                {
                    setKeyUpF2Cus();
                }
                else if (sender.Equals(txtImpNameT))
                {
                    setKeyUpF2Imp();
                }
                else if (sender.Equals(txtFwdNameT))
                {
                    setKeyUpF2Fwd();
                }
                else if (sender.Equals(txtPolNameT))
                {
                    setKeyUpF2Pol();
                }
                else if (sender.Equals(txtPtiNameT))
                {
                    setKeyUpF2Pti();
                }
                else if (sender.Equals(txtConsignmnt))
                {
                    setKeyUpF2Cot();
                }
                else if (sender.Equals(txtStaffCS))
                {
                    setKeyUpF2StfCS();
                }
                else if (sender.Equals(txtPvlNameT))
                {
                    setKeyUpF2Pvl();
                }
                else if (sender.Equals(txtEttNameT))
                {
                    setKeyUpF2Ett();
                }
                else if (sender.Equals(txtPtiNameT))
                {
                    setKeyUpF2Pti();
                }
                else if (sender.Equals(txtIctNameT))
                {
                    setKeyUpF2Ict();
                }
                else if (sender.Equals(txtTpmNameT))
                {
                    setKeyUpF2Tpm();
                }
                else if (sender.Equals(txtCurrCode))
                {
                    setKeyUpF2Curr();
                }
                else if (sender.Equals(txtInsrNameT))
                {
                    setKeyUpF2Insr();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (sender.Equals(txtCusNameT))
                {
                    setKeyEnterCus();
                }
                else if (sender.Equals(txtImpNameT))
                {
                    setKeyEnterImp();
                }
                else if (sender.Equals(txtFwdNameT))
                {
                    setKeyEnterFwd();
                }
                else if (sender.Equals(txtStaffCS))
                {
                    setKeyEnterStaffCS();
                }
                else if (sender.Equals(txtConsignmnt))
                {
                    setKeyEnterConsignmnt();
                }
                else if (sender.Equals(txtEttNameT))
                {
                    setKeyEnterEtt();
                }
                else if (sender.Equals(txtPolNameT))
                {
                    setFeyEnterPol();
                }
                else if (sender.Equals(txtPvlNameT))
                {
                    setKeyEnterPvl();
                }
                else if (sender.Equals(txtPtiNameT))
                {
                    setKeyEnterPti();
                }
                else if (sender.Equals(txtJobCode))
                {
                    
                    txtJobCode.Text = txtJobCode.Text.Replace(xC.FixJobCode, "");
                    
                    xC.jobID = xC.xtDB.jimDB.selectByJobCode1(txtJobCode.Text);
                    setControl();
                    initGrfInv();
                }
                else if (sender.Equals(txtIctNameT))
                {
                    setKeyEnterIct();
                }
                else if (sender.Equals(txtTpmNameT))
                {
                    setKeyEnterTpm();
                }
                else if (sender.Equals(txtCurrCode))
                {
                    setKeyEnterCurr();
                }
                else if (sender.Equals(txtInsrNameT))
                {
                    setKeyEnterCurr();
                }
            }
        }
        private void setControl()
        {
            if (xC.jobID.Equals("")) return;
            jim = xC.xtDB.jimDB.selectByPk1(xC.jobID);
            jbl = xC.xtDB.jblDB.selectByJobId(xC.jobID);

            //jim = xC.xtDB.jimDB.selectByJobCode(txtJobCode.Text);
            //jbl = xC.xtDB.jblDB.selectByJobId(jim.job_import_id);

            Customer cus = xC.xtDB.cusDB.selectByPk1(jim.cust_id);
            Customer imp = xC.xtDB.cusDB.selectByPk1(jim.imp_id);
            Staff stf = xC.xtDB.stfDB.selectByPk1(jim.staff_id);
            EntryType ett = xC.xtDB.ettDB.selectByPk1(jim.entry_type_id);
            Privilege pvl = xC.xtDB.pvlDB.selectByPk1(jim.privi_id);
            Customer fwd = xC.xtDB.cusDB.selectByPk1(jbl.forwarder_id);
            PortOfLoading pol = xC.xtDB.polDB.selectByPk1(jbl.port_of_loading_id);
            PortImport pti = xC.xtDB.ptiDB.selectByPk1(jbl.port_imp_id);
            Country cst = xC.xtDB.cotDB.selectByPk1(jbl.consignmnt_id);

            txtID.Value = jim.job_import_id;
            txtBlId.Value = jbl.job_import_bl_id;
            txtJobNo.Value = jim.jobno;
            stfId = jim.staff_id;
            txtJobCode.Value = xC.FixJobCode + jim.job_import_code;

            setKeyUpF2StfCS1(stf);
            setKeyUpF2Ett1(ett);
            setKeyUpF2Pvl1(pvl);
            setKeyUpF2Fwd1(fwd);
            setKeyUpF2Pol1(pol);

            txtRef1.Value = jim.ref_1;
            txtRef2.Value = jim.ref_2;
            txtRef3.Value = jim.ref_3;
            txtRef4.Value = jim.ref_4;
            txtRef5.Value = jim.ref_5;
            txtRemark1.Value = jim.remark1;
            txtRemark2.Value = jim.remark2;
            txtRemark3.Value = jim.remark3;
            txtRemark4.Value = jim.remark4;
            txtRemark5.Value = jim.remark5;
            txtRemark6.Value = jim.remark6;
            txtMarsk1.Value = jim.marsk1;
            txtMarsk2.Value = jim.marsk2;
            txtMarsk3.Value = jim.marsk3;
            txtMarsk4.Value = jim.marsk4;
            txtMarsk5.Value = jim.marsk5;
            txtMarsk6.Value = jim.marsk6;

            xC.setC1Combo(cboChkExam, jim.check_exam_id);
            xC.setC1Combo(cboTransMode, jim.transport_mode);
            //cboChkExam.SelectedItem = jim.check_exam_id;
            setKeyUpF2Cus1(cus);
            setKeyUpF2Imp1(imp);
            setKeyUpF2Pti1(pti);
            setKeyUpF2Cot1(cst);

            txtPkg1.Value = jbl.packages1;
            txtPkg2.Value = jbl.packages2;
            txtPkg3.Value = jbl.packages3;
            txtPkg4.Value = jbl.packages4;
            txtPkg5.Value = jbl.packages5;
            txtPkgTotal.Value = jbl.packages_total;
            txtContain1.Value = jbl.container1;
            txtContain2.Value = jbl.container2;
            txtContain3.Value = jbl.container3;
            txtContain4.Value = jbl.container4;
            txtContain5.Value = jbl.container5;
            txtContain6.Value = jbl.container6;
            xC.setC1Combo(cboContain1, jbl.container1_doc_type_id);
            xC.setC1Combo(cboContain2, jbl.container2_doc_type_id);
            xC.setC1Combo(cboContain3, jbl.container3_doc_type_id);
            xC.setC1Combo(cboContain4, jbl.container4_doc_type_id);
            xC.setC1Combo(cboContain5, jbl.container5_doc_type_id);
            xC.setC1Combo(cboContain6, jbl.container6_doc_type_id);
            xC.setC1Combo(cboUtp1, jbl.unit_package1_id);
            xC.setC1Combo(cboUtp2, jbl.unit_package2_id);
            xC.setC1Combo(cboUtp3, jbl.unit_package3_id);
            xC.setC1Combo(cboUtp4, jbl.unit_package4_id);
            xC.setC1Combo(cboUtp5, jbl.unit_package5_id);
            txtGw.Value = jbl.gw;
            //txtGwTotal.Value = jbl.gw_total;
            txtVolume.Value = jbl.volume1;
            //txtGwTotal.Value = jbl.gw_total;
            xC.setC1Combo(cboUgw, jbl.gw_unit_id);
            xC.setC1Combo(cboVolume, jbl.unit_volume1_id);
            txtMbl.Value = jbl.mbl_mawb;
            txtHbl.Value = jbl.hbl_hawb;
            txtMves.Value = jbl.m_vessel;
            txtFves.Value = jbl.f_vessel;
            txtEta.Value = jbl.eta;
            txtEtd.Value = jbl.etd;
            txtJobDate.Value = jim.job_date;
            txtBl.Value = jbl.bl;
            xC.setC1Combo(cboBlType, jbl.bl_type);
        }
        private Boolean setJobImport()
        {
            Boolean chk = false;
            jim = new JobImport();
            jim.job_import_id = txtID.Text;
            if (txtID.Text.Length > 0)
            {
                jim = xC.xtDB.jimDB.selectByPk1(txtID.Text);
                jim.job_import_code = txtJobCode.Text.Replace(xC.FixJobCode,"");
                jim.job_year = jim.job_year.Equals("") ? DateTime.Now.Year.ToString() : jim.job_year;
            }
            else
            {
                jim.job_year = DateTime.Now.Year.ToString();
            }
            //jim.job_import_date = ((DateTime)txtImpDate.Value).ToString("yyyy-MM-dd");

            jim.cust_id = cusId;
            jim.imp_id = impId;
            jim.transport_mode = cboTransMode.SelectedItem != null ? ((ComboBoxItem)(cboTransMode.SelectedItem)).Value : "";
            jim.staff_id = stfId;
            jim.entry_type_id = ettId;
            jim.privi_id = pvlId;
            jim.ref_1 = txtRef1.Text;
            jim.ref_2 = txtRef2.Text;
            jim.ref_3 = txtRef3.Text;
            jim.ref_4 = txtRef4.Text;
            jim.ref_5 = txtRef5.Text;
            jim.ref_edi = "";
            jim.imp_entry = "";
            jim.edi_response = "";
            jim.tax_method_id = "";
            jim.check_exam_id = cboChkExam.SelectedItem != null ? ((ComboBoxItem)(cboChkExam.SelectedItem)).Value : "";
            jim.inv_date = "";
            jim.tax_amt = "";
            jim.insr_date = "";
            jim.insr_id = "";
            jim.policy_no = "";
            jim.premium = "";
            jim.policy_date = "";
            jim.policy_clause = "";
            //jim.job_year = "";
            jim.date_create = "";
            jim.date_modi = "";
            jim.date_cancel = "";
            jim.user_create = "";
            jim.user_modi = "";
            jim.user_cancel = "";
            jim.active = "1";
            jim.jobno = txtJobNo.Value.ToString();
            if (!txtJobDate.Text.Equals(""))
            {
                DateTime jobDate = (DateTime)txtJobDate.Value;
                jim.job_date = jobDate.Year.ToString()+"-"+ jobDate.ToString("MM-dd");
            }
            else
            {
                jim.job_date = "";
            }
            jim.imp_date = "";
            jim.bl = "";
            

            jim.remark1 = txtRemark1.Text;
            jim.remark2 = txtRemark2.Text;
            jim.remark3 = txtRemark3.Text;
            jim.remark4 = txtRemark4.Text;
            jim.remark5 = txtRemark5.Text;
            jim.remark6 = txtRemark6.Text;
            jim.marsk1 = txtMarsk1.Text;
            jim.marsk2 = txtMarsk2.Text;
            jim.marsk3 = txtMarsk3.Text;
            jim.marsk4 = txtMarsk4.Text;
            jim.marsk5 = txtMarsk5.Text;
            jim.marsk6 = txtMarsk6.Text;

            return chk;
        }
        private Boolean setJobImportBl()
        {
            Boolean chk = false;
            jbl = new JobImportBl();
            jbl.job_import_bl_id = "";
            
            if (txtID.Text.Length > 0)
            {
                jbl = xC.xtDB.jblDB.selectByJobId(txtID.Text);
            }
            if(jbl.job_import_bl_id==null) jbl.job_import_bl_id = "";
            jbl.job_import_id = txtID.Text;
            //jbl.job_import_id = "job_import_id";
            jbl.forwarder_id = fwdId;
            jbl.mbl_mawb = txtMbl.Text;
            jbl.hbl_hawb = txtHbl.Text;
            jbl.m_vessel = txtMves.Text;
            jbl.f_vessel = txtFves.Text;
            if (!txtEtd.Text.Equals(""))
            {
                DateTime etd = (DateTime)txtEtd.Value;
                jbl.etd = etd.Year.ToString() + "-" + etd.ToString("MM-dd");
            }
            else
            {
                jbl.etd = "";
            }
            if (!txtEta.Text.Equals(""))
            {
                DateTime eta = (DateTime)txtEta.Value;
                jbl.eta = eta.Year.ToString() + "-" + eta.ToString("MM-dd");
            }
            else
            {
                jbl.eta = "";
            }
            //jbl.etd = "";
            //jbl.eta = "";
            jbl.port_imp_id = ptiId;

            jbl.terminal_id = "";
            jbl.marsk = "";
            jbl.description = "";
            jbl.gw = txtGw.Text;
            jbl.gw_unit_id = cboUgw.SelectedItem != null ? ((ComboBoxItem)(cboUgw.SelectedItem)).Value : "";
            jbl.unit_volume1_id = cboVolume.SelectedItem != null ? ((ComboBoxItem)(cboVolume.SelectedItem)).Value : "";
            jbl.packages_total = txtPkgTotal.Text;
            jbl.unit_package1_id = cboUtp1.SelectedItem != null ? ((ComboBoxItem)(cboUtp1.SelectedItem)).Value : "";
            jbl.total_con20 = "";
            jbl.total_con40 = "";
            jbl.volume1 = txtVolume.Text;

            jbl.port_of_loading_id = polId;
            jbl.date_check_exam = "";
            jbl.date_delivery = "";
            jbl.date_tofac = "";
            jbl.truck_id = "";
            jbl.car_number = "";
            jbl.tranfer_with_job_id = "";
            jbl.truck_cop_id = "";
            jbl.status_doc_forrow = "";
            jbl.doc_forrow = "";

            jbl.date_doc_forrow = "";
            jbl.status_job_forrow = "";
            jbl.job_forrow_description = "";
            jbl.date_finish_job_forrow = "";
            jbl.status_oth_job = "";
            jbl.delivery_remark = "";
            jbl.container_yard = "";
            jbl.date_create = "";
            jbl.date_modi = "";
            jbl.date_cancel = "";

            jbl.user_create = "";
            jbl.user_modi = "";
            jbl.user_cancel = "";
            jbl.active = "1";
            jbl.remark = "";
            jbl.oth_job_no = "";

            jbl.fwdCode = "";
            jbl.fwdCode = "";

            jbl.ugwCode = "";
            jbl.ugwNameT = "";
            jbl.utpCode = "";
            jbl.utpNameT = "";
            jbl.polCode = "";
            jbl.polNameT = "";
            jbl.tmnCode = "";
            jbl.tmnNameT = "";

            jbl.packages1 = txtPkg1.Text;
            jbl.packages2 = txtPkg2.Text;
            jbl.packages3 = txtPkg3.Text;
            jbl.packages4 = txtPkg4.Text;
            jbl.packages5 = txtPkg5.Text;
            jbl.unit_package1_id = cboUtp1.SelectedItem != null ? ((ComboBoxItem)(cboUtp1.SelectedItem)).Value : "";
            jbl.unit_package2_id = cboUtp2.SelectedItem != null ? ((ComboBoxItem)(cboUtp2.SelectedItem)).Value : "";
            jbl.unit_package3_id = cboUtp3.SelectedItem != null ? ((ComboBoxItem)(cboUtp3.SelectedItem)).Value : "";
            jbl.unit_package4_id = cboUtp4.SelectedItem != null ? ((ComboBoxItem)(cboUtp4.SelectedItem)).Value : "";
            jbl.unit_package5_id = cboUtp5.SelectedItem != null ? ((ComboBoxItem)(cboUtp5.SelectedItem)).Value : "";
            jbl.gw_total = "";
            jbl.container1 = txtContain1.Text;
            jbl.container2 = txtContain2.Text;
            jbl.container3 = txtContain3.Text;
            jbl.container4 = txtContain4.Text;
            jbl.container5 = txtContain5.Text;
            jbl.container6 = txtContain6.Text;
            jbl.container1_doc_type_id = cboContain1.SelectedItem != null ? ((ComboBoxItem)(cboContain1.SelectedItem)).Value : "";
            jbl.container2_doc_type_id = cboContain2.SelectedItem != null ? ((ComboBoxItem)(cboContain2.SelectedItem)).Value : "";
            jbl.container3_doc_type_id = cboContain3.SelectedItem != null ? ((ComboBoxItem)(cboContain3.SelectedItem)).Value : "";
            jbl.container4_doc_type_id = cboContain4.SelectedItem != null ? ((ComboBoxItem)(cboContain4.SelectedItem)).Value : "";
            jbl.container5_doc_type_id = cboContain5.SelectedItem != null ? ((ComboBoxItem)(cboContain5.SelectedItem)).Value : "";
            jbl.container6_doc_type_id = cboContain6.SelectedItem != null ? ((ComboBoxItem)(cboContain6.SelectedItem)).Value : "";
            jbl.bl_type = cboBlType.SelectedItem != null ? ((ComboBoxItem)(cboBlType.SelectedItem)).Value : "";
            jbl.bl = txtBl.Text;
            jbl.consignmnt_id = cstId;
            return chk;
        }
        private Boolean setInvoice()
        {
            Boolean chk = false;
            jin = new JobImportInv();
            jin.job_import_inv_id = txtJinId.Text;
            jin.job_import_id = txtID.Text;
            if (!txtInvDate.Text.Equals(""))
            {
                DateTime etd = (DateTime)txtInvDate.Value;
                jin.invoice_date = etd.Year.ToString() + "-" + etd.ToString("MM-dd");
            }
            else
            {
                jin.invoice_date = "";
            }
            String impId = "", ictId="", tmpId="", currId="", insrId="";
            impId = xC.xtDB.cusDB.selectImpIdByNameTLike1(txtConsNameT.Text);
            jin.cons_id = impId;       // buyer = cons_id จริงๆ คือ importer

            ictId = xC.xtDB.ictDB.selectByNameTLike(txtIctNameT.Text);
            jin.inco_terms_id = ictId;
            tmpId = xC.xtDB.tpmDB.selectByNameTLike(txtTpmNameT.Text);
            jin.term_pay_id = tmpId;

            jin.amount = txtInvAmt.Text;
            currId = xC.xtDB.currDB.selectByNameTLike(txtCurrCode.Text);
            jin.curr_id = currId;
            insrId = xC.xtDB.cusDB.selectInsrIdByNameTLike1(txtInsrNameT.Text);
            jin.insr_id = insrId;

            jin.date_create = "";
            jin.date_modi = "";
            jin.date_cancel = "";
            jin.user_create = "";
            jin.user_modi = "";
            jin.user_cancel = "";
            jin.remark = txtInvRemark.Text;
            jin.active = "";
            jin.inv_no = txtInvNo.Text;

            jin.suppCode = "";
            jin.SuppNameT = "";
            jin.ictCode = "";
            jin.ictNameT = "";
            jin.currCode = "";
            jin.currNameT = "";
            jin.tpmCode = "";
            jin.tpmNameT = "";

            return chk;
        }
        private void setControlInvNew()
        {
            //Customer cus = new Customer();
            Customer insr = new Customer();
            //cus = xC.xtDB.cusDB.selectByPk1(txtID.Text);
            insr = xC.xtDB.cusDB.selectInsurByPk1(cusId);
            txtJinId.Value = "";
            txtInvDate.Value = DateTime.Now.Year.ToString()+"-"+DateTime.Now.ToString("MM-dd");
            txtInsrNameT.Value = insr.cust_name_t;
            txtConsNameT.Value = txtImpNameT.Text;      //buyer จริงๆเป็น importer
            txtIctNameT.Value = "";
            txtTpmNameT.Value = "";
            txtInvAmt.Value = "";
            txtCurrCode.Value = "";
            
        }
        public static bool sendEmailViaOutlook(string sFromAddress, string sToAddress, string sCc, string sSubject, string sBody, BodyType bodyType, List<string> arrAttachments = null, string sBcc = null)
        {
            bool bRes = false;
            try
            {
                //Get Outlook COM objects
                Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.MailItem newMail = (Microsoft.Office.Interop.Outlook.MailItem)app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                //Parse 'sToAddress'
                if (!string.IsNullOrWhiteSpace(sToAddress))
                {
                    string[] arrAddTos = sToAddress.Split(new char[] { ';', ',' });
                    foreach (string strAddr in arrAddTos)
                    {
                        if (!string.IsNullOrWhiteSpace(strAddr) &&
                            strAddr.IndexOf('@') != -1)
                        {
                            newMail.Recipients.Add(strAddr.Trim());
                        }
                        else
                            throw new Exception("Bad to-address: " + sToAddress);
                    }
                }
                else
                    throw new Exception("Must specify to-address");

                //Parse 'sCc'
                if (!string.IsNullOrWhiteSpace(sCc))
                {
                    string[] arrAddTos = sCc.Split(new char[] { ';', ',' });
                    foreach (string strAddr in arrAddTos)
                    {
                        if (!string.IsNullOrWhiteSpace(strAddr) &&
                            strAddr.IndexOf('@') != -1)
                        {
                            newMail.Recipients.Add(strAddr.Trim());
                        }
                        else
                            throw new Exception("Bad CC-address: " + sCc);
                    }
                }

                //Is BCC empty?
                if (!string.IsNullOrWhiteSpace(sBcc))
                {
                    newMail.BCC = sBcc.Trim();
                }

                //Resolve all recepients
                if (!newMail.Recipients.ResolveAll())
                {
                    throw new Exception("Failed to resolve all recipients: " + sToAddress + ";" + sCc);
                }


                //Set type of message
                switch (bodyType)
                {
                    case BodyType.HTML:
                        newMail.HTMLBody = sBody;
                        break;
                    case BodyType.RTF:
                        newMail.RTFBody = sBody;
                        break;
                    case BodyType.PlainText:
                        newMail.Body = sBody;
                        break;
                    default:
                        throw new Exception("Bad email body type: " + bodyType);
                }


                if (arrAttachments != null)
                {
                    //Add attachments
                    foreach (string strPath in arrAttachments)
                    {
                        if (File.Exists(strPath))
                        {
                            newMail.Attachments.Add(strPath);
                        }
                        else
                            throw new Exception("Attachment file is not found: \"" + strPath + "\"");
                    }
                }

                //Add subject
                if (!string.IsNullOrWhiteSpace(sSubject))
                    newMail.Subject = sSubject;

                Microsoft.Office.Interop.Outlook.Accounts accounts = app.Session.Accounts;
                Microsoft.Office.Interop.Outlook.Account acc = null;

                //Look for our account in the Outlook
                foreach (Microsoft.Office.Interop.Outlook.Account account in accounts)
                {
                    if (account.SmtpAddress.Equals(sFromAddress, StringComparison.CurrentCultureIgnoreCase))
                    {
                        //Use it
                        acc = account;
                        break;
                    }
                }

                //Did we get the account
                if (acc != null)
                {
                    //Use this account to send the e-mail. 
                    newMail.SendUsingAccount = acc;

                    //And send it

                    ((Microsoft.Office.Interop.Outlook._MailItem)newMail).Display();
                    //((Microsoft.Office.Interop.Outlook._MailItem)newMail).Send();

                    //Done
                    bRes = true;
                }
                else
                {
                    throw new Exception("Account does not exist in Outlook: " + sFromAddress);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Failed to send mail: " + ex.Message);
            }

            return bRes;
        }


        private void FrmJobImpNew3_Load(object sender, EventArgs e)
        {

        }
    }
}
