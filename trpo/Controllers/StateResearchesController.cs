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
    public class StateResearchesController : ApiController
    {
        private trpoContext db = new trpoContext();

        // GET: api/StateResearches
        public IQueryable<StateResearch> GetStateResearches()
        {
            return db.StateResearches;
        }

        // GET: api/StateResearches/5
        [ResponseType(typeof(StateResearch))]
        public async Task<IHttpActionResult> GetStateResearch(int id)
        {
            StateResearch stateResearch = await db.StateResearches.FindAsync(id);
            if (stateResearch == null)
            {
                return NotFound();
            }

            return Ok(stateResearch);
        }

        // PUT: api/StateResearches/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStateResearch(int id, StateResearch stateResearch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stateResearch.Id)
            {
                return BadRequest();
            }

            db.Entry(stateResearch).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateResearchExists(id))
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

        // POST: api/StateResearches
        [ResponseType(typeof(StateResearch))]
        public async Task<IHttpActionResult> PostStateResearch(StateResearch stateResearch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StateResearches.Add(stateResearch);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = stateResearch.Id }, stateResearch);
        }

        // DELETE: api/StateResearches/5
        [ResponseType(typeof(StateResearch))]
        public async Task<IHttpActionResult> DeleteStateResearch(int id)
        {
            StateResearch stateResearch = await db.StateResearches.FindAsync(id);
            if (stateResearch == null)
            {
                return NotFound();
            }

            db.StateResearches.Remove(stateResearch);
            await db.SaveChangesAsync();

            return Ok(stateResearch);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StateResearchExists(int id)
        {
            return db.StateResearches.Count(e => e.Id == id) > 0;
        }
    }
}