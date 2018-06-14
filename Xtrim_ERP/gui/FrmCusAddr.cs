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
    public partial class FrmCusAddr : Form
    {
        XtrimControl xC;
        Address addr;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "";
        public FrmCusAddr(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            bg = txtAddrT1.BackColor;
            fc = txtAddrT1.ForeColor;
            ff = txtAddrT1.Font;
            setFocusColor();
            setControl();

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            bg = txtAddrT1.BackColor;
            fc = txtAddrT1.ForeColor;
            theme1.SetTheme(sB, "BeigeOne");
            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;
            chkVoid.Click += ChkVoid_Click;
            btnVoid.Click += BtnVoid_Click;

            sB1.Text = "";
            addr = new Address();
            if (xC.addrID.Equals(""))
            {
                flagEdit = true;
            }
            else
            {
                flagEdit = false;
            }
            setControlEnable(flagEdit);
            setFocus();
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
        }
        private void setFocus()
        {
            txtAddrName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtAddrT1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtAddrT2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtAddrT3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtAddrT4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtAddrE1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtAddrE2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtAddrE3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtAddrE4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtEmail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);

            txtTele.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtFax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtRemark.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtContactName1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtContactName2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtContactTel1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtContactTel2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtWeb1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtWeb2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtMap.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);

            txtRemark2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtOverTime.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtRateOverTime.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtWeb3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            txtTimeOpen.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);

            txtTimeOpenOverTime.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
        }
        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //C1TextBox a = (C1TextBox)sender;
                if (((C1TextBox)sender).Name.Equals("txtAddrName"))
                {
                    txtAddrT1.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtAddrT1"))
                {
                    txtAddrT2.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtAddrT2"))
                {
                    txtAddrT3.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtAddrT3"))
                {
                    txtAddrT4.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtAddrT4"))
                {
                    txtTele.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtTele"))
                {
                    txtFax.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtFax"))
                {
                    txtRemark.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtRemark"))
                {
                    txtRemark2.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtRemark2"))
                {
                    txtContactName1.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtContactName1"))
                {
                    txtContactName2.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtContactName2"))
                {
                    txtMap.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtMap"))
                {
                    btnMapPath.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("btnMapPath"))
                {
                    txtWeb1.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtWeb1"))
                {
                    txtWeb2.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtWeb2"))
                {
                    txtWeb3.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtWeb3"))
                {
                    txtAddrE1.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtAddrE1"))
                {
                    txtAddrE2.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtAddrE2"))
                {
                    txtAddrE3.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtAddrE3"))
                {
                    txtAddrE4.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtAddrE4"))
                {
                    txtContactTel1.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtContactTel1"))
                {
                    txtContactTel2.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtContactTel2"))
                {
                    txtTimeOpen.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtTimeOpen"))
                {
                    txtTimeOpenOverTime.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtTimeOpenOverTime"))
                {
                    txtOverTime.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtOverTime"))
                {
                    txtRateOverTime.Focus();
                }
                else if (((C1TextBox)sender).Name.Equals("txtRateOverTime"))
                {
                    chkAddrDefaultCus.Focus();
                }
            }
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
            this.txtAddrName.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAddrName.Enter += new System.EventHandler(this.textBox_Enter);

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

            this.txtContactName1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContactName1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContactName2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContactName2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContactTel1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContactTel1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContactTel2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContactTel2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtWeb1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtWeb1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtWeb2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtWeb2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtWeb3.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtWeb3.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRateOverTime.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRateOverTime.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtOverTime.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtOverTime.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTimeOpen.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTimeOpen.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTimeOpenOverTime.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTimeOpenOverTime.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMap.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMap.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void setControlEnable(Boolean flag)
        {
            txtAddrName.Enabled = flag;
            txtAddrT1.Enabled = flag;
            txtAddrT2.Enabled = flag;
            txtAddrT3.Enabled = flag;
            txtAddrT4.Enabled = flag;
            txtAddrE1.Enabled = flag;
            txtAddrE2.Enabled = flag;
            txtAddrE3.Enabled = flag;
            txtAddrE4.Enabled = flag;
            txtEmail.Enabled = flag;
            txtTele.Enabled = flag;
            txtFax.Enabled = flag;
            txtRemark.Enabled = flag;

            txtContID.Enabled = flag;
            txtContID2.Enabled = flag;
            txtContactName1.Enabled = flag;
            txtContactName2.Enabled = flag;
            txtContactTel1.Enabled = flag;
            txtContactTel2.Enabled = flag;
            txtWeb1.Enabled = flag;
            txtWeb2.Enabled = flag;
            txtMap.Enabled = flag;
            txtRemark2.Enabled = flag;
            chkAddrDefaultCus.Enabled = flag;
            btnMapView.Enabled = flag;
            txtOverTime.Enabled = flag; ;
            txtRateOverTime.Enabled = flag;
            txtWeb3.Enabled = flag;
            txtTimeOpen.Enabled = flag;
            txtTimeOpenOverTime.Enabled = flag;
            chkAddrDefaultCus.Enabled = flag;
            chkVoid.Enabled = flag;
            chkContainerYard.Enabled = flag;
            chkPlaceAddr.Enabled = flag;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }
        private void setControl()
        {
            txtID.Value = xC.addrID;
            addr = xC.xtDB.addrDB.selectByPk1(xC.addrID);
            txtAddrName.Value = addr.address_name;
            txtAddrT1.Value = addr.line_t1;
            txtAddrT2.Value = addr.line_t2;
            txtAddrT3.Value = addr.line_t3;
            txtAddrT4.Value = addr.line_t4;
            txtAddrE1.Value = addr.line_e1;
            txtAddrE2.Value = addr.line_e2;
            txtAddrE3.Value = addr.line_e3;
            txtAddrE4.Value = addr.line_e4;
            txtEmail.Value = addr.email;
            txtTele.Value = addr.tele;
            txtFax.Value = addr.fax;
            txtRemark.Value = addr.remark;

            txtContID.Value = addr.contact_id;
            txtContID2.Value = addr.contact_id2;
            txtContactName1.Value = addr.contact_name1;
            txtContactName2.Value = addr.contact_name2;
            txtContactTel1.Value = addr.contact_name_tel1;
            txtContactTel2.Value = addr.contact_name_tel2;
            txtWeb1.Value = addr.web_site1;
            txtWeb2.Value = addr.web_site2;
            txtMap.Value = addr.google_map;
            txtRemark2.Value = addr.remark2;
            chkAddrDefaultCus.Checked = addr.status_defalut_customer.Equals("1") ? true : false;
            btnMapView.Visible = addr.map_pic_path != null ? true : false;
            txtOverTime.Value = addr.over_time;
            txtRateOverTime.Value = addr.rate_over_time;
            txtWeb3.Value = addr.web_site3;
            txtTimeOpen.Value = addr.time_open_close;
            txtTimeOpenOverTime.Value = addr.time_open_close_over_time;
            chkPlaceAddr.Checked = addr.status_place_addr.Equals("1") ? true : false;
            chkContainerYard.Checked = addr.status_container_yard.Equals("1") ? true : false;
        }
        private void setAddress()
        {
            addr.address_id = txtID.Text;
            addr.address_name = txtAddrName.Text;
            addr.address_code = "";
            addr.line_t1 = txtAddrT1.Text;
            addr.line_t2 = txtAddrT2.Text;
            addr.line_t3 = txtAddrT3.Text;
            addr.line_t4 = txtAddrT4.Text;
            addr.line_e1 = txtAddrE1.Text;
            addr.line_e2 = txtAddrE2.Text;
            addr.line_e3 = txtAddrE3.Text;
            addr.line_e4 = txtAddrE4.Text;
            addr.prov_id = "";
            addr.amphur_id = "";
            addr.district_id = "";
            addr.zipcode = "";
            addr.email = txtEmail.Text;
            addr.email2 = "";
            addr.tele = txtTele.Text;
            addr.mobile = "";
            addr.fax = txtFax.Text;
            addr.remark = txtRemark.Text;
            addr.address_type_id = "";
            addr.table_id = xC.cusID;
            addr.date_create = "";
            addr.date_modi = "";
            addr.date_cancel = "";
            addr.user_create = "";
            addr.user_modi = "";
            addr.user_cancel = "";
            addr.active = "1";

            addr.contact_id = txtContID.Text;
            addr.contact_name1 = txtContactName1.Text;
            addr.contact_name2 = txtContactName2.Text;
            addr.contact_name_tel1 = txtContactTel1.Text;
            addr.contact_name_tel2 = txtContactTel2.Text;

            addr.web_site1 = txtWeb1.Text;
            addr.web_site2 = txtWeb2.Text;
            addr.google_map = txtMap.Text;
            addr.status_defalut_customer = chkAddrDefaultCus.Checked ? "1" : "0";
            addr.remark2 = txtRemark2.Text;
            addr.time_open_close = txtTimeOpen.Text;
            addr.time_open_close_over_time = txtTimeOpenOverTime.Text;
            addr.contact_id2 = txtContID2.Text;
            addr.map_pic_path = txtMapPicPath.Text;
            addr.web_site3 = txtWeb3.Text;
            addr.over_time = txtOverTime.Text;
            addr.rate_over_time = txtRateOverTime.Text;
            addr.status_container_yard = chkContainerYard.Checked ? "1" : "0";
            addr.status_place_addr = chkPlaceAddr.Checked ? "1" : "0";
        }
        private void ChkVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
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
        private void BtnVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ ยกเลิกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                xC.xtDB.addrDB.VoidAddress(txtID.Text, userIdVoid);
                this.Dispose();
            }
        }
        private void btnMap_Click(object sender, EventArgs e)
        {
            FrmCusMap frm = new FrmCusMap(xC);
            frm.ShowDialog(this);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            flagEdit = flagEdit ? false : true;
            setControlEnable(flagEdit);
        }

        private void btnCont1_Click(object sender, EventArgs e)
        {
            xC.contID = txtContID.Text;
            FrmContactAdd frm = new FrmContactAdd(xC,"1");
            frm.ShowDialog(this);
            txtContactName1.Value = xC.rContactName;
            txtContactTel1.Value = xC.rContacTel;
            txtContID.Value = xC.rContID;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //setAddress();
            //xC.xtDB.addrDB.insertAddress(addr);
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setAddress();
                String re = xC.xtDB.addrDB.insertAddress(addr);
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
        private void FrmCusAddr_Load(object sender, EventArgs e)
        {

        }
    }
}
