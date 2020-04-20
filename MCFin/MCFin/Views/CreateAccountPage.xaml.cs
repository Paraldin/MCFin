using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static MCFin.Models.PersonalAccount;

namespace MCFin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccountPage : ContentPage
    {
        public CreateAccountPage()
        {
            InitializeComponent();
        }

        private void submitButton_Clicked(object sender, EventArgs e)
        {
            var newAccount = new PostAccount
            {
                HHid = 1,
                AccountName = accountEntry.Text,
                AccountBalance = Convert.ToDecimal(balanceEntry.Text)
            };
        }
    }
}