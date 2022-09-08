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
    public class ResearchersController : ApiController
    {
        private trpoContext db = new trpoContext();

        // GET: api/Researchers
        public IQueryable<Researcher> GetResearchers()
        {
            return db.Researchers;
        }

        // GET: api/Researchers/5
        [ResponseType(typeof(Researcher))]
        public async Task<IHttpActionResult> GetResearcher(int id)
        {
            Researcher researcher = await db.Researchers.FindAsync(id);
            if (researcher == null)
            {
                return NotFound();
            }

            return Ok(researcher);
        }

        // PUT: api/Researchers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutResearcher(int id, Researcher researcher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != researcher.Id)
            {
                return BadRequest();
            }

            db.Entry(researcher).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResearcherExists(id))
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

        // POST: api/Researchers
        [ResponseType(typeof(Researcher))]
        public async Task<IHttpActionResult> PostResearcher(Researcher researcher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Researchers.Add(researcher);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = researcher.Id }, researcher);
        }

        // DELETE: api/Researchers/5
        [ResponseType(typeof(Researcher))]
        public async Task<IHttpActionResult> DeleteResearcher(int id)
        {
            Researcher researcher = await db.Researchers.FindAsync(id);
            if (researcher == null)
            {
                return NotFound();
            }

            db.Researchers.Remove(researcher);
            await db.SaveChangesAsync();

            return Ok(researcher);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResearcherExists(int id)
        {
            return db.Researchers.Count(e => e.Id == id) > 0;
        }
    }
}