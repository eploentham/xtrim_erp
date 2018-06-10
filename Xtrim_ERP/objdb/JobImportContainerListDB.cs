using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class JobImportContainerListDB
    {
        public JobImportContainerList jcs;
        ConnectDB conn;

        public JobImportContainerListDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jcs = new JobImportContainerList();
            jcs.job_import_container_id = "job_import_container_id";
            jcs.job_import_id = "job_import_id";
            jcs.container_no = "container_no";
            jcs.doc_type_id_container = "doc_type_id_container";
            jcs.seal = "seal";
            jcs.row1 = "row1";
            jcs.remark = "remark";
            jcs.active = "active";
            jcs.date_create = "date_create";
            jcs.date_modi = "date_modi";
            jcs.date_cancel = "date_cancel";
            jcs.user_create = "user_create";
            jcs.user_modi = "user_modi";
            jcs.user_cancel = "user_cancel";

            jcs.table = "t_job_import_container_list";
            jcs.pkField = "job_import_container_id";
        }
        private void chkNull(JobImportContainerList p)
        {
            int chk = 0;
            Decimal chk1 = 0;
            p.job_import_id = p.job_import_id == null ? "" : p.job_import_id;
            p.container_no = p.container_no == null ? "" : p.container_no;
            p.seal = p.seal == null ? "" : p.seal;
            p.row1 = p.row1 == null ? "" : p.row1;
            p.remark = p.remark == null ? "" : p.remark;
            p.date_create = p.date_create == null ? "" : p.date_create;
            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.doc_type_id_container = int.TryParse(p.doc_type_id_container, out chk) ? chk.ToString() : "0";
        }
        public String insert(JobImportContainerList p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);

            sql = "Insert Into " + jcs.table + "(" + jcs.job_import_id + "," + jcs.container_no + "," + jcs.seal + "," +
                jcs.row1 + "," + jcs.remark + "," + jcs.date_create + "," +
                jcs.date_modi + "," + jcs.date_cancel + "," + jcs.user_create + "," +
                jcs.user_modi + "," + jcs.user_cancel + "," + jcs.doc_type_id_container + "," +
                jcs.active + " " +
                ") " +
                "Values ('" + p.job_import_id + "','" + p.container_no + "','" + p.seal + "'," +
                "'" + p.row1 + "','" + p.remark.Replace("'", "''") + "','" + p.date_create + "'," +
                "'" + p.date_modi + "','" + p.date_cancel + "','" + p.user_create.Replace("'", "''") + "'," +
                "'" + p.user_modi.Replace("'", "''") + "','" + p.user_cancel.Replace("'", "''") + "','" + p.doc_type_id_container.Replace("'", "''") + "'," +                
                "'" + p.active.Replace("'", "''") + "' " +
                ")";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
                String code = re.Substring(re.Length - 6);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String update(JobImportContainerList p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + jcs.table + " Set " +
                " " + jcs.job_import_id + " = '" + p.job_import_id + "'" +
                "," + jcs.container_no + " = '" + p.container_no.Replace("'", "''") + "'" +
                "," + jcs.seal + " = '" + p.seal + "'" +
                "," + jcs.row1 + " = '" + p.row1.Replace("'", "''") + "'" +
                "," + jcs.doc_type_id_container + " = '" + p.doc_type_id_container.Replace("'", "''") + "'" +
                "," + jcs.date_modi + " = now() " +
                "," + jcs.user_modi + " = '" + conn.user.staff_id + "' " +                
                
                "," + jcs.remark + " = '" + p.remark.Replace("'", "''") + "' " +

                "Where " + jcs.pkField + "='" + p.job_import_container_id + "'"
                ;

            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String insertJobImportContainerList(JobImportContainerList p)
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
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select jcs.* " +
                "From " + jcs.table + " jcs " +
                "Where jcs." + jcs.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public JobImportContainerList selectByPk1(String copId)
        {
            JobImportContainerList cont1 = new JobImportContainerList();
            DataTable dt = new DataTable();
            String sql = "select jcs.*  " +
                "From " + jcs.table + " jcs " +

                "Where jcs." + jcs.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cont1 = setJobImportCheckList(dt);
            return cont1;
        }
        public JobImportContainerList selectByJobId(String copId)
        {
            JobImportContainerList cont1 = new JobImportContainerList();
            DataTable dt = new DataTable();
            String sql = "select jcs.*  " +
                "From " + jcs.table + " jcs " +

                "Where jcs." + jcs.job_import_id + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cont1 = setJobImportCheckList(dt);
            return cont1;
        }
        private JobImportContainerList setJobImportCheckList(DataTable dt)
        {
            JobImportContainerList jcl1 = new JobImportContainerList();
            if (dt.Rows.Count > 0)
            {
                jcl1.job_import_container_id = dt.Rows[0][jcs.job_import_container_id].ToString();
                jcl1.job_import_id = dt.Rows[0][jcs.job_import_id].ToString();
                jcl1.container_no = dt.Rows[0][jcs.container_no] != null ? dt.Rows[0][jcs.container_no].ToString() : "";
                jcl1.doc_type_id_container = dt.Rows[0][jcs.doc_type_id_container] != null ? dt.Rows[0][jcs.doc_type_id_container].ToString() : "";
                jcl1.seal = dt.Rows[0][jcs.seal] != null ? dt.Rows[0][jcs.seal].ToString() : "";
                jcl1.row1 = dt.Rows[0][jcs.row1] != null ? dt.Rows[0][jcs.row1].ToString() : "";
                jcl1.remark = dt.Rows[0][jcs.remark] != null ? dt.Rows[0][jcs.remark].ToString() : "";
                jcl1.active = dt.Rows[0][jcs.active] != null ? dt.Rows[0][jcs.active].ToString() : "";

                jcl1.date_create = dt.Rows[0][jcs.date_create] != null ? dt.Rows[0][jcs.date_create].ToString() : "";
                jcl1.date_modi = dt.Rows[0][jcs.date_modi] != null ? dt.Rows[0][jcs.date_modi].ToString() : "";
                jcl1.date_cancel = dt.Rows[0][jcs.date_cancel] != null ? dt.Rows[0][jcs.date_cancel].ToString() : "";
                jcl1.user_create = dt.Rows[0][jcs.user_create] != null ? dt.Rows[0][jcs.user_create].ToString() : "";
                jcl1.user_modi = dt.Rows[0][jcs.user_modi] != null ? dt.Rows[0][jcs.user_modi].ToString() : "";
                jcl1.user_cancel = dt.Rows[0][jcs.user_cancel] != null ? dt.Rows[0][jcs.user_cancel].ToString() : "";
                
            }
            else
            {
                jcl1.job_import_container_id = "";
                jcl1.job_import_id = "";
                jcl1.container_no = "";
                jcl1.doc_type_id_container = "";
                jcl1.seal = "";
                jcl1.row1 = "";
                jcl1.remark = "";

                jcl1.date_create = "";
                jcl1.date_modi = "";
                jcl1.date_cancel = "";
                jcl1.user_create = "";
                jcl1.user_modi = "";
                jcl1.user_cancel = "";
                jcl1.remark = "";
                jcl1.active = "";
            }
            return jcl1;
        }
    }
}
