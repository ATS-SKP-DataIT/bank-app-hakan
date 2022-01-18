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
            string TokenId = "1666723Dx";
            var url = $"https://10.0.2.2:49155/{api}";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.ServerCertificateValidationCallback = delegate { return true; };
            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";        

            //issue here to fix:
            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(
                    Convert.FromBase64String(
                        JsonConvert.SerializeObject( 
                            new APIReqModel {
                                Json = json, 
                                Token = TokenId, 
                                Username = username}
                            )));
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
