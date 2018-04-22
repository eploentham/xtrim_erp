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
    public class ImportDataDB
    {
        ConnectDB conn;
        ImporterDB impDB;
        CustomerDB cusDB;
        ConsigneeDB consDB;
        InsuranceDB insrDB;
        DepartmentDB deptDB;
        StaffDB stfDB;
        JobImportDB jimDB;
        TerminalDB tmnDB;
        PortImportDB ptiDB;
        PortOfLoadingDB polDB;
        ForwarderDB fwdDB;
        JobImportBlDB jblDB;
        CurrencyDB currDB;
        JobImportInvDB jinDB;
        EntryTypeDB ettDB;
        IncoTermsDB ictDB;
        TermPaymentDB tpmDB;
        PrivilegeDB pvlDB;
        UnitPackageDB utpDB;
        UnitGwDB ugwDB;

        List<Department> lDept;

        public ImportDataDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            impDB = new ImporterDB(conn);
            cusDB = new CustomerDB(conn);
            consDB = new ConsigneeDB(conn);
            insrDB = new InsuranceDB(conn);
            deptDB = new DepartmentDB(conn);
            stfDB = new StaffDB(conn);
            jimDB = new JobImportDB(conn);
            ptiDB = new PortImportDB(conn);
            polDB = new PortOfLoadingDB(conn);
            tmnDB = new TerminalDB(conn);
            fwdDB = new ForwarderDB(conn);
            jblDB = new JobImportBlDB(conn);
            currDB = new CurrencyDB(conn);
            jinDB = new JobImportInvDB(conn);
            ettDB = new EntryTypeDB(conn);
            ictDB = new IncoTermsDB(conn);
            tpmDB = new TermPaymentDB(conn);
            pvlDB = new PrivilegeDB(conn);
            utpDB = new UnitPackageDB(conn);
            ugwDB = new UnitGwDB(conn);
        }
        public void ImportMEIOSYSimport(String pathA, String flagNew, String flag, ProgressBar pb1)
        {
            pb1.Show();
            DataTable dt = new DataTable();
            String sql = "";
            sql = "Select * From importer ";
            dt = conn.selectData(conn.connIm, sql);
            pb1.Minimum = 0;
            pb1.Maximum = dt.Rows.Count;
            pb1.Value = 0;
            conn.OpenConnectionNoClose();
            if (flagNew.Equals("new"))
            {
                impDB.deleteAll();
            }
            foreach (DataRow row in dt.Rows)
            {
                pb1.Value++;
                Importer imp = new Importer();
                imp.cust_id = "";
                imp.imp_code = row["code"].ToString();
                imp.imp_name_t = row["tname"].ToString();
                imp.imp_name_e = row["ename"].ToString();
                imp.active = "1";

                imp.address_t = "";
                imp.address_e = "";
                imp.addr = "";
                imp.amphur_id = "";
                imp.district_id = "";

                imp.province_id = row["provcode"].ToString();
                imp.zipcode = row["zipcode"].ToString();
                imp.sale_id = "";
                imp.sale_name_t = "";
                imp.fax = "";

                imp.tele = row["tel"].ToString();
                imp.email = row["email"].ToString();
                imp.tax_id = row["taxid"].ToString();
                imp.remark = row["imremark1"].ToString();
                imp.contact_name1 = row["contach"].ToString();

                imp.contact_name2 = "";
                imp.contact_name1_tel = "";
                imp.contact_name2_tel = "";
                imp.status_company = "importer";
                imp.status_vendor = "meiosys";

                imp.date_create = "";
                imp.date_modi = "";
                imp.date_cancel = "";
                imp.user_create = "";
                imp.user_modi = "";

                imp.user_cancel = "";
                imp.remark2 = row["imremark2"].ToString();
                imp.po_due_period = "";

                imp.taddr1 = row["taddr1"].ToString();
                imp.taddr2 = row["taddr2"].ToString();
                imp.taddr3 = row["taddr3"].ToString();
                imp.taddr4 = row["taddr4"].ToString();

                imp.eaddr1 = row["eaddr1"].ToString();
                imp.eaddr2 = row["eaddr2"].ToString();
                imp.eaddr3 = row["eaddr3"].ToString();
                imp.eaddr4 = row["eaddr4"].ToString();

                imp.remark3 = row["imremark3"].ToString();
                imp.payerorg = row["payerorg"].ToString();
                imp.payerprofile = row["payerprofile"].ToString();
                imp.payeruser = row["payeruser"].ToString();

                impDB.insertImporter(imp);
            }

            sql = "Select * From importer ";
            conn.OpenConnectionA(pathA, flag);
            dt.Clear();
            dt = conn.selectDataA(conn.connA, sql);
            foreach (DataRow row in dt.Rows)
            {
                //pb1.Value++;
                Importer imp = new Importer();
                imp.cust_id = "";
                imp.imp_code = row["ImporterID"].ToString();
                imp.imp_name_t = row["ImporterName"].ToString();
                imp.imp_name_e = row["ImporterName"].ToString();
                imp.active = "1";

                imp.address_t = "";
                imp.address_e = "";
                imp.addr = "";
                imp.amphur_id = "";
                imp.district_id = "";

                imp.province_id = "";
                imp.zipcode = "";
                imp.sale_id = "";
                imp.sale_name_t = "";
                imp.fax = row["ImporterFaxNumber"].ToString();

                imp.tele = "";
                imp.email = "";
                imp.tax_id = "";
                imp.remark = row["ImporterFacName"].ToString();
                imp.contact_name1 = "";

                imp.contact_name2 = "";
                imp.contact_name1_tel = "";
                imp.contact_name2_tel = "";
                imp.status_company = "importer";
                imp.status_vendor = "xtrim";

                imp.date_create = "";
                imp.date_modi = "";
                imp.date_cancel = "";
                imp.user_create = "";
                imp.user_modi = "";

                imp.user_cancel = "";
                imp.remark2 = row["ImporterFacContact"].ToString();
                imp.po_due_period = "";

                imp.taddr1 = row["ImporterAddress"].ToString();
                imp.taddr2 = row["ImporterAddress1"].ToString();
                imp.taddr3 = row["ImporterAddress2"].ToString();
                imp.taddr4 = row["ImporterPostalCode"].ToString();

                imp.eaddr1 = row["ImporterCountry/Region"].ToString();
                imp.eaddr2 = row["ImporterPhoneNumber"].ToString();
                imp.eaddr3 = row["ImporterExtension"].ToString();
                imp.eaddr4 = "";

                imp.remark3 = "";
                imp.payerorg = "";
                imp.payerprofile = "";
                imp.payeruser = "";

                impDB.insertImporter(imp);
            }

            conn.CloseConnectionNoClose();
            pb1.Hide();
        }
        public String testConnection(String pathA, String flag)
        {
            String re = "";
            try
            {
                re = conn.TestOpenConnectionA(pathA, flag);
            }
            catch (Exception ex)
            {
                re = "fail";
            }

            return re;
        }
        public void ImportOpenJOBcustomer(String pathA, String flagNew, String flag, ProgressBar pb1)
        {
            pb1.Show();
            DataTable dt = new DataTable();
            String sql = "";
            sql = "Select * from Customers ";
            conn.OpenConnectionA(pathA, flag);
            dt = conn.selectDataA(conn.connA, sql);
            pb1.Minimum = 0;
            pb1.Maximum = dt.Rows.Count;
            pb1.Value = 0;
            conn.OpenConnectionNoClose();
            if (flagNew.Equals("new"))
            {
                cusDB.deleteAll();
            }
            foreach (DataRow row in dt.Rows)
            {
                Customer cons = new Customer();
                cons.cust_id = "";
                cons.cust_code = row["CustomerID"].ToString();
                cons.cust_name_t = row["CustomerName"].ToString();
                cons.cust_name_e = row["CustomerName"].ToString();
                cons.active = "1";

                cons.address_t = row["CustomerAddress"].ToString();
                cons.address_e = row["CustomerAddress"].ToString();
                cons.addr = row["CustomerAddress"].ToString();
                cons.amphur_id = "";
                cons.district_id = "";

                cons.province_id = "";
                cons.zipcode = "";
                cons.sale_id = "";
                cons.sale_name_t = "";
                cons.fax = row["CustomerFaxNumber"].ToString();

                cons.tele = "";
                cons.email = "";
                cons.tax_id = "";
                cons.remark = row["CustomerExtension"].ToString();
                cons.contact_name1 = "";

                cons.contact_name2 = "";
                cons.contact_name1_tel = "";
                cons.contact_name2_tel = "";
                cons.status_company = "";
                cons.status_vendor = "";

                cons.date_create = "";
                cons.date_modi = "";
                cons.date_cancel = "";
                cons.user_create = "";
                cons.user_modi = "";

                cons.user_cancel = "";
                cons.remark2 = row["CustomerPhoneNumber"].ToString();
                cons.po_due_period = "";
                cons.taddr1 = row["CustomerAddress"].ToString();
                cons.taddr2 = row["CustomerCity"].ToString();

                cons.taddr3 = row["CustomerStateOrProvince"].ToString();
                cons.taddr4 = row["CustomerPostalCode"].ToString();
                cons.eaddr1 = row["CustomerStateOrProvince"].ToString();
                cons.eaddr2 = row["CustomerPostalCode"].ToString();
                cons.eaddr3 = row["CustomerCountry/Region"].ToString();

                cons.eaddr4 = row["CustomerPhoneNumber"].ToString();

                cusDB.insertCustomer(cons);
            }
            conn.CloseConnectionNoClose();
            pb1.Hide();
        }
        public void ImportOpenJOBconsignee(String pathA, String flagNew, String flag, ProgressBar pb1)
        {
            pb1.Show();
            DataTable dt = new DataTable();
            String sql = "";
            sql = "Select * from Consignee ";
            conn.OpenConnectionA(pathA, flag);
            dt = conn.selectDataA(conn.connA, sql);
            pb1.Minimum = 0;
            pb1.Maximum = dt.Rows.Count;
            pb1.Value = 0;
            conn.OpenConnectionNoClose();
            if (flagNew.Equals("new"))
            {
                consDB.deleteAll();
            }
            foreach (DataRow row in dt.Rows)
            {
                Consignee cons = new Consignee();
                cons.cons_id = "";
                cons.cons_code = row["ConsigneeID"].ToString();
                cons.cons_name_t = row["ConsigneeName"].ToString();
                cons.cons_name_e = row["ConsigneeName"].ToString();
                cons.active = "1";

                cons.address_t = "";
                cons.address_e = "";
                cons.addr = "";
                cons.amphur_id = "";
                cons.district_id = "";

                cons.province_id = "";
                cons.zipcode = "";
                cons.sale_id = "";
                cons.sale_name_t = "";
                cons.fax = "";

                cons.tele = "";
                cons.email = "";
                cons.tax_id = "";
                cons.remark = row["ConsigneeAddress5"].ToString();
                cons.contact_name1 = "";

                cons.contact_name2 = "";
                cons.contact_name1_tel = "";
                cons.contact_name2_tel = "";
                cons.status_company = "";
                cons.status_vendor = "";

                cons.date_create = "";
                cons.date_modi = "";
                cons.date_cancel = "";
                cons.user_create = "";
                cons.user_modi = "";

                cons.user_cancel = "";
                cons.remark2 = row["name_address"].ToString();
                cons.po_due_period = "";
                cons.taddr1 = row["ConsigneeAddress1"].ToString();
                cons.taddr2 = row["ConsigneeAddress2"].ToString();

                cons.taddr3 = row["ConsigneeAddress3"].ToString();
                cons.taddr4 = row["ConsigneeAddress4"].ToString();
                cons.eaddr1 = row["country"].ToString();
                cons.eaddr2 = "";
                cons.eaddr3 = "";

                cons.eaddr4 = "";
                cons.status_cons = "1";

                consDB.insertConsignee(cons);
            }
            conn.CloseConnectionNoClose();
            pb1.Hide();
        }
        public void ImportOpenJOBExpConsignee(String pathA, String flagNew, String flag, ProgressBar pb1)
        {
            pb1.Show();
            DataTable dt = new DataTable();
            String sql = "";
            sql = "Select * from ExpConsignee ";
            conn.OpenConnectionA(pathA, flag);
            dt = conn.selectDataA(conn.connA, sql);
            pb1.Minimum = 0;
            pb1.Maximum = dt.Rows.Count;
            pb1.Value = 0;
            conn.OpenConnectionNoClose();
            if (flagNew.Equals("new"))
            {
                consDB.deleteExpConsigneeAll();
            }
            foreach (DataRow row in dt.Rows)
            {
                Consignee cons = new Consignee();
                cons.cons_id = "";
                cons.cons_code = row["ConsigneeID"].ToString();
                cons.cons_name_t = row["ConsigneeName"].ToString();
                cons.cons_name_e = row["ConsigneeName"].ToString();
                cons.active = "1";

                cons.address_t = "";
                cons.address_e = "";
                cons.addr = "";
                cons.amphur_id = "";
                cons.district_id = "";

                cons.province_id = "";
                cons.zipcode = "";
                cons.sale_id = "";
                cons.sale_name_t = "";
                cons.fax = "";

                cons.tele = "";
                cons.email = "";
                cons.tax_id = "";
                cons.remark = "";
                cons.contact_name1 = "";

                cons.contact_name2 = "";
                cons.contact_name1_tel = "";
                cons.contact_name2_tel = "";
                cons.status_company = "";
                cons.status_vendor = "";

                cons.date_create = "";
                cons.date_modi = "";
                cons.date_cancel = "";
                cons.user_create = "";
                cons.user_modi = "";

                cons.user_cancel = "";
                cons.remark2 = "";
                cons.po_due_period = "";
                cons.taddr1 = row["ConsigneeAddress"].ToString();
                cons.taddr2 = row["ConsigneeCity"].ToString();

                cons.taddr3 = row["ConsigneePostalCode"].ToString();
                cons.taddr4 = row["ConsigneeStateOrProvince"].ToString();
                cons.eaddr1 = row["ConsigneeCountry/Region"].ToString();
                cons.eaddr2 = "";
                cons.eaddr3 = "";

                cons.eaddr4 = "";
                cons.status_cons = "2";

                consDB.insertConsignee(cons);
            }
            conn.CloseConnectionNoClose();
            pb1.Hide();
        }
        public void ImportOpenJOBImpSupplier(String pathA, String flagNew, String flag, ProgressBar pb1)
        {
            pb1.Show();
            DataTable dt = new DataTable();
            String sql = "";
            sql = "Select * from ImpSuppliers ";
            conn.OpenConnectionA(pathA, flag);
            dt = conn.selectDataA(conn.connA, sql);
            pb1.Minimum = 0;
            pb1.Maximum = dt.Rows.Count;
            pb1.Value = 0;
            conn.OpenConnectionNoClose();
            if (flagNew.Equals("new"))
            {
                consDB.deleteExpConsigneeAll();
            }
            foreach (DataRow row in dt.Rows)
            {
                Consignee cons = new Consignee();
                cons.cons_id = "";
                cons.cons_code = row["SupplierID"].ToString();
                cons.cons_name_t = row["SupplierName"].ToString();
                cons.cons_name_e = row["SupplierName"].ToString();
                cons.active = "1";

                cons.address_t = "";
                cons.address_e = "";
                cons.addr = "";
                cons.amphur_id = "";
                cons.district_id = "";

                cons.province_id = "";
                cons.zipcode = "";
                cons.sale_id = "";
                cons.sale_name_t = "";
                cons.fax = "";

                cons.tele = "";
                cons.email = "";
                cons.tax_id = "";
                cons.remark = "";
                cons.contact_name1 = "";

                cons.contact_name2 = "";
                cons.contact_name1_tel = "";
                cons.contact_name2_tel = "";
                cons.status_company = "";
                cons.status_vendor = "";

                cons.date_create = "";
                cons.date_modi = "";
                cons.date_cancel = "";
                cons.user_create = "";
                cons.user_modi = "";

                cons.user_cancel = "";
                cons.remark2 = "";
                cons.po_due_period = "";
                cons.taddr1 = row["SupplierAddress"].ToString();
                cons.taddr2 = row["SupplierCity"].ToString();

                cons.taddr3 = row["SupplierPostalCode"].ToString();
                cons.taddr4 = row["SupplierStateOrProvince"].ToString();
                cons.eaddr1 = row["SupplierCountry/Region"].ToString();
                cons.eaddr2 = "";
                cons.eaddr3 = "";

                cons.eaddr4 = "";
                cons.status_cons = "4";

                consDB.insertConsignee(cons);
            }
            conn.CloseConnectionNoClose();
            pb1.Hide();
        }
        public void ImportOpenJOBInsurance(String pathA, String flagNew, String flag, ProgressBar pb1)
        {
            pb1.Show();
            DataTable dt = new DataTable();
            String sql = "";
            sql = "Select * from BrokerInsurance ";
            conn.OpenConnectionA(pathA, flag);
            dt = conn.selectDataA(conn.connA, sql);
            pb1.Minimum = 0;
            pb1.Maximum = dt.Rows.Count;
            pb1.Value = 0;
            conn.OpenConnectionNoClose();
            if (flagNew.Equals("new"))
            {
                insrDB.deleteInsuranceAll();
            }
            foreach (DataRow row in dt.Rows)
            {
                Insurance insr = new Insurance();
                insr.insu_id = "";
                insr.insu_code = row["BrokerID"].ToString();
                insr.insu_name_t = row["BrokerName"].ToString();
                insr.insu_name_e = row["BrokerName"].ToString();
                insr.active = "1";

                insr.address_t = "";
                insr.address_e = "";
                insr.addr = "";
                insr.amphur_id = "";
                insr.district_id = "";

                insr.province_id = "";
                insr.zipcode = "";
                insr.sale_id = "";
                insr.sale_name_t = "";
                insr.fax = row["BrokerFaxNumber"].ToString();

                insr.tele = row["BrokerPhoneNumber"].ToString();
                insr.email = "";
                insr.tax_id = "";
                insr.remark = row["BrokerExtension"].ToString();
                insr.contact_name1 = row["BrokerContacts"].ToString();

                insr.contact_name2 = "";
                insr.contact_name1_tel = "";
                insr.contact_name2_tel = "";
                insr.status_company = "";
                insr.status_vendor = "";

                insr.date_create = "";
                insr.date_modi = "";
                insr.date_cancel = "";
                insr.user_create = "";
                insr.user_modi = "";

                insr.user_cancel = "";
                insr.remark2 = "";
                insr.po_due_period = "";
                insr.taddr1 = row["BrokerAddress"].ToString();
                insr.taddr2 = row["BrokerCity"].ToString();

                insr.taddr3 = row["BrokerStateOrProvince"].ToString();
                insr.taddr4 = row["BrokerPostalCode"].ToString();
                insr.eaddr1 = row["BrokerCountry/Region"].ToString();
                insr.eaddr2 = row["BrokerPhoneNumber"].ToString();
                insr.eaddr3 = row["BrokerExtension"].ToString();

                insr.eaddr4 = "";
                //cons.status_cons = "4";

                insrDB.insertCustomer(insr);
            }
            conn.CloseConnectionNoClose();
            pb1.Hide();
        }
        public void ImportOpenJOBDepartment(String pathA, String flagNew, String flag, ProgressBar pb1)
        {
            pb1.Show();
            DataTable dt = new DataTable();
            String sql = "";
            sql = "Select DepartmentName from Employees Group By DepartmentName";
            conn.OpenConnectionA(pathA, flag);
            dt = conn.selectDataA(conn.connA, sql);
            pb1.Minimum = 0;
            pb1.Maximum = dt.Rows.Count;
            pb1.Value = 0;
            conn.OpenConnectionNoClose();
            if (flagNew.Equals("new"))
            {
                deptDB.deleteAll();
            }
            foreach (DataRow row in dt.Rows)
            {
                Department dept = new Department();
                dept.dept_id = "";
                dept.depart_name_t = row["DepartmentName"].ToString();
                dept.dept_parent_id = "";
                dept.active = "1";
                dept.comp_id = "";

                dept.date_cancel = "";
                dept.date_create = "";
                dept.date_modi = "";
                dept.depart_code = row["DepartmentName"].ToString();
                dept.remark = "";

                dept.user_cancel = "";
                dept.user_create = "";
                dept.user_modi = "";

                deptDB.insertDepartment(dept);
            }
            conn.CloseConnectionNoClose();
            pb1.Hide();
        }
        public void ImportOpenJOBStaff(String pathA, String flagNew, String flag, ProgressBar pb1)
        {
            pb1.Show();
            DataTable dt = new DataTable();
            String sql = "";

            ImportOpenJOBDepartment(pathA, flagNew, flag, pb1);
            deptDB.getlDept();

            sql = "Select * from Employees ";
            conn.OpenConnectionA(pathA, flag);
            dt = conn.selectDataA(conn.connA, sql);
            pb1.Minimum = 0;
            pb1.Maximum = dt.Rows.Count;
            pb1.Value = 0;
            conn.OpenConnectionNoClose();
            if (flagNew.Equals("new"))
            {
                stfDB.deleteAll();
            }
            foreach (DataRow row in dt.Rows)
            {
                Staff stf = new Staff();
                stf.staff_id = "";
                stf.staff_code = "";
                stf.username = "";
                stf.prefix_id = "";
                stf.staff_fname_t = row["FirstName"].ToString();
                stf.staff_fname_e = "";
                stf.staff_lname_t = row["LastName"].ToString();
                stf.staff_lname_e = "";
                stf.password1 = "";
                stf.active = "1";
                stf.remark = "Employees";
                stf.priority = "";
                stf.tele = "";
                stf.mobile = "";
                stf.fax = "";
                stf.email = "";
                stf.posi_id = "";
                stf.posi_name = "";
                stf.date_create = "";
                stf.date_modi = "";
                stf.date_cancel = "";
                stf.user_create = "";
                stf.user_modi = "";
                stf.user_cancel = "";
                stf.pid = "";
                stf.logo = "";
                stf.dept_id = deptDB.getIdByName(row["DepartmentName"].ToString());
                stf.dept_name_t = row["DepartmentName"].ToString();

                stfDB.insertStaff(stf);
            }

            sql = "Select * from CS ";
            dt.Clear();
            dt = conn.selectDataA(conn.connA, sql);
            foreach (DataRow row in dt.Rows)
            {
                Staff stf = new Staff();
                stf.staff_id = "";
                stf.staff_code = row["CsID"].ToString();
                stf.username = "";
                stf.prefix_id = "";
                stf.staff_fname_t = row["CsName"].ToString();
                stf.staff_fname_e = "";
                stf.staff_lname_t = "";
                stf.staff_lname_e = "";
                stf.password1 = "";
                stf.active = "1";
                stf.remark = "CS";
                stf.priority = "";
                stf.tele = "";
                stf.mobile = "";
                stf.fax = "";
                stf.email = "";
                stf.posi_id = "";
                stf.posi_name = "";
                stf.date_create = "";
                stf.date_modi = "";
                stf.date_cancel = "";
                stf.user_create = "";
                stf.user_modi = "";
                stf.user_cancel = "";
                stf.pid = "";
                stf.logo = "";
                stf.dept_id = "";
                stf.dept_name_t = "";

                stfDB.insertStaff(stf);
            }

            conn.CloseConnectionNoClose();
            pb1.Hide();
        }
        public void ImportOpenJOBJobImport(String pathA, String flagNew, String flag, ProgressBar pb1, Form frm)
        {
            pb1.Show();
            DataTable dt = new DataTable();
            String sql = "";

            cusDB.getlCus();

            ImportOpenJOBDepartment(pathA, flagNew, flag, pb1);
            deptDB.getlDept();
            impDB.getlImp();
            stfDB.getlStf();
            ettDB.getlEtt();

            sql = "Select * from ImpJob ";
            conn.OpenConnectionA(pathA, flag);
            dt = conn.selectDataA(conn.connA, sql);
            pb1.Minimum = 0;
            pb1.Maximum = dt.Rows.Count;
            pb1.Value = 0;
            conn.OpenConnectionNoClose();
            if (flagNew.Equals("new"))
            {
                jimDB.deleteAll();
            }
            foreach (DataRow row in dt.Rows)
            {
                DateTime dt1 = new DateTime();
                JobImport jim = new JobImport();
                jim.job_import_id = "";
                jim.job_import_code = "IMP " + row["ImpJobID"].ToString();

                if (row["ImpJobID"].ToString().Equals("29206"))
                {
                    sql = "";
                }

                //DateTime.TryParse(row["ImpJobDate"].ToString(), out dt1);
                jim.job_import_date = DateTime.TryParse(row["ImpJobDate"].ToString(), out dt1) ? dt1.ToString("yyyy-MM-dd hh:MM:ss") : "";

                jim.cust_id = cusDB.getIdByCode(row["CustomerID"].ToString().Trim());
                jim.imp_id = impDB.getIdByCode(row["ImporterID"].ToString().Trim());
                jim.transport_mode = row["TransportMode"].ToString();
                jim.staff_id = stfDB.getIdByCode(row["CsID"].ToString().Trim());
                jim.entry_type = ettDB.getIdByCode(row["EntryType"].ToString());
                jim.privi_id = pvlDB.getIdByDesc(row["Pivilege"].ToString());
                jim.ref_1 = row["CustomerRef"].ToString();
                jim.ref_2 = "";
                jim.ref_3 = "";
                jim.ref_4 = "";
                jim.ref_5 = "";
                jim.ref_edi = row["EdiRef"].ToString();
                jim.imp_entry = row["ImpEntry"].ToString();
                jim.edi_response = row["EdiResponse"].ToString();
                jim.tax_method_id = row["วีธีชำระภาษี"].ToString();
                jim.check_exam_id = row["การตรวจปล่อย"].ToString();


                if (DateTime.TryParse(row["วันจ้งยอด"].ToString(), out dt1))
                {
                    if (dt1.Year > 2100)
                    {
                        dt1 = dt1.AddYears(-543);
                        jim.inv_date = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                    else
                    {
                        jim.inv_date = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                }
                else
                {
                    jim.inv_date = "";
                }

                jim.tax_amt = row["ยอดภาษีที่แจ้ง"].ToString();
                jim.insr_date = DateTime.TryParse(row["InsuranceDate"].ToString(), out dt1) ? dt1.ToString("yyyy-MM-dd hh:MM:ss") : "";
                jim.insr_id = row["BrokerID"].ToString();
                jim.policy_no = row["PolicyNo"].ToString();
                jim.premium = row["Premium"].ToString();
                jim.policy_date = DateTime.TryParse(row["PolicyDate"].ToString(), out dt1) ? dt1.ToString("yyyy-MM-dd hh:MM:ss") : "";
                jim.policy_clause = row["PolicyClause"].ToString().Trim();
                jim.job_year = DateTime.TryParse(row["ImpJobDate"].ToString(), out dt1) ? dt1.ToString("yyyy") : "";
                jim.date_create = "";
                jim.date_modi = "";
                jim.date_cancel = "";
                jim.user_create = "";
                jim.user_modi = "";
                jim.user_cancel = "";
                jim.active = "1";
                //jim.remark = DateTime.TryParse(row["ImpJobRemark"].ToString(), out dt1) ? dt1.ToString("yyyy") : "";
                jim.remark = row["ImpJobRemark"].ToString().Trim();
                jim.remark1 = "";
                jim.remark2 = "";
                jimDB.insertJobImport(jim);

                pb1.Value++;
                if ((pb1.Value % 100) == 0)
                {
                    frm.Refresh();
                }
            }
            conn.CloseConnectionNoClose();
            pb1.Hide();
        }
        public void ImportOpenJOBTermail(String pathA, String flagNew, String flag, ProgressBar pb1, Form frm)
        {
            pb1.Show();
            DataTable dt = new DataTable();
            String sql = "";
            sql = "Select * from terminal ";
            conn.OpenConnectionA(pathA, flag);
            dt = conn.selectDataA(conn.connA, sql);
            pb1.Minimum = 0;
            pb1.Maximum = dt.Rows.Count;
            pb1.Value = 0;
            conn.OpenConnectionNoClose();
            if (flagNew.Equals("new"))
            {
                tmnDB.deleteAll();
            }
            foreach (DataRow row in dt.Rows)
            {
                Terminal tmn = new Terminal();
                tmn = new Terminal();
                tmn.terminal_id = "";
                tmn.terminal_code = row["TerminalID"].ToString().Trim();
                tmn.terminal_name_e = row["TerminalName"].ToString().Trim();
                tmn.terminal_name_t = row["TerminalName"].ToString().Trim();
                //tmn.status_app = "status_app";
                tmn.sort1 = "";

                tmn.active = "1";
                tmn.date_create = "";
                tmn.date_modi = "";
                tmn.date_cancel = "";
                tmn.user_create = "";
                tmn.user_modi = "";
                tmn.user_cancel = "";
                //tmn.status_app = "status_app";
                tmn.remark = "";

                tmnDB.insertPortImprt(tmn);
            }
            conn.CloseConnectionNoClose();
            pb1.Hide();
        }
        public void ImportOpenJOBPortOfLoading(String pathA, String flagNew, String flag, ProgressBar pb1, Form frm)
        {
            pb1.Show();
            DataTable dt = new DataTable();
            String sql = "";
            sql = "Select * from Port_of_Loading ";
            conn.OpenConnectionA(pathA, flag);
            dt = conn.selectDataA(conn.connA, sql);
            pb1.Minimum = 0;
            pb1.Maximum = dt.Rows.Count;
            pb1.Value = 0;
            conn.OpenConnectionNoClose();
            if (flagNew.Equals("new"))
            {
                polDB.deleteAll();
            }
            foreach (DataRow row in dt.Rows)
            {
                PortOfLoading pol = new PortOfLoading();
                //pol = new new();
                pol.port_of_loading_id = "";
                pol.port_of_loading_code = row["PortOfLodingID"].ToString().Trim();
                pol.port_of_loading_e = row["PortOfLodingID"].ToString().Trim();
                pol.port_of_loading_t = row["PortOfLodingID"].ToString().Trim();
                pol.remark = row["PortCountry"].ToString().Trim();
                //tmn.status_app = "status_app";
                pol.sort1 = "";

                pol.active = "1";
                pol.date_create = "";
                pol.date_modi = "";
                pol.date_cancel = "";
                pol.user_create = "";
                pol.user_modi = "";
                pol.user_cancel = "";
                //tmn.status_app = "status_app";
                pol.remark = "";

                polDB.insertPortImprt(pol);
            }
            conn.CloseConnectionNoClose();
            pb1.Hide();
        }
        public void ImportOpenJOBForwarder(String pathA, String flagNew, String flag, ProgressBar pb1, Form frm)
        {
            pb1.Show();
            DataTable dt = new DataTable();
            String sql = "";
            sql = "Select * From impforwarder ";
            conn.OpenConnectionA(pathA, flag);
            if (flagNew.Equals("new"))
            {
                fwdDB.deleteAll();
            }
            dt.Clear();
            dt = conn.selectDataA(conn.connA, sql);
            foreach (DataRow row in dt.Rows)
            {
                //pb1.Value++;
                Forwarder fwd = new Forwarder();
                fwd.forwarder_id = "";
                fwd.forwarder_code = row["ImpForwarderID"].ToString();
                fwd.forwarder_name_t = row["ImpForwarderName"].ToString();
                fwd.forwarder_name_e = row["ImpForwarderName"].ToString();
                fwd.active = "1";

                fwd.address_t = "";
                fwd.address_e = "";
                fwd.addr = "";
                fwd.amphur_id = "";
                fwd.district_id = "";

                fwd.province_id = "";
                fwd.zipcode = "";
                fwd.sale_id = "";
                fwd.sale_name_t = "";
                fwd.fax = row["ImpForwarderFax"].ToString();

                fwd.tele = row["ImpForwarderTel"].ToString();
                fwd.email = "";
                fwd.tax_id = "";
                fwd.remark = "";
                fwd.contact_name1 = row["ImpForwarderContact1"].ToString();

                fwd.contact_name2 = row["ImpForwarderContact2"].ToString();
                fwd.contact_name3 = row["ImpForwarderContact3"].ToString();
                fwd.contact_name4 = row["ImpForwarderContact1Airport"].ToString();
                fwd.contact_name5 = row["ImpForwarderContact2Airport"].ToString();
                fwd.contact_name6 = row["ImpForwarderContact3Airport"].ToString();
                fwd.contact_name1_tel = "";
                fwd.contact_name2_tel = "";
                fwd.status_company = "forwarder";
                fwd.status_vendor = "xtrim";

                fwd.date_create = "";
                fwd.date_modi = "";
                fwd.date_cancel = "";
                fwd.user_create = "";
                fwd.user_modi = "";

                fwd.user_cancel = "";
                fwd.remark2 = "";
                fwd.po_due_period = "";

                fwd.taddr1 = row["ImpForwarderAddress"].ToString();
                fwd.taddr2 = row["ImpForwarderCity"].ToString();
                fwd.taddr3 = row["ImpForwarderTel"].ToString();
                fwd.taddr4 = row["ImpForwarderFax"].ToString();

                fwd.eaddr1 = row["ImpForwarderAddressAirport"].ToString();
                fwd.eaddr2 = row["ImpForwarderCityAirport"].ToString();
                fwd.eaddr3 = row["ImpForwarderTelAirport"].ToString();
                fwd.eaddr4 = row["ImpForwarderFaxAirport"].ToString();

                fwd.remark3 = "";
                fwd.payerorg = "";
                fwd.payerprofile = "";
                fwd.payeruser = "";

                fwdDB.insertForwarder(fwd);
            }
            conn.CloseConnectionNoClose();
            pb1.Hide();
        }
        public void ImportOpenJOBJobImportBl(String pathA, String flagNew, String flag, ProgressBar pb1, Form frm)
        {
            pb1.Show();
            DataTable dt = new DataTable();
            String sql = "";

            jimDB.getlJim();
            fwdDB.getlFwd();
            ugwDB.getlUgw();
            ptiDB.getlPti();
            tmnDB.getlPol();
            utpDB.getlPol();

            sql = "Select * From impbldetail ";
            conn.OpenConnectionA(pathA, flag);
            if (flagNew.Equals("new"))
            {
                jblDB.deleteAll();
            }
            dt.Clear();
            dt = conn.selectDataA(conn.connA, sql);
            foreach (DataRow row in dt.Rows)
            {
                DateTime dt1 = new DateTime();
                //pb1.Value++;
                JobImportBl jbl = new JobImportBl();
                jbl.job_import_bl_id = "";
                jbl.job_import_id = jimDB.getIdByCode1(row["ImpJobID"].ToString().Trim());
                jbl.forwarder_id = fwdDB.getIdByCode(row["ImpForwarderID"].ToString().Trim());
                jbl.mbl_mawb = row["MBL/MAWB"].ToString();
                jbl.hbl_hawb = row["HBL/HAWB"].ToString();
                jbl.m_vessel = row["MVessel"].ToString();
                jbl.f_vessel = row["FVessel"].ToString();
                if (DateTime.TryParse(row["ETD"].ToString(), out dt1))
                {
                    if (dt1.Year > 2100)
                    {
                        dt1 = dt1.AddYears(-543);
                        jbl.etd = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                    else if (dt1.Year < 1500)
                    {
                        dt1 = dt1.AddYears(543);
                        jbl.etd = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                    else
                    {
                        jbl.etd = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                }
                else
                {
                    jbl.etd = "";
                }
                //jbl.etd = DateTime.TryParse(row["ETD"].ToString(), out dt1) ? dt1.ToString("yyyy-MM-dd hh:MM:ss") : "";
                if (DateTime.TryParse(row["ETA"].ToString(), out dt1))
                {
                    if (dt1.Year > 2100)
                    {
                        dt1 = dt1.AddYears(-543);
                        jbl.eta = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                    else if (dt1.Year < 1500)
                    {
                        dt1 = dt1.AddYears(543);
                        jbl.eta = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                    else
                    {
                        jbl.eta = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                }
                else
                {
                    jbl.eta = "";
                }
                //jbl.eta = DateTime.TryParse(row["ETA"].ToString(), out dt1) ? dt1.ToString("yyyy-MM-dd hh:MM:ss") : "";
                jbl.port_imp_id = ptiDB.getIdByCode(row["รหัสท่านำเข้า"].ToString().Trim());

                jbl.terminal_id = tmnDB.getIdByCode(row["TerminalID"].ToString().Trim());
                jbl.marsk = row["Marsk"].ToString();
                jbl.description = row["Description"].ToString();
                jbl.gw = row["GW"].ToString();
                jbl.gw_unit_id = ugwDB.getIdByCode(row["GWUnitID"].ToString().Trim());
                jbl.total_packages = row["TotalPackages"].ToString();
                jbl.unit_package_id = utpDB.getIdByName(row["PackagesUnitID"].ToString().Trim());
                jbl.total_con20 = row["TotalCon20'"].ToString();
                jbl.total_con40 = row["TotalCon40'"].ToString();
                jbl.volume1 = row["Volume"].ToString();

                jbl.port_of_loding_id = polDB.getIdByName(row["PortOfLodingID"].ToString().Trim());
                if (DateTime.TryParse(row["วันตรวจปล่อย"].ToString(), out dt1))
                {
                    if (dt1.Year > 2100)
                    {
                        dt1 = dt1.AddYears(-543);
                        jbl.date_check_exam = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                    else if (dt1.Year < 1500)
                    {
                        dt1 = dt1.AddYears(543);
                        jbl.date_check_exam = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                    else
                    {
                        jbl.date_check_exam = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                }
                else
                {
                    jbl.date_check_exam = "";
                }
                //jbl.date_check_exam = DateTime.TryParse(row["วันตรวจปล่อย"].ToString(), out dt1) ? dt1.ToString("yyyy-MM-dd hh:MM:ss") : "";
                if (DateTime.TryParse(row["DeliveryDate"].ToString(), out dt1))
                {
                    if (dt1.Year > 2100)
                    {
                        dt1 = dt1.AddYears(-543);
                        jbl.date_delivery = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                    else if (dt1.Year < 1500)
                    {
                        dt1 = dt1.AddYears(543);
                        jbl.date_delivery = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                    else
                    {
                        jbl.date_delivery = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                }
                else
                {
                    jbl.date_delivery = "";
                }
                //jbl.date_delivery = DateTime.TryParse(row["DeliveryDate"].ToString(), out dt1) ? dt1.ToString("yyyy-MM-dd hh:MM:ss") : "";
                if (DateTime.TryParse(row["ToFacDate"].ToString(), out dt1))
                {
                    if (dt1.Year > 2100)
                    {
                        dt1 = dt1.AddYears(-543);
                        jbl.date_tofac = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                    else if (dt1.Year < 1500)
                    {
                        dt1 = dt1.AddYears(543);
                        jbl.date_tofac = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                    else
                    {
                        jbl.date_tofac = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                }
                else
                {
                    jbl.date_tofac = "";
                }
                //jbl.date_tofac = DateTime.TryParse(row["ToFacDate"].ToString(), out dt1) ? dt1.ToString("yyyy-MM-dd hh:MM:ss") : "";
                jbl.truck_id = row["TruckID"].ToString();
                jbl.car_number = row["จำนวนรถ"].ToString();
                jbl.tranfer_with_job_id = row["ส่งสินค้าไปพร้อมกับ JOB NO"].ToString();
                jbl.truck_cop_id = row["TruckCompanyID"].ToString();
                jbl.status_doc_forrow = row["มีเอกสารต้องตามต่อ"].ToString().Equals("false") ? "0" : "1";
                jbl.doc_forrow = row["ชนิดเอกสาร"].ToString();

                if (DateTime.TryParse(row["วันส่งเอกสารให้ลูกค้า"].ToString(), out dt1))
                {
                    if (dt1.Year > 2100)
                    {
                        dt1 = dt1.AddYears(-543);
                        jbl.date_doc_forrow = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                    else if (dt1.Year < 1500)
                    {
                        dt1 = dt1.AddYears(543);
                        jbl.date_doc_forrow = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                    else
                    {
                        jbl.date_doc_forrow = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                }
                else
                {
                    jbl.date_doc_forrow = "";
                }
                //jbl.date_doc_forrow = DateTime.TryParse(row["วันส่งเอกสารให้ลูกค้า"].ToString(), out dt1) ? dt1.ToString("yyyy-MM-dd hh:MM:ss") : "";
                jbl.status_job_forrow = row["มีงานต้องตามต่อ"].ToString().Equals("false") ? "0" : "1";
                jbl.job_forrow_description = row["ชนิดงานตาม"].ToString();
                if (DateTime.TryParse(row["วันเสร็จงานตาม"].ToString(), out dt1))
                {
                    if (dt1.Year > 2100)
                    {
                        dt1 = dt1.AddYears(-543);
                        jbl.date_finish_job_forrow = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                    else if (dt1.Year < 1500)
                    {
                        dt1 = dt1.AddYears(543);
                        jbl.date_finish_job_forrow = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                    else
                    {
                        jbl.date_finish_job_forrow = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                }
                else
                {
                    jbl.date_finish_job_forrow = "";
                }
                //jbl.date_finish_job_forrow = DateTime.TryParse(row["วันเสร็จงานตาม"].ToString(), out dt1) ? dt1.ToString("yyyy-MM-dd hh:MM:ss") : "";
                jbl.status_oth_job = row["เปิด OTH JOB เพื่อตามงานต่อ"].ToString().Equals("false") ? "0" : "1";
                jbl.delivery_remark = row["DeliveryRemarks"].ToString();
                jbl.container_yard = row["ContainerYard"].ToString();
                jbl.oth_job_no = row["oth job no"].ToString();
                jbl.date_create = "";
                jbl.date_modi = "";
                jbl.date_cancel = "";

                jbl.user_create = "";
                jbl.user_modi = "";
                jbl.user_cancel = "";
                jbl.active = "1";
                jbl.remark = "";

                jblDB.insertJobImportBl(jbl);
            }
            conn.CloseConnectionNoClose();
            pb1.Hide();
        }
        public void ImportOpenJOBJobImportInv(String pathA, String flagNew, String flag, ProgressBar pb1, Form frm)
        {
            pb1.Show();
            DataTable dt = new DataTable();
            String sql = "";
            jimDB.getlJim();
            consDB.getlSupp();
            currDB.getlCurr();
            ictDB.getlIct();
            tpmDB.getlTpm();
            sql = "Select * From impinv ";
            conn.OpenConnectionA(pathA, flag);
            if (flagNew.Equals("new"))
            {
                jblDB.deleteAll();
            }
            dt.Clear();
            dt = conn.selectDataA(conn.connA, sql);
            foreach (DataRow row in dt.Rows)
            {
                DateTime dt1 = new DateTime();
                //pb1.Value++;
                JobImportInv jin = new JobImportInv();
                jin.job_import_inv_id = "";
                jin.job_import_id = jimDB.getIdByCode1(row["ImpJobID"].ToString());
                if (DateTime.TryParse(row["ImpInvDate"].ToString(), out dt1))
                {
                    if (dt1.Year > 2100)
                    {
                        dt1 = dt1.AddYears(-543);
                        jin.invoice_date = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                    else if (dt1.Year < 1500)
                    {
                        dt1 = dt1.AddYears(543);
                        jin.invoice_date = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                    else
                    {
                        jin.invoice_date = dt1.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                }
                else
                {
                    jin.invoice_date = "";
                }
                //jin.invoice_date = row["ImpInvDate"].ToString();
                jin.inv_no = row["ImpInvNo"].ToString();
                jin.cons_id = consDB.getSuppIdByCode(row["SupplierID"].ToString());
                jin.inco_teams_id = ictDB.getIdByCode(row["IncoTermsID"].ToString());
                jin.term_pay_id = tpmDB.getIdByCode(row["TermPaymentID"].ToString());
                jin.amount = row["TotalAmt"].ToString();
                jin.curr_id = currDB.getIdByCode(row["CurrencyID"].ToString());
                jin.date_create = "";
                jin.date_modi = "";
                jin.date_cancel = "";
                jin.user_create = "";
                jin.user_modi = "";
                jin.user_cancel = "";
                jin.remark = "";
                jin.active = "1";

                jinDB.insertJobImportInv(jin);
            }
            conn.CloseConnectionNoClose();
            pb1.Hide();
        }
    }
}
