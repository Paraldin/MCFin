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
    public partial class TransactionDetailPage : ContentPage
    {
        public TransactionDetailPage(Transaction trans)
        {
            TransactionDetailViewModel vm = new TransactionDetailViewModel(trans, Navigation);

            BindingContext = vm;
            InitializeComponent();
        }
    }
}