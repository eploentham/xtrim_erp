﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class Company:Peinvistent
    {
        public String comp_id { get; set; }
        public String comp_code { get; set; }
        public String comp_name_t { get; set; }
        public String comp_name_e { get; set; }
        public String comp_address_e { get; set; }
        public String comp_address_t { get; set; }
        public String addr1 { get; set; }
        public String addr2 { get; set; }
        public String amphur_id { get; set; }
        public String district_id { get; set; }
        public String province_id { get; set; }
        public String zipcode { get; set; }
        public String tele { get; set; }
        public String fax { get; set; }
        public String email { get; set; }
        public String website { get; set; }
        public String logo { get; set; }
        public String tax_id { get; set; }
        public String vat { get; set; }
        public String spec1 { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String qu_line1 { get; set; }
        public String qu_line2 { get; set; }
        public String qu_line3 { get; set; }
        public String qu_line4 { get; set; }
        public String qu_line5 { get; set; }
        public String qu_line6 { get; set; }
        public String inv_line1 { get; set; }
        public String inv_line2 { get; set; }
        public String inv_line3 { get; set; }
        public String inv_line4 { get; set; }
        public String inv_line5 { get; set; }
        public String inv_line6 { get; set; }
        public String po_line1 { get; set; }
        public String po_due_period { get; set; }
    }
}