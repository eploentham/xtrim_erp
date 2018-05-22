using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
    public partial class FrmCustomer1 : Form
    {
        Customer cus;
        XtrimControl xC;
        //FpSpread grdView;
        C1FlexGrid grfCus, grfAddr, grfCont, grfRmk, grfTax;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        
        int colno=0, colID = 1, colCode = 2, colNameT = 3, colAddr = 4, coltele=5, colemail=6, colRemark = 7, colRemark2 = 8, colcontact1=9, colcontact2=10;
        int colCnt = 8;
        int colAddrno = 0, colAddrID = 1, colAddrName = 2, colAddrLine1=3, colAddrLine2=4, colAddrLine3=5, colAddrline4=6, colAddrEmail=7, colAddrEmail2=8;
        int colAddrTele = 9, colAddrMobile = 10, colAddrRemark = 11, colAddrRemark2 = 12;
        int colContId = 1, colContFNameT = 2, colContLNameT = 3, colContNickName = 4, colContMobile = 5, colContEmail = 6, colContPosName = 7, colContRemark = 8, colContWork = 9;
        int colRmkId = 1, colRmkRemark1 = 2, colRmkRemark2 = 3;
        int colTaxId = 1, colTaxTaxId = 2, colTaxNameT = 3, colTaxNameE=4, colTaxRemark=5;

        Boolean flagNew = false;
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        String userIdVoid = "";
        public FrmCustomer1(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            cus = new Customer();
            bg = txtCusCode.BackColor;
            fc = txtCusCode.ForeColor;
            ff = txtCusCode.Font;
            chkSCus.Checked = true;
            
            //ContextMenu custommenu = new ContextMenu();
            //custommenu.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_void));
            ////custommenu.MenuItems.Add("&ยกเลิก";
            //grdView.ContextMenu = custommenu;
            //setFocusColor();
            //setGrdView();
            ////setFocusColor();
            //setFocus();
            tabPage1.Text = "รายละเอียด";
            tabPage2.Text = "สถานที่ติดต่อ (ที่อยู่)";
            tabPage3.Text = "ชื่อผู้ติดต่อ";
            tabPage4.Text = "หมายเหตุ";
            tabPage5.Text = "ข้อมูลจ่ายเช็ค&หักภาษี ณ ที่จ่าย";
            initGrfCusH();
            initGrfAddrH();
            initGrfContH();
            initGrfRmkH();
            initGrfTaxH();
            setGrfCusH();
            setGrfAddrH();
            btnVoid.Hide();
            //btnAddrVoid.Hide();
            setControlNew();
            setFocusColor();
            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(txtCusCode, theme1.Theme);
            bg = txtCusCode.BackColor;
            fc = txtCusCode.ForeColor;
            theme1.SetTheme(sB, "BeigeOne");

            ContextMenu menuAddr = new ContextMenu();
            menuAddr.MenuItems.Add("&เพิ่มใหม่", new EventHandler(ContextMenu_Addr_new));
            menuAddr.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Addr_Edit));
            menuAddr.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Addr_Cancel));
            grfAddr.ContextMenu = menuAddr;

            ContextMenu menuCont = new ContextMenu();
            menuCont.MenuItems.Add("&เพิ่มใหม่", new EventHandler(ContextMenu_Cont_new));
            menuCont.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Cont_Edit));
            menuCont.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Cont_Cancel));
            grfCont.ContextMenu = menuCont;

            ContextMenu menuRmk = new ContextMenu();
            menuRmk.MenuItems.Add("&เพิ่มใหม่", new EventHandler(ContextMenu_Rmk_new));
            menuRmk.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Rmk_Edit));
            menuRmk.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Rmk_Cancel));
            grfRmk.ContextMenu = menuRmk;

            ContextMenu menuTax = new ContextMenu();
            menuTax.MenuItems.Add("&เพิ่มใหม่", new EventHandler(ContextMenu_Tax_new));
            menuTax.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Tax_Edit));
            menuTax.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Tax_Cancel));
            grfTax.ContextMenu = menuTax;

            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;

            //theme1.SetTheme(sB1, "BeigeOne");
        }
        private void ContextMenu_Addr_new(object sender, System.EventArgs e)
        {
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่เลือก ลูกค้า", "");
                return;
            }
            xC.addrID = "";
            xC.cusID = txtID.Text;
            FrmCusAddr frm = new FrmCusAddr(xC);
            frm.ShowDialog(this);
            setGrfAddrH(txtID.Text);
        }
        private void ContextMenu_Addr_Edit(object sender, System.EventArgs e)
        {
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่เลือก ลูกค้า", "");
                return;
            }
            xC.addrID = grfAddr[grfAddr.Row, colAddrID].ToString();
            xC.cusID = txtID.Text;
            FrmCusAddr frm = new FrmCusAddr(xC);
            frm.ShowDialog(this);
            setGrfAddrH(txtID.Text);
        }
        private void ContextMenu_Addr_Cancel(object sender, System.EventArgs e)
        {

        }
        private void ContextMenu_Cont_new(object sender, System.EventArgs e)
        {
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่เลือก ลูกค้า", "");
                return;
            }
            xC.contID = "";
            xC.cusID = txtID.Text;
            FrmContactAdd frm = new FrmContactAdd(xC,"0");
            frm.ShowDialog(this);
        }
        private void ContextMenu_Cont_Edit(object sender, System.EventArgs e)
        {
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่เลือก ลูกค้า", "");
                return;
            }
            if (grfCont[grfCont.Row, colContId] == null) return;
            xC.contID = grfCont[grfCont.Row, colContId].ToString();
            xC.cusID = txtID.Text;
            FrmContactAdd frm = new FrmContactAdd(xC,"0");
            frm.ShowDialog(this);
            setGrfContH(txtID.Text);
        }
        private void ContextMenu_Cont_Cancel(object sender, System.EventArgs e)
        {

        }
        private void ContextMenu_Rmk_new(object sender, System.EventArgs e)
        {
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่เลือก ลูกค้า", "");
                return;
            }
            xC.cusrID = "";
            xC.cusID = txtID.Text;
            FrmCusRemark frm = new FrmCusRemark(xC);
            frm.ShowDialog(this);
            setGrfRmkH(txtID.Text);
        }
        private void ContextMenu_Rmk_Edit(object sender, System.EventArgs e)
        {
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่เลือก ลูกค้า", "");
                return;
            }
            if (grfRmk[grfRmk.Row, colContId] == null) return;
            xC.cusrID = grfRmk[grfRmk.Row, colContId].ToString();
            xC.cusID = txtID.Text;
            FrmCusRemark frm = new FrmCusRemark(xC);
            frm.ShowDialog(this);
            setGrfRmkH(txtID.Text);
        }
        private void ContextMenu_Rmk_Cancel(object sender, System.EventArgs e)
        {

        }
        private void ContextMenu_Tax_new(object sender, System.EventArgs e)
        {
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่เลือก ลูกค้า", "");
                return;
            }
            xC.custID = "";
            xC.cusID = txtID.Text;
            FrmCusTaxInvoice frm = new FrmCusTaxInvoice(xC);
            frm.ShowDialog(this);
            setGrfTaxH(txtID.Text);
        }
        private void ContextMenu_Tax_Edit(object sender, System.EventArgs e)
        {
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่เลือก ลูกค้า", "");
                return;
            }
            if (grfTax[grfTax.Row, colContId] == null) return;
            xC.custID = grfTax[grfTax.Row, colContId].ToString();
            xC.cusID = txtID.Text;
            FrmCusTaxInvoice frm = new FrmCusTaxInvoice(xC);
            frm.ShowDialog(this);
            setGrfTaxH(txtID.Text);
        }
        private void ContextMenu_Tax_Cancel(object sender, System.EventArgs e)
        {

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
        private void setFocusColor()
        {
            this.txtCusCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCusCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCusNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCusNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCusNameE.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCusNameE.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAddrT1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAddrT1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAddrT2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAddrT2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAddrT3.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAddrT3.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAddrT4.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAddrT4.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAddrE1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAddrE1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAddrE2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAddrE2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAddrE3.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAddrE3.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAddrE4.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAddrE4.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTele.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTele.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtFax.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtFax.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEmail.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEmail.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContactTel1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContactTel1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContactTel2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContactTel2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTaxId.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTaxId.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContactName1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContactName1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContactName2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContactName2.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtAddrName.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtAddrName.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtAddrLineT1.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtAddrLineT1.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtAddrLineT2.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtAddrLineT2.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtAddrLineT3.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtAddrLineT3.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtAddrLineT4.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtAddrLineT4.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtAddrLineE1.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtAddrLineE1.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtAddrLineE2.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtAddrLineE2.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtAddrLineE3.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtAddrLineE3.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtAddrLineE4.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtAddrLineE4.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtAddrTele.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtAddrTele.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtAddrFax.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtAddrFax.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtAddrEmail.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtAddrEmail.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtAddrMobile.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtAddrMobile.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtAddrRemark.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtAddrRemark.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtAddrRemark2.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtAddrRemark2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAddrContactName1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAddrContactName1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAddrContactName2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAddrContactName2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAddrContactTel1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAddrContactTel1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAddrContactTel2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAddrContactTel2.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtContactName2.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtContactName2.Enter += new System.EventHandler(this.textBox_Enter);
            
        }
        private void setControlAddrEdit(Boolean flag)
        {
            if (flag)
            {
                //setControlAddrEnable(true);
                btnEdit.Image = Resources.open24;
            }
            else
            {
                //setControlAddrEnable(false);
                btnEdit.Image = Resources.lock24;
            }
        }
        private void setControlEdit(Boolean flag)
        {
            if (flag)
            {
                btnSave.Enabled = true;
                btnNew.Hide();
                btnEdit.Enabled = false;
                btnEdit.Image = Resources.open24;
                setControlEnable(true);
                btnNew.Hide();
                //btnEdit.Show();
            }
            else
            {
                btnSave.Enabled = false;
                btnNew.Hide();
                btnEdit.Enabled = true;
                btnEdit.Image = Resources.lock24;
                setControlEnable(false);
                btnNew.Show();
                //btnEdit.Hide();
            }
            

        }
        private void setControlNew()
        {
            btnSave.Enabled = true;
            btnNew.Show();
            btnEdit.Enabled = false;
            chkVoid.Checked = false;
            txtID.Value = "";
        }
        private void setCusNew()
        {
            txtID.Value = "";
            txtCusCode.Value = "";
            txtCusNameT.Value = "";
            txtCusNameE.Value = "";
            txtAddrT1.Value = "";
            txtAddrT2.Value = "";
            txtAddrT3.Value = "";
            txtAddrT4.Value = "";
            txtAddrE1.Value = "";
            txtAddrE2.Value = "";
            txtAddrE3.Value = "";
            txtAddrE4.Value = "";
            txtTele.Value = "";
            txtFax.Value = "";
            txtEmail.Value = "";
            txtRemark.Value = "";
            txtRemark2.Value = "";
            txtContactName1.Value = "";
            txtContactName2.Value = "";
            txtContactTel1.Value = "";
            txtContactTel2.Value = "";

            chkCus.Checked = false;
            chkImp.Checked = false;
            chkFwd.Checked = false;
            chkExp.Checked = false;
        }
        private void setFocus()
        {
            txtCusCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusNameT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusNameE.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtTaxId.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtRemark.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);

            txtCusCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtCusCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            flagNew = true;
            tabPage2.Hide();
            setCusNew();
            setControlEdit(true);
            chkVoid.Hide();
            //btnNew.Show();
            //btnEdit.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            bg = txtCusCode.BackColor;
            fc = txtCusCode.ForeColor;
            flagEdit = flagEdit ? false : true;
            setControlEnable(flagEdit);
            //setControlEdit(true);
            //btnEdit.Show();
        }

        private void setGrfCusH()
        {
            DataTable dt = new DataTable();
            if (chkSCus.Checked)
            {

            }
            dt = xC.xtDB.cusDB.selectAll2(chkSCus.Checked==true ? "1" : "0", chkSImp.Checked == true ? "1" : "0", chkSExp.Checked == true ? "1" : "0", 
                chkSConsImp.Checked == true ? "1" : "0", chkSConsExp.Checked == true ? "1" : "0", chkSInsr.Checked == true ? "1" : "0", chkSFwd.Checked == true ? "1" : "0", 
                chkSSupp.Checked == true ? "1" : "0");
            //grfCus.Cols.Count = 2;
            //grfCus.Rows.Count = 7;
            grfCus.DataSource = dt;
            grfCus.Cols[colID].Width = 60;
            grfCus.Cols[colCode].Width = 80;
            grfCus.Cols[colNameT].Width = 100;
            grfCus.Cols[colAddr].Width = 100;
            grfCus.Cols[colRemark].Width = 100;
            grfCus.Cols[colRemark2].Width = 100;
            grfCus.Cols[coltele].Width = 100;
            grfCus.Cols[colemail].Width = 100;
            grfCus.Cols[colcontact1].Width = 100;
            grfCus.Cols[colcontact2].Width = 100;
            grfCus.ShowCursor = true;
            grfCus.Cols[colAddr].Caption = "ที่อยู่";
            grfCus.Cols[colID].Caption = "no";
            grfCus.Cols[colCode].Caption = "รหัส";
            grfCus.Cols[colNameT].Caption = "ชื่อบริษัท";
            grfCus.Cols[colRemark].Caption = "หมายเหตุ";
            grfCus.Cols[colRemark2].Caption = "หมายเหตุ2";
            grfCus.Cols[coltele].Caption = "tele";
            grfCus.Cols[colemail].Caption = "email";
            grfCus.Cols[colcontact1].Caption = "ชื่อผู้ติดต่อ";
            grfCus.Cols[colcontact2].Caption = "ชื่อผู้ติดต่อ2";
            grfCus.Cols[colID].Visible = false;
            //grfCus.Col = colCnt;
        }

        private void chkVoid_Click(object sender, EventArgs e)
        {
            if (btnVoid.Visible)
            {
                btnVoid.Hide();
            }
            else
            {
                txtPasswordVoid.Show();
                txtPasswordVoid.Focus();
                stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> กรุณาป้อนรหัสผ่าน", txtPasswordVoid);
            }
        }
        private void TxtPasswordVoid_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                userIdVoid = xC.xtDB.stfDB.selectByPasswordAdmin(txtPasswordVoid.Text.Trim());
                if (userIdVoid.Length > 0)
                {
                    txtPasswordVoid.Hide();
                    btnVoid.Show();
                    stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> รหัสผ่านถูกต้อง", btnVoid);
                }
                else
                {
                    sep.SetError(txtPasswordVoid, "333");
                }
            }
        }
        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการยกเลิก รายการ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String re = xC.xtDB.cusDB.voidCustomer(txtID.Value.ToString());
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    MessageBox.Show("ยกเลิก ข้อมูล เรียบร้อย", "");
                    setGrfCusH();
                    //setGrfAddrH();
                    chkVoid.Checked = false;
                }
            }
        }

        private void chkSCus_Click(object sender, EventArgs e)
        {
            setGrfCusH();
        }

        private void chkSImp_Click(object sender, EventArgs e)
        {
            setGrfCusH();
        }
        
        private void chkSExp_Click(object sender, EventArgs e)
        {
            setGrfCusH();
        }

        private void chkSConsImp_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void btnAddr_Click(object sender, EventArgs e)
        {
            xC.addrID = "";
            xC.cusID = txtID.Text;
            FrmCusAddr frm = new FrmCusAddr(xC);
            frm.ShowDialog(this);
        }

        private void chkSConsImp_Click(object sender, EventArgs e)
        {
            setGrfCusH();
        }

        private void chkSConsExp_Click(object sender, EventArgs e)
        {
            setGrfCusH();
        }

        private void chkSInsr_Click(object sender, EventArgs e)
        {
            setGrfCusH();
        }

        private void chkSFwd_Click(object sender, EventArgs e)
        {
            setGrfCusH();
        }

        private void chkSSupp_Click(object sender, EventArgs e)
        {
            setGrfCusH();
        }

        private void Mac(CellStyleCollection s)
        {
            s.Clear();

            CellStyle cs = s.Normal;
            cs.BackColor = Color.FromArgb(250, 250, 250);
            cs.Border.Width = 0;

            cs = s.Fixed;
            cs.BackgroundImage = GetBitmapResource("Mac_Header.png");
            cs.BackgroundImageLayout = ImageAlignEnum.TileStretch;
            cs.Border.Width = 0;
            cs.Margins = new System.Drawing.Printing.Margins(4, 4, 4, 2);

            cs = s.SelectedColumnHeader;
            cs.MergeWith(s.Fixed);
            cs.BackgroundImage = GetBitmapResource("Mac_HeaderSelected.png");

            s.SelectedRowHeader.MergeWith(cs);

            cs = s.Highlight;
            cs.Clear();
            cs.BackColor = Color.FromArgb(150, Color.LightSteelBlue);

            s.Focus.MergeWith(cs);
        }

        private void setGrfAddrH()
        {
            //grfAddr.DataSource = xC.xtDB.cusDB.dtCus;
            grfAddr.Cols[colAddrName].Width = 100;
            grfAddr.Cols[colAddrLine1].Width = 100;
            //grdFlex.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            grfAddr.Cols[colAddrName].Caption = "ชื่อที่อยู่";
            grfAddr.Cols[colAddrLine1].Caption = "ที่อยู่ 1";
        }
        private void setGrfAddrH(String custId)
        {
            grfAddr.DataSource = xC.xtDB.addrDB.selectByTableId1(custId);
            grfAddr.Cols[colAddrID].Width = 60;
            grfAddr.Cols[colAddrName].Width = 100;
            grfAddr.Cols[colAddrLine1].Width = 100;
            grfAddr.Cols[colAddrLine2].Width = 100;
            grfAddr.Cols[colAddrLine3].Width = 100;
            grfAddr.Cols[colAddrline4].Width = 100;
            grfAddr.Cols[colAddrEmail].Width = 100;
            grfAddr.Cols[colAddrEmail2].Width = 100;
            grfAddr.Cols[colAddrTele].Width = 100;
            grfAddr.Cols[colAddrMobile].Width = 100;
            grfAddr.Cols[colAddrRemark].Width = 100;
            grfAddr.Cols[colAddrRemark2].Width = 100;
            grfAddr.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            grfAddr.Cols[colAddrName].Caption = "ชื่อที่อยู่";
            grfAddr.Cols[colAddrLine1].Caption = "ที่อยู่ 1";
            grfAddr.Cols[colAddrLine2].Caption = "ที่อยู่ 2";
            grfAddr.Cols[colAddrLine3].Caption = "ที่อยู่ 3";
            grfAddr.Cols[colAddrline4].Caption = "ที่อยู่ 4";
            grfAddr.Cols[colAddrEmail].Caption = "email";
            grfAddr.Cols[colAddrEmail2].Caption = "email2";
            grfAddr.Cols[colAddrTele].Caption = "tele";
            grfAddr.Cols[colAddrMobile].Caption = "mobile";
            grfAddr.Cols[colAddrRemark].Caption = "หมายเหตุ";
            grfAddr.Cols[colAddrRemark2].Caption = "หมายเหตุ2";

            grfAddr.Cols[colAddrID].Visible = false;
            //grfAddr1.Cols[colAddrID].Visible = false;
        }
        private void setGrfContH(String custId)
        {
            grfCont.DataSource = xC.xtDB.contDB.selectByCusId(custId);
            grfCont.Cols[colContId].Width = 60;
            grfCont.Cols[colContFNameT].Width = 60;
            grfCont.Cols[colContLNameT].Width = 60;
            grfCont.Cols[colContNickName].Width = 60;
            grfCont.Cols[colContMobile].Width = 60;
            grfCont.Cols[colContEmail].Width = 60;
            grfCont.Cols[colContPosName].Width = 60;
            grfCont.Cols[colContRemark].Width = 60;
            grfCont.Cols[colContWork].Width = 60;

            grfCont.Cols[colContFNameT].Caption = "ชื่อ";
            grfCont.Cols[colContLNameT].Caption = "นามสกุล";
            grfCont.Cols[colContNickName].Caption = "ชื่อเล่น";
            grfCont.Cols[colContMobile].Caption = "มือถือ";
            grfCont.Cols[colContEmail].Caption = "Email";
            grfCont.Cols[colContPosName].Caption = "ตำแหน่ง";
            grfCont.Cols[colContRemark].Caption = "หมายเหตุ";
            grfCont.Cols[colContWork].Caption = "งานที่รับผิดชอบ";

            grfCont.Cols[colContId].Visible = false;
        }
        private void setGrfRmkH(String custId)
        {
            grfRmk.DataSource = xC.xtDB.cusrDB.selectByCusId(custId);
            grfRmk.Cols[colRmkId].Width = 60;
            grfRmk.Cols[colRmkRemark1].Width = 60;
            grfRmk.Cols[colRmkRemark2].Width = 60;            

            grfRmk.Cols[colRmkRemark1].Caption = "หมายเหตุ";
            grfRmk.Cols[colRmkRemark2].Caption = "หมายเหตุ2";
            
            grfRmk.Cols[colRmkId].Visible = false;
        }
        private void setGrfTaxH(String custId)
        {
            grfTax.DataSource = xC.xtDB.custDB.selectByCusId(custId);
            grfTax.Cols[colTaxTaxId].Width = 60;
            grfTax.Cols[colTaxNameT].Width = 60;
            grfTax.Cols[colTaxNameE].Width = 60;
            grfTax.Cols[colTaxRemark].Width = 60;

            grfTax.Cols[colTaxTaxId].Caption = "tax id";
            grfTax.Cols[colTaxNameT].Caption = "ชื่อผู้ออกใบกำกับภาษี ไทย";
            grfTax.Cols[colTaxNameE].Caption = "ชื่อผู้ออกใบกำกับภาษี english";
            grfTax.Cols[colTaxRemark].Caption = "หมายเหตุ";

            grfTax.Cols[colTaxId].Visible = false;
        }
        private void initGrfCusH()
        {
            grfCus = new C1FlexGrid();
            grfCus.Font = fEdit;
            grfCus.Dock = System.Windows.Forms.DockStyle.Fill;
            grfCus.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfCus);

            grfCus.AfterDataRefresh += new System.ComponentModel.ListChangedEventHandler(this.StatusBar_AfterDataRefresh);
            grfCus.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfCus_CellChanged);
            grfCus.LeaveCell += new System.EventHandler(this.grdFlex_LeaveCell);
            grfCus.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfCus_AfterRowColChange);
            //this.grfCus.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfCus_AfterRowColChange);
            //new C1.Win.C1FlexGrid.RangeEventHandler(this.c1FlexGrid1_AfterRowColChange);
            //splitContainer1.Panel1.Controls.Add(this.grfCus);
            panel6.Controls.Add(this.grfCus);
            //grfCus.ShowThemedHeaders = ShowThemedHeadersEnum.None;
            //grfCus.Styles.Clear();
            //Mac(grfCus.Styles);
            //Controls.Add(sB);
            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfCus, theme);
        }
        private void initGrfAddrH()
        {
            grfAddr = new C1FlexGrid();
            grfAddr.Font = fEdit;
            grfAddr.Dock = System.Windows.Forms.DockStyle.Fill;
            grfAddr.Location = new System.Drawing.Point(0, 0);

            //grfAddr.AfterDataRefresh += new System.ComponentModel.ListChangedEventHandler(this.StatusBar_AfterDataRefresh);
            //grfAddr.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdFlex_CellChanged);
            grfAddr.DoubleClick += new System.EventHandler(this.grfAddr_DoubleClick);
            grfAddr.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfAddr_AfterRowColChange);

            panel3.Controls.Add(this.grfAddr);
            //Controls.Add(sB);

            //grfAddr1 = new C1FlexGrid();
            //grfAddr1.Font = fEdit;
            //grfAddr1.Dock = System.Windows.Forms.DockStyle.Fill;
            //grfAddr1.Location = new System.Drawing.Point(0, 0);
            //panel3.Controls.Add(this.grfAddr1);
        }
        private void initGrfContH()
        {
            grfCont = new C1FlexGrid();
            grfCont.Font = fEdit;
            grfCont.Dock = System.Windows.Forms.DockStyle.Fill;
            grfCont.Location = new System.Drawing.Point(0, 0);
            
            grfCont.DoubleClick += new System.EventHandler(this.grfCont_DoubleClick);
            grfCont.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfCont_AfterRowColChange);

            panel4.Controls.Add(this.grfCont);            
        }
        private void initGrfRmkH()
        {
            grfRmk = new C1FlexGrid();
            grfRmk.Font = fEdit;
            grfRmk.Dock = System.Windows.Forms.DockStyle.Fill;
            grfRmk.Location = new System.Drawing.Point(0, 0);

            grfRmk.DoubleClick += new System.EventHandler(this.grfRmk_DoubleClick);
            grfRmk.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfRmk_AfterRowColChange);

            panel9.Controls.Add(this.grfRmk);
        }
        private void initGrfTaxH()
        {
            grfTax = new C1FlexGrid();
            grfTax.Font = fEdit;
            grfTax.Dock = System.Windows.Forms.DockStyle.Fill;
            grfTax.Location = new System.Drawing.Point(0, 0);

            grfTax.DoubleClick += new System.EventHandler(this.grfTax_DoubleClick);
            grfTax.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfTax_AfterRowColChange);

            panel10.Controls.Add(this.grfTax);
        }
        private void grfRmk_DoubleClick(object sender, EventArgs e)
        {

        }
        private void grfCont_DoubleClick(object sender, EventArgs e)
        {

        }
        private void grfAddr_DoubleClick(object sender, EventArgs e)
        {

        }
        private void grfTax_DoubleClick(object sender, EventArgs e)
        {

        }
        //private void setControlAddr(String addrId)
        //{
        //    if (addrId.Equals("")) return;
        //    Address addr = new Address();
        //    addr = xC.xtDB.addrDB.selectByPk1(addrId);
        //    txtAddrId.Value = addr.address_id;
        //    txtAddrName.Value = addr.address_name;
        //    txtAddrLineT1.Value = addr.line_t1;
        //    txtAddrLineT2.Value = addr.line_t2;
        //    txtAddrLineT3.Value = addr.line_t3;
        //    txtAddrLineT4.Value = addr.line_t4;
        //    txtAddrLineE1.Value = addr.line_e1;
        //    txtAddrLineE2.Value = addr.line_e2;
        //    txtAddrLineE3.Value = addr.line_e3;
        //    txtAddrLineE4.Value = addr.line_e4;
        //    txtAddrTele.Value = addr.tele;
        //    txtAddrFax.Value = addr.fax;
        //    txtAddrEmail.Value = addr.email;
        //    txtAddrMobile.Value = addr.mobile;
        //    txtAddrRemark.Value = addr.remark;
        //    txtAddrRemark2.Value = addr.remark;
        //    txtAddrContactName1.Value = addr.contact_name1;
        //    txtAddrContactName2.Value = addr.contact_name2;
        //    txtAddrContactTel1.Value = addr.contact_name_tel1;
        //    txtAddrContactTel2.Value = addr.contact_name_tel2;

        //    txtAddrWeb1.Value = addr.web_site1;
        //    txtAddrWeb2.Value = addr.web_site2;
        //    txtAddrGoogleMap.Value = addr.google_map;
        //    chkAddrDefaultCus.Checked = addr.status_defalut_customer.Equals("1") ? true : false;
        //    txtAddrTableId.Value = addr.table_id;
        //}
        
        private void setControlCus(String cusId)
        {
            if (cusId.Equals("")) return;
            Customer cus = new Customer();
            cus = xC.xtDB.cusDB.selectByPk1(cusId);
            txtID.Value = cus.cust_id;
            txtCusCode.Value = cus.cust_code;
            txtCusNameT.Value = cus.cust_name_t;
            txtCusNameE.Value = cus.cust_name_e;
            txtAddrT1.Value = cus.taddr1;
            txtAddrT2.Value = cus.taddr2;
            txtAddrT3.Value = cus.taddr3;
            txtAddrT4.Value = cus.taddr4;
            txtAddrE1.Value = cus.eaddr1;
            txtAddrE2.Value = cus.eaddr2;
            txtAddrE3.Value = cus.eaddr3;
            txtAddrE4.Value = cus.eaddr4;
            txtTaxId.Value = cus.tax_id;
            txtTele.Value = cus.tele;
            txtFax.Value = cus.fax;
            txtEmail.Value = cus.email;
            txtRemark.Value = cus.remark;
            txtRemark2.Value = cus.remark2;
            txtContactName1.Value = cus.contact_name1;
            txtContactName2.Value = cus.contact_name2;
            txtContactTel1.Value = cus.contact_name1_tel;
            txtContactTel2.Value = cus.contact_name2_tel;
            
            chkCus.Checked = cus.status_cust.Equals("1") ? true : false;
            chkImp.Checked = cus.status_imp.Equals("1") ? true : false;
            chkFwd.Checked = cus.status_fwd.Equals("1") ? true : false;
            chkExp.Checked = cus.status_exp.Equals("1") ? true : false;
            
        }

        private void btnAddrEdit_Click(object sender, EventArgs e)
        {
            //setControlAddrEnable(true);
            setControlAddrEdit(true);
        }
        //private void setAddreNew()
        //{
        //    txtAddrId.Value = "";
        //    txtAddrName.Value = "";
        //    txtAddrLineT1.Value = "";
        //    txtAddrLineT2.Value = "";
        //    txtAddrLineT3.Value = "";
        //    txtAddrLineT4.Value = "";
        //    txtAddrLineE1.Value = "";
        //    txtAddrLineE2.Value = "";
        //    txtAddrLineE3.Value = "";
        //    txtAddrLineE4.Value = "";
        //    txtAddrTele.Value = "";
        //    txtAddrFax.Value = "";
        //    txtAddrEmail.Value = "";
        //    txtAddrMobile.Value = "";
        //    txtAddrRemark.Value = "";
        //    txtAddrRemark2.Value = "";
        //    txtAddrContactName1.Value = "";
        //    txtAddrContactName2.Value = "";
        //    txtAddrContactTel1.Value = "";
        //    txtAddrContactTel2.Value = "";

        //    txtAddrWeb1.Value = "";
        //    txtAddrWeb2.Value = "";
        //    txtAddrGoogleMap.Value = "";
        //    chkAddrDefaultCus.Checked = false;
        //}
        private void btnAddrNew_Click(object sender, EventArgs e)
        {
            //setAddreNew();
            //setControlAddrEnable(true);
        }
        //private void saveAddr()
        //{
        //    Address addr = new Address();
        //    addr.address_id = txtAddrId.Value.ToString().Trim();
        //    addr.address_code = "";
        //    addr.line_t1 = txtAddrLineT1.Value.ToString().Trim();
        //    addr.line_t2 = txtAddrLineT2.Value.ToString().Trim();
        //    addr.line_t3 = txtAddrLineT3.Value.ToString().Trim();
        //    addr.line_t4 = txtAddrLineT4.Value.ToString().Trim();
        //    addr.line_e1 = txtAddrLineE1.Value.ToString().Trim();
        //    addr.line_e2 = txtAddrLineE2.Value.ToString().Trim();
        //    addr.line_e3 = txtAddrLineE3.Value.ToString().Trim();
        //    addr.line_e4 = txtAddrLineE4.Value.ToString().Trim();
        //    addr.prov_id = "";
        //    addr.amphur_id = "";
        //    addr.district_id = "";
        //    addr.zipcode = "";
        //    addr.email = txtAddrEmail.Value.ToString().Trim();
        //    addr.email2 = "";
        //    addr.tele = txtAddrTele.Value.ToString().Trim();
        //    addr.mobile = txtAddrMobile.Value.ToString().Trim();
        //    addr.fax = txtAddrFax.Value.ToString().Trim();
        //    addr.remark = txtAddrRemark.Value.ToString().Trim();
        //    addr.address_type_id = "";
        //    addr.table_id = txtAddrTableId.Value.ToString().Trim();
        //    addr.date_create = "";
        //    addr.date_modi = "";
        //    addr.date_cancel = "";
        //    addr.user_create = "";
        //    addr.user_modi = "";
        //    addr.user_cancel = "";
        //    addr.active = "";
        //    addr.address_name = txtAddrName.Value.ToString().Trim();
        //    addr.contact_id = "";
        //    addr.contact_name1 = txtAddrContactName1.Text;
        //    addr.contact_name2 = txtAddrContactName2.Text;
        //    addr.contact_name_tel1 = txtAddrContactTel1.Text;
        //    addr.contact_name_tel2 = txtAddrContactTel2.Text;

        //    addr.web_site1 = txtAddrWeb1.Text;
        //    addr.web_site2 = txtAddrWeb2.Text;
        //    addr.google_map = txtAddrGoogleMap.Text;
        //    addr.status_defalut_customer = chkAddrDefaultCus.Checked ? "1" : "0";
        //    String re = xC.xtDB.addrDB.insertAddress(addr);
        //    int chk = 0;
        //    if (int.TryParse(re, out chk))
        //    {
        //        btnAddrSave.Image = Resources.accept_database24;
        //        sB1.Text = "บันทึกข้อมูล " + cus.cust_code + " " + addr.line_t1 + " เรียบร้อย ";
        //    }
        //}
        private void btnAddrSave_Click(object sender, EventArgs e)
        {
            //saveAddr();
        }
        private void saveCustomer()
        {
            //Customer cus = new Customer();
            cus.cust_id = txtID.Text;
            cus.cust_code = txtCusCode.Text.Trim();
            cus.cust_name_t = txtCusNameT.Text.Trim();
            cus.cust_name_e = txtCusNameE.Text.Trim();
            cus.tax_id = txtTaxId.Text.Trim();

            cus.address_t = "";
            cus.address_e = "";
            cus.addr = "";
            cus.amphur_id = "";
            cus.district_id = "";

            cus.province_id = "";
            cus.zipcode = "";
            cus.sale_id = "";
            cus.sale_name_t = "";
            cus.fax = txtFax.Text;

            cus.tele = txtTele.Text;
            cus.email = txtEmail.Text.Trim();
            cus.tax_id = txtTaxId.Text.Trim();
            cus.remark = txtRemark.Text;
            cus.contact_name1 = txtContactName1.Text.Trim();

            cus.contact_name2 = txtContactName2.Text.Trim();
            cus.contact_name1_tel = txtContactTel1.Text.Trim();
            cus.contact_name2_tel = txtContactTel2.Text.Trim();
            cus.status_company = "1";
            cus.status_vendor = "";

            cus.date_create = "";
            cus.date_modi = "";
            cus.date_cancel = "";
            cus.user_create = "";
            cus.user_modi = "";

            cus.user_cancel = "";
            cus.remark2 = txtRemark2.Text;
            cus.po_due_period = "";
            cus.taddr1 = txtAddrT1.Text.Trim();
            cus.taddr2 = txtAddrT2.Text.Trim();

            cus.taddr3 = txtAddrT3.Value.ToString().Trim();
            cus.taddr4 = txtAddrT4.Value.ToString().Trim();
            cus.eaddr1 = txtAddrE1.Value.ToString().Trim();
            cus.eaddr2 = txtAddrE2.Value.ToString().Trim();
            cus.eaddr3 = txtAddrE3.Value.ToString().Trim();

            cus.eaddr4 = txtAddrE4.Value.ToString().Trim();
            cus.sort1 = "";

            cus.status_cust = chkCus.Checked ? "1" : "0";
            cus.status_exp = chkExp.Checked ? "1" : "0";
            cus.status_fwd = chkFwd.Checked ? "1" : "0";
            cus.status_imp = chkImp.Checked ? "1" : "0";

            String re = xC.xtDB.cusDB.insertCustomer(cus);
            int chk = 0;
            if (int.TryParse(re, out chk))
            {
                if (flagNew)
                {
                    Address addr = new Address();
                    addr.address_id = "";
                    addr.address_code = "";
                    addr.line_t1 = txtAddrT1.Value.ToString().Trim();
                    addr.line_t2 = txtAddrT2.Value.ToString().Trim();
                    addr.line_t3 = txtAddrT3.Value.ToString().Trim();
                    addr.line_t4 = txtAddrT4.Value.ToString().Trim();
                    addr.line_e1 = txtAddrE1.Value.ToString().Trim();
                    addr.line_e2 = txtAddrE2.Value.ToString().Trim();
                    addr.line_e3 = txtAddrE3.Value.ToString().Trim();
                    addr.line_e4 = txtAddrE4.Value.ToString().Trim();
                    addr.prov_id = "";
                    addr.amphur_id = "";
                    addr.district_id = "";
                    addr.zipcode = "";
                    addr.email = txtEmail.Value.ToString().Trim();
                    addr.email2 = "";
                    addr.tele = txtTele.Value.ToString().Trim();
                    addr.mobile = "";
                    addr.fax = "";
                    addr.remark = "";
                    addr.address_type_id = "";
                    addr.table_id = re;
                    addr.date_create = "";
                    addr.date_modi = "";
                    addr.date_cancel = "";
                    addr.user_create = "";
                    addr.user_modi = "";
                    addr.user_cancel = "";
                    addr.active = "";
                    addr.address_name = "";
                    addr.contact_id = "";
                    addr.contact_name1 = txtContactName1.Text;
                    addr.contact_name2 = txtContactName2.Text;
                    addr.contact_name_tel1 = txtContactTel1.Text;
                    addr.contact_name_tel2 = txtContactTel2.Text;

                    addr.web_site1 = "";
                    addr.web_site2 = "";
                    addr.google_map = "";
                    addr.status_defalut_customer = "1";
                    String re1 = xC.xtDB.addrDB.insertAddress(addr);

                }

                btnSave.Image = Resources.accept_database24;
                sB1.Text = "บันทึกข้อมูล " + cus.cust_code + " เรียบร้อย ";
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //saveCustomer();
            //tabPage2.Show();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                saveCustomer();
                //String re = xC.xtDB.cusDB.insertCustomer(cus);
                //int chk = 0;
                //if (int.TryParse(re, out chk))
                //{
                //    btnSave.Image = Resources.accept_database24;
                //}
                //else
                //{
                //    btnSave.Image = Resources.accept_database24;
                //}
                setGrfCusH();
                setControlEnable(false);
                //this.Dispose();
            }
        }

        //private void setControlAddrEnable(Boolean flag)
        //{
        //    txtAddrId.Enabled = flag;
        //    txtAddrName.Enabled = flag;
        //    txtAddrLineT1.Enabled = flag;
        //    txtAddrLineT2.Enabled = flag;
        //    txtAddrLineT3.Enabled = flag;
        //    txtAddrLineT4.Enabled = flag;
        //    txtAddrLineE1.Enabled = flag;
        //    txtAddrLineE2.Enabled = flag;
        //    txtAddrLineE3.Enabled = flag;
        //    txtAddrLineE4.Enabled = flag;
        //    txtAddrTele.Enabled = flag;
        //    txtAddrFax.Enabled = flag;
        //    txtAddrEmail.Enabled = flag;
        //    txtAddrMobile.Enabled = flag;
        //    txtAddrRemark.Enabled = flag;
        //    txtAddrRemark2.Enabled = flag;
        //    txtAddrContactName1.Enabled = flag;
        //    txtAddrContactName2.Enabled = flag;
        //    txtAddrContactTel1.Enabled = flag;
        //    txtAddrContactTel2.Enabled = flag;

        //    txtAddrWeb1.Enabled = flag;
        //    txtAddrWeb2.Enabled = flag;
        //    txtAddrGoogleMap.Enabled = flag;
        //    chkAddrDefaultCus.Enabled = flag;
        //}
        private void setControlEnable(Boolean flag)
        {
            txtCusCode.Enabled = flag;
            txtCusNameT.Enabled = flag;
            txtCusNameE.Enabled = flag;
            txtAddrT1.Enabled = flag;
            txtAddrT2.Enabled = flag;
            txtAddrT3.Enabled = flag;
            txtAddrT4.Enabled = flag;
            txtAddrE1.Enabled = flag;
            txtAddrE2.Enabled = flag;
            txtAddrE3.Enabled = flag;
            txtAddrE4.Enabled = flag;
            txtTele.Enabled = flag;
            txtFax.Enabled = flag;
            txtEmail.Enabled = flag;
            txtRemark.Enabled = flag;
            txtRemark2.Enabled = flag;
            txtTaxId.Enabled = flag;
            txtContactName1.Enabled = flag;
            txtContactName2.Enabled = flag;
            txtContactTel1.Enabled = flag;
            txtContactTel2.Enabled = flag;
            groupBox1.Enabled = flag;
            chkVoid.Enabled = flag;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }
        private void grdFlex_LeaveCell(object sender, EventArgs e)
        {

        }
        private void grfCus_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            sB.Text = grfCus.Rows[e.Row].ToString();
        }
        private void grfAddr_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String addrId = "";
            addrId = grfAddr[e.NewRange.r1, colID] != null ? grfAddr[e.NewRange.r1, colID].ToString() : "";
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
        }
        private void grfCont_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String addrId = "";
            addrId = grfCont[e.NewRange.r1, colID] != null ? grfCont[e.NewRange.r1, colID].ToString() : "";
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
        }
        private void grfRmk_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String addrId = "";
            addrId = grfRmk[e.NewRange.r1, colID] != null ? grfRmk[e.NewRange.r1, colID].ToString() : "";
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
        }
        private void grfTax_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String addrId = "";
            addrId = grfTax[e.NewRange.r1, colID] != null ? grfTax[e.NewRange.r1, colID].ToString() : "";
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
        }
        private void grfCus_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1<0) return;
            String aaa = "";
            sB1.Text = e.NewRange.r1.ToString();
            if (e.NewRange.Data==null) return;
            sB1.Text = e.NewRange.Data.ToString();
            String cusId = "";
            cusId = grfCus[e.NewRange.r1, colID] != null ? grfCus[e.NewRange.r1, colID].ToString() : "";
            setControlCus(cusId);
            setGrfAddrH(cusId);
            setGrfContH(cusId);
            setGrfRmkH(cusId);
            setGrfTaxH(cusId);
            setControlEdit(false);
            chkVoid.Show();
        }
        void StatusBar_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            int cnt = grfCus.Rows.Count - grfCus.Rows.Fixed;
            sB.Text = cnt.ToString() + " rows in data source";
        }
        private void FrmCustomer1_Load(object sender, EventArgs e)
        {

        }
        // utilities
        private Bitmap BuildStyleBackground(Color background)
        {
            return BuildStyleBackground(Color.FromArgb(150, background), background, 90f);
        }
        private Bitmap BuildStyleBackground(Color color1, Color color2, float angle)
        {
            Rectangle rc = new Rectangle(0, 0, 10, 15);
            Bitmap bmp = new Bitmap(rc.Width, rc.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            using (LinearGradientBrush br = new LinearGradientBrush(rc, color1, color2, angle))
            {
                g.FillRectangle(br, rc);
            }
            return bmp;
        }
        private Bitmap GetBitmapResource(string name)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            foreach (string res in asm.GetManifestResourceNames())
            {
                if (res.EndsWith(name))
                {
                    return (Bitmap)Bitmap.FromStream(asm.GetManifestResourceStream(res));
                }
            }
            throw new ArgumentException("can't find resource " + name);
        }
        //#endregion
    }
}
