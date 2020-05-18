using Mics.Mobile.ViewModels;
using Mics.Web.Api;
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
    public partial class CustomerPage : ContentPage
    {
        CustomerViewModel viewModel;
        public CustomerPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CustomerViewModel();
        }

        private void CustomerSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = CustomerSearch.Text;
            if (!string.IsNullOrEmpty(keyword))
                CustomersListView.ItemsSource = viewModel.custViews.Where(a => a.Name.ToLower().StartsWith(keyword.ToLower()));
            else
                CustomersListView.ItemsSource = viewModel.custViews;

        }

        private async void CustomersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as CustomerView;
            if (item == null)
                return;

            await Navigation.PushAsync(new CustomerViewDetailsPage(new CustomerViewDetailsModel(item)));

            // Manually deselect item.
            CustomersListView.SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Customers.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}