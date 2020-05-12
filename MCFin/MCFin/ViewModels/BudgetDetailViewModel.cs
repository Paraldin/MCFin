using MCFin.Core;
using MCFin.Models;
using Microcharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Entry = Microcharts.Entry;

namespace MCFin.ViewModels
{
    class BudgetDetailViewModel : BaseViewModel
    {
        public Budget Budget { get; private set; }
        public ObservableCollection<Transaction> transactions { get; private set; }
        public RadialGaugeChart Chart { get; private set; }

        INavigation _navigation;
        public BudgetDetailViewModel(Budget budget, INavigation nav)
        {
            Budget = budget;
            _navigation = nav;
            transactions = new ObservableCollection<Transaction>();
        }

        public async Task RefreshBudget(Budget budget)
        {
            CreateChart(budget);
            await GetBudgetTransactions(budget.Id);
        }

        private void CreateChart(Budget budget)
        {
            List<Entry> entries = new List<Entry>
        {
            new Entry((float)budget.CurrentBalance){ Color=SkiaSharp.SKColor.Parse("#DB8918") }
        };
            Chart = new RadialGaugeChart { Entries = entries, MaxValue = (float)budget.Amount, BackgroundColor = SkiaSharp.SKColor.Parse("#00FFFFFF") };
        }

        private async Task GetBudgetTransactions(int budgetId)
        {
            List<Transaction> budgetTrans = await ApiCore.GetBudgetTransactions(budgetId);
            transactions = new ObservableCollection<Transaction>(budgetTrans);
        }
    }
}
