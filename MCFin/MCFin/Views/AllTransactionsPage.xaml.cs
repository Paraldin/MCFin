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
    public partial class AllTransactionsPage : ContentPage
    { 
        public AllTransactionsPage()
        {
            InitializeComponent();
            ViewModel = new AllTransactionsViewModel(Navigation);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ViewModel.ViewTransaction.Execute(e.Item as Transaction);
            ((ListView)sender).SelectedItem = null;
        }

        private AllTransactionsViewModel ViewModel
        {
            get { return BindingContext as AllTransactionsViewModel; }
            set { BindingContext = value; }
        }
    }
}