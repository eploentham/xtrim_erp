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
using Xtrim_ERP.Properties;

namespace Xtrim_ERP.gui
{
    public partial class FrmJobImpNew3 : Form
    {
        XtrimControl xC;
        JobImport jim;
        Font fEdit, fEditB;
        Color bg, fc, cgrfOld;
        Font ff, ffB;
        C1FlexGrid grfMarsk, grfPkg, grfGw, grfContain, grfRemark;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String cusId = "", impId="", fwdId="", polId="", ptiId="", stfId="", cstId="";

        int colMarskId = 1, colMarskDesc = 2;
        int colRemarkId = 1, colRemarkDesc = 2;
        int colContainId = 1, colContainQty = 2, colContainContainId = 3;
        int colGwId = 1, colGwQty = 2, colGwGwId = 3;
        int colPKGId = 1, colPKGQty = 2, colPKGPkgId = 3;

        public FrmJobImpNew3(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            jim = new JobImport();

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            theme1.SetTheme(tC2, "VS2013Light");
            btnJobSearch.Click += BtnJobSearch_Click;
            btnSave.Click += BtnSave_Click;
            txtCusNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtImpNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtFwdNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtPolNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtPtiNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtConsignmnt.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtStaffCS.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);
            txtPvlNameT.KeyUp += new KeyEventHandler(txtCusCode_KeyUp);

            xC.setCboTransMode(cboTransMode);
            xC.setCboTaxMethod(cboTaxMethod);
            xC.xtDB.ittDB.setCboImporterType(cboItt);
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
            xC.xtDB.utpDB.setC1CboUtp(cboUtp1, "");

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
        
