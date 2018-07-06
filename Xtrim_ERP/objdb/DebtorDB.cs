using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class DebtorDB
    {
        public Debtor dtr;
        ConnectDB conn;
        public List<Debtor> lexpn;
        public DebtorDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            dtr = new Debtor();
            dtr.debtor_id = "debtor_id";
            dtr.cus_id = "cus_id";
            dtr.amount = "amount";
            dtr.billing_detail_id = "billing_detail_id";
            dtr.payment_detail_id = "payment_detail_id";
            dtr.job_id = "job_id";
            dtr.active = "active";
            dtr.remark = "remark";
            dtr.date_create = "date_create";
            dtr.date_modi = "date_modi";
            dtr.date_cancel = "date_cancel";
            dtr.user_create = "user_create";
            dtr.user_modi = "user_modi";
            dtr.user_cancel = "user_cancel";
            dtr.status_debtor = "status_debtor";
            dtr.comp_id = "comp_id";

            dtr.table = "t_debtor";
            dtr.pkField = "debtor_id";

            lexpn = new List<Debtor>();
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Debtor utp1 in lexpn)
            {
                if (name.Trim().Equals(utp1.cus_id))
                {
                    id = utp1.debtor_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(Debtor p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.amount = p.amount == null ? "" : p.amount;
            p.status_debtor = p.status_debtor == null ? "" : p.status_debtor;
            //p.payment_detail_id = p.payment_detail_id == null ? "" : p.payment_detail_id;
            p.remark = p.remark == null ? "" : p.remark;
            //p.payment_detail_id = p.payment_detail_id == null ? "" : p.payment_detail_id;
            //p.remark = p.remark == null ? "" : p.remark;

            p.billing_detail_id = int.TryParse(p.billing_detail_id, out chk) ? chk.ToString() : "0";
            p.payment_detail_id = int.TryParse(p.payment_detail_id, out chk) ? chk.ToString() : "0";
            p.job_id = int.TryParse(p.job_id, out chk) ? chk.ToString() : "0";
            p.cus_id = int.TryParse(p.cus_id, out chk) ? chk.ToString() : "0";
            p.comp_id = int.TryParse(p.comp_id, out chk) ? chk.ToString() : "0";

            p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
            //p.amount_income = Decimal.TryParse(p.amount_income, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(Debtor p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            chkNull(p);
            if (p.status_debtor.Equals("2"))
            {
                p.amount = "-"+p.amount;
            }
            sql = "Insert Into " + dtr.table + "(" + dtr.amount + "," + dtr.cus_id + "," + dtr.payment_detail_id + "," +
                dtr.active + "," + dtr.remark + ", " + dtr.billing_detail_id + ", " +
                dtr.date_create + ", " + dtr.date_modi + ", " + dtr.date_cancel + ", " +
                dtr.user_create + ", " + dtr.user_modi + ", " + dtr.user_cancel + "," +
                dtr.job_id + "," + dtr.status_debtor + "," + dtr.comp_id + " " +
                ") " +
                "Values ('" + p.amount + "','" + p.cus_id + "','" + p.payment_detail_id.Replace("'", "''") + "'," +
                "'" + p.active + "','" + p.remark + "','" + p.billing_detail_id + "', " +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.job_id +  "','" + p.status_debtor + "','" + p.comp_id + "' " +
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
        public String update(Debtor p, String userId)
        {
            String re = "", sql = "";
            chkNull(p);
            //sql = "Update " + dtr.table + " Set " +
            //    " " + dtr.amount + "='" + p.amount + "' " +
            //    "," + dtr.payment_detail_id + "='" + p.payment_detail_id.Replace("'", "''") + "' " +
            //    "," + dtr.debtor_id + "='" + p.debtor_id.Replace("'", "''") + "' " +
            //    "," + dtr.remark + "='" + p.remark.Replace("'", "''") + "' " +
            //    "," + dtr.date_modi + "=now() " +
            //    "," + dtr.user_modi + "='" + userId.Replace("'", "''") + "' " +
            //    "," + dtr.billing_detail_id + "='" + p.billing_detail_id.Replace("'", "''") + "' " +
            //    "," + dtr.job_id + "='" + p.job_id.Replace("'", "''") + "' " +
            //    //"," + dtr.amount_income + "='" + p.amount_income.Replace("'", "''") + "' " +
            //    "Where " + dtr.pkField + "='" + p.debtor_id + "'"
            //    ;

            try
            {
                //re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }
            return re;
        }
        public String insertDebtor(Debtor p, String userId)
        {
            String re = "";

            if (p.debtor_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }
            return re;
        }
        public String voidDebtor(String id)
        {
            String re = "", sql = "";

            sql = "Update " + dtr.table + " Set " +
                " " + dtr.active + "='3' " +
                "," + dtr.date_cancel + "=now() " +
                "Where " + dtr.cus_id + "='" + id + "'"
                ;
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bill.* " +
                "From " + dtr.table + " bill " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ett." + dtr.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Debtor selectByPk1(String copId)
        {
            Debtor cop1 = new Debtor();
            DataTable dt = new DataTable();
            String sql = "select bill.* " +
                "From " + dtr.table + " bill " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bill." + dtr.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setDebtor(dt);
            return cop1;
        }
        public DataTable selectDebtor()
        {
            DataTable dt = new DataTable();
            String sql = "select bill."+dtr.cus_id+", sum("+dtr.amount+") as "+dtr.amount+",cus.cust_name_t " +
                "From " + dtr.table + " bill " +
                "Left Join b_customer cus On bill.cus_id = cus.cust_id " +
                "Where bill." + dtr.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Debtor setDebtor(DataTable dt)
        {
            Debtor bill1 = new Debtor();
            if (dt.Rows.Count > 0)
            {
                bill1.debtor_id = dt.Rows[0][dtr.debtor_id].ToString();
                bill1.cus_id = dt.Rows[0][dtr.cus_id].ToString();
                bill1.amount = dt.Rows[0][dtr.amount].ToString();
                bill1.billing_detail_id = dt.Rows[0][dtr.billing_detail_id].ToString();
                bill1.payment_detail_id = dt.Rows[0][dtr.payment_detail_id].ToString();
                bill1.active = dt.Rows[0][dtr.active].ToString();
                bill1.date_cancel = dt.Rows[0][dtr.date_cancel].ToString();
                bill1.date_create = dt.Rows[0][dtr.date_create].ToString();
                bill1.date_modi = dt.Rows[0][dtr.date_modi].ToString();
                bill1.user_cancel = dt.Rows[0][dtr.user_cancel].ToString();
                bill1.user_create = dt.Rows[0][dtr.user_create].ToString();
                bill1.user_modi = dt.Rows[0][dtr.user_modi].ToString();
                bill1.payment_detail_id = dt.Rows[0][dtr.payment_detail_id].ToString();
                bill1.remark = dt.Rows[0][dtr.remark].ToString();
                bill1.job_id = dt.Rows[0][dtr.job_id].ToString();
                bill1.status_debtor = dt.Rows[0][dtr.status_debtor].ToString();
                bill1.comp_id = dt.Rows[0][dtr.comp_id].ToString();
            }
            else
            {
                bill1.debtor_id = "";
                bill1.cus_id = "";
                bill1.amount = "";
                bill1.billing_detail_id = "";
                bill1.payment_detail_id = "";
                bill1.job_id = "";
                bill1.active = "";
                bill1.remark = "";
                bill1.date_create = "";
                bill1.date_modi = "";
                bill1.date_cancel = "";
                bill1.user_create = "";
                bill1.user_modi = "";
                bill1.user_cancel = "";
                bill1.status_debtor = "";
                bill1.comp_id = "";
            }

            return bill1;
        }
    }
}
