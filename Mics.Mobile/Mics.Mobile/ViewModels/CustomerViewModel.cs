using Mics.Mobile.Data;
using Mics.Mobile.Views;
using Mics.Web.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mics.Mobile.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }
        public ObservableCollection<CustomerView> custViews { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CustomerViewModel()
        {
            Title = "Customers";
            Customers = new ObservableCollection<Customer>();
            custViews = new ObservableCollection<CustomerView>();
            // LoadCustomers();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Customer>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Customer;
                Customers.Add(newItem);
                await CustomerDataStore.AddItemAsync(newItem);
            });
        }
        public async void LoadCustomers()
        {
            var data = await CustomerDataStore.GetItemsAsync(true);
        }
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Customers.Clear();
                // var data = await WebApiDataStore.GetItemsAsync(true).ConfigureAwait(false);

               //   var data = await CustomerDataStore.GetItemsAsync(true).ConfigureAwait(false);

                using(var db = new CustomerRepository())
                {
                    var data = await db.GeAllAsync().ConfigureAwait(false);
                    foreach (var cust in data)
                    {
                        Customers.Add(cust);
                        //var r = await CustomerViewSqlLiteDataStore.AddItemAsync(cust);
                    }
                }


               // var data = await sqlDataService.GetItemsAsync(true).ConfigureAwait(false);

                
                //bool r = await sqlDataService.AddItemsAsync(data);
               // var data2 = await sqlDataService.GetItemsAsync(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
