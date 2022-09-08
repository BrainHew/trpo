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
    public class ResearchesController : ApiController
    {
        private trpoContext db = new trpoContext();

        // GET: api/Researches
        public IQueryable<Researches> GetResearches()
        {
            return db.Researches;
        }

        // GET: api/Researches/5
        [ResponseType(typeof(Researches))]
        public async Task<IHttpActionResult> GetResearches(int id)
        {
            Researches researches = await db.Researches.FindAsync(id);
            if (researches == null)
            {
                return NotFound();
            }

            return Ok(researches);
        }

        // PUT: api/Researches/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutResearches(int id, Researches researches)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != researches.Id)
            {
                return BadRequest();
            }

            db.Entry(researches).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResearchesExists(id))
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

        // POST: api/Researches
        [ResponseType(typeof(Researches))]
        public async Task<IHttpActionResult> PostResearches(Researches researches)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Researches.Add(researches);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = researches.Id }, researches);
        }

        // DELETE: api/Researches/5
        [ResponseType(typeof(Researches))]
        public async Task<IHttpActionResult> DeleteResearches(int id)
        {
            Researches researches = await db.Researches.FindAsync(id);
            if (researches == null)
            {
                return NotFound();
            }

            db.Researches.Remove(researches);
            await db.SaveChangesAsync();

            return Ok(researches);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResearchesExists(int id)
        {
            return db.Researches.Count(e => e.Id == id) > 0;
        }
    }
}