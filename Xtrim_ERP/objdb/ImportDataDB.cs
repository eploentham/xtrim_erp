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

        public ImportDataDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            impDB = new ImporterDB(conn);
            cusDB = new CustomerDB(conn);
        }
        public void ImportMEIOSYSimport(ProgressBar pb1)
        {
            DataTable dt = new DataTable();
            String sql = "";
            sql = "Select * From importer ";
            dt = conn.selectData(conn.connIm, sql);
            pb1.Minimum = 0;
            pb1.Maximum = dt.Rows.Count;
            pb1.Value = 0;
            conn.OpenConnectionNoClose();
            foreach(DataRow row in dt.Rows)
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
                imp.status_company = "";
                imp.status_vendor = "";

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
            conn.CloseConnectionNoClose();
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
        public void ImportOpenJOBcustomer(String pathA, ProgressBar pb1)
        {
            DataTable dt = new DataTable();
            String sql = "";
            sql = "Select * from Customers ";
            conn.OpenConnectionA(pathA);
            dt = conn.selectDataA(conn.connA, sql);
            pb1.Minimum = 0;
            pb1.Maximum = dt.Rows.Count;
            pb1.Value = 0;
            conn.OpenConnectionNoClose();
            foreach (DataRow row in dt.Rows)
            {
                Customer cus = new Customer();
                cus.cust_id = "";
                cus.cust_code = row["CustomerID"].ToString();
                cus.cust_name_t = row["CustomerName"].ToString();
                cus.cust_name_e = row["CustomerName"].ToString();
                cus.active = "1";

                cus.address_t = row["CustomerAddress"].ToString();
                cus.address_e = row["CustomerAddress"].ToString();
                cus.addr = row["CustomerAddress"].ToString();
                cus.amphur_id = "";
                cus.district_id = "";

                cus.province_id = "";
                cus.zipcode = "zipcode";
                cus.sale_id = "sale_id";
                cus.sale_name_t = "sale_name_t";
                cus.fax = row["CustomerFaxNumber"].ToString();

                cus.tele = "tele";
                cus.email = "email";
                cus.tax_id = "tax_id";
                cus.remark = row["CustomerExtension"].ToString();
                cus.contact_name1 = "contact_name1";

                cus.contact_name2 = "contact_name2";
                cus.contact_name1_tel = "contact_name1_tel";
                cus.contact_name2_tel = "contact_name2_tel";
                cus.status_company = "status_company";
                cus.status_vendor = "status_vendor";

                cus.date_create = "date_create";
                cus.date_modi = "date_modi";
                cus.date_cancel = "date_cancel";
                cus.user_create = "user_create";
                cus.user_modi = "user_modi";

                cus.user_cancel = "user_cancel";
                cus.remark2 = row["CustomerPhoneNumber"].ToString();
                cus.po_due_period = "po_due_period";
                cus.taddr1 = row["CustomerAddress"].ToString();
                cus.taddr2 = row["CustomerCity"].ToString();

                cus.taddr3 = row["CustomerStateOrProvince"].ToString();
                cus.taddr4 = row["CustomerPostalCode"].ToString();
                cus.eaddr1 = row["CustomerStateOrProvince"].ToString();
                cus.eaddr2 = row["CustomerPostalCode"].ToString();
                cus.eaddr3 = row["CustomerCountry/Region"].ToString();

                cus.eaddr4 = row["CustomerPhoneNumber"].ToString();

                cusDB.insertCustomer(cus);
            }
            conn.CloseConnectionNoClose();
        }
    }
}
