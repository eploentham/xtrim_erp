using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class BillingCoverDB
    {
        public BillingCover bllC;
        ConnectDB conn;
        public List<BillingCover> lexpn;
        public BillingCoverDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            bllC = new BillingCover();
            bllC.billing_cover_id = "billing_cover_id";
            bllC.billing_cover_code = "billing_cover_code";
            bllC.remark1 = "remark1";
            bllC.remark2 = "remark2";
            bllC.active = "active";
            bllC.remark = "remark";
            bllC.date_create = "date_create";
            bllC.date_modi = "date_modi";
            bllC.date_cancel = "date_cancel";
            bllC.user_create = "user_create";
            bllC.user_modi = "user_modi";
            bllC.user_cancel = "user_cancel";
            bllC.job_id = "job_id";
            bllC.cust_id = "cust_id";

            bllC.table = "t_billing_cover";
            bllC.pkField = "billing_cover_id";

            lexpn = new List<BillingCover>();
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (BillingCover utp1 in lexpn)
            {
                if (name.Trim().Equals(utp1.billing_cover_code))
                {
                    id = utp1.billing_cover_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(BillingCover p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.remark1 = p.remark1 == null ? "" : p.remark1;
            p.billing_cover_code = p.billing_cover_code == null ? "" : p.billing_cover_code;
            
            p.remark = p.remark == null ? "" : p.remark;
            p.remark2 = p.remark2 == null ? "" : p.remark2;

            p.cust_id = int.TryParse(p.cust_id, out chk) ? chk.ToString() : "0";
            p.job_id = int.TryParse(p.job_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(BillingCover p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            chkNull(p);
            sql = "Insert Into " + bllC.table + "(" + bllC.remark1 + "," + bllC.billing_cover_code + "," + bllC.job_id + "," +
                bllC.active + "," + bllC.remark + ", " + bllC.remark2 + ", " +
                bllC.date_create + ", " + bllC.date_modi + ", " + bllC.date_cancel + ", " +
                bllC.user_create + ", " + bllC.user_modi + ", " + bllC.user_cancel + "," +
                bllC.cust_id + " " +
                ") " +
                "Values ('" + p.remark1 + "','" + p.billing_cover_code + "','" + p.job_id + "'," +
                "'" + p.active + "','" + p.remark + "','" + p.remark2 + "'," +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.cust_id + "' " +
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
        public String update(BillingCover p, String userId)
        {
            String re = "", sql = "";
            chkNull(p);
            sql = "Update " + bllC.table + " Set " +
                " " + bllC.remark1 + "='" + p.remark1 + "' " +                
                "," + bllC.billing_cover_code + "='" + p.billing_cover_code.Replace("'", "''") + "' " +
                "," + bllC.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + bllC.date_modi + "=now() " +
                "," + bllC.user_modi + "='" + userId.Replace("'", "''") + "' " +
                "," + bllC.remark2 + "='" + p.remark2.Replace("'", "''") + "' " +
                "," + bllC.job_id + "='" + p.job_id.Replace("'", "''") + "' " +
                "," + bllC.cust_id + "='" + p.cust_id.Replace("'", "''") + "' " +
                "Where " + bllC.pkField + "='" + p.billing_cover_id + "'";

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
        public String insertBillingCover(BillingCover p, String userId)
        {
            String re = "";

            if (p.billing_cover_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }
            return re;
        }
        public String voidBillingCover(String id)
        {
            String re = "", sql = "";

            sql = "Update " + bllC.table + " Set " +
                " " + bllC.active + "='3' " +
                "," + bllC.date_cancel + "=now() " +
                "Where " + bllC.billing_cover_id + "='" + id + "'"
                ;
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        //public DataTable selectByCusId(String copId)
        //{
        //    DataTable dt = new DataTable();
        //    String sql = "select bll.* " +
        //        "From " + bllC.table + " bll " +
        //        //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
        //        "Where bll." + bllC.cust_id + " ='" + copId + "' and " + bllC.active + "='1' ";
        //    dt = conn.selectData(conn.conn, sql);
        //    return dt;
        //}
        public DataTable selectByJobId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + bllC.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + bllC.remark2 + " ='" + copId + "' and " + bllC.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + bllC.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + bllC.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public BillingCover selectByPk1(String copId)
        {
            BillingCover cop1 = new BillingCover();
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + bllC.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + bllC.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setBillingCover(dt);
            return cop1;
        }
        public BillingCover setBillingCover(DataTable dt)
        {
            BillingCover bllC1 = new BillingCover();
            if (dt.Rows.Count > 0)
            {
                bllC1.billing_cover_id = dt.Rows[0][bllC.billing_cover_id].ToString();
                bllC1.billing_cover_code = dt.Rows[0][bllC.billing_cover_code].ToString();
                bllC1.remark1 = dt.Rows[0][bllC.remark1].ToString();
                bllC1.remark2 = dt.Rows[0][bllC.remark2].ToString();
                bllC1.active = dt.Rows[0][bllC.active].ToString();
                bllC1.date_cancel = dt.Rows[0][bllC.date_cancel].ToString();
                bllC1.date_create = dt.Rows[0][bllC.date_create].ToString();
                bllC1.date_modi = dt.Rows[0][bllC.date_modi].ToString();
                bllC1.user_cancel = dt.Rows[0][bllC.user_cancel].ToString();
                bllC1.user_create = dt.Rows[0][bllC.user_create].ToString();
                bllC1.user_modi = dt.Rows[0][bllC.user_modi].ToString();
                bllC1.cust_id = dt.Rows[0][bllC.cust_id].ToString();
                bllC1.remark = dt.Rows[0][bllC.remark].ToString();
                bllC1.job_id = dt.Rows[0][bllC.job_id].ToString();
            }
            else
            {
                bllC1.billing_cover_id = "";
                bllC1.billing_cover_code = "";
                bllC1.remark1 = "";
                bllC1.remark2 = "";
                
                bllC1.active = "";
                bllC1.remark = "";
                bllC1.date_create = "";
                bllC1.date_modi = "";
                bllC1.date_cancel = "";
                bllC1.user_create = "";
                bllC1.user_modi = "";
                bllC1.user_cancel = "";
                bllC1.cust_id = "";
                bllC1.job_id = "";
            }

            return bllC1;
        }
    }
}
