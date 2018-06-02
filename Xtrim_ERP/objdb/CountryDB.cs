using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class CountryDB
    {
        public Country cot;
        ConnectDB conn;

        public CountryDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            cot = new Country();
            cot.cou_id = "cou_id";
            cot.cou_code = "cou_code";
            cot.cou_code2 = "cou_code2";
            cot.cou_code3 = "cou_code3";
            cot.cou_name = "cou_name";
            cot.cou_name1 = "cou_name1";
            cot.cou_name2 = "cou_name2";
            cot.currency = "currency";
            cot.wtocountry = "wtocountry";
            cot.startdate = "startdate";
            cot.finishdate = "finishdate";
            cot.progver = "progver";
            cot.usrname = "usrname";
            cot.update_dd = "update_dd";
            cot.update_tt = "update_tt";
            cot.sort1 = "sort1";
            cot.date_cancel = "date_cancel";
            cot.date_create = "date_create";
            cot.date_modi = "date_modi";
            cot.user_cancel = "user_cancel";
            cot.user_create = "user_create";
            cot.user_modi = "user_modi";
            cot.remark = "remark";
            cot.active = "active";

            cot.table = "b_country";
            cot.pkField = "cou_id";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cot.*  " +
                "From " + cot.table + " cot " +
                " " +
                //"Where cot." + cot.active + " ='1' "
                "";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select cot.* " +
                "From " + cot.table + " cot " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cot." + cot.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Country selectByPk1(String copId)
        {
            Country cop1 = new Country();
            DataTable dt = new DataTable();
            String sql = "select cot.* " +
                "From " + cot.table + " cot " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cot." + cot.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setCountry(dt);
            return cop1;
        }
        private Country setCountry(DataTable dt)
        {
            Country cot1 = new Country();
            if (dt.Rows.Count > 0)
            {
                cot1.cou_id = dt.Rows[0][cot.cou_id].ToString();
                cot1.cou_code = dt.Rows[0][cot.cou_code].ToString();
                cot1.cou_code2 = dt.Rows[0][cot.cou_code2].ToString();
                cot1.cou_code3 = dt.Rows[0][cot.cou_code3].ToString();
                cot1.cou_name = dt.Rows[0][cot.cou_name].ToString();
                cot1.cou_name1 = dt.Rows[0][cot.cou_name1].ToString();
                cot1.cou_name2 = dt.Rows[0][cot.cou_name2].ToString();
                cot1.currency = dt.Rows[0][cot.currency].ToString();
                cot1.wtocountry = dt.Rows[0][cot.wtocountry].ToString();
                cot1.startdate = dt.Rows[0][cot.startdate].ToString();
                cot1.finishdate = dt.Rows[0][cot.finishdate].ToString();
                cot1.progver = dt.Rows[0][cot.progver].ToString();
                cot1.usrname = dt.Rows[0][cot.usrname].ToString();
                cot1.update_dd = dt.Rows[0][cot.update_dd].ToString();
                cot1.update_tt = dt.Rows[0][cot.update_tt].ToString();
                cot1.sort1 = dt.Rows[0][cot.sort1].ToString();
                //cot1.active = dt.Rows[0][cot.active].ToString();
                //cot1.date_cancel = dt.Rows[0][cot.date_cancel].ToString();
                //cot1.date_create = dt.Rows[0][cot.date_create].ToString();
                //cot1.date_modi = dt.Rows[0][cot.date_modi].ToString();
                //cot1.user_cancel = dt.Rows[0][cot.user_cancel].ToString();
                //cot1.user_create = dt.Rows[0][cot.user_create].ToString();
                //cot1.user_modi = dt.Rows[0][cot.user_modi].ToString();
                //cot1.remark = dt.Rows[0][cot.remark].ToString();
            }

            return cot1;
        }
    }
}
