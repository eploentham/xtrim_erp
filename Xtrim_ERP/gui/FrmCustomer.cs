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
using Xtrim_ERP.Properties;

namespace Xtrim_ERP.gui
{
    public partial class FrmCustomer : Form
    {
        Customer cus;
        XtrimControl xC;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        int colID = 0, colE = 1, colS = 2, colCode = 3, colNameT = 4, colNameE = 5, colRemark = 6, coledit = 7;
        int colCnt = 8;

        Boolean flagEdit = false;

        public FrmCustomer(XtrimControl x)
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

            ContextMenu custommenu = new ContextMenu();
            custommenu.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_void));
            //custommenu.MenuItems.Add("&ยกเลิก";
            grdView.ContextMenu = custommenu;
            setFocusColor();
            setGrdView();
            //setFocusColor();
            setFocus();
            tabPage1.Text = "รายละเอียด";
            tabPage2.Text = "ที่อยู่ address";
        }
        private void setGrdViewH()
        {
            FarPoint.Win.Spread.EnhancedInterfaceRenderer outlinelook = new FarPoint.Win.Spread.EnhancedInterfaceRenderer();
            outlinelook.RangeGroupBackgroundColor = Color.LightGreen;
            outlinelook.RangeGroupButtonBorderColor = Color.Red;
            outlinelook.RangeGroupLineColor = Color.Blue;
            grdView.InterfaceRenderer = outlinelook;
            grdView.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

            grdView.BorderStyle = BorderStyle.None;
            grdView.Sheets[0].Columns[colCode, colRemark].AllowAutoFilter = true;
            grdView.Sheets[0].Columns[colCode, colRemark].AllowAutoSort = true;
            grdView.Sheets[0].AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu;

            FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttoncell = new FarPoint.Win.Spread.CellType.ButtonCellType();

            grdView.Sheets[0].ColumnCount = colCnt;
            grdView.Sheets[0].RowCount = 1;
            grdView.Font = fEdit;

            grdView.Sheets[0].Columns[colID].CellType = objTextCell;
            grdView.Sheets[0].Columns[colE].CellType = buttoncell;
            grdView.Sheets[0].Columns[colS].CellType = buttoncell;
            grdView.Sheets[0].Columns[colCode].CellType = objTextCell;
            grdView.Sheets[0].Columns[colNameT].CellType = objTextCell;
            grdView.Sheets[0].Columns[colNameE].CellType = objTextCell;
            grdView.Sheets[0].Columns[colRemark].CellType = objTextCell;
            grdView.Sheets[0].Columns[coledit].CellType = objTextCell;

            grdView.Sheets[0].ColumnHeader.Cells[0, colE].Text = "edit";
            grdView.Sheets[0].ColumnHeader.Cells[0, colS].Text = "save";
            grdView.Sheets[0].ColumnHeader.Cells[0, colCode].Text = "code";
            grdView.Sheets[0].ColumnHeader.Cells[0, colNameT].Text = "ชื่อภาษาไทย";
            grdView.Sheets[0].ColumnHeader.Cells[0, colNameE].Text = "ชื่อภาษาอังกฤษ";
            grdView.Sheets[0].ColumnHeader.Cells[0, colRemark].Text = "หมายเหตุ";

            grdView.Sheets[0].Columns[colE].Width = 50;
            grdView.Sheets[0].Columns[colS].Width = 50;
            grdView.Sheets[0].Columns[colCode].Width = 80;
            grdView.Sheets[0].Columns[colNameT].Width = 200;
            grdView.Sheets[0].Columns[colNameE].Width = 200;
            grdView.Sheets[0].Columns[colRemark].Width = 200;

            grdView.Sheets[0].Columns[colID].Visible = false;
            grdView.Sheets[0].Columns[coledit].Visible = false;

            grdView.AllowColumnMove = true;
        }
        private void setGrdView()
        {
            DataTable dt = new DataTable();
            int i = 0;
            FarPoint.Win.Spread.Column columnobj;
            columnobj = grdView.ActiveSheet.Columns[colCode, colRemark];

            dt = xC.xtDB.cusDB.selectAll();
            grdView.Sheets[0].Rows.Clear();
            setGrdViewH();
            grdView.Sheets[0].RowCount = dt.Rows.Count + 1;
            foreach (DataRow row in dt.Rows)
            {
                grdView.Sheets[0].Cells[i, colID].Value = row[xC.xtDB.cusDB.cus.cust_id] == null ? "" : row[xC.xtDB.cusDB.cus.cust_id].ToString();
                grdView.Sheets[0].Cells[i, colCode].Value = row[xC.xtDB.cusDB.cus.cust_code].ToString();
                grdView.Sheets[0].Cells[i, colNameT].Value = row[xC.xtDB.cusDB.cus.cust_name_t].ToString();
                grdView.Sheets[0].Cells[i, colNameE].Value = row[xC.xtDB.cusDB.cus.cust_name_e].ToString();
                grdView.Sheets[0].Cells[i, colRemark].Value = row[xC.xtDB.cusDB.cus.remark].ToString();

                grdView.Sheets[0].Cells[i, coledit].Value = "0";
                if (i % 2 != 0)
                {
                    grdView.Sheets[0].Cells[i, 0, i, colCnt - 1].BackColor = System.Drawing.Color.FromArgb(235, 241, 222);
                }

                columnobj.Locked = true;

                i++;
            }
        }
        private void setFocus()
        {
            this.txtCusCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtCusNameT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtCusNameE.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtEmail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtAddr1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtAddr2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtAddr3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtAddr4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtTele.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);

            this.txtFax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtEmail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtTaxId.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtRemark.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtRemark2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtContactName1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtContactName2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            
        }
        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                C1TextBox a = (C1TextBox)sender;
                if (a.Name.Equals("txtCusCode"))
                {
                    txtCusNameT.Focus();
                    return;
                }
                if (a.Name.Equals("txtCusNameT"))
                {
                    txtCusNameE.Focus();
                    return;
                }
                if (a.Name.Equals("txtCusNameE"))
                {
                    txtEmail.Focus();
                    return;
                }
                if (a.Name.Equals("txtEmail"))
                {
                    txtAddr1.Focus();
                    return;
                }
                if (a.Name.Equals("txtAddr1"))
                {
                    txtAddr2.Focus();
                    return;
                }
                if (a.Name.Equals("txtAddr2"))
                {
                    txtAddr3.Focus();
                    return;
                }
                if (a.Name.Equals("txtAddr3"))
                {
                    txtAddr4.Focus();
                    return;
                }
                if (a.Name.Equals("txtAddr4"))
                {
                    txtTele.Focus();
                    return;
                }
                if (a.Name.Equals("txtTele"))
                {
                    txtFax.Focus();
                    return;
                }
                if (a.Name.Equals("txtFax"))
                {
                    txtEmail.Focus();
                    return;
                }
                if (a.Name.Equals("txtEmail"))
                {
                    txtFax.Focus();
                    return;
                }
                if (a.Name.Equals("txtFax"))
                {
                    txtTaxId.Focus();
                    return;
                }
                if (a.Name.Equals("txtTaxId"))
                {
                    txtRemark.Focus();
                    return;
                }
                if (a.Name.Equals("txtRemark"))
                {
                    txtRemark2.Focus();
                    return;
                }
                if (a.Name.Equals("txtRemark2"))
                {
                    txtContactName1.Focus();
                    return;
                }
                if (a.Name.Equals("txtContactName1"))
                {
                    txtContactName2.Focus();
                    return;
                }
                if (a.Name.Equals("txtContactName2"))
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
            this.txtCusCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCusCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCusNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCusNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCusNameE.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCusNameE.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEmail.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEmail.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAddr1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAddr1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAddr2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAddr2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAddr3.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAddr3.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAddr4.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAddr4.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTele.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTele.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtFax.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtFax.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEmail.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEmail.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTaxId.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTaxId.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContactName1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContactName1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContactName2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContactName2.Enter += new System.EventHandler(this.textBox_Enter);
            
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = Color.DarkCyan;
            a.Font = new Font(ff, FontStyle.Bold);

            //a.ForeColor = Color.Black;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = bg;
            a.ForeColor = fc;
            a.Font = new Font(ff, FontStyle.Regular);
        }
        private void setControl()
        {
            //cop = xC.xtDB.copDB.selectByPk1(xC.copID);
            txtID.Value = cus.cust_id;
            txtCusCode.Value = cus.cust_code;
            txtCusNameT.Value = cus.cust_name_t;
            txtCusNameE.Value = cus.cust_name_e;
            txtEmail.Value = cus.email;
            txtAddr1.Value = cus.taddr1;
            txtAddr2.Value = cus.taddr2;
            txtAddr3.Value = cus.taddr3;
            txtAddr4.Value = cus.taddr4;
            txtTele.Value = cus.tele;
            txtFax.Value = cus.fax;
            txtEmail.Value = cus.email;
            txtTaxId.Value = cus.tax_id;
            txtRemark.Value = cus.remark;
            txtRemark2.Value = cus.remark2;
            txtContactName1.Value = cus.contact_name1;
            txtContactName2.Value = cus.contact_name2;
            btnOk.Image = Resources.database48;

        }
        private void setCustomer()
        {
            cus.cust_id = txtID.Value.ToString();
            cus.cust_code = txtCusCode.Value.ToString();
            cus.cust_name_t = txtCusNameT.Value.ToString();
            cus.cust_name_e = txtCusNameE.Value.ToString();
            cus.email = txtEmail.Value.ToString();
            cus.taddr1 = txtAddr1.Value.ToString();
            cus.taddr2 = txtAddr2.Value.ToString();
            cus.taddr3 = txtAddr3.Value.ToString();
            cus.taddr4 = txtAddr4.Value.ToString();
            cus.tele = txtTele.Value.ToString();
            cus.fax = txtFax.Value.ToString();
            cus.email = txtEmail.Value.ToString();
            cus.tax_id = txtTaxId.Value.ToString();
            cus.remark = txtRemark.Value.ToString();
            cus.remark2 = txtRemark2.Value.ToString();
            cus.contact_name1 = txtContactName1.Value.ToString();
            cus.contact_name2 = txtContactName2.Value.ToString();
            
        }
        private void setEnable(Boolean flag)
        {
            txtCusCode.Enabled = flag;
            txtID.Enabled = flag;
            txtCusNameT.Enabled = flag;
            txtCusNameE.Enabled = flag;            
            txtEmail.Enabled = flag;
            txtAddr1.Enabled = flag;
            txtAddr2.Enabled = flag;
            txtAddr3.Enabled = flag;
            txtAddr4.Enabled = flag;

            txtTele.Enabled = flag;
            txtFax.Enabled = flag;
            txtEmail.Enabled = flag;
            txtTaxId.Enabled = flag;
            txtRemark.Enabled = flag;
            txtRemark2.Enabled = flag;
            txtContactName1.Enabled = flag;
            txtContactName2.Enabled = flag;

            if (flag)
            {
                btnEdit.Image = Resources.open48;
            }
            else
            {
                btnEdit.Image = Resources.lock48;
            }
            //flag == true ? btnEdit.Image = Resources.open48 : btnEdit.Image = Resources.open48;
            //btnEdit.Image = Resources.open48;
            
        }
        private void ContextMenu_void(object sender, System.EventArgs e)
        {
            FarPoint.Win.Spread.Row row = grdView.ActiveSheet.ActiveRow;
            FarPoint.Win.Spread.Column c;
            c = grdView.ActiveSheet.ActiveColumn;
            String aa = grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colCode].Value == null ? "" : grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colCode].Value.ToString();
            if (MessageBox.Show("ต้องการ ยกเลิก \nรายการ" + aa, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String re = xC.xtDB.banDB.voidBank(grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colID].Value == null ? "" : grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colID].Value.ToString());
                if (re.Equals("1"))
                {
                    grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[grdView.ActiveSheet.ActiveRow.Index, 0, grdView.ActiveSheet.ActiveRow.Index, colCnt - 1].BackColor = Color.Gray;
                }
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setCustomer();
                String re = xC.xtDB.cusDB.insertCustomer(cus);
                int chk = 0;
                if(int.TryParse(re, out chk))
                {
                    btnOk.Image = Resources.Accept_database48;
                }
                else
                {
                    btnOk.Image = Resources.Accept_database48;
                }
                setGrdView();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            flagEdit = flagEdit ? false : true;
            setEnable(flagEdit);
        }

        private void grdView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            cus = xC.xtDB.cusDB.selectByPk1(grdView.Sheets[0].Cells[e.Row, colID].Value == null ? "" : grdView.Sheets[0].Cells[e.Row, colID].Value.ToString());
            setControl();
            setEnable(false);
        }
        private void FrmCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
