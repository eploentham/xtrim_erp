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
        public Bank ban;
        ConnectDB conn;

        public BankDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ban = new Bank();
            ban.bank_id = "bank_id";
            ban.bank_code = "bank_code";
            ban.bank_name_t = "bank_name_t";
            ban.bank_name_e = "bank_name_e";
            ban.active = "active";
            ban.remark = "remark";
            ban.user_cancel = "user_cancel";
            ban.user_create = "user_create";
            ban.user_modi = "user_modi";
            ban.date_cancel = "date_cancel";
            ban.date_create = "date_create";
            ban.date_modi = "date_modi";

            ban.table = "b_bank";
            ban.pkField = "bank_id";
        }
        public String insert(Bank p)
        {
            String re = "", sql="";            
            p.active = "1";
            //p.ssdata_id = "";
            sql = "Insert Into " + ban.table + "(" + ban.bank_code + "," + ban.bank_name_t + "," + ban.bank_name_e + "," +
                ban.active + "," + ban.remark + ", " + ban.date_create + " " +
                ") " +
                "Values ('" + p.bank_code + "','" + p.bank_name_t + "','" + p.bank_name_e + "'," +
                "'" + p.active + "','" + p.remark + "', now() " +
                ")";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String update(Bank p)
        {
            String re = "", sql="";

            sql = "Update "+ban.table + " Set " +
                " "+ban.bank_code +"='"+p.bank_code+"' " +
                ","+ban.bank_name_e + "='" + p.bank_name_e.Replace("'", "''") + "' " +
                "," + ban.bank_name_t + "='" + p.bank_name_t.Replace("'", "''") + "' " +
                "," + ban.remark + "='" + p.remark.Replace("'","''") + "' " +
                "," + ban.date_modi + "=now() " +
                "Where " +ban.bank_id +"='"+p.bank_id+"'"
                ;
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String insertBank(Bank p)
        {
            String re = "";

            if (p.bank_id.Equals(""))
            {
                re = insert(p);
            }
            else
            {
                re = update(p);
            }

            return re;
        }
        public String voidBank(String id)
        {
            String re = "", sql = "";

            sql = "Update " + ban.table + " Set " +
                " " + ban.active + "='3' " +                
                "," + ban.date_cancel + "=now() " +
                "Where " + ban.bank_id + "='" + id + "'"
                ;
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }

        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select ban.*  " +
                "From " + ban.table + " ban " +
                " " +
                "Where ban." + ban.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        
    }
}
