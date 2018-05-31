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
    }
}
