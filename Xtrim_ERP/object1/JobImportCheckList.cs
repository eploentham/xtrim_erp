using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class JobImportCheckList:Persistent
    {
        public String import_check_list_id { get; set; }
        public String job_import_id { get; set; }
        public String status_original { get; set; }
        public String check_list_date { get; set; }
        public String type_of_bl { get; set; }
        public String email_do { get; set; }
        public String privi1_id { get; set; }
        public String privi2_id { get; set; }
        public String privi1_date { get; set; }
        public String privi2_date { get; set; }
        public String privi1_desc { get; set; }
        public String privi2_desc { get; set; }
        public String doc_authen1_id { get; set; }
        public String doc_authen2_id { get; set; }
        public String doc_authen3_id { get; set; }
        public String doc_authen1_date { get; set; }
        public String doc_authen2_date { get; set; }
        public String doc_authen3_date { get; set; }
        public String enter_bl { get; set; }
        public String insurance_atten { get; set; }
        public String email_do1 { get; set; }
        public String email_do1_date { get; set; }
        public String do_date_send { get; set; }
        public String date_date_receive { get; set; }
        public String date_tax_send { get; set; }
        public String date_tax_receive { get; set; }
        public String exp1_date_send { get; set; }
        public String exp1_date_receive { get; set; }
        public String exp2_date_send { get; set; }
        public String exp2_date_receive { get; set; }
        public String receipt_date { get; set; }
        public String receipt_copy_date { get; set; }
        public String accept_tender { get; set; }
        public String advance_billing { get; set; }
        public String approve_date { get; set; }
        public String parent1 { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String remark { get; set; }
        public String active { get; set; }
    }
}
