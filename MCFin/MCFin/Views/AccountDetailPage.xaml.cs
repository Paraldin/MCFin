using MCFin.Core;
using MCFin.Models;
using MCFin.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MCFin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountDetailPage : ContentPage
    {
        int acctId;
        AccountDetailViewModel vm { get; set; }
        public AccountDetailPage(PersonalAccount account)
        {
            vm = new AccountDetailViewModel(account, Navigation);

            BindingContext = vm;

            acctId = account.Id;

            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            await vm.GetTransactions(acctId);
            transactionList.ItemsSource = vm.transactionCollection;

            base.OnAppearing();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushModalAsync(new TransactionDetailPage((Transaction)e.Item));

            ((ListView)sender).SelectedItem = null;
        }

        
    }
}