﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class TaxDetail:Persistent
    {
        public String tax_detail_id { get; set; }
        public String tax_id { get; set; }
        public String item_id { get; set; }
        public String b_tax_id { get; set; }
        public String b_tax_name_t { get; set; }
        public String item_name_t { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String rate1 { get; set; }
        public String tax_date { get; set; }
        public String amount { get; set; }
        public String tax_amount { get; set; }
    }
}