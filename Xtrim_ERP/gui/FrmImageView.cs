using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xtrim_ERP.control;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.gui
{
    public partial class FrmImageView : Form
    {
        XtrimControl xC;
        ExpensesDrawDatail expndd;
        Images img;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String imgId = "";
        MemoryStream stream;
        PictureBox pic1;

        public FrmImageView(XtrimControl x, String imgid)
        {
            InitializeComponent();
            xC = x;
            this.imgId = imgid;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            stream = new MemoryStream();
            img = new Images();
            pic1 = new PictureBox();
            img = xC.xtDB.imgDB.selectByPk1(imgId);
            //MessageBox.Show("111111 "+ img.job_id + "/" + img.image_name, "11111111");
            stream = xC.ftpC.download(img.job_id + "/" + img.image_name);
            if (stream == null) return;
            try
            {
                Image img1;
                img1 = Image.FromStream(stream);
                
                pic1.Image = Image.FromStream(stream);
                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                pic1.Dock = DockStyle.Fill;
                panel1.Controls.Add(pic1);

                //pic1.st
                this.Width = img1.Width + 5;
                this.Height = img1.Height + 5;

                ContextMenu menuGw = new ContextMenu();
                menuGw.MenuItems.Add("&ยกเลิกภาพนี้", new EventHandler(ContextMenu_pay));
                pic1.ContextMenu = menuGw;
            }
            catch (Exception ex)
            {
                Label lb = new Label();
                lb.Text = "ภาพนี้เสีย";
                lb.ForeColor = Color.Red;
                //lb.Font.Size = xC.iniC.grdViewFontSize
                panel1.Controls.Add(lb);
                ContextMenu menuGw = new ContextMenu();
                menuGw.MenuItems.Add("&ยกเลิกภาพนี้", new EventHandler(ContextMenu_pay));
                this.ContextMenu = menuGw;
            }
            

            //theme1.Theme = C1ThemeController.ApplicationTheme;
            //theme1.SetTheme(sB, "BeigeOne");
            //expndd = new ExpensesDrawDatail();
            //expndd = xC.xtDB.expnddDB.selectByPk1(tableId);
            //txtTableId.Value = expndd.expenses_draw_detail_id;
            //txtItmNameT.Value = expndd.item_name_t;
            //txtJobId.Value = expndd.job_id;

            
        }
        private void ContextMenu_pay(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("ต้องการ ยกเลิกภาพนี้  \n ยกเลิก  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String re = xC.xtDB.imgDB.voidImage(img.image_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    Close();
                }
            }
        }
        private void FrmImageView_Load(object sender, EventArgs e)
        {

        }
    }
}
