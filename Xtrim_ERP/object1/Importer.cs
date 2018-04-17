using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class Importer:Persistent
    {
        public String imp_id { get; set; }
        public String cust_id { get; set; }
        public String imp_code { get; set; }
        public String imp_name_t { get; set; }
        public String imp_name_e { get; set; }
        public String active { get; set; }
        public String address_t { get; set; }
        public String address_e { get; set; }
        public String addr { get; set; }
        public String amphur_id { get; set; }
        public String district_id { get; set; }
        public String province_id { get; set; }
        public String zipcode { get; set; }
        public String sale_id { get; set; }
        public String sale_name_t { get; set; }
        public String fax { get; set; }
        public String tele { get; set; }
        public String email { get; set; }
        public String tax_id { get; set; }
        public String remark { get; set; }
        public String contact_name1 { get; set; }
        public String contact_name2 { get; set; }
        public String contact_name1_tel { get; set; }
        public String contact_name2_tel { get; set; }
        public String status_company { get; set; }
        public String status_vendor { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String remark2 { get; set; }
        public String po_due_period { get; set; }
        public String taddr1 { get; set; }
        public String taddr2 { get; set; }
        public String taddr3 { get; set; }
        public String taddr4 { get; set; }
        public String eaddr1 { get; set; }
        public String eaddr2 { get; set; }
        public String eaddr3 { get; set; }
        public String eaddr4 { get; set; }
    }
}
