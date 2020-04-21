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
        public ObservableCollection<Transaction> transactionCollection { get; private set; }
        INavigation _navigation;
        public AccountDetailViewModel(PersonalAccount account, INavigation nav)
        {
            personalAccount = account;
            _navigation = nav;
            AddTransaction = new Command(async () => await CreateTransaction());
            transactionCollection = new ObservableCollection<Transaction>();
        }

        private async Task CreateTransaction()
        {
            await _navigation.PushAsync(new CreateTransactionPage(personalAccount.Id, this));
        }

        public async Task GetTransactions(int acctId)
        {
            List<Transaction> transactions = await ApiCore.GetAccountTransactions(acctId);
            transactionCollection.Clear();
            transactions = transactions.OrderByDescending(t => t.Date).ToList();
            foreach(var t in transactions)
            {
                transactionCollection.Add(t);
            }
        }
    }
}
