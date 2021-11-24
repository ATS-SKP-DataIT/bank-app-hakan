using Bank_APP_Mobile_Dual.Models;
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
    public partial class FrontPage : ContentPage
    {
        private List<UserInfos> UserInfos = new List<UserInfos>();
        private int currentBalance = 15000;
        private int accountNumber = 1293923942;

        public FrontPage()
        {
            InitializeComponent();

            Title = "Bank Application";
            BackgroundColor = Color.DarkSlateBlue;
            
            string accountName = "Main Account";

            UserInfos.Add(new UserInfos(accountNumber, accountName));
            Frame depositLayout = new Frame {
                Padding = 1,
                CornerRadius = 3,
                Content = new StackLayout
                {
                    Spacing = 3,
                    BackgroundColor = Color.DarkSlateBlue,
                    Children =
                    {
                        LabelMaker($"Deposit Amount:", 18, TextAlignment.Center, TextAlignment.Start, Color.White, FontAttributes.None),
                        new Entry{}
                    }
                }
            };

            StackLayout underLayout = new StackLayout
            {
                Margin = new Thickness(10),
                Spacing = 25,
                BackgroundColor = Color.DarkSlateBlue,
                Children =
                {
                    LabelMaker($"Account Info:", 14, TextAlignment.Center, TextAlignment.Start, Color.White, FontAttributes.Bold),
                    new Frame{
                        Padding = 1,
                        CornerRadius = 3,
                        Content =
                        new StackLayout {
                            BackgroundColor = Color.DarkSlateBlue,
                            Children = {
                                AccountDropDown("Name"),
                                AccountDropDown("Number")
                            }
                        }
                    },
                    new Frame{
                        Padding = 1,
                        CornerRadius = 3,
                        Content =
                        new StackLayout
                        {
                                BackgroundColor = Color.DarkSlateBlue,
                                Children ={
                                LabelMaker($"Current Balance: \n{currentBalance}", 18, TextAlignment.Center, TextAlignment.Start, Color.White, FontAttributes.Bold),
                                
                            }
                        }
                    },    
                    depositLayout,
                },
            };

            var layout = new StackLayout
            {
                Margin = new Thickness(20),
                Spacing = 25,
                BackgroundColor = Color.DarkSlateBlue,
                Children =
                {
                    LabelMaker("Deposit", 22, TextAlignment.Center, TextAlignment.Start, Color.White, FontAttributes.Bold),
                    underLayout,

                }
            };
            Content = layout;
        }

        public Label LabelMaker(string txt, int size, TextAlignment horizontal, TextAlignment vertical, Color txtColor, FontAttributes fontAttributes)
        {
            return new Label
            {
                Text = txt,
                FontSize = size,
                HorizontalTextAlignment = horizontal,
                VerticalTextAlignment = vertical,
                TextColor = txtColor,
                FontAttributes = fontAttributes,
            };
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private Picker AccountDropDown(string cases)
        {
            Picker _picker = new Picker();
            if (cases == "Name")
            {
                foreach (UserInfos item in UserInfos)
                {
                    _picker.Items.Add($"{item.AccountName}");
                }
            }
            else if (cases == "Number")
            {
                foreach (UserInfos item in UserInfos)
                {
                    _picker.Items.Add($"{item.AccountNumber}");
                }
            }
            _picker.HorizontalTextAlignment = TextAlignment.Center;
            _picker.SelectedIndex = 0;
            _picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            return _picker;
        }
    } 
}