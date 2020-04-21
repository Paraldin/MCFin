using MCFin.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MCFin.ViewModels
{
    class CreatePageViewModel : BaseViewModel
    {
        public ICommand NewCreatePage { get; }
        INavigation _navigation;
        public CreatePageViewModel(INavigation nav)
        {
            _navigation = nav;
            NewCreatePage = new Command<string>(async (param) => await RenderCreatePage(param));
        }

        private async Task RenderCreatePage(string param)
        {
            Page page;
            switch (param)
            {
                case "account":
                    page = new CreateAccountPage();
                    break;
                case "category":
                    page = new CreateCategoryPage();
                    break;
                case "budget":
                    page = new CreateBudgetPage();
                    break;
                default:
                    page = new CreateTransactionPage();
                    break;
            }
            await _navigation.PushAsync(page);
        }
    }
}
