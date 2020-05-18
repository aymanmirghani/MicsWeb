using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mics.Web.Api;

namespace Mics.Mobile.Data
{
    public class ProductRepository : IRepository<Product>, IDisposable
    {
        private DatabaseContext dbContext;

        public ProductRepository()
        {
            dbContext = new DatabaseContext(App.FilePath);
        }
        public ProductRepository(string dbPath)
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

        public void Dispose()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
        protected virtual void Dispose(bool arg)
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

        public Task<IEnumerable<Product>> GeAllAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            try
            {
                var data = await dbContext.Products.FindAsync(id).ConfigureAwait(false);
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> InsertAsync(Product item)
        {
            try
            {


                var result = await dbContext.Products.AddAsync(item).ConfigureAwait(false);
                if(result.State == EntityState.Added)
                {
                    await dbContext.SaveChangesAsync().ConfigureAwait(false);
                    return true;
                }
               
                
                return false;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertBulkAsync(List<Product> itemList)
        {
            try
            {
                if (itemList == null)
                    return false;
                int ret = 0;
                List<Product> toInsert = new List<Product>();
                List<Product> toUpdate = new List<Product>();
                foreach (var item in itemList)
                {
                    var found = dbContext.Products.Find(item.ProductID);
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
                    dbContext.Products.AddRange(toInsert);
                if (toUpdate.Count > 0)
                    dbContext.Products.UpdateRange(toUpdate);

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

        public bool IsSynchedWith(Product old, Product entity)
        {
            if (old != null && entity != null)
            {
                if(old.Name != entity.Name) return false;
                if(old.ActiveFlag != entity.ActiveFlag) return false;
                if(old.Class != entity.Class) return false;
                if(old.Color != entity.Color) return false;
                if(old.Comments != entity.Comments) return false;
                if(old.DaysToManufacture != entity.DaysToManufacture) return false;
                if(old.Description != entity.Description) return false;
                if(old.DiscontinuedDate != entity.DiscontinuedDate) return false;
                if(old.FinishedGoodsFlag != entity.FinishedGoodsFlag) return false;
                if(old.ListPrice != entity.ListPrice) return false;
                if(old.MakeFlag != entity.MakeFlag) return false;
                if(old.ModifiedDate != entity.ModifiedDate) return false;
                if(old.PrimaryVendorId != entity.PrimaryVendorId) return false;
                if(old.ProductLine != entity.ProductLine) return false;
                if(old.ProductModelID != entity.ProductModelID) return false;
                if(old.ProductNumber != entity.ProductNumber) return false;
                if(old.ReorderPoint != entity.ReorderPoint) return false;
                if(old.SafetyStockLevel != entity.SafetyStockLevel) return false;
                if(old.SecondaryVendorId != entity.SecondaryVendorId) return false;
                if(old.SellEndDate != entity.SellEndDate) return false;
                if(old.SellStartDate != entity.SellStartDate) return false;
                if(old.Size != entity.Size) return false;
                if(old.StandardCost != entity.StandardCost) return false;
                if(old.Weight != entity.Weight) return false;
                if(old.WeightUnitMeasureCode != entity.WeightUnitMeasureCode) return false;
                if(old.ProductSubcategoryID != entity.ProductSubcategoryID) return false;
            }
            return true;
        }

        public Task<IEnumerable<Product>> QueryAsync(Func<Product, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void SynchEntity(Product old, Product entity)
        {
            if (old != null && entity != null)
            {
                old.Name = entity.Name;
                old.ActiveFlag = entity.ActiveFlag;
                old.Class = entity.Class;
                old.Color = entity.Color;
                old.Comments = entity.Comments;
                old.DaysToManufacture = entity.DaysToManufacture;
                old.Description = entity.Description;
                old.DiscontinuedDate = entity.DiscontinuedDate;
                old.FinishedGoodsFlag = entity.FinishedGoodsFlag;
                old.ListPrice = entity.ListPrice;
                old.MakeFlag = entity.MakeFlag;
                old.ModifiedDate = entity.ModifiedDate;
                old.PrimaryVendorId = entity.PrimaryVendorId;
                old.ProductLine = entity.ProductLine;
                old.ProductModelID = entity.ProductModelID;
                old.ProductNumber = entity.ProductNumber;
                old.ReorderPoint = entity.ReorderPoint;
                old.SafetyStockLevel = entity.SafetyStockLevel;
                old.SecondaryVendorId = entity.SecondaryVendorId;
                old.SellEndDate = entity.SellEndDate;
                old.SellStartDate = entity.SellStartDate;
                old.Size = entity.Size;
                old.StandardCost = entity.StandardCost;
                old.Weight = entity.Weight;
                old.WeightUnitMeasureCode = entity.WeightUnitMeasureCode;
                old.ProductSubcategoryID = entity.ProductSubcategoryID;
            }

        } 

        public Task<bool> UpdateAsync(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
