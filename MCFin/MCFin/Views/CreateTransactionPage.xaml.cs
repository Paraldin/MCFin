using MCFin.Models;
using MCFin.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MCFin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateTransactionPage : ContentPage
    {
        CreateTransactionViewModel ViewModel { get; set; }
        int acctId;
        public CreateTransactionPage()
        {
            ViewModel = new CreateTransactionViewModel();

            InitializeComponent();

            accountPicker.ItemsSource = ViewModel.accountList;
            categoryPicker.ItemsSource = ViewModel.categoryList;
            budgetPicker.ItemsSource = ViewModel.budgetList;
        }

        public CreateTransactionPage(int Id, AccountDetailViewModel vm)
        {
            ViewModel = new CreateTransactionViewModel();
            acctId = Id;
            InitializeComponent();

            accountPicker.ItemsSource = ViewModel.accountList;
            categoryPicker.ItemsSource = ViewModel.categoryList;
            budgetPicker.ItemsSource = ViewModel.budgetList;
            accountSection.IsVisible = false;
        }

        private void submitButton_Clicked(object sender, EventArgs e)
        {
            submitButton.IsEnabled = false;
            var transaction = new PostTransaction
            {
                Description = descriptionEntry.Text,
                Date = (DateTimeOffset)datePicker.Date,
                Amount = Convert.ToDecimal(amountEntry.Text),
                Type = expenseBox.IsChecked,
                AccountId = accountPicker.SelectedItem == null ? acctId : (accountPicker.SelectedItem as PersonalAccount).Id,
                CategoryId = (categoryPicker.SelectedItem as Category).Id,
                EnteredById = Constants.APIConstants.UserId,
                BudgetItemId = budgetPicker.SelectedItem != null ? (budgetPicker.SelectedItem as Budget).Id : 0
            };

            ViewModel.CreateTransaction(transaction);
            App.dashboardViewModel.CallAllLists();
            Navigation.PopAsync();
        }
    }
}