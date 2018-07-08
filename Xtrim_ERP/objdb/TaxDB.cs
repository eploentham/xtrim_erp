using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class TaxDB
    {
        public Tax tax;
        ConnectDB conn;
        public List<Tax> lexpn;
        public TaxDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            tax = new Tax();
            tax.tax_id = "tax_id";
            tax.tax_code = "tax_code";
            tax.tax_date = "tax_date";
            tax.job_id = "job_id";
            tax.job_code = "job_code";
            tax.expenses_pay_detail_id = "expenses_pay_detail_id";
            tax.active = "active";
            tax.remark = "remark";
            tax.date_create = "date_create";
            tax.date_modi = "date_modi";
            tax.date_cancel = "date_cancel";
            tax.user_create = "user_create";
            tax.user_modi = "user_modi";
            tax.user_cancel = "user_cancel";
            tax.cust_id = "cust_id";
            tax.year_id = "year_id";

            tax.cust_name_t = "cust_name_t";
            tax.cust_addr = "cust_addr";
            tax.cust_tele = "cust_tele";
            tax.agent_id = "agent_id";
            tax.agent_name_t = "agent_name_t";
            tax.agent_addr = "agent_addr";
            tax.agent_tele = "agent_tele";
            tax.payer_id = "payer_id";
            tax.payer_name_t = "payer_name_t";
            tax.payer_addr = "payer_addr";

            tax.payer_tele = "payer_tele";
            tax.status_tax_type = "status_tax_type";
            tax.row_no = "row_no";
            tax.status_payer = "status_payer";
            tax.payer_other = "payer_other";
            tax.status_tax_normal = "status_tax_normal";
            tax.tax_add_no = "tax_add_no";
            tax.ref1 = "ref1";
            tax.line1_date = "line1_date";
            tax.line1_amount = "line1_amount";

            tax.line1_tax = "line1_tax";
            tax.line2_date = "line2_date";
            tax.line2_amount = "line2_amount";
            tax.line2_tax = "line2_tax";
            tax.line3_date = "line3_date";
            tax.line3_amount = "line3_amount";
            tax.line3_tax = "line3_tax";
            tax.line41_date = "line41_date";
            tax.line41_amount = "line41_amount";
            tax.line41_tax = "line41_tax";

            tax.line41_text = "line41_text";
            tax.line421_date = "line421_date";
            tax.line421_amount = "line421_amount";
            tax.line421_tax = "line421_tax";
            tax.line421_text = "line421_text";
            tax.line422_date = "line422_date";
            tax.line422_amount = "line422_amount";
            tax.line422_tax = "line422_tax";
            tax.line422_text = "line422_text";
            tax.line423_date = "line423_date";

            tax.line423_amount = "line423_amount";
            tax.line423_tax = "line423_tax";
            tax.line423_text = "line423_text";
            tax.line5_date = "line5_date";
            tax.line5_amount = "line5_amount";
            tax.line5_tax = "line5_tax";
            tax.line5_text = "line5_text";
            tax.line6_date = "line6_date";
            tax.line6_amount = "line6_amount";
            tax.line6_tax = "line6_tax";
            tax.line6_text = "line6_text";
            tax.status_page = "status_page";
            //tax.year_id1 = "year_id";
            
            tax.table = "t_tax";
            tax.pkField = "tax_id";

            lexpn = new List<Tax>();
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Tax utp1 in lexpn)
            {
                if (name.Trim().Equals(utp1.tax_code))
                {
                    id = utp1.tax_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(Tax p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.tax_date = p.tax_date == null ? "" : p.tax_date;
            p.tax_code = p.tax_code == null ? "" : p.tax_code;
            p.job_code = p.job_code == null ? "" : p.job_code;
            p.remark = p.remark == null ? "" : p.remark;
            p.year_id = p.year_id == null ? "" : p.year_id;
            p.cust_name_t = p.cust_name_t == null ? "" : p.cust_name_t;
            p.cust_addr = p.cust_addr == null ? "" : p.cust_addr;
            p.cust_tele = p.cust_tele == null ? "" : p.cust_tele;
            p.agent_name_t = p.agent_name_t == null ? "" : p.agent_name_t;
            p.agent_addr = p.agent_addr == null ? "" : p.agent_addr;
            p.agent_tele = p.agent_tele == null ? "" : p.agent_tele;
            p.payer_name_t = p.payer_name_t == null ? "" : p.payer_name_t;
            p.payer_addr = p.payer_addr == null ? "" : p.payer_addr;
            p.payer_tele = p.payer_tele == null ? "" : p.payer_tele;
            p.status_tax_type = p.status_tax_type == null ? "" : p.status_tax_type;
            p.row_no = p.row_no == null ? "" : p.row_no;
            p.status_payer = p.status_payer == null ? "" : p.status_payer;
            p.payer_other = p.payer_other == null ? "" : p.payer_other;
            p.status_tax_normal = p.status_tax_normal == null ? "" : p.status_tax_normal;
            p.tax_add_no = p.tax_add_no == null ? "" : p.tax_add_no;
            p.ref1 = p.ref1 == null ? "" : p.ref1;
            p.line1_date = p.line1_date == null ? "" : p.line1_date;
            p.line2_date = p.line2_date == null ? "" : p.line2_date;
            p.line3_date = p.line3_date == null ? "" : p.line3_date;
            p.line41_date = p.line41_date == null ? "" : p.line41_date;
            p.line41_text = p.line41_text == null ? "" : p.line41_text;
            p.line421_date = p.line421_date == null ? "" : p.line421_date;
            p.line421_text = p.line421_text == null ? "" : p.line421_text;
            p.line422_date = p.line422_date == null ? "" : p.line422_date;
            p.line422_text = p.line422_text == null ? "" : p.line422_text;
            p.line423_date = p.line423_date == null ? "" : p.line423_date;
            p.line423_text = p.line423_text == null ? "" : p.line423_text;
            p.line5_date = p.line5_date == null ? "" : p.line5_date;
            p.line5_text = p.line5_text == null ? "" : p.line5_text;
            p.line6_date = p.line6_date == null ? "" : p.line6_date;
            p.line6_text = p.line6_text == null ? "" : p.line6_text;
            p.status_page = p.status_page == null ? "" : p.status_page;
            //p.year_id1 = p.year_id1 == null ? "" : p.year_id1;

            p.cust_id = int.TryParse(p.cust_id, out chk) ? chk.ToString() : "0";
            p.job_id = int.TryParse(p.job_id, out chk) ? chk.ToString() : "0";
            p.agent_id = int.TryParse(p.agent_id, out chk) ? chk.ToString() : "0";
            p.expenses_pay_detail_id = int.TryParse(p.expenses_pay_detail_id, out chk) ? chk.ToString() : "0";
            p.payer_id = int.TryParse(p.payer_id, out chk) ? chk.ToString() : "0";
            //p.agent_id1 = int.TryParse(p.agent_id1, out chk) ? chk.ToString() : "0";
            //p.agent_id1 = int.TryParse(p.agent_id1, out chk) ? chk.ToString() : "0";
            //p.agent_id1 = int.TryParse(p.agent_id1, out chk) ? chk.ToString() : "0";
            //p.agent_id1 = int.TryParse(p.agent_id1, out chk) ? chk.ToString() : "0";
            //p.agent_id1 = int.TryParse(p.agent_id1, out chk) ? chk.ToString() : "0";
            //p.agent_id1 = int.TryParse(p.agent_id1, out chk) ? chk.ToString() : "0";
            //p.agent_id1 = int.TryParse(p.agent_id1, out chk) ? chk.ToString() : "0";
            //p.agent_id1 = int.TryParse(p.agent_id1, out chk) ? chk.ToString() : "0";


            p.expenses_pay_detail_id = Decimal.TryParse(p.expenses_pay_detail_id, out chk1) ? chk1.ToString() : "0";
            p.line1_amount = Decimal.TryParse(p.line1_amount, out chk1) ? chk1.ToString() : "0";
            p.line1_tax = Decimal.TryParse(p.line1_tax, out chk1) ? chk1.ToString() : "0";
            p.line2_amount = Decimal.TryParse(p.line2_amount, out chk1) ? chk1.ToString() : "0";
            p.line2_tax = Decimal.TryParse(p.line2_tax, out chk1) ? chk1.ToString() : "0";
            p.line3_amount = Decimal.TryParse(p.line3_amount, out chk1) ? chk1.ToString() : "0";
            p.line3_tax = Decimal.TryParse(p.line3_tax, out chk1) ? chk1.ToString() : "0";
            p.line41_amount = Decimal.TryParse(p.line41_amount, out chk1) ? chk1.ToString() : "0";
            p.line41_tax = Decimal.TryParse(p.line41_tax, out chk1) ? chk1.ToString() : "0";
            p.line421_amount = Decimal.TryParse(p.line421_amount, out chk1) ? chk1.ToString() : "0";
            p.line421_tax = Decimal.TryParse(p.line421_tax, out chk1) ? chk1.ToString() : "0";
            p.line422_amount = Decimal.TryParse(p.line422_amount, out chk1) ? chk1.ToString() : "0";
            p.line422_tax = Decimal.TryParse(p.line422_tax, out chk1) ? chk1.ToString() : "0";
            p.line423_amount = Decimal.TryParse(p.line423_amount, out chk1) ? chk1.ToString() : "0";
            p.line423_tax = Decimal.TryParse(p.line423_tax, out chk1) ? chk1.ToString() : "0";
            p.line5_amount = Decimal.TryParse(p.line5_amount, out chk1) ? chk1.ToString() : "0";
            p.line5_tax = Decimal.TryParse(p.line5_tax, out chk1) ? chk1.ToString() : "0";
            p.line6_amount = Decimal.TryParse(p.line6_amount, out chk1) ? chk1.ToString() : "0";
            p.line6_tax = Decimal.TryParse(p.line6_tax, out chk1) ? chk1.ToString() : "0";
            //p.expenses_pay_detail_id1 = Decimal.TryParse(p.expenses_pay_detail_id1, out chk1) ? chk1.ToString() : "0";
            //p.expenses_pay_detail_id1 = Decimal.TryParse(p.expenses_pay_detail_id1, out chk1) ? chk1.ToString() : "0";
        }
        
        public String insert(Tax p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            chkNull(p);
            sql = "Insert Into " + tax.table + "(" + tax.tax_date + "," + tax.tax_code + "," + tax.job_code + "," +
                tax.active + "," + tax.remark + ", " + tax.job_id + ", " +
                tax.date_create + ", " + tax.date_modi + ", " + tax.date_cancel + ", " +
                tax.user_create + ", " + tax.user_modi + ", " + tax.user_cancel + "," +
                tax.expenses_pay_detail_id + "," + tax.cust_id + "," + tax.year_id + "," +
                tax.cust_name_t + "," + tax.cust_addr + "," + tax.cust_tele + "," +
                tax.agent_id + "," + tax.agent_name_t + "," + tax.agent_addr + "," +
                tax.agent_tele + "," + tax.payer_id + "," + tax.payer_name_t + "," +
                tax.payer_addr + "," + tax.payer_tele + "," + tax.status_tax_type + "," +
                tax.row_no + "," + tax.status_payer + "," + tax.payer_other + "," +
                tax.status_tax_normal + "," + tax.tax_add_no + "," + tax.ref1 + "," +
                tax.line1_date + "," + tax.line1_amount + "," + tax.line1_tax + "," +
                tax.line2_date + "," + tax.line2_amount + "," + tax.line2_tax + "," +
                tax.line3_date + "," + tax.line3_amount + "," + tax.line3_tax + "," +
                tax.line41_date + "," + tax.line41_amount + "," + tax.line41_tax + "," +
                tax.line41_text + "," + tax.line421_date + "," + tax.line421_amount + "," +
                tax.line421_tax + "," + tax.line421_text + "," + tax.line422_date + "," +
                tax.line422_amount + "," + tax.line422_tax + "," + tax.line422_text + "," +
                tax.line423_date + "," + tax.line423_amount + "," + tax.line423_tax + "," +
                tax.line423_text + "," + tax.line5_date + "," + tax.line5_amount + "," +
                tax.line5_tax + "," + tax.line5_text + "," + tax.line6_date + "," +
                tax.line6_amount + "," + tax.line6_tax + "," + tax.line6_text + "," +
                tax.status_page + " " +
                ") " +
                "Values ('" + p.tax_date + "','" + p.tax_code + "','" + p.job_code + "'," +
                "'" + p.active + "','" + p.remark + "','" + p.job_id + "', " +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.expenses_pay_detail_id + "','" + p.cust_id + "','" + p.year_id + "','" +
                "'" + p.cust_name_t + "','" + p.cust_addr + "','" + p.cust_tele + "','" +
                "'" + p.agent_id + "','" + p.agent_name_t + "','" + p.agent_addr + "','" +
                "'" + p.agent_tele + "','" + p.payer_id + "','" + p.payer_name_t + "','" +
                "'" + p.payer_addr + "','" + p.payer_tele + "','" + p.status_tax_type + "','" +
                "'" + p.row_no + "','" + p.status_payer + "','" + p.payer_other + "','" +
                "'" + p.status_tax_normal + "','" + p.tax_add_no + "','" + p.ref1 + "','" +
                "'" + p.line1_date + "','" + p.line1_amount + "','" + p.line1_tax + "','" +
                "'" + p.line2_date + "','" + p.line2_amount + "','" + p.line2_tax + "','" +
                "'" + p.line3_date + "','" + p.line3_amount + "','" + p.line3_tax + "','" +
                "'" + p.line41_date + "','" + p.line41_amount + "','" + p.line41_tax + "','" +
                "'" + p.line41_text + "','" + p.line421_date + "','" + p.line421_amount + "','" +
                "'" + p.line421_tax + "','" + p.line421_text + "','" + p.line422_date + "','" +
                "'" + p.line422_amount + "','" + p.line422_tax + "','" + p.line422_text + "','" +
                "'" + p.line423_date + "','" + p.line423_amount + "','" + p.line423_tax + "','" +
                "'" + p.line423_text + "','" + p.line5_date + "','" + p.line5_amount + "','" +
                "'" + p.line5_tax + "','" + p.line5_text + "','" + p.line6_date + "','" +
                "'" + p.line6_amount + "','" + p.line6_tax + "','" + p.line6_text + "','" +
                "'" + p.status_page + "' " +
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
        public String update(Tax p, String userId)
        {
            String re = "", sql = "";
            chkNull(p);
            sql = "Update " + tax.table + " Set " +
                " " + tax.tax_date + "='" + p.tax_date + "' " +
                "," + tax.job_code + "='" + p.job_code.Replace("'", "''") + "' " +
                "," + tax.tax_code + "='" + p.tax_code.Replace("'", "''") + "' " +
                "," + tax.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + tax.date_modi + "=now() " +
                "," + tax.user_modi + "='" + userId.Replace("'", "''") + "' " +
                "," + tax.job_id + "='" + p.job_id.Replace("'", "''") + "' " +
                "," + tax.expenses_pay_detail_id + "='" + p.expenses_pay_detail_id.Replace("'", "''") + "' " +
                "," + tax.cust_id + "='" + p.cust_id.Replace("'", "''") + "' " +
                "," + tax.year_id + "='" + p.year_id.Replace("'", "''") + "' " +
                "Where " + tax.pkField + "='" + p.tax_id + "'"
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
        public String insertTax(Tax p, String userId)
        {
            String re = "";

            if (p.tax_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }
            return re;
        }
        public String voidTax(String id)
        {
            String re = "", sql = "";
            sql = "Update " + tax.table + " Set " +
                " " + tax.active + "='3' " +
                "," + tax.date_cancel + "=now() " +
                "Where " + tax.tax_id + "='" + id + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String updateBillingCover(String id, String coverid)
        {
            String re = "", sql = "";
            sql = "Update " + tax.table + " Set " +
                " " + tax.year_id + "='" + coverid + "' " +
                "Where " + tax.tax_id + "='" + id + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public DataTable selectByCusId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + tax.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + tax.cust_id + " ='" + copId + "' and " + tax.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByJobId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + tax.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + tax.job_id + " ='" + copId + "' and " + tax.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + tax.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + tax.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Tax selectByPk1(String copId)
        {
            Tax cop1 = new Tax();
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + tax.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + tax.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setTax(dt);
            return cop1;
        }
        public Tax setTax(DataTable dt)
        {
            Tax bll1 = new Tax();
            if (dt.Rows.Count > 0)
            {
                bll1.tax_id = dt.Rows[0][tax.tax_id].ToString();
                bll1.tax_code = dt.Rows[0][tax.tax_code].ToString();
                bll1.tax_date = dt.Rows[0][tax.tax_date].ToString();
                bll1.job_id = dt.Rows[0][tax.job_id].ToString();
                bll1.active = dt.Rows[0][tax.active].ToString();
                bll1.date_cancel = dt.Rows[0][tax.date_cancel].ToString();
                bll1.date_create = dt.Rows[0][tax.date_create].ToString();
                bll1.date_modi = dt.Rows[0][tax.date_modi].ToString();
                bll1.user_cancel = dt.Rows[0][tax.user_cancel].ToString();
                bll1.user_create = dt.Rows[0][tax.user_create].ToString();
                bll1.user_modi = dt.Rows[0][tax.user_modi].ToString();
                bll1.job_code = dt.Rows[0][tax.job_code].ToString();
                bll1.remark = dt.Rows[0][tax.remark].ToString();
                bll1.expenses_pay_detail_id = dt.Rows[0][tax.expenses_pay_detail_id].ToString();
                bll1.cust_id = dt.Rows[0][tax.cust_id].ToString();
                bll1.year_id = dt.Rows[0][tax.year_id].ToString();
            }
            else
            {
                bll1.tax_id = "";
                bll1.tax_code = "";
                bll1.tax_date = "";
                bll1.job_id = "";
                bll1.job_code = "";
                bll1.expenses_pay_detail_id = "";
                bll1.active = "";
                bll1.remark = "";
                bll1.date_create = "";
                bll1.date_modi = "";
                bll1.date_cancel = "";
                bll1.user_create = "";
                bll1.user_modi = "";
                bll1.user_cancel = "";
                bll1.cust_id = "";
                bll1.year_id = "";
            }

            return bll1;
        }
    }
}
