using MCFin.Models;
using MCFin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MCFin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BudgetDetailPage : ContentPage
    {
        private Budget _budget;
        private BudgetDetailViewModel ViewModel;
        public BudgetDetailPage(Budget budget)
        {
            _budget = budget;
            ViewModel = new BudgetDetailViewModel(budget, Navigation);
            InitializeComponent();
            BindingContext = ViewModel;
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new TransactionDetailPage(((Transaction)e.Item), _budget));

            ((ListView)sender).SelectedItem = null;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.RefreshBudget(_budget);
            transactionList.ItemsSource = ViewModel.transactions;
            ChartOne.Chart = ViewModel.Chart;
        }
    }
}