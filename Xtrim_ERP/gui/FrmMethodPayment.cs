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
    public partial class FrmMethodPayment : Form
    {
        XtrimControl xC;
        MethodPayment mtp;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colName = 3, colRemark = 4;
        C1FlexGrid grfMtp;
        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "";

        public FrmMethodPayment(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            mtp = new MethodPayment();
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel3.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }

            bg = txtCode.BackColor;
            fc = txtCode.ForeColor;
            ff = txtCode.Font;

            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnSave.Click += BtnSave_Click;

            initGrfDept();
            setGrfDeptH();
            setControlEnable(false);
            setFocusColor();
            sB1.Text = "";
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
        }

        private void initGrfDept()
        {
            grfMtp = new C1FlexGrid();
            grfMtp.Font = fEdit;
            grfMtp.Dock = System.Windows.Forms.DockStyle.Fill;
            grfMtp.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfMtp);

            grfMtp.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfDept_AfterRowColChange);
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);

            panel2.Controls.Add(grfMtp);

            theme1.SetTheme(grfMtp, "Office2013Red");
        }
        private void setGrfDeptH()
        {
            //grfDept.Rows.Count = 7;
            grfMtp.DataSource = xC.iniDB.mtpDB.selectAll();
            grfMtp.Cols.Count = 5;
            TextBox txt = new TextBox();

            grfMtp.Cols[colCode].Editor = txt;
            grfMtp.Cols[colName].Editor = txt;
            grfMtp.Cols[colRemark].Editor = txt;

            grfMtp.Cols[colCode].Width = 60;
            grfMtp.Cols[colName].Width = 200;
            grfMtp.Cols[colRemark].Width = 100;

            grfMtp.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfMtp.Cols[colCode].Caption = "รหัส";
            grfMtp.Cols[colName].Caption = "ชื่อ วิธีการจ่ายเงิน";
            grfMtp.Cols[colRemark].Caption = "หมายเหตุ";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 1; i < grfMtp.Rows.Count; i++)
            {
                grfMtp[i, 0] = i;
                if (i % 2 == 0)
                    grfMtp.Rows[i].StyleNew.BackColor = color;
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfMtp.Cols[colID].Visible = false;
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
            this.txtCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void setControl(String deptId)
        {
            mtp = xC.iniDB.mtpDB.selectByPk1(deptId);
            txtID.Value = mtp.method_payment_id;
            txtCode.Value = mtp.method_payment_code;
            txtNameT.Value = mtp.method_payment_name_t;
            txtRemark.Value = mtp.remark;
        }
        private void setControlEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            txtCode.Enabled = flag;
            txtNameT.Enabled = flag;
            txtRemark.Enabled = flag;
            chkVoid.Enabled = flag;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }
        private void setDeptment()
        {
            mtp.method_payment_id = txtID.Text;
            mtp.method_payment_code = txtCode.Text;
            mtp.method_payment_name_t = txtNameT.Text;
            mtp.remark = txtRemark.Text;
        }
        private void grfDept_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String deptId = "";
            deptId = grfMtp[e.NewRange.r1, colID] != null ? grfMtp[e.NewRange.r1, colID].ToString() : "";
            setControl(deptId);
            setControlEnable(false);
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
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
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setDeptment();
                String re = xC.iniDB.mtpDB.insertMethodPayment(mtp, xC.user.staff_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                setGrfDeptH();
                //setGrdView();
                //this.Dispose();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            flagEdit = flagEdit ? false : true;
            setControlEnable(flagEdit);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtID.Value = "";
            txtCode.Value = "";
            txtNameT.Value = "";
            txtRemark.Value = "";
            chkVoid.Checked = false;
            btnVoid.Hide();
            setControlEnable(true);
        }
        private void FrmMethodPayment_Load(object sender, EventArgs e)
        {

        }
    }
}
