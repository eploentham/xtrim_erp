
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class JobImportDeliveryDB
    {
        public JobImportDelivery jdv;
        ConnectDB conn;

        public JobImportDeliveryDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jdv = new JobImportDelivery();
            jdv.job_import_delivery_id = "job_import_delivery_id";
            jdv.job_import_id = "job_import_id";
            jdv.row1 = "row1";
            jdv.delivery_doc_no = "delivery_doc_no";
            jdv.car_type_id = "car_type_id";
            jdv.transporter_id = "transporter_id";
            jdv.place_id = "place_id";
            jdv.packages = "packages";
            jdv.unit_package_id = "unit_package_id";
            jdv.gw = "gw";
            jdv.unit_gw_id = "unit_gw_id";
            jdv.volume1 = "volume1";
            jdv.unit_volume1_id = "unit_volume1_id";
            jdv.job_import_delivery1_id = "job_import_delivery1_id";
            jdv.container_no = "container_no";
            jdv.doc_type_namet_container = "doc_type_namet_container";
            jdv.seal = "seal";
            jdv.yard_container = "yard_container";
            jdv.remark = "remark";
            jdv.active = "active";
            jdv.date_create = "date_create";
            jdv.date_modi = "date_modi";
            jdv.date_cancel = "date_cancel";
            jdv.user_create = "user_create";
            jdv.user_modi = "user_modi";
            jdv.user_cancel = "user_cancel";
        }
        private void chkNull(JobImportDelivery p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.row1 = p.row1 == null ? "" : p.row1;
            p.delivery_doc_no = p.delivery_doc_no == null ? "" : p.delivery_doc_no;
            p.date_create = p.date_create == null ? "" : p.date_create;
            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.packages = p.packages == null ? "" : p.packages;
            p.gw = p.gw == null ? "" : p.gw;
            p.volume1 = p.volume1 == null ? "" : p.volume1;
            p.container_no = p.container_no == null ? "" : p.container_no;
            p.doc_type_namet_container = p.doc_type_namet_container == null ? "" : p.doc_type_namet_container;
            p.seal = p.seal == null ? "" : p.seal;
            p.yard_container = p.yard_container == null ? "" : p.yard_container;
            p.remark = p.remark == null ? "" : p.remark;
            //p.packages1 = p.packages1 == null ? "" : p.packages1;
            //p.packages1 = p.packages1 == null ? "" : p.packages1;

            p.job_import_id = int.TryParse(p.job_import_id, out chk) ? chk.ToString() : "0";
            p.car_type_id = int.TryParse(p.car_type_id, out chk) ? chk.ToString() : "0";
            p.transporter_id = int.TryParse(p.transporter_id, out chk) ? chk.ToString() : "0";
            p.place_id = int.TryParse(p.place_id, out chk) ? chk.ToString() : "0";
            p.unit_package_id = int.TryParse(p.unit_package_id, out chk) ? chk.ToString() : "0";
            p.unit_gw_id = int.TryParse(p.unit_gw_id, out chk) ? chk.ToString() : "0";
            p.unit_volume1_id = int.TryParse(p.unit_volume1_id, out chk) ? chk.ToString() : "0";
            p.job_import_delivery1_id = int.TryParse(p.job_import_delivery1_id, out chk) ? chk.ToString() : "0";
            //p.job_import_id1 = int.TryParse(p.job_import_id1, out chk) ? chk.ToString() : "0";
        }
        public String insert(JobImportDelivery p)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";

            chkNull(p);
            sql = "Insert Into " + jdv.table + "(" + jdv.job_import_id + "," + jdv.row1 + "," + jdv.delivery_doc_no + "," +
                jdv.active + "," + jdv.remark + "," + jdv.date_create + "," +
                jdv.date_modi + "," + jdv.date_cancel + "," + jdv.user_create + "," +
                jdv.transporter_id + "," + jdv.place_id + "," + jdv.packages + ", " +
                jdv.unit_package_id + "," + jdv.gw + "," + jdv.unit_gw_id + ", " +
                jdv.volume1 + "," + jdv.unit_volume1_id + "," + jdv.job_import_delivery1_id + ", " +
                jdv.container_no + "," + jdv.doc_type_namet_container + "," + jdv.seal + ", " +
                jdv.yard_container + " " +
                ") " +
                "Values ('" + p.job_import_id + "','" + p.row1 + "','" + p.delivery_doc_no + "'," +
                "'" + p.active + "','" + p.remark + "', now() " +
                "'" + p.date_modi + "','" + p.date_cancel + "','" + p.user_create + "'," +
                "'" + p.transporter_id + "','" + p.place_id + "','" + p.packages + "', " +
                "'" + p.unit_package_id + "','" + p.gw + "','" + p.unit_gw_id + "', " +
                "'" + p.volume1 + "','" + p.unit_volume1_id + "','" + p.job_import_delivery1_id + "', " +
                "'" + p.container_no + "','" + p.doc_type_namet_container + "','" + p.seal + "', " +
                "'" + p.yard_container + "' " +
                ")";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String update(JobImportDelivery p)
        {
            String re = "", sql = "";

            chkNull(p);
            sql = "Update " + jdv.table + " Set " +
                " " + jdv.job_import_id + "='" + p.job_import_id + "' " +
                "," + jdv.row1 + "='" + p.row1.Replace("'", "''") + "' " +
                "," + jdv.delivery_doc_no + "='" + p.delivery_doc_no.Replace("'", "''") + "' " +
                "," + jdv.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + jdv.user_modi + "='" + p.user_modi.Replace("'", "''") + "' " +
                "," + jdv.date_modi + "=now() " +
                "," + jdv.transporter_id + "='" + p.transporter_id.Replace("'", "''") + "' " +
                "," + jdv.place_id + "='" + p.place_id.Replace("'", "''") + "' " +
                "," + jdv.packages + "='" + p.packages.Replace("'", "''") + "' " +
                "," + jdv.unit_package_id + "='" + p.unit_package_id.Replace("'", "''") + "' " +
                "," + jdv.gw + "='" + p.gw.Replace("'", "''") + "' " +
                "," + jdv.unit_gw_id + "='" + p.unit_gw_id.Replace("'", "''") + "' " +
                "," + jdv.volume1 + "='" + p.volume1.Replace("'", "''") + "' " +
                "," + jdv.unit_volume1_id + "='" + p.unit_volume1_id.Replace("'", "''") + "' " +
                "," + jdv.job_import_delivery1_id + "='" + p.job_import_delivery1_id.Replace("'", "''") + "' " +
                "," + jdv.container_no + "='" + p.container_no.Replace("'", "''") + "' " +
                "," + jdv.doc_type_namet_container + "='" + p.doc_type_namet_container.Replace("'", "''") + "' " +
                "," + jdv.seal + "='" + p.seal.Replace("'", "''") + "' " +
                "," + jdv.yard_container + "='" + p.yard_container.Replace("'", "''") + "' " +
                "Where " + jdv.pkField + "='" + p.job_import_delivery_id + "'"
                ;
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String insertPrefix(JobImportDelivery p)
        {
            String re = "";

            if (p.job_import_delivery_id.Equals(""))
            {
                re = insert(p);
            }
            else
            {
                re = update(p);
            }
            return re;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select jdv.*  " +
                "From " + jdv.table + " jdv " +
                " " +
                "Where jdv." + jdv.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select jdv.* " +
                "From " + jdv.table + " jdv " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where jdv." + jdv.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public JobImportDelivery selectByPk1(String copId)
        {
            JobImportDelivery cop1 = new JobImportDelivery();
            DataTable dt = new DataTable();
            String sql = "select jdv.* " +
                "From " + jdv.table + " jdv " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where jdv." + jdv.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setImportContainer(dt);
            return cop1;
        }
        private JobImportDelivery setImportContainer(DataTable dt)
        {
            JobImportDelivery jii1 = new JobImportDelivery();
            if (dt.Rows.Count > 0)
            {
                jii1.job_import_delivery_id = dt.Rows[0][jdv.job_import_delivery_id].ToString();
                jii1.job_import_id = dt.Rows[0][jdv.job_import_id].ToString();
                jii1.row1 = dt.Rows[0][jdv.row1].ToString();
                jii1.active = dt.Rows[0][jdv.active].ToString();
                jii1.remark = dt.Rows[0][jdv.remark].ToString();
                jii1.delivery_doc_no = dt.Rows[0][jdv.delivery_doc_no].ToString();
                jii1.date_create = dt.Rows[0][jdv.date_create].ToString();
                jii1.date_modi = dt.Rows[0][jdv.date_modi].ToString();
                jii1.date_cancel = dt.Rows[0][jdv.date_cancel].ToString();
                jii1.user_cancel = dt.Rows[0][jdv.user_cancel].ToString();
                jii1.user_create = dt.Rows[0][jdv.user_create].ToString();
                jii1.user_modi = dt.Rows[0][jdv.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][tmn.status_app].ToString();
                jii1.car_type_id = dt.Rows[0][jdv.car_type_id].ToString();
                jii1.transporter_id = dt.Rows[0][jdv.transporter_id].ToString();
                jii1.place_id = dt.Rows[0][jdv.place_id].ToString();
                jii1.packages = dt.Rows[0][jdv.packages].ToString();
                jii1.unit_package_id = dt.Rows[0][jdv.unit_package_id].ToString();
                jii1.gw = dt.Rows[0][jdv.gw].ToString();
                jii1.unit_gw_id = dt.Rows[0][jdv.unit_gw_id].ToString();
                jii1.volume1 = dt.Rows[0][jdv.volume1].ToString();
                jii1.unit_volume1_id = dt.Rows[0][jdv.unit_volume1_id].ToString();
                jii1.job_import_delivery1_id = dt.Rows[0][jdv.job_import_delivery1_id].ToString();
                jii1.container_no = dt.Rows[0][jdv.container_no].ToString();
                jii1.doc_type_namet_container = dt.Rows[0][jdv.doc_type_namet_container].ToString();
                jii1.seal = dt.Rows[0][jdv.seal].ToString();
                jii1.yard_container = dt.Rows[0][jdv.yard_container].ToString();
            }

            return jii1;
        }
    }
}
