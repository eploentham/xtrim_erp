using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class CompanyDB
    {
        public Company cop;
        ConnectDB conn;
        public CompanyDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            cop = new Company();
            cop.comp_id = "comp_id";
            cop.comp_code = "comp_code";
            cop.comp_name_t = "comp_name_t";
            cop.comp_name_e = "comp_name_e";
            cop.comp_address_e = "comp_address_e";
            cop.comp_address_t = "comp_address_t";
            cop.addr1 = "addr1";
            cop.addr2 = "addr2";
            cop.amphur_id = "amphur_id";
            cop.district_id = "district_id";
            cop.province_id = "province_id";
            cop.zipcode = "zipcode";
            cop.tele = "tele";
            cop.fax = "fax";
            cop.email = "email";
            cop.website = "website";
            cop.logo = "logo";
            cop.tax_id = "tax_id";
            cop.vat = "vat";
            cop.spec1 = "spec1";
            cop.date_create = "date_create";
            cop.date_modi = "date_modi";
            cop.date_cancel = "date_cancel";
            cop.user_create = "user_create";
            cop.user_modi = "user_modi";
            cop.user_cancel = "user_cancel";
            cop.qu_line1 = "qu_line1";
            cop.qu_line2 = "qu_line2";
            cop.qu_line3 = "qu_line3";
            cop.qu_line4 = "qu_line4";
            cop.qu_line5 = "qu_line5";
            cop.qu_line6 = "qu_line6";
            cop.inv_line1 = "inv_line1";
            cop.inv_line2 = "inv_line2";
            cop.inv_line3 = "inv_line3";
            cop.inv_line4 = "inv_line4";
            cop.inv_line5 = "inv_line5";
            cop.inv_line6 = "inv_line6";
            cop.po_line1 = "po_line1";
            cop.po_due_period = "";
    }
    }
}
