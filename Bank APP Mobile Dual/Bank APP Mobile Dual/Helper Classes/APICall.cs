using Bank_APP_Mobile_Dual.Models;
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
        public static string SendRequest(string json, string api)
        {
            var url = $"https://10.0.2.2:49155/{api}";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.ServerCertificateValidationCallback = delegate { return true; };
            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";        

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
