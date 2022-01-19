using Bank_APP_Mobile_Dual.Helper_Classes;
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

using static Bank_APP_Mobile_Dual.Helper_Classes.APICall;

namespace Bank_APP_Mobile_Dual.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateUser : ContentPage
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        

        private void CreateUserBtn_Clicked(object sender, EventArgs e)
        {
            //check if all info is filled
         

            //Gets info from all fields, then impliments it and creates a new user with the data input
            var EntryList = new List<Entry>();
            var ElementList =
                Grid_CreateUser.Children.
                Cast<Element>().
                Where(x => x is StackLayout).
                ToList();
            ElementList.ForEach(x => EntryList.Add((x as StackLayout).Children[1] as Entry));

            CreateUserModel newUser = new CreateUserModel(
                EntryList[2].Text, //Email
                EntryList[0].Text, //UserName
                EntryList[3].Text, //FirstName
                EntryList[4].Text, //LastName
                EntryList[1].Text); //Password
            Crypt crypt = new Crypt();
            Task.Run(() => SendRequest(crypt.Encrypter(JsonConvert.SerializeObject(newUser), "13334448853"), "user", "UserCreationTemp563"));

        }




        private void CancelBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}