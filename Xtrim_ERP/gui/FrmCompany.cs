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
    public partial class FrmCompany : Form
    {
        Company cop;
        XtrimControl xC;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        int colID = 0, colE = 1, colS = 2, colCode = 3, colNameT = 4, colNameE = 5, colRemark = 6, coledit = 7;
        int colCnt = 8;

        public FrmCompany(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            cop = new Company();

            bg = txtCopCode.BackColor;
            fc = txtCopCode.ForeColor;
            ff = txtCopCode.Font;

            ContextMenu custommenu = new ContextMenu();
            custommenu.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_void));
            //custommenu.MenuItems.Add("&ยกเลิก";
            grdView.ContextMenu = custommenu;
            setFocusColor();
            setGrdView();
            setFocusColor();
            setFocus();
        }

        private void grdView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            cop = xC.xtDB.copDB.selectByPk1(grdView.Sheets[0].Cells[e.Row, colID].Value == null ? "" : grdView.Sheets[0].Cells[e.Row, colID].Value.ToString());
            setControl();
            setEnable(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            setEnable(true);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล " , "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setCompany();
                xC.xtDB.copDB.insertCompany(cop);
                setGrdView();
            }
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

            dt = xC.xtDB.copDB.selectAll();
            grdView.Sheets[0].Rows.Clear();
            setGrdViewH();
            grdView.Sheets[0].RowCount = dt.Rows.Count + 1;
            foreach (DataRow row in dt.Rows)
            {
                grdView.Sheets[0].Cells[i, colID].Value = row[xC.xtDB.copDB.cop.comp_id] == null ? "" : row[xC.xtDB.copDB.cop.comp_id].ToString();
                grdView.Sheets[0].Cells[i, colCode].Value = row[xC.xtDB.copDB.cop.comp_code].ToString();
                grdView.Sheets[0].Cells[i, colNameT].Value = row[xC.xtDB.copDB.cop.comp_name_t].ToString();
                grdView.Sheets[0].Cells[i, colNameE].Value = row[xC.xtDB.copDB.cop.comp_name_e].ToString();
                grdView.Sheets[0].Cells[i, colRemark].Value = row[xC.xtDB.copDB.cop.remark].ToString();

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
            this.txtCopCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtCopNameT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtCopAddressT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtEmail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtTAddr1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtTAddr2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtTAddr3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtTAddr4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtVat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);

            this.txtEAddr1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtEAddr2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtEAddr3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtEAddr4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtZipCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtTele.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtFax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtCopNameE.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtCopAddressE.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtTaxId.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtRemark.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtWebSite.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtLogo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
        }
        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                C1TextBox a = (C1TextBox)sender;
                if (a.Name.Equals("txtCopCode"))
                {
                    txtCopNameT.Focus();
                    return;
                }
                if (a.Name.Equals("txtCopNameT"))
                {
                    txtCopAddressT.Focus();
                    return;
                }
                if (a.Name.Equals("txtCopAddressT"))
                {
                    txtTAddr1.Focus();
                    return;
                }
                if (a.Name.Equals("txtTAddr1"))
                {
                    txtTAddr2.Focus();
                    return;
                }
                if (a.Name.Equals("txtTAddr2"))
                {
                    txtTAddr3.Focus();
                    return;
                }
                if (a.Name.Equals("txtTAddr3"))
                {
                    txtTAddr4.Focus();
                    return;
                }
                if (a.Name.Equals("txtTAddr3"))
                {
                    txtTAddr4.Focus();
                    return;
                }
                if (a.Name.Equals("txtTAddr3"))
                {
                    txtTAddr4.Focus();
                    return;
                }
                if (a.Name.Equals("txtTAddr4"))
                {
                    txtZipCode.Focus();
                    return;
                }
                if (a.Name.Equals("txtZipCode"))
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
                    txtCopNameE.Focus();
                    return;
                }
                if (a.Name.Equals("txtCopNameE"))
                {
                    txtCopAddressE.Focus();
                    return;
                }
                if (a.Name.Equals("txtCopAddressE"))
                {
                    txtEAddr1.Focus();
                    return;
                }
                if (a.Name.Equals("txtEAddr1"))
                {
                    txtEAddr2.Focus();
                    return;
                }
                if (a.Name.Equals("txtEAddr2"))
                {
                    txtEAddr3.Focus();
                    return;
                }
                if (a.Name.Equals("txtEAddr3"))
                {
                    txtEAddr4.Focus();
                    return;
                }
                if (a.Name.Equals("txtEAddr4"))
                {
                    txtTaxId.Focus();
                    return;
                }
                if (a.Name.Equals("txtTaxId"))
                {
                    txtVat.Focus();
                    return;
                }
                if (a.Name.Equals("txtVat"))
                {
                    txtRemark.Focus();
                    return;
                }
                if (a.Name.Equals("txtRemark"))
                {
                    txtEmail.Focus();
                    return;
                }
                if (a.Name.Equals("txtEmail"))
                {
                    txtWebSite.Focus();
                    return;
                }
                if (a.Name.Equals("txtWebSite"))
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
            this.txtCopCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCopCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCopAddressE.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCopAddressE.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCopAddressT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCopAddressT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCopNameE.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCopNameE.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCopNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCopNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEAddr1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEAddr1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEAddr2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEAddr2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEAddr3.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEAddr3.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEAddr4.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEAddr4.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTAddr1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTAddr1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTAddr2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTAddr2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTAddr3.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTAddr3.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTAddr4.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTAddr4.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEmail.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEmail.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtFax.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtFax.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtLogo.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtLogo.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTaxId.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTaxId.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTele.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTele.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtVat.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtVat.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtWebSite.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtWebSite.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtZipCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtZipCode.Enter += new System.EventHandler(this.textBox_Enter);
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
            txtID.Value = cop.comp_id;
            txtCopCode.Value = cop.comp_code;
            txtCopNameE.Value = cop.comp_name_e;
            txtCopNameT.Value = cop.comp_name_t;
            txtTAddr1.Value = cop.taddr1;
            txtTAddr2.Value = cop.taddr2;
            txtTAddr3.Value = cop.taddr3;
            txtTAddr4.Value = cop.taddr4;
            txtEAddr1.Value = cop.eaddr1;
            txtEAddr2.Value = cop.eaddr2;
            txtEAddr3.Value = cop.eaddr3;
            txtEAddr4.Value = cop.eaddr4;
            txtRemark.Value = cop.remark;
            txtLogo.Value = cop.logo;
            txtWebSite.Value = cop.website;
            txtEmail.Value = cop.email;
            txtFax.Value = cop.fax;
            txtTele.Value = cop.tele;
            //cboDist.Value = cop.comp_id;
            //cbpAmph.Value = cop.comp_id;
            //cboProv.Value = cop.comp_id;
            //txtEAddr1.Value = cop.comp_id;
            txtCopAddressE.Value = cop.comp_address_e;
            txtVat.Value = cop.vat;
            txtTaxId.Value = cop.tax_id;
            txtZipCode.Value = cop.zipcode;
            //txtTAddr1.Value = cop.comp_id;
            txtCopAddressT.Value = cop.comp_address_t;            
            
            //txtCopCode.Value = cop.comp_id;
        }
        private void setCompany()
        {
            cop.comp_id = txtID.Value.ToString();
            cop.comp_code = txtCopCode.Value.ToString();
            cop.comp_name_e = txtCopNameE.Value.ToString();
            cop.comp_name_t = txtCopNameT.Value.ToString();
            cop.taddr1 = txtTAddr1.Value.ToString();
            cop.taddr2 = txtTAddr2.Value.ToString();
            cop.taddr3 = txtTAddr3.Value.ToString();
            cop.taddr4 = txtTAddr4.Value.ToString();
            cop.eaddr1 = txtEAddr1.Value.ToString();
            cop.eaddr2 = txtEAddr2.Value.ToString();
            cop.eaddr3 = txtEAddr3.Value.ToString();
            cop.eaddr4 = txtEAddr4.Value.ToString();
            cop.remark = txtRemark.Value.ToString();
            cop.logo = txtLogo.Value.ToString();
            cop.website = txtWebSite.Value.ToString();
            cop.email = txtEmail.Value.ToString();
            cop.fax = txtFax.Value.ToString();
            cop.tele = txtTele.Value.ToString();
            //cboDist.Value = cop.comp_id;
            //cbpAmph.Value = cop.comp_id;
            //cboProv.Value = cop.comp_id;
            //txtEAddr1.Value = cop.comp_id;
            cop.comp_address_e = txtCopAddressE.Value.ToString();
            cop.vat = txtVat.Value.ToString();
            cop.tax_id = txtTaxId.Value.ToString();
            cop.zipcode = txtZipCode.Value.ToString();
            //txtTAddr1.Value = cop.comp_id;
            cop.comp_address_t = txtCopAddressT.Value.ToString();


            //txtCopCode.Value = xC.xtDB.copDB.cop.comp_id;
        }
        private void setEnable(Boolean flag)
        {
            txtCopCode.Enabled = flag;
            txtID.Enabled = flag;
            txtCopCode.Enabled = flag;
            txtCopNameE.Enabled = flag;
            txtCopNameT.Enabled = flag;
            txtTAddr1.Enabled = flag;
            txtTAddr2.Enabled = flag;
            txtTAddr3.Enabled = flag;
            txtTAddr4.Enabled = flag;
            txtEAddr1.Enabled = flag;
            txtEAddr2.Enabled = flag;
            txtEAddr3.Enabled = flag;
            txtEAddr4.Enabled = flag;
            txtRemark.Enabled = flag;
            txtLogo.Enabled = flag;
            txtWebSite.Enabled = flag;
            txtEmail.Enabled = flag;
            txtFax.Enabled = flag;
            txtTele.Enabled = flag;
            //cboDist.Value = cop.comp_id;
            //cbpAmph.Value = cop.comp_id;
            //cboProv.Value = cop.comp_id;
            //txtEAddr1.Value = cop.comp_id;
            txtCopAddressE.Enabled = flag;
            txtVat.Enabled = flag;
            txtTaxId.Enabled = flag;
            txtZipCode.Enabled = flag;
            //txtTAddr1.Value = cop.comp_id;
            txtCopAddressT.Enabled = flag;
        }

        private void FrmCompany_Load(object sender, EventArgs e)
        {

        }
    }
}
