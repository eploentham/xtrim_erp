using C1.Win.C1FlexGrid;
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

namespace Xtrim_ERP.gui
{
    public partial class FrmCompany : Form
    {
        Company cop;
        XtrimControl xC;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        int colID = 1, colE = 1, colS = 2, colCode = 3, colNameT = 4, colNameE = 5, colRemark = 6, coledit = 7;
        int colCnt = 8;
        int colBID = 1, colBBnkNameT = 2, colBBnkBranch = 3, colBaccnumber = 4, colBRemark = 5, colBedit=6;

        C1FlexGrid grfCop, grfCopBnk;

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
            //custommenu.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_void));
            //custommenu.MenuItems.Add("&ยกเลิก";
            //grdView.ContextMenu = custommenu;
            setFocusColor();
            initGrfInvH();
            initGrfCopBnk();
            setGrfCopH();
            //setGrfCop();
            setFocus();
            theme1.SetTheme(sB, "BeigeOne");
            sB1.Text = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbb";
            
        }
        private void initGrfInvH()
        {
            grfCop = new C1FlexGrid();
            grfCop.Font = fEdit;
            grfCop.Dock = System.Windows.Forms.DockStyle.Fill;
            grfCop.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfCop);

            grfCop.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfCus_AfterRowColChange);
            //grfCop.DoubleClick += new System.EventHandler(this.grfCus_DoubleClick);

            panel1.Controls.Add(this.grfCop);
        }
        private void initGrfCopBnk()
        {
            grfCopBnk = new C1FlexGrid();
            grfCopBnk.Font = fEdit;
            grfCopBnk.Dock = System.Windows.Forms.DockStyle.Fill;
            grfCopBnk.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfCopBnk);

            grfCopBnk.AfterRowColChange += GrfCopBnk_AfterRowColChange;
            //grfCopBnk.DoubleClick += new System.EventHandler(this.grfCus_DoubleClick);

            panel2.Controls.Add(this.grfCopBnk);
        }

        private void GrfCopBnk_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.OldRange.c1 == colBaccnumber)
            {
                grfCopBnk[grfCopBnk.Row, colBedit] = "1";
                grfCopBnk.Rows.Count++;
            }
            //else if (e.OldRange.c1 == colBaccnumber)
            //{

            //}
        }

        private void grfCus_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String addrId = "";
            addrId = grfCop[e.NewRange.r1, colID] != null ? grfCop[e.NewRange.r1, colID].ToString() : "";
            setControl(addrId);
            //setControlAddrEnable(false);
        }
        private void grfCus_DoubleClick(object sender, EventArgs e)
        {
            //String addrId = "";
            //addrId = grfCop[grfCop.Row, colID].ToString();
        }
        //private void grdView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        //{
        //    cop = xC.xtDB.copDB.selectByPk1(grdView.Sheets[0].Cells[e.Row, colID].Value == null ? "" : grdView.Sheets[0].Cells[e.Row, colID].Value.ToString());
        //    setControl();
        //    setEnable(false);
        //}

        private void btnEdit_Click(object sender, EventArgs e)
        {
            setEnable(true);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล " , "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setCompany();
                String re = xC.xtDB.copDB.insertCompany(cop, xC.userId);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    for (int i = 1; i < grfCopBnk.Rows.Count; i++)
                    {
                        if (grfCopBnk[i, colBedit] == null) continue;
                        if (grfCopBnk[i, colBedit].ToString().Equals("1"))
                        {
                            CompanyBank copb = new CompanyBank();
                            copb.comp_bank_id = grfCopBnk[i, colBID] != null ? grfCopBnk[i, colBID].ToString() : "";
                            copb.comp_bank_name_t = grfCopBnk[i, colBBnkNameT] != null ? grfCopBnk[i, colBBnkNameT].ToString() : "";
                            copb.comp_bank_branch = grfCopBnk[i, colBBnkBranch] != null ? grfCopBnk[i, colBBnkBranch].ToString() : "";
                            copb.acc_number = grfCopBnk[i, colBaccnumber] != null ? grfCopBnk[i, colBaccnumber].ToString() : "";
                            copb.remark = grfCopBnk[i, colBRemark] != null ? grfCopBnk[i, colBRemark].ToString() : "";
                            copb.bank_id = xC.xtDB.bnkDB.getIdByName(copb.comp_bank_name_t);
                            copb.comp_id = txtID.Text;
                            xC.xtDB.copbDB.insertCompany(copb, xC.userId);
                        }
                    }
                }
                
                //setGrdView();
            }
        }
        private void setGrfCopH()
        {
            //grfCop.Cols.Count = colCnt;
            //grfCop.Rows.Count = 1;
            grfCop.DataSource = xC.xtDB.copDB.selectAll();
            grfCop.Cols[colID].Width = 60;
            grfCop.Cols[colE].Width = 60;
            grfCop.Cols[colS].Width = 60;
            grfCop.Cols[colCode].Width = 60;
            grfCop.Cols[colNameT].Width = 60;
            grfCop.Cols[colNameE].Width = 60;
            grfCop.Cols[colRemark].Width = 60;
            grfCop.Cols[coledit].Width = 60;

            grfCop.ShowCursor = true;

            //grfCop.Cols[colE].Caption = "edit";
            //grfCop.Cols[colS].Caption = "save";
            //grfCop.Cols[colCode].Caption = "รหัส";
            //grfCop.Cols[colNameT].Caption = "ชื่อไทย";
            //grfCop.Cols[colNameE].Caption = "name eng";
            //grfCop.Cols[colRemark].Caption = "หมายเหตุ";
            ////grfCop.Cols[colCode].Caption = "รหัส";
            ////grfCop.Cols[colCode].Caption = "รหัส";

            //grfCop.Cols[colID].Visible = false;
            //grfCop.Cols[coledit].Visible = false;
        }
        private void setGrfCop()
        {
            grfCop.DataSource = xC.xtDB.copDB.selectAll();
        }
        private void setGrfCopBnk(String copid)
        {
            grfCopBnk.Clear();
            DataTable dt = new DataTable();
            dt = xC.xtDB.copbDB.selectBankByCop(copid);
            grfCopBnk.Cols.Count = 7;
            grfCopBnk.Rows.Count = dt.Rows.Count + 2;

            C1TextBox txt = new C1TextBox();
            txt.DataType = txtCopCode.DataType;
            C1ComboBox cbo = new C1ComboBox();
            xC.xtDB.bnkDB.setC1CboItem(cbo);

            grfCopBnk.Cols[colBBnkNameT].Editor = cbo;
            grfCopBnk.Cols[colBBnkBranch].Editor = txt;
            grfCopBnk.Cols[colBaccnumber].Editor = txt;
            grfCopBnk.Cols[colBRemark].Editor = txt;

            grfCopBnk.Cols[colBBnkNameT].Caption = "ธนาคาร";
            grfCopBnk.Cols[colBBnkBranch].Caption = "สาขา";
            grfCopBnk.Cols[colBaccnumber].Caption = "เลขที่บัญชี";
            grfCopBnk.Cols[colBRemark].Caption = "หมยาเหตุ";

            grfCopBnk.Cols[colBID].Width = 60;
            grfCopBnk.Cols[colBBnkNameT].Width = 150;
            grfCopBnk.Cols[colBBnkBranch].Width = 150;
            grfCopBnk.Cols[colBaccnumber].Width = 100;
            grfCopBnk.Cols[colBRemark].Width = 200;

            //grfCopBnk.DataSource = dt;
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfCopBnk[i+1, 0] = i+1;
                if (i % 2 == 0)
                    grfCopBnk.Rows[i+1].StyleNew.BackColor = color;
                grfCopBnk[i + 1, colBID] = dt.Rows[i][xC.xtDB.copbDB.copB.comp_bank_id].ToString();
                grfCopBnk[i + 1, colBBnkNameT] = dt.Rows[i][xC.xtDB.copbDB.copB.comp_bank_name_t].ToString();
                grfCopBnk[i + 1, colBBnkBranch] = dt.Rows[i][xC.xtDB.copbDB.copB.comp_bank_branch].ToString();
                grfCopBnk[i + 1, colBaccnumber] = dt.Rows[i][xC.xtDB.copbDB.copB.acc_number].ToString();
                grfCopBnk[i + 1, colBRemark] = dt.Rows[i][xC.xtDB.copbDB.copB.remark].ToString();
                grfCopBnk[i + 1, colBedit] = "";
            }
            grfCopBnk.Cols[colBID].Visible = false;
            grfCopBnk.Cols[colBedit].Visible = false;
        }
        //private void ContextMenu_void(object sender, System.EventArgs e)
        //{
        //    FarPoint.Win.Spread.Row row = grdView.ActiveSheet.ActiveRow;
        //    FarPoint.Win.Spread.Column c;
        //    c = grdView.ActiveSheet.ActiveColumn;
        //    String aa = grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colCode].Value == null ? "" : grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colCode].Value.ToString();
        //    if (MessageBox.Show("ต้องการ ยกเลิก \nรายการ" + aa, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
        //    {
        //        String re = xC.xtDB.banDB.voidBank(grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colID].Value == null ? "" : grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colID].Value.ToString());
        //        if (re.Equals("1"))
        //        {
        //            grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[grdView.ActiveSheet.ActiveRow.Index, 0, grdView.ActiveSheet.ActiveRow.Index, colCnt - 1].BackColor = Color.Gray;
        //        }
        //    }
        //}
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
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colNameT].Text = "ชื่อภาษาไทย";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colNameE].Text = "ชื่อภาษาอังกฤษ";
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
        //private void setGrdView()
        //{
        //    DataTable dt = new DataTable();
        //    int i = 0;
        //    FarPoint.Win.Spread.Column columnobj;
        //    columnobj = grdView.ActiveSheet.Columns[colCode, colRemark];

        //    dt = xC.xtDB.copDB.selectAll();
        //    grdView.Sheets[0].Rows.Clear();
        //    setGrdViewH();
        //    grdView.Sheets[0].RowCount = dt.Rows.Count + 1;
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        grdView.Sheets[0].Cells[i, colID].Value = row[xC.xtDB.copDB.cop.comp_id] == null ? "" : row[xC.xtDB.copDB.cop.comp_id].ToString();
        //        grdView.Sheets[0].Cells[i, colCode].Value = row[xC.xtDB.copDB.cop.comp_code].ToString();
        //        grdView.Sheets[0].Cells[i, colNameT].Value = row[xC.xtDB.copDB.cop.comp_name_t].ToString();
        //        grdView.Sheets[0].Cells[i, colNameE].Value = row[xC.xtDB.copDB.cop.comp_name_e].ToString();
        //        grdView.Sheets[0].Cells[i, colRemark].Value = row[xC.xtDB.copDB.cop.remark].ToString();

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
            a.BackColor = xC.cTxtFocus;
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
        private void setControl(String copid)
        {
            if (copid.Equals("")) return;
            cop = xC.xtDB.copDB.selectByPk1(copid);
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
            setGrfCopBnk(txtID.Text);
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
