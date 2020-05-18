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
    public class CustomerViewsController : ApiController
    {
        private MicsEntities db = new MicsEntities();

        // GET: api/CustomerViews
        public IQueryable<CustomerView> GetCustomerViews()
        {
            return db.CustomerViews;
        }

        // GET: api/CustomerViews/5
        [ResponseType(typeof(CustomerView))]
        public async Task<IHttpActionResult> GetCustomerView(int id)
        {
            CustomerView customerView = await db.CustomerViews.FindAsync(id);
            if (customerView == null)
            {
                return NotFound();
            }

            return Ok(customerView);
        }

        // PUT: api/CustomerViews/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomerView(int id, CustomerView customerView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerView.CustomerID)
            {
                return BadRequest();
            }

            db.Entry(customerView).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerViewExists(id))
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

        // POST: api/CustomerViews
        [ResponseType(typeof(CustomerView))]
        public async Task<IHttpActionResult> PostCustomerView(CustomerView customerView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerViews.Add(customerView);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerViewExists(customerView.CustomerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = customerView.CustomerID }, customerView);
        }

        // DELETE: api/CustomerViews/5
        [ResponseType(typeof(CustomerView))]
        public async Task<IHttpActionResult> DeleteCustomerView(int id)
        {
            CustomerView customerView = await db.CustomerViews.FindAsync(id);
            if (customerView == null)
            {
                return NotFound();
            }

            db.CustomerViews.Remove(customerView);
            await db.SaveChangesAsync();

            return Ok(customerView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerViewExists(int id)
        {
            return db.CustomerViews.Count(e => e.CustomerID == id) > 0;
        }
    }
}