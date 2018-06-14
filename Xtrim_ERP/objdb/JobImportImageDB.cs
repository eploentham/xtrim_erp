using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class JobImportImageDB
    {
        public JobImportImage jii;
        ConnectDB conn;

        public JobImportImageDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jii = new JobImportImage();
            jii.job_import_image_id = "job_import_image_id";
            jii.job_import_id = "job_import_id";
            jii.path_pic = "path_pic";
            jii.active = "active";
            jii.remark = "remark";
            jii.status_pic = "status_pic";
            jii.date_create = "date_create";
            jii.date_modi = "date_modi";
            jii.date_cancel = "date_cancel";
            jii.user_create = "user_create";
            jii.user_modi = "user_modi";
            jii.user_cancel = "user_cancel";
            jii.sort1 = "sort1";
            jii.status_module = "status_module";

            jii.table = "t_job_import_image";
            jii.pkField = "job_import_image_id";
        }
        public String insert(JobImportImage p)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            sql = "Insert Into " + jii.table + "(" + jii.job_import_id + "," + jii.path_pic + "," + jii.status_pic + "," +
                jii.active + "," + jii.remark + "," + jii.date_create + "," +
                jii.date_modi + "," + jii.date_cancel + "," + jii.user_create + "," +
                jii.user_modi + "," + jii.user_cancel + "," + jii.sort1 + "," +
                jii.status_module + "," +
                ") " +
                "Values ('" + p.job_import_id + "','" + p.path_pic + "','" + p.status_pic + "'," +
                "'" + p.active + "','" + p.remark + "', now() " +
                "'" + p.date_modi + "','" + p.date_cancel + "','" + p.user_create + "'," +
                "'" + p.user_modi + "','" + p.user_cancel + "','" + p.sort1 + "'," +
                "'" + p.status_module + "' " +
                ")";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String update(JobImportImage p)
        {
            String re = "", sql = "";

            sql = "Update " + jii.table + " Set " +
                " " + jii.job_import_id + "='" + p.job_import_id + "' " +
                "," + jii.path_pic + "='" + p.path_pic.Replace("'", "''") + "' " +
                "," + jii.status_pic + "='" + p.status_pic.Replace("'", "''") + "' " +
                "," + jii.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + jii.user_modi + "='" + p.user_modi.Replace("'", "''") + "' " +
                "," + jii.date_modi + "=now() " +
                "," + jii.status_module + "='" + p.status_module.Replace("'", "''") + "' " +
                "Where " + jii.pkField + "='" + p.job_import_image_id + "'"
                ;
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String insertPrefix(JobImportImage p)
        {
            String re = "";

            if (p.job_import_image_id.Equals(""))
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
            String sql = "select jii.*  " +
                "From " + jii.table + " jii " +
                " " +
                "Where jii." + jii.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select jii.* " +
                "From " + jii.table + " jii " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where jii." + jii.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public JobImportImage selectByPk1(String copId)
        {
            JobImportImage cop1 = new JobImportImage();
            DataTable dt = new DataTable();
            String sql = "select jii.* " +
                "From " + jii.table + " jii " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where jii." + jii.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setImportImage(dt);
            return cop1;
        }
        private JobImportImage setImportImage(DataTable dt)
        {
            JobImportImage jii1 = new JobImportImage();
            if (dt.Rows.Count > 0)
            {
                jii1.job_import_image_id = dt.Rows[0][jii.job_import_image_id].ToString();
                jii1.job_import_id = dt.Rows[0][jii.job_import_id].ToString();
                jii1.path_pic = dt.Rows[0][jii.path_pic].ToString();
                jii1.active = dt.Rows[0][jii.active].ToString();
                jii1.remark = dt.Rows[0][jii.remark].ToString();
                jii1.status_pic = dt.Rows[0][jii.status_pic].ToString();
                jii1.date_create = dt.Rows[0][jii.date_create].ToString();
                jii1.date_modi = dt.Rows[0][jii.date_modi].ToString();
                jii1.user_cancel = dt.Rows[0][jii.user_cancel].ToString();
                jii1.user_create = dt.Rows[0][jii.user_create].ToString();
                jii1.user_modi = dt.Rows[0][jii.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][tmn.status_app].ToString();
                jii1.remark = dt.Rows[0][jii.remark].ToString();
                jii1.sort1 = dt.Rows[0][jii.sort1].ToString();
                jii1.status_module = dt.Rows[0][jii.status_module].ToString();
            }

            return jii1;
        }
    }
}
