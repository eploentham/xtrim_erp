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
using System.Reflection;
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
        JobImportCheckList jcl;
        JobImportCheckExam jce;
        JobImport jConY;
        Customer imp;

        Font fEdit, fEditB;
        Color bg, fc, cgrfOld;
        Font ff, ffB;
        C1FlexGrid grfInv, grfEmail, grfPic, grfJclExp, grfJdc, grfDeli, grfConY, grfExpnD;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String cusId = "", impId="", fwdId="", polId="", ptiId="", stfId="", cstId="", ettId="", pvlId="", ictId="", cony1id="", cony2id = "", cony3id = "", cony4id = "";

        int colJobInvId = 1, colJobInvNo = 2, colJobInvDate = 3, colJobInvCons = 4, colJobInvIncoTerm = 5, colJobInvTermPayment = 6, colJobInvAmt = 7, colJobInvCurr = 8;

        int colMarskId = 1, colMarskDesc = 2;
        int colJdcId = 1, colJdcContainerNo = 2, colJdcType=3, colJdcSeal=4;
        int colContainId = 1, colContainQty = 2, colContainContainId = 3;
        int colGwId = 1, colGwQty = 2, colGwGwId = 3;
        int colEmailB = 1, colEmailPath = 2, colEmailDel=3;
        int colConyId = 1, colConYPath = 2;
        //int colExpndId = 1, colExpndItemNamet = 2, colExpndQty = 3, colExpndUnitNameT = 4, colExpnPrice = 5, colExpndAmt = 6, colExpndReceiptNo = 7, colExpndReceiptDate = 8;

        int colDid = 1, colDItemNamet = 2, colDQty = 3, colDUnitNameT = 4, colDPrice = 5, colDamt = 6, colDwatx1 = 7, colDwatx3 = 8, colDvat = 9;
        int colDtotal = 10, colDremark = 11, colDItemId = 12, colDUnitId = 13, colDpaytocusnamet = 14, colDpaytocusaddr = 15, colDapaytocustax = 16, colDreceiptno = 17;
        int colDreceiptdate = 18, colDpaytocusid = 19, colDedit = 20;

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
            jcl = new JobImportCheckList();
            jce = new JobImportCheckExam();
            jConY = new JobImport();
            imp = new Customer();
            bg = txtJobCode.BackColor;
            fc = txtJobCode.ForeColor;
            ff = txtRef1.Font;

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            theme1.SetTheme(tC2, "VS2013Light");
            theme1.SetTheme(panel8, "VS2013Light");
            theme1.SetTheme(cDRight, "BeigeOne");
            btnJobSearch.Click += BtnJobSearch_Click;
            btnSave.Click += BtnSave_Click;
            btnInvNew.Click += BtnInvNew_Click;
            btnInvSave.Click += BtnInvSave_Click;
            btnJclSave.Click += BtnJclSave_Click;
            btnEmail.Click += BtnEmail_Click;
            btnSend.Click += BtnSend_Click;
            btnJceSave.Click += BtnJceSave_Click;
            btnConySave.Click += BtnConySave_Click;
            btnDNew.Click += BtnDNew_Click;

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
            txtDeliImporter.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtDeliTruckCop.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtDeliPlaceAddr.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtDeliContainYardNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtConYCop1.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtConYCop2.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtConYCop3.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtConYCop4.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);

            txtPkg1.KeyUp += new KeyEventHandler(TxtPkg1_KeyUp);
            txtPkg2.KeyUp += new KeyEventHandler(TxtPkg1_KeyUp);
            txtPkg3.KeyUp += new KeyEventHandler(TxtPkg1_KeyUp);
            txtPkg4.KeyUp += new KeyEventHandler(TxtPkg1_KeyUp);
            txtPkg5.KeyUp += new KeyEventHandler(TxtPkg1_KeyUp);

            txtContain1.KeyUp += new KeyEventHandler(TxtContain1_KeyUp);
            txtContain2.KeyUp += new KeyEventHandler(TxtContain1_KeyUp);
            txtContain3.KeyUp += new KeyEventHandler(TxtContain1_KeyUp);
            txtContain4.KeyUp += new KeyEventHandler(TxtContain1_KeyUp);
            txtContain5.KeyUp += new KeyEventHandler(TxtContain1_KeyUp);
            txtContain6.KeyUp += new KeyEventHandler(TxtContain1_KeyUp);
            
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

            xC.xtDB.dctDB.setC1CboTypeofBL(cboJclTypeofBl, "");
            xC.xtDB.dctDB.setC1CboCl41(cboJclPrivi1, "");
            xC.xtDB.dctDB.setC1CboCl42(cboJclPrivi2, "");
            xC.xtDB.dctDB.setC1CboCl5(cboJclDocAuthen1, "");
            xC.xtDB.dctDB.setC1CboCl5(cboJclDocAuthen2, "");
            xC.xtDB.dctDB.setC1CboCl5(cboJclDocAuthen3, "");

            xC.xtDB.ugwDB.setC1CboUgw(cboUgw, "");
            xC.xtDB.ugwDB.setC1CboUgw(cboVolume, "");
            
            
            xC.xtDB.utpDB.setC1CboUtp(cboUtp1, "");
            xC.xtDB.utpDB.setC1CboUtp(cboUtp2, "");
            xC.xtDB.utpDB.setC1CboUtp(cboUtp3, "");
            xC.xtDB.utpDB.setC1CboUtp(cboUtp4, "");
            xC.xtDB.utpDB.setC1CboUtp(cboUtp5, "");
            xC.xtDB.utpDB.setC1CboUtp(cboDeliPkg, "");
            xC.xtDB.trkDB.setCboTrkC1(cboDeliCarType);
            xC.xtDB.ugwDB.setC1CboUgw(cboDeliVolume, "");
            xC.xtDB.ugwDB.setC1CboUgw(cboDeliGw, "");
            //xC.xtDB.trkDB.setC1CboUtp(cboDeliCarType, "");
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
            setControlJcl();
            setControlJce();

            initGrfInv();
            initGrfEmail();
            initGrfPic();
            initGrfJclExp();
            initGrfJdc();
            initGrfConY();
            initGrfExpnD();

            setFocus();
            setTabIndex();
            setFocusColor();
            //txtJobCode.Enabled = false;
        }

        private void BtnDNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            
            FrmExpenseDrawD frm = new FrmExpenseDrawD(xC, "", impId, txtImpNameT.Text, imp.taddr1, imp.tax_id);
            frm.ShowDialog(this);
            setExpnDD(0, "");
        }
        private void setExpnDD(int row1, String ddid)
        {
            if (xC.sItm.item_id == null) return;
            if (!xC.sItm.item_id.Equals(""))
            {
                for (int i = 1; i < grfExpnD.Rows.Count; i++)
                {
                    if (grfExpnD[i, colDItemNamet] == null) grfExpnD.RemoveItem(i);
                }
                int row = 0;
                if (row1 > 0)
                {
                    row = row1;
                    grfExpnD[row, colDid] = ddid;
                    grfExpnD.Rows[grfExpnD.Row].StyleNew.BackColor = Color.Gray;
                }
                else
                {
                    row = grfExpnD.Rows.Count++;
                    grfExpnD[row, colDid] = "";
                }
                grfExpnD[row, colDItemId] = xC.sItm.item_id;
                grfExpnD[row, colDItemNamet] = xC.sItm.item_name_t;
                grfExpnD[row, colDQty] = xC.sItm.qty;
                grfExpnD[row, colDUnitNameT] = xC.sItm.unit_name_t;
                grfExpnD[row, colDPrice] = xC.sItm.price1;
                grfExpnD[row, colDamt] = xC.sItm.amt;
                grfExpnD[row, colDwatx1] = xC.sItm.wtax1;
                grfExpnD[row, colDwatx3] = xC.sItm.wtax3;
                grfExpnD[row, colDvat] = xC.sItm.vat;
                grfExpnD[row, colDUnitId] = xC.sItm.unit_id;
                grfExpnD[row, colDtotal] = xC.sItm.total;
                grfExpnD[row, colDpaytocusnamet] = xC.sItm.cust_name_t;
                grfExpnD[row, colDpaytocusaddr] = xC.sItm.cust_addr;
                grfExpnD[row, colDapaytocustax] = xC.sItm.cust_tax;
                grfExpnD[row, colDreceiptno] = xC.sItm.receipt_no;
                grfExpnD[row, colDreceiptdate] = xC.sItm.receipt_date;
                grfExpnD[row, colDpaytocusid] = xC.sItm.cust_id;
                grfExpnD[row, colDremark] = xC.sItm.vat;
                grfExpnD[row, colDedit] = "1";
                calAmount();
            }
        }
        private void calAmount()
        {
            Decimal amt = 0;
            for (int i = 1; i < grfExpnD.Rows.Count; i++)
            {
                Decimal amt1 = 0;
                if (grfExpnD[i, colDamt] == null) continue;
                if (Decimal.TryParse(grfExpnD[i, colDamt].ToString(), out amt1))
                {
                    amt += amt1;
                }
            }
            txtAmt.Value = amt;
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
        private void initGrfDeli()
        {
            grfDeli = new C1FlexGrid();
            grfDeli.Dock = DockStyle.Fill;
            panel16.Controls.Add(grfDeli);

            TextBox txt = new TextBox();
            C1ComboBox cbo = new C1ComboBox();

            xC.xtDB.dctDB.setC1CboContain(cbo, "");
            grfDeli.Cols[colJdcId].Editor = txt;
            grfDeli.Cols[colJdcContainerNo].Editor = txt;
            grfDeli.Cols[colJdcType].Editor = cbo;
            grfDeli.Cols[colJdcSeal].Editor = txt;
            grfDeli.Cols[colJdcId].Caption = "id";
            grfDeli.Cols[colJdcContainerNo].Caption = "container no";
            grfDeli.Cols[colJdcType].Caption = "Type";
            grfDeli.Cols[colJdcSeal].Caption = "seal";


            //grfJdc.Rows.Count = 2;
            //grfJdc.Cols.Count = 3;
            grfDeli.Cols[colJdcContainerNo].Width = 150;

            grfDeli.Cols[colJdcId].Visible = false;
            grfDeli.AfterRowColChange += GrfRemark_AfterRowColChange;
            grfDeli.CellChanged += GrfRemark_CellChanged;

            //ContextMenu menuRemark = new ContextMenu();
            //menuRemark.MenuItems.Add("&เพิ่มใหม่", new EventHandler(ContextMenu_Remark_new));
            //menuRemark.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Remark_Edit));
            //menuRemark.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Remark_Cancel));
            //grfRemark.ContextMenu = menuRemark;
        }
        private void initGrfJdc()
        {
            grfJdc = new C1FlexGrid();
            grfJdc.Dock = DockStyle.Fill;
            panel15.Controls.Add(grfJdc);
            
            TextBox txt = new TextBox();
            C1ComboBox cbo = new C1ComboBox();

            xC.xtDB.dctDB.setC1CboContain(cbo, "");
            grfJdc.Cols[colJdcId].Editor = txt;
            grfJdc.Cols[colJdcContainerNo].Editor = txt;
            grfJdc.Cols[colJdcType].Editor = cbo;
            grfJdc.Cols[colJdcSeal].Editor = txt;
            grfJdc.Cols[colJdcId].Caption = "id";
            grfJdc.Cols[colJdcContainerNo].Caption = "container no";
            grfJdc.Cols[colJdcType].Caption = "Type";
            grfJdc.Cols[colJdcSeal].Caption = "seal";

            
            //grfJdc.Rows.Count = 2;
            //grfJdc.Cols.Count = 3;
            grfJdc.Cols[colJdcContainerNo].Width = 150;

            grfJdc.Cols[colJdcId].Visible = false;
            grfJdc.AfterRowColChange += GrfRemark_AfterRowColChange;
            grfJdc.CellChanged += GrfRemark_CellChanged;

            //ContextMenu menuRemark = new ContextMenu();
            //menuRemark.MenuItems.Add("&เพิ่มใหม่", new EventHandler(ContextMenu_Remark_new));
            //menuRemark.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Remark_Edit));
            //menuRemark.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Remark_Cancel));
            //grfRemark.ContextMenu = menuRemark;
        }
        private void initGrfJclExp()
        {
            grfJclExp = new C1FlexGrid();
            grfJclExp.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();            

            grfJclExp.Cols[colContainId].Editor = txt;
            grfJclExp.Cols[colContainQty].Editor = txt;
            grfJclExp.Cols[colContainContainId].Editor = txt;
            grfJclExp.Cols[colContainQty].Caption = "qty";
            grfJclExp.Cols[colContainContainId].Caption = "TYPE";

            panel12.Controls.Add(grfJclExp);
            grfJclExp.Rows.Count = 2;
            grfJclExp.Cols.Count = 4;
            grfJclExp.Cols[colContainQty].Width = 60;
            grfJclExp.Cols[colContainContainId].Width = 150;
            grfJclExp.Cols[colContainId].Visible = false;

            grfJclExp.CellChanged += GrfContain_CellChanged;

            ContextMenu menuJclExp = new ContextMenu();
            menuJclExp.MenuItems.Add("&เพิ่มใหม่", new EventHandler(ContextMenu_JclExp_new));
            menuJclExp.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_JclExp_Edit));
            menuJclExp.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_JclExp_Cancel));
            grfJclExp.ContextMenu = menuJclExp;
        }
        private void initGrfPic()
        {
            grfPic = new C1FlexGrid();
            grfPic.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();
            C1Button btnPicAdd = new C1Button();
            C1Button btnPicDel = new C1Button();
            theme1.SetTheme(btnPicAdd, "BeigeOne");
            grfPic.BackColor = this.BackColor;
            theme1.SetTheme(grfPic, "VS2013Light");

            grfPic.Cols[colEmailB].Editor = btnPicAdd;
            grfPic.Cols[colEmailPath].Editor = txt;
            grfPic.Cols[colEmailDel].Editor = btnPicDel;
            btnPicAdd.Click += btnPicAdd_Click;
            btnPicDel.Click += btnPicDel_Click;

            grfPic.Cols[colEmailB].Caption = "+";
            grfPic.Cols[colEmailPath].Caption = "Path file";
            grfPic.Cols[colEmailDel].Caption = "Del";

            gbPic.Controls.Add(grfPic);
            grfPic.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            grfPic.Rows.Count = 2;
            grfPic.Cols.Count = 4;
            grfPic.Cols[colEmailB].Width = 60;
            grfPic.Cols[colEmailPath].Width = panel10.Width - grfEmail.Cols[colEmailB].Width - 20;
            grfPic.Cols[colEmailB].StyleNew.BackColor = Color.AntiqueWhite;

            grfPic.MouseDown += grfPic_MouseDown;

            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&เพิ่มใหม่", new EventHandler(ContextMenu_Gw_new));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            //grfGw.ContextMenu = menuGw;
        }
        private void initGrfEmail()
        {
            grfEmail = new C1FlexGrid();
            grfEmail.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();
            C1Button btnAdd = new C1Button();
            C1Button btnDel = new C1Button();
            theme1.SetTheme(btnAdd, "BeigeOne");
            grfEmail.BackColor = this.BackColor;
            theme1.SetTheme(grfEmail, "VS2013Light");

            grfEmail.Cols[colEmailB].Editor = btnAdd;
            grfEmail.Cols[colEmailPath].Editor = txt;
            grfEmail.Cols[colEmailDel].Editor = btnDel;
            btnAdd.Click += btnAdd_Click;
            btnDel.Click += btnDel_Click;

            grfEmail.Cols[colEmailB].Caption = "+";
            grfEmail.Cols[colEmailPath].Caption = "Path file";
            grfEmail.Cols[colEmailDel].Caption = "Del";

            panel10.Controls.Add(grfEmail);
            grfEmail.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            grfEmail.Rows.Count = 2;
            grfEmail.Cols.Count = 4;
            grfEmail.Cols[colEmailB].Width = 60;
            grfEmail.Cols[colEmailPath].Width = panel10.Width - grfEmail.Cols[colEmailB].Width -20;
            grfEmail.Cols[colEmailB].StyleNew.BackColor = Color.AntiqueWhite;

            grfEmail.MouseDown += grfEmail_MouseDown;

            //ContextMenu menuPkg = new ContextMenu();
            //menuPkg.MenuItems.Add("&เพิ่มใหม่", new EventHandler(ContextMenu_Pkg_new));
            //menuPkg.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Pkg_Edit));
            //menuPkg.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Pkg_Cancel));
            //grfPkg.ContextMenu = menuPkg;
        }
        private void initGrfConY()
        {
            grfConY = new C1FlexGrid();
            grfConY.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();
            
            theme1.SetTheme(grfConY, "BeigeOne");
            //grfConY.BackColor = this.BackColor;
            theme1.SetTheme(grfPic, "VS2013Light");

            grfConY.Cols[colConyId].Editor = txt;
            grfConY.Cols[colConYPath].Editor = txt;

            //grfConY.Cols[colConyId].Caption = "+";
            grfConY.Cols[colConYPath].Caption = "Path file";
            

            gBConY.Controls.Add(grfConY);
            grfConY.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            grfConY.Rows.Count = 2;
            grfConY.Cols.Count = 3;
            grfConY.Cols[colConyId].Width = 60;
            grfConY.Cols[colConYPath].Width = gBConY.Width - 20;
            grfConY.Cols[colEmailB].StyleNew.BackColor = Color.AntiqueWhite;
            grfConY.Cols[colConyId].Visible = false;
            //grfPic.MouseDown += grfPic_MouseDown;

            ContextMenu menuConY = new ContextMenu();
            menuConY.MenuItems.Add("&เพิ่มใหม่", new EventHandler(ContextMenu_ConY_new));
            menuConY.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_ConY_Del));
            menuConY.MenuItems.Add("&view", new EventHandler(ContextMenu_ConY_View));
            grfConY.ContextMenu = menuConY;
        }
        private void initGrfExpnD()
        {
            grfExpnD = new C1FlexGrid();
            grfExpnD.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();

            grfExpnD.Cols[colContainId].Editor = txt;
            grfExpnD.Cols[colContainQty].Editor = txt;
            grfExpnD.Cols[colContainContainId].Editor = txt;
            grfExpnD.Cols[colContainQty].Caption = "qty";
            grfExpnD.Cols[colContainContainId].Caption = "TYPE";

            panel20.Controls.Add(grfExpnD);
            
            grfExpnD.Rows.Count = 1;
            grfExpnD.Cols.Count = 21;
            grfExpnD.Cols[colContainQty].Width = 60;
            grfExpnD.Cols[colContainContainId].Width = 150;
            grfExpnD.Cols[colContainId].Visible = false;

            grfExpnD.CellChanged += GrfContain_CellChanged;

            ContextMenu menuJclExp = new ContextMenu();
            menuJclExp.MenuItems.Add("&ป้อนใบเสร็จรับเงิน", new EventHandler(ContextMenu_JclExp_new));
            
            grfExpnD.ContextMenu = menuJclExp;
        }
        private void setGrfExpnD(String jobid)
        {
            grfExpnD.Clear();
            grfExpnD.Rows.Count = 1;
            DataTable dt = new DataTable();
            dt = xC.xtDB.expnddDB.selectByJobId(jobid);

            grfExpnD.Cols[colDQty].Width = 80;
            grfExpnD.Cols[colDUnitNameT].Width = 140;
            grfExpnD.Cols[colDamt].Width = 100;
            grfExpnD.Cols[colDPrice].Width = 80;
            grfExpnD.Cols[colDItemNamet].Width = 220;
            grfExpnD.Cols[colDwatx1].Width = 80;
            grfExpnD.Cols[colDwatx3].Width = 80;
            grfExpnD.Cols[colDvat].Width = 80;
            grfExpnD.Cols[colDtotal].Width = 100;
            grfExpnD.Cols[colDremark].Width = 200;
            //if (flagfom2 == flagForm2.Cheque)
            //{
            grfExpnD.Cols[colDpaytocusnamet].Width = 200;
            grfExpnD.Cols[colDpaytocusaddr].Width = 200;
            grfExpnD.Cols[colDapaytocustax].Width = 80;
            grfExpnD.Cols[colDreceiptno].Width = 100;
            grfExpnD.Cols[colDreceiptdate].Width = 100;

            grfExpnD.ShowCursor = true;
            grfExpnD.Cols[colDItemNamet].Caption = "รายการ";
            grfExpnD.Cols[colDQty].Caption = "QTY";
            grfExpnD.Cols[colDUnitNameT].Caption = "หน่วย";
            grfExpnD.Cols[colDPrice].Caption = "ราคา";
            grfExpnD.Cols[colDamt].Caption = "รวมราคา";
            grfExpnD.Cols[colDwatx1].Caption = "WTAX 1%";
            grfExpnD.Cols[colDwatx3].Caption = "WTAX 3%";
            grfExpnD.Cols[colDvat].Caption = "VAT";
            grfExpnD.Cols[colDtotal].Caption = "รวมทั้งหมด";
            grfExpnD.Cols[colDremark].Caption = "หมายเหตุ";
            //if (flagfom2 == flagForm2.Cheque)
            //{
            grfExpnD.Cols[colDpaytocusnamet].Caption = "ชื่อลูกค้า";
            grfExpnD.Cols[colDpaytocusaddr].Caption = "ที่อยู่ลูกค้า";
            grfExpnD.Cols[colDapaytocustax].Caption = "tax id";
            grfExpnD.Cols[colDreceiptno].Caption = "เลขที่ใบเสร็จ";
            grfExpnD.Cols[colDreceiptdate].Caption = "วันที่ในใบเสร็จ";

            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Row row = grfExpnD.Rows.Add();
                row[0] = i + 1;
                if (i % 2 == 0)
                    grfExpnD.Rows[i].StyleNew.BackColor = color;
                row[colDid] = dt.Rows[i][xC.xtDB.expnddDB.expnC.expenses_draw_detail_id].ToString();
                row[colDItemNamet] = dt.Rows[i][xC.xtDB.expnddDB.expnC.item_name_t].ToString();
                row[colDQty] = dt.Rows[i][xC.xtDB.expnddDB.expnC.qty].ToString();
                row[colDUnitNameT] = dt.Rows[i][xC.xtDB.expnddDB.expnC.unit_name_t].ToString();
                row[colDamt] = dt.Rows[i][xC.xtDB.expnddDB.expnC.amount].ToString();
                row[colDPrice] = dt.Rows[i][xC.xtDB.expnddDB.expnC.price].ToString();
                row[colDwatx1] = dt.Rows[i][xC.xtDB.expnddDB.expnC.wtax1].ToString();
                row[colDwatx3] = dt.Rows[i][xC.xtDB.expnddDB.expnC.wtax3].ToString();
                row[colDvat] = dt.Rows[i][xC.xtDB.expnddDB.expnC.vat].ToString();
                row[colDtotal] = dt.Rows[i][xC.xtDB.expnddDB.expnC.total].ToString();
                row[colDremark] = dt.Rows[i][xC.xtDB.expnddDB.expnC.remark].ToString();
                row[colDItemId] = dt.Rows[i][xC.xtDB.expnddDB.expnC.item_id].ToString();
                //if (flagfom2 == flagForm2.Cheque)
                //{
                row[colDpaytocusnamet] = dt.Rows[i][xC.xtDB.expnddDB.expnC.pay_to_cus_name_t].ToString();
                row[colDpaytocusaddr] = dt.Rows[i][xC.xtDB.expnddDB.expnC.pay_to_cus_addr].ToString();
                row[colDapaytocustax] = dt.Rows[i][xC.xtDB.expnddDB.expnC.pay_to_cus_tax].ToString();
                row[colDreceiptno] = dt.Rows[i][xC.xtDB.expnddDB.expnC.receipt_no].ToString();
                row[colDreceiptdate] = dt.Rows[i][xC.xtDB.expnddDB.expnC.receipt_date].ToString();
                row[colDpaytocusid] = dt.Rows[i][xC.xtDB.expnddDB.expnC.pay_to_cus_id].ToString();
                row[colDedit] = "-";
            }
            grfExpnD.Cols[colDid].Visible = false;
        }
        private void setGrfJdc()
        {
            DataTable dt = new DataTable();
            dt = xC.xtDB.jcnDB.selectByJobId(txtID.Text);
            if (dt.Rows.Count > 0)
            {
                grfJdc.DataSource = dt;
            }
            else
            {
                ComboBoxItem ci1 = new ComboBoxItem();
                ComboBoxItem ci2 = new ComboBoxItem();
                ComboBoxItem ci3 = new ComboBoxItem();
                ComboBoxItem ci4 = new ComboBoxItem();
                ComboBoxItem ci5 = new ComboBoxItem();
                ComboBoxItem ci6 = new ComboBoxItem();
                ci1 = (ComboBoxItem)(cboContain1.SelectedItem);
                ci2 = (ComboBoxItem)(cboContain2.SelectedItem);
                ci3 = (ComboBoxItem)(cboContain3.SelectedItem);
                ci4 = (ComboBoxItem)(cboContain4.SelectedItem);
                ci5 = (ComboBoxItem)(cboContain5.SelectedItem);
                ci6 = (ComboBoxItem)(cboContain6.SelectedItem);
                int cnt = 0, cn1 = 0, cn2 = 0, cn3 = 0, cn4 = 0, cn5 = 0, cn6 = 0;
                int.TryParse(txtContainTotal.Text, out cnt);
                int.TryParse(txtContain1.Text, out cn1);
                int.TryParse(txtContain2.Text, out cn2);
                int.TryParse(txtContain3.Text, out cn3);
                int.TryParse(txtContain4.Text, out cn4);
                int.TryParse(txtContain5.Text, out cn5);
                int.TryParse(txtContain6.Text, out cn6);
                cn2 += cn1;
                cn3 += cn2;
                cn4 += cn3;
                cn5 += cn4;
                cn6 += cn5;
                grfJdc.Rows.Count = cnt+1;
                grfJdc.Cols.Count = 5;
                for (int i = 1; i < grfJdc.Rows.Count; i++)
                {
                    grfJdc[i, 0] = i;
                    if (i <= cn1)
                    {
                        grfJdc[i, colJdcType] = ci1;
                    }
                    else if ((i > cn1) && (i <= cn2))
                    {
                        grfJdc[i, colJdcType] = ci2;
                    }
                    else if ((i > cn2) && (i <= cn3))
                    {
                        grfJdc[i, colJdcType] = ci3;
                    }
                    else if ((i > cn3) && (i <= cn4))
                    {
                        grfJdc[i, colJdcType] = ci4;
                    }
                    else if ((i > cn4) && (i <= cn5))
                    {
                        grfJdc[i, colJdcType] = ci5;
                    }
                    else if ((i > cn5) && (i <= cn6))
                    {
                        grfJdc[i, colJdcType] = ci6;
                    }
                }
            }
        }
        private void grfPic_MouseDown(object sender, MouseEventArgs e)
        {
            //Check if Button column has been clicked.
            if (grfPic.Cols[grfPic.MouseCol].Editor is C1Button)
            {
                //Current cell enters in edit mode, and button is clicked
                SendKeys.Send("{ENTER}");
                SendKeys.Send("{ENTER}");
            }
        }
        private void btnPicAdd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(String.Format("Button clicked in - Row : {0}, column : {1}.", grfEmail.MouseRow.ToString(), grfEmail.MouseCol.ToString()));
            OpenFileDialog theDialog = new OpenFileDialog();
            DialogResult result = theDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                grfPic[grfPic.Row, colEmailPath] = theDialog.FileName;
                if (grfPic.Rows.Count == (grfPic.Row + 1)) grfPic.Rows.Count++;
            }
        }
        private void btnPicDel_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(String.Format("Button clicked in - Row : {0}, column : {1}.", grfEmail.MouseRow.ToString(), grfEmail.MouseCol.ToString()));
            if (grfPic.Rows.Count == (grfPic.Row + 1)) return;
            grfPic.RemoveItem(grfPic.Row);
        }
        private void grfEmail_MouseDown(object sender, MouseEventArgs e)
        {
            //Check if Button column has been clicked.
            if (grfEmail.Cols[grfEmail.MouseCol].Editor is C1Button)
            {
                //Current cell enters in edit mode, and button is clicked
                SendKeys.Send("{ENTER}");
                SendKeys.Send("{ENTER}");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(String.Format("Button clicked in - Row : {0}, column : {1}.", grfEmail.MouseRow.ToString(), grfEmail.MouseCol.ToString()));
            OpenFileDialog theDialog = new OpenFileDialog();
            DialogResult result = theDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                grfEmail[grfEmail.Row, colEmailPath] = theDialog.FileName;
                if (grfEmail.Rows.Count == (grfEmail.Row+1)) grfEmail.Rows.Count++;
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(String.Format("Button clicked in - Row : {0}, column : {1}.", grfEmail.MouseRow.ToString(), grfEmail.MouseCol.ToString()));
            if (grfEmail.Rows.Count == (grfEmail.Row + 1)) return;
            grfEmail.RemoveItem(grfEmail.Row);
        }
        private void GrfRemark_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfJdc.Row == grfJdc.Rows.Count)
            {
                grfJdc.Rows.Count = grfJdc.Rows.Count + 1;
            }
        }
        private void GrfGw_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            //grfGw.Rows.Count = (grfGw.Row == grfGw.Rows.Count - 1) ? (grfGw.Rows.Count = grfGw.Rows.Count + 1) : grfGw.Rows.Count;
        }

        private void GrfContain_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            //grfContain.Rows.Count = (grfContain.Row == grfContain.Rows.Count - 1) ? (grfContain.Rows.Count = grfContain.Rows.Count + 1) : grfContain.Rows.Count;
        }

        private void GrfMarsk_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            grfInv.Rows.Count = (grfInv.Row == grfInv.Rows.Count - 1) ? (grfInv.Rows.Count = grfInv.Rows.Count + 1) : grfInv.Rows.Count;
        }

        private void GrfPkg_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            //grfPkg.Rows.Count = (grfPkg.Row == grfPkg.Rows.Count - 1) ? (grfPkg.Rows.Count = grfPkg.Rows.Count + 1) : grfPkg.Rows.Count;
        }

        private void GrfRemark_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfJdc.Row == grfJdc.Rows.Count - 1)
            {
                grfJdc.Rows.Count = grfJdc.Rows.Count + 1;
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
        private void ContextMenu_ConY_new(object sender, System.EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            DialogResult result = theDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                grfConY[grfConY.Rows.Count-1, colConYPath] = theDialog.FileName;
                //if (grfConY.Rows.Count == (grfConY.Row + 1)) grfConY.Rows.Count++;
                grfConY.Rows.Count++;
            }
        }
        private void ContextMenu_ConY_Del(object sender, System.EventArgs e)
        {

        }
        private void ContextMenu_ConY_View(object sender, System.EventArgs e)
        {

        }
        private void ContextMenu_Remark_new(object sender, System.EventArgs e)
        {
            
        }
        private void ContextMenu_Remark_Edit(object sender, System.EventArgs e)
        {

        }
        private void ContextMenu_Remark_Cancel(object sender, System.EventArgs e)
        {

        }
        private void ContextMenu_JclExp_new(object sender, System.EventArgs e)
        {
            FrmJobImpCheckListExp frm = new FrmJobImpCheckListExp(xC);
            frm.ShowDialog(this);
        }
        private void ContextMenu_JclExp_Edit(object sender, System.EventArgs e)
        {

        }
        private void ContextMenu_JclExp_Cancel(object sender, System.EventArgs e)
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
        private void BtnConySave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("ข้อมูล job ยังไม่มีข้อมูล", "");
                return;
            }
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setJobImportContainYard();
                String re = xC.xtDB.jimDB.updateContainerYard(jConY);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnConySave.Image = Resources.accept_database24;
                }
                else
                {
                    btnConySave.Image = Resources.DeleteTable_small;
                }
                //setGrdView();
                //this.Dispose();
            }
        }
        private void BtnJceSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("ข้อมูล job ยังไม่มีข้อมูล", "");
                return;
            }
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setJobImportCheckExam();
                String re = xC.xtDB.jceDB.insertJobImportCheckExam(jce);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnJclSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnJclSave.Image = Resources.DeleteTable_small;
                }
                //setGrdView();
                //this.Dispose();
            }
        }
        private void BtnJclSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("ข้อมูล job ยังไม่มีข้อมูล", "");
                return;
            }
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setJobImportCheckList();
                String re = xC.xtDB.jclDB.insertJobImportCheckList(jcl);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnJclSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnJclSave.Image = Resources.DeleteTable_small;
                }
                //setGrdView();
                //this.Dispose();
            }
        }
        private void BtnSend_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            List<String> lfile = new List<String>();
            for(int i = 1; i < grfEmail.Rows.Count; i++)
            {
                if(grfEmail[i, colEmailPath]!=null) lfile.Add(grfEmail[i, colEmailPath].ToString());
            }
            sendEmailViaOutlook("eploentham@xtrim-logistics.com", txtTo.Text, "", txtSubject.Text, txtBody.Text, BodyType.HTML, lfile, null);
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
        private void setFocusColor()
        {
            this.txtJobCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtJobCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRef1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRef1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRef2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRef2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRef3.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRef3.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRef4.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRef4.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRef5.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRef5.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtJobNo.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtJobNo.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtStaffCS.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtStaffCS.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEttNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEttNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPvlNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPvlNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboChkExam.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboChkExam.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboTransMode.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboTransMode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCusNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCusNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCusAddr.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCusAddr.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCusContactNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCusContactNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtFwdNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtFwdNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPolNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPolNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtConsignmnt.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtConsignmnt.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMbl.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMbl.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEtd.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEtd.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboBlType.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboBlType.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtBl.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtBl.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtImpNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtImpNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtImpAddr.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtImpAddr.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtImpContactNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtImpContactNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMves.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMves.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtFves.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtFves.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtHbl.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtHbl.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEta.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEta.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPtiNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPtiNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTmnNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTmnNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMarsk1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMarsk1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMarsk2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMarsk2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMarsk3.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMarsk3.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMarsk4.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMarsk4.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMarsk5.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMarsk5.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMarsk6.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMarsk6.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPkg1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPkg1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPkg2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPkg2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPkg3.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPkg3.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPkg4.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPkg4.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPkg5.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPkg5.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboUtp1.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboUtp1.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboUtp2.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboUtp2.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboUtp3.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboUtp3.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboUtp4.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboUtp4.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboUtp5.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboUtp5.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtGw.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtGw.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtVolume.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtVolume.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboUgw.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboUgw.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboVolume.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboVolume.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContain1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContain1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContain2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContain2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContain3.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContain3.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContain4.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContain4.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContain5.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContain5.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContain6.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContain6.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboContain1.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboContain1.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboContain2.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboContain2.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboContain3.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboContain3.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboContain4.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboContain4.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboContain5.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboContain5.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboContain6.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboContain6.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark3.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark3.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark4.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark4.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark5.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark5.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark6.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark6.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtDeliImporter.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDeliImporter.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtDeliImporterAddr.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDeliImporterAddr.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtDeliPkg.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDeliPkg.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtDeliGw.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDeliGw.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtDeliVolume.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDeliVolume.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtDeliTruckCop.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDeliTruckCop.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtDeliPlaceAddr.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDeliPlaceAddr.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtDeliContainYardNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDeliContainYardNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtJceNumOpenGoods.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtJceNumOpenGoods.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtJceNumLayoutBad.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtJceNumLayoutBad.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtJceBadGoodsDesc.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtJceBadGoodsDesc.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtJceAttendCorrupt.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtJceAttendCorrupt.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtJceDmcNo.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtJceDmcNo.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEmailDo.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEmailDo.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtJclPrivi1Desc.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtJclPrivi1Desc.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtJclPrivi2Desc.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtJclPrivi2Desc.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtInsurAtten.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtInsurAtten.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEmailDo1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEmailDo1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtParent1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtParent1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtConYCop1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtConYCop1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtConYCop1Addr.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtConYCop1Addr.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtConYCop1TimeOpen.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtConYCop1TimeOpen.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtConYCop1TimeOpenOver.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtConYCop1TimeOpenOver.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtConYCop2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtConYCop2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtConYCop2Addr.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtConYCop2Addr.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtConYCop2TimeOpen.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtConYCop2TimeOpen.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtConYCop2TimeOpenOver.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtConYCop2TimeOpenOver.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtConYCop3.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtConYCop3.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtConYCop3Addr.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtConYCop3Addr.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtConYCop3TimeOpen.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtConYCop3TimeOpen.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtConYCop3TimeOpenOver.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtConYCop3TimeOpenOver.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtConYCop4.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtConYCop4.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtConYCop4Addr.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtConYCop4Addr.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtConYCop4TimeOpen.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtConYCop4TimeOpen.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtConYCop4TimeOpenOver.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtConYCop4TimeOpenOver.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtJceQtyOpenGoods.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtJceQtyOpenGoods.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtJceQtyLayoutBad.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtJceQtyLayoutBad.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = xC.cTxtFocus;
            a.Font = new Font(ff, FontStyle.Bold);
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = bg;
            a.ForeColor = fc;
            a.Font = new Font(ff, FontStyle.Regular);
        }
        private void setTabIndex()
        {
            txtJobCode.TabIndex = 1;
            txtJobDate.TabIndex = 2;
            txtRef1.TabIndex = 3;
            txtRef2.TabIndex = 4;
            txtRef3.TabIndex = 5;
            txtRef4.TabIndex = 6;
            txtRef5.TabIndex = 7;
            txtJobNo.TabIndex = 8;
            txtStaffCS.TabIndex = 9;
            txtEttNameT.TabIndex = 10;

            txtPvlNameT.TabIndex = 11;
            cboChkExam.TabIndex = 12;
            cboTransMode.TabIndex = 13;
            txtCusNameT.TabIndex = 14;
            txtCusAddr.TabIndex = 15;
            txtCusContactNameT.TabIndex = 16;
            txtFwdNameT.TabIndex = 17;
            txtPolNameT.TabIndex = 18;
            txtConsignmnt.TabIndex = 19;
            txtMbl.TabIndex = 20;
            txtEtd.TabIndex = 21;
            cboBlType.TabIndex = 22;
            txtBl.TabIndex = 23;
            txtImpNameT.TabIndex = 24;
            txtImpAddr.TabIndex = 25;
            txtImpContactNameT.TabIndex = 26;
            txtMves.TabIndex = 27;
            txtFves.TabIndex = 28;
            txtHbl.TabIndex = 29;
            txtEta.TabIndex = 30;
            txtPtiNameT.TabIndex = 31;
            txtTmnNameT.TabIndex = 32;
            txtMarsk1.TabIndex = 33;
            txtMarsk2.TabIndex = 34;
            txtMarsk3.TabIndex = 35;
            txtMarsk4.TabIndex = 36;
            txtMarsk5.TabIndex = 37;
            txtMarsk6.TabIndex = 38;
            txtPkg1.TabIndex = 39;
            txtPkg2.TabIndex = 40;
            txtPkg3.TabIndex = 41;
            txtPkg4.TabIndex = 42;
            txtPkg5.TabIndex = 43;
            cboUtp1.TabIndex = 44;
            cboUtp2.TabIndex = 45;
            cboUtp3.TabIndex = 46;
            cboUtp4.TabIndex = 47;
            cboUtp5.TabIndex = 48;
            txtGw.TabIndex = 49;
            txtVolume.TabIndex = 50;
            cboUgw.TabIndex = 51;
            cboVolume.TabIndex = 52;
            txtContain1.TabIndex = 53;
            txtContain2.TabIndex = 54;
            txtContain3.TabIndex = 55;
            txtContain4.TabIndex = 56;
            txtContain5.TabIndex = 57;
            txtContain6.TabIndex = 58;
            cboContain1.TabIndex = 59;
            cboContain2.TabIndex = 60;
            cboContain3.TabIndex = 61;
            cboContain4.TabIndex = 62;
            cboContain5.TabIndex = 63;
            cboContain6.TabIndex = 64;
            txtRemark1.TabIndex = 65;
            txtRemark2.TabIndex = 66;
            txtRemark3.TabIndex = 67;
            txtRemark4.TabIndex = 68;
            txtRemark5.TabIndex = 69;
            txtRemark6.TabIndex = 70;
        }
        private void setFocus()
        {
            txtJobCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtJobDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtRef1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtRef2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtRef3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtRef4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtRef5.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);

            txtJobNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtStaffCS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtEttNameT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtPvlNameT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            cboChkExam.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            cboTransMode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusNameT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusAddr.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusContactNameT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtFwdNameT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtPolNameT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtConsignmnt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtMbl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtEtd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            cboBlType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtBl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtImpNameT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtImpAddr.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtImpContactNameT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtMves.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtFves.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtHbl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtEta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtPtiNameT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtTmnNameT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtMarsk1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtMarsk2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtMarsk3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtMarsk4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtMarsk5.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtMarsk6.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtPkg1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtPkg2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtPkg3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtPkg4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtPkg5.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            cboUtp1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            cboUtp2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            cboUtp3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            cboUtp4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            cboUtp5.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtGw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtVolume.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            cboUgw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            cboVolume.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtContain1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtContain2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtContain3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtContain4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtContain5.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtContain6.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            cboContain1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            cboContain2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            cboContain3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            cboContain4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            cboContain5.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            cboContain6.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtRemark1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtRemark2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtRemark3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtRemark4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtRemark5.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtRemark6.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            //txtRef51.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
        }
        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sender.Equals(txtJobCode))
                {
                    txtJobDate.Focus();
                }
                else if (sender.Equals(txtJobDate))
                {
                    txtRef1.Focus();
                }
                else if (sender.Equals(txtRef1))
                {
                    txtRef2.Focus();
                }
                else if (sender.Equals(txtRef2))
                {
                    txtRef3.Focus();
                }
                else if (sender.Equals(txtRef3))
                {
                    txtRef4.Focus();
                }
                else if (sender.Equals(txtRef4))
                {
                    txtRef5.Focus();
                }
                else if (sender.Equals(txtRef5))
                {
                    txtJobNo.Focus();
                }
                else if (sender.Equals(txtJobNo))
                {
                    txtStaffCS.Focus();
                }
                else if (sender.Equals(txtStaffCS))
                {
                    txtEttNameT.Focus();
                }
                else if (sender.Equals(txtEttNameT))
                {
                    txtPvlNameT.Focus();
                }
                else if (sender.Equals(txtPvlNameT))
                {
                    cboChkExam.Focus();
                }
                else if (sender.Equals(cboChkExam))
                {
                    cboTransMode.Focus();
                }
                else if (sender.Equals(cboTransMode))
                {
                    txtCusNameT.Focus();
                }
                else if (sender.Equals(txtCusNameT))
                {
                    txtCusAddr.Focus();
                }
                else if (sender.Equals(txtCusAddr))
                {
                    txtCusContactNameT.Focus();
                }
                else if (sender.Equals(txtCusContactNameT))
                {
                    txtFwdNameT.Focus();
                }
                else if (sender.Equals(txtFwdNameT))
                {
                    txtPolNameT.Focus();
                }
                else if (sender.Equals(txtPolNameT))
                {
                    txtConsignmnt.Focus();
                }
                else if (sender.Equals(txtConsignmnt))
                {
                    txtMbl.Focus();
                }
                else if (sender.Equals(txtMbl))
                {
                    txtEtd.Focus();
                }
                else if (sender.Equals(txtEtd))
                {
                    cboBlType.Focus();
                }
                else if (sender.Equals(cboBlType))
                {
                    txtBl.Focus();
                }
                else if (sender.Equals(txtBl))
                {
                    txtImpNameT.Focus();
                }
                else if (sender.Equals(txtImpNameT))
                {
                    txtImpAddr.Focus();
                }
                else if (sender.Equals(txtImpAddr))
                {
                    txtImpContactNameT.Focus();
                }
                else if (sender.Equals(txtImpContactNameT))
                {
                    txtMves.Focus();
                }
                else if (sender.Equals(txtMves))
                {
                    txtFves.Focus();
                }
                else if (sender.Equals(txtFves))
                {
                    txtHbl.Focus();
                }
                else if (sender.Equals(txtHbl))
                {
                    txtEta.Focus();
                }
                else if (sender.Equals(txtEta))
                {
                    txtPtiNameT.Focus();
                }
                else if (sender.Equals(txtPtiNameT))
                {
                    txtTmnNameT.Focus();
                }
                else if (sender.Equals(txtTmnNameT))
                {
                    txtMarsk1.Focus();
                }
                else if (sender.Equals(txtMarsk1))
                {
                    txtMarsk2.Focus();
                }
                else if (sender.Equals(txtMarsk2))
                {
                    txtMarsk3.Focus();
                }
                else if (sender.Equals(txtMarsk3))
                {
                    txtMarsk4.Focus();
                }
                else if (sender.Equals(txtMarsk4))
                {
                    txtMarsk5.Focus();
                }
                else if (sender.Equals(txtMarsk5))
                {
                    txtMarsk6.Focus();
                }
                else if (sender.Equals(txtMarsk6))
                {
                    txtPkg1.Focus();
                }
                else if (sender.Equals(txtPkg1))
                {
                    txtPkg2.Focus();
                }
                else if (sender.Equals(txtPkg2))
                {
                    txtPkg3.Focus();
                }
                else if (sender.Equals(txtPkg3))
                {
                    txtPkg4.Focus();
                }
                else if (sender.Equals(txtPkg4))
                {
                    txtPkg5.Focus();
                }
                else if (sender.Equals(txtPkg5))
                {
                    cboUtp1.Focus();
                }
                else if (sender.Equals(cboUtp1))
                {
                    cboUtp2.Focus();
                }
                else if (sender.Equals(cboUtp2))
                {
                    cboUtp3.Focus();
                }
                else if (sender.Equals(cboUtp3))
                {
                    cboUtp4.Focus();
                }
                else if (sender.Equals(cboUtp4))
                {
                    cboUtp5.Focus();
                }
                else if (sender.Equals(cboUtp5))
                {
                    txtGw.Focus();
                }
                else if (sender.Equals(txtGw))
                {
                    txtVolume.Focus();
                }
                else if (sender.Equals(txtVolume))
                {
                    cboUgw.Focus();
                }
                else if (sender.Equals(cboUgw))
                {
                    cboVolume.Focus();
                }
                else if (sender.Equals(cboVolume))
                {
                    txtContain1.Focus();
                }
                else if (sender.Equals(txtContain1))
                {
                    txtContain2.Focus();
                }
                else if (sender.Equals(txtContain2))
                {
                    txtContain3.Focus();
                }
                else if (sender.Equals(txtContain3))
                {
                    txtContain4.Focus();
                }
                else if (sender.Equals(txtContain4))
                {
                    txtContain5.Focus();
                }
                else if (sender.Equals(txtContain5))
                {
                    txtContain6.Focus();
                }
                else if (sender.Equals(txtContain6))
                {
                    cboContain1.Focus();
                }
                else if (sender.Equals(cboContain1))
                {
                    cboContain2.Focus();
                }
                else if (sender.Equals(cboContain2))
                {
                    cboContain3.Focus();
                }
                else if (sender.Equals(cboContain3))
                {
                    cboContain4.Focus();
                }
                else if (sender.Equals(cboContain4))
                {
                    cboContain5.Focus();
                }
                else if (sender.Equals(cboContain5))
                {
                    cboContain6.Focus();
                }
                else if (sender.Equals(cboContain6))
                {
                    txtRemark1.Focus();
                }
                else if (sender.Equals(txtRemark1))
                {
                    txtRemark2.Focus();
                }
                else if (sender.Equals(txtRemark2))
                {
                    txtRemark3.Focus();
                }
                else if (sender.Equals(txtRemark3))
                {
                    txtRemark4.Focus();
                }
                else if (sender.Equals(txtRemark4))
                {
                    txtRemark5.Focus();
                }
                else if (sender.Equals(txtRemark5))
                {
                    txtRemark6.Focus();
                }
                else if (sender.Equals(txtRemark6))
                {
                    //txtPvlNameT1.Focus();
                }
            }
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
            imp = xC.sImp;
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
        private void setKeyUpF2DeliImp()
        {
            Point pp = txtDeliImporter.Location;
            pp.Y = pp.Y + 120;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Importer, pp);
            frm.ShowDialog(this);
            setKeyUpF2DeliImp1(xC.sImp);
        }
        private void setKeyUpF2DeliImp1(Customer imp)
        {
            txtDeliImporter.Value = imp.cust_name_t;
            txtDeliImporterAddr.Value = imp.taddr1 + Environment.NewLine + imp.taddr2 + Environment.NewLine + imp.taddr3 + Environment.NewLine + imp.taddr4 + Environment.NewLine + imp.cust_code + Environment.NewLine + imp.remark;
        }
        private void setKeyUpF2DeliTrkCop()
        {
            Point pp = txtDeliTruckCop.Location;
            pp.Y = pp.Y + 120;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.TruckCop, pp);
            frm.ShowDialog(this);
            setKeyUpF2DeliTrkCop1(xC.sTrkCop);
        }
        private void setKeyUpF2DeliTrkCop1(Customer trk)
        {
            txtDeliTruckCop.Value = trk.cust_name_t;
        }
        private void setKeyUpF2DeliPlaceAddr()
        {
            Point pp = txtDeliPlaceAddr.Location;
            pp.Y = pp.Y + 140;
            pp.X = pp.X + 240;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.AddressPlaceAddr, pp);
            frm.ShowDialog(this);
            setKeyUpF2DeliPlaceAddr1(xC.sAddr);
        }
        private void setKeyUpF2DeliPlaceAddr1(Address addr)
        {
            txtDeliPlaceAddr.Value = addr.address_name+" "+addr.line_t1;
        }
        private void setKeyUpF2DeliContainerYard()
        {
            Point pp = txtDeliContainYardNameT.Location;
            pp.Y = pp.Y + 140;
            pp.X = pp.X + 240;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.AddressPlaceAddr, pp);
            frm.ShowDialog(this);
            setKeyUpF2DeliContainerYard1(xC.sAddr);
        }
        private void setKeyUpF2DeliContainerYard1(Address addr)
        {
            txtDeliContainYardNameT.Value = addr.address_name + " " + addr.line_t1;
        }
        private void setKeyUpF2ConYCop1()
        {
            Point pp = txtConYCop1.Location;
            pp.Y = pp.Y + 150;
            pp.X = pp.X + 280;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.ContainerYard, pp);
            frm.ShowDialog(this);
            setKeyUpF2ConYCop11(xC.sConY, xC.sAddr);
        }
        private void setKeyUpF2ConYCop11(Customer conY, Address addr)
        {
            String txt = "",txt1="",addrname="";
            txt = conY.taddr1 + Environment.NewLine;
            if(!conY.taddr2.Equals("")) txt += conY.taddr2 + Environment.NewLine;
            if (!conY.taddr3.Equals("")) txt += conY.taddr3 + Environment.NewLine;
            if (!conY.taddr4.Equals("")) txt += conY.taddr4 + Environment.NewLine;
            if (!conY.cust_code.Equals("")) txt += conY.cust_code + Environment.NewLine;
            if (!conY.remark.Equals("")) txt += conY.remark + Environment.NewLine;
            if (!conY.tele.Equals("")) txt += conY.tele + Environment.NewLine;
            //if (!conY.t.Equals("")) txt += conY.tele + Environment.NewLine;
            txtConYCop1.Value = conY.cust_name_t;
            txtConYCop1Addr.Value = txt;
            cony1id = xC.sConY.cust_id;

            if (addr == null) return;

            addrname = addr.address_name.Equals("") ? "ชื่อลานคืนตู้ ไม่ได้ระบุ" : addr.address_name;
            if (!addrname.Equals("")) txt1 = addrname + Environment.NewLine;
            if (!addr.time_open_close.Equals("")) txt1 += "เวลาเปิด-ปิด "+addr.time_open_close + Environment.NewLine;
            if (!addr.contact_name1.Equals("")) txt1 += "ชื่อผู้ติดต่อ1 "+addr.contact_name1 + Environment.NewLine;
            if (!addr.contact_name_tel1.Equals("")) txt1 += "เบอร์ "+addr.contact_name_tel1 + Environment.NewLine;
            txtConYCop1TimeOpen.Value = txt1;
            txtConYCop1TimeOpenOver.Value = addr.time_open_close_over_time +"[" +addr.rate_over_time+ "] ชื่อผู้ติดต่อ2 " + addr.contact_name2+ " เบอร์ " + addr.contact_name_tel2;
            
        }
        private void setKeyUpF2ConYCop2()
        {
            Point pp = txtConYCop2.Location;
            pp.Y = pp.Y + 150;
            pp.X = pp.X + 280;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.ContainerYard, pp);
            frm.ShowDialog(this);
            setKeyUpF2ConYCop21(xC.sConY, xC.sAddr);
        }
        private void setKeyUpF2ConYCop21(Customer conY, Address addr)
        {
            String txt = "", txt1 = "", addrname = "";
            txt = conY.taddr1 + Environment.NewLine;
            if (!conY.taddr2.Equals("")) txt += conY.taddr2 + Environment.NewLine;
            if (!conY.taddr3.Equals("")) txt += conY.taddr3 + Environment.NewLine;
            if (!conY.taddr4.Equals("")) txt += conY.taddr4 + Environment.NewLine;
            if (!conY.cust_code.Equals("")) txt += conY.cust_code + Environment.NewLine;
            if (!conY.remark.Equals("")) txt += conY.remark + Environment.NewLine;
            if (!conY.tele.Equals("")) txt += conY.tele + Environment.NewLine;
            //if (!conY.t.Equals("")) txt += conY.tele + Environment.NewLine;
            txtConYCop2.Value = conY.cust_name_t;
            txtConYCop2Addr.Value = txt;
            cony1id = xC.sConY.cust_id;

            if (addr == null) return;

            addrname = addr.address_name.Equals("") ? "ชื่อลานคืนตู้ ไม่ได้ระบุ" : addr.address_name;
            if (!addrname.Equals("")) txt1 = addrname + Environment.NewLine;
            if (!addr.time_open_close.Equals("")) txt1 += "เวลาเปิด-ปิด " + addr.time_open_close + Environment.NewLine;
            if (!addr.contact_name1.Equals("")) txt1 += "ชื่อผู้ติดต่อ1 " + addr.contact_name1 + Environment.NewLine;
            if (!addr.contact_name_tel1.Equals("")) txt1 += "เบอร์ " + addr.contact_name_tel1 + Environment.NewLine;
            txtConYCop2TimeOpen.Value = txt1;
            txtConYCop2TimeOpenOver.Value = addr.time_open_close_over_time + "[" + addr.rate_over_time + "] ชื่อผู้ติดต่อ2 " + addr.contact_name2 + " เบอร์ " + addr.contact_name_tel2;

        }
        private void setKeyUpF2ConYCop3()
        {
            Point pp = txtConYCop3.Location;
            pp.Y = pp.Y + 150;
            pp.X = pp.X + 280;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.ContainerYard, pp);
            frm.ShowDialog(this);
            setKeyUpF2ConYCop31(xC.sConY, xC.sAddr);
        }
        private void setKeyUpF2ConYCop31(Customer conY, Address addr)
        {
            String txt = "", txt1 = "", addrname = "";
            txt = conY.taddr1 + Environment.NewLine;
            if (!conY.taddr2.Equals("")) txt += conY.taddr2 + Environment.NewLine;
            if (!conY.taddr3.Equals("")) txt += conY.taddr3 + Environment.NewLine;
            if (!conY.taddr4.Equals("")) txt += conY.taddr4 + Environment.NewLine;
            if (!conY.cust_code.Equals("")) txt += conY.cust_code + Environment.NewLine;
            if (!conY.remark.Equals("")) txt += conY.remark + Environment.NewLine;
            if (!conY.tele.Equals("")) txt += conY.tele + Environment.NewLine;
            //if (!conY.t.Equals("")) txt += conY.tele + Environment.NewLine;
            txtConYCop3.Value = conY.cust_name_t;
            txtConYCop3Addr.Value = txt;
            cony1id = xC.sConY.cust_id;

            if (addr == null) return;

            addrname = addr.address_name.Equals("") ? "ชื่อลานคืนตู้ ไม่ได้ระบุ" : addr.address_name;
            if (!addrname.Equals("")) txt1 = addrname + Environment.NewLine;
            if (!addr.time_open_close.Equals("")) txt1 += "เวลาเปิด-ปิด " + addr.time_open_close + Environment.NewLine;
            if (!addr.contact_name1.Equals("")) txt1 += "ชื่อผู้ติดต่อ1 " + addr.contact_name1 + Environment.NewLine;
            if (!addr.contact_name_tel1.Equals("")) txt1 += "เบอร์ " + addr.contact_name_tel1 + Environment.NewLine;
            txtConYCop3TimeOpen.Value = txt1;
            txtConYCop3TimeOpenOver.Value = addr.time_open_close_over_time + "[" + addr.rate_over_time + "] ชื่อผู้ติดต่อ2 " + addr.contact_name2 + " เบอร์ " + addr.contact_name_tel2;

        }
        private void setKeyUpF2ConYCop4()
        {
            Point pp = txtConYCop4.Location;
            pp.Y = pp.Y + 150;
            pp.X = pp.X + 280;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.ContainerYard, pp);
            frm.ShowDialog(this);
            setKeyUpF2ConYCop41(xC.sConY, xC.sAddr);
        }
        private void setKeyUpF2ConYCop41(Customer conY, Address addr)
        {
            String txt = "", txt1 = "", addrname = "";
            txt = conY.taddr1 + Environment.NewLine;
            if (!conY.taddr2.Equals("")) txt += conY.taddr2 + Environment.NewLine;
            if (!conY.taddr3.Equals("")) txt += conY.taddr3 + Environment.NewLine;
            if (!conY.taddr4.Equals("")) txt += conY.taddr4 + Environment.NewLine;
            if (!conY.cust_code.Equals("")) txt += conY.cust_code + Environment.NewLine;
            if (!conY.remark.Equals("")) txt += conY.remark + Environment.NewLine;
            if (!conY.tele.Equals("")) txt += conY.tele + Environment.NewLine;
            //if (!conY.t.Equals("")) txt += conY.tele + Environment.NewLine;
            txtConYCop4.Value = conY.cust_name_t;
            txtConYCop4Addr.Value = txt;
            cony1id = xC.sConY.cust_id;

            if (addr == null) return;

            addrname = addr.address_name.Equals("") ? "ชื่อลานคืนตู้ ไม่ได้ระบุ" : addr.address_name;
            if (!addrname.Equals("")) txt1 = addrname + Environment.NewLine;
            if (!addr.time_open_close.Equals("")) txt1 += "เวลาเปิด-ปิด " + addr.time_open_close + Environment.NewLine;
            if (!addr.contact_name1.Equals("")) txt1 += "ชื่อผู้ติดต่อ1 " + addr.contact_name1 + Environment.NewLine;
            if (!addr.contact_name_tel1.Equals("")) txt1 += "เบอร์ " + addr.contact_name_tel1 + Environment.NewLine;
            txtConYCop4TimeOpen.Value = txt1;
            txtConYCop4TimeOpenOver.Value = addr.time_open_close_over_time + "[" + addr.rate_over_time + "] ชื่อผู้ติดต่อ2 " + addr.contact_name2 + " เบอร์ " + addr.contact_name_tel2;

        }
        private void setKeyEnterPol()
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
        private void setKeyEnterDeliImp()
        {
            if (txtDeliImporter.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.cusDB.selectImpIdByCodeLike(txtDeliImporter.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sImp = new Customer();
                    xC.sImp = xC.xtDB.cusDB.setCustomer(dt);
                    setKeyUpF2DeliImp1(xC.sImp);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2DeliImp();
                }
            }
        }
        private void setKeyEnterDeliPlaceAddr()
        {
            if (txtDeliPlaceAddr.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.addrDB.selectByCodeLike(txtDeliPlaceAddr.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sAddr = new Address();
                    xC.sAddr = xC.xtDB.addrDB.setAddress(dt);
                    setKeyUpF2DeliPlaceAddr1(xC.sAddr);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2DeliPlaceAddr();
                }
            }
        }
        private void setKeyEnterDeliContainerYard()
        {
            if (txtDeliContainYardNameT.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.addrDB.selectByCodeLike(txtDeliContainYardNameT.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sAddr = new Address();
                    xC.sAddr = xC.xtDB.addrDB.setAddress(dt);
                    setKeyUpF2DeliContainerYard1(xC.sAddr);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2DeliContainerYard();
                }
            }
        }
        private void setKeyEnterConY1()
        {
            if (txtConYCop1.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.cusDB.selectByCodeLike(txtConYCop1.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sConY = new Customer();
                    xC.sConY = xC.xtDB.cusDB.setCustomer(dt);
                    setKeyUpF2ConYCop11(xC.sConY, null);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2ConYCop1();
                }
            }
        }
        private void setKeyEnterConY2()
        {
            if (txtConYCop2.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.cusDB.selectByCodeLike(txtConYCop2.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sConY = new Customer();
                    xC.sConY = xC.xtDB.cusDB.setCustomer(dt);
                    setKeyUpF2ConYCop21(xC.sConY, null);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2ConYCop2();
                }
            }
        }
        private void setKeyEnterConY3()
        {
            if (txtConYCop2.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.cusDB.selectByCodeLike(txtConYCop3.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sConY = new Customer();
                    xC.sConY = xC.xtDB.cusDB.setCustomer(dt);
                    setKeyUpF2ConYCop31(xC.sConY, null);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2ConYCop3();
                }
            }
        }
        private void setKeyEnterConY4()
        {
            if (txtConYCop2.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.xtDB.cusDB.selectByCodeLike(txtConYCop4.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sConY = new Customer();
                    xC.sConY = xC.xtDB.cusDB.setCustomer(dt);
                    setKeyUpF2ConYCop41(xC.sConY, null);
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2ConYCop4();
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
                    setKeyUpF2Insr1(xC.sInsr);
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
        private void TxtContain1_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calContainer();
        }
        private void calContainer()
        {
            Decimal contain1 = 0, contain2 = 0, contain3 = 0, contain4 = 0, contain5 = 0, contain6 = 0;
            Decimal.TryParse(txtContain1.Text, out contain1);
            Decimal.TryParse(txtContain2.Text, out contain2);
            Decimal.TryParse(txtContain3.Text, out contain3);
            Decimal.TryParse(txtContain4.Text, out contain4);
            Decimal.TryParse(txtContain5.Text, out contain5);
            Decimal.TryParse(txtContain6.Text, out contain6);
            txtContainTotal.Value = contain1 + contain2 + contain3 + contain4 + contain5 + contain6;
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
                else if (sender.Equals(txtDeliImporter))
                {
                    setKeyUpF2DeliImp();
                }
                else if (sender.Equals(txtDeliTruckCop))
                {
                    setKeyUpF2DeliTrkCop();
                }
                else if (sender.Equals(txtDeliPlaceAddr))
                {
                    setKeyUpF2DeliPlaceAddr();
                }
                else if (sender.Equals(txtDeliContainYardNameT))
                {
                    setKeyUpF2DeliContainerYard();
                }
                else if (sender.Equals(txtConYCop1))
                {
                    setKeyUpF2ConYCop1();
                }
                else if (sender.Equals(txtConYCop2))
                {
                    setKeyUpF2ConYCop2();
                }
                else if (sender.Equals(txtConYCop3))
                {
                    setKeyUpF2ConYCop3();
                }
                else if (sender.Equals(txtConYCop4))
                {
                    setKeyUpF2ConYCop4();
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
                    setKeyEnterPol();
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
                    setKeyEnterInsr();
                }
                else if (sender.Equals(txtDeliImporter))
                {
                    setKeyEnterDeliImp();
                }
                else if (sender.Equals(txtDeliPlaceAddr))
                {
                    setKeyEnterDeliPlaceAddr();
                }
                else if (sender.Equals(txtDeliContainYardNameT))
                {
                    setKeyEnterDeliContainerYard();
                }
                else if (sender.Equals(txtConYCop1))
                {
                    setKeyEnterConY1();
                }
                else if (sender.Equals(txtConYCop2))
                {
                    setKeyEnterConY2();
                }
                else if (sender.Equals(txtConYCop3))
                {
                    setKeyEnterConY3();
                }
                else if (sender.Equals(txtConYCop4))
                {
                    setKeyEnterConY4();
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
            Customer trkCop = xC.xtDB.cusDB.selectByPk1(jbl.deli_truck_cop_id);

            txtID.Value = jim.job_import_id;
            txtBlId.Value = jbl.job_import_bl_id;
            txtJclId.Value = jcl.import_check_list_id;
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
            //xC.setC1Combo(cboDeliPkg, jbl.bl_type);
            if (!jbl.deli_imp_id.Equals(""))
            {
                Customer deliImp = new Customer();
                deliImp = xC.xtDB.cusDB.selectByPk1(jbl.deli_imp_id);
                txtDeliImporter.Value = deliImp.cust_name_t;
                txtDeliImporterAddr.Value = jbl.deli_imp_addr;
            }
            else
            {
                txtDeliImporter.Value = txtImpNameT.Text;
                txtDeliImporterAddr.Value = txtImpAddr.Text;
            }
            if (!jbl.deli_package.Equals(""))
            {
                txtDeliPkg.Value = jbl.deli_package;
                xC.setC1Combo(cboDeliPkg, jbl.deli_unit_package_id);
            }
            else
            {
                txtDeliPkg.Value = txtPkgTotal.Text;
            }
            if (!jbl.deli_gw.Equals(""))
            {
                txtDeliGw.Value = jbl.deli_gw;
                xC.setC1Combo(cboDeliGw, jbl.deli_unit_gw_id);
            }
            else
            {
                txtDeliGw.Value = txtGw.Text;
            }
            if (!jbl.deli_volume.Equals(""))
            {
                txtDeliVolume.Value = jbl.deli_volume;
                xC.setC1Combo(cboDeliVolume, jbl.deli_unit_volume_id);
            }
            else
            {
                txtDeliVolume.Value = txtVolume.Text;
            }
            xC.setC1Combo(cboDeliCarType, jbl.deli_truck_id);
            txtDeliTruckCop.Value = trkCop.cust_name_t;
            if (!jbl.deli_place_addr_name_t.Equals(""))
            {
                txtDeliPlaceAddr.Value = jbl.deli_place_addr_name_t;
            }
            else
            {
                txtDeliPlaceAddr.Value = "";
            }
            if (!jbl.deli_yard_addr_name_t.Equals(""))
            {
                txtDeliContainYardNameT.Value = jbl.deli_yard_addr_name_t;
            }
            else
            {
                txtDeliContainYardNameT.Value = "";
            }
            calContainer();
            setGrfJdc();

            Customer conY = new Customer();
            if (!jim.container_yard1_id.Equals(""))
            {
                conY = xC.xtDB.cusDB.selectByPk1(jim.container_yard1_id);
                setKeyUpF2ConYCop11(conY, null);
                txtConYCop1Addr.Value = jim.container_yard1_addr;
                txtConYCop1TimeOpen.Value = jim.time_open_close1;
                txtConYCop1TimeOpenOver.Value = jim.time_open_close_over_time1;
                chkConY1Tax.Checked = jim.status_container_yard1_tax.Equals("1") ? true : false;
            }
            if (!jim.container_yard2_id.Equals(""))
            {
                conY = xC.xtDB.cusDB.selectByPk1(jim.container_yard2_id);
                setKeyUpF2ConYCop11(conY, null);
                txtConYCop2Addr.Value = jim.container_yard2_addr;
                txtConYCop2TimeOpen.Value = jim.time_open_close2;
                txtConYCop2TimeOpenOver.Value = jim.time_open_close_over_time2;
                chkConY2Tax.Checked = jim.status_container_yard2_tax.Equals("1") ? true : false;
            }
            if (!jim.container_yard3_id.Equals(""))
            {
                conY = xC.xtDB.cusDB.selectByPk1(jim.container_yard3_id);
                setKeyUpF2ConYCop11(conY, null);
                txtConYCop3Addr.Value = jim.container_yard3_addr;
                txtConYCop3TimeOpen.Value = jim.time_open_close3;
                txtConYCop3TimeOpenOver.Value = jim.time_open_close_over_time3;
                chkConY3Tax.Checked = jim.status_container_yard3_tax.Equals("1") ? true : false;
            }
            if (!jim.container_yard4_id.Equals(""))
            {
                conY = xC.xtDB.cusDB.selectByPk1(jim.container_yard4_id);
                setKeyUpF2ConYCop11(conY, null);
                txtConYCop4Addr.Value = jim.container_yard4_addr;
                txtConYCop4TimeOpen.Value = jim.time_open_close4;
                txtConYCop4TimeOpenOver.Value = jim.time_open_close_over_time4;
                chkConY4Tax.Checked = jim.status_container_yard4_tax.Equals("1") ? true : false;
            }
            setGrfExpnD(txtID.Text);
        }
        private void setControlJcl()
        {
            jcl = xC.xtDB.jclDB.selectByJobId(xC.jobID);

            chkJclOriginal.Checked = jcl.status_original.Equals("2") ? true : false;
            chkJclCopy.Checked = jcl.status_original.Equals("1") ? true : false;
            txtJclDate.Value = jcl.check_list_date;

            xC.setC1Combo(cboJclTypeofBl, jcl.type_of_bl);
            txtEmailDo.Value = jcl.email_do;//
            xC.setC1Combo(cboJclPrivi1, jcl.type_of_bl);
            xC.setC1Combo(cboJclPrivi2, jcl.type_of_bl);
            xC.setC1Combo(cboJclDocAuthen1, jcl.type_of_bl);
            xC.setC1Combo(cboJclDocAuthen2, jcl.type_of_bl);
            xC.setC1Combo(cboJclDocAuthen3, jcl.type_of_bl);
            txtJclPrivi1Date.Value = jcl.email_do;
            txtJclPrivi2Date.Value = jcl.email_do;
            txtJclDocAuthen1.Value = jcl.email_do;
            txtJclDocAuthen2.Value = jcl.email_do;
            txtJclDocAuthen3.Value = jcl.email_do;
            txtJclPrivi1Desc.Value = jcl.email_do;
            txtJclPrivi2Desc.Value = jcl.email_do;

            txtJclEnterBl.Value = jcl.email_do;
            txtInsurAtten.Value = jcl.email_do;
            txtEmailDo1.Value = jcl.email_do;
            txtEmailDo1Date.Value = jcl.email_do;
            txtDoDateSend.Value = jcl.email_do;
            txtDoDateReceive.Value = jcl.email_do;
            txtTaxDateSend.Value = jcl.email_do;
            txtTaxDateReceive.Value = jcl.email_do;
            txtExp1DateSend.Value = jcl.email_do;
            txtExp1DateReceive.Value = jcl.email_do;
            txtExp2DateSend.Value = jcl.email_do;
            txtExp2DateReceive.Value = jcl.email_do;
            txtReceiptDate.Value = jcl.email_do;
            txtReceiptCopyDate.Value = jcl.email_do;
            txtAcceptDate.Value = jcl.email_do;
            txtAdvanceBillingDate.Value = jcl.email_do;
            txtApproveDate.Value = jcl.email_do;
            txtParent1.Value = jcl.email_do;
            //txtDoDateSend1.Value = jcl.email_do;
        }
        private void setControlJce()
        {
            jce = xC.xtDB.jceDB.selectByJobId(xC.jobID);

            chkJceNoOpenGoods.Checked = jce.status_open_goods.Equals("2") ? true : false;
            chkJceOpenGoods.Checked = jce.status_open_goods.Equals("1") ? true : false;
            txtJceQtyOpenGoods.Value = jce.qty_open_goods;
            txtJceNumOpenGoods.Value = jce.number_open_goods;
            chkJceLayoutGood.Checked = jce.status_layout_goods.Equals("2") ? true : false;
            chkJcelayoutBad.Checked = jce.status_layout_goods.Equals("1") ? true : false;
            txtJceNumLayoutBad.Value = jce.number_bad_goods;
            txtJceBadGoodsDesc.Value = jce.bad_goods_desc;
            txtJceAttendCorrupt.Value = jce.attend_corrupt;
            chkJceCorruptGoodsNo.Checked = jce.status_corrupt_goods.Equals("1") ? true : false;
            chkJceCorruptGoodsYes.Checked = jce.status_corrupt_goods.Equals("3") ? true : false;
            txtJceDmcNo.Value = jce.dmc_no;
            txtJceDmcDate.Value = jce.dmc_date;
            txtJceCustomDate.Value = jce.custom_date;
            txtJceTransportDate.Value = jce.transport_date;

        }
        private Boolean setJobImportContainYard()
        {
            Boolean chk = false;
            
            Customer cony = new Customer();
            
            jConY.job_import_id = txtID.Text;
            jConY.container_yard1_id = cony1id;
            jConY.container_yard2_id = cony2id;
            jConY.container_yard3_id = cony3id;
            jConY.container_yard4_id = cony4id;
            jConY.container_yard5_id = "";
            jConY.container_yard1_addr = txtConYCop1Addr.Text;
            jConY.container_yard2_addr = txtConYCop2Addr.Text;
            jConY.container_yard3_addr = txtConYCop3Addr.Text;
            jConY.container_yard4_addr = txtConYCop4Addr.Text;
            jConY.container_yard5_addr = "";
            jConY.time_open_close1 = txtConYCop1TimeOpen.Text;
            jConY.time_open_close2 = txtConYCop2TimeOpen.Text;
            jConY.time_open_close3 = txtConYCop3TimeOpen.Text;
            jConY.time_open_close4 = txtConYCop4TimeOpen.Text;
            jConY.time_open_close5 = "";
            jConY.time_open_close_over_time1 = txtConYCop1TimeOpenOver.Text;
            jConY.time_open_close_over_time2 = txtConYCop2TimeOpenOver.Text;
            jConY.time_open_close_over_time3 = txtConYCop3TimeOpenOver.Text;
            jConY.time_open_close_over_time4 = txtConYCop4TimeOpenOver.Text;
            jConY.time_open_close_over_time5 = "";
            jConY.status_container_yard1_tax = chkConY1Tax.Checked ? "1" : "0";
            jConY.status_container_yard2_tax = chkConY2Tax.Checked ? "1" : "0";
            jConY.status_container_yard3_tax = chkConY3Tax.Checked ? "1" : "0";
            jConY.status_container_yard4_tax = chkConY4Tax.Checked ? "1" : "0";

            return chk;
        }
        private Boolean setJobImportCheckList()
        {
            Boolean chk = false;
            jcl = new JobImportCheckList();
            jcl.check_list_date = txtJclId.Text;
            jcl.job_import_id = txtID.Text;
            jcl.status_original = chkJclOriginal.Checked ? "2" : "1";
            jcl.check_list_date = xC.datetoDB(txtJclDate.Text);
            jcl.type_of_bl = cboJclTypeofBl.SelectedItem != null ? ((ComboBoxItem)(cboJclTypeofBl.SelectedItem)).Value : "";
            jcl.email_do = txtEmailDo.Text;
            jcl.privi1_id = cboJclPrivi1.SelectedItem != null ? ((ComboBoxItem)(cboJclPrivi1.SelectedItem)).Value : "";
            jcl.privi2_id = cboJclPrivi2.SelectedItem != null ? ((ComboBoxItem)(cboJclPrivi2.SelectedItem)).Value : "";
            jcl.privi1_date = xC.datetoDB(txtJclPrivi1Date.Text); ;
            jcl.privi2_date = xC.datetoDB(txtJclPrivi2Date.Text); ;
            jcl.privi1_desc = txtJclPrivi1Desc.Text;
            jcl.privi2_desc = txtJclPrivi2Desc.Text;
            jcl.doc_authen1_id = cboJclDocAuthen1.SelectedItem != null ? ((ComboBoxItem)(cboJclDocAuthen1.SelectedItem)).Value : "";
            jcl.doc_authen2_id = cboJclDocAuthen2.SelectedItem != null ? ((ComboBoxItem)(cboJclDocAuthen2.SelectedItem)).Value : "";
            jcl.doc_authen3_id = cboJclDocAuthen3.SelectedItem != null ? ((ComboBoxItem)(cboJclDocAuthen3.SelectedItem)).Value : "";
            jcl.doc_authen1_date = xC.datetoDB(txtJclDocAuthen1.Text);
            jcl.doc_authen2_date = xC.datetoDB(txtJclDocAuthen2.Text); ;
            jcl.doc_authen3_date = xC.datetoDB(txtJclDocAuthen3.Text); ;
            jcl.enter_bl = xC.datetoDB(txtJclEnterBl.Text);
            jcl.insurance_atten = txtInsurAtten.Text;
            jcl.email_do1 = txtEmailDo1.Text;
            jcl.email_do1_date = xC.datetoDB(txtEmailDo1Date.Text);
            jcl.do_date_send = xC.datetoDB(txtDoDateSend.Text);
            jcl.do_date_receive = xC.datetoDB(txtDoDateReceive.Text);
            jcl.tax_date_send = xC.datetoDB(txtTaxDateSend.Text);
            jcl.tax_date_receive = xC.datetoDB(txtTaxDateReceive.Text);
            jcl.exp1_date_send = xC.datetoDB(txtExp1DateSend.Text);
            jcl.exp1_date_receive = xC.datetoDB(txtExp1DateReceive.Text);
            jcl.exp2_date_send = xC.datetoDB(txtExp2DateSend.Text);
            jcl.exp2_date_receive = xC.datetoDB(txtExp2DateReceive.Text);
            jcl.receipt_date = xC.datetoDB(txtReceiptDate.Text);
            jcl.receipt_copy_date = xC.datetoDB(txtReceiptCopyDate.Text);
            jcl.accept_tender = xC.datetoDB(txtAcceptDate.Text);
            jcl.advance_billing = xC.datetoDB(txtAdvanceBillingDate.Text);
            jcl.approve_date = xC.datetoDB(txtApproveDate.Text);
            jcl.parent1 = txtParent1.Text;
            jcl.date_create = "";
            jcl.date_modi = "";
            jcl.date_cancel = "";
            jcl.user_create = "";
            jcl.user_modi = "";
            jcl.user_cancel = "";
            jcl.remark = "";
            jcl.active = "1";

            return chk;
        }
        private Boolean setJobImportCheckExam()
        {
            Boolean chk = false;
            jce = new JobImportCheckExam();
            jce.job_import_check_exam_id = txtJceId.Text;
            jce.job_import_id = txtID.Text;
            jce.status_open_goods = chkJceOpenGoods.Checked ? "1" : "0";
            jce.qty_open_goods = txtJceQtyOpenGoods.Text;
            jce.number_open_goods = txtJceNumOpenGoods.Text;
            jce.status_layout_goods = chkJcelayoutBad.Checked ? "1" : "2";
            jce.qty_bad_goods = txtJceQtyLayoutBad.Text;
            jce.number_bad_goods = txtJceNumLayoutBad.Text;
            jce.bad_goods_desc = txtJceBadGoodsDesc.Text;
            jce.attend_corrupt = txtJceAttendCorrupt.Text;
            jce.status_corrupt_goods = chkJceCorruptGoodsYes.Checked ? "3" : "1";
            jce.dmc_no = txtJceDmcNo.Text;
            jce.dmc_date = xC.datetoDB(txtJceDmcDate.Text);
            jce.date_create = "";
            jce.date_modi = "";
            jce.date_cancel = "";
            jce.user_create = "";
            jce.user_modi = "";
            jce.user_cancel = "";
            jce.remark = "";
            jce.active = "1";
            jce.sort1 = "";
            jce.transport_date = xC.datetoDB(txtJceTransportDate.Text);
            jce.custom_date = xC.datetoDB(txtJceCustomDate.Text);

            return chk;
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
                Microsoft.Office.Interop.Outlook.NameSpace nameSpace = app.GetNamespace("MAPI");
                nameSpace.Logon("eploentham@xtrim-logistics.com", "Ekartc2c5", Missing.Value, Missing.Value);
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
