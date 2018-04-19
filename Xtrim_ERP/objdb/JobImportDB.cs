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
            jim.entry_type = "entry_type_id";
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
            jim.remark = "remark";
            jim.remark1 = "remark1";
            jim.remark2 = "remark2";

            jim.table = "t_job_import";
            jim.pkField = "job_import_id";

            lJim = new List<JobImport>();
            lJim1 = new List<JobImport>();
        }
        public void getlJim()
        {
            //lDept = new List<Department>();

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
                if (code.Trim().Equals(jim1.job_import_code))
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
            p.remark = p.remark == null ? "" : p.remark;
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
            p.entry_type = p.entry_type == null ? "" : p.entry_type;
            p.transport_mode = p.transport_mode == null ? "" : p.transport_mode;
            p.job_import_date = p.job_import_date == null ? "" : p.job_import_date;
            p.job_import_code = p.job_import_code == null ? "" : p.job_import_code;

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
            p.entry_type = Decimal.TryParse(p.entry_type, out chk1) ? chk1.ToString() : "0";
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
                jim.entry_type + "," + jim.privi_id + "," + jim.ref_1 + "," +
                jim.ref_2 + "," + jim.ref_3 + "," + jim.ref_4 + "," +
                jim.ref_5 + "," + jim.ref_edi + "," + jim.imp_entry + "," +
                jim.edi_response + "," + jim.tax_method_id + "," + jim.check_exam_id + "," +
                jim.inv_date + "," + jim.tax_amt + "," + jim.insr_date + "," +
                jim.insr_id + "," + jim.policy_no + ", " + jim.premium + ", " +
                jim.policy_date + "," + jim.policy_clause + ", " + jim.job_year + ", " +
                jim.date_create + "," + jim.date_modi + ", " + jim.date_cancel + ", " +
                jim.user_create + "," + jim.user_modi + ", " + jim.user_cancel + ", " +
                jim.active + "," + jim.remark + ", " + jim.remark1 + ", " +
                jim.remark2 + " " +
                ") " +
                "Values ('" + p.job_import_code + "','" + p.job_import_date + "','" + p.cust_id + "'," +
                "'" + p.imp_id + "','" + p.transport_mode.Replace("'", "''") + "','" + p.staff_id + "'," +
                "'" + p.entry_type + "','" + p.privi_id + "','" + p.ref_1.Replace("'", "''") + "'," +
                "'" + p.ref_2.Replace("'", "''") + "','" + p.ref_3.Replace("'", "''") + "','" + p.ref_4.Replace("'", "''") + "'," +
                "'" + p.ref_5.Replace("'", "''") + "','" + p.ref_edi.Replace("'", "''") + "','" + p.imp_entry.Replace("'", "''") + "'," +
                "'" + p.edi_response.Replace("'", "''") + "','" + p.tax_method_id + "','" + p.check_exam_id + "'," +
                "'" + p.inv_date + "','" + p.tax_amt + "','" + p.insr_date + "', " +
                "'" + p.insr_id + "','" + p.policy_no.Replace("'", "''") + "','" + p.premium + "', " +
                "'" + p.policy_date + "','" + p.policy_clause.Replace("'", "''") + "','" + p.job_year + "', " +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + p.user_create + "','" + p.user_modi + "','" + p.user_cancel + "', " +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.remark1.Replace("'", "''") + "', " +
                "'" + p.remark2.Replace("'", "''") + "' " +
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
                "," + jim.entry_type + " = '" + p.entry_type.Replace("'", "''") + "'" +
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
                "," + jim.date_modi + " = '" + p.date_modi + "' " +
                "," + jim.user_modi + " = '" + p.user_modi + "' " +
                "," + jim.remark + " = '" + p.remark.Replace("'", "''") + "' " +
                "," + jim.remark1 + " = '" + p.remark1.Replace("'", "''") + "' " +
                "," + jim.remark2 + " = '" + p.remark2.Replace("'", "''") + "' " +
                "Where " + jim.pkField + "='" + p.staff_id + "'"
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
        public JobImport selectByPk1(String copId)
        {
            JobImport cop1 = new JobImport();
            DataTable dt = new DataTable();
            String sql = "select jim.* " +
                "From " + jim.table + " jim " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where jim." + jim.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setJobImport(dt);
            return cop1;
        }
        private JobImport setJobImport(DataTable dt)
        {
            JobImport jim = new JobImport();
            if (dt.Rows.Count > 0)
            {
                jim.job_import_id = dt.Rows[0][jim.job_import_id].ToString();
                jim.job_import_code = dt.Rows[0][jim.job_import_code].ToString();
                jim.job_import_date = dt.Rows[0][jim.job_import_date].ToString();
                jim.cust_id = dt.Rows[0][jim.cust_id].ToString();
                jim.imp_id = dt.Rows[0][jim.imp_id].ToString();
                jim.transport_mode = dt.Rows[0][jim.transport_mode].ToString();
                jim.staff_id = dt.Rows[0][jim.staff_id].ToString();
                jim.entry_type = dt.Rows[0][jim.entry_type].ToString();
                jim.privi_id = dt.Rows[0][jim.privi_id].ToString();
                jim.ref_1 = dt.Rows[0][jim.ref_1].ToString();
                jim.ref_2 = dt.Rows[0][jim.ref_2].ToString();
                jim.ref_3 = dt.Rows[0][jim.ref_3].ToString();
                jim.ref_4 = dt.Rows[0][jim.ref_4].ToString();
                jim.ref_5 = dt.Rows[0][jim.ref_5].ToString();
                jim.ref_edi = dt.Rows[0][jim.ref_edi].ToString();
                jim.imp_entry = dt.Rows[0][jim.imp_entry].ToString();
                jim.edi_response = dt.Rows[0][jim.edi_response].ToString();
                jim.tax_method_id = dt.Rows[0][jim.tax_method_id].ToString();
                jim.check_exam_id = dt.Rows[0][jim.check_exam_id].ToString();
                jim.inv_date = dt.Rows[0][jim.inv_date].ToString();
                jim.tax_amt = dt.Rows[0][jim.tax_amt].ToString();
                jim.insr_date = dt.Rows[0][jim.insr_date].ToString();
                jim.insr_id = dt.Rows[0][jim.insr_id].ToString();
                jim.policy_no = dt.Rows[0][jim.policy_no].ToString();
                jim.premium = dt.Rows[0][jim.premium].ToString();
                jim.policy_date = dt.Rows[0][jim.policy_date].ToString();
                jim.policy_clause = dt.Rows[0][jim.policy_clause].ToString();
                jim.job_year = dt.Rows[0][jim.job_year].ToString();
                jim.date_create = dt.Rows[0][jim.date_create].ToString();
                jim.date_modi = dt.Rows[0][jim.date_modi].ToString();
                jim.date_cancel = dt.Rows[0][jim.date_cancel].ToString();
                jim.user_create = dt.Rows[0][jim.user_create].ToString();
                jim.user_modi = dt.Rows[0][jim.user_modi].ToString();
                jim.user_cancel = dt.Rows[0][jim.user_cancel].ToString();
                jim.active = dt.Rows[0][jim.active].ToString();
                jim.remark = dt.Rows[0][jim.remark].ToString();
                jim.remark1 = dt.Rows[0][jim.remark1].ToString();
                jim.remark2 = dt.Rows[0][jim.remark2].ToString();
            }

            return jim;
        }
    }
}
