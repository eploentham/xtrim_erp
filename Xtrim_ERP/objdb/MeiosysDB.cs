using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class MeiosysDB
    {
        ConnectDB conn;
        String year = "";
        public MeiosysDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {

        }
        public DataTable selectJobNoImport()
        {
            year = DateTime.Now.Year.ToString();
            DataTable dt = new DataTable();
            String sql = "";
            sql = "select job.jobno, job.cusrefno, job.jobdate, job.imdate, job.bl, job.importer, job.vslname, job.housebl" +
                ", imp.tname, job4.im_ename, job.vslnamerem, couo.name as origin, couc.name as consignmnt, job.loaded, plc.name as loaded_name "+
                ", job.released, plcr.name as name_repleased, job.out_released, plco.name as name_out_repleased, job.approval, plca.name as name_approval " +
                "from job_"+ year + " as job "+
                "left join importer imp on imp.code = job.importer "+
                "left join job_4_"+ year + " job4 on job4.jobno = job.jobno " +
                "left join country couo on couo.code = job.origin " +
                "left join country couc on couc.code = job.consignmnt " +
                "left join place plc on plc.code = job.loaded " +
                "left join place plcr on plcr.code = job.released " +
                "left join place plco on plco.code = job.out_released " +
                "left join place plca on plca.code = job.approval " +
                "Where job.cusrefno is null or job.cusrefno = '' " +
                "Order By job.jobno desc ";
            dt = conn.selectData(conn.connIm, sql);
            return dt;
        }
        public DataTable selectJobNoImport(String jobNo)
        {
            year = DateTime.Now.Year.ToString();
            DataTable dt = new DataTable();
            String sql = "";
            sql = "select job.jobno, job.cusrefno, job.jobdate, job.imdate, job.bl, job.importer, job.vslname, job.housebl" +
                ", imp.tname, job4.im_ename, job.vslnamerem, couo.name as origin, couc.name as consignmnt, job.loaded, plc.name as loaded_name " +
                ", job.released, plcr.name as name_repleased, job.out_released, plco.name as name_out_repleased, job.approval, plca.name as name_approval, job.transmode, job.bl " +
                "from job_" + year + " as job " +
                "left join importer imp on imp.code = job.importer " +
                "left join job_4_" + year + " job4 on job4.jobno = job.jobno " +
                "left join country couo on couo.code = job.origin " +
                "left join country couc on couc.code = job.consignmnt " +
                "left join place plc on plc.code = job.loaded " +
                "left join place plcr on plcr.code = job.released " +
                "left join place plco on plco.code = job.out_released " +
                "left join place plca on plca.code = job.approval " +
                "Where job.jobno = '"+ jobNo + "' " +
                "Order By job.jobno desc ";
            dt = conn.selectData(conn.connIm, sql);
            return dt;
        }
        public DataTable selectJobInvNoImport(String jobNo)
        {
            year = DateTime.Now.Year.ToString();
            DataTable dt = new DataTable();
            String sql = "";
            sql = "select hinv.invno, hinv.invdate, hinv.invitemno, hinv.pono, hinv.consignee, cons.tname " +
                ", hinv.termpaycod, hinv.termpaydet, hinv.totalinv, hinv.currency, hinv.exratethb, hinv.totalinvthb " +
                "from hinv_"+ year + " hinv " +
                "left join consignee cons on hinv.consignee = cons.code " +
                "Where hinv.jobno = '" + jobNo + "' ";
            dt = conn.selectData(conn.connIm, sql);
            return dt;
        }
        public void setJobImport(String jobNo)
        {
            String year = DateTime.Now.Year.ToString();
            String date = DateTime.Now.ToString("yyyy-MM-dd");
            JobImport jim = new JobImport();
            DataTable dt = new DataTable();
            CustomerDB cusDB = new CustomerDB(conn);
            String impId = "";

            dt = selectJobNoImport(jobNo);
            if (dt.Rows.Count>0)
            {
                impId = cusDB.selectImpIdByCodeLike(dt.Rows[0]["importer"].ToString());
                jim.job_import_id = "";
                jim.job_import_code = "";
                jim.job_import_date = date;
                jim.cust_id = "";
                jim.imp_id = impId;
                jim.transport_mode = dt.Rows[0]["transmode"].ToString().Trim();
                jim.staff_id = conn.user.staff_id;
                jim.entry_type = "entry_type_id";
                jim.privi_id = "privi_id";
                jim.ref_1 = "";
                jim.ref_2 = "";
                jim.ref_3 = "";
                jim.ref_4 = "";
                jim.ref_5 = "";
                jim.ref_edi = "ref_edi";
                jim.imp_entry = "imp_entry";
                jim.edi_response = "edi_response";
                jim.tax_method_id = "tax_method_id";
                jim.check_exam_id = "check_exam_id";
                jim.inv_date = "inv_date";
                jim.tax_amt = "tax_amt";
                jim.insr_date = "insr_date";
                jim.insr_id = "insr_id";
                jim.policy_no = "policy_no";
                jim.premium = "premium";
                jim.policy_date = "policy_date";
                jim.policy_clause = "policy_clause";
                jim.job_year = year;
                jim.date_create = "";
                jim.date_modi = "";
                jim.date_cancel = "";
                jim.user_create = "";
                jim.user_modi = "";
                jim.user_cancel = "";
                jim.active = "1";
                jim.remark = "remark";
                jim.remark1 = "remark1";
                jim.remark2 = "remark2";
                jim.jobno = dt.Rows[0]["jobno"].ToString().Trim();
                jim.job_date = conn.dateMiotoDB(dt.Rows[0]["jobdate"].ToString().Trim());
                jim.imp_date = conn.dateMiotoDB(dt.Rows[0]["imdate"].ToString().Trim());
                jim.bl = dt.Rows[0]["bl"].ToString().Trim();
            }
        }
    }
}
