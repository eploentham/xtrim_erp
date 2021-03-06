﻿using C1.Win.C1Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class BillingDB
    {
        public Billing bll;
        ConnectDB conn;
        public List<Billing> lexpn;
        public BillingDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            bll = new Billing();
            bll.billing_id = "billing_id";
            bll.billing_code = "billing_code";
            bll.billing_date = "billing_date";
            bll.job_id = "job_id";
            bll.job_code = "job_code";
            bll.amount = "amount";
            bll.active = "active";
            bll.remark = "remark";
            bll.date_create = "date_create";
            bll.date_modi = "date_modi";
            bll.date_cancel = "date_cancel";
            bll.user_create = "user_create";
            bll.user_modi = "user_modi";
            bll.user_cancel = "user_cancel";
            bll.cust_id = "cust_id";
            bll.billing_cover_id = "billing_cover_id";

            bll.table = "t_billing";
            bll.pkField = "billing_id";

            lexpn = new List<Billing>();
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Billing utp1 in lexpn)
            {
                if (name.Trim().Equals(utp1.billing_code))
                {
                    id = utp1.billing_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(Billing p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.billing_date = p.billing_date == null ? "" : p.billing_date;
            p.billing_code = p.billing_code == null ? "" : p.billing_code;
            p.job_code = p.job_code == null ? "" : p.job_code;
            p.remark = p.remark == null ? "" : p.remark;

            p.cust_id = int.TryParse(p.cust_id, out chk) ? chk.ToString() : "0";
            p.job_id = int.TryParse(p.job_id, out chk) ? chk.ToString() : "0";
            p.billing_cover_id = int.TryParse(p.billing_cover_id, out chk) ? chk.ToString() : "0";

            p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(Billing p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            chkNull(p);
            sql = "Insert Into " + bll.table + "(" + bll.billing_date + "," + bll.billing_code + "," + bll.job_code + "," +
                bll.active + "," + bll.remark + ", " + bll.job_id + ", " +
                bll.date_create + ", " + bll.date_modi + ", " + bll.date_cancel + ", " +
                bll.user_create + ", " + bll.user_modi + ", " + bll.user_cancel + "," +
                bll.amount + "," + bll.cust_id + "," + bll.billing_cover_id + " " +
                ") " +
                "Values ('" + p.billing_date + "','" + p.billing_code + "','" + p.job_code + "'," +
                "'" + p.active + "','" + p.remark + "','" + p.job_id + "', " +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.amount + "','" + p.cust_id + "','" + p.billing_cover_id + "' " +
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
        public String update(Billing p, String userId)
        {
            String re = "", sql = "";
            chkNull(p);
            sql = "Update " + bll.table + " Set " +
                " " + bll.billing_date + "='" + p.billing_date + "' " +
                "," + bll.job_code + "='" + p.job_code.Replace("'", "''") + "' " +
                "," + bll.billing_code + "='" + p.billing_code.Replace("'", "''") + "' " +
                "," + bll.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + bll.date_modi + "=now() " +
                "," + bll.user_modi + "='" + userId.Replace("'", "''") + "' " +
                "," + bll.job_id + "='" + p.job_id.Replace("'", "''") + "' " +
                "," + bll.amount + "='" + p.amount.Replace("'", "''") + "' " +
                "," + bll.cust_id + "='" + p.cust_id.Replace("'", "''") + "' " +
                "," + bll.billing_cover_id + "='" + p.billing_cover_id.Replace("'", "''") + "' " +
                "Where " + bll.pkField + "='" + p.billing_id + "'";
            
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
        public String insertBilling(Billing p, String userId)
        {
            String re = "";

            if (p.billing_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }
            return re;
        }
        public String voidBilling(String id)
        {
            String re = "", sql = "";
            sql = "Update " + bll.table + " Set " +
                " " + bll.active + "='3' " +
                "," + bll.date_cancel + "=now() " +
                "Where " + bll.billing_id + "='" + id + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String updateBillingCover(String id, String coverid)
        {
            String re = "", sql = "";
            sql = "Update " + bll.table + " Set " +
                " " + bll.billing_cover_id + "='"+ coverid + "' " +
                "Where " + bll.billing_id + "='" + id + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public DataTable selectByCusId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + bll.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + bll.cust_id + " ='" + copId + "' and " + bll.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByJobId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + bll.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + bll.job_id + " ='" + copId + "' and "+bll.active+"='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Billing selectByBillCode1(String copId)
        {
            Billing cop1 = new Billing();
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + bll.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + bll.billing_code + " ='" + copId + "' and " + bll.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setBilling(dt);
            return cop1;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + bll.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + bll.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Billing selectByPk1(String copId)
        {
            Billing cop1 = new Billing();
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + bll.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + bll.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setBilling(dt);
            return cop1;
        }
        public Billing setBilling(DataTable dt)
        {
            Billing bll1 = new Billing();
            if (dt.Rows.Count > 0)
            {
                bll1.billing_id = dt.Rows[0][bll.billing_id].ToString();
                bll1.billing_code = dt.Rows[0][bll.billing_code].ToString();
                bll1.billing_date = dt.Rows[0][bll.billing_date].ToString();
                bll1.job_id = dt.Rows[0][bll.job_id].ToString();
                bll1.active = dt.Rows[0][bll.active].ToString();
                bll1.date_cancel = dt.Rows[0][bll.date_cancel].ToString();
                bll1.date_create = dt.Rows[0][bll.date_create].ToString();
                bll1.date_modi = dt.Rows[0][bll.date_modi].ToString();
                bll1.user_cancel = dt.Rows[0][bll.user_cancel].ToString();
                bll1.user_create = dt.Rows[0][bll.user_create].ToString();
                bll1.user_modi = dt.Rows[0][bll.user_modi].ToString();
                bll1.job_code = dt.Rows[0][bll.job_code].ToString();
                bll1.remark = dt.Rows[0][bll.remark].ToString();
                bll1.amount = dt.Rows[0][bll.amount].ToString();
                bll1.cust_id = dt.Rows[0][bll.cust_id].ToString();
                bll1.billing_cover_id = dt.Rows[0][bll.billing_cover_id].ToString();
            }
            else
            {
                bll1.billing_id = "";
                bll1.billing_code = "";
                bll1.billing_date = "";
                bll1.job_id = "";
                bll1.job_code = "";
                bll1.amount = "";
                bll1.active = "";
                bll1.remark = "";
                bll1.date_create = "";
                bll1.date_modi = "";
                bll1.date_cancel = "";
                bll1.user_create = "";
                bll1.user_modi = "";
                bll1.user_cancel = "";
                bll1.cust_id = "";
                bll1.billing_cover_id = "";
            }

            return bll1;
        }
    }
}
