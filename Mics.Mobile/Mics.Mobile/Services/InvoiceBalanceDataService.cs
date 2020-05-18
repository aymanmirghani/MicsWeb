using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mics.Web.Api;
using Xamarin.Essentials;

namespace Mics.Mobile.Services
{
    public class InvoiceBalanceDataService : IDataStore<InvoicesBalance_View>, IDisposable
    {
        HttpClient client;
        IEnumerable<InvoicesBalance_View> data;

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet || Connectivity.NetworkAccess == NetworkAccess.Local;
        public InvoiceBalanceDataService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");
            data = new List<InvoicesBalance_View>();

        }
        public Task<bool> AddItemAsync(InvoicesBalance_View item)
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

        public Task<InvoicesBalance_View> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InvoicesBalance_View>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(InvoicesBalance_View item)
        {
            throw new NotImplementedException();
        }
    }
}
