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
    public class FTaxTypeDB
    {
        public FTaxType ftt;
        ConnectDB conn;

        public List<FTaxType> lExpnT;

        public FTaxTypeDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ftt = new FTaxType();
            ftt.f_tax_type_id = "f_tax_type_id";
            ftt.f_tax_type_code = "f_tax_type_code";
            ftt.f_tax_type_name_t = "f_tax_type_name_t";
            //itmGrp.item_type_name_t = "item_type_name_t";

            ftt.table = "f_tax_type";
            ftt.pkField = "f_tax_type_id";

            lExpnT = new List<FTaxType>();

        }
        public void getlItmGrp()
        {
            //lDept = new List<Department>();

            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                FTaxType curr1 = new FTaxType();
                curr1.f_tax_type_id = row[ftt.f_tax_type_id].ToString();
                curr1.f_tax_type_code = row[ftt.f_tax_type_code].ToString();
                curr1.f_tax_type_name_t = row[ftt.f_tax_type_name_t].ToString();

                lExpnT.Add(curr1);
            }
        }
        public void setC1CboFTax(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            if (lExpnT.Count <= 0) getlItmGrp();
            //DataTable dt = selectWard();
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (FTaxType cus1 in lExpnT)
            {
                item = new ComboBoxItem();
                item.Value = cus1.f_tax_type_id;
                item.Text = cus1.f_tax_type_name_t;
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
                "From " + ftt.table + " itmGrp " +
                " ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
    }
}
