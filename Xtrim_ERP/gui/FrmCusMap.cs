using Google.Maps;
using Google.Maps.Geocoding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xtrim_ERP.control;

namespace Xtrim_ERP.gui
{
    public partial class FrmCusMap : Form
    {
        XtrimControl xC;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        public FrmCusMap(XtrimControl x)
        {
            InitializeComponent();
        }

        private void FrmCusMap_Load(object sender, EventArgs e)
        {
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //StreamReader reader = new StreamReader(assembly.GetManifestResourceStream("googlemap.html"));
            //webBrowser1.DocumentText = reader.ReadToEnd();

            const string keyString = "AIzaSyBMj25ZUQsFrZUqllGExQXawTv4GqEDYBk";
            const string urlString = "https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=";
            string inputUrl = null;
            string inputKey = null;

            //Console.WriteLine("Enter the URL (must be URL-encoded) to sign: ");
            //inputUrl = Console.ReadLine();
            //if (inputUrl.Length == 0)
            //{
            //    inputUrl = urlString;
            //}

            //Console.WriteLine("Enter the Private key to sign the URL: ");
            //inputKey = Console.ReadLine();
            //if (inputKey.Length == 0)
            //{
            //    inputKey = keyString;
            //}

            //Console.WriteLine(xC.GoogleMapSign(inputUrl, inputKey));


            GoogleSigned.AssignAllServices(new GoogleSigned(keyString));
            var request = new GeocodingRequest();
            request.Address = "Bangna, Thailand";
            var response = new GeocodingService().GetResponse(request);

            if (response.Status == ServiceResponseStatus.Ok && response.Results.Count() > 0)
            {
                var result = response.Results.First();
                webBrowser1.Navigate("https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=AIzaSyBMj25ZUQsFrZUqllGExQXawTv4GqEDYBk");

                Console.WriteLine("Full Address: " + result.FormattedAddress);         // "1600 Pennsylvania Ave NW, Washington, DC 20500, USA"
                Console.WriteLine("Latitude: " + result.Geometry.Location.Latitude);   // 38.8976633
                Console.WriteLine("Longitude: " + result.Geometry.Location.Longitude); // -77.0365739
                Console.WriteLine();
                
            }
            else
            {
                Console.WriteLine("Unable to geocode.  Status={0} and ErrorMessage={1}", response.Status, response.ErrorMessage);
            }

            //webBrowser1.Navigate("https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=AIzaSyBMj25ZUQsFrZUqllGExQXawTv4GqEDYBk");
        }
    }
}
