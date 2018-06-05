using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class TermPaymentDB
    {
        public TermPayment tpm;
        ConnectDB conn;

        public List<TermPayment> lTpm;

        public TermPaymentDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            tpm = new TermPayment();
            tpm.term_payment_id = "term_payment_id";
            tpm.term_payment_code = "term_payment_code";
            tpm.term_payment_name_e = "term_payment_name_e";
            tpm.term_payment_name_t = "term_payment_name_t";
            //ett.status_app = "status_app";
            tpm.sort1 = "sort1";

            tpm.active = "active";
            tpm.date_create = "date_create";
            tpm.date_modi = "date_modi";
            tpm.date_cancel = "date_cancel";
            tpm.user_create = "user_create";
            tpm.user_modi = "user_modi";
            tpm.user_cancel = "user_cancel";
            //ett.status_app = "status_app";
            tpm.remark = "remark";

            tpm.table = "b_term_payment";
            tpm.pkField = "term_payment_id";

            lTpm = new List<TermPayment>();

            //getlTpm();
        }
        public void getlTpm()
        {
            //lDept = new List<Department>();

            lTpm.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                TermPayment tpm1 = new TermPayment();
                tpm1.term_payment_id = row[tpm.term_payment_id].ToString();
                tpm1.term_payment_code = row[tpm.term_payment_code].ToString();
                tpm1.term_payment_name_e = row[tpm.term_payment_name_e].ToString();
                tpm1.term_payment_name_t = row[tpm.term_payment_name_t].ToString();

                lTpm.Add(tpm1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (TermPayment tpm1 in lTpm)
            {
                if (code.Trim().Equals(tpm1.term_payment_code))
                {
                    id = tpm1.term_payment_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (TermPayment tpm1 in lTpm)
            {
                if (name.Trim().Equals(tpm1.term_payment_name_t))
                {
                    id = tpm1.term_payment_id;
                    break;
                }
            }
            return id;
        }
        public String insert(TermPayment p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + tpm.table + "(" + tpm.term_payment_code + "," + tpm.term_payment_name_e + "," + tpm.term_payment_name_t + "," +
                tpm.date_create + "," + tpm.date_modi + "," + tpm.date_cancel + "," +
                tpm.user_create + "," + tpm.user_modi + "," + tpm.user_cancel + "," +
                tpm.active + "," + tpm.remark + ", " + tpm.sort1 + " " +
                ") " +
                "Values ('" + p.term_payment_code + "','" + p.term_payment_name_e.Replace("'", "''") + "','" + p.term_payment_name_t.Replace("'", "''") + "'," +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + p.user_create + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.sort1 + "' " +
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
        public String update(TermPayment p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            sql = "Update " + tpm.table + " Set " +
                " " + tpm.term_payment_code + " = '" + p.term_payment_code + "'" +
                "," + tpm.term_payment_name_e + " = '" + p.term_payment_name_e.Replace("'", "''") + "'" +
                "," + tpm.term_payment_name_t + " = '" + p.term_payment_name_t.Replace("'", "''") + "'" +
                "," + tpm.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + tpm.date_modi + " = now()" +
                "," + tpm.user_modi + " = '" + p.user_modi + "' " +
                "," + tpm.sort1 + " = '" + p.sort1 + "' " +
                //"," + ett.status_app + " = '" + p.status_app + "' " +
                "Where " + tpm.pkField + "='" + p.term_payment_id + "'"
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
        public String insertTermPayment(TermPayment p)
        {
            String re = "";

            if (p.term_payment_id.Equals(""))
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
            String sql = "Delete From  " + tpm.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select tpm.*  " +
                "From " + tpm.table + " tpm " +
                " " +
                "Where tpm." + tpm.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select tpm.* " +
                "From " + tpm.table + " tpm " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where tpm." + tpm.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public TermPayment selectByPk1(String copId)
        {
            TermPayment cop1 = new TermPayment();
            DataTable dt = new DataTable();
            String sql = "select tpm.* " +
                "From " + tpm.table + " tpm " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where tpm." + tpm.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setTermPayment(dt);
            return cop1;
        }
        public DataTable selectByCodeLike(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select tpm.* " +
                "From " + tpm.table + " tpm " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where LOWER(tpm." + tpm.term_payment_code + ") like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public TermPayment setTermPayment(DataTable dt)
        {
            TermPayment ett1 = new TermPayment();
            if (dt.Rows.Count > 0)
            {
                ett1.term_payment_id = dt.Rows[0][tpm.term_payment_id].ToString();
                ett1.term_payment_code = dt.Rows[0][tpm.term_payment_code].ToString();
                ett1.term_payment_name_e = dt.Rows[0][tpm.term_payment_name_e].ToString();
                ett1.term_payment_name_t = dt.Rows[0][tpm.term_payment_name_t].ToString();
                ett1.active = dt.Rows[0][tpm.active].ToString();
                ett1.date_cancel = dt.Rows[0][tpm.date_cancel].ToString();
                ett1.date_create = dt.Rows[0][tpm.date_create].ToString();
                ett1.date_modi = dt.Rows[0][tpm.date_modi].ToString();
                ett1.user_cancel = dt.Rows[0][tpm.user_cancel].ToString();
                ett1.user_create = dt.Rows[0][tpm.user_create].ToString();
                ett1.user_modi = dt.Rows[0][tpm.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][ett.status_app].ToString();
                ett1.remark = dt.Rows[0][tpm.remark].ToString();
                ett1.sort1 = dt.Rows[0][tpm.sort1].ToString();
            }

            return ett1;
        }
    }
}
