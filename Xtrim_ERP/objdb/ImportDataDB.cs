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
        }
        public void ImportMEIOSYSimport(String flagNew, ProgressBar pb1)
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
        public void ImportOpenJOBcustomer(String pathA,String flagNew, String flag, ProgressBar pb1)
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
    }
}
