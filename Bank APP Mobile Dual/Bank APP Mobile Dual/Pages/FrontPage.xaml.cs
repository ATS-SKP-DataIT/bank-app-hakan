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
        public FrontPage()
        {
            InitializeComponent();

            Title = "Bank Application";
            BackgroundColor = Color.DarkSlateBlue;
            int currentBalance = 15000;
            int accountNumber = 1293923942;
            string accountName = "Main Account";

            Frame depositLayout = new Frame {
                Padding = 1,
                CornerRadius = 3,
                Content = new StackLayout
                {
                    Spacing = 3,
                    BackgroundColor = Color.DarkSlateBlue,
                    Children =
                    {
                        LabelMaker($"Deposit Amount:", 18, TextAlignment.Start, TextAlignment.Start, Color.White, FontAttributes.None),
                        new Entry{}
                    }
                }
            };

            var underLayout = new StackLayout
            {
                Margin = new Thickness(10),
                Spacing = 25,
                BackgroundColor = Color.DarkSlateBlue,
                Children =
                {
                    LabelMaker($"Account Name: {accountName}", 14, TextAlignment.Center, TextAlignment.Start, Color.White, FontAttributes.None),
                    new Frame{
                        Padding = 1,
                        CornerRadius = 3,
                        Content = new StackLayout
                        {
                            Spacing = 3,
                            BackgroundColor = Color.DarkSlateBlue,
                            Children =
                            {

                                LabelMaker($"Account Number: {accountNumber}", 14, TextAlignment.Center, TextAlignment.Start, Color.White, FontAttributes.None),
                                LabelMaker($"Current Balance: {currentBalance}", 18, TextAlignment.Center, TextAlignment.Start, Color.White, FontAttributes.Bold),
                                AccountDropDown(accountNumber),
                            }
                        },
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

        private Picker AccountDropDown(int accountNumber)
        {
            List<string> AccountInfo = new List<string>();
            AccountInfo.Add(accountNumber.ToString());
            var _picker = new Picker();
            foreach (var item in AccountInfo)
            {
                _picker.Items.Add(item);
            }
            _picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            return _picker;
        }
    } 
}