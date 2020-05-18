using Microsoft.EntityFrameworkCore;
using Mics.Web.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mics.Mobile.Services
{
    public class SqliteDataService : DbContext,IDataStore<Customer>
    {
        string _dbpath;
        public SqliteDataService(string dbPath)
        {
            _dbpath = dbPath;
            this.Database.EnsureCreated();;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerView> CustomerViews { get; set; }
        public DbSet<Product> Products { get; set; }

        public async Task<bool> AddItemAsync(Customer item)
        {
            Customers.Add(item);
            var result = await SaveChangesAsync().ConfigureAwait(false);
            return result > 0;
        }
        public async Task<bool> AddItemAsync(CustomerView item)
        {
            
            CustomerViews.Add(item);
            
            var result = await SaveChangesAsync().ConfigureAwait(false);
            return result > 0;
        }
        public async  Task<bool> AddItemsAsync(IEnumerable<CustomerView> items)
        {

            CustomerViews.AddRange(items);

            var result = await SaveChangesAsync().ConfigureAwait(false);
            return true;
        }
        public async Task<bool> CommitData()
        {
            var result = await SaveChangesAsync().ConfigureAwait(false);
            return result > 0;
        }
        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetItemAsync(string id)
        {
            var data = await Customers.FirstOrDefaultAsync(a => a.CustomerID == Int32.Parse(id)).ConfigureAwait(false);
            return data;
        }

        public async Task<IEnumerable<Customer>> GetItemsAsync(bool forceRefresh = false)
        {
           var data = await Customers.ToListAsync().ConfigureAwait(false);
            return data;
        }

        public async Task<bool> UpdateItemAsync(Customer item)
        {
            
            Customers.Update(item);
            var result = await SaveChangesAsync().ConfigureAwait(false);
            return result >= 0;
        }

        public Task<bool> UpdateItemAsync(CustomerView item)
        {
            throw new NotImplementedException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlite($"Filename={_dbpath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(a => a.CustomerID);
            modelBuilder.Entity<CustomerView>().HasKey(a => a.CustomerID);
            modelBuilder.Entity<Product>().HasKey(a => a.ProductID);
            modelBuilder.Entity<SalesOrderHeader>().HasKey(a => a.SalesOrderID);
            modelBuilder.Entity<SalesOrderDetail>().HasKey(a => a.SalesOrderDetailID);
            modelBuilder.Entity<SalesTerritory>().HasKey(a => a.TerritoryID);

            modelBuilder.Entity<Customer>().Property(a => a.Name).IsRequired();
        }

       

       
    }
}
