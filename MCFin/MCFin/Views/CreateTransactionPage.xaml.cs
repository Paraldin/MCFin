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
        AccountDetailViewModel AccountDetail { get; set; }
        public CreateTransactionPage()
        {
            ViewModel = new CreateTransactionViewModel();

            InitializeComponent();

            accountPicker.ItemsSource = ViewModel.testList;
            categoryPicker.ItemsSource = ViewModel.categoryList;
        }

        public CreateTransactionPage(int Id, AccountDetailViewModel vm)
        {
            ViewModel = new CreateTransactionViewModel();
            AccountDetail = vm;
            InitializeComponent();

            accountPicker.ItemsSource = ViewModel.testList;
            categoryPicker.ItemsSource = ViewModel.categoryList;
            accountPicker.SelectedItem = SelectedAccount(Id);
        }

        private PersonalAccount SelectedAccount(int Id)
        {
                accountSection.IsVisible = false;
                return ViewModel.testList.FirstOrDefault(a => a.Id == Id);
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
                AccountId = (accountPicker.SelectedItem as PersonalAccount).Id,
                CategoryId = (categoryPicker.SelectedItem as Category).Id,
                EnteredById = "7a076858-6d59-457b-832b-65386b5ce532",
                BudgetItemId = budgetPicker.SelectedItem != null ? (budgetPicker.SelectedItem as Category).Id : 0
            };

            ViewModel.CreateTransaction(transaction);
            Navigation.PopAsync();
        }
    }
}