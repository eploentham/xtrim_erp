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
            sql = "select job.jobno, job.cusrefno, job.jobdate, job.imdate, job.bl, job.importer, job.vslname, job.housebl,job.bl " +
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
                ", job.released, plcr.name as name_repleased, job.out_released, plco.name as name_out_repleased, job.approval, plca.name as name_approval " +
                ", job.transmode, job.bl, job.grsww, job.grswwunit, job.nopkg, job.pkgunit, job.housebl, job.vslname, job.vslnamerem, job.netww,job.netwwunit " +
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
            
            DataTable dtJob = new DataTable();
            DataTable dtJob4 = new DataTable();
            DataTable dtJob3 = new DataTable();
            DataTable dtJobInv = new DataTable();
            CustomerDB cusDB = new CustomerDB(conn);
            String impId = "";
            JobImportDB jimDB = new JobImportDB(conn);
            JobImportBlDB jblDB = new JobImportBlDB(conn);
            dtJob = selectJobNoImport(jobNo);
            if (dtJob.Rows.Count>0)
            {
                impId = cusDB.selectImpIdByCodeLike(dtJob.Rows[0]["importer"].ToString());
                jim.job_import_id = "";
                jim.job_import_code = "";
                jim.job_import_date = date;
                jim.cust_id = "";
                jim.imp_id = impId;
                jim.transport_mode = dtJob.Rows[0]["transmode"].ToString().Trim();
                jim.staff_id = conn.user.staff_id;
                jim.entry_type = "";
                jim.privi_id = "";
                jim.ref_1 = "";
                jim.ref_2 = "";
                jim.ref_3 = "";
                jim.ref_4 = "";
                jim.ref_5 = "";
                jim.ref_edi = "";
                jim.imp_entry = "";
                jim.edi_response = "";
                jim.tax_method_id = "";
                jim.check_exam_id = "";
                jim.inv_date = "";
                jim.tax_amt = "";
                jim.insr_date = "";
                jim.insr_id = "";
                jim.policy_no = "";
                jim.premium = "";
                jim.policy_date = "";
                jim.policy_clause = "";
                jim.job_year = year;
                jim.date_create = "";
                jim.date_modi = "";
                jim.date_cancel = "";
                jim.user_create = "";
                jim.user_modi = "";
                jim.user_cancel = "";
                jim.active = "1";
                jim.remark = "";
                jim.remark1 = "";
                jim.remark2 = "";
                jim.jobno = dtJob.Rows[0]["jobno"].ToString().Trim();
                jim.job_date = conn.dateMiotoDB(dtJob.Rows[0]["jobdate"].ToString().Trim());
                jim.imp_date = conn.dateMiotoDB(dtJob.Rows[0]["imdate"].ToString().Trim());
                jim.bl = dtJob.Rows[0]["bl"].ToString().Trim();
                String jimId = jimDB.insertJobImport(jim);
                int chk = 0;
                if (int.TryParse(jimId, out chk))
                {
                    JobImportBl jbl = new JobImportBl();
                    jbl.job_import_bl_id = "";
                    jbl.job_import_id = jimId;
                    jbl.forwarder_id = "";
                    jbl.mbl_mawb = "";
                    jbl.hbl_hawb = dtJob.Rows[0]["housebl"].ToString().Trim();
                    jbl.m_vessel = dtJob.Rows[0]["vslname"].ToString().Trim();
                    jbl.f_vessel = "";
                    jbl.etd = "";
                    jbl.eta = "";
                    jbl.port_imp_id = "";

                    jbl.terminal_id = "";
                    jbl.marsk = "";
                    jbl.description = "";
                    jbl.gw = dtJob.Rows[0]["grsww"].ToString().Trim();
                    jbl.gw_unit_id = dtJob.Rows[0]["grswwunit"].ToString().Trim();
                    jbl.total_packages = dtJob.Rows[0]["nopkg"].ToString().Trim();
                    jbl.unit_package_id = dtJob.Rows[0]["pkgunit"].ToString().Trim();
                    jbl.total_con20 = "";
                    jbl.total_con40 = "";
                    jbl.volume1 = "";

                    jbl.port_of_loading_id = "";
                    jbl.date_check_exam = "";
                    jbl.date_delivery = "";
                    jbl.date_tofac = "";
                    jbl.truck_id = "";
                    jbl.car_number = "";
                    jbl.tranfer_with_job_id = "";
                    jbl.truck_cop_id = "";
                    jbl.status_doc_forrow = "";
                    jbl.doc_forrow = "";

                    jbl.date_doc_forrow = "";
                    jbl.status_job_forrow = "";
                    jbl.job_forrow_description = "";
                    jbl.date_finish_job_forrow = "";
                    jbl.status_oth_job = "";
                    jbl.delivery_remark = "";
                    jbl.container_yard = "";
                    jbl.date_create = "";
                    jbl.date_modi = "";
                    jbl.date_cancel = "";

                    jbl.user_create = "";
                    jbl.user_modi = "";
                    jbl.user_cancel = "";
                    jbl.active = "1";
                    jbl.remark = "";
                    jbl.oth_job_no = "";
                    jbl.fwdCode = "";
                    jbl.fwdCode = "";

                    jbl.ugwCode = "";
                    jbl.ugwNameT = "";
                    jbl.utpCode = "";
                    jbl.utpNameT = "";
                    jbl.polCode = "";
                    jbl.polNameT = "";
                    jbl.tmnCode = "";
                    jbl.tmnNameT = "";
                    jblDB.insertJobImportBl(jbl);
                }
            }
        }
    }
}
