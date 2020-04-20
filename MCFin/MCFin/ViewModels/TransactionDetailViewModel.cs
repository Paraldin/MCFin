using MCFin.Core;
using MCFin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MCFin.ViewModels
{
    public class TransactionDetailViewModel : BaseViewModel
    {
        INavigation _navigation;
        public Transaction Transaction { get; private set; }
        public string Image { get; private set; }
        public Command ReconcileTransaction { get; }

        public TransactionDetailViewModel(Transaction transaction, INavigation nav)
        {
            _navigation = nav;

            Transaction = transaction;

            Image = transaction.Reconciled == true ? "checkmark.png" : "xbutton.png";

            ReconcileTransaction = new Command(async () => await Reconcile(transaction.Id));
        }

        private async Task Reconcile(int transId)
        {
            Transaction.Reconciled = true;
            await ApiCore.ReconcileTransaction(transId);
            await _navigation.PopModalAsync();
        }
    }
}
