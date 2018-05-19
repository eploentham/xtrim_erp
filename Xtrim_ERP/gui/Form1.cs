using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xtrim_ERP.gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void c1FlexGrid1_Click(object sender, EventArgs e)
        {

        }

        private void c1FlexGrid1_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            String aaa = "";
            aaa = "aaa";
        }

        private void c1FlexGrid1_LeaveCell(object sender, EventArgs e)
        {
            String vvv = "";
            vvv = "";

        }

        private void c1FlexGrid1_CursorChanged(object sender, EventArgs e)
        {

        }

        private void c1FlexGrid1_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            String aaa = "";
            aaa = e.NewRange.r1.ToString();
        }

        private void c1FlexGrid1_EnterCell(object sender, EventArgs e)
        {
            
        }

        private void c1FlexGrid1_RowColChange(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void c1FlexGrid1_LocationChanged(object sender, EventArgs e)
        {

        }

        private void c1FlexGrid1_GridChanged(object sender, C1.Win.C1FlexGrid.GridChangedEventArgs e)
        {
            String aaa = e.c1.ToString();
        }

        private void c1FlexGrid1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void c1FlexGrid1_CellButtonClick(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {

        }

        private void txtContFNameT_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
