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
    public class ImporterTypeDB
    {
        public ImporterType itt;
        ConnectDB conn;

        public ImporterTypeDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            itt = new ImporterType();
            itt.active = "active";
            itt.date_cancel = "date_cancel";
            itt.date_create = "date_create";
            itt.date_modi = "date_modi";
            itt.importer_type_code = "importer_type_code";
            itt.importer_type_id = "importer_type_id";
            itt.importer_type_name = "importer_type_name";

            itt.pkField = "importer_type_id";
            itt.table = "f_importer_type";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select itt.*  " +
                "From " + itt.table + " itt " +
                " " +
                //"Where cot." + cot.active + " ='1' "
                "";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select itt.* " +
                "From " + itt.table + " itt " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cot." + itt.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public ImporterType selectByPk1(String copId)
        {
            ImporterType cop1 = new ImporterType();
            DataTable dt = new DataTable();
            String sql = "select itt.* " +
                "From " + itt.table + " itt " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cot." + itt.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            setImporterType(dt);
            return cop1;
        }
        private ImporterType setImporterType(DataTable dt)
        {
            ImporterType itt1 = new ImporterType();
            if (dt.Rows.Count > 0)
            {
                itt1.importer_type_id = dt.Rows[0][itt.importer_type_id].ToString();
                itt1.importer_type_code = dt.Rows[0][itt.importer_type_code].ToString();
                itt1.importer_type_name = dt.Rows[0][itt.importer_type_name].ToString();
                itt1.active = dt.Rows[0][itt.active].ToString();
                //itt1.cou_name = dt.Rows[0][itt.cou_name].ToString();
                
            }
            return itt1;
        }
        public C1ComboBox setCboImporterType(C1ComboBox c)
        {
            DataTable dt = selectAll();
            c.Items.Clear();
            foreach(DataRow row in dt.Rows)
            {
                ComboBoxItem a1 = new ComboBoxItem();
                a1.Value = row[itt.importer_type_id].ToString();
                a1.Text = row[itt.importer_type_name].ToString();
                c.Items.Add(a1);
            }
            return c;
        }
    }
}
