using MCFin.Core;
using MCFin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace MCFin.ViewModels
{
    class CreateTransactionViewModel
    {
        public ObservableCollection<PersonalAccount> accountList;
        public ObservableCollection<Category> categoryList;
        public ObservableCollection<Budget> budgetList;
        private readonly INavigation _nav;

        public CreateTransactionViewModel(INavigation nav)
        {
            categoryList = new ObservableCollection<Category>();
            accountList = new ObservableCollection<PersonalAccount>();
            budgetList = new ObservableCollection<Budget>();
            GetCategories();
            GetBudgets();
            GetAccounts();
            _nav = nav;
        }

        public async void CreateTransaction(PostTransaction trans)
        {
            try
            {
                await ApiCore.PostTransaction(trans.Description, trans.Date, trans.Amount, trans.Type, trans.AccountId, trans.CategoryId, trans.EnteredById, trans.BudgetItemId);
                var difference = trans.Amount;
                App.dashboardViewModel.accountList.FirstOrDefault(a => a.Id == trans.AccountId).Balance += difference;
                if(trans.BudgetItemId != 0)
                {
                    App.dashboardViewModel.testBudgets.FirstOrDefault(a => a.Id == trans.BudgetItemId).CurrentBalance += difference;
                }
                await App.dashboardViewModel.CallHouseTransactions();

            }
            catch (Exception)
            {
                Log.Warning("Danger", "Something went wrong creating transactions");
            }
            finally
            {
                await _nav.PopAsync();
            }
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

        public async Task CreateTransaction()
        {
            

            await _nav.PopAsync();
        }
    }
}
