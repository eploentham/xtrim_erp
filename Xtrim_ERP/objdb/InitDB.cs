using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.objdb
{
    public class InitDB
    {
        ConnectDB conn;

        public CompanyDB copDB;
        public StaffDB stfDB;
        public CustomerDB cusDB;
        public ConsigneeDB consDB;
        public InsuranceDB insrDB;
        public DepartmentDB deptDB;
        public TerminalDB tmnDB;
        public PortImportDB ptiDB;
        public PortOfLoadingDB polDB;
        public ForwarderDB fwdDB;
        public CurrencyDB currDB;
        public EntryTypeDB ettDB;
        public IncoTermsDB ictDB;
        public TermPaymentDB tpmDB;
        public PrivilegeDB pvlDB;
        public UnitGwDB ugwDB;
        public UnitPackageDB utpDB;
        public BTaxDB btaxDB;
        public CompanyBankDB copbDB;
        public BankDB bnkDB;
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
        public TruckDB trkDB;
        public ItemsDB itmDB;
        public ItemsCatDB itmcDB;
        public ItemsTypeDB itmtDB;
        public ItemsGrpDB itmgDB;
        public ItemGroupDB itmGrpDB;
        public ItemsTypeSubDB itmtsDB;
        public MethodPaymentDB mtpDB;
        public FMethodPaymentDB fmtpDB;
        public FTaxTypeDB fttDB;
        public TaxDB taxDB;
        public ImporterDB impDB;

        public InitDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            copDB = new CompanyDB(conn);

            impDB = new ImporterDB(conn);
            consDB = new ConsigneeDB(conn);
            insrDB = new InsuranceDB(conn);
            deptDB = new DepartmentDB(conn);
            ptiDB = new PortImportDB(conn);
            polDB = new PortOfLoadingDB(conn);
            tmnDB = new TerminalDB(conn);
            fwdDB = new ForwarderDB(conn);
            currDB = new CurrencyDB(conn);

            ettDB = new EntryTypeDB(conn);
            ictDB = new IncoTermsDB(conn);
            tpmDB = new TermPaymentDB(conn);
            pvlDB = new PrivilegeDB(conn);
            ugwDB = new UnitGwDB(conn);
            utpDB = new UnitPackageDB(conn);
            copbDB = new CompanyBankDB(conn);
            btaxDB = new BTaxDB(conn);
            stfDB = new StaffDB(conn);
            cusDB = new CustomerDB(conn);
            bnkDB = new BankDB(conn);
            addrDB = new AddressDB(conn);
            contDB = new ContactDB(conn);
            cusrDB = new CustomerRemarkDB(conn);
            custDB = new CustomerTaxInvoiceDB(conn);
            pfxDB = new PrefixDB(conn);
            posiDB = new PositionDB(conn);
            cotDB = new CountryDB(conn);
            ittDB = new ImporterTypeDB(conn);
            cemDB = new CheckExamDB(conn);
            dctDB = new DocTypeDB(conn);
            trkDB = new TruckDB(conn);
            itmDB = new ItemsDB(conn);
            itmcDB = new ItemsCatDB(conn);
            itmtDB = new ItemsTypeDB(conn);
            itmgDB = new ItemsGrpDB(conn);
            itmGrpDB = new ItemGroupDB(conn);
            itmtsDB = new ItemsTypeSubDB(conn);
            mtpDB = new MethodPaymentDB(conn);
            fmtpDB = new FMethodPaymentDB(conn);
            fttDB = new FTaxTypeDB(conn);
            taxDB = new TaxDB(conn);
        }
    }
}
