using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xtrim_ERP.control;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.gui
{
    public partial class FrmImages : Form
    {
        XtrimControl xC;
        ExpensesDrawDatail expndd;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        C1FlexGrid grfImg;

        int colPath = 1, colRemark=2;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String tableId = "";

        public FrmImages(XtrimControl x, String tableid)
        {
            InitializeComponent();
            xC = x;
            this.tableId = tableid;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            expndd = new ExpensesDrawDatail();
            expndd = xC.accDB.expnddDB.selectByPk1(tableId);
            txtTableId.Value = expndd.expenses_draw_detail_id;
            txtItmNameT.Value = expndd.item_name_t;
            txtJobId.Value = expndd.job_id;

            btnImages.Click += BtnImages_Click;
            btnUpload.Click += BtnUpload_Click;

            sB1.Text = "";
            initGrfJob();
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                int i = 0;
                DataTable dt = new DataTable();
                dt = xC.xtDB.imgDB.selectByTableId(tableId);
                i = dt.Rows.Count+1;
                foreach (Row row in grfImg.Rows)
                {
                    int chk = 0, chkD = 0;
                    if (row[colPath] == null) continue;
                    if (row[colPath].ToString().Equals("Path")) continue;
                    Images img = new Images();
                    img.image_id = "";
                    img.table_id = tableId;
                    
                    img.image_path = row[colPath].ToString();
                    String ext = Path.GetExtension(@img.image_path);
                    img.image_name = tableId+"_"+i + ext;

                    img.active = "";
                    img.remark = row[colRemark].ToString();
                    img.date_create = "";
                    img.date_modi = "";
                    img.date_cancel = "";
                    img.user_create = "";
                    img.user_modi = "";
                    img.user_cancel = "";
                    img.job_id = txtJobId.Text;

                    string re = xC.xtDB.imgDB.insertImages(img, xC.userId);
                    if (int.TryParse(re, out chk))
                    {
                        
                        xC.ftpC.createDirectory(img.job_id);
                        xC.ftpC.upload(img.job_id+"/"+img.image_name, img.image_path);
                    }
                    i++;
                }
            }
        }

        private void BtnImages_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            OpenFileDialog ofd = new OpenFileDialog();
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;

            ofd.Filter = "";
            ofd.Multiselect = true;
            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                ofd.Filter = String.Format("{0}{1}{2} ({3})|{3}", ofd.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }

            ofd.Filter = String.Format("{0}{1}{2} ({3})|{3}", ofd.Filter, sep, "All Files", "*.*");

            ofd.DefaultExt = ".png"; // Default file extension 

            //Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = ofd.FileNames;
                    setGrfImg(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void initGrfJob()
        {
            grfImg = new C1FlexGrid();
            grfImg.Font = fEdit;
            grfImg.Dock = System.Windows.Forms.DockStyle.Fill;
            grfImg.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpnD);

            //grfJob.AfterRowColChange += GrfJob_AfterRowColChange;
            //grfImg.DoubleClick += GrfJob_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //grfJob.CellChanged += GrfExpnD_CellChanged;
            panel2.Controls.Add(grfImg);
            grfImg.Clear();
            grfImg.Rows.Count = 1;
            grfImg.Cols.Count = 3;
            
            grfImg.Cols[colPath].Width = 300;
            grfImg.Cols[colRemark].Width = 200;

            grfImg.Cols[colPath].Caption = "Path";
            grfImg.Cols[colRemark].Caption = "หมายเหตุ";

            //grfImg.Cols[colID].Visible = false;

            theme1.SetTheme(grfImg, "Office2013Red");
        }
        
        private void setGrfImg(String[] path1)
        {
            grfImg.DataSource = null;
            grfImg.Rows.Count = 1;
            grfImg.Clear();
            if (path1 == null) return;

            //grfJob.DataSource = xC.xtDB.jimDB.selectJimJblByJobYear2(cusid);
            //grfJob.Cols.Count = dt.Columns.Count;

            grfImg.Cols.Count = 3;
            TextBox txt = new TextBox();

            grfImg.Cols[colPath].Editor = txt;

            grfImg.Cols[colPath].Width = 300;
            grfImg.Cols[colRemark].Width = 200;

            grfImg.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";
            grfImg.Cols[colPath].Caption = "Path";
            grfImg.Cols[colRemark].Caption = "หมายเหตุ";

            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            foreach(String path in path1)
            {
                //grfImg[i + 1, 0] = i;
                //if (i % 2 == 0)
                //    grfImg.Rows[i].StyleNew.BackColor = color;
                Row row = grfImg.Rows.Add();
                row[colPath] = path;
                row[colRemark] = "";
            }
        }
        private void FrmImages_Load(object sender, EventArgs e)
        {

        }
    }
}
