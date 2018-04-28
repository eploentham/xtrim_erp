using C1.Win.C1Command;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xtrim_ERP.control;
using Xtrim_ERP.Properties;

namespace Xtrim_ERP.gui
{
    public class MainMenu1:Form
    {
        MenuStrip menuM;
        ToolStripMenuItem menuImp, menuExit, menuJimView, menuJimAdd;
        TabControl tC1;
        TabPage tabPage1;

        private Point _imageLocation = new Point(13, 5);
        private Point _imgHitArea = new Point(13, 2);

        private XtrimControl xC;

        public MainMenu1(XtrimControl x)
        {
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            this.menuM = new System.Windows.Forms.MenuStrip();
            this.menuImp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuJimView = new System.Windows.Forms.ToolStripMenuItem();
            menuJimAdd = new System.Windows.Forms.ToolStripMenuItem();
            tC1 = new System.Windows.Forms.TabControl();

            this.menuM.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit,
            this.menuImp});
            this.menuM.Location = new System.Drawing.Point(0, 0);
            this.menuM.Name = "menuStrip1";
            this.menuM.Size = new System.Drawing.Size(800, 24);
            this.menuM.TabIndex = 0;
            this.menuM.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.menuImp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {menuJimView, menuJimAdd });
            this.menuImp.Name = "toolStripMenuItem1";
            this.menuImp.Size = new System.Drawing.Size(125, 20);
            this.menuImp.Text = "Job Import";
            // 
            // toolStripMenuItem2
            // 
            this.menuExit.Image = global::Xtrim_ERP.Properties.Resources.login16;
            this.menuExit.Name = "toolStripMenuItem2";
            this.menuExit.Size = new System.Drawing.Size(141, 20);
            this.menuExit.Text = "Exit";
            // 
            // toolStripMenuItem3
            // 
            this.menuJimView.Name = "toolStripMenuItem3";
            this.menuJimView.Size = new System.Drawing.Size(180, 22);
            this.menuJimView.Text = "Open JOB View";

            menuJimAdd.Name = "toolStripMenuItem3";
            menuJimAdd.Size = new System.Drawing.Size(180, 22);
            menuJimAdd.Text = "Open JOB New";
            // 
            // MainMenu3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuM);
            this.MainMenuStrip = this.menuM;
            this.Name = "MainMenu3";
            this.Text = "MainMenu3";

            menuExit.Click += new System.EventHandler(this.menuExit_Click);
            menuJimView.Click += new System.EventHandler(this.menuJimView_Click);

            //tC1.Controls.Add(this.tabPage1);
            //this.tC1.Controls.Add(this.tabPage2);
            this.tC1.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.tC1.Location = new System.Drawing.Point(0, 24);
            this.tC1.Name = "tC1";
            this.tC1.SelectedIndex = 0;
            //this.tC1.Size = new System.Drawing.Size(800, 426);
            this.tC1.TabIndex = 0;
            tC1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            tC1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            tC1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseClick);
            tC1.Alignment = TabAlignment.Bottom;
            Controls.Add(this.tC1);


            //this.tC1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            //this.tC1.Location = new System.Drawing.Point(236, 12);
            //this.tC1.Name = "tC1";
            //this.tC1.SelectedIndex = 0;
            //this.tC1.Size = new System.Drawing.Size(861, 701);
            //this.tC1.TabIndex = 0;
            //this.tC1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            //this.tC1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseClick);




            //this.Load += new System.EventHandler(this.MainMenu3_Load);
            menuM.ResumeLayout(false);
            menuM.PerformLayout();
            tC1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
            this.WindowState = FormWindowState.Maximized;
        }
        private void menuExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void menuJimView_Click(object sender, EventArgs e)
        {
            //Close();
            //FrmJobImpView frm = new FrmJobImpView(xC, this);
            //frm.FormBorderStyle = FormBorderStyle.None;
            //TabPage tab = new TabPage("dddddd");
            //AddNewTab(frm, "Import JOB");
        }
        public void AddNewTab(Form frm, String label)
        {
            foreach (Control y in tC1.Controls)
            {
                if (y is TabPage)
                {
                    if (y.Text.Equals("Import JOB"))
                    {
                        if (label.Equals("Import JOB"))
                        {
                            tC1.SelectedTab = (TabPage)y;
                            return;
                        }
                    }
                }
            }
            TabPage tab = new TabPage(label);
            tab.SuspendLayout();
            frm.TopLevel = false;
            tab.Width = tC1.Width - 10;
            tab.Height = tC1.Height - 35;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.Width = tab.Width;
            frm.Height = tab.Height;
            //foreach (Control x in frm.Controls)
            //{
            //    if (x is DataGridView)
            //    {
            //        //x.Dock = DockStyle.Fill;
            //    }
            //}
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
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                Image img = new Bitmap(Resources.close);
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

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ...
            if (keyData == (Keys.Escape))
            {
                if (MessageBox.Show("ต้องการออกจากโปรแกรม", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    Close();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
