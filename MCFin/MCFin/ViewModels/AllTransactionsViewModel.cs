using MCFin.Core;
using MCFin.Models;
using MCFin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MCFin.ViewModels
{
    class AllTransactionsViewModel : BaseViewModel
    {
        public ObservableCollection<Transaction> transactions { get; private set; }
        public ICommand ViewTransaction { get; }
        INavigation _navigation;

        public AllTransactionsViewModel(INavigation nav)
        {
            _navigation = nav;
            ViewTransaction = new Command<Transaction>(vm => TransactionDetail(vm));
            GetAllTransactions();

        }
        private void GetAllTransactions()
        {
            List<Transaction> allTransactions = ApiCore.GetHouseholdTransactions(1,0,0).Result;
            allTransactions = allTransactions.OrderByDescending(t => t.Date).ToList();
            transactions = new ObservableCollection<Transaction>(allTransactions);
        }

        private async void TransactionDetail(Transaction transaction)
        {
            await _navigation.PushModalAsync(new TransactionDetailPage(transaction));
        }
    }
}
