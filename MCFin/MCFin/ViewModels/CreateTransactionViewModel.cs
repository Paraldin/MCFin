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
        public List<PersonalAccount> testList;
        public ObservableCollection<Category> categoryList;

        public CreateTransactionViewModel()
        {
            testList = new List<PersonalAccount>
                {
                     new PersonalAccount { Id = 1, Name = "Test Account 1", Balance = (decimal)352.33, ReconciledBalance = (decimal)381.34 },
                    new PersonalAccount { Id = 2, Name = "Test Account 2", Balance = (decimal)3112.33, ReconciledBalance = (decimal)381.34 },
                    new PersonalAccount { Id = 3, Name = "Test Account 3", Balance = (decimal)152.47, ReconciledBalance = (decimal)381.34 },
                    new PersonalAccount { Id = 4, Name = "Test Account 4", Balance = (decimal)3052.33, ReconciledBalance = (decimal)3081.34 },
                    new PersonalAccount { Id = 5, Name = "Test Retirement", Balance = 320000, ReconciledBalance = 320000 }
                };

            categoryList = new ObservableCollection<Category>();
            GetCategories();
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
    }
}
