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
        public BudgetDetailPage(Budget budget)
        {
            var vm = new BudgetDetailViewModel(budget, Navigation);
            InitializeComponent();
            BindingContext = vm;
            ChartOne.Chart = vm.Chart;
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushModalAsync(new TransactionDetailPage((Transaction)e.Item));

            ((ListView)sender).SelectedItem = null;
        }
    }
}