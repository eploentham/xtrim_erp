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
        ExpensesDraw expnD;
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

        public FrmReservePay(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
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
            flagEdit = true;
            setControlEnable(flagEdit);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setControlCus("");
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
            setControlCus(cusId);
            setControlEnable(false);
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
                dt = xC.xtDB.rspDB.selectAll1();
                grfExpnD.Rows.Count = dt.Rows.Count + 1;
                grfExpnD.Cols.Count = 6;
            }
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
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    grfExpnD[i + 1, 0] = i;
            //    if (i % 2 == 0)
            //        grfExpnD.Rows[i].StyleNew.BackColor = color;
            //    grfExpnD[i + 1, colDid] = dt.Rows[i][xC.xtDB.expnddDB.expnC.expenses_draw_detail_id].ToString();
            //    grfExpnD[i + 1, colAmt] = xC.xtDB.itmDB.getNameById(dt.Rows[i][xC.xtDB.expnddDB.expnC.item_id].ToString());
            //    grfExpnD[i + 1, colDdesc1] = dt.Rows[i][xC.xtDB.expnddDB.expnC.desc1].ToString();
            //    grfExpnD[i + 1, colDdesc2] = dt.Rows[i][xC.xtDB.expnddDB.expnC.desc2].ToString();
            //    grfExpnD[i + 1, colDremark] = xC.xtDB.itmDB.getNameById(dt.Rows[i][xC.xtDB.expnddDB.expnC.remark].ToString());
            //    grfExpnD[i + 1, colDamt] = dt.Rows[i][xC.xtDB.expnddDB.expnC.amount].ToString();
            //}
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
        }
        private void setControlCus(String rspid)
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
            
        }
        private void FrmReservePay_Load(object sender, EventArgs e)
        {

        }
    }
}
