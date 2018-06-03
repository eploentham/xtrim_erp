using C1.Win.C1Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class CheckExamDB
    {
        public CheckExam cem;
        ConnectDB conn;
        public List<CheckExam> lCem;
        public DataTable dtContain;

        public CheckExamDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            cem = new CheckExam();
            cem.active = "active";
            cem.date_cancel = "date_cancel";
            cem.date_create = "date_create";
            cem.date_modi = "date_modi";
            cem.check_exam_code = "check_exam_code";
            cem.check_exam_id = "check_exam_id";
            cem.check_exam_name = "check_exam_name";

            cem.pkField = "check_exam_id";
            cem.table = "f_check_exam";

            lCem = new List<CheckExam>();
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cem.*  " +
                "From " + cem.table + " cem " +
                " " +
                "Where cem." + cem.active + " ='1' "+
                "";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select cem.* " +
                "From " + cem.table + " cem " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cem." + cem.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public CheckExam selectByPk1(String copId)
        {
            CheckExam cop1 = new CheckExam();
            DataTable dt = new DataTable();
            String sql = "select cem.* " +
                "From " + cem.table + " cem " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cem." + cem.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            setCheckExam(dt);
            return cop1;
        }
        public void getlCem()
        {
            lCem.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            dtContain = dt;
            foreach (DataRow row in dt.Rows)
            {
                CheckExam utp1 = new CheckExam();
                utp1.check_exam_id = row[cem.check_exam_id].ToString();
                utp1.check_exam_code = row[cem.check_exam_code].ToString();
                utp1.check_exam_name = row[cem.check_exam_name].ToString();
                lCem.Add(utp1);
            }
        }
        private CheckExam setCheckExam(DataTable dt)
        {
            CheckExam itt1 = new CheckExam();
            if (dt.Rows.Count > 0)
            {
                itt1.check_exam_id = dt.Rows[0][cem.check_exam_id].ToString();
                itt1.check_exam_code = dt.Rows[0][cem.check_exam_code].ToString();
                itt1.check_exam_name = dt.Rows[0][cem.check_exam_name].ToString();
                itt1.active = dt.Rows[0][cem.active].ToString();
                //itt1.cou_name = dt.Rows[0][itt.cou_name].ToString();

            }
            return itt1;
        }
        public C1ComboBox setCboCheckExam(C1ComboBox c)
        {
            DataTable dt = selectAll();
            c.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ComboBoxItem a1 = new ComboBoxItem();
                a1.Value = row[cem.check_exam_id].ToString();
                a1.Text = row[cem.check_exam_name].ToString();
                c.Items.Add(a1);
            }
            return c;
        }
        public void setCboCheckExam(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            if (lCem.Count <= 0) getlCem();
            foreach (CheckExam cus1 in lCem)
            {
                item = new ComboBoxItem();
                item.Value = cus1.check_exam_id;
                item.Text = cus1.check_exam_name;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                }
            }
        }
    }
}
