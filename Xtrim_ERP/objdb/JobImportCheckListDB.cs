using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class JobImportCheckListDB
    {
        public JobImportCheckList jcl;
        ConnectDB conn;

        public JobImportCheckListDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jcl = new JobImportCheckList();
            jcl.import_check_list_id = "import_check_list_id";
            jcl.job_import_id = "job_import_id";
            jcl.status_original = "status_original";
            jcl.check_list_date = "check_list_date";
            jcl.type_of_bl = "type_of_bl";
            jcl.email_do = "email_do";
            jcl.privi1_id = "privi1_id";
            jcl.privi2_id = "privi2_id";
            jcl.privi1_date = "privi1_date";
            jcl.privi2_date = "privi2_date";
            jcl.privi1_desc = "privi1_desc";
            jcl.privi2_desc = "privi2_desc";
            jcl.doc_authen1_id = "doc_authen1_id";
            jcl.doc_authen2_id = "doc_authen2_id";
            jcl.doc_authen3_id = "doc_authen3_id";
            jcl.doc_authen1_date = "doc_authen1_date";
            jcl.doc_authen2_date = "doc_authen2_date";
            jcl.doc_authen3_date = "doc_authen3_date";
            jcl.enter_bl = "enter_bl";
            jcl.insurance_atten = "insurance_atten";
            jcl.email_do1 = "email_do1";
            jcl.email_do1_date = "email_do1_date";
            jcl.do_date_send = "do_date_send";
            jcl.date_date_receive = "date_date_receive";
            jcl.date_tax_send = "date_tax_send";
            jcl.date_tax_receive = "date_tax_receive";
            jcl.exp1_date_send = "exp1_date_send";
            jcl.exp1_date_receive = "exp1_date_receive";
            jcl.exp2_date_send = "exp2_date_send";
            jcl.exp2_date_receive = "exp2_date_receive";
            jcl.receipt_date = "receipt_date";
            jcl.receipt_copy_date = "receipt_copy_date";
            jcl.accept_tender = "accept_tender";
            jcl.advance_billing = "advance_billing";
            jcl.approve_date = "approve_date";
            jcl.parent1 = "parent1";
            jcl.date_create = "date_create";
            jcl.date_modi = "date_modi";
            jcl.date_cancel = "date_cancel";
            jcl.user_create = "user_create";
            jcl.user_modi = "user_modi";
            jcl.user_cancel = "user_cancel";
            jcl.remark = "remark";
            jcl.active = "active";

            jcl.table = "t_job_import_check_list";
            jcl.pkField = "import_check_list_id";
        }
        private void chkNull(JobImportCheckList p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;

            //p.amphur_id = int.TryParse(p.amphur_id, out chk) ? chk.ToString() : "0";
        }
    }
}
