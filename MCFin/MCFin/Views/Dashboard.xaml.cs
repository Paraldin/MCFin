using MCFin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entry = Microcharts.Entry;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using MCFin.Models;

namespace MCFin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();

            DashboardViewModel vm = new DashboardViewModel(Navigation);
            BindingContext = vm;
            ChartOne.Chart = new DonutChart() { Entries = vm.entries, HoleRadius = .8f, LabelTextSize = 30, BackgroundColor = SkiaSharp.SKColor.Parse("#00FFFFFF") };
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                var selectedItem = e.SelectedItem as PersonalAccount;
                await Navigation.PushAsync(new AccountDetailPage(selectedItem));
            }
            
        }
        private async void BudgetList_ItemTappedAsync(object sender, ItemTappedEventArgs e)
        {
            var budget = (Budget)e.Item;

            await Navigation.PushAsync(new BudgetDetailPage(budget));

            budgetList.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            accountList.SelectedItem = null;

            base.OnAppearing();
        }

    }
}