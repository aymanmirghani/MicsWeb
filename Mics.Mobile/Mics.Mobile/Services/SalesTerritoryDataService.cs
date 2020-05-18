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

    public class SalesTerritoryDataService : IDataStore<SalesTerritory>
    {
        HttpClient client;
        IEnumerable<SalesTerritory> data;
        
        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet || Connectivity.NetworkAccess == NetworkAccess.Local;
        public SalesTerritoryDataService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");
            data = new List<SalesTerritory>();
            
        }

        public Task<bool> AddItemAsync(SalesTerritory item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(SalesTerritory item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<SalesTerritory> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SalesTerritory>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"micswebapi/api/salesterritories").ConfigureAwait(false);
                data = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<SalesTerritory>>(json)).ConfigureAwait(false);
            }
            
            return data;
        }
    }
}