        private void initGrfMarsk()
        {
            grfMarsk = new C1FlexGrid();
            grfMarsk.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();

            grfMarsk.Cols[colMarskId].Editor = txt;
            grfMarsk.Cols[colMarskDesc].Editor = txt;
            grfMarsk.Cols[colMarskDesc].Caption = "marsk";

            gBMarsk.Controls.Add(grfMarsk);
            grfMarsk.Rows.Count = 2;
            grfMarsk.Cols.Count = 3;
            grfMarsk.Cols[colMarskDesc].Width = 200;
            grfMarsk.Cols[colMarskId].Visible = false;

            grfMarsk.CellChanged += GrfMarsk_CellChanged;

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
            grfMarsk.Rows.Count = (grfMarsk.Row == grfMarsk.Rows.Count - 1) ? (grfMarsk.Rows.Count = grfMarsk.Rows.Count + 1) : grfMarsk.Rows.Count;
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
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.DeleteTable_small;
                }
                //setGrdView();
                this.Dispose();
            }
        }
        private void setKeyUpF2Cus()
        {
            Point pp = txtCusNameT.Location;
            pp.Y = pp.Y + 120 + 20;
            pp.X = pp.X - 20 + groupBox1.Left;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Customer, pp);
            frm.ShowDialog(this);
            setKeyUpF2Cus1();
        }
        private void setKeyUpF2Cus1()
        {
            txtCusAddr.Value = xC.sCus.taddr1 + Environment.NewLine + xC.sCus.taddr2 + Environment.NewLine + xC.sCus.taddr3 + Environment.NewLine + xC.sCus.taddr4 + Environment.NewLine + xC.sCus.cust_code + Environment.NewLine + xC.sCus.remark;
            txtCusNameT.Value = xC.sCus.cust_name_t;
            txtCusContactNameT.Value = xC.sCus.contact_name1 + " " + xC.sCus.contact_name1_tel;
            cusId = xC.sCus.cust_id;
        }
        private void setKeyUpF2Imp()
        {
            Point pp = txtImpNameT.Location;
            pp.Y = pp.Y + 120 + 20;
            pp.X = pp.X - 20 + groupBox2.Left;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Importer, pp);
            frm.ShowDialog(this);
            setKeyUpF2Imp1();
        }
        private void setKeyUpF2Imp1()
        {
            txtImpAddr.Value = xC.sImp.taddr1 + Environment.NewLine + xC.sImp.taddr2 + Environment.NewLine + xC.sImp.taddr3 + Environment.NewLine + xC.sImp.taddr4 + Environment.NewLine + xC.sImp.cust_code + Environment.NewLine + xC.sImp.remark;
            txtImpNameT.Value = xC.sImp.cust_name_t;
            txtImpContactNameT.Value = xC.sImp.contact_name1 + " " + xC.sImp.contact_name1_tel;
            impId = xC.sImp.cust_id;
        }
        private void setKeyUpF2Fwd()
        {
            Point pp = txtFwdNameT.Location;
            pp.Y = pp.Y + 120;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Forwarder, pp);
            frm.ShowDialog(this);
            setKeyUpF2Fwd1();
        }
        private void setKeyUpF2Fwd1()
        {
            txtImpAddr.Value = xC.sImp.taddr1 + Environment.NewLine + xC.sImp.taddr2 + Environment.NewLine + xC.sImp.taddr3 + Environment.NewLine + xC.sImp.taddr4 + Environment.NewLine + xC.sImp.cust_code + Environment.NewLine + xC.sImp.remark;
            txtImpNameT.Value = xC.sImp.cust_name_t;
            txtImpContactNameT.Value = xC.sImp.contact_name1 + " " + xC.sImp.contact_name1_tel;
            fwdId = xC.sFwd.cust_id;
        }
        private void setKeyUpF2Pol()
        {
            Point pp = txtPolNameT.Location;
            pp.Y = pp.Y + 120;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.PortOfLoading, pp);
            frm.ShowDialog(this);
            setKeyUpF2Pol1();
        }
        private void setKeyUpF2Pol1()
        {
            txtPolNameT.Value = xC.sPol.port_of_loading_t;
            txtCntryCode.Value = xC.sPol.cntrycode;
            polId = xC.sPol.port_of_loading_id;
        }
        private void setKeyUpF2Pti()
        {
            Point pp = txtPtiNameT.Location;
            pp.Y = pp.Y + 120;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.PortOfLoading, pp);
            frm.ShowDialog(this);
            setKeyUpF2Pti1();
        }
        private void setKeyUpF2Pti1()
        {
            txtPtiNameT.Value = xC.sPol.port_of_loading_t;
            ptiId = xC.sPol.port_of_loading_id;
        }
        private void setKeyUpF2Cot()
        {
            Point pp = txtConsignmnt.Location;
            pp.Y = pp.Y + 120;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Consignmnt, pp);
            frm.ShowDialog(this);
            setKeyUpF2Cot1();
        }
        private void setKeyUpF2Cot1()
        {
            txtConsignmnt.Value = xC.sCot.cou_name;
            cstId = xC.sCot.cou_id;
        }
        private void setKeyUpF2StfCS()
        {
            Point pp = txtStaffCS.Location;
            pp.Y = pp.Y + 120;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Staff, pp);
            frm.ShowDialog(this);
            setKeyUpF2StfCS1();
        }
        private void setKeyUpF2StfCS1()
        {
            txtStaffCS.Value = xC.sStf.staff_fname_t + " " + xC.sStf.staff_lname_t;
            stfId = xC.sStf.staff_id;
        }
        private void setKeyUpF2Pvl()
        {
            Point pp = txtPvlNameT.Location;
            pp.Y = pp.Y + 120;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Privilege, pp);
            frm.ShowDialog(this);
            setKeyUpF2Pvl1();
        }
        private void setKeyUpF2Pvl1()
        {
            txtPvlNameT.Value = xC.sPvl.desc1;
            stfId = xC.sPvl.priv_id;
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
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (sender.Equals(txtCusNameT))
                {
                    if (txtCusNameT.Text.Length >= 2)
                    {
                        DataTable dt = new DataTable();
                        dt = xC.xtDB.cusDB.selectCusByCodeLike(txtCusNameT.Text);
                        if (dt.Rows.Count == 1)
                        {
                            xC.sCus = new Customer();
                            xC.sCus = xC.xtDB.cusDB.setCustomer(dt);
                            setKeyUpF2Cus1();
                        }
                        else if (dt.Rows.Count > 1)
                        {
                            setKeyUpF2Cus();
                        }
                        //MessageBox.Show("1111", "11");
                    }
                }
                else if (sender.Equals(txtImpNameT))
                {
                    if (txtImpNameT.Text.Length >= 2)
                    {
                        DataTable dt = new DataTable();
                        dt = xC.xtDB.cusDB.selectImpIdByCodeLike(txtImpNameT.Text);
                        if (dt.Rows.Count == 1)
                        {
                            xC.sImp = new Customer();
                            xC.sImp = xC.xtDB.cusDB.setCustomer(dt);
                            setKeyUpF2Imp1();
                        }
                        else if (dt.Rows.Count > 1)
                        {
                            setKeyUpF2Imp();
                        }
                    }
                }
                else if (sender.Equals(txtFwdNameT))
                {
                    if (txtFwdNameT.Text.Length >= 2)
                    {
                        DataTable dt = new DataTable();
                        dt = xC.xtDB.cusDB.selectFwsIdByCodeLike(txtFwdNameT.Text);
                        if (dt.Rows.Count == 1)
                        {
                            xC.sFwd = new Customer();
                            xC.sFwd = xC.xtDB.cusDB.setCustomer(dt);
                            setKeyUpF2Fwd1();
                        }
                        else if (dt.Rows.Count > 1)
                        {
                            setKeyUpF2Fwd();
                        }
                    }
                }
                else if (sender.Equals(txtStaffCS))
                {
                    if (txtStaffCS.Text.Length >= 2)
                    {
                        DataTable dt = new DataTable();
                        dt = xC.xtDB.stfDB.selectCSByCodeLike(txtStaffCS.Text);
                        if (dt.Rows.Count == 1)
                        {
                            xC.sStf = new Staff();
                            xC.sStf = xC.xtDB.stfDB.setStaff(dt);
                            setKeyUpF2StfCS1();
                        }
                        else if (dt.Rows.Count > 1)
                        {
                            setKeyUpF2StfCS();
                        }
                    }
                }
                else if (sender.Equals(txtConsignmnt))
                {
                    if (txtConsignmnt.Text.Length >= 2)
                    {
                        DataTable dt = new DataTable();
                        dt = xC.xtDB.cotDB.selectByCodeLike(txtConsignmnt.Text);
                        if (dt.Rows.Count == 1)
                        {
                            xC.sCot = new Country();
                            xC.sCot = xC.xtDB.cotDB.setCountry(dt);
                            setKeyUpF2Cot1();
                        }
                        else if (dt.Rows.Count > 1)
                        {
                            setKeyUpF2Cot();
                        }
                    }
                }
            }
        }

        private void setJobImport()
        {
            jim = new JobImport();
            jim.job_import_id = "";
            jim.job_import_code = txtJobCode.Text;
            //jim.job_import_date = ((DateTime)txtImpDate.Value).ToString("yyyy-MM-dd");

            jim.cust_id = cusId;
            jim.imp_id = impId;
            jim.transport_mode = ((ComboBoxItem)(cboTransMode.SelectedItem)).Value;
            jim.staff_id = stfId;
            jim.entry_type = "";
            jim.privi_id = polId;
            jim.ref_1 = txtRef1.Text;
            jim.ref_2 = txtRef2.Text;
            jim.ref_3 = txtRef3.Text;
            jim.ref_4 = txtRef4.Text;
            jim.ref_5 = txtRef5.Text;
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
            jim.remark = "";
            jim.remark1 = "";
            jim.remark2 = "";
            jim.jobno = txtJobNo.Text;
            jim.job_date = "";
            jim.imp_date = "";
            jim.bl = "";

        }
        private void FrmJobImpNew3_Load(object sender, EventArgs e)
        {

        }
    }
}
