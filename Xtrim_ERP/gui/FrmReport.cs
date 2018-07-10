using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xtrim_ERP.control;

namespace Xtrim_ERP.gui
{
    public partial class FrmReport : Form
    {
        XtrimControl xC;

        public FrmReport(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {

        }
        public void setReportTax(DataTable dt)
        {
            String chk = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                //cc.lw.WriteLog("rpt.setReportCheckUp OK ");
                rpt.Load(Application.StartupPath+ "\\report\\tax_1.rpt");
                //cc.lw.WriteLog("rpt.setReportCheckUp OK Load" + cc.initC.PathReport + "CheckUp_mini_1.rpt");
                rpt.SetDataSource(dt);
                //cc.lw.WriteLog("rpt.setReportCheckUp OK SetDataSource");
                //        //rpt.SetDataSource(dt2);
                //        //ParameterField myParam = new ParameterField();
                //        //myParam.Name = "header1";
                //        //myParam.

                //rpt.SetParameterValue("line1", "ผลตรวจสุขภาพประจำปี " + cuc.YearId);
                //rpt.SetParameterValue("compName", "โรงพยาบาล อรวรรณ");
                //rpt.SetParameterValue("compAddress", "8/8 หมู่ 6 ต.แพรกษา อ.เมือง จ.สมุทรปราการ 10280 โทร : 02-3342555  Fax.02-3342684");


                //rpt.SetParameterValue("custName", cuc.CustNameT);
                //rpt.SetParameterValue("year_id",cuc.YearId);

                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                //cc.lw.WriteLog("rpt.setReportCheckUp Error " + chk);
            }
        }
        private void FrmReport_Load(object sender, EventArgs e)
        {

        }
    }
}
