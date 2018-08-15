using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class AccDB
    {
        ConnectDB conn;

        public CompanyDB copDB;
        public ReservePayDB rspDB;
        public ReserveCashDB rscDB;
        public ExpensesClearCashDB eccDB;
        public ExpensesRefundDB erfDB;
        public BillingDB bllDB;
        public BillingDetailDB blldDB;
        public DebtorDB dtrDB;
        public PaymentDB pytDB;
        public PaymentDetailDB pytdDB;
        public ReceiptDB rcpDB;
        public ReceiptDetailDB rcpdDB;
        public BillingCoverDB bllcDB;
        public ExpensesPayDB expnpDB;
        public ExpensesPayDetailDB expnpdDB;
        public ExpensesDrawDB expndDB;
        public ExpensesDrawDetailDB expnddDB;
        public ExpensesDrawTypeDB expndtDB;

        public AccDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            copDB = new CompanyDB(conn);
            rspDB = new ReservePayDB(conn);

            expnpDB = new ExpensesPayDB(conn);
            expnpdDB = new ExpensesPayDetailDB(conn);
            bllDB = new BillingDB(conn);
            blldDB = new BillingDetailDB(conn);
            dtrDB = new DebtorDB(conn);

            pytDB = new PaymentDB(conn);
            pytdDB = new PaymentDetailDB(conn);
            rcpDB = new ReceiptDB(conn);
            rcpdDB = new ReceiptDetailDB(conn);
            bllcDB = new BillingCoverDB(conn);

            rscDB = new ReserveCashDB(conn);

            eccDB = new ExpensesClearCashDB(conn);
            erfDB = new ExpensesRefundDB(conn);
            expndDB = new ExpensesDrawDB(conn);
            expnddDB = new ExpensesDrawDetailDB(conn);
            expndtDB = new ExpensesDrawTypeDB(conn);
        }
        public String updateOnhand(String expnpdid, String userId, String amt, String name1, String name2)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            Decimal amt1 = 0, onhand = 0;
            Boolean chkOnhand = false;
            if (!Decimal.TryParse(amt, out amt1))
            {
                return "";
            }

            //chkNull(p);
            //1.ดึงข้อมุล ดูว่ามี onhand ใบเก่า เหลือเงินเท่าไร
            //2.ถ้าเงินเหลือพอ ตัดยอด
            //3.เงินไม่พอ ให้ตัด เท่าที่มี
            //3.1 ดึงข้อมูล ใหม่ แล้วตัดยอดใหม่
            for (int i = 1; i < 5; i++)
            {
                if (chkOnhand) continue;
                ReservePay rsp1 = new ReservePay();
                rsp1 = rspDB.selectByOnhandOLD();
                if (Decimal.TryParse(rsp1.amount_onhand, out onhand))
                {
                    if (onhand >= amt1)  //2.ถ้าเงินเหลือพอ ตัดยอด
                    {
                        //amt1 = 1000;

                        sql = "Update " + rspDB.rsp.table + " Set " +
                            " " + rspDB.rsp.amount_onhand + " = " + rspDB.rsp.amount_onhand + "-" + amt1 + " " +
                            "," + rspDB.rsp.date_reserve + " = now() " +
                            "," + rspDB.rsp.date_modi + " = now() " +
                            "," + rspDB.rsp.user_modi + " = '" + userId + "' " +
                            "Where " + rspDB.rsp.pkField + "='" + rsp1.reserve_pay_id + "'";
                        try
                        {
                            re = conn.ExecuteNonQuery(conn.conn, sql);
                            re = copDB.updateAmountReserve("-" + amt1.ToString());
                            ReserveCash rsc = new ReserveCash();
                            rsc.reserve_cash_id = "";
                            rsc.reserve_pay_id = rsp1.reserve_pay_id;
                            rsc.expenses_pay_detail_id = expnpdid;
                            rsc.amount = "-" + amt1;
                            rsc.active = "1";
                            rsc.remark = "";
                            rsc.date_create = "";
                            rsc.date_modi = "";
                            rsc.date_cancel = "";
                            rsc.user_create = "";
                            rsc.user_modi = "";
                            rsc.user_cancel = "";
                            rsc.status_reserve = "2";
                            rsc.desc1 = "จ่ายเงิน " + name1 + " " + name2;
                            re = rscDB.insertReserveCash(rsc, userId);

                            chkOnhand = true;
                        }
                        catch (Exception ex)
                        {
                            sql = ex.Message + " " + ex.InnerException;
                        }
                    }
                    else
                    {
                        sql = "Update " + rspDB.rsp.table + " Set " +
                            " " + rspDB.rsp.amount_onhand + " = " + rspDB.rsp.amount_onhand + "-" + onhand + " " +
                            "," + rspDB.rsp.date_reserve + " = now() " +
                            "," + rspDB.rsp.date_modi + " = now() " +
                            "," + rspDB.rsp.user_modi + " = '" + userId + "' " +
                            "Where " + rspDB.rsp.pkField + "='" + rsp1.reserve_pay_id + "'";
                        try
                        {
                            re = conn.ExecuteNonQuery(conn.conn, sql);
                            amt1 = amt1 - onhand;
                            re = copDB.updateAmountReserve("-" + amt1.ToString());
                            ReserveCash rsc = new ReserveCash();
                            rsc.reserve_cash_id = "";
                            rsc.reserve_pay_id = rsp1.reserve_pay_id;
                            rsc.expenses_pay_detail_id = expnpdid;
                            rsc.amount = "-" + onhand.ToString();
                            rsc.active = "1";
                            rsc.remark = "";
                            rsc.date_create = "";
                            rsc.date_modi = "";
                            rsc.date_cancel = "";
                            rsc.user_create = "";
                            rsc.user_modi = "";
                            rsc.user_cancel = "";
                            rsc.status_reserve = "2";
                            rsc.desc1 = "จ่ายเงิน ";
                            rscDB.insertReserveCash(rsc, userId);

                            chkOnhand = false;
                        }
                        catch (Exception ex)
                        {
                            sql = ex.Message + " " + ex.InnerException;
                        }
                    }
                }
            }

            return re;
        }
    }
}
