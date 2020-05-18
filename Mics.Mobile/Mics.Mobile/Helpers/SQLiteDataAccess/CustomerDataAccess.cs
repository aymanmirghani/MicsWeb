using Mics.Web.Api;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mics.Mobile.Helpers.SQLiteDataAccess
{
    public class CustomerDataAccess : IDataAccess<Customer>
    {
        private SQLiteConnection dbConn;
        public CustomerDataAccess()
        {
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            // create the table(s)
            dbConn.CreateTable<Customer>();
           
        }
        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
           return dbConn.Query<Customer>("select * from CustomerView order by name");
          //  throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>>  GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Customer GetByID(string id)
        {
            return dbConn.Query<Customer>($"select * from Customer where CustomerID={id} order by name")[0];
        }

        public Task<Customer> GetByIDAsync(string id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Customer item)
        {
            return dbConn.Insert(item) > 0;
        }

        public Task<bool> InsertAsync(Customer item)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer item)
        {
            return dbConn.Update(item) > 0;
        }

        public Task<bool> UpdateAsync(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
