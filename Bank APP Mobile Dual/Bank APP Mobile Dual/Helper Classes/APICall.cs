using Bank_APP_Mobile_Dual.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bank_APP_Mobile_Dual.Helper_Classes
{
    class APICall
    {
        public static string SendRequest(string json, string api, string username)
        {
            try
            {
                string TokenId = "1666723Dx";
                var url = $"https://10.0.2.2:49155/{api}";

                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "POST";

                httpRequest.ServerCertificateValidationCallback = delegate { return true; };
                httpRequest.Accept = "application/json";
                httpRequest.ContentType = "application/json";

                var req = new APIReqModel
                {
                    Json = json,
                    Token = TokenId,
                    Username = Encoding.UTF8.GetBytes(username)
                };
                var EncryptedMsg = JsonConvert.SerializeObject(req);

                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(EncryptedMsg);
                }

                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch
            {
                return "Error";
            }
        }

        public static string SendRequest3(string json, string api, string username)
        {
            var url = $"https://10.0.2.2:49155/user";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.ServerCertificateValidationCallback = delegate { return true; };
            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write("{\"name\":\"John\"}");
            }
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return streamReader.ReadToEnd();
            }

        }

        public static void APIGetTesting()
        {
            string html = string.Empty;
            string url = "https://10.0.2.2:49155/user";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.ServerCertificateValidationCallback = delegate { return true; };

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

        }
    }
}