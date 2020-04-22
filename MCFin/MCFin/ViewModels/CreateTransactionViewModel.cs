using MCFin.Core;
using MCFin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            accountList = new ObservableCollection<PersonalAccount>();
            budgetList = new ObservableCollection<Budget>();
            GetCategories();
            GetBudgets();
            GetAccounts();
        }

        public async void CreateTransaction(PostTransaction trans)
        {
            await ApiCore.PostTransaction(trans.Description, trans.Date, trans.Amount, trans.Type, trans.AccountId, trans.CategoryId, trans.EnteredById, trans.BudgetItemId);
            var difference = trans.Type == false ? trans.Amount : trans.Amount * -1;
            App.dashboardViewModel.accountList.FirstOrDefault(a => a.Id == trans.AccountId).Balance += difference;
        }
        public async void GetCategories()
        {
            var categories = await ApiCore.GetHouseholdCategories(Constants.APIConstants.HouseId);
            foreach(var cat in categories)
            {
                categoryList.Add(cat);
            }
        }

        public async void GetBudgets()
        {
            var budgets = await ApiCore.GetHouseholdBudgets(Constants.APIConstants.HouseId);
            foreach(var b in budgets)
            {
                budgetList.Add(b);
            }
        }
        public async void GetAccounts()
        {
            var accounts = await ApiCore.GetPersonalAccounts(Constants.APIConstants.HouseId);
            foreach (var a in accounts)
            {
                accountList.Add(a);
            }
        }
    }
}
