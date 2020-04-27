using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace Insurance.smsSendService
{
    public class SmsSendService
    {


        public void sendTest()
        {
            try
            {
                string content;
                 
                string Method = "POST";


                string uri = "http://rest.payamak-panel.com/api/SendSMS/SendSMS";

                HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
                req.ContentType = "application/json";

                //req.Headers.Add("content-type", "application/json");
                req.Headers.Add("postman-token", "fcddb5f4-dc58-c7d5-4bf9-9748710f8789");
                //req.Headers.Add("application/x-www-form-urlencoded", "username=YourUserName&password=YourPassWord&recID=YourRecID", ParameterType.RequestBody);
                req.Headers.Add("cache-control", "no-cache");

                //req.pa

                req.KeepAlive = false;
                req.Method = Method.ToUpper();

                if (("POST,PUT").Split(',').Contains(Method.ToUpper()))
                {
                     
                    content = "test";

                    byte[] buffer = Encoding.ASCII.GetBytes(content);
                    req.ContentLength = buffer.Length;
                    req.ContentType = "text/xml";
                    Stream PostData = req.GetRequestStream();
                    PostData.Write(buffer, 0, buffer.Length);
                    PostData.Close();

                }

                HttpWebResponse resp = req.GetResponse() as HttpWebResponse;


                Encoding enc = System.Text.Encoding.GetEncoding(1252);
                StreamReader loResponseStream = new StreamReader(resp.GetResponseStream(), enc);

                string Response = loResponseStream.ReadToEnd();

                loResponseStream.Close();
                resp.Close();
                Console.WriteLine(Response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nMessage ---\n{0}", ex.Message);
                Console.WriteLine(
                    "\nHelpLink ---\n{0}", ex.HelpLink);
                Console.WriteLine("\nSource ---\n{0}", ex.Source);
                Console.WriteLine(
                    "\nStackTrace ---\n{0}", ex.StackTrace);
                Console.WriteLine(
                    "\nTargetSite ---\n{0}", ex.TargetSite);
            }
        }
    }
}
