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

namespace Xtrim_ERP.gui
{
    public partial class FrmExpenseClearCash : Form
    {
        XtrimControl xC;
        ExpensesPayDetail expnpd;
        ExpensesClearCash ecc;

        Font fEdit, fEditB;
        Color bg, fc, cgrfOld;
        Font ff, ffB;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String eccid = "", itmPd="", pdid="", jobcode="", rowno;
        DataTable dtImg = new DataTable();

        public FrmExpenseClearCash(XtrimControl x, String eccid, String pdid, String itmNameTPd, String jobcode, String rowno)
        {
            InitializeComponent();
            xC = x;
            itmPd = itmNameTPd;
            this.eccid = eccid;
            this.pdid = pdid;
            this.jobcode = jobcode;
            this.rowno = rowno;
            initConfig();
        }
        private void initConfig()
        {
            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            theme1.SetTheme(panel1, "VS2013Light");
            ecc = new ExpensesClearCash();
            expnpd = new ExpensesPayDetail();

            btnSave.Click += BtnSave_Click;
            txtItmNameT.KeyUp += TxtItmNameT_KeyUp;

            setControl(eccid);

            foreach (Control c in panel1.Controls)
            {
                theme1.SetTheme(c, "VS2013Light");
            }           

        }

        private void TxtItmNameT_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.F2)
            {
                setKeyUpF2Itm();
            }
        }
        private void setKeyUpF2Itm()
        {
            Point pp = txtItmNameT.Location;
            pp.Y = pp.Y + 120 + 20;
            pp.X = pp.X - 20;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Items, pp);
            frm.ShowDialog(this);
            setKeyUpF2Itm1(xC.sItm);
        }
        private void setKeyUpF2Itm1(Items itm)
        {
            txtItmNameT.Value = itm.item_name_t;
            txtItmId.Value = itm.item_id;
            txtItmCode.Value = itm.item_code;
        }
        private void setControl(String id)
        {
            Items itm = new Items();
            expnpd = new ExpensesPayDetail();
            ecc = new ExpensesClearCash();
            JobImport jim = new JobImport();
            ecc = xC.xtDB.eccDB.selectByPk1(id);
            expnpd = xC.xtDB.expnpdDB.selectByPk1(pdid);
            if (ecc.expense_clear_cash_id.Equals(""))
            {
                jim = xC.xtDB.jimDB.selectByJobCode(jobcode);
            }
            txtItmNamePd.Value = itmPd;
            txtId.Value = ecc.expense_clear_cash_id;
            txtJobId.Value = ecc.job_id.Equals("") ? jim.job_import_id : ecc.job_id;
            txtJobCode.Value = ecc.job_code.Equals("") ? jobcode : ecc.job_code;
            txtPdId.Value = ecc.expenses_pay_detail_id.Equals("") ? pdid : ecc.expenses_pay_detail_id;
            txtStfId.Value = ecc.staff_id.Equals("") ? xC.userId : ecc.staff_id;
            txtddId.Value = ecc.expenses_draw_detail_id.Equals("") ? expnpd.expenses_draw_detail_id : ecc.expenses_draw_detail_id;
            //txtdid.Value = ecc.expenses_draw_id.Equals("") ? jim.job_import_id : ecc.expenses_draw_id;
            int row = 0, chk=0;
            int.TryParse(rowno, out chk);
            //chk++;
            txtRow.Value = chk;
            txtReceiptNo.Value = ecc.receipt_no;
            txtReceiptDate.Value = ecc.receipt_date;
            txtItmId.Value = ecc.item_id;
            txtItmCode.Value = ecc.item_code;
            txtItmNameT.Value = ecc.item_name_t;            
            
            txtPayAmt.Value = ecc.pay_amount;
            
            //txtItmCode.Value = ecc.item_code;
            
            setImages(txtId.Text);
        }
        private void setImages(String id)
        {
            Images img = new Images();

            dtImg = xC.xtDB.imgDB.selectByTableId(id);
            int i = 0, gapX = 0, gapY = 0, x = 3, y = 3;
            Point btnsize = new Point(42, 45);
            gapX = 48;
            gapY = 51;
            x = 3;
            y = 3;
            foreach (DataRow row in dtImg.Rows)
            {
                C1Button btnImg = new C1Button();
                btnImg.Image = global::Xtrim_ERP.Properties.Resources.PrintPreview_large;
                btnImg.Location = new System.Drawing.Point(x, y);
                btnImg.Name = "btnImg" + i;
                btnImg.Size = new System.Drawing.Size(btnsize);
                btnImg.TabIndex = 500;
                btnImg.Text = "";
                btnImg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                theme1.SetTheme(btnImg, "VS2013Light");
                btnImg.UseVisualStyleBackColor = true;
                btnImg.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
                btnImg.Click += BtnImg_Click;
                if (i < 6)
                {
                    x += gapX;
                    //y += gapY;
                }
                else if (i == 6)
                {
                    x = 3;
                    y = 54;
                }
                else
                {
                    x += gapX;
                    //y += gapY;
                }

                panel2.Controls.Add(btnImg);
                i++;
            }
        }
        private Boolean setEcc()
        {
            Boolean chk = true;
            ecc = new ExpensesClearCash();
            if (txtId.Text.Equals(""))
            {

            }
            ecc = xC.xtDB.eccDB.selectByPk1(txtId.Text);
            ecc.expense_clear_cash_id = txtId.Text;
            ecc.expenses_pay_detail_id = txtPdId.Text;
            ecc.job_id = txtJobId.Text;
            ecc.job_code = txtJobCode.Text;
            ecc.expenses_draw_detail_id = txtddId.Text;
            ecc.staff_id = txtStfId.Text;

            ecc.active = "1";
            ecc.date_create = "";
            ecc.date_modi = "";
            ecc.date_cancel = "";
            ecc.user_create = "";
            ecc.user_modi = "";
            ecc.user_cancel = "";

            ecc.expenses_draw_id = "";
            ecc.remark = txtRemark.Text;
            ecc.ecc_doc = "";
            ecc.expense_clear_cash_date = "";
            ecc.item_id = txtItmId.Text;
            ecc.item_name_t = txtItmNameT.Text;

            ecc.pay_amount = txtPayAmt.Text.Replace("$","").Replace(",","");
            ecc.pay_date = "";
            ecc.qty = "";
            ecc.price = "";
            ecc.unit_id = "";
            ecc.unit_name_t = "";
            ecc.vat = "";
            ecc.total = "";
            ecc.receipt_date = xC.datetoDB(txtReceiptDate.Text);
            ecc.receipt_no = txtReceiptNo.Text;
            ecc.pay_to_cus_id = "";
            ecc.pay_to_cus_name_t = "";
            ecc.pay_to_cus_addr = "";
            ecc.pay_to_cus_tax = "";
            ecc.pay_staff_id = txtStfId.Text;
            ecc.row1 = txtRow.Text;
            ecc.item_code = txtItmCode.Text;
            return chk;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setEcc();
                //xC.sEcc = ecc;
                xC.xtDB.eccDB.insertExpenseReceiptCash(ecc, xC.userId);
            }
        }
        private void BtnImg_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (((C1Button)sender).Name.Equals("btnImg0"))
            {
                String id = "";
                if (dtImg.Rows[0][xC.xtDB.imgDB.img.image_id] == null) return;
                id = dtImg.Rows[0][xC.xtDB.imgDB.img.image_id].ToString();
                //MessageBox.Show("00000", "00000000");
                FrmImageView frm = new FrmImageView(xC, id);
                frm.ShowDialog(this);
                //MessageBox.Show("00000", "00000000");
            }
            else if (((C1Button)sender).Name.Equals("btnImg1"))
            {
                String id = "";
                if (dtImg.Rows[1][xC.xtDB.imgDB.img.image_id] == null) return;
                id = dtImg.Rows[1][xC.xtDB.imgDB.img.image_id].ToString();
                FrmImageView frm = new FrmImageView(xC, id);
                frm.ShowDialog(this);
            }
            else if (((C1Button)sender).Name.Equals("btnImg2"))
            {
                String id = "";
                if (dtImg.Rows[2][xC.xtDB.imgDB.img.image_id] == null) return;
                id = dtImg.Rows[2][xC.xtDB.imgDB.img.image_id].ToString();
                FrmImageView frm = new FrmImageView(xC, id);
                frm.ShowDialog(this);
            }
            else if (((C1Button)sender).Name.Equals("btnImg3"))
            {
                String id = "";
                if (dtImg.Rows[3][xC.xtDB.imgDB.img.image_id] == null) return;
                id = dtImg.Rows[3][xC.xtDB.imgDB.img.image_id].ToString();
                FrmImageView frm = new FrmImageView(xC, id);
                frm.ShowDialog(this);
            }
            else if (((C1Button)sender).Name.Equals("btnImg4"))
            {
                String id = "";
                if (dtImg.Rows[4][xC.xtDB.imgDB.img.image_id] == null) return;
                id = dtImg.Rows[4][xC.xtDB.imgDB.img.image_id].ToString();
                FrmImageView frm = new FrmImageView(xC, id);
                frm.ShowDialog(this);
            }
            else if (((C1Button)sender).Name.Equals("btnImg5"))
            {
                String id = "";
                if (dtImg.Rows[5][xC.xtDB.imgDB.img.image_id] == null) return;
                id = dtImg.Rows[5][xC.xtDB.imgDB.img.image_id].ToString();
                FrmImageView frm = new FrmImageView(xC, id);
                frm.ShowDialog(this);
            }
            else if (((C1Button)sender).Name.Equals("btnImg6"))
            {
                String id = "";
                if (dtImg.Rows[6][xC.xtDB.imgDB.img.image_id] == null) return;
                id = dtImg.Rows[6][xC.xtDB.imgDB.img.image_id].ToString();
                FrmImageView frm = new FrmImageView(xC, id);
                frm.ShowDialog(this);
            }
            else if (((C1Button)sender).Name.Equals("btnImg7"))
            {
                String id = "";
                if (dtImg.Rows[7][xC.xtDB.imgDB.img.image_id] == null) return;
                id = dtImg.Rows[7][xC.xtDB.imgDB.img.image_id].ToString();
                FrmImageView frm = new FrmImageView(xC, id);
                frm.ShowDialog(this);
            }
            else if (((C1Button)sender).Name.Equals("btnImg8"))
            {
                String id = "";
                if (dtImg.Rows[8][xC.xtDB.imgDB.img.image_id] == null) return;
                id = dtImg.Rows[8][xC.xtDB.imgDB.img.image_id].ToString();
                FrmImageView frm = new FrmImageView(xC, id);
                frm.ShowDialog(this);
            }
            else if (((C1Button)sender).Name.Equals("btnImg9"))
            {
                String id = "";
                if (dtImg.Rows[9][xC.xtDB.imgDB.img.image_id] == null) return;
                id = dtImg.Rows[9][xC.xtDB.imgDB.img.image_id].ToString();
                FrmImageView frm = new FrmImageView(xC, id);
                frm.ShowDialog(this);
            }
            else if (((C1Button)sender).Name.Equals("btnImg10"))
            {
                String id = "";
                if (dtImg.Rows[10][xC.xtDB.imgDB.img.image_id] == null) return;
                id = dtImg.Rows[10][xC.xtDB.imgDB.img.image_id].ToString();
                FrmImageView frm = new FrmImageView(xC, id);
                frm.ShowDialog(this);
            }
            else if (((C1Button)sender).Name.Equals("btnImg11"))
            {
                String id = "";
                if (dtImg.Rows[11][xC.xtDB.imgDB.img.image_id] == null) return;
                id = dtImg.Rows[11][xC.xtDB.imgDB.img.image_id].ToString();
                FrmImageView frm = new FrmImageView(xC, id);
                frm.ShowDialog(this);
            }
            else if (((C1Button)sender).Name.Equals("btnImg12"))
            {
                String id = "";
                if (dtImg.Rows[12][xC.xtDB.imgDB.img.image_id] == null) return;
                id = dtImg.Rows[12][xC.xtDB.imgDB.img.image_id].ToString();
                FrmImageView frm = new FrmImageView(xC, id);
                frm.ShowDialog(this);
            }
        }
        private void FrmExpenseClearCash_Load(object sender, EventArgs e)
        {

        }
    }
}
