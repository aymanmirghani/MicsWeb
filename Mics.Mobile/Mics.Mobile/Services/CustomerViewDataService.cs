using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Mics.Mobile.Models;
using Mics.Web.Api;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace Mics.Mobile.Services
{
    public class CustomerViewDataService : IDataStore<CustomerView>
    {
        HttpClient client;
        IEnumerable<CustomerView> custview;
        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public CustomerViewDataService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");
            custview = new List<CustomerView>();
        }
        public Task<bool> AddItemAsync(CustomerView item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerView> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerView>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"micswebapi/api/customerviews");
                custview = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<CustomerView>>(json));
                

            }
            return custview;
        }

        public Task<bool> UpdateItemAsync(CustomerView item)
        {
            throw new NotImplementedException();
        }
    }
}
