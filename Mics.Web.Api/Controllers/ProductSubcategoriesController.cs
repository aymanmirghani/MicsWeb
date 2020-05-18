using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Mics.Web.Api;

namespace Mics.Web.Api.Controllers
{
    public class ProductSubcategoriesController : ApiController
    {
        private MicsEntities db = new MicsEntities();

        // GET: api/ProductSubcategories
        public IQueryable<ProductSubcategory> GetProductSubcategories()
        {
            return db.ProductSubcategories;
        }

        // GET: api/ProductSubcategories/5
        [ResponseType(typeof(ProductSubcategory))]
        public async Task<IHttpActionResult> GetProductSubcategory(int id)
        {
            ProductSubcategory productSubcategory = await db.ProductSubcategories.FindAsync(id);
            if (productSubcategory == null)
            {
                return NotFound();
            }

            return Ok(productSubcategory);
        }

        // PUT: api/ProductSubcategories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductSubcategory(int id, ProductSubcategory productSubcategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productSubcategory.ProductSubcategoryID)
            {
                return BadRequest();
            }

            db.Entry(productSubcategory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSubcategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductSubcategories
        [ResponseType(typeof(ProductSubcategory))]
        public async Task<IHttpActionResult> PostProductSubcategory(ProductSubcategory productSubcategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductSubcategories.Add(productSubcategory);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productSubcategory.ProductSubcategoryID }, productSubcategory);
        }

        // DELETE: api/ProductSubcategories/5
        [ResponseType(typeof(ProductSubcategory))]
        public async Task<IHttpActionResult> DeleteProductSubcategory(int id)
        {
            ProductSubcategory productSubcategory = await db.ProductSubcategories.FindAsync(id);
            if (productSubcategory == null)
            {
                return NotFound();
            }

            db.ProductSubcategories.Remove(productSubcategory);
            await db.SaveChangesAsync();

            return Ok(productSubcategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductSubcategoryExists(int id)
        {
            return db.ProductSubcategories.Count(e => e.ProductSubcategoryID == id) > 0;
        }
    }
}