﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class JobImport:Persistent
    {
        public String job_import_id { get; set; }
        public String job_import_code { get; set; }
        public String job_import_date { get; set; }
        public String cust_id { get; set; }
        public String imp_id { get; set; }
        public String transport_mode { get; set; }
        public String staff_id { get; set; }
        public String entry_type_id { get; set; }
        public String privi_id { get; set; }
        public String ref_1 { get; set; }
        public String ref_2 { get; set; }
        public String ref_3 { get; set; }
        public String ref_4 { get; set; }
        public String ref_5 { get; set; }
        public String ref_edi { get; set; }
        public String imp_entry { get; set; }
        public String edi_response { get; set; }
        public String tax_method_id { get; set; }
        public String check_exam_id { get; set; }
        public String inv_date { get; set; }
        public String tax_amt { get; set; }
        public String insr_date { get; set; }
        public String insr_id { get; set; }
        public String policy_no { get; set; }
        public String premium { get; set; }
        public String policy_date { get; set; }
        public String policy_clause { get; set; }
        public String job_year { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String active { get; set; }
        public String remark3 { get; set; }
        public String remark1 { get; set; }
        public String remark2 { get; set; }
        public String remark4 { get; set; }
        public String remark5 { get; set; }
        public String remark6 { get; set; }
        public String marsk1 { get; set; }
        public String marsk2 { get; set; }
        public String marsk3 { get; set; }
        public String marsk4 { get; set; }
        public String marsk5 { get; set; }
        public String marsk6 { get; set; }


        public String cusAddr { get; set; }
        public String impAddr { get; set; }
        public String cusNameT { get; set; }
        public String impNameT { get; set; }
        public String cusCode { get; set; }
        public String impCode { get; set; }

        public String fwdCode { get; set; }
        public String fwdNameT { get; set; }

        public String ettCode { get; set; }
        public String ettNameT { get; set; }

        public String pvlCode { get; set; }
        public String pvlNameT { get; set; }

        public String jobno { get; set; }
        public String job_date { get; set; }

        public String imp_date { get; set; }
        public String bl { get; set; }

        public String container_yard1_id { get; set; }
        public String container_yard2_id { get; set; }
        public String container_yard3_id { get; set; }
        public String container_yard4_id { get; set; }
        public String container_yard5_id { get; set; }
        public String container_yard1_addr { get; set; }
        public String container_yard2_addr { get; set; }
        public String container_yard3_addr { get; set; }
        public String container_yard4_addr { get; set; }
        public String container_yard5_addr { get; set; }
        public String time_open_close1 { get; set; }
        public String time_open_close2 { get; set; }
        public String time_open_close3 { get; set; }
        public String time_open_close4 { get; set; }
        public String time_open_close5 { get; set; }
        public String time_open_close_over_time1 { get; set; }
        public String time_open_close_over_time2 { get; set; }
        public String time_open_close_over_time3 { get; set; }
        public String time_open_close_over_time4 { get; set; }
        public String time_open_close_over_time5 { get; set; }
        public String status_container_yard1_tax { get; set; }
        public String status_container_yard2_tax { get; set; }
        public String status_container_yard3_tax { get; set; }
        public String status_container_yard4_tax { get; set; }
        public String status_container_yard5_tax { get; set; }
    }
}
