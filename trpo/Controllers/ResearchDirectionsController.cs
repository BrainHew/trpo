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
    public class ResearchDirectionsController : ApiController
    {
        private trpoContext db = new trpoContext();

        // GET: api/ResearchDirections
        public IQueryable<ResearchDirection> GetResearchDirections()
        {
            return db.ResearchDirections;
        }

        // GET: api/ResearchDirections/5
        [ResponseType(typeof(ResearchDirection))]
        public async Task<IHttpActionResult> GetResearchDirection(int id)
        {
            ResearchDirection researchDirection = await db.ResearchDirections.FindAsync(id);
            if (researchDirection == null)
            {
                return NotFound();
            }

            return Ok(researchDirection);
        }

        // PUT: api/ResearchDirections/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutResearchDirection(int id, ResearchDirection researchDirection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != researchDirection.Id)
            {
                return BadRequest();
            }

            db.Entry(researchDirection).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResearchDirectionExists(id))
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

        // POST: api/ResearchDirections
        [ResponseType(typeof(ResearchDirection))]
        public async Task<IHttpActionResult> PostResearchDirection(ResearchDirection researchDirection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ResearchDirections.Add(researchDirection);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = researchDirection.Id }, researchDirection);
        }

        // DELETE: api/ResearchDirections/5
        [ResponseType(typeof(ResearchDirection))]
        public async Task<IHttpActionResult> DeleteResearchDirection(int id)
        {
            ResearchDirection researchDirection = await db.ResearchDirections.FindAsync(id);
            if (researchDirection == null)
            {
                return NotFound();
            }

            db.ResearchDirections.Remove(researchDirection);
            await db.SaveChangesAsync();

            return Ok(researchDirection);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResearchDirectionExists(int id)
        {
            return db.ResearchDirections.Count(e => e.Id == id) > 0;
        }
    }
}