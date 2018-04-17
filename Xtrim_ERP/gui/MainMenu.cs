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
using Xtrim_ERP.Properties;

namespace Xtrim_ERP.gui
{
    public partial class MainMenu : Form
    {
        XtrimControl xC;

        private Point _imageLocation = new Point(13, 5);
        private Point _imgHitArea = new Point(13, 2);
        
        Image CloseImage;

        public MainMenu(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            Login login = new Login();
            login.ShowDialog(this);
            if (login.LogonSuccessful.Equals("1"))
            {

            }
            else
            {
                Application.Exit();
            }
            c1DockingTabPage2.Text = "";
        }
        private void AddNewTab(Form frm, String label)
        {
            TabPage tab = new TabPage(label);
            tab.SuspendLayout();
            frm.TopLevel = false;
            tab.Width = tC1.Width - 10;
            tab.Height = tC1.Height - 35;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.Width = tab.Width;
            frm.Height = tab.Height;
            foreach (Control x in frm.Controls)
            {
                if (x is DataGridView)
                {
                    //x.Dock = DockStyle.Fill;
                }
            }
            //tab.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E1E1E");
            frm.Visible = true;

            tC1.TabPages.Add(tab);

            //frm.Location = new Point((tab.Width - frm.Width) / 2, (tab.Height - frm.Height) / 2);
            frm.Location = new Point(0, 0);
            tab.ResumeLayout();
            tab.Refresh();
            tab.Text = label;
            tC1.SelectedTab = tab;

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            tC1.DrawMode = TabDrawMode.OwnerDrawFixed;
            CloseImage = (Image)Resources.rsz_close;
            tC1.Padding = new Point(10, 3);
        }

        private void c1TopicBar1_LinkClick(object sender, C1.Win.C1Command.C1TopicBarClickEventArgs e)
        {
            if (e.Link.Text.Equals("Import JOB"))
            {
                //MessageBox.Show("Import JOB", "aaaaaaaaaaa");
                ImJView frm = new ImJView();
                TabPage tab = new TabPage("dddddd");
                AddNewTab(frm, "");
                //c1DockingTabPage2.p
            }
            else if (e.Link.Text.Equals("Export JOB"))
            {
                //Form3 frm3 = new Form3();
                //AddNewTab(frm3, "");
            }
            else if (e.Link.Text.Equals("Other"))
            {
                //Form4 frm4 = new Form4();
                //AddNewTab(frm4, "");
            }
            else if (e.Link.Text.Equals("ธนาคาร"))
            {
                FrmBank frm = new FrmBank(xC);
                frm.FormBorderStyle = FormBorderStyle.None;
                TabPage tab = new TabPage(e.Link.Text);                
                AddNewTab(frm, e.Link.Text);
            }
            else if (e.Link.Text.Equals("บริษัท"))
            {
                FrmCompany frm = new FrmCompany(xC);
                frm.FormBorderStyle = FormBorderStyle.None;
                TabPage tab = new TabPage(e.Link.Text);
                AddNewTab(frm, e.Link.Text);
            }
            else if (e.Link.Text.Equals("พนักงาน"))
            {
                FrmStaff frm = new FrmStaff(xC);
                frm.FormBorderStyle = FormBorderStyle.None;
                TabPage tab = new TabPage(e.Link.Text);
                AddNewTab(frm, e.Link.Text);
            }
            else if (e.Link.Text.Equals("ลูกค้า"))
            {
                FrmCustomer frm = new FrmCustomer(xC);
                frm.FormBorderStyle = FormBorderStyle.None;
                TabPage tab = new TabPage(e.Link.Text);
                AddNewTab(frm, e.Link.Text);
            }
            else if (e.Link.Text.ToLower().Equals("importer"))
            {
                FrmImporter frm = new FrmImporter(xC);
                frm.FormBorderStyle = FormBorderStyle.None;
                TabPage tab = new TabPage(e.Link.Text);
                AddNewTab(frm, e.Link.Text);
            }
        }

        private void tC1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                Image img = new Bitmap(CloseImage);
                Rectangle r = e.Bounds;
                r = this.tC1.GetTabRect(e.Index);
                r.Offset(2, 2);
                Brush TitleBrush = new SolidBrush(Color.Black);
                Font f = this.Font;
                string title = this.tC1.TabPages[e.Index].Text;

                e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));

                if (tC1.SelectedIndex >= 0)
                {
                    e.Graphics.DrawImage(img, new Point((r.X - 10) + (this.tC1.GetTabRect(e.Index).Width - _imageLocation.X), _imageLocation.Y));
                }

                //if (e.Index == tC1.SelectedIndex)
                //{
                //    e.Graphics.DrawString(title, new Font(tC1.Font, FontStyle.Bold), Brushes.Red, new PointF(e.Bounds.X + 3, e.Bounds.Y + 3));
                //}
                //else
                //{
                //    e.Graphics.DrawString(title, tC1.Font, Brushes.Black, new PointF(e.Bounds.X + 3, e.Bounds.Y + 3));
                //}
            }
            catch (Exception) { }
        }

        private void tC1_MouseClick(object sender, MouseEventArgs e)
        {
            TabControl tc = (TabControl)sender;
            Point p = e.Location;
            int _tabWidth = 0;
            _tabWidth = this.tC1.GetTabRect(tc.SelectedIndex).Width - (_imgHitArea.X);
            Rectangle r = this.tC1.GetTabRect(tc.SelectedIndex);
            r.Offset(_tabWidth, _imgHitArea.Y);
            r.Width = 16;
            r.Height = 16;
            if (tC1.SelectedIndex >= 0)
            {
                if (r.Contains(p))
                {
                    TabPage TabP = (TabPage)tc.TabPages[tc.SelectedIndex];
                    tc.TabPages.Remove(TabP);
                }
            }
        }
    }
}
