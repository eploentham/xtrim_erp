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
    public partial class FrmImporter : Form
    {
        Importer imp;
        XtrimControl xC;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        int colID = 0, colE = 1, colS = 2, colCode = 3, colNameT = 4, colNameE = 5, colRemark = 6, coledit = 7;
        int colCnt = 8;
        public FrmImporter(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            imp = new Importer();
            bg = txtImpCode.BackColor;
            fc = txtImpCode.ForeColor;
            ff = txtImpCode.Font;

            ContextMenu custommenu = new ContextMenu();
            custommenu.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_void));
            //custommenu.MenuItems.Add("&ยกเลิก";
            grdView.ContextMenu = custommenu;
            setFocusColor();
            setGrdView();
            setFocusColor();
            setFocus();
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

            dt = xC.xtDB.impDB.selectAll();
            grdView.Sheets[0].Rows.Clear();
            setGrdViewH();
            grdView.Sheets[0].RowCount = dt.Rows.Count + 1;
            foreach (DataRow row in dt.Rows)
            {
                grdView.Sheets[0].Cells[i, colID].Value = row[xC.xtDB.impDB.imp.imp_id] == null ? "" : row[xC.xtDB.cusDB.cus.cust_id].ToString();
                grdView.Sheets[0].Cells[i, colCode].Value = row[xC.xtDB.impDB.imp.imp_code].ToString();
                grdView.Sheets[0].Cells[i, colNameT].Value = row[xC.xtDB.impDB.imp.imp_name_t].ToString();
                grdView.Sheets[0].Cells[i, colNameE].Value = row[xC.xtDB.impDB.imp.imp_name_e].ToString();
                grdView.Sheets[0].Cells[i, colRemark].Value = row[xC.xtDB.impDB.imp.remark].ToString();

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
            this.txtImpCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtImpNameT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtImpNameE.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
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
                //C1TextBox a = (C1TextBox)sender;
                if (sender.Equals(txtImpCode))
                {
                    txtImpNameT.Focus();
                    return;
                }
                if (sender.Equals(txtImpNameT))
                {
                    txtImpNameE.Focus();
                    return;
                }
                if (sender.Equals(txtImpNameE))
                {
                    txtEmail.Focus();
                    return;
                }
                if (sender.Equals(txtEmail))
                {
                    txtAddr1.Focus();
                    return;
                }
                if (sender.Equals(txtAddr1))
                {
                    txtAddr2.Focus();
                    return;
                }
                if (sender.Equals(txtAddr2))
                {
                    txtAddr3.Focus();
                    return;
                }
                if (sender.Equals(txtAddr3))
                {
                    txtAddr4.Focus();
                    return;
                }
                if (sender.Equals(txtAddr4))
                {
                    txtTele.Focus();
                    return;
                }
                if (sender.Equals(txtTele))
                {
                    txtFax.Focus();
                    return;
                }
                if (sender.Equals(txtFax))
                {
                    txtEmail.Focus();
                    return;
                }
                if (sender.Equals(txtEmail))
                {
                    txtFax.Focus();
                    return;
                }
                if (sender.Equals(txtFax))
                {
                    txtTaxId.Focus();
                    return;
                }
                if (sender.Equals(txtTaxId))
                {
                    txtRemark.Focus();
                    return;
                }
                if (sender.Equals(txtRemark))
                {
                    txtRemark2.Focus();
                    return;
                }
                if (sender.Equals(txtRemark2))
                {
                    txtContactName1.Focus();
                    return;
                }
                if (sender.Equals(txtContactName1))
                {
                    txtContactName2.Focus();
                    return;
                }
                if (sender.Equals(txtContactName2))
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
            this.txtImpCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtImpCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtImpNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtImpNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtImpNameE.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtImpNameE.Enter += new System.EventHandler(this.textBox_Enter);

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
            txtID.Value = imp.imp_id;
            txtImpCode.Value = imp.imp_code;
            txtImpNameT.Value = imp.imp_name_t;
            txtImpNameE.Value = imp.imp_name_e;
            txtEmail.Value = imp.email;
            txtAddr1.Value = imp.taddr1;
            txtAddr2.Value = imp.taddr2;
            txtAddr3.Value = imp.taddr3;
            txtAddr4.Value = imp.taddr4;
            txtTele.Value = imp.tele;
            txtFax.Value = imp.fax;
            txtEmail.Value = imp.email;
            txtTaxId.Value = imp.tax_id;
            txtRemark.Value = imp.remark;
            txtRemark2.Value = imp.remark2;
            txtContactName1.Value = imp.contact_name1;
            txtContactName2.Value = imp.contact_name2;

        }
        private void setCustomer()
        {
            imp.imp_id = txtID.Value.ToString();
            imp.imp_code = txtImpCode.Value.ToString();
            imp.imp_name_t = txtImpNameT.Value.ToString();
            imp.imp_name_e = txtImpNameE.Value.ToString();
            imp.email = txtEmail.Value.ToString();
            imp.taddr1 = txtAddr1.Value.ToString();
            imp.taddr2 = txtAddr2.Value.ToString();
            imp.taddr3 = txtAddr3.Value.ToString();
            imp.taddr4 = txtAddr4.Value.ToString();
            imp.tele = txtTele.Value.ToString();
            imp.fax = txtFax.Value.ToString();
            imp.email = txtEmail.Value.ToString();
            imp.tax_id = txtTaxId.Value.ToString();
            imp.remark = txtRemark.Value.ToString();
            imp.remark2 = txtRemark2.Value.ToString();
            imp.contact_name1 = txtContactName1.Value.ToString();
            imp.contact_name2 = txtContactName2.Value.ToString();

        }
        private void setEnable(Boolean flag)
        {
            txtImpCode.Enabled = flag;
            txtID.Enabled = flag;
            txtImpNameT.Enabled = flag;
            txtImpNameE.Enabled = flag;
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
        private void btnEdit_Click(object sender, EventArgs e)
        {
            setEnable(true);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setCustomer();
                xC.xtDB.impDB.insertImporter(imp);
                setGrdView();
            }
        }

        private void grdView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            imp = xC.xtDB.impDB.selectByPk1(grdView.Sheets[0].Cells[e.Row, colID].Value == null ? "" : grdView.Sheets[0].Cells[e.Row, colID].Value.ToString());
            setControl();
            setEnable(false);
        }
        private void FrmImporter_Load(object sender, EventArgs e)
        {

        }
    }
}
