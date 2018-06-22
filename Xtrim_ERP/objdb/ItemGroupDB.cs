using C1.Win.C1Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class ItemGroupDB
    {
        public ItemGroup itmGrp;
        ConnectDB conn;

        public List<ItemGroup> lExpnT;

        public ItemGroupDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            itmGrp = new ItemGroup();
            itmGrp.item_group_id = "item_group_id";
            itmGrp.item_group_name_t = "item_group_name_t";
            itmGrp.item_group_name_e = "item_group_name_e";
            //itmGrp.item_type_name_t = "item_type_name_t";

            itmGrp.table = "f_item_group";
            itmGrp.pkField = "item_group_id";

            lExpnT = new List<ItemGroup>();

        }
        public void getlItmGrp()
        {
            //lDept = new List<Department>();

            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                ItemGroup curr1 = new ItemGroup();
                curr1.item_group_id = row[itmGrp.item_group_id].ToString();
                curr1.item_group_name_t = row[itmGrp.item_group_name_t].ToString();
                curr1.item_group_name_e = row[itmGrp.item_group_name_e].ToString();
                
                lExpnT.Add(curr1);
            }
        }
        public void setC1CboItmGrp(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            if (lExpnT.Count <= 0) getlItmGrp();
            //DataTable dt = selectWard();
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (ItemGroup cus1 in lExpnT)
            {
                item = new ComboBoxItem();
                item.Value = cus1.item_group_id;
                item.Text = cus1.item_group_name_t;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedText = item.Text;
                }
            }
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select itmGrp.*  " +
                "From " + itmGrp.table + " itmGrp " +
                " " ;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
    }
}
