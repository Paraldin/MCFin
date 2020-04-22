using MCFin.Constants;
using MCFin.Core;
using MCFin.Services;
using MCFin.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MCFin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            await Login();
        }
        private async Task Login()
        {
            loginButton.IsEnabled = false;
            try
            {
                var result = await ApiCore.Authenticate(emailEntry.Text, passwordEntry.Text);
                var userInfo = await ApiServices.EncodedGetData(result.Access_Token);
                APIConstants.HouseId = userInfo.HouseId;
                APIConstants.UserId = userInfo.GuidId;
                loginMessage.IsVisible = false;
                await Navigation.PushAsync(new Dashboard());
                loginButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                loginMessage.IsVisible = true;
                loginMessage.Text = ex.Message;
            }
        }

        private void entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!loginButton.IsEnabled)
            {
                loginButton.IsEnabled = true;
            }
        }
    }
}
