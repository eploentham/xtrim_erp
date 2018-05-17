using C1.Win.C1Input;
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
            sB1.Text = "";
            addr = new Address();
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
