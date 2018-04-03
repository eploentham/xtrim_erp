using System;
using System.Collections.Generic;
using System.Linq;
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
        }
    }
}
