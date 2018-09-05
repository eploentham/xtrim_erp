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
    public class IssueDB
    {
        public Issue iss;
        ConnectDB conn;

        public List<Issue> lIss;
        public DataTable dtAddrT;

        public IssueDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            iss = new Issue();
            iss.issue_id = "issue_id";
            iss.issue_name_t = "issue_name_t";
            iss.issue_name_e = "issue_name_e";
            iss.date_create = "date_create";
            iss.date_modi = "date_modi";
            iss.date_cancel = "date_cancel";
            iss.user_create = "user_create";
            iss.user_modi = "user_modi";
            iss.user_cancel = "user_cancel";
            iss.active = "active";
            iss.remark = "remark";

            iss.table = "b_issue";
            iss.pkField = "issue_id";
        }
        public void getlAddr()
        {
            //lDept = new List<Department>();

            lIss.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            dtAddrT = dt;
            foreach (DataRow row in dt.Rows)
            {
                Issue addrT1 = new Issue();
                addrT1.issue_id = row[iss.issue_id].ToString();
                addrT1.issue_name_e = row[iss.issue_name_e].ToString();
                addrT1.issue_name_t = row[addrT1.issue_name_t].ToString();
                //addrT1.line_e1 = row[addrT1.line_e1].ToString();

                lIss.Add(addrT1);
            }
        }
        public void setCboCus(ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            foreach (Issue cus1 in lIss)
            {
                item = new ComboBoxItem();
                item.Value = cus1.issue_id;
                item.Text = cus1.issue_name_t;
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
            foreach (Issue cus1 in lIss)
            {
                if (name.Trim().Equals(cus1.issue_name_t.Trim()))
                {
                    id = cus1.issue_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(Issue p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.issue_id = p.issue_id == null ? "" : p.issue_id;

            p.issue_name_t = p.issue_name_t == null ? "" : p.issue_name_t;
            p.issue_name_e = p.issue_name_e == null ? "" : p.issue_name_e;
            p.active = p.active == null ? "" : p.active;
            p.remark = p.remark == null ? "" : p.remark;

        }
        public String insert(Issue p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + iss.table + "(" + iss.issue_name_t + "," + iss.issue_name_e + "," + iss.remark + "," +
                iss.date_create + "," + iss.date_modi + ", " + iss.date_cancel + ", " +
                iss.user_create + "," + iss.user_modi + ", " + iss.user_cancel + ", " +
                iss.active + " " +
                ") " +
                "Values ('" + p.issue_name_t.Replace("'", "''") + "','" + p.issue_name_e.Replace("'", "''") + "','" + p.remark.Replace("'", "''") + "','" +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + p.user_create + "','" + p.user_modi + "','" + p.user_cancel + "', " +
                "'" + p.active + "' " +
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
        public String update(Issue p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + iss.table + " Set " +
                " " + iss.issue_name_t + " = '" + p.issue_name_t.Replace("'", "''") + "'" +
                "," + iss.issue_name_e + " = '" + p.issue_name_e.Replace("'", "''") + "'" +
                "," + iss.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + iss.date_modi + " = now()" +

                "Where " + iss.pkField + "='" + p.issue_id + "'"
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
        public String insertAddressType(Issue p)
        {
            String re = "";

            if (p.issue_id.Equals(""))
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
            String sql = "Delete From  " + iss.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cop.*  " +
                "From " + iss.table + " cop " +
                " " +
                "Where cop." + iss.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        private Issue setAddress(DataTable dt)
        {
            Issue iss1 = new Issue();
            if (dt.Rows.Count > 0)
            {
                iss1.issue_id = dt.Rows[0][iss.issue_id].ToString();
                iss1.issue_name_e = dt.Rows[0][iss.issue_name_e].ToString();
                iss1.date_create = dt.Rows[0][iss.date_create].ToString();
                iss1.date_modi = dt.Rows[0][iss.date_modi].ToString();
                iss1.date_cancel = dt.Rows[0][iss.date_cancel].ToString();
                iss1.user_create = dt.Rows[0][iss.user_create].ToString();
                iss1.user_modi = dt.Rows[0][iss.user_modi].ToString();
                iss1.issue_name_t = dt.Rows[0][iss.issue_name_t].ToString();
                iss1.user_cancel = dt.Rows[0][iss.user_cancel].ToString();

                iss1.active = dt.Rows[0][iss.active].ToString();

                iss1.remark = dt.Rows[0][iss.remark].ToString();

            }

            return iss1;
        }
    }
}
