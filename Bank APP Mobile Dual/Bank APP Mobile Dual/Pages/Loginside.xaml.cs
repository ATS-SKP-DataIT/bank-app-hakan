using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        }
        private void CreateUser_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateUser());
        }
    }
}