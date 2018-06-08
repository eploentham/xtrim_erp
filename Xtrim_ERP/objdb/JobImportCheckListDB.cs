using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class JobImportCheckListDB
    {
        public JobImportCheckList jcl;
        ConnectDB conn;

        public JobImportCheckListDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jcl = new JobImportCheckList();
            jcl.import_check_list_id = "import_check_list_id";
            jcl.job_import_id = "job_import_id";
            jcl.status_original = "status_original";
            jcl.check_list_date = "check_list_date";
            jcl.type_of_bl = "type_of_bl";
            jcl.email_do = "email_do";
            jcl.privi1_id = "privi1_id";
            jcl.privi2_id = "privi2_id";
            jcl.privi1_date = "privi1_date";
            jcl.privi2_date = "privi2_date";
            jcl.privi1_desc = "privi1_desc";
            jcl.privi2_desc = "privi2_desc";
            jcl.doc_authen1_id = "doc_authen1_id";
            jcl.doc_authen2_id = "doc_authen2_id";
            jcl.doc_authen3_id = "doc_authen3_id";
            jcl.doc_authen1_date = "doc_authen1_date";
            jcl.doc_authen2_date = "doc_authen2_date";
            jcl.doc_authen3_date = "doc_authen3_date";
            jcl.enter_bl = "enter_bl";
            jcl.insurance_atten = "insurance_atten";
            jcl.email_do1 = "email_do1";
            jcl.email_do1_date = "email_do1_date";
            jcl.do_date_send = "do_date_send";
            jcl.do_date_receive = "do_date_receive";
            jcl.tax_date_send = "tax_date_send";
            jcl.tax_date_receive = "tax_date_receive";
            jcl.exp1_date_send = "exp1_date_send";
            jcl.exp1_date_receive = "exp1_date_receive";
            jcl.exp2_date_send = "exp2_date_send";
            jcl.exp2_date_receive = "exp2_date_receive";
            jcl.receipt_date = "receipt_date";
            jcl.receipt_copy_date = "receipt_copy_date";
            jcl.accept_tender = "accept_tender";
            jcl.advance_billing = "advance_billing";
            jcl.approve_date = "approve_date";
            jcl.parent1 = "parent1";
            jcl.date_create = "date_create";
            jcl.date_modi = "date_modi";
            jcl.date_cancel = "date_cancel";
            jcl.user_create = "user_create";
            jcl.user_modi = "user_modi";
            jcl.user_cancel = "user_cancel";
            jcl.remark = "remark";
            jcl.active = "active";

            jcl.table = "t_job_import_check_list";
            jcl.pkField = "import_check_list_id";
        }
        private void chkNull(JobImportCheckList p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.status_original = p.status_original == null ? "" : p.status_original;
            p.check_list_date = p.check_list_date == null ? "" : p.check_list_date;
            p.email_do = p.email_do == null ? "" : p.email_do;
            p.privi1_date = p.privi1_date == null ? "" : p.privi1_date;
            p.privi2_date = p.privi2_date == null ? "" : p.privi2_date;
            p.privi1_desc = p.privi1_desc == null ? "" : p.privi1_desc;
            p.privi2_desc = p.privi2_desc == null ? "" : p.privi2_desc;
            p.doc_authen1_date = p.doc_authen1_date == null ? "" : p.doc_authen1_date;
            p.doc_authen2_date = p.doc_authen2_date == null ? "" : p.doc_authen2_date;
            p.doc_authen3_date = p.doc_authen3_date == null ? "" : p.doc_authen3_date;
            p.enter_bl = p.enter_bl == null ? "" : p.enter_bl;
            p.insurance_atten = p.insurance_atten == null ? "" : p.insurance_atten;
            p.email_do1 = p.email_do1 == null ? "" : p.email_do1;
            p.email_do1_date = p.email_do1_date == null ? "" : p.email_do1_date;
            p.do_date_send = p.do_date_send == null ? "" : p.do_date_send;
            p.do_date_receive = p.do_date_receive == null ? "" : p.do_date_receive;
            p.tax_date_send = p.tax_date_send == null ? "" : p.tax_date_send;
            p.tax_date_receive = p.tax_date_receive == null ? "" : p.tax_date_receive;
            p.exp1_date_send = p.exp1_date_send == null ? "" : p.exp1_date_send;
            p.exp1_date_receive = p.exp1_date_receive == null ? "" : p.exp1_date_receive;
            p.exp2_date_send = p.exp2_date_send == null ? "" : p.exp2_date_send;
            p.exp2_date_receive = p.exp2_date_receive == null ? "" : p.exp2_date_receive;
            p.receipt_date = p.receipt_date == null ? "" : p.receipt_date;
            p.receipt_copy_date = p.receipt_copy_date == null ? "" : p.receipt_copy_date;
            p.accept_tender = p.accept_tender == null ? "" : p.accept_tender;
            p.advance_billing = p.advance_billing == null ? "" : p.advance_billing;
            p.approve_date = p.approve_date == null ? "" : p.approve_date;
            p.parent1 = p.parent1 == null ? "" : p.parent1;
            p.date_create = p.date_create == null ? "" : p.date_create;
            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.remark = p.remark == null ? "" : p.remark;

            p.job_import_id = int.TryParse(p.job_import_id, out chk) ? chk.ToString() : "0";
            p.type_of_bl = int.TryParse(p.type_of_bl, out chk) ? chk.ToString() : "0";
            p.privi1_id = int.TryParse(p.privi1_id, out chk) ? chk.ToString() : "0";
            p.privi2_id = int.TryParse(p.privi2_id, out chk) ? chk.ToString() : "0";
            p.doc_authen1_id = int.TryParse(p.doc_authen1_id, out chk) ? chk.ToString() : "0";
            p.doc_authen2_id = int.TryParse(p.doc_authen2_id, out chk) ? chk.ToString() : "0";
            p.doc_authen3_id = int.TryParse(p.doc_authen3_id, out chk) ? chk.ToString() : "0";
            //p.cust_id = int.TryParse(p.cust_id, out chk) ? chk.ToString() : "0";
            //p.cust_id = int.TryParse(p.cust_id, out chk) ? chk.ToString() : "0";
            //p.cust_id = int.TryParse(p.cust_id, out chk) ? chk.ToString() : "0";
            //p.amphur_id = int.TryParse(p.amphur_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(JobImportCheckList p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);

            sql = "Insert Into " + jcl.table + "(" + jcl.job_import_id + "," + jcl.status_original + "," + jcl.check_list_date + "," +
                jcl.type_of_bl + "," + jcl.email_do + "," + jcl.privi1_id + "," +
                jcl.privi2_id + "," + jcl.privi1_date + "," + jcl.privi2_date + "," +
                jcl.privi1_desc + "," + jcl.privi2_desc + "," + jcl.doc_authen1_id + "," +
                jcl.doc_authen2_id + "," + jcl.doc_authen3_id + "," + jcl.doc_authen1_date + "," +
                jcl.doc_authen2_date + "," + jcl.doc_authen3_date + "," + jcl.enter_bl + "," +
                jcl.insurance_atten + "," + jcl.email_do1 + "," + jcl.email_do1_date + "," +
                jcl.do_date_send + "," + jcl.do_date_receive + ", " + jcl.tax_date_send + ", " +
                jcl.tax_date_receive + "," + jcl.exp1_date_send + ", " + jcl.exp1_date_receive + ", " +
                jcl.date_create + "," + jcl.date_modi + ", " + jcl.date_cancel + ", " +
                jcl.user_create + "," + jcl.user_modi + ", " + jcl.user_cancel + ", " +
                jcl.active + "," + jcl.exp2_date_send + ", " + jcl.exp2_date_receive + ", " +
                jcl.receipt_date + ", " + jcl.receipt_copy_date + ", " + jcl.accept_tender + ", " +
                jcl.advance_billing + ", " + jcl.approve_date + "," + jcl.parent1 + ", " +
                jcl.remark + " " +
                ") " +
                "Values ('" + p.job_import_id + "','" + p.status_original + "','" + p.check_list_date + "'," +
                "'" + p.type_of_bl + "','" + p.email_do.Replace("'", "''") + "','" + p.privi1_id + "'," +
                "'" + p.privi2_id + "','" + p.privi1_date + "','" + p.privi2_date.Replace("'", "''") + "'," +
                "'" + p.privi1_desc.Replace("'", "''") + "','" + p.privi2_desc.Replace("'", "''") + "','" + p.doc_authen1_id.Replace("'", "''") + "'," +
                "'" + p.doc_authen2_id.Replace("'", "''") + "','" + p.doc_authen3_id.Replace("'", "''") + "','" + p.doc_authen1_date.Replace("'", "''") + "'," +
                "'" + p.doc_authen2_date.Replace("'", "''") + "','" + p.doc_authen3_date + "','" + p.enter_bl + "'," +
                "'" + p.insurance_atten + "','" + p.email_do1 + "','" + p.email_do1_date + "', " +
                "'" + p.do_date_send + "','" + p.do_date_receive.Replace("'", "''") + "','" + p.tax_date_send + "', " +
                "'" + p.tax_date_receive + "','" + p.exp1_date_send.Replace("'", "''") + "','" + p.exp1_date_receive + "', " +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + conn.user.staff_id + "','" + p.user_modi + "','" + p.user_cancel + "', " +
                "'" + p.active + "','" + p.exp2_date_send.Replace("'", "''") + "','" + p.exp2_date_receive.Replace("'", "''") + "', " +
                "'" + p.receipt_date.Replace("'", "''") + "','" + p.receipt_copy_date.Replace("'", "''") + "','" + p.accept_tender.Replace("'", "''") + "'," +
                "'" + p.advance_billing.Replace("'", "''") + "','" + p.approve_date.Replace("'", "''") + "','" + p.parent1.Replace("'", "''") + "'," +
                "'" + p.remark.Replace("'", "''") + "' " +
                ")";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
                String code = re.Substring(re.Length - 6);                
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String update(JobImportCheckList p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + jcl.table + " Set " +
                " " + jcl.job_import_id + " = '" + p.job_import_id + "'" +
                "," + jcl.status_original + " = '" + p.status_original.Replace("'", "''") + "'" +
                "," + jcl.check_list_date + " = '" + p.check_list_date + "'" +
                "," + jcl.type_of_bl + " = '" + p.type_of_bl.Replace("'", "''") + "'" +
                "," + jcl.email_do + " = '" + p.email_do.Replace("'", "''") + "'" +
                "," + jcl.privi1_id + " = '" + p.privi1_id.Replace("'", "''") + "'" +
                "," + jcl.privi2_id + " = '" + p.privi2_id.Replace("'", "''") + "'" +
                "," + jcl.privi1_date + " = '" + p.privi1_date.Replace("'", "''") + "'" +
                "," + jcl.privi2_date + " = '" + p.privi2_date.Replace("'", "''") + "'" +
                "," + jcl.privi1_desc + " = '" + p.privi1_desc + "'" +
                "," + jcl.privi2_desc + " = '" + p.privi2_desc + "'" +
                "," + jcl.doc_authen1_id + " = '" + p.doc_authen1_id + "'" +
                "," + jcl.doc_authen2_id + " = '" + p.doc_authen2_id + "'" +
                "," + jcl.doc_authen3_id + " = '" + p.doc_authen3_id + "'" +
                "," + jcl.doc_authen1_date + " = '" + p.doc_authen1_date + "'" +
                "," + jcl.doc_authen2_date + " = '" + p.doc_authen2_date.Replace("'", "''") + "'" +
                "," + jcl.doc_authen3_date + " = '" + p.doc_authen3_date.Replace("'", "''") + "'" +
                "," + jcl.enter_bl + " = '" + p.enter_bl + "'" +
                "," + jcl.insurance_atten + " = '" + p.insurance_atten + "' " +
                "," + jcl.email_do1 + " = '" + p.email_do1 + "' " +
                "," + jcl.email_do1_date + " = '" + p.email_do1_date + "' " +
                "," + jcl.do_date_send + " = '" + p.do_date_send + "' " +
                "," + jcl.do_date_receive + " = '" + p.do_date_receive + "' " +
                "," + jcl.tax_date_send + " = '" + p.tax_date_send + "' " +
                "," + jcl.tax_date_receive + " = '" + p.tax_date_receive + "' " +
                "," + jcl.exp1_date_send + " = '" + p.exp1_date_send + "' " +
                "," + jcl.exp1_date_receive + " = '" + p.exp1_date_receive + "' " +
                "," + jcl.date_modi + " = now() " +
                "," + jcl.user_modi + " = '" + conn.user.staff_id + "' " +
                "," + jcl.exp2_date_send + " = '" + p.exp2_date_send.Replace("'", "''") + "' " +
                "," + jcl.exp2_date_receive + " = '" + p.exp2_date_receive.Replace("'", "''") + "' " +
                "," + jcl.receipt_date + " = '" + p.receipt_date.Replace("'", "''") + "' " +
                "," + jcl.receipt_copy_date + " = '" + p.receipt_copy_date.Replace("'", "''") + "' " +
                "," + jcl.accept_tender + " = '" + p.accept_tender.Replace("'", "''") + "' " +
                "," + jcl.advance_billing + " = '" + p.advance_billing.Replace("'", "''") + "' " +
                "," + jcl.approve_date + " = '" + p.approve_date.Replace("'", "''") + "' " +
                "," + jcl.parent1 + " = '" + p.parent1.Replace("'", "''") + "' " +
                "," + jcl.remark + " = '" + p.remark.Replace("'", "''") + "' " +

                "Where " + jcl.pkField + "='" + p.import_check_list_id + "'"
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
        public String insertJobImportCheckList(JobImportCheckList p)
        {
            String re = "";

            if (p.import_check_list_id.Equals(""))
            {
                re = insert(p);
            }
            else
            {
                re = update(p);
            }
            return re;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select jcl.* " +
                "From " + jcl.table + " jcl " +
                "Where cont." + jcl.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public JobImportCheckList selectByPk1(String copId)
        {
            JobImportCheckList cont1 = new JobImportCheckList();
            DataTable dt = new DataTable();
            String sql = "select jcl.*  " +
                "From " + jcl.table + " jcl " +
                
                "Where jcl." + jcl.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cont1 = setJobImportCheckList(dt);
            return cont1;
        }
        public JobImportCheckList selectByJobId(String copId)
        {
            JobImportCheckList cont1 = new JobImportCheckList();
            DataTable dt = new DataTable();
            String sql = "select jcl.*  " +
                "From " + jcl.table + " jcl " +

                "Where jcl." + jcl.job_import_id + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cont1 = setJobImportCheckList(dt);
            return cont1;
        }
        private JobImportCheckList setJobImportCheckList(DataTable dt)
        {
            JobImportCheckList jcl1 = new JobImportCheckList();
            if (dt.Rows.Count > 0)
            {
                jcl1.import_check_list_id  = dt.Rows[0][jcl.import_check_list_id].ToString();
                jcl1.job_import_id  = dt.Rows[0][jcl.job_import_id].ToString();
                jcl1.status_original  = dt.Rows[0][jcl.status_original].ToString();
                jcl1.check_list_date  = dt.Rows[0][jcl.check_list_date].ToString();
                jcl1.type_of_bl  = dt.Rows[0][jcl.type_of_bl].ToString();
                jcl1.email_do  = dt.Rows[0][jcl.email_do].ToString();
                jcl1.privi1_id  = dt.Rows[0][jcl.privi1_id].ToString();
                jcl1.privi2_id  = dt.Rows[0][jcl.privi2_id].ToString();
                jcl1.privi1_date  = dt.Rows[0][jcl.privi1_date].ToString();
                jcl1.privi2_date  = dt.Rows[0][jcl.privi2_date].ToString();
                jcl1.privi1_desc  = dt.Rows[0][jcl.privi1_desc].ToString();
                jcl1.privi2_desc  = dt.Rows[0][jcl.privi2_desc].ToString();
                jcl1.doc_authen1_id  = dt.Rows[0][jcl.doc_authen1_id].ToString();
                jcl1.doc_authen2_id  = dt.Rows[0][jcl.doc_authen2_id].ToString();
                jcl1.doc_authen3_id  = dt.Rows[0][jcl.doc_authen3_id].ToString();
                jcl1.doc_authen1_date  = dt.Rows[0][jcl.doc_authen1_date].ToString();
                jcl1.doc_authen2_date  = dt.Rows[0][jcl.doc_authen2_date].ToString();
                jcl1.doc_authen3_date  = dt.Rows[0][jcl.doc_authen3_date].ToString();
                jcl1.enter_bl  = dt.Rows[0][jcl.enter_bl].ToString();
                jcl1.insurance_atten  = dt.Rows[0][jcl.insurance_atten].ToString();
                jcl1.email_do1  = dt.Rows[0][jcl.email_do1].ToString();
                jcl1.email_do1_date  = dt.Rows[0][jcl.email_do1_date].ToString();
                jcl1.do_date_send  = dt.Rows[0][jcl.do_date_send].ToString();
                jcl1.do_date_receive  = dt.Rows[0][jcl.do_date_receive].ToString();
                jcl1.tax_date_send  = dt.Rows[0][jcl.tax_date_send].ToString();
                jcl1.tax_date_receive  = dt.Rows[0][jcl.tax_date_receive].ToString();
                jcl1.exp1_date_send  = dt.Rows[0][jcl.exp1_date_send].ToString();
                jcl1.exp1_date_receive  = dt.Rows[0][jcl.exp1_date_receive].ToString();
                jcl1.exp2_date_send  = dt.Rows[0][jcl.exp2_date_send].ToString();
                jcl1.exp2_date_receive  = dt.Rows[0][jcl.exp2_date_receive].ToString();
                jcl1.receipt_date  = dt.Rows[0][jcl.receipt_date].ToString();
                jcl1.receipt_copy_date  = dt.Rows[0][jcl.receipt_copy_date].ToString();
                jcl1.accept_tender  = dt.Rows[0][jcl.accept_tender].ToString();
                jcl1.advance_billing  = dt.Rows[0][jcl.advance_billing].ToString();
                jcl1.approve_date  = dt.Rows[0][jcl.approve_date].ToString();
                jcl1.parent1  = dt.Rows[0][jcl.parent1].ToString();
                jcl1.date_create  = dt.Rows[0][jcl.date_create].ToString();
                jcl1.date_modi  = dt.Rows[0][jcl.date_modi].ToString();
                jcl1.date_cancel  = dt.Rows[0][jcl.date_cancel].ToString();
                jcl1.user_create  = dt.Rows[0][jcl.user_create].ToString();
                jcl1.user_modi  = dt.Rows[0][jcl.user_modi].ToString();
                jcl1.user_cancel  = dt.Rows[0][jcl.user_cancel].ToString();
                jcl1.remark  = dt.Rows[0][jcl.remark].ToString();
                jcl1.active  = dt.Rows[0][jcl.active].ToString();
            }
            return jcl1;
        }
    }
}
