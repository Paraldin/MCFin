using MCFin.Core;
using MCFin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MCFin.ViewModels
{
    class CreateTransactionViewModel
    {
        public ObservableCollection<PersonalAccount> accountList;
        public ObservableCollection<Category> categoryList;
        public ObservableCollection<Budget> budgetList;

        public CreateTransactionViewModel()
        {
            categoryList = new ObservableCollection<Category>();
            GetCategories();
            GetBudgets();
            GetAccounts();
        }

        public async void CreateTransaction(PostTransaction trans)
        {
            await ApiCore.PostTransaction(trans.Description, trans.Date, trans.Amount, trans.Type, trans.AccountId, trans.CategoryId, trans.EnteredById, trans.BudgetItemId);
        }
        public async void GetCategories()
        {
            var categories = await ApiCore.GetHouseholdCategories(1);
            foreach(var cat in categories)
            {
                categoryList.Add(cat);
            }
        }

        public async void GetBudgets()
        {
            var categories = await ApiCore.GetHouseholdBudgets(1);
            budgetList = new ObservableCollection<Budget>(categories);
        }
        public async void GetAccounts()
        {
            var accounts = await ApiCore.GetPersonalAccounts(1);
            accountList = new ObservableCollection<PersonalAccount>(accounts);
        }
    }
}
