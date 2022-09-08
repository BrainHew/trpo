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
    public class FinancingVolumesController : ApiController
    {
        private trpoContext db = new trpoContext();

        // GET: api/FinancingVolumes
        public IQueryable<FinancingVolumes> GetFinancingVolumes()
        {
            return db.FinancingVolumes;
        }

        // GET: api/FinancingVolumes/5
        [ResponseType(typeof(FinancingVolumes))]
        public async Task<IHttpActionResult> GetFinancingVolumes(int id)
        {
            FinancingVolumes financingVolumes = await db.FinancingVolumes.FindAsync(id);
            if (financingVolumes == null)
            {
                return NotFound();
            }

            return Ok(financingVolumes);
        }

        // PUT: api/FinancingVolumes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFinancingVolumes(int id, FinancingVolumes financingVolumes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != financingVolumes.Id)
            {
                return BadRequest();
            }

            db.Entry(financingVolumes).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancingVolumesExists(id))
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

        // POST: api/FinancingVolumes
        [ResponseType(typeof(FinancingVolumes))]
        public async Task<IHttpActionResult> PostFinancingVolumes(FinancingVolumes financingVolumes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FinancingVolumes.Add(financingVolumes);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = financingVolumes.Id }, financingVolumes);
        }

        // DELETE: api/FinancingVolumes/5
        [ResponseType(typeof(FinancingVolumes))]
        public async Task<IHttpActionResult> DeleteFinancingVolumes(int id)
        {
            FinancingVolumes financingVolumes = await db.FinancingVolumes.FindAsync(id);
            if (financingVolumes == null)
            {
                return NotFound();
            }

            db.FinancingVolumes.Remove(financingVolumes);
            await db.SaveChangesAsync();

            return Ok(financingVolumes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FinancingVolumesExists(int id)
        {
            return db.FinancingVolumes.Count(e => e.Id == id) > 0;
        }
    }
}