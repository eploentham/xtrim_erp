using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class CustomerRemarkDB
    {
        public CustomerRemark cusR;
        ConnectDB conn;

        public List<CustomerRemark> lAddrT;
        public DataTable dtAddrT;

        public CustomerRemarkDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            cusR = new CustomerRemark();
            cusR.remark_id = "remark_id";
            cusR.cust_id = "cust_id";
            
            cusR.date_create = "date_create";
            cusR.date_modi = "date_modi";
            cusR.date_cancel = "date_cancel";
            cusR.user_create = "user_create";
            cusR.user_modi = "user_modi";
            cusR.user_cancel = "user_cancel";
            cusR.active = "active";
            cusR.remark = "remark";
            cusR.remark2 = "remark2";
            cusR.sort1 = "sort1";
            cusR.status_show1 = "status_show1";
            cusR.status_show2 = "status_show2";
            cusR.status_show3 = "status_show3";

            cusR.table = "b_customer_remark";
            cusR.pkField = "remark_id";
        }
        public void getlAddr()
        {
            //lDept = new List<Department>();

            lAddrT.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            dtAddrT = dt;
            foreach (DataRow row in dt.Rows)
            {
                CustomerRemark addrT1 = new CustomerRemark();
                addrT1.remark_id = row[cusR.remark_id].ToString();
                addrT1.remark = row[cusR.remark].ToString();
                addrT1.cust_id = row[addrT1.cust_id].ToString();
                //addrT1.line_e1 = row[addrT1.line_e1].ToString();

                lAddrT.Add(addrT1);
            }
        }
        public void setCboCus(ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            foreach (CustomerRemark cus1 in lAddrT)
            {
                item = new ComboBoxItem();
                item.Value = cus1.remark_id;
                item.Text = cus1.cust_id;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedItem = item;
                }
            }
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (CustomerRemark cus1 in lAddrT)
            {
                if (name.Trim().Equals(cus1.cust_id.Trim()))
                {
                    id = cus1.remark_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(CustomerRemark p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.remark_id = p.remark_id == null ? "" : p.remark_id;

            //p.cust_id = p.cust_id == null ? "" : p.cust_id;
            p.remark2 = p.remark2 == null ? "" : p.remark2;
            p.active = p.active == null ? "" : p.active;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
            p.status_show1 = p.status_show1 == null ? "" : p.status_show1;
            p.status_show2 = p.status_show2 == null ? "" : p.status_show2;
            p.status_show3 = p.status_show3 == null ? "" : p.status_show3;
            p.cust_id = int.TryParse(p.cust_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(CustomerRemark p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + cusR.table + "(" + cusR.cust_id + "," + cusR.remark2 + "," + cusR.remark + "," +
                cusR.date_create + "," + cusR.date_modi + ", " + cusR.date_cancel + ", " +
                cusR.user_create + "," + cusR.user_modi + ", " + cusR.user_cancel + ", " +
                cusR.active + ", " + cusR.sort1 + ", " + cusR.status_show1 + ", " +
                cusR.status_show2 + ", " + cusR.status_show3 + " " +
                ") " +
                "Values ('" + p.cust_id.Replace("'", "''") + "','" + p.remark2.Replace("'", "''") + "','" + p.remark.Replace("'", "''") + "'," +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + p.user_create + "','" + p.user_modi + "','" + p.user_cancel + "', " +
                "'" + p.active + "','" + p.sort1 + "','" + p.status_show1 + "', " +
                "'" + p.status_show2 + "','" + p.status_show3 + "' " +
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
        public String update(CustomerRemark p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + cusR.table + " Set " +
                " " + cusR.cust_id + " = '" + p.cust_id.Replace("'", "''") + "'" +
                "," + cusR.remark2 + " = '" + p.remark2.Replace("'", "''") + "'" +
                "," + cusR.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + cusR.sort1 + " = '" + p.sort1.Replace("'", "''") + "'" +
                "," + cusR.date_modi + " = now() " +
                "," + cusR.status_show1 + " = '" + p.status_show1.Replace("'", "''") + "'" +
                "," + cusR.status_show2 + " = '" + p.status_show2.Replace("'", "''") + "'" +
                "," + cusR.status_show3 + " = '" + p.status_show3.Replace("'", "''") + "' " +
                "Where " + cusR.pkField + "='" + p.remark_id + "'"
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
        public String insertCustomerRemark(CustomerRemark p)
        {
            String re = "";

            if (p.remark_id.Equals(""))
            {
                re = insert(p);
            }
            else
            {
                re = update(p);
            }

            return re;
        }
        public String deleteAll()
        {
            DataTable dt = new DataTable();
            String sql = "Delete From  " + cusR.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cop.*  " +
                "From " + cusR.table + " cop " +
                " " +
                "Where cop." + cusR.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select cont.* " +
                "From " + cusR.table + " cont " +
                "Where cont." + cusR.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public CustomerRemark selectByPk1(String copId)
        {
            CustomerRemark cont1 = new CustomerRemark();
            DataTable dt = new DataTable();
            String sql = "select cont.* " +
                "From " + cusR.table + " cont " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cont." + cusR.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cont1 = setCustomerRemark(dt);
            return cont1;
        }
        public DataTable selectByCusId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select remark_id, remark, remark2 " +
                "From " + cusR.table + " cont " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cont." + cusR.cust_id + " ='" + copId + "' and cont." + cusR.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        private CustomerRemark setCustomerRemark(DataTable dt)
        {
            CustomerRemark cusR1 = new CustomerRemark();
            if (dt.Rows.Count > 0)
            {
                cusR1.remark_id = dt.Rows[0][cusR.remark_id].ToString();
                cusR1.cust_id = dt.Rows[0][cusR.cust_id].ToString();
                cusR1.date_create = dt.Rows[0][cusR.date_create].ToString();
                cusR1.date_modi = dt.Rows[0][cusR.date_modi].ToString();
                cusR1.date_cancel = dt.Rows[0][cusR.date_cancel].ToString();
                cusR1.user_create = dt.Rows[0][cusR.user_create].ToString();
                cusR1.user_modi = dt.Rows[0][cusR.user_modi].ToString();
                cusR1.remark = dt.Rows[0][cusR.remark].ToString();
                cusR1.user_cancel = dt.Rows[0][cusR.user_cancel].ToString();
                cusR1.remark2 = dt.Rows[0][cusR.remark2].ToString();
                cusR1.active = dt.Rows[0][cusR.active].ToString();
                cusR1.sort1 = dt.Rows[0][cusR.sort1].ToString();
                cusR1.status_show1 = dt.Rows[0][cusR.status_show1].ToString();
                cusR1.status_show2 = dt.Rows[0][cusR.status_show2].ToString();
                cusR1.status_show3 = dt.Rows[0][cusR.status_show3].ToString();
            }

            return cusR1;
        }
    }
}
