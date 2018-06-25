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
    public class FMethodPaymentDB
    {
        public FMethodPayment fmtp;
        ConnectDB conn;

        public List<FMethodPayment> lMtp;

        public FMethodPaymentDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fmtp = new FMethodPayment();
            fmtp.method_payment_id = "f_method_payment_id";
            fmtp.method_payment_code = "f_method_payment_code";
            fmtp.method_payment_name_e = "f_method_payment_name_e";
            fmtp.method_payment_name_t = "f_method_payment_name_t";
            fmtp.status_app = "status_app";
            fmtp.sort1 = "sort1";

            fmtp.active = "active";
            fmtp.date_create = "date_create";
            fmtp.date_modi = "date_modi";
            fmtp.date_cancel = "date_cancel";
            fmtp.user_create = "user_create";
            fmtp.user_modi = "user_modi";
            fmtp.user_cancel = "user_cancel";
            //tmn.status_app = "status_app";
            fmtp.remark = "remark";

            fmtp.table = "f_method_payment";
            fmtp.pkField = "f_method_payment_id";

            lMtp = new List<FMethodPayment>();

            //getlMtp();
        }
        public void getlMtp()
        {
            //lDept = new List<Department>();

            lMtp.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                FMethodPayment mtp1 = new FMethodPayment();
                mtp1.method_payment_id = row[fmtp.method_payment_id].ToString();
                mtp1.method_payment_code = row[fmtp.method_payment_code].ToString();
                mtp1.method_payment_name_e = row[fmtp.method_payment_name_e].ToString();
                mtp1.method_payment_name_t = row[fmtp.method_payment_name_t].ToString();

                lMtp.Add(mtp1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (FMethodPayment mtp1 in lMtp)
            {
                if (code.Trim().Equals(mtp1.method_payment_code))
                {
                    id = mtp1.method_payment_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (FMethodPayment mtp1 in lMtp)
            {
                if (name.Trim().Equals(mtp1.method_payment_name_t))
                {
                    id = mtp1.method_payment_id;
                    break;
                }
            }
            return id;
        }
        public void setC1CboMtp(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            if (lMtp.Count <= 0) getlMtp();
            //DataTable dt = selectWard();
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (FMethodPayment cus1 in lMtp)
            {
                item = new ComboBoxItem();
                item.Value = cus1.method_payment_id;
                item.Text = cus1.method_payment_name_t;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedText = item.Text;
                }
            }
        }
        //public String insert(FMethodPayment p, String userId)
        //{
        //    String re = "";
        //    String sql = "";
        //    p.active = "1";
        //    //p.ssdata_id = "";
        //    int chk = 0;

        //    p.date_modi = p.date_modi == null ? "" : p.date_modi;
        //    p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
        //    p.user_create = p.user_create == null ? "" : p.user_create;
        //    p.user_modi = p.user_modi == null ? "" : p.user_modi;
        //    p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
        //    //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
        //    //p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";

        //    sql = "Insert Into " + mtp.table + "(" + mtp.method_payment_code + "," + mtp.method_payment_name_e + "," + mtp.method_payment_name_t + "," +
        //        mtp.date_create + "," + mtp.date_modi + "," + mtp.date_cancel + "," +
        //        mtp.user_create + "," + mtp.user_modi + "," + mtp.user_cancel + "," +
        //        mtp.active + "," + mtp.remark + ", " + mtp.sort1 + " " +
        //        ") " +
        //        "Values ('" + p.method_payment_code + "','" + p.method_payment_name_e.Replace("'", "''") + "','" + p.method_payment_name_t.Replace("'", "''") + "'," +
        //        "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "'," +
        //        "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
        //        "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.sort1 + "' " +
        //        ")";
        //    try
        //    {
        //        re = conn.ExecuteNonQuery(conn.conn, sql);
        //    }
        //    catch (Exception ex)
        //    {
        //        sql = ex.Message + " " + ex.InnerException;
        //    }

        //    return re;
        //}
        //public String update(FMethodPayment p, String userId)
        //{
        //    String re = "";
        //    String sql = "";
        //    int chk = 0;

        //    p.date_modi = p.date_modi == null ? "" : p.date_modi;
        //    p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
        //    p.user_create = p.user_create == null ? "" : p.user_create;
        //    p.user_modi = p.user_modi == null ? "" : p.user_modi;
        //    p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

        //    sql = "Update " + mtp.table + " Set " +
        //        " " + mtp.method_payment_code + " = '" + p.method_payment_code + "'" +
        //        "," + mtp.method_payment_name_e + " = '" + p.method_payment_name_e.Replace("'", "''") + "'" +
        //        "," + mtp.method_payment_name_t + " = '" + p.method_payment_name_t.Replace("'", "''") + "'" +
        //        "," + mtp.remark + " = '" + p.remark.Replace("'", "''") + "'" +
        //        "," + mtp.date_modi + " = now()" +
        //        "," + mtp.user_modi + " = '" + userId + "' " +
        //        "," + mtp.sort1 + " = '" + p.sort1 + "' " +
        //        //"," + tmn.status_app + " = '" + p.status_app + "' " +
        //        "Where " + mtp.pkField + "='" + p.method_payment_id + "'"
        //        ;

        //    try
        //    {
        //        re = conn.ExecuteNonQuery(conn.conn, sql);
        //    }
        //    catch (Exception ex)
        //    {
        //        sql = ex.Message + " " + ex.InnerException;
        //    }

        //    return re;
        //}
        //public String insertMethodPayment(FMethodPayment p, String userId)
        //{
        //    String re = "";

        //    if (p.method_payment_id.Equals(""))
        //    {
        //        re = insert(p, userId);
        //    }
        //    else
        //    {
        //        re = update(p, userId);
        //    }

        //    return re;
        //}
        public String deleteAll()
        {
            DataTable dt = new DataTable();
            String sql = "Delete From  " + fmtp.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select mtp.*  " +
                "From " + fmtp.table + " mtp " +
                " " +
                "Where mtp." + fmtp.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select mtp.* " +
                "From " + fmtp.table + " mtp " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where mtp." + fmtp.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public FMethodPayment selectByPk1(String copId)
        {
            FMethodPayment cop1 = new FMethodPayment();
            DataTable dt = new DataTable();
            String sql = "select mtp.* " +
                "From " + fmtp.table + " mtp " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where mtp." + fmtp.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setExpn(dt);
            return cop1;
        }
        private FMethodPayment setExpn(DataTable dt)
        {
            FMethodPayment expn1 = new FMethodPayment();
            if (dt.Rows.Count > 0)
            {
                expn1.method_payment_id = dt.Rows[0][fmtp.method_payment_id].ToString();
                expn1.method_payment_code = dt.Rows[0][fmtp.method_payment_code].ToString();
                expn1.method_payment_name_e = dt.Rows[0][fmtp.method_payment_name_e].ToString();
                expn1.method_payment_name_t = dt.Rows[0][fmtp.method_payment_name_t].ToString();
                expn1.active = dt.Rows[0][fmtp.active].ToString();
                expn1.date_cancel = dt.Rows[0][fmtp.date_cancel].ToString();
                expn1.date_create = dt.Rows[0][fmtp.date_create].ToString();
                expn1.date_modi = dt.Rows[0][fmtp.date_modi].ToString();
                expn1.user_cancel = dt.Rows[0][fmtp.user_cancel].ToString();
                expn1.user_create = dt.Rows[0][fmtp.user_create].ToString();
                expn1.user_modi = dt.Rows[0][fmtp.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][tmn.status_app].ToString();
                expn1.remark = dt.Rows[0][fmtp.remark].ToString();
                expn1.sort1 = dt.Rows[0][fmtp.sort1].ToString();
            }

            return expn1;
        }
    }
}
