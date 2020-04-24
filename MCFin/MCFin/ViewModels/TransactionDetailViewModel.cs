using MCFin.Core;
using MCFin.Interfaces;
using MCFin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MCFin.ViewModels
{
    public class TransactionDetailViewModel : BaseViewModel
    {
        INavigation _navigation;
        public Transaction Transaction { get; private set; }
        IHasBalance _model;
        public string Image { get; private set; }
        public Command ReconcileTransaction { get; }
        public Command DeleteTransaction { get; }

        public TransactionDetailViewModel(Transaction transaction, INavigation nav, IHasBalance fromModel)
        {
            _navigation = nav;
            _model = fromModel;

            Transaction = transaction;

            Image = transaction.Reconciled == true ? "checkmark.png" : "xbutton.png";

            ReconcileTransaction = new Command(async () => await Reconcile(transaction.Id));
            DeleteTransaction = new Command(async () => await Delete(transaction.Id));
        }

        public TransactionDetailViewModel(Transaction transaction, INavigation nav)
        {
            _navigation = nav;

            Transaction = transaction;

            Image = transaction.Reconciled == true ? "checkmark.png" : "xbutton.png";

            ReconcileTransaction = new Command(async () => await Reconcile(transaction.Id));
            DeleteTransaction = new Command(async () => await Delete(transaction.Id));
        }

        private async Task Reconcile(int transId)
        {
            Transaction.Reconciled = true;
            await ApiCore.ReconcileTransaction(transId);
            await _navigation.PopAsync();
        }

        private async Task Delete(int transId)
        {
            Transaction.IsDeleted = true;
            if(_model != null)
            _model.UpdateBalance(Transaction.Amount);
            await ApiCore.DeleteTransaction(transId);
            App.dashboardViewModel.CallAllLists();
            await _navigation.PopAsync();
        }
    }
}
