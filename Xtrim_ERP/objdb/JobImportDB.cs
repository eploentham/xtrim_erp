using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class JobImportDB
    {
        public JobImport jim;
        ConnectDB conn;

        public List<JobImport> lJim;
        public List<JobImport> lJim1;
        public List<String> lYear;

        public JobImportDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jim = new JobImport();
            jim.job_import_id = "job_import_id";
            jim.job_import_code = "job_import_code";
            jim.job_import_date = "job_import_date";
            jim.cust_id = "cust_id";
            jim.imp_id = "imp_id";
            jim.transport_mode = "transport_mode";
            jim.staff_id = "staff_id";
            jim.entry_type_id = "entry_type_id";
            jim.privi_id = "privi_id";
            jim.ref_1 = "ref_1";
            jim.ref_2 = "ref_2";
            jim.ref_3 = "ref_3";
            jim.ref_4 = "ref_4";
            jim.ref_5 = "ref_5";
            jim.ref_edi = "ref_edi";
            jim.imp_entry = "imp_entry";
            jim.edi_response = "edi_response";
            jim.tax_method_id = "tax_method_id";
            jim.check_exam_id = "check_exam_id";
            jim.inv_date = "inv_date";
            jim.tax_amt = "tax_amt";
            jim.insr_date = "insr_date";
            jim.insr_id = "insr_id";
            jim.policy_no = "policy_no";
            jim.premium = "premium";
            jim.policy_date = "policy_date";
            jim.policy_clause = "policy_clause";
            jim.job_year = "job_year";
            jim.date_create = "date_create";
            jim.date_modi = "date_modi";
            jim.date_cancel = "date_cancel";
            jim.user_create = "user_create";
            jim.user_modi = "user_modi";
            jim.user_cancel = "user_cancel";
            jim.active = "active";
            jim.remark3 = "remark3";
            jim.remark1 = "remark1";
            jim.remark2 = "remark2";
            jim.jobno = "job_no";
            jim.job_date = "job_date";
            jim.imp_date = "imp_date";
            jim.bl = "bl";

            jim.remark4 = "remark4";
            jim.remark5 = "remark5";
            jim.remark6 = "remark6";
            jim.marsk1 = "marsk1";
            jim.marsk2 = "marsk2";
            jim.marsk3 = "marsk3";
            jim.marsk4 = "marsk4";
            jim.marsk5 = "marsk5";
            jim.marsk6 = "marsk6";

            jim.container_yard1_id = "container_yard1_id";
            jim.container_yard2_id = "container_yard2_id";
            jim.container_yard3_id = "container_yard3_id";
            jim.container_yard4_id = "container_yard4_id";
            jim.container_yard5_id = "container_yard5_id";
            jim.container_yard1_addr = "container_yard1_addr";
            jim.container_yard2_addr = "container_yard2_addr";
            jim.container_yard3_addr = "container_yard3_addr";
            jim.container_yard4_addr = "container_yard4_addr";
            jim.container_yard5_addr = "container_yard5_addr";
            jim.time_open_close1 = "time_open_close1";
            jim.time_open_close2 = "time_open_close2";
            jim.time_open_close3 = "time_open_close3";
            jim.time_open_close4 = "time_open_close4";
            jim.time_open_close5 = "time_open_close5";
            jim.time_open_close_over_time1 = "time_open_close_over_time1";
            jim.time_open_close_over_time2 = "time_open_close_over_time2";
            jim.time_open_close_over_time3 = "time_open_close_over_time3";
            jim.time_open_close_over_time4 = "time_open_close_over_time4";
            jim.time_open_close_over_time5 = "time_open_close_over_time5";
            jim.status_container_yard1_tax = "status_container_yard1_tax";
            jim.status_container_yard2_tax = "status_container_yard2_tax";
            jim.status_container_yard3_tax = "status_container_yard3_tax";
            jim.status_container_yard4_tax = "status_container_yard4_tax";
            jim.status_container_yard5_tax = "status_container_yard5_tax";

            jim.cusAddr = "";
            jim.impAddr = "";
            jim.cusNameT = "";
            jim.impNameT = "";
            jim.cusCode = "";
            jim.impCode = "";

            jim.fwdCode = "";
            jim.fwdNameT = "";
            //jim.

            jim.table = "t_job_import";
            jim.pkField = "job_import_id";

            lJim = new List<JobImport>();
            lJim1 = new List<JobImport>();
            lYear = new List<String>();

            //getlJim();
        }
        public void getlJim()
        {
            //lDept = new List<Position>();

            lJim.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                JobImport jim1 = new JobImport();
                jim1.job_import_id = row[jim.job_import_id].ToString();
                jim1.job_import_code = row[jim.job_import_code].ToString();
                //jim1.entry_type_name_e = row[jim.entry_type_name_e].ToString();
                //jim1.entry_type_name_t = row[jim.entry_type_name_t].ToString();
                JobImport jim2 = new JobImport();
                jim2.job_import_id = row[jim.job_import_id].ToString();
                jim2.job_import_code = row[jim.job_import_code].ToString().Replace("IMP ","");

                lJim.Add(jim1);
                lJim1.Add(jim2);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (JobImport jim1 in lJim)
            {
                if (code.Trim().Equals(jim1.job_import_code))
                {
                    id = jim1.job_import_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByCode1(String code)
        {
            String id = "";
            foreach (JobImport jim1 in lJim1)
            {
                if (code.Equals(jim1.job_import_code))
                {
                    id = jim1.job_import_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(JobImport p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.remark2 = p.remark2 == null ? "" : p.remark2;
            p.remark1 = p.remark1 == null ? "" : p.remark1;
            p.remark3 = p.remark3 == null ? "" : p.remark3;
            p.remark4 = p.remark4 == null ? "" : p.remark4;
            p.remark5 = p.remark5 == null ? "" : p.remark5;
            p.remark6 = p.remark6 == null ? "" : p.remark6;
            p.marsk1 = p.marsk1 == null ? "" : p.marsk1;
            p.marsk2 = p.marsk2 == null ? "" : p.marsk2;
            p.marsk3 = p.marsk3 == null ? "" : p.marsk3;
            p.marsk4 = p.marsk4 == null ? "" : p.marsk4;
            p.marsk5 = p.marsk5 == null ? "" : p.marsk5;
            p.marsk6 = p.marsk6 == null ? "" : p.marsk6;

            p.job_year = p.job_year == null ? "" : p.job_year;
            p.policy_clause = p.policy_clause == null ? "" : p.policy_clause;
            p.policy_date = p.policy_date == null ? "" : p.policy_date;
            p.policy_no = p.policy_no == null ? "" : p.policy_no;
            p.insr_date = p.insr_date == null ? "" : p.insr_date;
            p.inv_date = p.inv_date == null ? "" : p.inv_date;
            p.edi_response = p.edi_response == null ? "" : p.edi_response;
            p.imp_entry = p.imp_entry == null ? "" : p.imp_entry;
            p.ref_edi = p.ref_edi == null ? "" : p.ref_edi;
            p.ref_5 = p.ref_5 == null ? "" : p.ref_5;
            p.ref_4 = p.ref_4 == null ? "" : p.ref_4;
            p.ref_3 = p.ref_3 == null ? "" : p.ref_3;
            p.ref_2 = p.ref_2 == null ? "" : p.ref_2;
            p.ref_1 = p.ref_1 == null ? "" : p.ref_1;
            p.entry_type_id = p.entry_type_id == null ? "" : p.entry_type_id;
            p.transport_mode = p.transport_mode == null ? "" : p.transport_mode;
            p.job_import_date = p.job_import_date == null ? "" : p.job_import_date;
            p.job_import_code = p.job_import_code == null ? "" : p.job_import_code;
            p.jobno = p.jobno == null ? "" : p.jobno;
            p.job_date = p.job_date == null ? "" : p.job_date;
            p.imp_date = p.imp_date == null ? "" : p.imp_date;
            p.bl = p.bl == null ? "" : p.bl;
            conn.user.staff_id = conn.user.staff_id == null ? "" : conn.user.staff_id;
            p.container_yard1_id = p.container_yard1_id == null ? "0" : p.container_yard1_id;
            p.container_yard2_id = p.container_yard2_id == null ? "0" : p.container_yard2_id;
            p.container_yard3_id = p.container_yard3_id == null ? "0" : p.container_yard3_id;
            p.container_yard4_id = p.container_yard4_id == null ? "0" : p.container_yard4_id;
            p.container_yard5_id = p.container_yard5_id == null ? "0" : p.container_yard5_id;
            p.container_yard1_addr = p.container_yard1_addr == null ? "" : p.container_yard1_addr;
            p.container_yard2_addr = p.container_yard2_addr == null ? "" : p.container_yard2_addr;
            p.container_yard3_addr = p.container_yard3_addr == null ? "" : p.container_yard3_addr;
            p.container_yard4_addr = p.container_yard4_addr == null ? "" : p.container_yard4_addr;
            p.container_yard5_addr = p.container_yard5_addr == null ? "" : p.container_yard5_addr;
            p.time_open_close1 = p.time_open_close1 == null ? "" : p.time_open_close1;
            p.time_open_close2 = p.time_open_close2 == null ? "" : p.time_open_close2;
            p.time_open_close3 = p.time_open_close3 == null ? "" : p.time_open_close3;
            p.time_open_close4 = p.time_open_close4 == null ? "" : p.time_open_close4;
            p.time_open_close5 = p.time_open_close5 == null ? "" : p.time_open_close5;
            p.time_open_close_over_time1 = p.time_open_close_over_time1 == null ? "" : p.time_open_close_over_time1;
            p.time_open_close_over_time2 = p.time_open_close_over_time2 == null ? "" : p.time_open_close_over_time2;
            p.time_open_close_over_time3 = p.time_open_close_over_time3 == null ? "" : p.time_open_close_over_time3;
            p.time_open_close_over_time4 = p.time_open_close_over_time4 == null ? "" : p.time_open_close_over_time4;
            p.time_open_close_over_time5 = p.time_open_close_over_time5 == null ? "" : p.time_open_close_over_time5;
            p.status_container_yard1_tax = p.status_container_yard1_tax == null ? "0" : p.status_container_yard1_tax;
            p.status_container_yard2_tax = p.status_container_yard2_tax == null ? "0" : p.status_container_yard2_tax;
            p.status_container_yard3_tax = p.status_container_yard3_tax == null ? "0" : p.status_container_yard3_tax;
            p.status_container_yard4_tax = p.status_container_yard4_tax == null ? "0" : p.status_container_yard4_tax;
            p.status_container_yard5_tax = p.status_container_yard5_tax == null ? "0" : p.status_container_yard5_tax;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.cust_id = int.TryParse(p.cust_id, out chk) ? chk.ToString() : "0";
            p.imp_id = int.TryParse(p.imp_id, out chk) ? chk.ToString() : "0";
            p.staff_id = int.TryParse(p.staff_id, out chk) ? chk.ToString() : "0";
            p.privi_id = int.TryParse(p.privi_id, out chk) ? chk.ToString() : "0";
            p.tax_method_id = int.TryParse(p.tax_method_id, out chk) ? chk.ToString() : "0";
            p.check_exam_id = int.TryParse(p.check_exam_id, out chk) ? chk.ToString() : "0";
            p.insr_id = int.TryParse(p.insr_id, out chk) ? chk.ToString() : "0";

            p.tax_amt = Decimal.TryParse(p.tax_amt, out chk1) ? chk1.ToString() : "0";
            p.premium = Decimal.TryParse(p.premium, out chk1) ? chk1.ToString() : "0";
            p.entry_type_id = Decimal.TryParse(p.entry_type_id, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(JobImport p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            Decimal chk1 = 0;

            chkNull(p);

            sql = "Insert Into " + jim.table + "(" + jim.job_import_code + "," + jim.job_import_date + "," + jim.cust_id + "," +
                jim.imp_id + "," + jim.transport_mode + "," + jim.staff_id + "," +
                jim.entry_type_id + "," + jim.privi_id + "," + jim.ref_1 + "," +
                jim.ref_2 + "," + jim.ref_3 + "," + jim.ref_4 + "," +
                jim.ref_5 + "," + jim.ref_edi + "," + jim.imp_entry + "," +
                jim.edi_response + "," + jim.tax_method_id + "," + jim.check_exam_id + "," +
                jim.inv_date + "," + jim.tax_amt + "," + jim.insr_date + "," +
                jim.insr_id + "," + jim.policy_no + ", " + jim.premium + ", " +
                jim.policy_date + "," + jim.policy_clause + ", " + jim.job_year + ", " +
                jim.date_create + "," + jim.date_modi + ", " + jim.date_cancel + ", " +
                jim.user_create + "," + jim.user_modi + ", " + jim.user_cancel + ", " +
                jim.active + "," + jim.remark3 + ", " + jim.remark1 + ", " +
                jim.remark2 + ", " + jim.jobno + ", " + jim.job_date + ", " +
                jim.imp_date + ", " + jim.bl + "," + jim.remark4 + ", " +
                jim.remark5 + ", " + jim.remark6 + "," + jim.marsk1 + ", " +
                jim.marsk2 + ", " + jim.marsk3 + "," + jim.marsk4 + ", " +
                jim.marsk5 + ", " + jim.marsk6 + ", " +
                jim.container_yard1_id + ", " + jim.container_yard2_id + "," + jim.container_yard3_id + ", " +
                jim.container_yard4_id + ", " + jim.container_yard5_id + "," + jim.container_yard1_addr + ", " +
                jim.container_yard2_addr + ", " + jim.container_yard3_addr + "," + jim.container_yard4_addr + ", " +
                jim.container_yard5_addr + ", " + jim.time_open_close1 + "," + jim.time_open_close2 + ", " +
                jim.time_open_close3 + ", " + jim.time_open_close4 + "," + jim.time_open_close5 + ", " +
                jim.time_open_close_over_time1 + ", " + jim.time_open_close_over_time2 + "," + jim.time_open_close_over_time3 + ", " +
                jim.time_open_close_over_time4 + ", " + jim.time_open_close_over_time5 + "," +
                jim.status_container_yard1_tax + ", " + jim.status_container_yard2_tax + "," + jim.status_container_yard3_tax + "," +
                jim.status_container_yard4_tax + ", " + jim.status_container_yard5_tax + " " +
                ") " +
                "Values ('" + p.job_import_code + "','" + p.job_import_date + "','" + p.cust_id + "'," +
                "'" + p.imp_id + "','" + p.transport_mode.Replace("'", "''") + "','" + p.staff_id + "'," +
                "'" + p.entry_type_id + "','" + p.privi_id + "','" + p.ref_1.Replace("'", "''") + "'," +
                "'" + p.ref_2.Replace("'", "''") + "','" + p.ref_3.Replace("'", "''") + "','" + p.ref_4.Replace("'", "''") + "'," +
                "'" + p.ref_5.Replace("'", "''") + "','" + p.ref_edi.Replace("'", "''") + "','" + p.imp_entry.Replace("'", "''") + "'," +
                "'" + p.edi_response.Replace("'", "''") + "','" + p.tax_method_id + "','" + p.check_exam_id + "'," +
                "'" + p.inv_date + "','" + p.tax_amt + "','" + p.insr_date + "', " +
                "'" + p.insr_id + "','" + p.policy_no.Replace("'", "''") + "','" + p.premium + "', " +
                "'" + p.policy_date + "','" + p.policy_clause.Replace("'", "''") + "','" + p.job_year + "', " +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + conn.user.staff_id + "','" + p.user_modi + "','" + p.user_cancel + "', " +
                "'" + p.active + "','" + p.remark3.Replace("'", "''") + "','" + p.remark1.Replace("'", "''") + "', " +
                "'" + p.remark2.Replace("'", "''") + "','" + p.jobno.Replace("'", "''") + "','" + p.job_date.Replace("'", "''") + "'," +
                "'" + p.imp_date.Replace("'", "''") + "','" + p.bl.Replace("'", "''") + "','" + p.remark4.Replace("'", "''") + "'," +
                "'" + p.remark5.Replace("'", "''") + "','" + p.remark6.Replace("'", "''") + "','" + p.marsk1.Replace("'", "''") + "'," +
                "'" + p.marsk2.Replace("'", "''") + "','" + p.marsk3.Replace("'", "''") + "','" + p.marsk4.Replace("'", "''") + "'," +
                "'" + p.marsk5.Replace("'", "''") + "','" + p.marsk6.Replace("'", "''") + "'," +
                "'" + p.container_yard1_id.Replace("'", "''") + "','" + p.container_yard2_id.Replace("'", "''") + "','" + p.container_yard3_id.Replace("'", "''") + "'," +
                "'" + p.container_yard4_id.Replace("'", "''") + "','" + p.container_yard5_id.Replace("'", "''") + "','" + p.container_yard1_addr.Replace("'", "''") + "'," +
                "'" + p.container_yard2_addr.Replace("'", "''") + "','" + p.container_yard3_addr.Replace("'", "''") + "','" + p.container_yard4_addr.Replace("'", "''") + "'," +
                "'" + p.container_yard5_addr.Replace("'", "''") + "','" + p.time_open_close1.Replace("'", "''") + "','" + p.time_open_close2.Replace("'", "''") + "'," +
                "'" + p.time_open_close3.Replace("'", "''") + "','" + p.time_open_close4.Replace("'", "''") + "','" + p.time_open_close5.Replace("'", "''") + "'," +
                "'" + p.time_open_close_over_time1.Replace("'", "''") + "','" + p.time_open_close_over_time2.Replace("'", "''") + "','" + p.time_open_close_over_time3.Replace("'", "''") + "'," +
                "'" + p.time_open_close_over_time4.Replace("'", "''") + "','" + p.time_open_close_over_time5.Replace("'", "''") + "', " +
                "'" + p.status_container_yard1_tax.Replace("'", "''") + "','" + p.status_container_yard2_tax.Replace("'", "''") + "','" + p.status_container_yard3_tax.Replace("'", "''") + "', " +
                "'" + p.status_container_yard4_tax.Replace("'", "''") + "','" + p.status_container_yard5_tax.Replace("'", "''") + "' " + 
                ")";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
                String code = re.Substring(re.Length-6);

                sql = "Update "+jim.table+" Set " +
                    ""+jim.job_import_code+" ='"+ code + "' " +
                    "Where "+jim.job_import_id+"='"+re+"'";
                conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String update(JobImport p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + jim.table + " Set " +
                " " + jim.job_import_code + " = '" + p.job_import_code + "'" +
                "," + jim.job_import_date + " = '" + p.job_import_date.Replace("'", "''") + "'" +
                "," + jim.cust_id + " = '" + p.cust_id + "'" +
                "," + jim.imp_id + " = '" + p.imp_id.Replace("'", "''") + "'" +
                "," + jim.transport_mode + " = '" + p.transport_mode.Replace("'", "''") + "'" +
                "," + jim.staff_id + " = '" + p.staff_id.Replace("'", "''") + "'" +
                "," + jim.entry_type_id + " = '" + p.entry_type_id.Replace("'", "''") + "'" +
                "," + jim.privi_id + " = '" + p.privi_id.Replace("'", "''") + "'" +
                "," + jim.ref_1 + " = '" + p.ref_1.Replace("'", "''") + "'" +
                "," + jim.ref_2 + " = '" + p.ref_2 + "'" +
                "," + jim.ref_3 + " = '" + p.ref_3 + "'" +
                "," + jim.ref_4 + " = '" + p.ref_4 + "'" +
                "," + jim.ref_5 + " = '" + p.ref_5 + "'" +
                "," + jim.ref_edi + " = '" + p.ref_edi + "'" +
                "," + jim.imp_entry + " = '" + p.imp_entry + "'" +
                "," + jim.edi_response + " = '" + p.edi_response.Replace("'", "''") + "'" +
                "," + jim.tax_method_id + " = '" + p.tax_method_id.Replace("'", "''") + "'" +
                "," + jim.check_exam_id + " = '" + p.check_exam_id + "'" +
                "," + jim.inv_date + " = '" + p.inv_date + "' " +
                "," + jim.tax_amt + " = '" + p.tax_amt + "' " +
                "," + jim.insr_date + " = '" + p.insr_date + "' " +
                "," + jim.insr_id + " = '" + p.insr_id + "' " +
                "," + jim.policy_no + " = '" + p.policy_no + "' " +
                "," + jim.premium + " = '" + p.premium + "' " +
                "," + jim.policy_date + " = '" + p.policy_date + "' " +
                "," + jim.policy_clause + " = '" + p.policy_clause + "' " +
                "," + jim.job_year + " = '" + p.job_year + "' " +
                "," + jim.date_modi + " = now() " +
                "," + jim.user_modi + " = '" + conn.user.staff_id + "' " +
                "," + jim.remark3 + " = '" + p.remark3.Replace("'", "''") + "' " +
                "," + jim.remark1 + " = '" + p.remark1.Replace("'", "''") + "' " +
                "," + jim.remark2 + " = '" + p.remark2.Replace("'", "''") + "' " +
                "," + jim.jobno + " = '" + p.jobno.Replace("'", "''") + "' " +
                "," + jim.job_date + " = '" + p.job_date.Replace("'", "''") + "' " +
                "," + jim.imp_date + " = '" + p.imp_date.Replace("'", "''") + "' " +
                "," + jim.bl + " = '" + p.bl.Replace("'", "''") + "' " +
                "," + jim.remark4 + " = '" + p.remark4.Replace("'", "''") + "' " +
                "," + jim.remark5 + " = '" + p.remark5.Replace("'", "''") + "' " +
                "," + jim.remark6 + " = '" + p.remark6.Replace("'", "''") + "' " +
                "," + jim.marsk1 + " = '" + p.marsk1.Replace("'", "''") + "' " +
                "," + jim.marsk2 + " = '" + p.marsk2.Replace("'", "''") + "' " +
                "," + jim.marsk3 + " = '" + p.marsk3.Replace("'", "''") + "' " +
                "," + jim.marsk4 + " = '" + p.marsk4.Replace("'", "''") + "' " +
                "," + jim.marsk5 + " = '" + p.marsk5.Replace("'", "''") + "' " +
                "," + jim.marsk6 + " = '" + p.marsk6.Replace("'", "''") + "' " +
                //"," + jim.container_yard1_id + " = '" + p.container_yard1_id.Replace("'", "''") + "' " +
                //"," + jim.container_yard2_id + " = '" + p.container_yard2_id.Replace("'", "''") + "' " +
                //"," + jim.container_yard3_id + " = '" + p.container_yard3_id.Replace("'", "''") + "' " +
                //"," + jim.container_yard4_id + " = '" + p.container_yard4_id.Replace("'", "''") + "' " +
                //"," + jim.container_yard5_id + " = '" + p.container_yard5_id.Replace("'", "''") + "' " +
                //"," + jim.container_yard1_addr + " = '" + p.container_yard1_addr.Replace("'", "''") + "' " +
                //"," + jim.container_yard2_addr + " = '" + p.container_yard2_addr.Replace("'", "''") + "' " +
                //"," + jim.container_yard3_addr + " = '" + p.container_yard3_addr.Replace("'", "''") + "' " +
                //"," + jim.container_yard4_addr + " = '" + p.container_yard4_addr.Replace("'", "''") + "' " +
                //"," + jim.container_yard5_addr + " = '" + p.container_yard5_addr.Replace("'", "''") + "' " +
                //"," + jim.time_open_close1 + " = '" + p.time_open_close1.Replace("'", "''") + "' " +
                //"," + jim.time_open_close2 + " = '" + p.time_open_close2.Replace("'", "''") + "' " +
                //"," + jim.time_open_close3 + " = '" + p.time_open_close3.Replace("'", "''") + "' " +
                //"," + jim.time_open_close4 + " = '" + p.time_open_close4.Replace("'", "''") + "' " +
                //"," + jim.time_open_close5 + " = '" + p.time_open_close5.Replace("'", "''") + "' " +
                //"," + jim.time_open_close_over_time1 + " = '" + p.time_open_close_over_time1.Replace("'", "''") + "' " +
                //"," + jim.time_open_close_over_time2 + " = '" + p.time_open_close_over_time2.Replace("'", "''") + "' " +
                //"," + jim.time_open_close_over_time3 + " = '" + p.time_open_close_over_time3.Replace("'", "''") + "' " +
                //"," + jim.time_open_close_over_time4 + " = '" + p.time_open_close_over_time4.Replace("'", "''") + "' " +
                //"," + jim.time_open_close_over_time5 + " = '" + p.time_open_close_over_time5.Replace("'", "''") + "' " +
                "Where " + jim.pkField + "='" + p.job_import_id + "'"
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
        public String updateContainerYard(JobImport p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + jim.table + " Set " +
                "" + jim.container_yard1_id + " = '" + p.container_yard1_id.Replace("'", "''") + "' " +
                "," + jim.container_yard2_id + " = '" + p.container_yard2_id.Replace("'", "''") + "' " +
                "," + jim.container_yard3_id + " = '" + p.container_yard3_id.Replace("'", "''") + "' " +
                "," + jim.container_yard4_id + " = '" + p.container_yard4_id.Replace("'", "''") + "' " +
                "," + jim.container_yard5_id + " = '" + p.container_yard5_id.Replace("'", "''") + "' " +
                "," + jim.container_yard1_addr + " = '" + p.container_yard1_addr.Replace("'", "''") + "' " +
                "," + jim.container_yard2_addr + " = '" + p.container_yard2_addr.Replace("'", "''") + "' " +
                "," + jim.container_yard3_addr + " = '" + p.container_yard3_addr.Replace("'", "''") + "' " +
                "," + jim.container_yard4_addr + " = '" + p.container_yard4_addr.Replace("'", "''") + "' " +
                "," + jim.container_yard5_addr + " = '" + p.container_yard5_addr.Replace("'", "''") + "' " +
                "," + jim.time_open_close1 + " = '" + p.time_open_close1.Replace("'", "''") + "' " +
                "," + jim.time_open_close2 + " = '" + p.time_open_close2.Replace("'", "''") + "' " +
                "," + jim.time_open_close3 + " = '" + p.time_open_close3.Replace("'", "''") + "' " +
                "," + jim.time_open_close4 + " = '" + p.time_open_close4.Replace("'", "''") + "' " +
                "," + jim.time_open_close5 + " = '" + p.time_open_close5.Replace("'", "''") + "' " +
                "," + jim.time_open_close_over_time1 + " = '" + p.time_open_close_over_time1.Replace("'", "''") + "' " +
                "," + jim.time_open_close_over_time2 + " = '" + p.time_open_close_over_time2.Replace("'", "''") + "' " +
                "," + jim.time_open_close_over_time3 + " = '" + p.time_open_close_over_time3.Replace("'", "''") + "' " +
                "," + jim.time_open_close_over_time4 + " = '" + p.time_open_close_over_time4.Replace("'", "''") + "' " +
                "," + jim.time_open_close_over_time5 + " = '" + p.time_open_close_over_time5.Replace("'", "''") + "' " +
                "," + jim.status_container_yard1_tax + " = '" + p.status_container_yard1_tax.Replace("'", "''") + "' " +
                "," + jim.status_container_yard2_tax + " = '" + p.status_container_yard2_tax.Replace("'", "''") + "' " +
                "," + jim.status_container_yard3_tax + " = '" + p.status_container_yard3_tax.Replace("'", "''") + "' " +
                "," + jim.status_container_yard4_tax + " = '" + p.status_container_yard4_tax.Replace("'", "''") + "' " +
                "," + jim.status_container_yard5_tax + " = '" + p.status_container_yard5_tax.Replace("'", "''") + "' " +
                "Where " + jim.pkField + "='" + p.job_import_id + "'"
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
        public String insertJobImport(JobImport p)
        {
            String re = "";

            if (p.job_import_id.Equals(""))
            {
                re = insert(p);
            }
            else
            {
                re = update(p);
            }
            return re;
        }
        public Dictionary<string, string> getlJobYear()
        {
            //lDept = new List<Position>();
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            //comboSource.Add("1", "Sunday");
            //comboSource.Add("2", "Monday");

            //string key = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Key;
            //string value = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Value;

            //lYear.Clear();
            DataTable dt = new DataTable();
            dt = selectJobYear();
            foreach (DataRow row in dt.Rows)
            {
                comboSource.Add(row[jim.job_year].ToString(), row[jim.job_year].ToString()+" ("+ row["cnt"].ToString()+")");

                //String jim1 = "";
                //jim1 = row[jim.job_year].ToString();
                //lYear.Add(jim1);
            }
            return comboSource;
        }
        public String getYearCurr()
        {
            String re = "";

            DataTable dt = new DataTable();
            String sql = "select year(now()) as year ";
            dt = conn.selectData(conn.conn, sql);
            
            re = (dt.Rows.Count > 0) ? dt.Rows[0][0].ToString() : "";
            return re;
        }
        public DataTable selectJobYear()
        {
            DataTable dt = new DataTable();
            String sql = "select jim."+jim.job_year+ ", count(1) as cnt  " +
                "From " + jim.table + " jim " +
                " " +
                "Where jim." + jim.active + " ='1' " +
                "Group By "+jim.job_year;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public String deleteAll()
        {
            DataTable dt = new DataTable();
            String sql = "Delete From  " + jim.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select jim.*  " +
                "From " + jim.table + " jim " +
                " " +
                "Where jim." + jim.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByJobYear(String year)
        {
            DataTable dt = new DataTable();
            String sql = "select jim.*  " +
                "From " + jim.table + " jim " +
                " " +
                "Where jim." + jim.active + " ='1' and "+jim.job_year+"='"+year+"' " +
                "Order By "+jim.job_import_code+" desc";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectJimJblByJobYear(String year)
        {
            DataTable dt = new DataTable();
            String sql = "select jim.*, tmn.terminal_code, tmn.terminal_name_t, fwd.forwarder_name_t, jbl.description, 1 as cntinv " +
                "From " + jim.table + " jim " +
                "Left Join t_job_import_bl jbl on jim.job_import_id = jbl.job_import_id " +
                "Left Join b_terminal tmn on jbl.terminal_id = tmn.terminal_id " +
                "Left Join b_forwarder fwd on jbl.forwarder_id = fwd.forwarder_id " +
                //"Left Join t_job_import_inv inv on jbl.job_import_id = inv.job_import_id " +
                "Where jim." + jim.active + " ='1' and " + jim.job_year + "='" + year + "' " +
                "Order By " + jim.job_import_code + " desc";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectJimJblByJobYear1(String year)
        {
            DataTable dt = new DataTable();
            String sql = "select jim.job_import_id, concat('IMP',jim.job_import_code), jim.remark1, cus.cust_name_t, imp.cust_name_t as imp_name_t, tmn.terminal_code, tmn.terminal_name_t, fwd.cust_name_t as forwarder_name_t " +
                ", jbl.description " +
                //", count(jie.job_import_expenses_id) as cntexpn " +
                "From " + jim.table + " jim " +
                "Left Join b_customer cus on jim.cust_id = cus.cust_id " +
                "Left Join b_customer imp on jim.imp_id = imp.cust_id " +
                "Left Join t_job_import_bl jbl on jim.job_import_id = jbl.job_import_id " +
                "Left Join b_terminal tmn on jbl.terminal_id = tmn.terminal_id " +
                "Left Join b_customer fwd on jbl.forwarder_id = fwd.cust_id " +
                "Left Join t_job_import_inv jin on jim.job_import_id = jin.job_import_id " +
                "Left Join t_job_import_expenses jie on jim.job_import_id = jie.job_import_id " +
                "Where jim." + jim.active + " ='1' and " + jim.job_year + "='" + year + "' " +
                //"Group By jim.job_import_id, jim.job_import_code, jim.remark, cus.cust_name_t, imp.imp_name_t, tmn.terminal_code, tmn.terminal_name_t, fwd.forwarder_name_t, jbl.description " +
                " " +
                "Order By " + jim.job_import_code + " desc";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select jim.* " +
                "From " + jim.table + " jim " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where jim." + jim.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public JobImport selectByPk1(String jobId)
        {
            JobImport cop1 = new JobImport();
            DataTable dt = new DataTable();
            String sql = "select jim.*" +
                ", IFNULL(cus.taddr1, '') as taddr1, IFNULL(cus.taddr2, '') as taddr2, " +
                "IFNULL(cus.taddr3, '') as taddr3, IFNULL(cus.taddr4, '') as taddr4 " +
                ", IFNULL(imp.taddr1, '') as imptaddr1, IFNULL(imp.taddr2, '') as imptaddr2, " +
                "IFNULL(imp.taddr3, '') as imptaddr3, IFNULL(imp.taddr4, '') as imptaddr4,  " +
                "IFNULL(cus.cust_name_t, '') as cust_name_t, IFNULL(imp.imp_name_t, '') as imp_name_t," +
                "IFNULL(cus.cust_code, '') as cust_code, IFNULL(imp.imp_code, '') as imp_code, " +
                "IFNULL(ett.entry_type_code, '') as entry_type_code, IFNULL(ett.entry_type_name_t, '') as entry_type_name_t, " +
                "IFNULL(pvl.code, '') as priv_code, IFNULL(pvl.desc1, '') as priv_name_t " +
                "From " + jim.table + " jim " +
                "Left Join b_customer cus On jim.cust_id = cus.cust_id " +
                "Left Join b_importer imp On jim.imp_id = imp.imp_id " +
                "Left Join b_entry_type ett On jim.entry_type_id = ett.entry_type_id " +
                "Left Join b_privilege pvl On jim.privi_id = pvl.priv_id " +
                "Where jim." + jim.pkField + " ='" + jobId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setJobImport(dt);
            return cop1;
        }
        public JobImport selectByJobCode(String jobId)
        {
            JobImport cop1 = new JobImport();
            DataTable dt = new DataTable();
            String sql = "select jim.* " +
                ", IFNULL(cus.taddr1, '') as taddr1, IFNULL(cus.taddr2, '') as taddr2, " +
                "IFNULL(cus.taddr3, '') as taddr3, IFNULL(cus.taddr4, '') as taddr4 " +
                ", IFNULL(imp.taddr1, '') as imptaddr1, IFNULL(imp.taddr2, '') as imptaddr2, " +
                "IFNULL(imp.taddr3, '') as imptaddr3, IFNULL(imp.taddr4, '') as imptaddr4,  " +
                "IFNULL(cus.cust_name_t, '') as cust_name_t, IFNULL(imp.cust_name_t, '') as imp_name_t," +
                "IFNULL(cus.cust_code, '') as cust_code, IFNULL(imp.cust_code, '') as imp_code, " +
                "IFNULL(ett.entry_type_code, '') as entry_type_code, IFNULL(ett.entry_type_name_t, '') as entry_type_name_t, " +
                "IFNULL(pvl.code, '') as priv_code, IFNULL(pvl.desc1, '') as priv_name_t " +
                "From " + jim.table + " jim " +
                "Left Join b_customer cus On jim.cust_id = cus.cust_id " +
                "Left Join b_customer imp On jim.imp_id = cus.cust_id and cus.status_imp = '1' " +
                "Left Join b_entry_type ett On jim.entry_type_id = ett.entry_type_id " +
                "Left Join b_privilege pvl On jim.privi_id = pvl.priv_id " +
                "Where jim." + jim.job_import_code + " ='" + jobId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setJobImport(dt);
            return cop1;
        }
        public String selectByJobCode1(String copId)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "select jim."+jim.job_import_id+" " +
                "From " + jim.table + " jim " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where jim." + jim.job_import_code + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0][jim.job_import_id].ToString();
            }
            return re;
        }
        private JobImport setJobImport(DataTable dt)
        {
            JobImport jim1 = new JobImport();
            if (dt.Rows.Count > 0)
            {
                jim1.job_import_id = dt.Rows[0][jim.job_import_id].ToString();
                jim1.job_import_code = dt.Rows[0][jim.job_import_code].ToString();
                jim1.job_import_date = dt.Rows[0][jim.job_import_date].ToString();
                jim1.cust_id = dt.Rows[0][jim.cust_id].ToString();
                jim1.imp_id = dt.Rows[0][jim.imp_id].ToString();
                jim1.transport_mode = dt.Rows[0][jim.transport_mode].ToString();
                jim1.staff_id = dt.Rows[0][jim.staff_id].ToString();
                jim1.entry_type_id = dt.Rows[0][jim.entry_type_id].ToString();
                jim1.privi_id = dt.Rows[0][jim.privi_id].ToString();
                jim1.ref_1 = dt.Rows[0][jim.ref_1].ToString();
                jim1.ref_2 = dt.Rows[0][jim.ref_2].ToString();
                jim1.ref_3 = dt.Rows[0][jim.ref_3].ToString();
                jim1.ref_4 = dt.Rows[0][jim.ref_4].ToString();
                jim1.ref_5 = dt.Rows[0][jim.ref_5].ToString();
                jim1.ref_edi = dt.Rows[0][jim.ref_edi].ToString();
                jim1.imp_entry = dt.Rows[0][jim.imp_entry].ToString();
                jim1.edi_response = dt.Rows[0][jim.edi_response].ToString();
                jim1.tax_method_id = dt.Rows[0][jim.tax_method_id].ToString();
                jim1.check_exam_id = dt.Rows[0][jim.check_exam_id].ToString();
                jim1.inv_date = dt.Rows[0][jim.inv_date].ToString();
                jim1.tax_amt = dt.Rows[0][jim.tax_amt].ToString();
                jim1.insr_date = dt.Rows[0][jim.insr_date].ToString();
                jim1.insr_id = dt.Rows[0][jim.insr_id].ToString();
                jim1.policy_no = dt.Rows[0][jim.policy_no].ToString();
                jim1.premium = dt.Rows[0][jim.premium].ToString();
                jim1.policy_date = dt.Rows[0][jim.policy_date].ToString();
                jim1.policy_clause = dt.Rows[0][jim.policy_clause].ToString();
                jim1.job_year = dt.Rows[0][jim.job_year].ToString();
                jim1.date_create = dt.Rows[0][jim.date_create].ToString();
                jim1.date_modi = dt.Rows[0][jim.date_modi].ToString();
                jim1.date_cancel = dt.Rows[0][jim.date_cancel].ToString();
                jim1.user_create = dt.Rows[0][jim.user_create].ToString();
                jim1.user_modi = dt.Rows[0][jim.user_modi].ToString();
                jim1.user_cancel = dt.Rows[0][jim.user_cancel].ToString();
                jim1.active = dt.Rows[0][jim.active].ToString();
                jim1.remark3 = dt.Rows[0][jim.remark3].ToString();
                jim1.remark1 = dt.Rows[0][jim.remark1].ToString();
                jim1.remark2 = dt.Rows[0][jim.remark2].ToString();

                jim1.cusAddr = dt.Rows[0]["taddr1"].ToString()+"\n"+dt.Rows[0]["taddr2"].ToString() + "\n" + dt.Rows[0]["taddr3"].ToString() + "\n" + dt.Rows[0]["taddr4"].ToString();
                jim1.impAddr = dt.Rows[0]["imptaddr1"].ToString() + "\n" + dt.Rows[0]["imptaddr2"].ToString() + "\n" + dt.Rows[0]["imptaddr3"].ToString() + "\n" + dt.Rows[0]["imptaddr4"].ToString();

                jim1.cusNameT = dt.Rows[0]["cust_name_t"].ToString();
                jim1.impNameT = dt.Rows[0]["imp_name_t"].ToString();
                jim1.cusCode = dt.Rows[0]["cust_code"].ToString();
                jim1.impCode = dt.Rows[0]["imp_code"].ToString();
                jim1.ettCode = dt.Rows[0]["entry_type_code"].ToString();
                jim1.ettNameT = dt.Rows[0]["entry_type_name_t"].ToString();
                jim1.pvlCode = dt.Rows[0]["priv_code"].ToString();
                jim1.pvlNameT = dt.Rows[0]["priv_name_t"].ToString();
                jim1.jobno = dt.Rows[0][jim.jobno].ToString();
                jim1.job_date = dt.Rows[0][jim.job_date].ToString();
                jim1.imp_date = dt.Rows[0][jim.imp_date].ToString();
                jim1.bl = dt.Rows[0][jim.bl].ToString();
                jim1.remark4 = dt.Rows[0][jim.remark4].ToString();
                jim1.remark5 = dt.Rows[0][jim.remark5].ToString();
                jim1.remark6 = dt.Rows[0][jim.remark6].ToString();
                jim1.marsk1 = dt.Rows[0][jim.marsk1].ToString();
                jim1.marsk2 = dt.Rows[0][jim.marsk2].ToString();
                jim1.marsk3 = dt.Rows[0][jim.marsk3].ToString();
                jim1.marsk4 = dt.Rows[0][jim.marsk4].ToString();
                jim1.marsk5 = dt.Rows[0][jim.marsk5].ToString();
                jim1.marsk6 = dt.Rows[0][jim.marsk6].ToString();
                jim1.container_yard1_id = dt.Rows[0][jim.container_yard1_id].ToString();
                jim1.container_yard2_id = dt.Rows[0][jim.container_yard2_id].ToString();
                jim1.container_yard3_id = dt.Rows[0][jim.container_yard3_id].ToString();
                jim1.container_yard4_id = dt.Rows[0][jim.container_yard4_id].ToString();
                jim1.container_yard5_id = dt.Rows[0][jim.container_yard5_id].ToString();
                jim1.container_yard1_addr = dt.Rows[0][jim.container_yard1_addr].ToString();
                jim1.container_yard2_addr = dt.Rows[0][jim.container_yard2_addr].ToString();
                jim1.container_yard3_addr = dt.Rows[0][jim.container_yard3_addr].ToString();
                jim1.container_yard4_addr = dt.Rows[0][jim.container_yard4_addr].ToString();
                jim1.container_yard5_addr = dt.Rows[0][jim.container_yard5_addr].ToString();
                jim1.time_open_close1 = dt.Rows[0][jim.time_open_close1].ToString();
                jim1.time_open_close2 = dt.Rows[0][jim.time_open_close2].ToString();
                jim1.time_open_close3 = dt.Rows[0][jim.time_open_close3].ToString();
                jim1.time_open_close4 = dt.Rows[0][jim.time_open_close4].ToString();
                jim1.time_open_close5 = dt.Rows[0][jim.time_open_close5].ToString();
                jim1.time_open_close_over_time1 = dt.Rows[0][jim.time_open_close_over_time1].ToString();
                jim1.time_open_close_over_time2 = dt.Rows[0][jim.time_open_close_over_time2].ToString();
                jim1.time_open_close_over_time3 = dt.Rows[0][jim.time_open_close_over_time3].ToString();
                jim1.time_open_close_over_time4 = dt.Rows[0][jim.time_open_close_over_time4].ToString();
                jim1.time_open_close_over_time5 = dt.Rows[0][jim.time_open_close_over_time5].ToString();
                jim1.status_container_yard1_tax = dt.Rows[0][jim.status_container_yard1_tax].ToString();
                jim1.status_container_yard2_tax = dt.Rows[0][jim.status_container_yard2_tax].ToString();
                jim1.status_container_yard3_tax = dt.Rows[0][jim.status_container_yard3_tax].ToString();
                jim1.status_container_yard4_tax = dt.Rows[0][jim.status_container_yard4_tax].ToString();
                jim1.status_container_yard5_tax = dt.Rows[0][jim.status_container_yard5_tax].ToString();
            }
            else
            {
                jim.job_import_id = "";
                jim.job_import_code = "";
                jim.job_import_date = "";
                jim.cust_id = "";
                jim.imp_id = "";
                jim.transport_mode = "";
                jim.staff_id = "";
                jim.entry_type_id = "";
                jim.privi_id = "";
                jim.ref_1 = "";
                jim.ref_2 = "";
                jim.ref_3 = "";
                jim.ref_4 = "";
                jim.ref_5 = "";
                jim.ref_edi = "";
                jim.imp_entry = "";
                jim.edi_response = "";
                jim.tax_method_id = "";
                jim.check_exam_id = "";
                jim.inv_date = "";
                jim.tax_amt = "";
                jim.insr_date = "";
                jim.insr_id = "";
                jim.policy_no = "";
                jim.premium = "";
                jim.policy_date = "";
                jim.policy_clause = "";
                jim.job_year = "";
                jim.date_create = "";
                jim.date_modi = "";
                jim.date_cancel = "";
                jim.user_create = "";
                jim.user_modi = "";
                jim.user_cancel = "";
                jim.active = "";
                jim.remark3 = "";
                jim.remark1 = "";
                jim.remark2 = "";
                jim.jobno = "";
                jim.job_date = "";
                jim.imp_date = "";
                jim.bl = "";

                jim.remark4 = "";
                jim.remark5 = "";
                jim.remark6 = "";
                jim.marsk1 = "";
                jim.marsk2 = "";
                jim.marsk3 = "";
                jim.marsk4 = "";
                jim.marsk5 = "";
                jim.marsk6 = "";

                jim.container_yard1_id = "";
                jim.container_yard2_id = "";
                jim.container_yard3_id = "";
                jim.container_yard4_id = "";
                jim.container_yard5_id = "";
                jim.container_yard1_addr = "";
                jim.container_yard2_addr = "";
                jim.container_yard3_addr = "";
                jim.container_yard4_addr = "";
                jim.container_yard5_addr = "";
                jim.time_open_close1 = "";
                jim.time_open_close2 = "";
                jim.time_open_close3 = "";
                jim.time_open_close4 = "";
                jim.time_open_close5 = "";
                jim.time_open_close_over_time1 = "";
                jim.time_open_close_over_time2 = "";
                jim.time_open_close_over_time3 = "";
                jim.time_open_close_over_time4 = "";
                jim.time_open_close_over_time5 = "";
                jim.status_container_yard1_tax = "";
                jim.status_container_yard2_tax = "";
                jim.status_container_yard3_tax = "";
                jim.status_container_yard4_tax = "";
                jim.status_container_yard5_tax = "";

                jim.cusAddr = "";
                jim.impAddr = "";
                jim.cusNameT = "";
                jim.impNameT = "";
                jim.cusCode = "";
                jim.impCode = "";

                jim.fwdCode = "";
                jim.fwdNameT = "";
            }

            return jim1;
        }
    }
}
