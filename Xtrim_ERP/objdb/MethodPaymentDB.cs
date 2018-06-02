using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class MethodPaymentDB
    {
        public MethodPayment mtp;
        ConnectDB conn;

        public List<MethodPayment> lMtp;

        public MethodPaymentDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            mtp = new MethodPayment();
            mtp.method_payment_id = "method_payment_id";
            mtp.method_payment_code = "method_payment_code";
            mtp.method_payment_name_e = "method_payment_name_e";
            mtp.method_payment_name_t = "method_payment_name_t";
            mtp.status_app = "status_app";
            mtp.sort1 = "sort1";

            mtp.active = "active";
            mtp.date_create = "date_create";
            mtp.date_modi = "date_modi";
            mtp.date_cancel = "date_cancel";
            mtp.user_create = "user_create";
            mtp.user_modi = "user_modi";
            mtp.user_cancel = "user_cancel";
            //tmn.status_app = "status_app";
            mtp.remark = "remark";

            mtp.table = "b_method_payment";
            mtp.pkField = "method_payment_id";

            lMtp = new List<MethodPayment>();

            //getlMtp();
        }
        public void getlMtp()
        {
            //lDept = new List<Department>();

            lMtp.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                MethodPayment mtp1 = new MethodPayment();
                mtp1.method_payment_id = row[mtp.method_payment_id].ToString();
                mtp1.method_payment_code = row[mtp.method_payment_code].ToString();
                mtp1.method_payment_name_e = row[mtp.method_payment_name_e].ToString();
                mtp1.method_payment_name_t = row[mtp.method_payment_name_t].ToString();

                lMtp.Add(mtp1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (MethodPayment mtp1 in lMtp)
            {
                if (code.Trim().Equals(mtp1.method_payment_code))
                {
                    id = mtp1.method_payment_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (MethodPayment mtp1 in lMtp)
            {
                if (name.Trim().Equals(mtp1.method_payment_name_t))
                {
                    id = mtp1.method_payment_id;
                    break;
                }
            }
            return id;
        }
        public String insert(MethodPayment p)
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

            sql = "Insert Into " + mtp.table + "(" + mtp.method_payment_code + "," + mtp.method_payment_name_e + "," + mtp.method_payment_name_t + "," +
                mtp.date_create + "," + mtp.date_modi + "," + mtp.date_cancel + "," +
                mtp.user_create + "," + mtp.user_modi + "," + mtp.user_cancel + "," +
                mtp.active + "," + mtp.remark + ", " + mtp.sort1 + " " +
                ") " +
                "Values ('" + p.method_payment_code + "','" + p.method_payment_name_e.Replace("'", "''") + "','" + p.method_payment_name_t.Replace("'", "''") + "'," +
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
        public String update(MethodPayment p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            sql = "Update " + mtp.table + " Set " +
                " " + mtp.method_payment_code + " = '" + p.method_payment_code + "'" +
                "," + mtp.method_payment_name_e + " = '" + p.method_payment_name_e.Replace("'", "''") + "'" +
                "," + mtp.method_payment_name_t + " = '" + p.method_payment_name_t.Replace("'", "''") + "'" +
                "," + mtp.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + mtp.date_modi + " = now()" +
                "," + mtp.user_modi + " = '" + p.user_modi + "' " +
                "," + mtp.sort1 + " = '" + p.sort1 + "' " +
                //"," + tmn.status_app + " = '" + p.status_app + "' " +
                "Where " + mtp.pkField + "='" + p.method_payment_id + "'"
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
        public String insertMethodPayment(MethodPayment p)
        {
            String re = "";

            if (p.method_payment_id.Equals(""))
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
            String sql = "Delete From  " + mtp.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select mtp.*  " +
                "From " + mtp.table + " mtp " +
                " " +
                "Where mtp." + mtp.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select mtp.* " +
                "From " + mtp.table + " mtp " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where mtp." + mtp.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public MethodPayment selectByPk1(String copId)
        {
            MethodPayment cop1 = new MethodPayment();
            DataTable dt = new DataTable();
            String sql = "select mtp.* " +
                "From " + mtp.table + " mtp " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where mtp." + mtp.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setExpn(dt);
            return cop1;
        }
        private MethodPayment setExpn(DataTable dt)
        {
            MethodPayment expn1 = new MethodPayment();
            if (dt.Rows.Count > 0)
            {
                expn1.method_payment_id = dt.Rows[0][mtp.method_payment_id].ToString();
                expn1.method_payment_code = dt.Rows[0][mtp.method_payment_code].ToString();
                expn1.method_payment_name_e = dt.Rows[0][mtp.method_payment_name_e].ToString();
                expn1.method_payment_name_t = dt.Rows[0][mtp.method_payment_name_t].ToString();
                expn1.active = dt.Rows[0][mtp.active].ToString();
                expn1.date_cancel = dt.Rows[0][mtp.date_cancel].ToString();
                expn1.date_create = dt.Rows[0][mtp.date_create].ToString();
                expn1.date_modi = dt.Rows[0][mtp.date_modi].ToString();
                expn1.user_cancel = dt.Rows[0][mtp.user_cancel].ToString();
                expn1.user_create = dt.Rows[0][mtp.user_create].ToString();
                expn1.user_modi = dt.Rows[0][mtp.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][tmn.status_app].ToString();
                expn1.remark = dt.Rows[0][mtp.remark].ToString();
                expn1.sort1 = dt.Rows[0][mtp.sort1].ToString();
            }

            return expn1;
        }
    }
}
