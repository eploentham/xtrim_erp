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
    public partial class FrmContactAdd : Form
    {
        XtrimControl xC;
        Contact cont;
        String flagContact = "";

        int colrow=0,colID = 1, colFNameT = 2, colLNameT = 3, colMobile=4, colEmail=5, colRemark = 6, coledit = 7;
        int colCnt = 8;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        
        C1FlexGrid grfCont;

        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        String userIdVoid = "";

        public FrmContactAdd(XtrimControl x, String flagcontact)
        {
            InitializeComponent();
            xC = x;
            flagContact = flagcontact;
            initConfig();
        }
        private void initConfig()
        {
            bg = txtContFNameT.BackColor;
            fc = txtContFNameT.ForeColor;
            ff = txtContFNameT.Font;

            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Bold);
            initGrfContH();
            setGrfInvH();

            setFocusColor();
            setControl(xC.contID);
            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            bg = txtContFNameT.BackColor;
            fc = txtContFNameT.ForeColor;
            theme1.SetTheme(sB, "BeigeOne");
            sB1.Text = "";
            cont = new Contact();
            setControlEnable(false);
            cboPrefix = xC.iniDB.pfxDB.setCboPrefix(cboPrefix);
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
        }
        private void initGrfContH()
        {
            grfCont = new C1FlexGrid();
            grfCont.Font = fEdit;
            grfCont.Dock = System.Windows.Forms.DockStyle.Fill;
            grfCont.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfCont);

            grfCont.DoubleClick += new System.EventHandler(this.grfCont_DoubleClick);
            //grfBank.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfBank_CellButtonClick);

            panel2.Controls.Add(this.grfCont);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfCont, theme);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            flagEdit = flagEdit ? false : true;
            setControlEnable(flagEdit);
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

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ ยกเลิกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                xC.iniDB.contDB.VoidContact(txtID.Text, userIdVoid);
                this.Dispose();
            }
        }

        private void setControl(String contId)
        {
            cont = xC.iniDB.contDB.selectByPk1(contId);
            txtID.Value = cont.cont_id;
            txtContFNameT.Value = cont.cont_fname_t;
            txtContLNameT.Value = cont.cont_lname_t;
            txtContFNameE.Value = cont.cont_fname_e;
            txtContLNameE.Value = cont.cont_lname_e;
            txtNickName.Value = cont.nick_name;
            txtPosiName.Value = cont.posi_name;
            txtRemark.Value = cont.remark;
            txtWorkResponse.Value = cont.work_response;
            txtEmail.Value = cont.email;
            txtEmail2.Value = cont.email2;
            txtMobile.Value = cont.mobile;
            
            cboPrefix.Text = cont.prefix_name_t;
        }
        private void setControlEnable(Boolean flag)
        {
            txtContFNameT.Enabled = flag;
            txtContLNameT.Enabled = flag;
            txtContFNameE.Enabled = flag;
            txtContLNameE.Enabled = flag;
            txtNickName.Enabled = flag;
            txtPosiName.Enabled = flag;
            txtRemark.Enabled = flag;
            txtWorkResponse.Enabled = flag;
            txtEmail.Enabled = flag;
            txtEmail2.Enabled = flag;
            txtMobile.Enabled = flag;
            btnSave.Enabled = flag;
            cboPrefix.Enabled = flag;
            chkVoid.Enabled = flag;
            
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }
        private void setContact()
        {
            cont.cont_id = txtID.Text;

            cont.cust_id = flagContact.Equals("0") ? xC.cusID : "";
            cont.cont_code = "";
            cont.username = "";
            cont.password1 = "";
            cont.prefix_id = "";
            cont.cont_fname_t = txtContFNameT.Text;
            cont.cont_fname_e = txtContFNameE.Text;
            cont.cont_lname_t = txtContLNameT.Text;
            cont.cont_lname_e = txtContLNameE.Text;
            cont.active = "1";
            cont.priority = "";
            cont.tele = "";
            cont.mobile = txtMobile.Text;
            cont.fax = "";
            cont.email = txtEmail.Text;
            cont.posi_id = "";
            cont.posi_name = txtPosiName.Text;
            cont.date_create = "";
            cont.date_modi = "";
            cont.date_cancel = "";
            cont.user_create = "";
            cont.user_modi = "";
            cont.user_cancel = "";
            cont.remark = txtRemark.Text;
            cont.email2 = txtEmail2.Text;
            cont.nick_name = txtNickName.Text;
            cont.work_response = txtWorkResponse.Text;
            cont.mobile = txtMobile.Text;
            cont.table_id = xC.addrID;
            cont.status_insr_email = chkInsrEmail.Checked ? "1" : "0";
            //ComboBoxItem c = ((ComboBoxItem)cboPrefix.SelectedItem).;
            cont.prefix_id = cboPrefix.SelectedItem == null ? "" :  ((ComboBoxItem)cboPrefix.SelectedItem).Value;
        }
        private void setGrfInvH()
        {
            DataTable dt = new DataTable();
            dt = xC.iniDB.contDB.selectAll1();
            //grfCont.Cols.Count = colCnt;
            //grfBank.Rows.Count = 7;
            grfCont.DataSource = dt;
            grfCont.Cols[colID].Width = 60;
            grfCont.Cols[colFNameT].Width = 100;
            grfCont.Cols[colLNameT].Width = 100;
            grfCont.Cols[colMobile].Width = 100;
            grfCont.Cols[colEmail].Width = 100;
            grfCont.Cols[colRemark].Width = 100;
            //grfBank.Cols[colE].Width = 100;
            //grfBank.Cols[colS].Width = 100;
            
            grfCont.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfBank.Cols[colCode].Caption = "รหัส";
            grfCont.Cols[colFNameT].Caption = "ชื่อ";
            grfCont.Cols[colLNameT].Caption = "นามสกุล";
            grfCont.Cols[colRemark].Caption = "หมายเหตุ";
            grfCont.Cols[colMobile].Caption = "มือถือ";
            grfCont.Cols[colEmail].Caption = "email";
            //grfBank.Cols[colS].Caption = "save";
            
            grfCont.Cols[colID].Visible = false;
            //grfCont.Cols[coledit].Visible = false;
            //FilterRow fr = new FilterRow(grfCont);
            //CellRange rg = grfBank.GetCellRange(2, colE);
            //rg.Style = grfBank.Styles["btn"];
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfBank.Cols[colE]. = false;
        }
        private void setFocusColor()
        {
            this.txtContFNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContFNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContLNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContLNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContFNameE.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContFNameE.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContLNameE.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContLNameE.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtNickName.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtNickName.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMobile.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMobile.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEmail.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEmail.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEmail2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEmail2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPosiName.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPosiName.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtAddrName.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtAddrName.Enter += new System.EventHandler(this.textBox_Enter);

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
        private void grfCont_DoubleClick(object sender, EventArgs e)
        {
            String contId = "";
            contId = grfCont[grfCont.Row, colID].ToString();
            if(flagEdit) setControl(contId);

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
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setContact();
                String re = xC.iniDB.contDB.insertContact(cont);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    //ถ้ามาจาก หน้าจอ address จะมี flagContact
                    if (flagContact.Equals("1"))
                    {
                        String re1 = xC.iniDB.addrDB.updateContact1(txtID.Text, re, txtContFNameT.Text + " " + txtContLNameT.Text, txtMobile.Text);
                        xC.rContactName = txtContFNameT.Text + " " + txtContLNameT.Text;
                        xC.rContacTel = txtMobile.Text;
                        xC.rContID = re;
                    }
                    else if (flagContact.Equals("2"))
                    {
                        String re2 = xC.iniDB.addrDB.updateContact2(txtID.Text, re, txtContFNameT.Text + " " + txtContLNameT.Text, txtMobile.Text);
                        xC.rContactName = txtContFNameT.Text + " " + txtContLNameT.Text;
                        xC.rContacTel = txtMobile.Text;
                        xC.rContID = re;
                    }
                    
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
        private void FrmContactAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
