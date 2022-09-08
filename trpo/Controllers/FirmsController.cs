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
using trpo.Models;

namespace trpo.Controllers
{
    public class FirmsController : ApiController
    {
        private trpoContext db = new trpoContext();

        // GET: api/Firms
        public IQueryable<Firm> GetFirms()
        {
            return db.Firms;
        }

        // GET: api/Firms/5
        [ResponseType(typeof(Firm))]
        public async Task<IHttpActionResult> GetFirm(int id)
        {
            Firm firm = await db.Firms.FindAsync(id);
            if (firm == null)
            {
                return NotFound();
            }

            return Ok(firm);
        }

        // PUT: api/Firms/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFirm(int id, Firm firm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != firm.Id)
            {
                return BadRequest();
            }

            db.Entry(firm).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirmExists(id))
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

        // POST: api/Firms
        [ResponseType(typeof(Firm))]
        public async Task<IHttpActionResult> PostFirm(Firm firm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Firms.Add(firm);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = firm.Id }, firm);
        }

        // DELETE: api/Firms/5
        [ResponseType(typeof(Firm))]
        public async Task<IHttpActionResult> DeleteFirm(int id)
        {
            Firm firm = await db.Firms.FindAsync(id);
            if (firm == null)
            {
                return NotFound();
            }

            db.Firms.Remove(firm);
            await db.SaveChangesAsync();

            return Ok(firm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FirmExists(int id)
        {
            return db.Firms.Count(e => e.Id == id) > 0;
        }
    }
}