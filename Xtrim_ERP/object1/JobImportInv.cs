using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class JobImportInv:Persistent
    {
        public String job_import_inv_id { get; set; }
        public String job_import_id { get; set; }
        public String invoice_date { get; set; }
        //public String t_job_import_invcol { get; set; }
        public String cons_id { get; set; }
        public String inco_terms_id { get; set; }
        public String term_pay_id { get; set; }
        public String amount { get; set; }
        public String curr_id { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String remark { get; set; }
        public String active { get; set; }
        public String inv_no { get; set; }

        public String suppCode { get; set; }
        public String SuppNameT { get; set; }
        public String ictCode { get; set; }
        public String ictNameT { get; set; }
        public String currCode { get; set; }
        public String currNameT { get; set; }
        public String tpmCode { get; set; }
        public String tpmNameT { get; set; }
    }
}
