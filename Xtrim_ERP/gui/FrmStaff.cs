using C1.Win.C1Input;
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

namespace Xtrim_ERP.gui
{
    public partial class FrmStaff : Form
    {
        Staff stf;
        XtrimControl xC;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        int colID = 0, colE = 1, colS = 2, colCode = 3, colNameT = 4, colNameE = 5, colRemark = 6, coledit = 7;
        int colCnt = 8;

        public FrmStaff(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            stf = new Staff();

            bg = txtStfCode.BackColor;
            fc = txtStfCode.ForeColor;
            ff = txtStfCode.Font;

            ContextMenu custommenu = new ContextMenu();
            custommenu.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_void));
            //custommenu.MenuItems.Add("&ยกเลิก";
            //grdView.ContextMenu = custommenu;
            setFocusColor();
            //setGrdView();
            setFocusColor();
            setFocus();
        }
        private void ContextMenu_void(object sender, System.EventArgs e)
        {
            //FarPoint.Win.Spread.Row row = grdView.ActiveSheet.ActiveRow;
            //FarPoint.Win.Spread.Column c;
            //c = grdView.ActiveSheet.ActiveColumn;
            //String aa = grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colCode].Value == null ? "" : grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colCode].Value.ToString();
            //if (MessageBox.Show("ต้องการ ยกเลิก \nรายการ" + aa, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //    String re = xC.xtDB.banDB.voidBank(grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colID].Value == null ? "" : grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colID].Value.ToString());
            //    if (re.Equals("1"))
            //    {
            //        grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[grdView.ActiveSheet.ActiveRow.Index, 0, grdView.ActiveSheet.ActiveRow.Index, colCnt - 1].BackColor = Color.Gray;
            //    }
            //}
        }
        //private void setGrdViewH()
        //{
        //    FarPoint.Win.Spread.EnhancedInterfaceRenderer outlinelook = new FarPoint.Win.Spread.EnhancedInterfaceRenderer();
        //    outlinelook.RangeGroupBackgroundColor = Color.LightGreen;
        //    outlinelook.RangeGroupButtonBorderColor = Color.Red;
        //    outlinelook.RangeGroupLineColor = Color.Blue;
        //    grdView.InterfaceRenderer = outlinelook;
        //    grdView.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

        //    grdView.BorderStyle = BorderStyle.None;
        //    grdView.Sheets[0].Columns[colCode, colRemark].AllowAutoFilter = true;
        //    grdView.Sheets[0].Columns[colCode, colRemark].AllowAutoSort = true;
        //    grdView.Sheets[0].AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu;

        //    FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();
        //    FarPoint.Win.Spread.CellType.ButtonCellType buttoncell = new FarPoint.Win.Spread.CellType.ButtonCellType();

        //    grdView.Sheets[0].ColumnCount = colCnt;
        //    grdView.Sheets[0].RowCount = 1;
        //    grdView.Font = fEdit;

        //    grdView.Sheets[0].Columns[colID].CellType = objTextCell;
        //    grdView.Sheets[0].Columns[colE].CellType = buttoncell;
        //    grdView.Sheets[0].Columns[colS].CellType = buttoncell;
        //    grdView.Sheets[0].Columns[colCode].CellType = objTextCell;
        //    grdView.Sheets[0].Columns[colNameT].CellType = objTextCell;
        //    grdView.Sheets[0].Columns[colNameE].CellType = objTextCell;
        //    grdView.Sheets[0].Columns[colRemark].CellType = objTextCell;
        //    grdView.Sheets[0].Columns[coledit].CellType = objTextCell;

        //    grdView.Sheets[0].ColumnHeader.Cells[0, colE].Text = "edit";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colS].Text = "save";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colCode].Text = "code";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colNameT].Text = "ชื่อไทย";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colNameE].Text = "ชื่ออังกฤษ";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colRemark].Text = "หมายเหตุ";

        //    grdView.Sheets[0].Columns[colE].Width = 50;
        //    grdView.Sheets[0].Columns[colS].Width = 50;
        //    grdView.Sheets[0].Columns[colCode].Width = 80;
        //    grdView.Sheets[0].Columns[colNameT].Width = 200;
        //    grdView.Sheets[0].Columns[colNameE].Width = 200;
        //    grdView.Sheets[0].Columns[colRemark].Width = 200;

        //    grdView.Sheets[0].Columns[colID].Visible = false;
        //    grdView.Sheets[0].Columns[coledit].Visible = false;

        //    grdView.AllowColumnMove = true;
        //}

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล " , "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setStaff();
                xC.xtDB.stfDB.insertStaff(stf);
                //setGrdView();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            setEnable(true);
        }

        //private void grdView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        //{
        //    stf = xC.xtDB.stfDB.selectByPk1(grdView.Sheets[0].Cells[e.Row, colID].Value == null ? "" : grdView.Sheets[0].Cells[e.Row, colID].Value.ToString());
        //    setControl();
        //    setEnable(false);
        //}

        //private void setGrdView()
        //{
        //    DataTable dt = new DataTable();
        //    int i = 0;
        //    FarPoint.Win.Spread.Column columnobj;
        //    columnobj = grdView.ActiveSheet.Columns[colCode, colRemark];

        //    dt = xC.xtDB.stfDB.selectAll();
        //    grdView.Sheets[0].Rows.Clear();
        //    setGrdViewH();
        //    grdView.Sheets[0].RowCount = dt.Rows.Count + 1;
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        grdView.Sheets[0].Cells[i, colID].Value = row[xC.xtDB.stfDB.stf.staff_id] == null ? "" : row[xC.xtDB.stfDB.stf.staff_id].ToString();
        //        grdView.Sheets[0].Cells[i, colCode].Value = row[xC.xtDB.stfDB.stf.staff_code].ToString();
        //        grdView.Sheets[0].Cells[i, colNameT].Value = row[xC.xtDB.stfDB.stf.staff_fname_t].ToString()+" "+ row[xC.xtDB.stfDB.stf.staff_lname_t].ToString();
        //        grdView.Sheets[0].Cells[i, colNameE].Value = row[xC.xtDB.stfDB.stf.staff_fname_e].ToString()+" "+ row[xC.xtDB.stfDB.stf.staff_lname_e].ToString();
        //        grdView.Sheets[0].Cells[i, colRemark].Value = row[xC.xtDB.stfDB.stf.remark].ToString();

        //        grdView.Sheets[0].Cells[i, coledit].Value = "0";
        //        if (i % 2 != 0)
        //        {
        //            grdView.Sheets[0].Cells[i, 0, i, colCnt - 1].BackColor = System.Drawing.Color.FromArgb(235, 241, 222);
        //        }

        //        columnobj.Locked = true;

        //        i++;
        //    }
        //}
        private void setFocus()
        {
            this.txtStfCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtStfFNameT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtStfFNameE.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtEmail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtStfLNameT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtStfLNameE.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtMobile.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtPid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);            
            this.txtTele.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);            
            this.txtRemark.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtLogo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
        }
        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                C1TextBox a = (C1TextBox)sender;
                if (a.Name.Equals("txtStfCode"))
                {
                    txtStfFNameT.Focus();
                    return;
                }
                if (a.Name.Equals("txtStfFNameT"))
                {
                    txtStfLNameT.Focus();
                    return;
                }
                if (a.Name.Equals("txtStfLNameT"))
                {
                    txtTele.Focus();
                    return;
                }
                if (a.Name.Equals("txtTele"))
                {
                    txtMobile.Focus();
                    return;
                }
                if (a.Name.Equals("txtMobile"))
                {
                    txtEmail.Focus();
                    return;
                }
                if (a.Name.Equals("txtEmail"))
                {
                    txtRemark.Focus();
                    return;
                }
                if (a.Name.Equals("txtRemark"))
                {
                    txtPid.Focus();
                    return;
                }
                if (a.Name.Equals("txtPid"))
                {
                    txtLogo.Focus();
                    return;
                }
                if (a.Name.Equals("txtLogo"))
                {
                    btnOk.Focus();
                    return;
                }
                
            }

            //a.BackColor = Color.DarkCyan;txtZipCode
            //a.Font = new Font(ff, FontStyle.Bold);
        }
        private void setFocusColor()
        {
            this.txtStfCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtStfCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtStfLNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtStfLNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtStfLNameE.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtStfLNameE.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtStfFNameE.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtStfFNameE.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtStfFNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtStfFNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMobile.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMobile.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEmail.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEmail.Enter += new System.EventHandler(this.textBox_Enter);            

            this.txtLogo.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtLogo.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPid.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPid.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTele.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTele.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboDept.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboDept.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboPosi.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboPosi.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboPrefix.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboPrefix.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            if (sender is C1TextBox)
            {
                C1TextBox a = (C1TextBox)sender;
                a.BackColor = Color.DarkCyan;
                a.Font = new Font(ff, FontStyle.Bold);
            }
            else if (sender is ComboBox)
            {
                ComboBox a = (ComboBox)sender;
                a.BackColor = Color.DarkCyan;
                a.Font = new Font(ff, FontStyle.Bold);
            }

            //a.ForeColor = Color.Black;
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            if (sender is C1TextBox)
            {
                C1TextBox a = (C1TextBox)sender;
                a.BackColor = bg;
                a.ForeColor = fc;
                a.Font = new Font(ff, FontStyle.Regular);
            }
            else if (sender is ComboBox)
            {
                ComboBox a = (ComboBox)sender;
                a.BackColor = bg;
                a.ForeColor = fc;
                a.Font = new Font(ff, FontStyle.Regular);
            }
            
        }
        private void setControl()
        {
            //cop = xC.xtDB.copDB.selectByPk1(xC.copID);
            txtID.Value = stf.staff_id;
            txtStfCode.Value = stf.staff_code;
            txtStfFNameT.Value = stf.staff_fname_t;
            txtStfFNameE.Value = stf.staff_fname_e;
            txtEmail.Value = stf.email;
            txtStfLNameT.Value = stf.staff_lname_t;
            txtStfLNameE.Value = stf.staff_lname_e;
            txtMobile.Value = stf.mobile;
            txtPid.Value = stf.pid;
            txtTele.Value = stf.tele;
            txtRemark.Value = stf.remark;
            txtLogo.Value = stf.logo;
            
        }
        private void setStaff()
        {
            stf.staff_id = txtID.Value.ToString();
            stf.staff_code = txtStfCode.Value.ToString();
            stf.staff_fname_t = txtStfFNameT.Value.ToString();
            stf.staff_fname_e = txtStfFNameE.Value.ToString();
            stf.email = txtEmail.Value.ToString();
            stf.staff_lname_t = txtStfLNameT.Value.ToString();
            stf.staff_lname_e = txtStfLNameE.Value.ToString();
            stf.mobile = txtMobile.Value.ToString();
            stf.pid = txtPid.Value.ToString();
            stf.tele = txtTele.Value.ToString();
            stf.remark = txtRemark.Value.ToString();
            stf.logo = txtLogo.Value.ToString();
            //stf.remark = txtRemark.Value.ToString();
            //stf.logo = txtLogo.Value.ToString();
            //txtCopCode.Value = xC.xtDB.copDB.cop.comp_id;
        }
        private void setEnable(Boolean flag)
        {
            txtStfCode.Enabled = flag;
            txtID.Enabled = flag;
            txtStfFNameT.Enabled = flag;
            txtStfFNameE.Enabled = flag;
            txtEmail.Enabled = flag;
            txtStfLNameT.Enabled = flag;
            txtStfLNameE.Enabled = flag;
            txtMobile.Enabled = flag;
            txtPid.Enabled = flag;
            txtTele.Enabled = flag;
            txtRemark.Enabled = flag;
            txtLogo.Enabled = flag;
            
        }
        private void FrmStaff_Load(object sender, EventArgs e)
        {

        }
    }
}
