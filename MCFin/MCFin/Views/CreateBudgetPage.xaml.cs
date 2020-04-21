using MCFin.Core;
using MCFin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MCFin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateBudgetPage : ContentPage
    {
        public CreateBudgetPage()
        {
            InitializeComponent();
        }

        private async void submitButton_Clicked(object sender, EventArgs e)
        {
            Budget budget = new Budget
            {
                HouseholdId = 1,
                Amount = Convert.ToDecimal(amountEntry.Text),
                Name = nameEntry.Text
            };

            await ApiCore.PostBudget(budget);
            await Navigation.PopAsync();
        }
    }
}