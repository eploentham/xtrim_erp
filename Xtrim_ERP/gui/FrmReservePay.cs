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
    public partial class FrmReservePay : Form
    {
        XtrimControl xC;
        ReservePay rsp;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colAmt = 2, colDate = 3, colStatus = 4, colDesc = 5;        
        C1FlexGrid grfExpnD, grfExpnD1;
        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "", jobId = "";
        public String drawId = "", flagForm = "";

        public FrmReservePay(XtrimControl x, String flagform)
        {
            InitializeComponent();
            xC = x;
            flagForm = flagform;
            initConfig();
        }
        private void initConfig()
        {
            rsp = new ReservePay();
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel3.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }

            bg = txtID.BackColor;
            fc = txtID.ForeColor;
            ff = txtID.Font;
            xC.xtDB.stfDB.setCboStaff(cboStaff, "");
            DateTime jobDate = DateTime.Now;
            txtDateDraw.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");
            jobDate = jobDate.AddDays(7);
            txtDateDraw.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");

            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;

            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnSave.Click += BtnSave_Click;
            btnAppv.Click += BtnAppv_Click;
            btnRsp.Click += BtnRsp_Click;

            xC.xtDB.stfDB.setCboStaff(cboStaff, "");
            initGrfDept();
            
            setGrfDeptH();

            setControlEnable(false);
            setFocusColor();
            //setControlAppv();
            //setControl(drawId);

            sB1.Text = "";
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
            if (flagForm.Equals("appv"))
            {
                btnNew.Hide();
                btnEdit.Hide();
                btnSave.Hide();
                btnAppv.Show();
                btnRsp.Hide();
                flagEdit = false;
                setControlEnable(flagEdit);
            }
            else if (flagForm.Equals("reserve"))
            {
                btnNew.Hide();
                btnEdit.Hide();
                btnSave.Hide();
                btnAppv.Hide();
                btnRsp.Show();
                btnRsp.Enabled = true;
            }
            else if (flagForm.Equals("draw"))
            {
                btnNew.Show();
                btnEdit.Show();
                btnSave.Show();
                btnAppv.Hide();
                btnRsp.Hide();
            }
        }

        private void BtnRsp_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ รับเงินเข้า เงินสำรองจ่าย ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String re = xC.updateReserveAmt(txtID.Text, xC.user.staff_id);
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

        private void BtnAppv_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ อนุมัติช้อมูล เงินสำรองจ่าย", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String re = xC.xtDB.rspDB.updateAppv(txtID.Text, xC.user.staff_id);
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setReservePay();
                String re = xC.xtDB.rspDB.insertReservePay(rsp, xC.user.staff_id);
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
            flagEdit = true;
            setControlEnable(flagEdit);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setControlRsp("");
            flagEdit = true;
            setControlEnable(flagEdit);
        }

        private void TxtPasswordVoid_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void initGrfDept()
        {
            grfExpnD = new C1FlexGrid();
            grfExpnD.Font = fEdit;
            grfExpnD.Dock = System.Windows.Forms.DockStyle.Fill;
            grfExpnD.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpnD);

            grfExpnD.AfterRowColChange += GrfExpnD_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //grfExpnD.CellChanged += GrfExpnD_CellChanged;
            panel2.Controls.Add(grfExpnD);

            theme1.SetTheme(grfExpnD, "Office2013Red");
        }

        private void GrfExpnD_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            String cusId = "";
            cusId = grfExpnD[e.NewRange.r1, colID] != null ? grfExpnD[e.NewRange.r1, colID].ToString() : "";
            setControlRsp(cusId);
            setControlEnable(false);
        }

        private void setGrfDeptH()
        {
            grfExpnD.Clear();
            //if (txtID.Text.Equals("")) return;
               
            grfExpnD.DataSource = xC.xtDB.rspDB.selectAll1();
            

            //grfExpnD.Rows.Count = 2;
            C1TextBox txt = new C1TextBox();
            txt.DataType = txtID.DataType;
           
            grfExpnD.Cols[colAmt].Editor = txt;
            grfExpnD.Cols[colDate].Editor = txt;
            grfExpnD.Cols[colStatus].Editor = txt;
            grfExpnD.Cols[colDesc].Editor = txt;

            grfExpnD.Cols[colAmt].Width = 80;
            grfExpnD.Cols[colDate].Width = 200;
            grfExpnD.Cols[colStatus].Width = 100;
            grfExpnD.Cols[colDesc].Width = 200;

            grfExpnD.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";
            grfExpnD.Cols[colAmt].Caption = "ยอดเงิน";
            grfExpnD.Cols[colDate].Caption = "วันที่เบิก";
            grfExpnD.Cols[colStatus].Caption = "สถานะ";
            grfExpnD.Cols[colDesc].Caption = "รายละเอียด";
            
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 1; i < grfExpnD.Rows.Count; i++)
            {
                grfExpnD[i, 0] = i;
                if(grfExpnD[i, colStatus].ToString().Equals("1"))
                {
                    grfExpnD[i, colStatus] = "ขออนุมัติ";
                }
                else if (grfExpnD[i, colStatus].ToString().Equals("2"))
                {
                    grfExpnD[i, colStatus] = "อนุมัติ";
                }
                else
                {
                    grfExpnD[i, colStatus] = "-";
                }
                
                if (i % 2 == 0)
                    grfExpnD.Rows[i].StyleNew.BackColor = color;
                //    grfExpnD[i + 1, colDid] = dt.Rows[i][xC.xtDB.expnddDB.expnC.expenses_draw_detail_id].ToString();
                //    grfExpnD[i + 1, colAmt] = xC.xtDB.itmDB.getNameById(dt.Rows[i][xC.xtDB.expnddDB.expnC.item_id].ToString());
                //    grfExpnD[i + 1, colDdesc1] = dt.Rows[i][xC.xtDB.expnddDB.expnC.desc1].ToString();
                //    grfExpnD[i + 1, colDdesc2] = dt.Rows[i][xC.xtDB.expnddDB.expnC.desc2].ToString();
                //    grfExpnD[i + 1, colDremark] = xC.xtDB.itmDB.getNameById(dt.Rows[i][xC.xtDB.expnddDB.expnC.remark].ToString());
                //    grfExpnD[i + 1, colDamt] = dt.Rows[i][xC.xtDB.expnddDB.expnC.amount].ToString();
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //if (grfPic.Rows.Count == (grfPic.Row + 1)) grfPic.Rows.Count++;
            //grfExpnD.AfterRowColChange += GrfExpnD_AfterRowColChange;
            //grfExpnD.RowColChange += GrfExpnD_RowColChange;

            //if (flagForm.Equals("pay"))
            //{
            //    ContextMenu menuGw = new ContextMenu();
            //    //menuGw.MenuItems.Add("&จ่ายเงิน รายการเบิก", new EventHandler(ContextMenu_pay));
            //    //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //    //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            //    grfExpnD.ContextMenu = menuGw;
            //}
            grfExpnD.Cols[colID].Visible = false;
        }
        private void setControlEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            txtDateDraw.Enabled = flag;
            txtDesc.Enabled = flag;
            txtAmt.Enabled = flag;
            txtAmtReserve.Enabled = flag;
            txtRspWait.Enabled = flag;
            chkVoid.Enabled = flag;
            cboStaff.Enabled = flag;
            
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
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
            this.txtDesc.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDesc.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAmt.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAmt.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAmtReserve.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAmtReserve.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRspWait.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRspWait.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void setControlRsp(String rspid)
        {
            if (!rspid.Equals(""))
            {
                ReservePay rsp = new ReservePay();
                rsp = xC.xtDB.rspDB.selectByPk1(rspid);
                txtID.Value = rsp.reserve_pay_id;
                txtDesc.Value = rsp.desc1;
                txtAmt.Value = rsp.amount_draw;
                txtDateDraw.Value = rsp.date_draw;
                xC.setC1Combo(cboStaff, rsp.staff_id);

                Company cop = new Company();
                cop = xC.xtDB.copDB.selectByCode1("001");
                txtAmtReserve.Value = cop.amount_reserve;
                txtRspWait.Value = xC.xtDB.rspDB.selectAppvWait();
                if (rsp.status_appv.Equals("2"))
                {
                    btnAppv.Enabled = false;
                    Decimal chk = 0;
                    if(Decimal.TryParse(rsp.amount_reserve, out chk))
                    {
                        btnRsp.Enabled = false;
                    }
                }
            }
            else
            {
                DateTime jobDate = DateTime.Now;
                txtDateDraw.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");
                txtID.Value = "";
                txtDesc.Value = "";
                txtAmt.Value = "";
                //txtDateDraw.Value = "";
                xC.setC1Combo(cboStaff, "");
            }
            if (flagForm.Equals("appv"))
            {
                btnNew.Hide();
                btnEdit.Hide();
                btnSave.Hide();
                btnAppv.Show();
                btnRsp.Hide();
                flagEdit = false;
                setControlEnable(flagEdit);
            }
            else if (flagForm.Equals("reserve"))
            {
                btnNew.Hide();
                btnEdit.Hide();
                btnSave.Hide();
                btnAppv.Hide();
                btnRsp.Show();
            }
            else if (flagForm.Equals("draw"))
            {
                btnNew.Show();
                btnEdit.Show();
                btnSave.Show();
                btnAppv.Hide();
                btnRsp.Hide();
            }
        }
        private void setReservePay()
        {
            rsp.reserve_pay_id = txtID.Text;
            rsp.desc1 = txtDesc.Text;
            rsp.amount_draw = txtAmt.Value.ToString();
            rsp.date_draw = xC.datetoDB(txtDateDraw.Text);
            rsp.staff_id = cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "";
            rsp.status_appv = "1";
        }
        private void FrmReservePay_Load(object sender, EventArgs e)
        {
            Company cop = new Company();
            cop = xC.xtDB.copDB.selectByCode1("001");
            txtAmtReserve.Value = cop.amount_reserve;
            txtRspWait.Value = xC.xtDB.rspDB.selectAppvWait();
        }
    }
}
