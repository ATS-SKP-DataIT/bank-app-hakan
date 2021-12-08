using Bank_APP_Mobile_Dual.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Bank_APP_Mobile_Dual.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateUser : ContentPage
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        public void SendRequest(string json)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44383/user");
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

        private void CreateUserBtn_Clicked(object sender, EventArgs e)
        {
            //check if all info is filled
         /*

            //Gets info from all fields, then impliments it and creates a new user with the data input
            var EntryList = new List<Entry>();
            var ElementList =
                Grid_main.Children.
                Cast<Element>().
                Where(x => x is StackLayout).
                ToList();
            ElementList.ForEach(x => EntryList.Add((x as StackLayout).Children[1] as Entry));

            CreateUserModel newUser = new CreateUserModel(
                EntryList[2].Text,
                EntryList[0].Text,
                EntryList[3].Text,
                EntryList[4].Text,
                EntryList[1].Text);
            SendRequest(JsonConvert.SerializeObject(newUser)); */
        }


     

        private void CancelBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}