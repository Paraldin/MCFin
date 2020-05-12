using MCFin.Constants;
using MCFin.Core;
using MCFin.Helpers;
using MCFin.Models;
using MCFin.Services;
using MCFin.ViewModels;
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
            BindingContext = new LoginPageViewModel(this);
        }

        private void entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoginForm_UsernameError.IsVisible = false;
            LoginForm_PasswordError.IsVisible = false;
            loginMessage.IsVisible = false;
        }

        private void Username_Completed(object sender, EventArgs e)
        {
            passwordEntry.Focus();
        }
    }
}
