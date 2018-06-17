﻿using C1.Win.C1Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class ExpensesDrawDetailDB
    {
        public ExpensesDrawDatail expnC;
        ConnectDB conn;

        public List<ExpensesDrawDatail> lexpnC;
        public ExpensesDrawDetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            expnC = new ExpensesDrawDatail();
            expnC.expenses_draw_detail_id = "expenses_draw_detail_id";
            expnC.desc1 = "desc1";
            expnC.desc2 = "desc2";
            expnC.amount = "amount";
            //tmn.status_app = "status_app";
            expnC.sort1 = "sort1";

            expnC.active = "active";
            expnC.date_create = "date_create";
            expnC.date_modi = "date_modi";
            expnC.date_cancel = "date_cancel";
            expnC.user_create = "user_create";
            expnC.user_modi = "user_modi";
            expnC.user_cancel = "user_cancel";
            expnC.expense_draw_id = "expenses_draw_id";
            expnC.remark = "remark";
            expnC.expense_type_id = "expenses_type_id";

            expnC.table = "t_expenses_draw_detail";
            expnC.pkField = "expenses_draw_detail_id";

            lexpnC = new List<ExpensesDrawDatail>();
        }
        public void getlexpnC()
        {
            //lDept = new List<Department>();

            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                ExpensesDrawDatail curr1 = new ExpensesDrawDatail();
                curr1.expenses_draw_detail_id = row[expnC.expenses_draw_detail_id].ToString();
                curr1.desc1 = row[expnC.desc1].ToString();
                curr1.desc2 = row[expnC.desc2].ToString();
                curr1.amount = row[expnC.amount].ToString();
                lexpnC.Add(curr1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (ExpensesDrawDatail curr1 in lexpnC)
            {
                if (code.Trim().Equals(curr1.desc1))
                {
                    id = curr1.expenses_draw_detail_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (ExpensesDrawDatail curr1 in lexpnC)
            {
                if (name.Trim().Equals(curr1.amount))
                {
                    id = curr1.expenses_draw_detail_id;
                    break;
                }
            }
            return id;
        }
        public void setC1CboExpnC(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            if (lexpnC.Count <= 0) getlexpnC();
            //DataTable dt = selectWard();
            foreach (ExpensesDrawDatail cus1 in lexpnC)
            {
                item = new ComboBoxItem();
                item.Value = cus1.expenses_draw_detail_id;
                item.Text = cus1.amount;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedText = item.Text;
                }
            }
        }
        private void chkNull(ExpensesDrawDatail p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.desc1 = p.desc1 == null ? "" : p.desc1;
            p.desc2 = p.desc2 == null ? "" : p.desc2;
            //p.amount = p.amount == null ? "" : p.amount;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;

            p.expense_draw_id = int.TryParse(p.expense_draw_id, out chk) ? chk.ToString() : "0";
            p.expense_type_id = int.TryParse(p.expense_type_id, out chk) ? chk.ToString() : "0";

            p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(ExpensesDrawDatail p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + expnC.table + "(" + expnC.desc1 + "," + expnC.desc2 + "," + expnC.amount + "," +
                expnC.date_create + "," + expnC.date_modi + "," + expnC.date_cancel + "," +
                expnC.user_create + "," + expnC.user_modi + "," + expnC.user_cancel + "," +
                expnC.active + "," + expnC.remark + ", " + expnC.sort1 + "," +
                expnC.expense_draw_id + "," + expnC.expense_type_id + " " + 
                ") " +
                "Values ('" + p.desc1.Replace("'", "''") + "','" + p.desc2.Replace("'", "''") + "','" + p.amount + "'," +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.sort1 + "', " +
                "'" + p.expense_draw_id + "','" + p.expense_type_id.Replace("'", "''") + "' " + 
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
        public String update(ExpensesDrawDatail p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + expnC.table + " Set " +
                " " + expnC.desc1 + " = '" + p.desc1.Replace("'", "''") + "'" +
                "," + expnC.desc2 + " = '" + p.desc2.Replace("'", "''") + "'" +
                "," + expnC.amount + " = '" + p.amount + "'" +
                "," + expnC.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + expnC.date_modi + " = now()" +
                "," + expnC.user_modi + " = '" + userId + "' " +
                "," + expnC.sort1 + " = '" + p.sort1 + "' " +
                "," + expnC.expense_draw_id + " = '" + p.expense_draw_id + "' " +
                "," + expnC.expense_type_id + " = '" + p.expense_type_id + "' " +
                "Where " + expnC.pkField + "='" + p.expenses_draw_detail_id + "'"
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
        public String insertExpenseDrawDetail(ExpensesDrawDatail p, String userId)
        {
            String re = "";

            if (p.expenses_draw_detail_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public String deleteAll()
        {
            DataTable dt = new DataTable();
            String sql = "Delete From  " + expnC.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select expC.*  " +
                "From " + expnC.table + " expC " +
                " " +
                "Where expC." + expnC.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByCodeLike(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expnC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where LOWER(expC." + expnC.desc1 + ") like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByDrawId(String copId)
        {
            String currId = "";
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expnC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expnC.expense_draw_id + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);            
            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expnC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expnC.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public ExpensesDrawDatail selectByPk1(String copId)
        {
            ExpensesDrawDatail cop1 = new ExpensesDrawDatail();
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expnC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expnC.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setExpenseDrawDetail(dt);
            return cop1;
        }
        public ExpensesDrawDatail setExpenseDrawDetail(DataTable dt)
        {
            ExpensesDrawDatail curr1 = new ExpensesDrawDatail();
            if (dt.Rows.Count > 0)
            {
                curr1.expenses_draw_detail_id = dt.Rows[0][expnC.expenses_draw_detail_id].ToString();
                curr1.desc1 = dt.Rows[0][expnC.desc1].ToString();
                curr1.desc2 = dt.Rows[0][expnC.desc2].ToString();
                curr1.amount = dt.Rows[0][expnC.amount].ToString();
                curr1.active = dt.Rows[0][expnC.active].ToString();
                curr1.date_cancel = dt.Rows[0][expnC.date_cancel].ToString();
                curr1.date_create = dt.Rows[0][expnC.date_create].ToString();
                curr1.date_modi = dt.Rows[0][expnC.date_modi].ToString();
                curr1.user_cancel = dt.Rows[0][expnC.user_cancel].ToString();
                curr1.user_create = dt.Rows[0][expnC.user_create].ToString();
                curr1.user_modi = dt.Rows[0][expnC.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][tmn.status_app].ToString();
                curr1.remark = dt.Rows[0][expnC.remark].ToString();
                curr1.sort1 = dt.Rows[0][expnC.sort1].ToString();
                curr1.expense_draw_id = dt.Rows[0][expnC.expense_draw_id].ToString();
                curr1.expense_type_id = dt.Rows[0][expnC.expense_type_id].ToString();
            }

            return curr1;
        }
    }
}