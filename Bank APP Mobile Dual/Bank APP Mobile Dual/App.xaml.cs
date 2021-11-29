using Bank_APP_Mobile_Dual.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bank_APP_Mobile_Dual
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //   MainPage = new MainPage();
            // MainPage = new FrontPage();
            MainPage = new Loginside();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
