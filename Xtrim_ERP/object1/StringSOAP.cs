using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
//using RDWS;

namespace Xtrim_ERP.object1
{
    public class StringSOAP
    {
        String soapTaxId = "";

        public StringSOAP()
        {
            soapTaxId = @"<wsdl:definitions xmlns:s=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://schemas.xmlsoap.org/wsdl/soap12/"" xmlns:http=""http://schemas.xmlsoap.org/wsdl/http/"" xmlns:mime=""http://schemas.xmlsoap.org/wsdl/mime/"" xmlns:tns=""https://rdws.rd.go.th/serviceRD3/checktinpinservice"" xmlns:soap=""http://schemas.xmlsoap.org/wsdl/soap/"" xmlns:tm=""http://microsoft.com/wsdl/mime/textMatching/"" xmlns:soapenc=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:wsdl=""http://schemas.xmlsoap.org/wsdl/"" targetNamespace=""https://rdws.rd.go.th/serviceRD3/checktinpinservice""> < wsdl:types > 
                 < wsdl:types > 
                 < s:schema elementFormDefault = ""qualified"" targetNamespace = ""https://rdws.rd.go.th/serviceRD3/checktinpinservice"" > 
    < s:element name = ""ServiceTIN"" >
     < s:complexType >
      < s:sequence >
       < s:element minOccurs = ""0"" maxOccurs = ""1"" name = ""anonymous"" type = ""s:string"" />
              < s:element minOccurs = ""0"" maxOccurs = ""1"" name = ""anonymous"" type = ""s:string"" />
                     < s:element minOccurs = ""0"" maxOccurs = ""1"" name = ""TIN"" type = ""s:string"" />
                            </ s:sequence >
                             </ s:complexType >
                              </ s:element >
                               < s:element name = ""ServiceTINResponse"" >
                                < s:complexType >
                                 < s:sequence >
                                  < s:element minOccurs = ""0"" maxOccurs = ""1"" name = ""ServiceTINResult"" type = ""tns:tinpin"" />
                                         </ s:sequence >
                                          </ s:complexType >
                                           </ s:element >
                                            < s:complexType name = ""tinpin"" >
                                             < s:sequence >
                                              < s:element minOccurs = ""0"" maxOccurs = ""1"" name = ""vMessageErr"" type = ""tns:ArrayOfAnyType"" />
                                                     < s:element minOccurs = ""0"" maxOccurs = ""1"" name = ""vID"" type = ""tns:ArrayOfAnyType"" />
                                                            < s:element minOccurs = ""0"" maxOccurs = ""1"" name = ""vDigitOk"" type = ""tns:ArrayOfAnyType"" />
                                                                   < s:element minOccurs = ""0"" maxOccurs = ""1"" name = ""vIsExist"" type = ""tns:ArrayOfAnyType"" />
                                            </ s:sequence >
                                            </ s:complexType >
                                            < s:complexType name = ""ArrayOfAnyType"" >
                                                < s:sequence >
                                                    < s:element minOccurs = ""0"" maxOccurs = ""unbounded"" name = ""anyType"" nillable = ""true"" />
                                                </ s:sequence >
                                            </ s:complexType >
                                            < s:element name = ""ServiceTINArr"" >
                                                < s:complexType >
                                                    < s:sequence >
                                                        < s:element minOccurs = ""0"" maxOccurs = ""1"" name = ""anonymous"" type = ""s:string"" />
                                                            < s:element minOccurs = ""0"" maxOccurs = ""1"" name = ""anonymous"" type = ""s:string"" />
                                                                < s:element minOccurs = ""0"" maxOccurs = ""1"" name = ""TINs"" type = ""tns:ArrayOfString"" />
                                                    </ s:sequence >
                                                </ s:complexType >
                                            </ s:element >
                                            < s:complexType name = ""ArrayOfString"" >
                                                < s:sequence >
                                                    < s:element minOccurs = ""0"" maxOccurs = ""unbounded"" name = ""string"" nillable = ""true"" type = ""s:string"" />
                                                </ s:sequence >
                                            </ s:complexType >
                                            < s:element name = ""ServiceTINArrResponse"" >
                                                < s:complexType >
                                                    < s:sequence >
                                                        < s:element minOccurs = ""0"" maxOccurs = ""1"" name = ""ServiceTINArrResult"" type = ""tns:tinpin"" />
                                                    </ s:sequence >
                                                </ s:complexType >
                                            </ s:element >
                </ s:schema >
            </ wsdl:types >
            < wsdl:message name = ""ServiceTINSoapIn"" >
                < wsdl:part name = ""parameters"" element = ""tns:ServiceTIN"" />
            </ wsdl:message >
            < wsdl:message name = ""ServiceTINSoapOut"" >
                < wsdl:part name = ""parameters"" element = ""tns:ServiceTINResponse"" />
            </ wsdl:message >
            < wsdl:message name = ""ServiceTINArrSoapIn"" >
                < wsdl:part name = ""parameters"" element = ""tns:ServiceTINArr"" />
            </ wsdl:message >
            < wsdl:message name = ""ServiceTINArrSoapOut"" >
                < wsdl:part name = ""parameters"" element = ""tns:ServiceTINArrResponse"" />
            </ wsdl:message >
            < wsdl:portType name = ""checktinpinserviceSoap"" >
                < wsdl:operation name = ""ServiceTIN"" >
                    < wsdl:documentation xmlns:wsdl = ""http://schemas.xmlsoap.org/wsdl/"" > Check PIN </ wsdl:documentation > 
                    < wsdl:input message = ""tns:ServiceTINSoapIn"" /> 
                    < wsdl:output message = ""tns:ServiceTINSoapOut"" /> 
                </ wsdl:operation > 
                < wsdl:operation name = ""ServiceTINArr"" > 
                < wsdl:documentation xmlns:wsdl = ""http://schemas.xmlsoap.org/wsdl/"" > Check TIN Array</ wsdl:documentation > 
                    < wsdl:input message = ""tns:ServiceTINArrSoapIn"" /> 
                    < wsdl:output message = ""tns:ServiceTINArrSoapOut"" /> 
                </ wsdl:operation > 
            </ wsdl:portType > 
            < wsdl:binding name = ""checktinpinserviceSoap"" type = ""tns:checktinpinserviceSoap"" > 
            < soap:binding transport = ""http://schemas.xmlsoap.org/soap/http"" /> 
            < wsdl:operation name = ""ServiceTIN"" > 
                < soap:operation soapAction = ""https://rdws.rd.go.th/serviceRD3/checktinpinservice/ServiceTIN"" style = ""document"" /> 
                < wsdl:input > 
                    < soap:body use = ""literal"" /> 
                </ wsdl:input > 
                < wsdl:output > 
                    < soap:body use = ""literal"" /> 
                </ wsdl:output > 
            </ wsdl:operation > 
            < wsdl:operation name = ""ServiceTINArr"" > 
                < soap:operation soapAction = ""https://rdws.rd.go.th/serviceRD3/checktinpinservice/ServiceTINArr"" style = ""document"" /> 
                < wsdl:input > 
                    < soap:body use = ""literal"" /> 
                </ wsdl:input > 
                < wsdl:output > 
                    < soap:body use = ""literal"" /> 
                </ wsdl:output > 
            </ wsdl:operation > 
        </ wsdl:binding > 
        < wsdl:service name = ""checktinpinservice"" > 
            < wsdl:port name = ""checktinpinserviceSoap"" binding = ""tns:checktinpinserviceSoap"" > 
                < soap:address location = ""https://rdws.rd.go.th/serviceRD3/checktinpinservice.asmx"" /> 
            </ wsdl:port > 
        </ wsdl:service > 
    </ wsdl:definitions > ";
        }
        public Boolean chkTaxIdSOAP(String taxId)
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
            X509Certificate2Collection certificates = new X509Certificate2Collection();
            certificates.Import(@"adhq1.cer");
            Boolean chk = false;
            soapTaxId = soapTaxId.Replace("TIN", taxId);
            String uri = soapTaxId, dump = "";
            
