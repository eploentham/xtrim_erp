using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class XtrimDB
    {
        ConnectDB conn;

        //public StaffDB sfDB;
        public BankDB bnkDB;
        public CompanyDB copDB;
        public StaffDB stfDB;
        public CustomerDB cusDB;
        public ImporterDB impDB;
        //public ImportDataDB imdDB;

        //ImporterDB impDB;
        //CustomerDB cusDB;
        public ConsigneeDB consDB;
        public InsuranceDB insrDB;
        public DepartmentDB deptDB;
        //StaffDB stfDB;
        public JobImportDB jimDB;
        public TerminalDB tmnDB;
        public PortImportDB ptiDB;
        public PortOfLoadingDB polDB;
        public ForwarderDB fwdDB;
        public JobImportBlDB jblDB;
        public CurrencyDB currDB;
        public JobImportInvDB jinDB;
        public EntryTypeDB ettDB;
        public IncoTermsDB ictDB;
        public TermPaymentDB tpmDB;
        public PrivilegeDB pvlDB;
        public UnitGwDB ugwDB;
        public UnitPackageDB utpDB;
        public JobImportExpnDB jieDB;
        
        public MethodPaymentDB mtpDB;
        public JobImportContDB jctDB;
        public AddressDB addrDB;
        public ContactDB contDB;
        public CustomerRemarkDB cusrDB;
        public CustomerTaxInvoiceDB custDB;
        public PrefixDB pfxDB;
        public PositionDB posiDB;
        public CountryDB cotDB;
        public ImporterTypeDB ittDB;
        public CheckExamDB cemDB;
        public DocTypeDB dctDB;
        public JobImportCheckListDB jclDB;
        public JobImportCheckExamDB jceDB;
        public JobImportContainerListDB jcsDB;
        public JobImportDeliveryDB jdvDB;
        public TruckDB trkDB;
        public JobImportContainerDB jcnDB;

        public ItemsDB itmDB;
        public ItemsCatDB itmcDB;
        public ItemsTypeDB itmtDB;
        public ItemsGrpDB itmgDB;
        public ItemGroupDB itmGrpDB;
        public ItemsTypeSubDB itmtsDB;
        public ExpensesDrawDB expndDB;
        public ExpensesDrawDetailDB expnddDB;
        public ExpensesDrawTypeDB expndtDB;
        public FMethodPaymentDB fmtpDB;
        public ReservePayDB rspDB;
        public CompanyBankDB copbDB;
        public ExpensesPayDB expnpDB;
        public ExpensesPayDetailDB expnpdDB;
        public BillingDB bllDB;
        public BillingDetailDB blldDB;
        public DebtorDB dtrDB;
        public BTaxDB btaxDB;
        public PaymentDB pytDB;
        public PaymentDetailDB pytdDB;
        public ReceiptDB rcpDB;
        public ReceiptDetailDB rcpdDB;
        public BillingCoverDB bllcDB;
        public FTaxTypeDB fttDB;
        public TaxDB taxDB;
        public ReserveCashDB rscDB;
        public ImagesDB imgDB;

        public MeiosysDB mioDB;

        public XtrimDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            //sfDB = new StaffDB(conn);
            bnkDB = new BankDB(conn);
            copDB = new CompanyDB(conn);
            stfDB = new StaffDB(conn);
            cusDB = new CustomerDB(conn);
            impDB = new ImporterDB(conn);
            //imdDB = new ImportDataDB(conn);

            //impDB = new ImporterDB(conn);
            //cusDB = new CustomerDB(conn);
            consDB = new ConsigneeDB(conn);
            insrDB = new InsuranceDB(conn);
            deptDB = new DepartmentDB(conn);
            //stfDB = new StaffDB(conn);
            jimDB = new JobImportDB(conn);
            ptiDB = new PortImportDB(conn);
            polDB = new PortOfLoadingDB(conn);
            tmnDB = new TerminalDB(conn);
            fwdDB = new ForwarderDB(conn);
            jblDB = new JobImportBlDB(conn);
            currDB = new CurrencyDB(conn);
            jinDB = new JobImportInvDB(conn);
            ettDB = new EntryTypeDB(conn);
            ictDB = new IncoTermsDB(conn);
            tpmDB = new TermPaymentDB(conn);
            pvlDB = new PrivilegeDB(conn);
            ugwDB = new UnitGwDB(conn);
            utpDB = new UnitPackageDB(conn);

            jieDB = new JobImportExpnDB(conn);
            
            mtpDB = new MethodPaymentDB(conn);
            jctDB = new JobImportContDB(conn);
            addrDB = new AddressDB(conn);
            contDB = new ContactDB(conn);
            cusrDB = new CustomerRemarkDB(conn);
            custDB = new CustomerTaxInvoiceDB(conn);
            pfxDB = new PrefixDB(conn);
            posiDB = new PositionDB(conn);
            mioDB = new MeiosysDB(conn);
            cotDB = new CountryDB(conn);
            ittDB = new ImporterTypeDB(conn);
            cemDB = new CheckExamDB(conn);
            dctDB = new DocTypeDB(conn);
            jclDB = new JobImportCheckListDB(conn);
            jceDB = new JobImportCheckExamDB(conn);
            jcsDB = new JobImportContainerListDB(conn);
            jdvDB = new JobImportDeliveryDB(conn);
            jcnDB = new JobImportContainerDB(conn);

            trkDB = new TruckDB(conn);
            itmDB = new ItemsDB(conn);
            itmcDB = new ItemsCatDB(conn);
            itmtDB = new ItemsTypeDB(conn);
            itmgDB = new ItemsGrpDB(conn);
            itmGrpDB = new ItemGroupDB(conn);
            itmtsDB = new ItemsTypeSubDB(conn);

            expndDB = new ExpensesDrawDB(conn);
            expnddDB = new ExpensesDrawDetailDB(conn);
            expndtDB = new ExpensesDrawTypeDB(conn);
            fmtpDB = new FMethodPaymentDB(conn);
            rspDB = new ReservePayDB(conn);
            copbDB = new CompanyBankDB(conn);
            expnpDB = new ExpensesPayDB(conn);
            expnpdDB = new ExpensesPayDetailDB(conn);
            bllDB = new BillingDB(conn);
            blldDB = new BillingDetailDB(conn);
            dtrDB = new DebtorDB(conn);
            btaxDB = new BTaxDB(conn);
            pytDB = new PaymentDB(conn);
            pytdDB = new PaymentDetailDB(conn);
            rcpDB = new ReceiptDB(conn);
            rcpdDB = new ReceiptDetailDB(conn);
            bllcDB = new BillingCoverDB(conn);
            fttDB = new FTaxTypeDB(conn);
            taxDB = new TaxDB(conn);
            rscDB = new ReserveCashDB(conn);
            imgDB = new ImagesDB(conn);
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
                    if (onhand > amt1)  //2.ถ้าเงินเหลือพอ ตัดยอด
                    {
                        //amt1 = 1000;

                        sql = "Update " + rspDB.rsp.table + " Set " +
                            " " + rspDB.rsp.amount_onhand + " = "+rspDB.rsp.amount_onhand+"-" + amt1 + " " +
                            "," + rspDB.rsp.date_reserve + " = now() " +
                            "," + rspDB.rsp.date_modi + " = now() " +
                            "," + rspDB.rsp.user_modi + " = '" + userId + "' " +
                            "Where " + rspDB.rsp.pkField + "='" + rsp1.reserve_pay_id + "'";
                        try
                        {
                            re = conn.ExecuteNonQuery(conn.conn, sql);
                            re = copDB.updateAmountReserve("-"+amt1.ToString());
                            ReserveCash rsc = new ReserveCash();
                            rsc.reserve_cash_id = "";
                            rsc.reserve_pay_id = rsp1.reserve_pay_id;
                            rsc.expenses_pay_detail_id = expnpdid;
                            rsc.amount = "-"+amt1;
                            rsc.active = "1";
                            rsc.remark = "";
                            rsc.date_create = "";
                            rsc.date_modi = "";
                            rsc.date_cancel = "";
                            rsc.user_create = "";
                            rsc.user_modi = "";
                            rsc.user_cancel = "";
                            rsc.status_reserve = "2";
                            rsc.desc1 = "จ่ายเงิน "+ name1+" "+ name2;
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
                            rsc.amount = "-"+onhand.ToString();
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
