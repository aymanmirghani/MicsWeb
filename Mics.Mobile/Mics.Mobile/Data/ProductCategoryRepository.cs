using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Mics.Web.Api;

namespace Mics.Mobile.Data
{
    public class ProductCategoryRepository : IRepository<ProductCategory>
    {
        private DatabaseContext dbContext;

        public ProductCategoryRepository()
        {
            dbContext = new DatabaseContext(App.FilePath);
        }
        public ProductCategoryRepository(string dbPath)
        {
            dbContext = new DatabaseContext(dbPath);
        }
        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Web.Api.ProductCategory>> GeAllAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<Web.Api.ProductCategory> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductCategory> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(Web.Api.ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public bool InsertBulkAsync(List<ProductCategory> itemList)
        {
            try
            {
                if (itemList == null)
                    return false;
                int ret = 0;
                List<ProductCategory> toInsert = new List<ProductCategory>();
                List<ProductCategory> toUpdate = new List<ProductCategory>();
                foreach (var item in itemList)
                {
                    var found = dbContext.ProductCategories.Find(item.ProductCategoryID);
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
                    dbContext.ProductCategories.AddRange(toInsert);
                if (toUpdate.Count > 0)
                    dbContext.ProductCategories.UpdateRange(toUpdate);

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

        public bool IsSynchedWith(ProductCategory old, ProductCategory entity)
        {
            if (old != null && entity != null)
            {
                if(old.Name != entity.Name) return false;
                if(old.ModifiedDate != entity.ModifiedDate) return false;
            }
            return true;
        }

        public Task<IEnumerable<Web.Api.ProductCategory>> QueryAsync(Func<Web.Api.ProductCategory, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void SynchEntity(ProductCategory old, ProductCategory entity)
        {
            if(old != null && entity != null)
            {
                old.Name = entity.Name;
                old.ModifiedDate = entity.ModifiedDate;
            }
            
        }

        public Task<bool> UpdateAsync(Web.Api.ProductCategory item)
        {
            throw new NotImplementedException();
        }
    }
}
