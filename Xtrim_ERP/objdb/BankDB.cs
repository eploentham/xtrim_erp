using C1.Win.C1Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class BankDB
    {
        public Bank bnk;
        ConnectDB conn;

        public List<Bank> lexpn;
        public BankDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            bnk = new Bank();
            bnk.bank_id = "bank_id";
            bnk.bank_code = "bank_code";
            bnk.bank_name_t = "bank_name_t";
            bnk.bank_name_e = "bank_name_e";
            bnk.active = "active";
            bnk.remark = "remark";
            bnk.user_cancel = "user_cancel";
            bnk.user_create = "user_create";
            bnk.user_modi = "user_modi";
            bnk.date_cancel = "date_cancel";
            bnk.date_create = "date_create";
            bnk.date_modi = "date_modi";

            bnk.table = "b_bank";
            bnk.pkField = "bank_id";

            lexpn = new List<Bank>();
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Bank utp1 in lexpn)
            {
                if (name.Trim().Equals(utp1.bank_name_t))
                {
                    id = utp1.bank_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(Bank p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.bank_code = p.bank_code == null ? "" : p.bank_code;
            p.bank_name_t = p.bank_name_t == null ? "" : p.bank_name_t;
            p.bank_name_e = p.bank_name_e == null ? "" : p.bank_name_e;
            p.remark = p.remark == null ? "" : p.remark;
            

            //p.amount_reserve = Decimal.TryParse(p.amount_reserve, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(Bank p, String userId)
        {
            String re = "", sql="";            
            p.active = "1";
            //p.ssdata_id = "";
            chkNull(p);
            sql = "Insert Into " + bnk.table + "(" + bnk.bank_code + "," + bnk.bank_name_t + "," + bnk.bank_name_e + "," +
                bnk.active + "," + bnk.remark + ", " + 
                bnk.date_create + ", " + bnk.date_modi + ", " + bnk.date_cancel + ", " +
                bnk.user_create + ", " + bnk.user_modi + ", " + bnk.user_cancel + " " +
                ") " +
                "Values ('" + p.bank_code + "','" + p.bank_name_t + "','" + p.bank_name_e + "'," +
                "'" + p.active + "','" + p.remark + "', " +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "' " +
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
        public String update(Bank p, String userId)
        {
            String re = "", sql="";
            chkNull(p);
            sql = "Update "+bnk.table + " Set " +
                " "+bnk.bank_code +"='"+p.bank_code+"' " +
                ","+bnk.bank_name_e + "='" + p.bank_name_e.Replace("'", "''") + "' " +
                "," + bnk.bank_name_t + "='" + p.bank_name_t.Replace("'", "''") + "' " +
                "," + bnk.remark + "='" + p.remark.Replace("'","''") + "' " +
                "," + bnk.date_modi + "=now() " +
                "," + bnk.user_modi + "='" + userId.Replace("'", "''") + "' " +
                "Where " +bnk.bank_id +"='"+p.bank_id+"'"
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
        public String insertBank(Bank p, String userId)
        {
            String re = "";

            if (p.bank_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }
            return re;
        }
        public String voidBank(String id)
        {
            String re = "", sql = "";

            sql = "Update " + bnk.table + " Set " +
                " " + bnk.active + "='3' " +                
                "," + bnk.date_cancel + "=now() " +
                "Where " + bnk.bank_id + "='" + id + "'"
                ;
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }

        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select ban.*  " +
                "From " + bnk.table + " ban " +
                " " +
                "Where ban." + bnk.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll1()
        {
            DataTable dt = new DataTable();
            String sql = "select ban."+bnk.bank_id+","+bnk.bank_name_t+","+bnk.remark+" " +
                "From " + bnk.table + " ban " +
                " " +
                "Where ban." + bnk.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public C1ComboBox setC1CboItem(C1ComboBox c)
        {
            lexpn.Clear();
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[bnk.bank_name_t].ToString();
                item.Value = row[bnk.bank_id].ToString();
                c.Items.Add(item);

                Bank expn1 = new Bank();
                expn1.bank_id = row[bnk.bank_id].ToString();
                expn1.bank_code = row[bnk.bank_code].ToString();
                expn1.bank_name_e = row[bnk.bank_name_e].ToString();
                expn1.bank_name_t = row[bnk.bank_name_t].ToString();

                lexpn.Add(expn1);
            }
            return c;
        }

    }
}
