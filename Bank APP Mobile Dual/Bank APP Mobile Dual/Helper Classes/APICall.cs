using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bank_APP_Mobile_Dual.Helper_Classes
{
    class APICall
    {
        public static async Task SendRequestAsync(string json, string api)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create($"https://localhost:44383/{api}");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
            catch(Exception e)
            {
                //log exception here:
                await App.Current.MainPage.DisplayAlert("Test Title", "Test", "OK");
            }
        }
    }
}
