using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class JobImportContainerDB
    {
        public JobImportContainer jcn;
        ConnectDB conn;

        public JobImportContainerDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jcn = new JobImportContainer();
            jcn.job_import_container_id = "job_import_container_id";
            jcn.job_import_id = "job_import_id";
            jcn.container_no = "container_no";
            jcn.container_doct_type_id = "container_doct_type_id";
            jcn.seal = "seal";
            jcn.active = "active";
            jcn.remark = "remark";
            jcn.date_create = "date_create";
            jcn.date_modi = "date_modi";
            jcn.date_cancel = "date_cancel";
            jcn.user_create = "user_create";
            jcn.user_modi = "user_modi";
            jcn.user_cancel = "user_cancel";

            jcn.table = "t_job_import_container";
            jcn.pkField = "job_import_container_id";
        }
        private void chkNull(JobImportContainer p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.container_no = p.container_no == null ? "" : p.container_no;
            p.remark = p.remark == null ? "" : p.remark;
            p.date_create = p.date_create == null ? "" : p.date_create;
            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.seal = p.seal == null ? "" : p.seal;

            p.job_import_id = int.TryParse(p.job_import_id, out chk) ? chk.ToString() : "0";
            p.container_doct_type_id = int.TryParse(p.container_doct_type_id, out chk) ? chk.ToString() : "0";
            p.job_import_id = int.TryParse(p.job_import_id, out chk) ? chk.ToString() : "0";
            p.job_import_id = int.TryParse(p.job_import_id, out chk) ? chk.ToString() : "0";
            p.job_import_id = int.TryParse(p.job_import_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(JobImportContainer p)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";

            chkNull(p);
            sql = "Insert Into " + jcn.table + "(" + jcn.job_import_id + "," + jcn.container_no + "," + jcn.container_doct_type_id + "," +
                jcn.active + "," + jcn.remark + "," + jcn.date_create + "," +
                jcn.date_modi + "," + jcn.date_cancel + "," + jcn.user_create + "," +
                jcn.user_modi + "," + jcn.user_cancel + "," + jcn.seal + " " +
                ") " +
                "Values ('" + p.job_import_id + "','" + p.container_no + "','" + p.container_doct_type_id + "'," +
                "'" + p.active + "','" + p.remark + "', now() " +
                "'" + p.date_modi + "','" + p.date_cancel + "','" + p.user_create + "'," +
                "'" + p.user_modi + "','" + p.user_cancel + "','" + p.seal + "' " +
                ")";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String update(JobImportContainer p)
        {
            String re = "", sql = "";

            chkNull(p);
            sql = "Update " + jcn.table + " Set " +
                " " + jcn.job_import_id + "='" + p.job_import_id + "' " +
                "," + jcn.container_no + "='" + p.container_no.Replace("'", "''") + "' " +
                "," + jcn.container_doct_type_id + "='" + p.container_doct_type_id.Replace("'", "''") + "' " +
                "," + jcn.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + jcn.user_modi + "='" + p.user_modi.Replace("'", "''") + "' " +
                "," + jcn.date_modi + "=now() " +
                "Where " + jcn.pkField + "='" + p.job_import_container_id + "'"
                ;
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String insertPrefix(JobImportContainer p)
        {
            String re = "";

            if (p.job_import_container_id.Equals(""))
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
            String sql = "select jcn.*  " +
                "From " + jcn.table + " jcn " +
                " " +
                "Where jcn." + jcn.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select jcn.* " +
                "From " + jcn.table + " jcn " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where jcn." + jcn.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public JobImportContainer selectByPk1(String copId)
        {
            JobImportContainer cop1 = new JobImportContainer();
            DataTable dt = new DataTable();
            String sql = "select jcn.* " +
                "From " + jcn.table + " jcn " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where jcn." + jcn.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setImportContainer(dt);
            return cop1;
        }
        public DataTable selectByJobId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select jcn.*  " +
                "From " + jcn.table + " jcn " +
                "Where jcn." + jcn.job_import_id + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            
            return dt;
        }
        private JobImportContainer setImportContainer(DataTable dt)
        {
            JobImportContainer jii1 = new JobImportContainer();
            if (dt.Rows.Count > 0)
            {
                jii1.job_import_container_id = dt.Rows[0][jcn.job_import_container_id].ToString();
                jii1.job_import_id = dt.Rows[0][jcn.job_import_id].ToString();
                jii1.container_no = dt.Rows[0][jcn.container_no].ToString();
                jii1.active = dt.Rows[0][jcn.active].ToString();
                jii1.remark = dt.Rows[0][jcn.remark].ToString();
                jii1.container_doct_type_id = dt.Rows[0][jcn.container_doct_type_id].ToString();
                jii1.date_create = dt.Rows[0][jcn.date_create].ToString();
                jii1.date_modi = dt.Rows[0][jcn.date_modi].ToString();
                jii1.user_cancel = dt.Rows[0][jcn.user_cancel].ToString();
                jii1.user_create = dt.Rows[0][jcn.user_create].ToString();
                jii1.user_modi = dt.Rows[0][jcn.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][tmn.status_app].ToString();
                jii1.remark = dt.Rows[0][jcn.remark].ToString();
                jii1.seal = dt.Rows[0][jcn.seal].ToString();
            }

            return jii1;
        }
    }
}
