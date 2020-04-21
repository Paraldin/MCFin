using MCFin.Core;
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
    public partial class CreateCategoryPage : ContentPage
    {
        public CreateCategoryPage()
        {
            InitializeComponent();
        }

        private async void submitButton_Clicked(object sender, EventArgs e)
        {
            await ApiCore.PostCategory((1), (nameEntry.Text));
            await Navigation.PopAsync();
        }
    }
}