using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mics.Web.Api;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace Mics.Mobile.Services
{
    public class ProductSubCategoryDataService : IDataStore<ProductSubcategory>, IDisposable
    {
        HttpClient client;
        IEnumerable<ProductSubcategory> data;
        string serviceUrl;
        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet || Connectivity.NetworkAccess == NetworkAccess.Local;
        public ProductSubCategoryDataService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");
            serviceUrl = $"micswebapi/api/productsubcategories";
            data = new List<ProductSubcategory>();

        }
        public Task<bool> AddItemAsync(ProductSubcategory item)
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

        public async Task<ProductSubcategory> GetItemAsync(string id)
        {
            ProductSubcategory item = null;
            if (IsConnected)
            {

                var json = await client.GetStringAsync(serviceUrl + $"/{id}").ConfigureAwait(false);
                item = await Task.Run(() => JsonConvert.DeserializeObject<ProductSubcategory>(json)).ConfigureAwait(false);
                return item;

            }
            return item;
        }

        public async Task<IEnumerable<ProductSubcategory>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {

                var json = await client.GetStringAsync(serviceUrl).ConfigureAwait(false);
                data = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<ProductSubcategory>>(json)).ConfigureAwait(false);


            }
            return data;
        }

        public Task<bool> UpdateItemAsync(ProductSubcategory item)
        {
            throw new NotImplementedException();
        }
    }
}
