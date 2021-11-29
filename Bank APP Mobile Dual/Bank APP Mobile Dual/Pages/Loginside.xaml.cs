using Bank_APP_Mobile_Dual.Helper_Classes.CRUDS;
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
            LoginsideCrud crud = new LoginsideCrud(null);
        }


    }
}