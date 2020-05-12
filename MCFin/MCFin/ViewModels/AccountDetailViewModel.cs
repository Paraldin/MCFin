using MCFin.Core;
using MCFin.Models;
using MCFin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MCFin.ViewModels
{
    public class AccountDetailViewModel : BaseViewModel
    {
        public Command AddTransaction { get; }
        public PersonalAccount personalAccount { get; private set; }
        public ObservableCollection<TransactionViewModel> transactionCollection { get; private set; }
        INavigation _navigation;
        public AccountDetailViewModel(PersonalAccount account, INavigation nav)
        {
            personalAccount = account;
            _navigation = nav;
            AddTransaction = new Command(async () => await CreateTransaction());
        }

        private async Task CreateTransaction()
        {
            await _navigation.PushAsync(new CreateTransactionPage(personalAccount.Id, this));
        }

        public async Task GetTransactions(int acctId)
        {
            List<Transaction> transactions = await ApiCore.GetAccountTransactions(acctId);
            transactions = transactions.OrderByDescending(t => t.Date).ToList();
            transactionCollection = new ObservableCollection<TransactionViewModel>();
            foreach(var trans in transactions)
            {
                var transVM = new TransactionViewModel();
                transVM.BaseTransaction = trans;
                transVM.Color = trans.Reconciled ? "#c0fce3" : "#ffcccc";
                transactionCollection.Add(transVM);
            }
        }
    }
}
