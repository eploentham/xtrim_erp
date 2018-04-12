using System;
using System.Collections.Generic;
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
            ban.bank_id = "";
            ban.bank_code = "";
            ban.bank_name_t = "";
            ban.bank_name_e = "";
            ban.active = "";
            ban.remark = "";
        }
        public String insert(Bank p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            sql = "Insert Into " + ban.table + "(" + ban.bank_code + "," + ban.bank_name_t + "," + ban.bank_name_e + "," +
                ban.active + "," + ban.remark + " " +
                ") " +
                "Values ('" + p.bank_code + "','" + p.bank_name_t + "','" + p.bank_name_e + "'," +
                "'" + p.active + "','" + p.remark + "' " +
                ")";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
    }
}
