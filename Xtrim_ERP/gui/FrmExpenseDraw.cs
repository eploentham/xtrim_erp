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
    public partial class FrmExpenseDraw : Form
    {
        XtrimControl xC;
        ExpensesDraw expnD;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colDesc = 3, colAmt=4, colRemark = 5;
        int colDid = 1, colDCode=2, colDdesc1 = 3, colDdesc2 = 4, colDamt = 5, colDremark = 6;
        C1FlexGrid grfExpnD, grfExpnD1;
        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "", jobId="";
        public String drawId="", flagForm="";
        public FrmExpenseDraw(XtrimControl x, String drawid, String flagform)
        {
            InitializeComponent();
            xC = x;
            drawId = drawid;
            flagForm = flagform;
            initConfig();
        }
        private void initConfig()
        {
            expnD = new ExpensesDraw();
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
            xC.xtDB.stfDB.setCboStaff(cboStaff,"");
            DateTime jobDate = DateTime.Now;
            txtExpndDrawDate.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");
            jobDate = jobDate.AddDays(7);
            txtDrawDate.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");

            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;
            txtJobCode.KeyUp += TxtJobCode_KeyUp;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnSave.Click += BtnSave_Click;
            btnDoc.Click += BtnDoc_Click;
            btnAppv.Click += BtnAppv_Click;

            initGrfDept();
            initGrfDept1();
            setGrfDeptH();
            setGrfDeptH1();
            setControlEnable(false);
            setFocusColor();
            setControlAppv();
            setControl(drawId);

            sB1.Text = "";
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
        }
        
        private void TxtJobCode_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if(e.KeyCode== Keys.Enter)
            {
                JobImport jim = xC.xtDB.jimDB.selectByJobCode(txtJobCode.Text.Replace("IMP",""));
                if (!jim.job_import_id.Equals(""))
                {
                    jobId = jim.job_import_id;
                    txtJobCode.Value = "IMP"+jim.job_import_code;
                    setGrfDeptH1();
                }
            }
        }

        private void initGrfDept()
        {
            grfExpnD = new C1FlexGrid();
            grfExpnD.Font = fEdit;
            grfExpnD.Dock = System.Windows.Forms.DockStyle.Fill;
            grfExpnD.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpnD);

            grfExpnD.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfExpnD_AfterRowColChange);
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            grfExpnD.CellChanged += GrfExpnD_CellChanged;
            panel4.Controls.Add(grfExpnD);

            theme1.SetTheme(grfExpnD, "Office2013Red");            
        }
        private void initGrfDept1()
        {
            grfExpnD1 = new C1FlexGrid();
            grfExpnD1.Font = fEdit;
            grfExpnD1.Dock = System.Windows.Forms.DockStyle.Fill;
            grfExpnD1.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpnD1);

            grfExpnD1.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfExpnD1_AfterRowColChange);
            //grfExpnD1.RowColChange += GrfExpnD1_RowColChange;
            //grfExpnD1.CellChanged += GrfExpnD1_CellChanged;

            panel3.Controls.Add(grfExpnD1);
            
            theme1.SetTheme(grfExpnD1, "VS2013Red");            
        }

        private void GrfExpnD_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Row <= 0) return;
            if ((grfExpnD.Col == colDdesc1))
            {
                //grfExpnD. = colDdesc2;
            }
            else if ((grfExpnD.Col == colDdesc2))
            {

            }
            else if ((grfExpnD.Col == colDamt))
            {
                calAmount();
            }
            if ((grfExpnD.Col == colDamt) && (grfExpnD.Rows.Count == (grfExpnD.Row + 1))) grfExpnD.Rows.Count++;
        }

        private void GrfExpnD1_RowColChange(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (e.r1 < 0) return;
            //if ((grfExpnD.Col == colDamt) && (grfExpnD.Rows.Count == (grfExpnD.Row + 1))) grfExpnD.Rows.Count++;
        }
        private void calAmount()
        {
            Decimal amt = 0;
            for(int i = 1; i < grfExpnD.Rows.Count; i++)
            {
                Decimal amt1 = 0;
                if (grfExpnD[i, colDamt] == null) continue;
                if(Decimal.TryParse(grfExpnD[i, colDamt].ToString(), out amt1))
                {
                    amt += amt1;
                }
            }
            txtAmt.Value = amt;
        }
        private void setGrfDeptH()
        {
            grfExpnD.Clear();
            //if (txtID.Text.Equals("")) return;
            DataTable dt = new DataTable();
            grfExpnD.Cols.Count = 7;
            if (flagForm.Equals("new"))
            {
                grfExpnD.Rows.Count = 2;
            }
            else
            {
                dt = xC.xtDB.expnddDB.selectByDrawId1(txtID.Text);
                grfExpnD.Rows.Count = dt.Rows.Count+1;
                grfExpnD.Cols.Count = 7;
            }
            //grfExpnD.Rows.Count = 2;
            C1TextBox txt = new C1TextBox();
            txt.DataType = txtCode.DataType;
            C1TextBox txt1 = new C1TextBox();
            txt1.DataType = txtAmt.DataType;
            C1ComboBox cbo = new C1ComboBox();
            xC.xtDB.itmDB.setCboItem(cbo);
            grfExpnD.Cols[colDCode].Editor = cbo;
            grfExpnD.Cols[colDdesc1].Editor = txt;
            grfExpnD.Cols[colDdesc2].Editor = txt;
            grfExpnD.Cols[colDremark].Editor = txt;
            grfExpnD.Cols[colDamt].Editor = txt1;

            grfExpnD.Cols[colDdesc1].Width = 200;
            grfExpnD.Cols[colDdesc2].Width = 200;
            grfExpnD.Cols[colDremark].Width = 100;
            grfExpnD.Cols[colDamt].Width = 80;
            grfExpnD.Cols[colDCode].Width = 200;

            grfExpnD.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";
            grfExpnD.Cols[colDCode].Caption = "รายการ";
            grfExpnD.Cols[colDdesc1].Caption = "รายละเอียด 1";
            grfExpnD.Cols[colDdesc2].Caption = "รายละเอียด 2";
            grfExpnD.Cols[colDremark].Caption = "หมายเหตุ";
            grfExpnD.Cols[colDamt].Caption = "ยอดเงินเบิก";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfExpnD[i + 1, 0] = i;
                if (i % 2 == 0)
                    grfExpnD.Rows[i].StyleNew.BackColor = color;
                grfExpnD[i+1, colDid] = dt.Rows[i][xC.xtDB.expnddDB.expnC.expenses_draw_detail_id].ToString();
                grfExpnD[i + 1, colCode] = xC.xtDB.itmDB.getNameById(dt.Rows[i][xC.xtDB.expnddDB.expnC.item_id].ToString());
                grfExpnD[i + 1, colDdesc1] = dt.Rows[i][xC.xtDB.expnddDB.expnC.desc1].ToString();
                grfExpnD[i + 1, colDdesc2] = dt.Rows[i][xC.xtDB.expnddDB.expnC.desc2].ToString();
                grfExpnD[i + 1, colDremark] = xC.xtDB.itmDB.getNameById(dt.Rows[i][xC.xtDB.expnddDB.expnC.remark].ToString());
                grfExpnD[i + 1, colDamt] = dt.Rows[i][xC.xtDB.expnddDB.expnC.amount].ToString();
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //if (grfPic.Rows.Count == (grfPic.Row + 1)) grfPic.Rows.Count++;
            //grfExpnD.AfterRowColChange += GrfExpnD_AfterRowColChange;
            //grfExpnD.RowColChange += GrfExpnD_RowColChange;
            
            if (flagForm.Equals("pay"))
            {
                ContextMenu menuGw = new ContextMenu();
                menuGw.MenuItems.Add("&จ่ายเงิน รายการเบิก", new EventHandler(ContextMenu_pay));
                //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
                //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
                grfExpnD.ContextMenu = menuGw;
            }
            grfExpnD.Cols[colDid].Visible = false;            
        }

        private void GrfExpnD_RowColChange(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfExpnD.Col == colDCode)
            {
                grfExpnD.Col = colDdesc1;
            }
            else if (grfExpnD.Col == colDamt)
            {
                if (grfExpnD.Rows.Count == (grfExpnD.Row + 1)) grfExpnD.Rows.Count++;
            }
        }

        private void GrfExpnD_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.OldRange.c1 == colDCode)
            {
                if (grfExpnD.Rows.Count == (grfExpnD.Row + 1)) grfExpnD.Rows.Count++;
                grfExpnD.Col = colDdesc1;
            }
            

        }

        private void setGrfDeptH1()
        {
            grfExpnD1.DataSource = null;
            grfExpnD1.Rows.Count = 2;
            grfExpnD1.Clear();
            if (txtJobCode.Text.Equals("")) return;
            grfExpnD1.DataSource = xC.xtDB.expndDB.selectByJobCode2(txtJobCode.Text.Replace("IMP",""));

            grfExpnD1.Cols.Count = 6;
            TextBox txt = new TextBox();

            grfExpnD1.Cols[colCode].Editor = txt;
            grfExpnD1.Cols[colDesc].Editor = txt;
            grfExpnD1.Cols[colRemark].Editor = txt;
            grfExpnD1.Cols[colAmt].Editor = txt;

            grfExpnD1.Cols[colAmt].Width = 80;
            grfExpnD1.Cols[colCode].Width = 60;
            grfExpnD1.Cols[colDesc].Width = 200;
            grfExpnD1.Cols[colRemark].Width = 100;

            grfExpnD1.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";
            grfExpnD1.Cols[colAmt].Caption = "ยอดเงิน";
            grfExpnD1.Cols[colCode].Caption = "เลขที่ใบเบิก";
            grfExpnD1.Cols[colDesc].Caption = "รายละเอียด";
            grfExpnD1.Cols[colRemark].Caption = "หมายเหตุ";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 1; i < grfExpnD1.Rows.Count; i++)
            {
                grfExpnD1[i, 0] = i;
                if (i % 2 == 0)
                    grfExpnD1.Rows[i].StyleNew.BackColor = color;
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfExpnD1.Cols[colID].Visible = false;
            
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

            this.txtDesc.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDesc.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void setControl(String deptId)
        {
            expnD = xC.xtDB.expndDB.selectByPk1(deptId);
            if (expnD.expenses_draw_id.Equals(""))
            {
                txtID.Value = "";
                txtCode.Value = "";
                txtJobCode.Value = "IMP" + expnD.job_code;
                txtDesc.Value = "";
                txtRemark.Value = "";
                DateTime jobDate = DateTime.Now;
                txtExpndDrawDate.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");
                jobDate = jobDate.AddDays(7);
                txtDrawDate.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");
                txtAmt.Value = 0;
            }
            else
            {
                txtID.Value = expnD.expenses_draw_id;
                txtCode.Value = expnD.expenses_draw_code;
                txtJobCode.Value = "IMP" + expnD.job_code;
                txtDesc.Value = expnD.desc1;
                txtRemark.Value = expnD.remark;
                txtExpndDrawDate.Value = expnD.expenses_draw_date;
                txtDrawDate.Value = expnD.draw_date;
                txtAmt.Value = expnD.amount;
                xC.setC1Combo(cboStaff, expnD.staff_id);
            }

            setGrfDeptH();
            setGrfDeptH1();
            if (expnD.status_appv.Equals("0"))
            {
                label8.Text = "...";
                
            }            
            else if (expnD.status_appv.Equals("1"))
            {
                label8.Text = "รออนุมัติ";
                label8.ForeColor = Color.Red;
            }
            else if (expnD.status_appv.Equals("2"))
            {
                label8.Text = "อนุมัติแล้ว";
                label8.ForeColor = Color.Green;
            }
        }
        private void setControlEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            txtCode.Enabled = flag;
            txtDesc.Enabled = flag;
            txtRemark.Enabled = flag;
            chkVoid.Enabled = flag;
            txtExpndDrawDate.Enabled = flag;
            txtDrawDate.Enabled = flag;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }
        private void setControlAppv()
        {
            if (flagForm.Equals("new"))
            {
                btnDoc.Show();
                btnNew.Show();
                btnSave.Show();
                btnVoid.Show();
                btnEdit.Show();
                btnAppv.Hide();
                label7.Hide();
                txtAppvAmt.Hide();
            }
            else if (flagForm.Equals("view"))
            {
                btnDoc.Show();
                btnNew.Show();
                btnSave.Show();
                btnVoid.Show();
                btnEdit.Show();
                btnAppv.Hide();
                label7.Hide();
                txtAppvAmt.Hide();
            }
            else if (flagForm.Equals("appv"))
            {
                btnDoc.Hide();
                btnNew.Hide();
                btnSave.Hide();
                btnVoid.Hide();
                btnEdit.Hide();
                btnAppv.Show();
                label7.Show();
                txtAppvAmt.Show();
            }
            else if (flagForm.Equals("pay"))
            {
                btnDoc.Hide();
                btnNew.Hide();
                btnSave.Hide();
                btnVoid.Hide();
                btnEdit.Hide();
                btnAppv.Hide();
                label7.Show();
                txtAppvAmt.Show();
            }
        }
        private void setExpensesDraw()
        {
            expnD.expenses_draw_id = txtID.Text;
            expnD.expenses_draw_code = txtCode.Text;
            expnD.desc1 = txtDesc.Text;
            expnD.remark = txtRemark.Text;
            expnD.expenses_draw_date = xC.datetoDB(txtExpndDrawDate.Text);
            expnD.draw_date = xC.datetoDB(txtDrawDate.Text);
            expnD.staff_id = cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "";
            expnD.job_code = txtJobCode.Text.Replace("IMP","");
            expnD.job_id = jobId;
            expnD.amount = txtAmt.Value.ToString();
            expnD.year = (DateTime.Parse(txtDrawDate.Text)).Year.ToString();
            if (label8.Text.Equals("..."))
            {
                expnD.status_appv = "0";
            }
            else if (label8.Text.Equals("รออนุมัติ"))
            {
                expnD.status_appv = "1";
            }
            else if (label8.Text.Equals("อนุมัติแล้ว"))
            {
                expnD.status_appv = "2";
            }

        }
        private void setExpensesDrawDetail(String expnid)
        {
            for (int i = 1; i < grfExpnD.Rows.Count; i++)
            {
                if (grfExpnD.Row <= 0) continue;
                ExpensesDrawDatail expndd = new ExpensesDrawDatail();
                expndd.expense_draw_id = expnid;
                expndd.expenses_draw_detail_id = grfExpnD[i, colDid] == null ? "" : grfExpnD[i, colDid].ToString();
                expndd.desc1 = grfExpnD[i, colDdesc1] == null ? "" : grfExpnD[i, colDdesc1].ToString();
                expndd.desc2 = grfExpnD[i, colDdesc2] == null ? "" : grfExpnD[i, colDdesc2].ToString();
                expndd.amount = grfExpnD[i, colDamt] == null ? "" : grfExpnD[i, colDamt].ToString();
                expndd.remark = grfExpnD[i, colDremark] == null ? "" : grfExpnD[i, colDremark].ToString();
                expndd.item_id = grfExpnD[i, colCode] == null ? "" : xC.xtDB.itmDB.getIdByName(grfExpnD[i, colCode].ToString().Trim());

                if (!expndd.amount.Equals(""))
                {
                    xC.xtDB.expnddDB.insertExpenseDrawDetail(expndd, xC.userId);
                }
            }
        }
        private void grfExpnD_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            //if (e.NewRange.Data == null) return;

            //String deptId = "";
            //deptId = grfExpnD[e.NewRange.r1, colID] != null ? grfExpnD[e.NewRange.r1, colID].ToString() : "";
            //setControl(deptId);
            //setControlEnable(false);


            //setControlAddr(addrId);
            //setControlAddrEnable(false);
        }
        private void grfExpnD1_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;


        }
        private void ContextMenu_pay(object sender, System.EventArgs e)
        {
            if (grfExpnD.Row == null) return;
            if (grfExpnD.Row < 0) return;

            String drawdId = "";
            drawdId = grfExpnD[grfExpnD.Row, colID] != null ? grfExpnD[grfExpnD.Row, colID].ToString() : "";
            FrmExpenseDrawPay frm = new FrmExpenseDrawPay(xC, drawdId, "pay");
            //frm.drawId = xC.drawID;
            //frm.flagForm = "appv";
            frm.WindowState = FormWindowState.Normal;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);
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
        private void BtnAppv_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ อนุมัติ  \n การเบิกเงิน  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String re = xC.xtDB.expndDB.updateStatusApprove(txtID.Text);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    setControl(drawId);
                }
            }
        }
        private void BtnDoc_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ ออกเลขที่เอกสาร  \n การเบิกเงิน และส่งข้อมูล ขออนุมัติ ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String re = xC.updateDrawSendToApprove(txtID.Text);
                int chk = 0;
                if(int.TryParse(re, out chk))
                {
                    setControl(drawId);
                }
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setExpensesDraw();
                String re = xC.xtDB.expndDB.insertExpenseDraw(expnD, xC.user.staff_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    if (flagForm.Equals("new"))
                    {
                        setExpensesDrawDetail(re);
                    }
                    else
                    {
                        setExpensesDrawDetail(txtID.Text);
                    }
                    
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
            txtDesc.Value = "";
            txtRemark.Value = "";
            chkVoid.Checked = false;
            btnVoid.Hide();
            setControlEnable(true);
        }
        private void FrmExpenseDraw_Load(object sender, EventArgs e)
        {

        }
    }
}
