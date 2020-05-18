using Microsoft.EntityFrameworkCore;
using Mics.Web.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mics.Mobile.Data
{
    public class CustomerRepository : IRepository<Customer>, IDisposable
    {
        private DatabaseContext dbContext;

        public CustomerRepository()
        {
            dbContext = new DatabaseContext(App.FilePath);
        }
        public CustomerRepository(string dbPath)
        {
            dbContext = new DatabaseContext(dbPath);
        }
        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var data = dbContext.Customers.Find(id);

                if (data != null)
                {
                    var result = dbContext.Remove(data);
                    await dbContext.SaveChangesAsync().ConfigureAwait(false);
                    return result.State == EntityState.Deleted;
                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
        
        public async Task<IEnumerable<Customer>> GeAllAsync(bool forceRefresh = false)
        {
            try
            {
                var data = await dbContext.Customers.ToListAsync().ConfigureAwait(false);
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Customer> GetByIdAsync(string id)
        {
            try
            {
                var data = await dbContext.Customers.FindAsync(id).ConfigureAwait(false);
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(Customer item)
        {
            try
            {

                if (dbContext.Customers.Find(item.TerritoryID) == null)
                {
                    var result = await dbContext.Customers.AddAsync(item);
                    await dbContext.SaveChangesAsync().ConfigureAwait(false);
                    return result.State == EntityState.Added;
                }
                else
                {
                    var result = dbContext.Customers.Update(item);
                    if (result.State == EntityState.Modified)
                        await dbContext.SaveChangesAsync().ConfigureAwait(false);
                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertBulkAsync(List<Customer> itemList)
        {
            try
            {
                if (itemList == null)
                    return false;
                int ret = 0;
                List<Customer> toInsert = new List<Customer>();
                List<Customer> toUpdate = new List<Customer>();
                foreach (var item in itemList)
                {
                    var found = dbContext.Customers.Find(item.CustomerID);
                    if (found == null)
                    {
                        toInsert.Add(item);
                        
                    }
                    else if (!IsSynchedWith(found, item))
                    {
                        SynchEntity(found, item);
                        toUpdate.Add(found);
                    }

                }
                if (toInsert.Count > 0)
                    dbContext.Customers.AddRange(toInsert);
                if (toUpdate.Count > 0)
                    dbContext.Customers.UpdateRange(toUpdate);

                if (toInsert.Count > 0 || toUpdate.Count > 0)
                    ret = dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool IsSynchedWith(Customer old, Customer entity)
        {
            if (old != null && entity != null)
            {
                if(old.Name != entity.Name) return false;
                if (old.Phone != entity.Phone) return false;
                if (old.TerritoryID != entity.TerritoryID) return false;
                if (old.SecondPhone != entity.SecondPhone) return false;
                if (old.AccountNumber != entity.AccountNumber) return false;
                if (old.ActiveFlag != entity.ActiveFlag) return false;
                if (old.AddressID != entity.AddressID) return false;
                if (old.BillingAddressID != entity.BillingAddressID) return false;
                if (old.ContactName != entity.ContactName) return false;
                if (old.CreditLimit != entity.CreditLimit) return false;
                if (old.CustomerType != entity.CustomerType) return false;
                if (old.DeliveryDay != entity.DeliveryDay) return false;
                if (old.Email != entity.Email) return false;
                if (old.Fax != entity.Fax) return false;

            }
            return true;
        }

        public async Task<IEnumerable<Customer>> QueryAsync(Func<Customer, bool> predicate)
        {
            try
            {
                var data = dbContext.Customers.Where(predicate);
                if (data != null)
                    return data.ToList();
                else
                    return null;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
        }

        public void SynchEntity(Customer old, Customer entity)
        {
            if(old != null && entity != null)
            {
                old.Name = entity.Name;
                old.Phone = entity.Phone;
                old.TerritoryID = entity.TerritoryID;
                old.SecondPhone = entity.SecondPhone;
                old.AccountNumber = entity.AccountNumber;
                old.ActiveFlag = entity.ActiveFlag;
                old.AddressID = entity.AddressID;
                old.BillingAddressID = entity.BillingAddressID;
                old.ContactName = entity.ContactName;
                old.CreditLimit = entity.CreditLimit;
                old.CustomerType = entity.CustomerType;
                old.DeliveryDay = entity.DeliveryDay;
                old.Email = entity.Email;
                old.Fax = entity.Fax;
                
            }
        }

        public async Task<bool> UpdateAsync(Customer item)
        {
            try
            {
                var result = dbContext.Customers.Update(item);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return result.State == EntityState.Modified;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
