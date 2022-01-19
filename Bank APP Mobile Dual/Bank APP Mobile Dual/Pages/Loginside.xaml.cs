using Bank_APP_Mobile_Dual.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using static Bank_APP_Mobile_Dual.Helper_Classes.APICall;

namespace Bank_APP_Mobile_Dual.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Loginside : ContentPage
    {
        public Loginside()
        {
            InitializeComponent();
        }

        private void SignIn_Clicked(object sender, EventArgs e)
        {

            /*
            var sendreqTask = Task.Run(() => SendRequest(JsonConvert.SerializeObject(
                new APILoginModel
                {
                    UserName = LoginSide_Entry_UserName.Text,
                    Email = LoginSide_Entry_UserName.Text,
                    Password =
                    LoginSide_Entry_PW.Text,
                }), "login")
            );
            string result = "Failed";
            if (sendreqTask.Result == "true")
                result = "Success";
            App.Current.MainPage.DisplayAlert("Login", result, "Ok");
            */
        }
        private void CreateUser_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateUser());
        }
    }
}