            //XmlDocument soapEnvelopeXml = new XmlDocument();
            const Int32 BufferSize = 128;
            String[] filePO;
            byte[] byteArray = Encoding.UTF8.GetBytes(uri);
            
            // Construct the base 64 encoded string used as credentials for the service call
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes("anonymous" + ":" + "anonymous");
            string credentials = System.Convert.ToBase64String(toEncodeAsBytes);

            // Create HttpWebRequest connection to the service
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create("https://rdws.rd.go.th/serviceRD3/checktinpinservice.asmx?wsdl");
            request1.Method = "POST";
            request1.ContentType = "text/xml;charset=UTF-8";
            request1.ContentLength = byteArray.Length;
            //request1.Headers.Add("Authorization", "Basic " + credentials);
            request1.ClientCertificates = certificates;
            request1.Headers.Add("SOAPAction", "https://rdws.rd.go.th/serviceRD3/checktinpinservice.asmx?wsdl");
            Stream dataStream = request1.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            string actNumber = "";
            XDocument doc;
            using (WebResponse response = request1.GetResponse())
            {                
                using (Stream stream = response.GetResponseStream())
                {
                    doc = XDocument.Load(stream);
                    foreach (XNode node in doc.DescendantNodes())
                    {
                        if (node is XElement)
                        {
                            XElement element = (XElement)node;
                            if (element.Name.LocalName.Equals("reportBytes"))
                            {
                                actNumber = element.ToString().Replace(@"<ns1:reportBytes xmlns:ns1=""http://xmlns.oracle.com/oxp/service/PublicReportService"">", "");
                                actNumber = actNumber.Replace("</reportBytes>", "").Replace("</result>", "").Replace(@"""", "").Replace("<>", "");
                                actNumber = actNumber.Replace("<reportBytes>", "").Replace("</ns1:reportBytes>", "");
                            }
                        }
                    }
                }
            }
            actNumber = actNumber.Trim();
            actNumber = actNumber.IndexOf("<reportContentType>") >= 0 ? actNumber.Substring(0, actNumber.IndexOf("<reportContentType>")) : actNumber;
            byte[] data = Convert.FromBase64String(actNumber);
            string decodedString = Encoding.UTF8.GetString(data);
            String[] data1 = decodedString.Split('\n');

            return chk;
        }
        public Boolean chkTaxIdSOAP1(String taxId)
        {
            Boolean chk = false;

            X509Certificate2 certificates = new X509Certificate2();
            certificates.Import(@"adhq1.cer");
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://rdws.rd.go.th/serviceRD3/checktinpinservice.asmx?wsdl");
            req.AllowAutoRedirect = true;
            req.ClientCertificates.Add(certificates);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            string postData = "login-form-type=cert";
            byte[] postBytes = Encoding.UTF8.GetBytes(postData);
            req.ContentLength = postBytes.Length;
            
            Stream postStream = req.GetRequestStream();
            postStream.Write(postBytes, 0, postBytes.Length);
            postStream.Flush();
            postStream.Close();
            WebResponse resp = req.GetResponse();

            Stream stream = resp.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }
            }

            stream.Close();

            return chk;
        }
    }
}
