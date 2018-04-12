﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class StaffDB
    {
        public Staff stf;
        ConnectDB conn;
        public StaffDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            stf = new Staff();
            stf.staff_id = "staff_id";
            stf.staff_code = "staff_code";
            stf.username = "username";
            stf.prefix = "prefix";
            stf.staff_name_t = "staff_name_t";
            stf.staff_name_e = "staff_name_e";
            stf.password1 = "password1";
            stf.active = "active";
            stf.staff_remark = "staff_remark";
            stf.priority = "priority";
            stf.tele = "tele";
            stf.mobile = "mobile";
            stf.fax = "fax";
            stf.email = "email";
            stf.posi_id = "posi_id";
            stf.posi_name = "posi_name";
            stf.date_create = "date_create";
            stf.date_modi = "date_modi";
            stf.date_cancel = "date_cancel";
            stf.user_create = "user_create";
            stf.user_modi = "user_modi";
            stf.user_cancel = "user_cancel";
        }
        public String insert(Staff p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            sql = "Insert Into " + stf.table + "(" + stf.staff_code + "," + stf.username + "," + stf.prefix + "," +
                stf.staff_name_t + "," + stf.staff_name_e + "," + stf.password1 + "," +
                stf.active + "," + stf.staff_remark + "," + stf.priority + "," +
                stf.tele + "," + stf.mobile + "," + stf.fax + "," +
                stf.email + "," + stf.posi_id + "," + stf.posi_name + "," +
                stf.date_create + "," + stf.date_modi + "," + stf.date_cancel + "," +
                stf.user_create + "," + stf.user_modi + "," + stf.user_cancel + " "+
                ") " +
                "Values ('" + p.staff_code + "','" + p.username + "','" + p.prefix + "'," +
                "'" + p.staff_name_t + "','" + p.staff_name_e + "','" + p.password1 + "'," +
                "'" + p.active + "','" + p.staff_remark + "','" + p.priority + "'," +
                "'" + p.tele + "','" + p.mobile + "','" + p.fax + "'," +
                "'" + p.email + "','" + p.posi_id + "','" + p.posi_name + "'," +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + p.user_create + "','" + p.user_modi + "','" + p.user_cancel + "' " +
                ")";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
    }
}