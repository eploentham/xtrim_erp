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
        ExpensesDrawDatail expndd;
        ExpensesClearCash ecc;

        Font fEdit, fEditB;
        Color bg, fc, cgrfOld;
        Font ff, ffB;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String eccid = "";
        DataTable dtImg = new DataTable();

        public FrmExpenseClearCash(XtrimControl x, String eccid)
        {
            InitializeComponent();
            xC = x;
            this.eccid = eccid;
            initConfig();
        }
        private void initConfig()
        {
            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            theme1.SetTheme(panel1, "VS2013Light");
            ecc = new ExpensesClearCash();

            setControl(eccid);

            foreach (Control c in panel1.Controls)
            {
                theme1.SetTheme(c, "VS2013Light");
            }           

        }
        private void setControl(String id)
        {
            txtId.Value = id;
            Items itm = new Items();
            expndd = new ExpensesDrawDatail();
            ecc = new ExpensesClearCash();
            ecc = xC.xtDB.eccDB.selectByPk1(id);
            //expndd = xC.xtDB.expnddDB.selectByPk1(ecc.expenses_draw_detail_id);
            //itm = xC.xtDB.itmDB.selectByPk1(ecc.item_id);
            //txtTableId.Value = expndd.expenses_draw_detail_id;
            txtRow.Value = ecc.row1;
            txtRcpAmt.Value = ecc.pay_amount;
            txtRcpNum.Value = ecc.receipt_no;
            txtRcpDate.Value = ecc.receipt_date;
            txtItmCode.Value = ecc.item_code;
            txtItmNameT.Value = ecc.item_name_t;
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
