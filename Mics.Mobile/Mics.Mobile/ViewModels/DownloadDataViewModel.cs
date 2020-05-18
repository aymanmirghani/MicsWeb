using Mics.Mobile.Data;
using Mics.Mobile.Services;
using Mics.Web.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Mics.Mobile.ViewModels
{
    public class DownloadDataViewModel: BaseViewModel
    {
        public ObservableCollection<Customer> customers { get; set; }
        public ObservableCollection<SalesTerritory> salesTerritories { get; set; }
        public ObservableCollection<CustomerView> customersView { get; set; }
        public ObservableCollection<ProductCategory> productCatetories { get; set; }
        public ObservableCollection<ProductSubcategory> productSubcategories { get; set; }
        public ObservableCollection<Product> products { get; set; }
        public ObservableCollection<SpecialOffer> specialOffers { get; set; }
        public ObservableCollection<SpecialOfferProduct> specialOfferProducts { get; set; }
        public ObservableCollection<SalesOrderHeader> salesOrderHeaders { get; set; }
        public ObservableCollection<SalesOrderDetail> salesOrderDetails { get; set; }
        public bool SyncCustomers { get; set; }
        public bool SyncProducts { get; set; }
        public bool SyncOrders { get; set; }
        public float DownloadProgress { get; set; }


        public DownloadDataViewModel()
        {
            customers = new ObservableCollection<Customer>();
            salesTerritories = new ObservableCollection<SalesTerritory>();
            customersView = new ObservableCollection<CustomerView>();
            productCatetories = new ObservableCollection<ProductCategory>();
            productSubcategories = new ObservableCollection<ProductSubcategory>();
            products = new ObservableCollection<Product>();
            specialOffers = new ObservableCollection<SpecialOffer>();
            specialOfferProducts = new ObservableCollection<SpecialOfferProduct>();
            SyncCustomers = true;
            SyncProducts = true;
            SyncOrders = true;
        }
        public async void DownloadCustomers()
        {
            try
            {
                //Load territories
                SalesTerritoryDataService service = new SalesTerritoryDataService();
                var territorData = await service.GetItemsAsync(true).ConfigureAwait(false);
                DownloadProgress = (float)0.1;
                using (SalesTerritoryRepository terRep = new SalesTerritoryRepository())
                {
                    List<SalesTerritory> list = new List<SalesTerritory>();
                    foreach (var ter in territorData)
                    {
                        salesTerritories.Add(ter);
                        list.Add(ter);
                        // await terRep.DeleteAsync(ter.TerritoryID).ConfigureAwait(false);
                        // await terRep.InsertAsync(ter).ConfigureAwait(false);
                    }
                    var added = terRep.InsertBulkAsync(list);
                    DownloadProgress = (float)0.2;

                }
                CustomerDataService custService = new CustomerDataService();
                var custData = await custService.GetItemsAsync(true).ConfigureAwait(false);
                DownloadProgress = (float)0.4;
                if (custData != null && custData.Any())
                {
                    using (var db = new CustomerRepository())
                    {
                        db.InsertBulkAsync(custData.ToList());
                        DownloadProgress = (float)0.55;
                    }

                }
                
                
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        public static List<Customer> GetCustomersFromLocalDb()
        {
            List<Customer> ret = new List<Customer>();
            using(var db = new CustomerRepository()) 
            {
                var data = db.GeAllAsync();
                ret = data.Result.ToList();
            }
            return ret;
        }

        public async void DownloadProducts()
        {
            try
            {
                using (ProductDataService prodService = new ProductDataService())
                {
                    var prodData = await prodService.GetItemsAsync(true).ConfigureAwait(false);
                    DownloadProgress = (float)0.4;
                    if (prodData != null && prodData.Any())
                    {
                        using (var db = new ProductRepository())
                        {
                            db.InsertBulkAsync(prodData.ToList());
                            DownloadProgress = (float)0.55;
                        }

                    }
                }
              
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        public async void DownloadOrders()
        {

        }

    }
}
