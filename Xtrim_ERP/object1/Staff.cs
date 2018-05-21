﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class Staff:Persistent
    {
        public String staff_id { get; set; }
        public String staff_code { get; set; }
        public String username { get; set; }
        public String prefix_id { get; set; }
        public String staff_fname_t { get; set; }
        public String staff_fname_e { get; set; }
        public String staff_lname_t { get; set; }
        public String staff_lname_e { get; set; }
        public String password1 { get; set; }
        public String priority { get; set; }
        public String tele { get; set; }
        public String mobile { get; set; }
        public String fax { get; set; }
        public String email { get; set; }
        public String posi_id { get; set; }
        public String posi_name { get; set; }
        public String pid { get; set; }
        public String logo { get; set; }
        public String dept_id { get; set; }
        public String dept_name { get; set; }
        public String prefix_name_t { get; set; }
        public String posi_name_t { get; set; }
        public String dept_name_t { get; set; }

        public String status_admin { get; set; }
        public String status_module_imp_job { get; set; }
        public String status_module_exp_job { get; set; }
        public String status_module_other_job { get; set; }
    }
}
