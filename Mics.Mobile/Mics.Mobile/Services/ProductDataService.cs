using Mics.Web.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Mics.Mobile.Services
{
    public class ProductDataService : IDataStore<Product>, IDisposable
    { 

        HttpClient client;
        IEnumerable<Product> data;
        
        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet || Connectivity.NetworkAccess == NetworkAccess.Local;
        public ProductDataService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");
            data = new List<Product>();

        }
    public Task<bool> AddItemAsync(Product item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetItemAsync(string id)
        {
            var json = await client.GetStringAsync($"micswebapi/api/products/{id}").ConfigureAwait(false);
            var item = await Task.Run(() => JsonConvert.DeserializeObject<Product>(json)).ConfigureAwait(false);

            return item;
        }

        public async Task<IEnumerable<Product>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"micswebapi/api/products").ConfigureAwait(false);
                data = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Product>>(json)).ConfigureAwait(false);
            }
            return data;
        }

        public Task<bool> UpdateItemAsync(Product item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (client != null)
                client.Dispose();
        }
    }
}
