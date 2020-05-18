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
    public class ProductCategoryDataService : IDataStore<ProductCategory>, IDisposable
    {
        HttpClient client;
        IEnumerable<ProductCategory> data;
        string serviceUrl;

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet || Connectivity.NetworkAccess == NetworkAccess.Local;
        public ProductCategoryDataService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");
            serviceUrl = $"micswebapi/api/productcategories";
            data = new List<ProductCategory>();

        }
        public Task<bool> AddItemAsync(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (client != null)
                client.Dispose();
        }

        public async Task<ProductCategory> GetItemAsync(string id)
        {
            ProductCategory item = null ;
            if (IsConnected)
            {

                var json = await client.GetStringAsync(serviceUrl+ $"/{id}").ConfigureAwait(false);
                item = await Task.Run(() => JsonConvert.DeserializeObject<ProductCategory>(json)).ConfigureAwait(false);

            }
            return item;
        }

        public async Task<IEnumerable<ProductCategory>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
               
                    var json = await client.GetStringAsync(serviceUrl).ConfigureAwait(false);
                    data = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<ProductCategory>>(json)).ConfigureAwait(false);
                
                
            }
            return data;
        }

        public Task<bool> UpdateItemAsync(ProductCategory item)
        {
            throw new NotImplementedException();
        }
    }
}
