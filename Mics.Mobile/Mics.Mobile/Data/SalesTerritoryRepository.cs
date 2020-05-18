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
    public class SalesTerritoryRepository : IRepository<SalesTerritory>,IDisposable
    {
        private DatabaseContext dbContext;

        public SalesTerritoryRepository()
        {
            dbContext = new DatabaseContext(App.FilePath);
        }
        public SalesTerritoryRepository(string dbPath)
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
                SalesTerritory data = dbContext.SalesTerritories.Find(id);
                
                if(data != null)
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

        public async Task<IEnumerable<SalesTerritory>> GeAllAsync(bool forceRefresh = false)
        {
            try
            {
                var data = await dbContext.SalesTerritories.ToListAsync().ConfigureAwait(false);
                return data;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public async Task<SalesTerritory> GetByIdAsync(int id)
        {
            try
            {
                SalesTerritory data = await dbContext.SalesTerritories.FindAsync(id).ConfigureAwait(false);
                return data;
            }
            catch (Exception)
            {
                return null;
            }
           
        }

        public Task<SalesTerritory> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public bool InsertBulkAsync(List<SalesTerritory> itemList)
        {
            try
            {
                int insertCount = 0;
                int updateCount = 0;
                int ret = 0;
                List<SalesTerritory> toInsert = new List<SalesTerritory>();
                List<SalesTerritory> toUpdate = new List<SalesTerritory>();
                foreach (var item in itemList)
                {
                    var found = dbContext.SalesTerritories.Find(item.TerritoryID);
                    if(found == null)
                    {
                        toInsert.Add(item); 
                        //var result = dbContext.SalesTerritories.Add(item);
                       // if (result.State == EntityState.Added)
                        //    insertCount++;
                    }
                    else
                    {
                        
                        if(!IsSynchedWith(found, item))
                        {
                            SynchEntity(found, item);
                            toUpdate.Add(found);
                        }
                           
                        //int count = dbContext.SalesTerritories.Count();
                        //var UpdateResult = dbContext.SalesTerritories.Update(item);
                        //if (UpdateResult.State == EntityState.Modified)

                    }
                        
                }
                              
                if (toInsert.Count > 0)
                    dbContext.SalesTerritories.AddRange(toInsert);
                if (toUpdate.Count > 0)
                    dbContext.SalesTerritories.UpdateRange(toUpdate);

                if (toInsert.Count > 0 || toUpdate.Count > 0)
                    ret = dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }
        public async Task<bool> InsertAsync(SalesTerritory item)
        {
            try
            {
                
                if(dbContext.SalesTerritories.Find(item.TerritoryID) == null)
                {
                    var result = await dbContext.SalesTerritories.AddAsync(item);
                    await dbContext.SaveChangesAsync().ConfigureAwait(false);
                    return result.State == EntityState.Added;
                }
                else
                {
                    var result = dbContext.SalesTerritories.Update(item);
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

        public async Task<IEnumerable<SalesTerritory>> QueryAsync(Func<SalesTerritory, bool> predicate)
        {
            try
            {
                var data = dbContext.SalesTerritories.Where(predicate);
                if (data != null)
                    return data.ToList();
                else
                    return null;
                
            }
            catch (Exception)
            {
                return null;
            }


        }

        public async Task<bool> UpdateAsync(SalesTerritory item)
        {
            try
            {
                var result = dbContext.SalesTerritories.Update(item);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return result.State == EntityState.Modified;

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

        public bool IsSynchedWith(SalesTerritory old, SalesTerritory entity)
        {
            if (old != null && entity != null)
            {
                if (old.Name != entity.Name) return false;
            }
            
            return true;
        }

        public void SynchEntity(SalesTerritory old, SalesTerritory entity)
        {
            if(old != null && entity != null)
            {
                old.Name = entity.Name;
            }
            
        }
    }
}
