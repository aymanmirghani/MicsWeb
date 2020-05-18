using Mics.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mics.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerViewDetailsPage : ContentPage
    {
        CustomerViewDetailsModel viewModel;
        public CustomerViewDetailsPage(CustomerViewDetailsModel vm)
        {
            InitializeComponent();
            BindingContext = viewModel = vm;
        }

        private void NewOrder_Clicked(object sender, EventArgs e)
        {

        }

        private void ViewOrders_Clicked(object sender, EventArgs e)
        {

        }

        private void Payments_Clicked(object sender, EventArgs e)
        {

        }
    }
}