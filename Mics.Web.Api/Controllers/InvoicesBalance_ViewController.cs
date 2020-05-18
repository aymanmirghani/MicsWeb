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
    public class InvoicesBalance_ViewController : ApiController
    {
        private MicsEntities db = new MicsEntities();

        // GET: api/InvoicesBalance_View
        public IQueryable<InvoicesBalance_View> GetInvoicesBalance_View()
        {
            return db.InvoicesBalance_View;
        }

        // GET: api/InvoicesBalance_View/5
        [ResponseType(typeof(InvoicesBalance_View))]
        public async Task<IHttpActionResult> GetInvoicesBalance_View(int id)
        {
            InvoicesBalance_View invoicesBalance_View = await db.InvoicesBalance_View.FindAsync(id);
            if (invoicesBalance_View == null)
            {
                return NotFound();
            }

            return Ok(invoicesBalance_View);
        }

        // PUT: api/InvoicesBalance_View/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInvoicesBalance_View(int id, InvoicesBalance_View invoicesBalance_View)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != invoicesBalance_View.CustomerID)
            {
                return BadRequest();
            }

            db.Entry(invoicesBalance_View).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoicesBalance_ViewExists(id))
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

        // POST: api/InvoicesBalance_View
        [ResponseType(typeof(InvoicesBalance_View))]
        public async Task<IHttpActionResult> PostInvoicesBalance_View(InvoicesBalance_View invoicesBalance_View)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InvoicesBalance_View.Add(invoicesBalance_View);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InvoicesBalance_ViewExists(invoicesBalance_View.CustomerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = invoicesBalance_View.CustomerID }, invoicesBalance_View);
        }

        // DELETE: api/InvoicesBalance_View/5
        [ResponseType(typeof(InvoicesBalance_View))]
        public async Task<IHttpActionResult> DeleteInvoicesBalance_View(int id)
        {
            InvoicesBalance_View invoicesBalance_View = await db.InvoicesBalance_View.FindAsync(id);
            if (invoicesBalance_View == null)
            {
                return NotFound();
            }

            db.InvoicesBalance_View.Remove(invoicesBalance_View);
            await db.SaveChangesAsync();

            return Ok(invoicesBalance_View);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvoicesBalance_ViewExists(int id)
        {
            return db.InvoicesBalance_View.Count(e => e.CustomerID == id) > 0;
        }
    }
}