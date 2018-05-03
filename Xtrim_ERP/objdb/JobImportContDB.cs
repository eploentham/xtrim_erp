using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class JobImportContDB
    {
        public JobImportCont jct;
        ConnectDB conn;

        public JobImportContDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jct = new JobImportCont();
            jct.job_import_cont_id = "job_import_cont_id";
            jct.job_import_id = "job_import_id";
            jct.row_no = "row_no";
            jct.container_no = "container_no";
            jct.container_seal = "container_seal";
            jct.container_type = "container_type";
            jct.packages_per_con = "packages_per_con";
            jct.unit_package_id = "unit_package_id";
            jct.gw_per_con = "gw_per_con";
            jct.unit_gw_id = "unit_gq_id";
            jct.truck_id = "truck_id";
            jct.qty_container = "qty_container";
            jct.date_create = "date_create";
            jct.date_modi = "date_modi";
            jct.date_cancel = "date_cancel";
            jct.user_create = "user_create";
            jct.user_modi = "user_modi";
            jct.user_cancel = "user_cancel";
            jct.active = "active";
            jct.remark = "remark";

            jct.table = "t_job_import_cont";
            jct.pkField = "job_import_cont_id";
        }
        public String insert(JobImportCont p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.remark = p.remark == null ? "" : p.remark;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.job_import_id = int.TryParse(p.job_import_id, out chk) ? chk.ToString() : "0";
            p.unit_package_id = int.TryParse(p.unit_package_id, out chk) ? chk.ToString() : "0";
            p.row_no = int.TryParse(p.row_no, out chk) ? chk.ToString() : "0";
            p.unit_gw_id = int.TryParse(p.unit_gw_id, out chk) ? chk.ToString() : "0";
            p.truck_id = int.TryParse(p.truck_id, out chk) ? chk.ToString() : "0";
            //p.tax_amount = Decimal.TryParse(p.tax_amount, out chk1) ? chk1.ToString() : "0";
            //p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
            //p.cost_amount = Decimal.TryParse(p.cost_amount, out chk1) ? chk1.ToString() : "0";
            //p.cheque_amount = Decimal.TryParse(p.cheque_amount, out chk1) ? chk1.ToString() : "0";
            //p.amount_pay = Decimal.TryParse(p.amount_pay, out chk1) ? chk1.ToString() : "0";
            //p.cheque_pay_amount = Decimal.TryParse(p.cheque_pay_amount, out chk1) ? chk1.ToString() : "0";
            //p.amount1 = Decimal.TryParse(p.amount1, out chk1) ? chk1.ToString() : "0";
            //p.amount1 = Decimal.TryParse(p.amount1, out chk1) ? chk1.ToString() : "0";
            //p.amount1 = Decimal.TryParse(p.amount1, out chk1) ? chk1.ToString() : "0";
            //p.amount1 = Decimal.TryParse(p.amount1, out chk1) ? chk1.ToString() : "0";

            sql = "Insert Into " + jct.table + "(" + jct.job_import_id + "," + jct.row_no + "," + jct.container_no + "," +
                jct.container_seal + "," + jct.container_type + "," + jct.packages_per_con + "," +
                jct.unit_package_id + "," + jct.gw_per_con + "," + jct.unit_gw_id + "," +
                jct.truck_id + "," + jct.qty_container + ", " + jct.date_create + ", " +
                jct.date_modi + "," + jct.date_cancel + ", " + jct.user_create + ", " +
                jct.user_modi + "," + jct.user_cancel + ", " + jct.remark + ", " +
                p.active + "' " +
                ") " +
                "Values ('" + p.job_import_id + "','" + p.row_no + "','" + p.container_no + "'," +
                "'" + p.container_seal + "','" + p.container_type + "','" + p.packages_per_con + "'," +
                "'" + p.unit_package_id + "','" + p.gw_per_con + "','" + p.unit_gw_id + "'," +
                "'" + p.truck_id + "','" + p.qty_container.Replace("'", "''") + "',now(), " +
                "'" + p.date_modi + "','" + p.date_cancel + "','" + p.user_create + "', " +
                "'" + p.user_modi + "','" + p.user_cancel + "','" + p.remark + "',' " +
                p.active + "' " +
                ")";
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
        public String update(JobImportCont p)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.remark = p.remark == null ? "" : p.remark;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.job_import_id = int.TryParse(p.job_import_id, out chk) ? chk.ToString() : "0";
            p.unit_package_id = int.TryParse(p.unit_package_id, out chk) ? chk.ToString() : "0";
            p.row_no = int.TryParse(p.row_no, out chk) ? chk.ToString() : "0";
            p.unit_gw_id = int.TryParse(p.unit_gw_id, out chk) ? chk.ToString() : "0";
            p.truck_id = int.TryParse(p.truck_id, out chk) ? chk.ToString() : "0";

            sql = "Update " + jct.table + " Set " +
                " " + jct.job_import_id + " = '" + p.job_import_id + "'" +
                "," + jct.row_no + " = '" + p.row_no + "'" +
                "," + jct.container_no + " = '" + p.container_no.Replace("'", "''") + "'" +
                "," + jct.container_seal + " = '" + p.container_seal.Replace("'", "''") + "'" +
                "," + jct.date_modi + " = now()" +
                "," + jct.user_modi + " = '" + p.user_modi + "' " +
                "," + jct.container_type + " = '" + p.container_type + "' " +
                "," + jct.packages_per_con + " = '" + p.packages_per_con + "' " +
                "," + jct.unit_package_id + " = '" + p.unit_package_id + "' " +
                "," + jct.gw_per_con + " = '" + p.gw_per_con + "' " +
                "," + jct.unit_gw_id + " = '" + p.unit_gw_id + "' " +
                "," + jct.truck_id + " = '" + p.truck_id + "' " +
                "," + jct.qty_container + " = '" + p.qty_container + "' " +
                "," + jct.remark + " = '" + p.remark.Replace("'", "''") + "' " +

                "Where " + jct.pkField + "='" + p.job_import_cont_id + "'"
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
        public String insertJobImportJct(JobImportCont p)
        {
            String re = "";

            if (p.job_import_cont_id.Equals(""))
            {
                re = insert(p);
            }
            else
            {
                re = update(p);
            }

            return re;
        }
        public String deleteAll()
        {
            DataTable dt = new DataTable();
            String sql = "Delete From  " + jct.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select jct.*  " +
                "From " + jct.table + " jct " +
                " " +
                "Where jct." + jct.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String invId)
        {
            DataTable dt = new DataTable();
            String sql = "select jct.* " +
                "From " + jct.table + " jct " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where jct." + jct.pkField + " ='" + invId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByJobId(String jobid)
        {
            //JobImportInv cop1 = new JobImportInv();
            DataTable dt = new DataTable();
            String sql = "select jct.* " +
                ", IFNULL(expn.expenses_code, '') as expenses_code, IFNULL(expn.expenses_name_t, '') as expenses_name_t " +
                ", IFNULL(mtp.method_payment_code, '') as method_payment_code, IFNULL(mtp.method_payment_name_t, '') as method_payment_name_t " +
                "From " + jct.table + " jct " +
                "Left Join b_expenses expn On jct.expenses_id = expn.expenses_id " +
                "Left Join b_method_payment mtp On jct.method_payment_id = mtp.method_payment_id " +
                "Where jct." + jct.job_import_id + " ='" + jobid + "' ";
            dt = conn.selectData(conn.conn, sql);
            //cop1 = setJobImportInv(dt);
            return dt;
        }
        private JobImportCont setJobImportCont(DataTable dt)
        {
            JobImportCont jct1 = new JobImportCont();
            if (dt.Rows.Count > 0)
            {
                jct1.job_import_cont_id = dt.Rows[0][jct.job_import_cont_id].ToString();
                jct1.job_import_id = dt.Rows[0][jct.job_import_id].ToString();
                jct1.row_no = dt.Rows[0][jct.row_no].ToString();
                jct1.container_no = dt.Rows[0][jct.container_no].ToString();
                jct1.container_seal = dt.Rows[0][jct.container_seal].ToString();
                jct1.date_cancel = dt.Rows[0][jct.date_cancel].ToString();
                jct1.date_create = dt.Rows[0][jct.date_create].ToString();
                jct1.date_modi = dt.Rows[0][jct.date_modi].ToString();
                jct1.user_cancel = dt.Rows[0][jct.user_cancel].ToString();
                jct1.user_create = dt.Rows[0][jct.user_create].ToString();
                jct1.user_modi = dt.Rows[0][jct.user_modi].ToString();
                jct1.container_type = dt.Rows[0][jct.container_type].ToString();
                jct1.packages_per_con = dt.Rows[0][jct.packages_per_con].ToString();
                jct1.unit_package_id = dt.Rows[0][jct.unit_package_id].ToString();
                jct1.gw_per_con = dt.Rows[0][jct.gw_per_con].ToString();
                jct1.unit_gw_id = dt.Rows[0][jct.unit_gw_id].ToString();
                jct1.truck_id = dt.Rows[0][jct.truck_id].ToString();
                jct1.remark = dt.Rows[0][jct.remark].ToString();
                jct1.qty_container = dt.Rows[0][jct.qty_container].ToString();
                jct1.active = dt.Rows[0][jct.active].ToString();
                
            }

            return jct1;
        }
    }
}
