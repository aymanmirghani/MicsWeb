using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Mics.Web.Api;

namespace Mics.Mobile.Data
{
    public class ProductSubCategoryRepository : IRepository<ProductSubcategory>
    {
        private DatabaseContext dbContext;

        public ProductSubCategoryRepository()
        {
            dbContext = new DatabaseContext(App.FilePath);
        }
        public ProductSubCategoryRepository(string dbPath)
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

        public Task<IEnumerable<ProductSubcategory>> GeAllAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<ProductSubcategory> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductSubcategory> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(ProductSubcategory item)
        {
            throw new NotImplementedException();
        }

        public bool InsertBulkAsync(List<ProductSubcategory> itemList)
        {
            try
            {
                if (itemList == null)
                    return false;
                int ret = 0;
                List<ProductSubcategory> toInsert = new List<ProductSubcategory>();
                List<ProductSubcategory> toUpdate = new List<ProductSubcategory>();
                foreach (var item in itemList)
                {
                    var found = dbContext.ProductSubcategories.Find(item.ProductSubcategoryID);
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
                    dbContext.ProductSubcategories.AddRange(toInsert);
                if (toUpdate.Count > 0)
                    dbContext.ProductSubcategories.UpdateRange(toUpdate);

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

        public bool IsSynchedWith(ProductSubcategory old, ProductSubcategory entity)
        {
            if (old != null && entity != null)
            {
                if (old.Name != entity.Name) return false;
                if (old.ProductCategoryID != entity.ProductCategoryID) return false;
            }
            return true;
        }

        public Task<IEnumerable<ProductSubcategory>> QueryAsync(Func<ProductSubcategory, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void SynchEntity(ProductSubcategory old, ProductSubcategory entity)
        {
            if(old != null && entity != null)
            {
                old.Name = entity.Name;
                old.ProductCategoryID = entity.ProductCategoryID;
            }
        }

        public Task<bool> UpdateAsync(ProductSubcategory item)
        {
            throw new NotImplementedException();
        }
    }
}
