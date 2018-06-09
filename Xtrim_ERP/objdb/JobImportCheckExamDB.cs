using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class JobImportCheckExamDB
    {
        public JobImportCheckExam jce;
        ConnectDB conn;

        public JobImportCheckExamDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jce = new JobImportCheckExam();
            jce.job_import_check_exam_id = "job_import_check_exam_id";
            jce.job_import_id = "job_import_id";
            jce.status_open_goods = "status_open_goods";
            jce.qty_open_goods = "qty_open_goods";
            jce.number_open_goods = "number_open_goods";
            jce.status_layout_goods = "status_layout_goods";
            jce.qty_bad_goods = "qty_bad_goods";
            jce.number_bad_goods = "number_bad_goods";
            jce.bad_goods_desc = "bad_goods_desc";
            jce.attend_corrupt = "attend_corrupt";
            jce.status_corrupt_goods = "status_corrupt_goods";
            jce.dmc_no = "dmc_no";
            jce.dmc_date = "dmc_date";
            jce.date_create = "date_create";
            jce.date_modi = "date_modi";
            jce.date_cancel = "date_cancel";
            jce.user_create = "user_create";
            jce.user_modi = "user_modi";
            jce.user_cancel = "user_cancel";
            jce.remark = "remark";
            jce.active = "active";
            jce.sort1 = "sort1";
            jce.transport_date = "transport_date";
            jce.custom_date = "custom_date";

            jce.table = "t_job_import_check_exam";
            jce.pkField = "job_import_check_exam_id";
        }
        private void chkNull(JobImportCheckExam p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            //jce.job_import_check_exam_id = p.job_import_check_exam_id == null ? "" : p.job_import_check_exam_id;
            //jce. = p.status_original == null ? "" : p.status_original;
            jce.status_open_goods = p.status_open_goods == null ? "0" : p.status_open_goods;
            jce.qty_open_goods = p.qty_open_goods == null ? "0" : p.qty_open_goods;
            jce.number_open_goods = p.number_open_goods == null ? "" : p.number_open_goods;
            jce.status_layout_goods = p.status_layout_goods == null ? "0" : p.status_layout_goods;
            jce.qty_bad_goods = p.qty_bad_goods == null ? "0" : p.qty_bad_goods;
            jce.number_bad_goods = p.number_bad_goods == null ? "" : p.number_bad_goods;
            jce.bad_goods_desc = p.bad_goods_desc == null ? "" : p.bad_goods_desc;
            jce.attend_corrupt = p.attend_corrupt == null ? "" : p.attend_corrupt;
            jce.status_corrupt_goods = p.status_corrupt_goods == null ? "0" : p.status_corrupt_goods;
            jce.dmc_no = p.dmc_no == null ? "" : p.dmc_no;
            jce.dmc_date = p.dmc_date == null ? "" : p.dmc_date;
            jce.date_create = p.date_create == null ? "" : p.date_create;
            jce.date_modi = p.date_modi == null ? "" : p.date_modi;
            jce.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            jce.user_create = p.user_create == null ? "" : p.user_create;
            jce.user_modi = p.user_modi == null ? "" : p.user_modi;
            jce.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            jce.remark = p.remark == null ? "" : p.remark;
            jce.active = p.active == null ? "" : p.active;
            jce.sort1 = p.sort1 == null ? "" : p.sort1;
            jce.transport_date = p.transport_date == null ? "" : p.transport_date;
            jce.custom_date = p.custom_date == null ? "" : p.custom_date;

            p.job_import_id = int.TryParse(p.job_import_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(JobImportCheckExam p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);

            sql = "Insert Into " + jce.table + "(" + jce.job_import_id + "," + jce.status_open_goods + "," + jce.qty_open_goods + "," +
                jce.number_open_goods + "," + jce.status_layout_goods + "," + jce.qty_bad_goods + "," +
                jce.number_bad_goods + "," + jce.bad_goods_desc + "," + jce.attend_corrupt + "," +
                jce.status_corrupt_goods + "," + jce.dmc_no + "," + jce.dmc_date + "," +                
                jce.date_create + "," + jce.date_modi + ", " + jce.date_cancel + ", " +
                jce.user_create + "," + jce.user_modi + ", " + jce.user_cancel + ", " +
                jce.active + "," + jce.remark + ", " + jce.sort1 + ", " +
                jce.transport_date + "," + jce.custom_date + ", " +
                ") " +
                "Values ('" + p.job_import_id + "','" + p.status_open_goods + "','" + p.qty_open_goods + "'," +
                "'" + p.number_open_goods + "','" + p.status_layout_goods.Replace("'", "''") + "','" + p.qty_bad_goods + "'," +
                "'" + p.number_bad_goods + "','" + p.bad_goods_desc + "','" + p.attend_corrupt.Replace("'", "''") + "'," +
                "'" + p.status_corrupt_goods.Replace("'", "''") + "','" + p.dmc_no.Replace("'", "''") + "','" + p.dmc_date.Replace("'", "''") + "'," +                
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + conn.user.staff_id + "','" + p.user_modi + "','" + p.user_cancel + "', " +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.sort1.Replace("'", "''") + "', " +
                "'" + p.transport_date + "','" + p.custom_date.Replace("'", "''") + "','" +
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
        public String update(JobImportCheckExam p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + jce.table + " Set " +
                " " + jce.job_import_id + " = '" + p.job_import_id + "'" +
                "," + jce.status_open_goods + " = '" + p.status_open_goods.Replace("'", "''") + "'" +
                "," + jce.qty_open_goods + " = '" + p.qty_open_goods + "'" +
                "," + jce.number_open_goods + " = '" + p.number_open_goods.Replace("'", "''") + "'" +
                "," + jce.status_layout_goods + " = '" + p.status_layout_goods.Replace("'", "''") + "'" +
                "," + jce.qty_bad_goods + " = '" + p.qty_bad_goods.Replace("'", "''") + "'" +
                "," + jce.number_bad_goods + " = '" + p.number_bad_goods.Replace("'", "''") + "'" +
                "," + jce.bad_goods_desc + " = '" + p.bad_goods_desc.Replace("'", "''") + "'" +
                "," + jce.attend_corrupt + " = '" + p.attend_corrupt.Replace("'", "''") + "'" +
                "," + jce.status_corrupt_goods + " = '" + p.status_corrupt_goods + "'" +
                "," + jce.dmc_no + " = '" + p.dmc_no + "'" +
                "," + jce.dmc_date + " = '" + p.dmc_date + "'" +                
                "," + jce.date_modi + " = now() " +
                "," + jce.user_modi + " = '" + conn.user.staff_id + "' " +
                "," + jce.remark + " = '" + p.remark.Replace("'", "''") + "' " +
                "," + jce.sort1 + " = '" + p.sort1.Replace("'", "''") + "' " +
                "," + jce.transport_date + " = '" + p.transport_date.Replace("'", "''") + "' " +
                "," + jce.custom_date + " = '" + p.custom_date.Replace("'", "''") + "' " +

                "Where " + jce.pkField + "='" + p.job_import_check_exam_id + "'"
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
        public String insertJobImportCheckExam(JobImportCheckExam p)
        {
            String re = "";

            if (p.job_import_check_exam_id.Equals(""))
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
            String sql = "select jce.* " +
                "From " + jce.table + " jce " +
                "Where cont." + jce.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public JobImportCheckExam selectByPk1(String copId)
        {
            JobImportCheckExam cont1 = new JobImportCheckExam();
            DataTable dt = new DataTable();
            String sql = "select jce.*  " +
                "From " + jce.table + " jce " +

                "Where jce." + jce.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cont1 = setJobImportCheckExam(dt);
            return cont1;
        }
        public JobImportCheckExam selectByJobId(String copId)
        {
            JobImportCheckExam cont1 = new JobImportCheckExam();
            DataTable dt = new DataTable();
            String sql = "select jce.*  " +
                "From " + jce.table + " jcjcel " +

                "Where jce." + jce.job_import_id + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cont1 = setJobImportCheckExam(dt);
            return cont1;
        }
        private JobImportCheckExam setJobImportCheckExam(DataTable dt)
        {
            JobImportCheckExam jcl1 = new JobImportCheckExam();
            if (dt.Rows.Count > 0)
            {
                jcl1.job_import_check_exam_id = dt.Rows[0][jce.job_import_check_exam_id].ToString();
                jcl1.job_import_id = dt.Rows[0][jce.job_import_id].ToString();
                jcl1.status_open_goods = dt.Rows[0][jce.status_open_goods].ToString();
                jcl1.qty_open_goods = dt.Rows[0][jce.qty_open_goods].ToString();
                jcl1.number_open_goods = dt.Rows[0][jce.number_open_goods].ToString();
                jcl1.status_layout_goods = dt.Rows[0][jce.status_layout_goods].ToString();
                jcl1.qty_bad_goods = dt.Rows[0][jce.qty_bad_goods].ToString();
                jcl1.number_bad_goods = dt.Rows[0][jce.number_bad_goods].ToString();
                jcl1.bad_goods_desc = dt.Rows[0][jce.bad_goods_desc].ToString();
                jcl1.attend_corrupt = dt.Rows[0][jce.attend_corrupt].ToString();
                jcl1.status_corrupt_goods = dt.Rows[0][jce.status_corrupt_goods].ToString();
                jcl1.dmc_no = dt.Rows[0][jce.dmc_no].ToString();
                jcl1.dmc_date = dt.Rows[0][jce.dmc_date].ToString();
                jcl1.date_create = dt.Rows[0][jce.date_create].ToString();
                jcl1.date_modi = dt.Rows[0][jce.date_modi].ToString();
                jcl1.date_cancel = dt.Rows[0][jce.date_cancel].ToString();
                jcl1.user_create = dt.Rows[0][jce.user_create].ToString();
                jcl1.user_modi = dt.Rows[0][jce.user_modi].ToString();
                jcl1.user_cancel = dt.Rows[0][jce.user_cancel].ToString();
                jcl1.remark = dt.Rows[0][jce.remark].ToString();
                jcl1.active = dt.Rows[0][jce.active].ToString();
                jcl1.sort1 = dt.Rows[0][jce.sort1].ToString();
                jcl1.transport_date = dt.Rows[0][jce.transport_date].ToString();
                jcl1.custom_date = dt.Rows[0][jce.custom_date].ToString();
            }
            return jcl1;
        }
    }
}
