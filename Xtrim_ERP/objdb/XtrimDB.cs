using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.objdb
{
    public class XtrimDB
    {
        ConnectDB conn;

        //public StaffDB sfDB;
        public BankDB banDB;
        public CompanyDB copDB;
        public StaffDB stfDB;
        public CustomerDB cusDB;
        public ImporterDB impDB;
        public ImportDataDB imdDB;

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
        public ExpensesDB expnDB;
        public MethodPaymentDB mtpDB;
        public JobImportContDB jctDB;
        public AddressDB addrDB;
        public ContactDB contDB;
        public CustomerRemarkDB cusrDB;
        public CustomerTaxInvoiceDB custDB;

        public XtrimDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            //sfDB = new StaffDB(conn);
            banDB = new BankDB(conn);
            copDB = new CompanyDB(conn);
            stfDB = new StaffDB(conn);
            cusDB = new CustomerDB(conn);
            impDB = new ImporterDB(conn);
            imdDB = new ImportDataDB(conn);

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
            expnDB = new ExpensesDB(conn);
            mtpDB = new MethodPaymentDB(conn);
            jctDB = new JobImportContDB(conn);
            addrDB = new AddressDB(conn);
            contDB = new ContactDB(conn);
            cusrDB = new CustomerRemarkDB(conn);
            custDB = new CustomerTaxInvoiceDB(conn);
        }
    }
}
