using MCFin.Models;
using MCFin.ViewModels;
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
    public partial class CreatePage : ContentPage
    {
        public CreatePage()
        {
            InitializeComponent();
            ViewModel = new CreatePageViewModel(Navigation);
        }

        private CreatePageViewModel ViewModel
        {
            get { return (CreatePageViewModel)BindingContext; }
            set { BindingContext = value; }
        }
    }
}