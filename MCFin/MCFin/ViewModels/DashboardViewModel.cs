using MCFin.Core;
using MCFin.Models;
using MCFin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Entry = Microcharts.Entry;
using Microcharts;
using System.Linq;

namespace MCFin.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        //Comand names go here
        public Command SeeAllTransactions { get; }
        public Command GoToCreate { get; }
        public ObservableCollection<Budget> testBudgets { get; private set; } 
        public ObservableCollection<PersonalAccount> accountList { get; private set; }
        public List<Entry> entries { get; private set; }
        INavigation _navigation; 
        public DashboardViewModel(INavigation nav)
        {
            //Commands calls go here
            SeeAllTransactions = new Command(async () => await SeeTransactions());
            GoToCreate = new Command(async () => await RenderCreate());
            _navigation = nav;
            CallAccountList();
            CallHouseTransactions();
            CallBudgetList();
        }

        List<string> _colors = new List<string>()
        {
            "#001aad",
            "#eb9900",
            "#980094",
            "#f66227",
            "#d30070",
            "#f00c4a"
        };

        private void CallAccountList()
        {
            List<PersonalAccount> accounts = ApiCore.GetPersonalAccounts(1).Result;
            accountList = new ObservableCollection<PersonalAccount>(accounts);
        }

        private void CallBudgetList()
        {
            List<Budget> budgets = ApiCore.GetHouseholdBudgets(1).Result;
            testBudgets = new ObservableCollection<Budget>(budgets);
        }

        private void CallHouseTransactions()
        {
            List<Transaction> transactions = ApiCore.GetHouseholdTransactions(1, DateTimeOffset.Now.Month, DateTimeOffset.Now.Year).Result;

            entries = new List<Entry>();
            var categoryValues = new Dictionary<string, decimal>();
            var uniqueCategories = transactions.Select(t => t.CatName).Distinct();
            foreach(var cat in uniqueCategories)
            {
                if(cat != "Transfer")
                {
                    decimal total = Math.Ceiling(transactions.Where(t => t.CatName == cat).Select(t => Math.Abs(t.Amount)).Sum());
                    categoryValues.Add(cat, total);
                }
            }
            categoryValues = categoryValues.OrderByDescending(c => c.Value).Take(6).ToDictionary(l => l.Key, v => v.Value);
            int counter = 0;
            foreach(KeyValuePair<string, decimal> category in categoryValues)
            {
                entries.Add(new Entry((float)category.Value) { Color = SkiaSharp.SKColor.Parse(_colors[counter]), Label=category.Key, ValueLabel=$"{category.Value}" });
                counter++;
            }
        }

        //Command Implementation goes here
        private async Task SeeTransactions() 
        {
            await _navigation.PushAsync(new AllTransactionsPage());
        }

        private async Task RenderCreate()
        {
            await _navigation.PushAsync(new CreatePage());
        }
    }
}
