using C1.Win.C1Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xtrim_ERP.objdb;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.control
{
    public class XtrimControl
    {
        public InitConfig iniC;
        private IniFile iniF;
        public ConnectDB conn;
        public int grdViewFontSize=0;
        public List<Department> lDept;

        public XtrimDB xtDB;

        public String copID = "", jobID="";

        public Customer sCus;
        public Importer sImp;
        public Forwarder sFwd;
        public EntryType sEtt;
        public PortOfLoading sPol;
        public Privilege sPvl;
        public UnitGw sUgw;
        public UnitPackage sUtp;
        public Terminal sTmn;
        public LogFile lf;

        public Color cTxtFocus;

        //public enum Search
        //{
        //    Customer,
        //    Importer,
        //    Regular,
        //    Important,
        //    Critical
        //};

        public XtrimControl()
        {
            initConfig();
        }
        private void initConfig()
        {
            String appName = "";
            appName = System.AppDomain.CurrentDomain.FriendlyName;
            appName = appName.ToLower().Replace(".exe", "");
            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\" + appName + ".ini"))
            {
                appName = Environment.CurrentDirectory + "\\" + appName + ".ini";
            }
            else
            {
                appName = Environment.CurrentDirectory + "\\" + Application.ProductName + ".ini";
            }
            iniF = new IniFile(appName);
            iniC = new InitConfig();            

            GetConfig();
            conn = new ConnectDB(iniC);

            xtDB = new XtrimDB(conn);
            sCus = new Customer();
            sImp = new Importer();
            sFwd = new Forwarder();
            sEtt = new EntryType();
            sPol = new PortOfLoading();
            sPvl = new Privilege();
            sUgw = new UnitGw();
            sUtp = new UnitPackage();
            sTmn = new Terminal();

            cTxtFocus = ColorTranslator.FromHtml(iniC.txtFocus);
        }
        public void GetConfig()
        {
            iniC.hostDB = iniF.Read("hostDB");
            iniC.hostDBEx = iniF.Read("hostDBEx");
            iniC.hostDBIm = iniF.Read("hostDBIm");
            iniC.nameDB = iniF.Read("nameDB");
            iniC.nameDBEx = iniF.Read("nameDBEx");
            iniC.nameDBIm = iniF.Read("nameDBIm");
            iniC.passDB = iniF.Read("passDB");
            iniC.passDBEx = iniF.Read("passDBEx");
            iniC.passDBIm = iniF.Read("passDBIm");
            iniC.portDB = iniF.Read("portDB");
            iniC.portDBEx = iniF.Read("portDBEx");
            iniC.portDBIm = iniF.Read("portDBIm");
            iniC.userDB = iniF.Read("userDB");
            iniC.userDBEx = iniF.Read("userDBEx");
            iniC.userDBIm = iniF.Read("userDBIm");

            iniC.grdViewFontSize = iniF.Read("grdViewFontSize");
            iniC.grdViewFontName = iniF.Read("grdViewFontName");
            iniC.themeApplication = iniF.Read("themeApplication");
            iniC.txtFocus = iniF.Read("txtFocus");

            iniC.grdViewFontName = iniC.grdViewFontName.Equals("") ? "Microsoft Sans Serif" : iniC.grdViewFontName;
            int.TryParse(iniC.grdViewFontSize, out grdViewFontSize);
        }
        
        public String getValueCboItem(ComboBox c)
        {
            ComboBoxItem iSale;
            iSale = (ComboBoxItem)c.SelectedItem;
            if (iSale == null)
            {
                return "";
            }
            else
            {
                return iSale.Value;
            }
        }
        //public void setCbo(ComboBox c)
        //{
        //    ComboBoxItem item = new ComboBoxItem();
        //    DataTable dt = selectWard();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        item = new ComboBoxItem();
        //        item.Value = dt.Rows[i]["MNC_MD_DEP_NO"].ToString();
        //        item.Text = dt.Rows[i]["MNC_MD_DEP_DSC"].ToString();
        //        c.Items.Add(item);
        //        //c.Items.Add(new );
        //    }
        //    //return c;
        //}
        public ComboBox setCboYear(ComboBox c)
        {
            c.Items.Clear();
            c.Items.Add(System.DateTime.Now.Year);
            c.Items.Add(System.DateTime.Now.Year - 1);
            c.Items.Add(System.DateTime.Now.Year - 2);
            c.SelectedIndex = c.FindStringExact(String.Concat(System.DateTime.Now.Year));
            return c;
        }
        public String datetoDB(object dt)
        {
            DateTime dt1 = new DateTime();
            try
            {
                if (dt == null)
                {
                    return "";
                }
                else if (dt == "")
                {
                    return "";
                }
                else
                {
                    dt1 = DateTime.Parse(dt.ToString());
                    if (dt1.Year <= 1500)
                    {
                        return String.Concat((dt1.Year), "-") + dt1.Month.ToString("00") + "-" + dt1.Day.ToString("00");
                    }
                    else
                    {
                        return dt1.Year.ToString() + "-" + dt1.Month.ToString("00") + "-" + dt1.Day.ToString("00");
                    }

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public ComboBox setCboMonth(ComboBox c)
        {
            //c.ClearItems();
            c.Items.Clear();
            var items = new[]{
                new{Text = "มกราคม", Value="01"},
                new{Text = "กุมภาพันธ์", Value="02"},
                new{Text = "มีนาคม", Value="03"},
                new{Text = "เมษายน", Value="04"},
                new{Text = "พฤษภาคม", Value="05"},
                new{Text = "มิถุนายน", Value="06"},
                new{Text = "กรกฎาคม", Value="07"},
                new{Text = "สิงหาคม", Value="08"},
                new{Text = "กันยายน", Value="09"},
                new{Text = "ตุลาคม", Value="10"},
                new{Text = "พฤศจิกายน", Value="11"},
                new{Text = "ธันวาคม", Value="12"}
            };
            c.DataSource = items;
            c.DisplayMember = "Text";

            c.ValueMember = "Value";
            c.SelectedIndex = c.FindStringExact(getMonth(System.DateTime.Now.Month.ToString("00")));
            return c;
        }
        public String getMonth(String monthId)
        {
            if (monthId == "01")
            {
                return "มกราคม";
            }
            else if (monthId == "02")
            {
                return "กุมภาพันธ์";
            }
            else if (monthId == "03")
            {
                return "มีนาคม";
            }
            else if (monthId == "04")
            {
                return "เมษายน";
            }
            else if (monthId == "05")
            {
                return "พฤษภาคม";
            }
            else if (monthId == "06")
            {
                return "มิถุนายน";
            }
            else if (monthId == "07")
            {
                return "กรกฎาคม";
            }
            else if (monthId == "08")
            {
                return "สิงหาคม";
            }
            else if (monthId == "09")
            {
                return "กันยายน";
            }
            else if (monthId == "10")
            {
                return "ตุลาคม";
            }
            else if (monthId == "11")
            {
                return "พฤศจิกายน";
            }
            else if (monthId == "12")
            {
                return "ธันวาคม";
            }
            else
            {
                return "";
            }
        }
        public String dateDBtoShow(String dt)
        {
            if (dt != "")
            {
                return dt.Substring(8, 2) + "-" + dt.Substring(5, 2) + "-" + String.Concat(Int16.Parse(dt.Substring(0, 4)) + 543);
            }
            else
            {
                return dt;
            }
        }
        public void createFolder(String path)
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
                Directory.CreateDirectory(path);
        }
        private AlternateView getEmbeddedImage(String filePath, String cid)
        {
            LinkedResource res = new LinkedResource(filePath);
            res.ContentId = cid;
            string htmlBody = "<img src=cid:" + res.ContentId + ">";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
        public String FixNull(Object o)
        {
            String chk = "";
            if (o == null)
            {
                chk = "";
            }
            else
            {
                chk = o.ToString();
            }
            return chk;
        }
        public string GetInfoMessageSEP(string text, string subtext)
        {
            return "<table><tr><td><parm><img src='res://Info1.png'></parm></td>" +
            "<td><b><parm>Information</parm></b></td></tr></table>" +
            "<parm><hr noshade size=1 style='margin:2' color=darker></parm>" +
            "<div style='margin:1 12'><parm>" + text +
            "</parm></div><parm><hr noshade size=1 style='margin:2' color=darker></parm>" +
            "<table><tr><td><parm></parm></td><td><b><parm>" + subtext +
            "</parm></b></td></tr></table>";
        }
        public void setCboC1(C1ComboBox c, String selected)
        {
            foreach(object o in c.Items)
            {
                ComboBoxItem a4 = (ComboBoxItem)o;
                if (a4.Value.Equals(selected))
                {
                    c.SelectedText = a4.Text;
                    break;
                }
            }
        }
        public string GoogleMapSign(string url, string keyString)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();

            // converting key to bytes will throw an exception, need to replace '-' and '_' characters first.
            string usablePrivateKey = keyString.Replace("-", "+").Replace("_", "/");
            byte[] privateKeyBytes = Convert.FromBase64String(usablePrivateKey);

            Uri uri = new Uri(url);
            byte[] encodedPathAndQueryBytes = encoding.GetBytes(uri.LocalPath + uri.Query);

            // compute the hash
            HMACSHA1 algorithm = new HMACSHA1(privateKeyBytes);
            byte[] hash = algorithm.ComputeHash(encodedPathAndQueryBytes);

            // convert the bytes to string and make url-safe by replacing '+' and '/' characters
            string signature = Convert.ToBase64String(hash).Replace("+", "-").Replace("/", "_");

            // Add the signature to the existing URI.
            return uri.Scheme + "://" + uri.Host + uri.LocalPath + uri.Query + "&signature=" + signature;
        }
    }
}
