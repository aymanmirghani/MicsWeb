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
    public class WebApiDataService : IDataStore<Mics.Web.Api.Customer>, IDataStore<Mics.Web.Api.CustomerView>,IDataStore<Mics.Web.Api.Product>
    {
        HttpClient client;
        IEnumerable<CustomerView> custview;
        IEnumerable<Customer> customers;
        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public WebApiDataService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");
            custview = new List<CustomerView>();
            customers = new List<Customer>();
        }

        #region Customer
        public Task<bool> AddItemAsync(Customer item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddItemAsync(CustomerView item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddItemAsync(Product item)
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
                var json = await client.GetStringAsync($"micswebapi/api/customers");
                customers = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Customer>>(json));


            }
            return customers;
        }

        public Task<bool> UpdateItemAsync(Customer item)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region CustomerView
        public Task<bool> UpdateItemAsync(CustomerView item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Product item)
        {
            throw new NotImplementedException();
        }

        Task<CustomerView> IDataStore<CustomerView>.GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<Product> IDataStore<Product>.GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<CustomerView>> IDataStore<CustomerView>.GetItemsAsync(bool forceRefresh)
        {
            if(forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"micswebapi/api/customers");
                custview = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<CustomerView>>(json));


            }
            return custview;
        }

        Task<IEnumerable<Product>> IDataStore<Product>.GetItemsAsync(bool forceRefresh)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
