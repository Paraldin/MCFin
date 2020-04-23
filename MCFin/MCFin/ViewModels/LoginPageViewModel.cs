using MCFin.Constants;
using MCFin.Core;
using MCFin.Helpers;
using MCFin.Models;
using MCFin.Services;
using MCFin.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MCFin.ViewModels
{
    class LoginPageViewModel
    {
        public LoginForm LoginModel { get; set; } = new LoginForm();
        public ICommand LoginInCommand { get; }
        private Page _page;
        private string _accessToken;
        public LoginPageViewModel(Page page)
        {
            _page = page;
            LoginInCommand = new Command(() => Login_Clicked());
        }

        private bool LoginAsync()
        {
            return ValidationHelper.IsFormValid(LoginModel, _page);
        }

        private async void Login_Clicked()
        {
            if (LoginAsync())
            {
                await Login();
            }
        }
        private async Task Login()
        {
            var logMessage = _page.FindByName<Label>("loginMessage");
            var submitButton = _page.FindByName<Button>("submitButton");
            submitButton.IsEnabled = false;
            try
            {
                AuthenticatedUser result = await ApiCore.Authenticate(LoginModel.Username, LoginModel.Password);
                await GetUserInfo(result.Access_Token);
                logMessage.IsVisible = false;
                await _page.Navigation.PushAsync(new Dashboard());
            }
            catch (Exception ex)
            {
                logMessage.IsVisible = true;
                logMessage.Text = "Incorrect Username or Password";
            }
            finally
            {
                submitButton.IsEnabled = true;
            }
        }
        private async Task GetUserInfo(string token)
        {
            var userInfo = await ApiServices.EncodedGetData(token);
            APIConstants.HouseId = userInfo.HouseholdId.Value;
            APIConstants.UserId = userInfo.GuidId;
        }
    }
}
