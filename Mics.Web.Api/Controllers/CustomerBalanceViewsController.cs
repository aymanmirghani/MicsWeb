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
    public class CustomerBalanceViewsController : ApiController
    {
        private MicsEntities db = new MicsEntities();

        // GET: api/CustomerBalanceViews
        public IQueryable<CustomerBalanceView> GetCustomerBalanceViews()
        {
            return db.CustomerBalanceViews;
        }

        // GET: api/CustomerBalanceViews/5
        [ResponseType(typeof(CustomerBalanceView))]
        public async Task<IHttpActionResult> GetCustomerBalanceView(int id)
        {
            CustomerBalanceView customerBalanceView = await db.CustomerBalanceViews.FindAsync(id);
            if (customerBalanceView == null)
            {
                return NotFound();
            }

            return Ok(customerBalanceView);
        }

        // PUT: api/CustomerBalanceViews/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomerBalanceView(int id, CustomerBalanceView customerBalanceView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerBalanceView.CustomerID)
            {
                return BadRequest();
            }

            db.Entry(customerBalanceView).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerBalanceViewExists(id))
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

        // POST: api/CustomerBalanceViews
        [ResponseType(typeof(CustomerBalanceView))]
        public async Task<IHttpActionResult> PostCustomerBalanceView(CustomerBalanceView customerBalanceView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerBalanceViews.Add(customerBalanceView);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerBalanceViewExists(customerBalanceView.CustomerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = customerBalanceView.CustomerID }, customerBalanceView);
        }

        // DELETE: api/CustomerBalanceViews/5
        [ResponseType(typeof(CustomerBalanceView))]
        public async Task<IHttpActionResult> DeleteCustomerBalanceView(int id)
        {
            CustomerBalanceView customerBalanceView = await db.CustomerBalanceViews.FindAsync(id);
            if (customerBalanceView == null)
            {
                return NotFound();
            }

            db.CustomerBalanceViews.Remove(customerBalanceView);
            await db.SaveChangesAsync();

            return Ok(customerBalanceView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerBalanceViewExists(int id)
        {
            return db.CustomerBalanceViews.Count(e => e.CustomerID == id) > 0;
        }
    }
}