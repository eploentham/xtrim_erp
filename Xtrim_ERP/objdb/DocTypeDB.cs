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
    public class DocTypeDB
    {
        public DocType cem;
        ConnectDB conn;
        public List<DocType> lContain, lBl,lTypeBl, lCl41,lCl42,lCl5;
        //public List<DocType> lBl;
        public DataTable dtContain, dtBl;

        public DocTypeDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            cem = new DocType();
            cem.active = "active";
            cem.date_cancel = "date_cancel";
            cem.date_create = "date_create";
            cem.date_modi = "date_modi";
            cem.doc_type_code = "doc_type_code";
            cem.doc_type_id = "doc_type_id";
            cem.doc_type_name = "doc_type_name";
            cem.status_combo = "status_combo";

            cem.pkField = "doc_type_id";
            cem.table = "f_doc_type";
            lContain = new List<DocType>();
            lBl = new List<DocType>();
            lTypeBl = new List<DocType>();
            lCl41 = new List<DocType>();
            lCl42 = new List<DocType>();
            lCl5 = new List<DocType>();
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cem.*  " +
                "From " + cem.table + " cem " +
                " " +
                "Where cem." + cem.active + " ='1' and cem."+cem.status_combo+"='combo'" +
                "";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAllGW()
        {
            DataTable dt = new DataTable();
            String sql = "select cem.*  " +
                "From " + cem.table + " cem " +
                " " +
                "Where cem." + cem.active + " ='1' and cem." + cem.status_combo + "='gw'" +
                "";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAllContainer()
        {
            DataTable dt = new DataTable();
            String sql = "select cem.*  " +
                "From " + cem.table + " cem " +
                " " +
                "Where cem." + cem.active + " ='1' and cem." + cem.status_combo + "='container'" +
                "";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAllBLTYPE()
        {
            DataTable dt = new DataTable();
            String sql = "select cem.*  " +
                "From " + cem.table + " cem " +
                " " +
                "Where cem." + cem.active + " ='1' and cem." + cem.status_combo + "='BL_TYPE'" +
                "";
            dt = conn.selectData(conn.conn, sql);
            dtBl = dt;
            return dt;
        }
        public DataTable selectAllTYPEofBL()
        {
            DataTable dt = new DataTable();
            String sql = "select cem.*  " +
                "From " + cem.table + " cem " +
                " " +
                "Where cem." + cem.active + " ='1' and cem." + cem.status_combo + "='type_of_bl'" +
                "";
            dt = conn.selectData(conn.conn, sql);
            dtBl = dt;
            return dt;
        }
        public DataTable selectAllCl41()
        {
            DataTable dt = new DataTable();
            String sql = "select cem.*  " +
                "From " + cem.table + " cem " +
                " " +
                "Where cem." + cem.active + " ='1' and cem." + cem.status_combo + "='check_list_4_1'" +
                "";
            dt = conn.selectData(conn.conn, sql);
            dtBl = dt;
            return dt;
        }
        public DataTable selectAllCl42()
        {
            DataTable dt = new DataTable();
            String sql = "select cem.*  " +
                "From " + cem.table + " cem " +
                " " +
                "Where cem." + cem.active + " ='1' and cem." + cem.status_combo + "='check_list_4_2'" +
                "";
            dt = conn.selectData(conn.conn, sql);
            dtBl = dt;
            return dt;
        }
        public DataTable selectAllCl5()
        {
            DataTable dt = new DataTable();
            String sql = "select cem.*  " +
                "From " + cem.table + " cem " +
                " " +
                "Where cem." + cem.active + " ='1' and cem." + cem.status_combo + "='check_list_5'" +
                "";
            dt = conn.selectData(conn.conn, sql);
            dtBl = dt;
            return dt;
        }
        public DataTable selectAllPKG()
        {
            DataTable dt = new DataTable();
            String sql = "select cem.*  " +
                "From " + cem.table + " cem " +
                " " +
                "Where cem." + cem.active + " ='1' and cem." + cem.status_combo + "='pkg'" +
                "";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select cem.* " +
                "From " + cem.table + " cem " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cem." + cem.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DocType selectByPk1(String copId)
        {
            DocType cop1 = new DocType();
            DataTable dt = new DataTable();
            String sql = "select cem.* " +
                "From " + cem.table + " cem " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cem." + cem.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            setDocType(dt);
            return cop1;
        }
        private DocType setDocType(DataTable dt)
        {
            DocType itt1 = new DocType();
            if (dt.Rows.Count > 0)
            {
                itt1.doc_type_id = dt.Rows[0][cem.doc_type_id].ToString();
                itt1.doc_type_code = dt.Rows[0][cem.doc_type_code].ToString();
                itt1.doc_type_name = dt.Rows[0][cem.doc_type_name].ToString();
                itt1.active = dt.Rows[0][cem.active].ToString();
                //itt1.cou_name = dt.Rows[0][itt.cou_name].ToString();

            }
            return itt1;
        }
        public C1ComboBox setCboDocType(C1ComboBox c)
        {
            DataTable dt = selectAll();
            c.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ComboBoxItem a1 = new ComboBoxItem();
                a1.Value = row[cem.doc_type_id].ToString();
                a1.Text = row[cem.doc_type_name].ToString();
                c.Items.Add(a1);
            }
            return c;
        }
        public C1ComboBox setCboGW(C1ComboBox c)
        {
            DataTable dt = selectAllGW();
            c.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ComboBoxItem a1 = new ComboBoxItem();
                a1.Value = row[cem.doc_type_id].ToString();
                a1.Text = row[cem.doc_type_name].ToString();
                c.Items.Add(a1);
            }
            return c;
        }
        public C1ComboBox setCboPKG(C1ComboBox c)
        {
            DataTable dt = selectAllPKG();
            c.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ComboBoxItem a1 = new ComboBoxItem();
                a1.Value = row[cem.doc_type_id].ToString();
                a1.Text = row[cem.doc_type_name].ToString();
                c.Items.Add(a1);
            }
            return c;
        }
        public C1ComboBox setCboContainer(C1ComboBox c)
        {
            DataTable dt = selectAllContainer();
            c.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ComboBoxItem a1 = new ComboBoxItem();
                a1.Value = row[cem.doc_type_id].ToString();
                a1.Text = row[cem.doc_type_name].ToString();
                c.Items.Add(a1);
            }
            return c;
        }
        public void getlContain()
        {
            lContain.Clear();
            DataTable dt = new DataTable();
            dt = selectAllContainer();
            dtContain = dt;
            foreach (DataRow row in dt.Rows)
            {
                DocType utp1 = new DocType();
                utp1.doc_type_id = row[cem.doc_type_id].ToString();
                utp1.doc_type_code = row[cem.doc_type_code].ToString();
                utp1.doc_type_name = row[cem.doc_type_name].ToString();
                lContain.Add(utp1);
            }
        }
        public void getlBlType()
        {
            lBl.Clear();
            DataTable dt = new DataTable();
            dt = selectAllBLTYPE();
            dtContain = dt;
            foreach (DataRow row in dt.Rows)
            {
                DocType utp1 = new DocType();
                utp1.doc_type_id = row[cem.doc_type_id].ToString();
                utp1.doc_type_code = row[cem.doc_type_code].ToString();
                utp1.doc_type_name = row[cem.doc_type_name].ToString();
                lBl.Add(utp1);
            }
        }
        public void getlTypeofBL()
        {
            lTypeBl.Clear();
            DataTable dt = new DataTable();
            dt = selectAllBLTYPE();
            dtContain = dt;
            foreach (DataRow row in dt.Rows)
            {
                DocType utp1 = new DocType();
                utp1.doc_type_id = row[cem.doc_type_id].ToString();
                utp1.doc_type_code = row[cem.doc_type_code].ToString();
                utp1.doc_type_name = row[cem.doc_type_name].ToString();
                lTypeBl.Add(utp1);
            }
        }
        public void getlCl41()
        {
            lCl41.Clear();
            DataTable dt = new DataTable();
            dt = selectAllCl41();
            dtContain = dt;
            foreach (DataRow row in dt.Rows)
            {
                DocType utp1 = new DocType();
                utp1.doc_type_id = row[cem.doc_type_id].ToString();
                utp1.doc_type_code = row[cem.doc_type_code].ToString();
                utp1.doc_type_name = row[cem.doc_type_name].ToString();
                lCl41.Add(utp1);
            }
        }
        public void getlCl42()
        {
            lCl42.Clear();
            DataTable dt = new DataTable();
            dt = selectAllCl42();
            dtContain = dt;
            foreach (DataRow row in dt.Rows)
            {
                DocType utp1 = new DocType();
                utp1.doc_type_id = row[cem.doc_type_id].ToString();
                utp1.doc_type_code = row[cem.doc_type_code].ToString();
                utp1.doc_type_name = row[cem.doc_type_name].ToString();
                lCl42.Add(utp1);
            }
        }
        public void getlCl5()
        {
            lCl5.Clear();
            DataTable dt = new DataTable();
            dt = selectAllCl5();
            dtContain = dt;
            foreach (DataRow row in dt.Rows)
            {
                DocType utp1 = new DocType();
                utp1.doc_type_id = row[cem.doc_type_id].ToString();
                utp1.doc_type_code = row[cem.doc_type_code].ToString();
                utp1.doc_type_name = row[cem.doc_type_name].ToString();
                lCl5.Add(utp1);
            }
        }
        public void setC1CboContain(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            if (lContain.Count <= 0) getlContain();
            foreach (DocType cus1 in lContain)
            {
                item = new ComboBoxItem();
                item.Value = cus1.doc_type_id;
                item.Text = cus1.doc_type_name;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                }
            }
        }
        public void setC1CboBLTYPE(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            if (lBl.Count <= 0) getlBlType();
            foreach (DocType cus1 in lBl)
            {
                item = new ComboBoxItem();
                item.Value = cus1.doc_type_id;
                item.Text = cus1.doc_type_name+" ["+ cus1.doc_type_code+"]";
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                }
            }
        }
        public void setC1CboTypeofBL(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            if (lTypeBl.Count <= 0) getlTypeofBL();
            foreach (DocType cus1 in lTypeBl)
            {
                item = new ComboBoxItem();
                item.Value = cus1.doc_type_id;
                item.Text = cus1.doc_type_name + " [" + cus1.doc_type_code + "]";
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                }
            }
        }
        public void setC1CboCl41(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            if (lCl41.Count <= 0) getlCl41();
            foreach (DocType cus1 in lCl41)
            {
                item = new ComboBoxItem();
                item.Value = cus1.doc_type_id;
                item.Text = cus1.doc_type_name + " [" + cus1.doc_type_code + "]";
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                }
            }
        }
        public void setC1CboCl42(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            if (lCl42.Count <= 0) getlCl42();
            foreach (DocType cus1 in lCl42)
            {
                item = new ComboBoxItem();
                item.Value = cus1.doc_type_id;
                item.Text = cus1.doc_type_name + " [" + cus1.doc_type_code + "]";
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                }
            }
        }
        public void setC1CboCl5(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            if (lCl5.Count <= 0) getlCl5();
            foreach (DocType cus1 in lCl5)
            {
                item = new ComboBoxItem();
                item.Value = cus1.doc_type_id;
                item.Text = cus1.doc_type_name + " [" + cus1.doc_type_code + "]";
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                }
            }
        }
        public void setC1CboBLTYPE1(C1ComboBox c, String selected)
        {
            if (dtBl == null) selectAllBLTYPE();
            if (dtBl.Rows.Count <= 0) selectAllBLTYPE();
            c.DataSource = dtBl;
            //foreach (DocType cus1 in lBl)
            //{
            //    item = new ComboBoxItem();
            //    item.Value = cus1.doc_type_id;
            //    item.Text = cus1.doc_type_name + " [" + cus1.doc_type_code + "]";
            //    c.Items.Add(item);
            //    if (item.Value.Equals(selected))
            //    {
            //        //c.SelectedItem = item.Value;
            //        c.SelectedText = item.Text;
            //    }
            //}
        }
    }
}
