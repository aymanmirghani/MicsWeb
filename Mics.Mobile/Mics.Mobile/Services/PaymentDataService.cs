using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mics.Web.Api;
using Xamarin.Essentials;

namespace Mics.Mobile.Services
{
    public class PaymentDataService : IDataStore<Payment>, IDisposable
    {
        HttpClient client;
        IEnumerable<Payment> data;

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet || Connectivity.NetworkAccess == NetworkAccess.Local;
        public PaymentDataService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");
            data = new List<Payment>();

        }
        public Task<bool> AddItemAsync(Payment item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Payment item)
        {
            throw new NotImplementedException();
        }
    }
}
