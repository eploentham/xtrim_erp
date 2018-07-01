using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class CompanyBankDB
    {
        public CompanyBank copB;
        ConnectDB conn;
        public CompanyBankDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            copB = new CompanyBank();
            copB.comp_bank_id = "comp_bank_id";
            copB.comp_id = "comp_id";
            copB.comp_bank_name_t = "comp_bank_name_t";
            copB.comp_bank_branch = "comp_bank_branch";
            copB.comp_bank_active = "comp_bank_active";
            copB.acc_number = "acc_number";
            copB.remark = "remark";
            copB.date_create = "date_create";
            copB.date_modi = "date_modi";
            copB.date_cancel = "date_cancel";
            copB.user_create = "user_create";
            copB.user_modi = "user_modi";
            copB.user_cancel = "user_cancel";
            copB.active = "active";
            copB.bank_id = "bank_id";
        }
        private void chkNull(CompanyBank p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.comp_id = p.comp_id == null ? "" : p.comp_id;
            p.comp_bank_name_t = p.comp_bank_name_t == null ? "" : p.comp_bank_name_t;
            p.comp_bank_active = p.comp_bank_active == null ? "" : p.comp_bank_active;
            p.acc_number = p.acc_number == null ? "" : p.acc_number;
            p.remark = p.remark == null ? "" : p.remark;
            p.active = p.active == null ? "" : p.active;
            //p.bank_id = p.bank_id == null ? "" : p.bank_id;
            //p.inv_line2 = p.inv_line2 == null ? "" : p.inv_line2;
            //p.inv_line4 = p.inv_line4 == null ? "" : p.inv_line4;


            p.bank_id = int.TryParse(p.bank_id, out chk) ? chk1.ToString() : "0";
        }
        public String insert(CompanyBank p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";


            chkNull(p);
            sql = "Insert Into " + copB.table + "(" + copB.comp_id + "," + copB.comp_bank_name_t + "," + copB.comp_bank_branch + "," +
                copB.comp_bank_active + "," + copB.acc_number + ", " + copB.remark + ", " +
                copB.date_create + "," + copB.date_modi + ", " + copB.date_cancel + ", " +
                copB.user_create + "," + copB.user_modi + ", " + copB.user_cancel + ", " +
                copB.active + "," + copB.bank_id + " " +
                ") " +
                "Values ('" + p.comp_id + "','" + p.comp_bank_name_t.Replace("'", "''") + "','" + p.comp_bank_branch.Replace("'", "''") + "'," +
                "'" + p.comp_bank_active.Replace("'", "''") + "','" + p.acc_number.Replace("'", "''") + "','" + p.remark.Replace("'", "''") + "'," +
                "'" + p.date_create.Replace("'", "''") + "','" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.active + "','" + p.bank_id + "' " + 
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
        public String update(CompanyBank p, String userId)
        {
            String re = "", sql = "";

            chkNull(p);

            sql = "Update " + copB.table + " Set " +
                " " + copB.comp_id + "='" + p.comp_id + "' " +
                "," + copB.comp_bank_name_t + "='" + p.comp_bank_name_t.Replace("'", "''") + "' " +
                "," + copB.comp_bank_branch + "='" + p.comp_bank_branch.Replace("'", "''") + "' " +
                "," + copB.comp_bank_active + "='" + p.comp_bank_active.Replace("'", "''") + "' " +
                "," + copB.acc_number + "='" + p.acc_number.Replace("'", "''") + "' " +
                "," + copB.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + copB.date_modi + "=now() " +
                "," + copB.user_modi + "='" + userId + "' " +
                "," + copB.bank_id + "='" + p.bank_id + "' " +                
                "Where " + copB.pkField + "='" + p.comp_bank_id + "'"
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
        public String insertCompany(CompanyBank p, String userId)
        {
            String re = "";

            if (p.comp_bank_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select copB.*  " +
                "From " + copB.table + " copB " +
                " " +
                "Where copB." + copB.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select copB.* " +
                "From " + copB.table + " copB " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where copB." + copB.comp_id + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public CompanyBank selectByPk1(String copId)
        {
            CompanyBank cop1 = new CompanyBank();
            DataTable dt = new DataTable();
            String sql = "select copB.* " +
                "From " + copB.table + " copB " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where copB." + copB.comp_id + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setCompany(dt);
            return cop1;
        }
        private CompanyBank setCompany(DataTable dt)
        {
            CompanyBank cop1 = new CompanyBank();
            if (dt.Rows.Count > 0)
            {
                cop1.comp_bank_id = dt.Rows[0][copB.comp_bank_id].ToString();
                cop1.comp_id = dt.Rows[0][copB.comp_id].ToString();
                cop1.comp_bank_name_t = dt.Rows[0][copB.comp_bank_name_t].ToString();
                cop1.comp_bank_branch = dt.Rows[0][copB.comp_bank_branch].ToString();
                cop1.comp_bank_active = dt.Rows[0][copB.comp_bank_active].ToString();
                cop1.acc_number = dt.Rows[0][copB.acc_number].ToString();
                cop1.remark = dt.Rows[0][copB.remark].ToString();
                cop1.date_create = dt.Rows[0][copB.date_create].ToString();
                cop1.date_modi = dt.Rows[0][copB.date_modi].ToString();
                cop1.date_cancel = dt.Rows[0][copB.date_cancel].ToString();
                cop1.user_create = dt.Rows[0][copB.user_create].ToString();
                cop1.user_modi = dt.Rows[0][copB.user_modi].ToString();
                cop1.user_cancel = dt.Rows[0][copB.user_cancel].ToString();
                cop1.active = dt.Rows[0][copB.active].ToString();
                cop1.bank_id = dt.Rows[0][copB.bank_id].ToString();               

            }
            else
            {
                cop1.comp_bank_id = "";
                cop1.comp_id = "";
                cop1.comp_bank_name_t = "";
                cop1.comp_bank_branch = "";
                cop1.comp_bank_active = "";
                cop1.acc_number = "";
                cop1.remark = "";
                cop1.date_create = "";
                cop1.date_modi = "";
                cop1.date_cancel = "";
                cop1.user_create = "";
                cop1.user_modi = "";
                cop1.user_cancel = "";
                cop1.active = "";
                cop1.bank_id = "";
            }

            return cop1;
        }
    }
}
