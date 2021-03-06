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
    public class ExpensesPayDetailDB
    {
        public ExpensesPayDetail expnP;
        ConnectDB conn;

        public List<ExpensesPayDetail> lexpn;
        public ExpensesPayDetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            expnP = new ExpensesPayDetail();
            expnP.expenses_pay_detail_id = "expenses_pay_detail_id";
            expnP.expenses_pay_id = "expenses_pay_id";
            expnP.item_id = "item_id";
            expnP.status_pay_type = "status_pay_type";
            expnP.active = "active";
            expnP.remark = "remark";
            expnP.user_cancel = "user_cancel";
            expnP.user_create = "user_create";
            expnP.user_modi = "user_modi";
            expnP.date_cancel = "date_cancel";
            expnP.date_create = "date_create";
            expnP.date_modi = "date_modi";
            
            expnP.item_name_t= "item_name_t";
            expnP.job_id= "job_id";
            expnP.pay_amount= "pay_amount";
            expnP.pay_to_cus_id= "pay_to_cus_id";
            expnP.pay_to_cus_name_t= "pay_to_cus_name_t";
            expnP.pay_to_cus_addr= "pay_to_cus_addr";
            expnP.pay_to_cus_tax= "pay_to_cus_tax";
            expnP.pay_cheque_no= "pay_cheque_no";
            expnP.pay_cheque_bank_id= "pay_cheque_bank_id";
            expnP.pay_staff_id= "pay_staff_id";
            expnP.pay_date= "pay_date";
            expnP.comp_bank_id= "comp_bank_id";
            expnP.pay_bank_date= "pay_bank_date";
            expnP.expenses_draw_detail_id = "expenses_draw_detail_id";
            expnP.desc_dd = "desc_dd";
            expnP.desc_d = "desc_d";
            expnP.staff_id = "staff_id";
            expnP.expense_clear_cash_id = "expense_clear_cash_id";
            expnP.ecc_doc = "ecc_doc";
            expnP.erc_doc = "erc_doc";
            expnP.status_appv = "status_appv";
            expnP.appv_amt = "appv_amt";

            expnP.table = "t_expenses_pay_detail";
            expnP.pkField = "expenses_pay_detail_id";

            lexpn = new List<ExpensesPayDetail>();
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (ExpensesPayDetail utp1 in lexpn)
            {
                if (name.Trim().Equals(utp1.item_id))
                {
                    id = utp1.expenses_pay_detail_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(ExpensesPayDetail p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.expenses_pay_id = p.expenses_pay_id == null ? "" : p.expenses_pay_id;
            p.item_id = p.item_id == null ? "" : p.item_id;
            p.status_pay_type = p.status_pay_type == null ? "0" : p.status_pay_type;
            p.remark = p.remark == null ? "" : p.remark;
            p.item_name_t = p.item_name_t == null ? "" : p.item_name_t;
            p.desc_dd = p.desc_dd == null ? "" : p.desc_dd;
            p.desc_d = p.desc_d == null ? "" : p.desc_d;
            //p.pay_to_cus_id = p.pay_to_cus_id == null ? "" : p.pay_to_cus_id;
            p.pay_to_cus_name_t = p.pay_to_cus_name_t == null ? "" : p.pay_to_cus_name_t;
            p.pay_to_cus_addr = p.pay_to_cus_addr == null ? "" : p.pay_to_cus_addr;
            p.pay_to_cus_tax = p.pay_to_cus_tax == null ? "" : p.pay_to_cus_tax;
            p.pay_cheque_no = p.pay_cheque_no == null ? "" : p.pay_cheque_no;
            p.erc_doc = p.erc_doc == null ? "" : p.erc_doc;
            p.status_appv = p.status_appv == null ? "0" : p.status_appv;
            //p.remark1 = p.remark1 == null ? "" : p.remark1;

            p.staff_id = int.TryParse(p.staff_id, out chk) ? chk.ToString() : "0";
            p.job_id = int.TryParse(p.job_id, out chk) ? chk.ToString() : "0";
            p.pay_to_cus_id = int.TryParse(p.pay_to_cus_id, out chk) ? chk.ToString() : "0";
            p.pay_cheque_bank_id = int.TryParse(p.pay_cheque_bank_id, out chk) ? chk.ToString() : "0";
            p.pay_staff_id = int.TryParse(p.pay_staff_id, out chk) ? chk.ToString() : "0";
            p.comp_bank_id = int.TryParse(p.comp_bank_id, out chk) ? chk.ToString() : "0";
            p.expenses_draw_detail_id = int.TryParse(p.expenses_draw_detail_id, out chk) ? chk.ToString() : "0";
            p.expense_clear_cash_id = int.TryParse(p.expense_clear_cash_id, out chk) ? chk.ToString() : "0";
            p.ecc_doc = int.TryParse(p.ecc_doc, out chk) ? chk.ToString() : "0";

            p.pay_amount = Decimal.TryParse(p.pay_amount, out chk1) ? chk1.ToString() : "0";
            p.appv_amt = Decimal.TryParse(p.appv_amt, out chk1) ? chk1.ToString() : "0";
            //p.amount_reserve = Decimal.TryParse(p.amount_reserve, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(ExpensesPayDetail p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";

            chkNull(p);
            sql = "Insert Into " + expnP.table + "(" + expnP.expenses_pay_id + "," + expnP.item_id + "," + expnP.status_pay_type + "," +
                expnP.active + "," + expnP.remark + ", " + 
                expnP.date_create + ", " + expnP.date_modi + ", " + expnP.date_cancel + "," +
                expnP.user_create + ", " + expnP.user_modi + ", " + expnP.user_cancel + ", " +
                expnP.item_name_t + ", " + expnP.job_id + ", " + expnP.pay_amount + ", " +
                expnP.pay_to_cus_id + ", " + expnP.pay_to_cus_name_t + ", " + expnP.pay_to_cus_addr + ", " +
                expnP.pay_to_cus_tax + ", " + expnP.pay_cheque_no + ", " + expnP.pay_cheque_bank_id + ", " +
                expnP.pay_staff_id + ", " + expnP.pay_date + ", " + expnP.comp_bank_id + ", " +
                expnP.pay_bank_date + "," + expnP.expenses_draw_detail_id + "," + expnP.desc_dd + "," +
                expnP.desc_d + "," + expnP.staff_id + "," + expnP.expense_clear_cash_id + "," +
                expnP.ecc_doc + "," + expnP.erc_doc + "," + expnP.status_appv + "," +
                expnP.appv_amt + " " +
                ") " +
                "Values ('" + p.expenses_pay_id + "','" + p.item_id + "','" + p.status_pay_type + "'," +
                "'" + p.active + "','" + p.remark + "'," +
                "now() ,'" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + p.user_create + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.item_name_t + "','" + p.job_id + "','" + p.pay_amount + "'," +
                "'" + p.pay_to_cus_id + "','" + p.pay_to_cus_name_t + "','" + p.pay_to_cus_addr + "'," +
                "'" + p.pay_to_cus_tax + "','" + p.pay_cheque_no + "','" + p.pay_cheque_bank_id + "'," +
                "'" + p.pay_staff_id + "','" + p.pay_date + "','" + p.comp_bank_id + "'," +
                "'" + p.pay_bank_date + "','" + p.expenses_draw_detail_id + "','" + p.desc_dd + "'," +
                "'" + p.desc_d + "','" + p.staff_id + "','" + p.expense_clear_cash_id + "', " +
                "'" + p.ecc_doc + "','" + p.erc_doc + "','" + p.status_appv + "'," +
                "'" + p.appv_amt + "' " +
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
        public String update(ExpensesPayDetail p, String userId)
        {
            String re = "", sql = "";

            chkNull(p);
            sql = "Update " + expnP.table + " Set " +
                " " + expnP.expenses_pay_id + "='" + p.expenses_pay_id + "' " +
                "," + expnP.status_pay_type + "='" + p.status_pay_type.Replace("'", "''") + "' " +
                "," + expnP.item_id + "='" + p.item_id.Replace("'", "''") + "' " +
                "," + expnP.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + expnP.date_modi + "=now() " +
                "," + expnP.user_modi + "='" + userId.Replace("'", "''") + "' " +
                "," + expnP.item_name_t + "='" + p.item_name_t.Replace("'", "''") + "' " +
                "," + expnP.job_id + "='" + p.job_id.Replace("'", "''") + "' " +
                "," + expnP.pay_amount + "='" + p.pay_amount.Replace("'", "''") + "' " +
                "," + expnP.pay_to_cus_id + "='" + p.pay_to_cus_id.Replace("'", "''") + "' " +
                "," + expnP.pay_to_cus_name_t + "='" + p.pay_to_cus_name_t.Replace("'", "''") + "' " +
                "," + expnP.pay_to_cus_addr + "='" + p.pay_to_cus_addr.Replace("'", "''") + "' " +
                "," + expnP.pay_to_cus_tax + "='" + p.pay_to_cus_tax.Replace("'", "''") + "' " +
                "," + expnP.pay_cheque_no + "='" + p.pay_cheque_no.Replace("'", "''") + "' " +
                "," + expnP.pay_cheque_bank_id + "='" + p.pay_cheque_bank_id.Replace("'", "''") + "' " +
                "," + expnP.pay_staff_id + "='" + p.pay_staff_id.Replace("'", "''") + "' " +
                "," + expnP.pay_date + "='" + p.pay_date.Replace("'", "''") + "' " +
                "," + expnP.comp_bank_id + "='" + p.comp_bank_id.Replace("'", "''") + "' " +
                "," + expnP.pay_bank_date + "='" + p.pay_bank_date.Replace("'", "''") + "' " +
                "," + expnP.expenses_draw_detail_id + "='" + p.expenses_draw_detail_id.Replace("'", "''") + "' " +
                "," + expnP.desc_dd + "='" + p.desc_dd.Replace("'", "''") + "' " +
                "," + expnP.desc_d + "='" + p.desc_d.Replace("'", "''") + "' " +
                "," + expnP.staff_id + "='" + p.staff_id.Replace("'", "''") + "' " +
                "," + expnP.expense_clear_cash_id + "='" + p.expense_clear_cash_id.Replace("'", "''") + "' " +

                "Where " + expnP.expenses_pay_detail_id + "='" + p.expenses_pay_detail_id + "'"
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
        public String insertExpensesPayDetail(ExpensesPayDetail p, String userId)
        {
            String re = "";

            if (p.expenses_pay_detail_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }
            return re;
        }
        public String voidExpensePayDetail(String id)
        {
            String re = "", sql = "";

            sql = "Update " + expnP.table + " Set " +
                " " + expnP.active + "='3' " +
                "," + expnP.date_cancel + "=now() " +
                "Where " + expnP.expenses_pay_detail_id + "='" + id + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String updateEcc(String id, String eccid)
        {
            String re = "", sql = "";

            sql = "Update " + expnP.table + " Set " +
                " " + expnP.expense_clear_cash_id + "='"+ eccid.Replace("CC","") + "' " +
                "," + expnP.ecc_doc + "='" + eccid.Replace("CC", "") + "' " +
                "Where " + expnP.expenses_pay_detail_id + "='" + id + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String updateStatusApprove(String id, String erc_doc, String amt)
        {
            String re = "", sql = "";
            sql = "Update " + expnP.table + " Set " +
                " " + expnP.status_appv + "='1' " +
                "," + expnP.erc_doc + "='" + erc_doc.Replace("CC", "") + "' " +
                "," + expnP.appv_amt + "=" + expnP.appv_amt+"-"+ amt + " " +
                "Where " + expnP.expenses_pay_detail_id + "='" + id + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select expnP.*  " +
                "From " + expnP.table + " expnP " +
                " " +
                "Where expnP." + expnP.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll1()
        {
            DataTable dt = new DataTable();
            String sql = "select expnP." + expnP.expenses_pay_detail_id + "," + expnP.item_id + "," + expnP.remark + " " +
                "From " + expnP.table + " expnP " +
                " " +
                "Where expnP." + expnP.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByEccId(String eccId)
        {
            DataTable dt = new DataTable();
            String sql = "select expnP." + expnP.expenses_pay_detail_id + "," + expnP.item_name_t + "," + expnP.pay_amount + " " +
                "From " + expnP.table + " expnP " +
                " " +
                "Where expnP." + expnP.active + " ='1' and expnP." + expnP.expense_clear_cash_id+" = '"+eccId+"'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByStfIdEccDocNo(String stfId)
        {
            DataTable dt = new DataTable();
            String sql = "select expnP." + expnP.expenses_pay_detail_id + "," + expnP.item_name_t + "," + expnP.pay_amount + " " +
                "From " + expnP.table + " expnP " +
                " " +
                "Where expnP." + expnP.active + " ='1' and expnP." + expnP.pay_staff_id + " = '" + stfId + "' and expnP." + expnP.ecc_doc + "='0'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByEccDoc(String eccdoc)
        {
            DataTable dt = new DataTable();
            String sql = "select expnP." + expnP.expenses_pay_detail_id + "," + expnP.item_name_t + "," + expnP.pay_amount + " " +
                "From " + expnP.table + " expnP " +
                " " +
                "Where expnP." + expnP.active + " ='1' and expnP." + expnP.ecc_doc + " = '" + eccdoc + "'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public ExpensesPayDetail selectByPk1(String copId)
        {
            ExpensesPayDetail cop1 = new ExpensesPayDetail();
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expnP.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expnP.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setExpensePayDetail(dt);
            return cop1;
        }
        public DataTable selectByJobIdStfId(String jobid, String stfid)
        {
            String wherejob="", wherestf = "";
            DataTable dt = new DataTable();
            if (!jobid.Equals(""))
            {
                wherejob = " and expnP." + expnP.job_id + "='" + jobid + "'  ";
            }
            if (!stfid.Equals(""))
            {
                wherestf = " and expnP." + expnP.pay_staff_id + "='" + stfid + "'  ";
            }
            String sql = "select expnP.* " +
                "From " + expnP.table + " expnP " +
                " " +
                "Where expnP." + expnP.active + " ='1' "+ wherejob+ wherestf + " " +
                "Order By expnP."+expnP.expenses_pay_detail_id;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        
        public DataTable selectByJobIdStfIdNoClear(String jobid, String stfid)
        {
            String wherejob = "", wherestf = "";
            DataTable dt = new DataTable();
            if (!jobid.Equals(""))
            {
                wherejob = " and expnP." + expnP.job_id + "='" + jobid + "'  ";
            }
            if (!stfid.Equals(""))
            {
                wherestf = " and expnP." + expnP.pay_staff_id + "='" + stfid + "'  ";
            }
            String sql = "select expnP.* " +
                "From " + expnP.table + " expnP " +
                " " +
                "Where expnP." + expnP.active + " ='1' and epxnP."+expnP.expense_clear_cash_id+"=0 "+  wherejob + wherestf;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public String selectSumPayAmtByJobIdStfIdNoClear(String jobid, String stfid)
        {
            String wherejob = "", wherestf = "",re="";
            DataTable dt = new DataTable();
            if (!jobid.Equals(""))
            {
                wherejob = " and expnP." + expnP.job_id + "='" + jobid + "'  ";
            }
            if (!stfid.Equals(""))
            {
                wherestf = " and expnP." + expnP.pay_staff_id + "='" + stfid + "'  ";
            }
            String sql = "select sum(expnP." +expnP.pay_amount+") as amt " +
                "From " + expnP.table + " expnP " +
                " " +
                //"Where expnP." + expnP.active + " ='1' and expnP." + expnP.expense_clear_cash_id + "=0 " + wherejob + wherestf;
                "Where expnP." + expnP.active + " ='1' " + wherejob + wherestf;
            dt = conn.selectData(conn.conn, sql);
            re = dt.Rows[0]["amt"].ToString();
            return re;
        }
        public DataTable selectPrintCheque(String expndid)
        {
            DataTable dt = new DataTable();
            String sql = "select expnP." + expnP.pay_cheque_no + ",expnP." + expnP.pay_to_cus_name_t + "," +
                "sum(expnP." + expnP.pay_amount + ") as "+ expnP.pay_amount + ",expnP." + expnP.pay_bank_date + ",expnP." + expnP.comp_bank_id + "," +
                "copb.comp_bank_name_t,copb.comp_bank_branch,copb.acc_number " + " " +
                "From " + expnP.table + " expnP " +
                "inner join b_company_bank copb on copb.comp_bank_id = expnP.comp_bank_id " +
                //"Where expnP." + expnP.active + " ='1' and expnP."+ expnP.status_pay_type+ "='2' and expnP." + expnP.expenses_pay_id+"='"+ expndid+"' " +
                "Where expnP." + expnP.active + " ='1' and expnP." + expnP.expenses_pay_id + "='" + expndid + "' " +
                "Group By expnP." + expnP.pay_cheque_no;
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
                item.Text = row[expnP.item_id].ToString();
                item.Value = row[expnP.expenses_pay_detail_id].ToString();
                c.Items.Add(item);

                ExpensesPayDetail expn1 = new ExpensesPayDetail();
                expn1.expenses_pay_detail_id = row[expnP.expenses_pay_detail_id].ToString();
                expn1.expenses_pay_id = row[expnP.expenses_pay_id].ToString();
                expn1.status_pay_type = row[expnP.status_pay_type].ToString();
                expn1.item_id = row[expnP.item_id].ToString();

                lexpn.Add(expn1);
            }
            return c;
        }
        public ExpensesPayDetail setExpensePayDetail(DataTable dt)
        {
            ExpensesPayDetail pd1 = new ExpensesPayDetail();
            if (dt.Rows.Count > 0)
            {
                pd1.expenses_pay_detail_id = dt.Rows[0][expnP.expenses_pay_detail_id].ToString();
                pd1.expenses_pay_id = dt.Rows[0][expnP.expenses_pay_id].ToString();
                pd1.item_id = dt.Rows[0][expnP.item_id].ToString();
                pd1.status_pay_type = dt.Rows[0][expnP.status_pay_type].ToString();
                pd1.active = dt.Rows[0][expnP.active].ToString();
                pd1.remark = dt.Rows[0][expnP.remark].ToString();
                pd1.user_cancel = dt.Rows[0][expnP.user_cancel].ToString();
                pd1.user_create = dt.Rows[0][expnP.user_create].ToString();
                pd1.user_modi = dt.Rows[0][expnP.user_modi].ToString();
                pd1.date_cancel = dt.Rows[0][expnP.date_cancel].ToString();
                pd1.date_create = dt.Rows[0][expnP.date_create].ToString();
                pd1.date_modi = dt.Rows[0][expnP.date_modi].ToString();

                pd1.item_name_t = dt.Rows[0][expnP.item_name_t].ToString();
                pd1.job_id = dt.Rows[0][expnP.job_id].ToString();
                pd1.pay_amount = dt.Rows[0][expnP.pay_amount].ToString();
                pd1.pay_to_cus_id = dt.Rows[0][expnP.pay_to_cus_id].ToString();
                pd1.pay_to_cus_name_t = dt.Rows[0][expnP.pay_to_cus_name_t].ToString();
                pd1.pay_to_cus_addr = dt.Rows[0][expnP.pay_to_cus_addr].ToString();
                pd1.pay_to_cus_tax = dt.Rows[0][expnP.pay_to_cus_tax].ToString();
                pd1.pay_cheque_no = dt.Rows[0][expnP.pay_cheque_no].ToString();
                pd1.pay_cheque_bank_id = dt.Rows[0][expnP.pay_cheque_bank_id].ToString();
                pd1.pay_staff_id = dt.Rows[0][expnP.pay_staff_id].ToString();
                pd1.pay_date = dt.Rows[0][expnP.pay_date].ToString();
                pd1.comp_bank_id = dt.Rows[0][expnP.comp_bank_id].ToString();
                pd1.pay_bank_date = dt.Rows[0][expnP.pay_bank_date].ToString();
                pd1.expenses_draw_detail_id = dt.Rows[0][expnP.expenses_draw_detail_id].ToString();
                pd1.desc_dd = dt.Rows[0][expnP.desc_dd].ToString();
                pd1.desc_d = dt.Rows[0][expnP.desc_d].ToString();
                pd1.staff_id = dt.Rows[0][expnP.staff_id].ToString();
                pd1.expense_clear_cash_id = dt.Rows[0][expnP.expense_clear_cash_id].ToString();
                pd1.ecc_doc = dt.Rows[0][expnP.ecc_doc].ToString();
                pd1.erc_doc = dt.Rows[0][expnP.erc_doc].ToString();
                pd1.status_appv = dt.Rows[0][expnP.status_appv].ToString();
                pd1.appv_amt = dt.Rows[0][expnP.appv_amt].ToString();
            }
            else
            {
                pd1.expenses_pay_detail_id = "";
                pd1.expenses_pay_id = "";
                pd1.item_id = "";
                pd1.status_pay_type = "";
                pd1.active = "1";
                pd1.remark = "";
                pd1.user_cancel = "";
                pd1.user_create = "";
                pd1.user_modi = "";
                pd1.date_cancel = "";
                pd1.date_create = "";
                pd1.date_modi = "";

                pd1.item_name_t = "";
                pd1.job_id = "";
                pd1.pay_amount = "";
                pd1.pay_to_cus_id = "";
                pd1.pay_to_cus_name_t = "";
                pd1.pay_to_cus_addr = "";
                pd1.pay_to_cus_tax = "";
                pd1.pay_cheque_no = "";
                pd1.pay_cheque_bank_id = "";
                pd1.pay_staff_id = "";
                pd1.pay_date = "";
                pd1.comp_bank_id = "";
                pd1.pay_bank_date = "";
                pd1.expenses_draw_detail_id = "";
                pd1.desc_dd = "";
                pd1.desc_d = "";
                pd1.staff_id = "";
                pd1.expense_clear_cash_id = "";
                pd1.ecc_doc = "";
                pd1.erc_doc = "";
                pd1.status_appv = "";
                pd1.appv_amt = "";
            }

            return pd1;
        }
    }
}
