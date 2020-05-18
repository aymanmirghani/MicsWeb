using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Mics.Mobile.Models;
using Mics.Web.Api;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace Mics.Mobile.Services
{
    public class CustomerDataService : IDataStore<Mics.Web.Api.Customer>
    {
        HttpClient client;
        IEnumerable<CustomerView> custview;
        IEnumerable<Customer> customers;

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public CustomerDataService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");
            custview = new List<CustomerView>();
            customers = new List<Customer>();
        }
        public Task<bool> AddItemAsync(Customer item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"micswebapi/api/customers").ConfigureAwait(false);
                customers = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Customer>>(json)).ConfigureAwait(false);
            }
            return customers;
        }

        public Task<bool> UpdateItemAsync(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
