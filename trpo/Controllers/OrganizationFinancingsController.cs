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
    public class OrganizationFinancingsController : ApiController
    {
        private trpoContext db = new trpoContext();

        // GET: api/OrganizationFinancings
        public IQueryable<OrganizationFinancing> GetOrganizationFinancings()
        {
            return db.OrganizationFinancings;
        }

        // GET: api/OrganizationFinancings/5
        [ResponseType(typeof(OrganizationFinancing))]
        public async Task<IHttpActionResult> GetOrganizationFinancing(int id)
        {
            OrganizationFinancing organizationFinancing = await db.OrganizationFinancings.FindAsync(id);
            if (organizationFinancing == null)
            {
                return NotFound();
            }

            return Ok(organizationFinancing);
        }

        // PUT: api/OrganizationFinancings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrganizationFinancing(int id, OrganizationFinancing organizationFinancing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organizationFinancing.Id)
            {
                return BadRequest();
            }

            db.Entry(organizationFinancing).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationFinancingExists(id))
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

        // POST: api/OrganizationFinancings
        [ResponseType(typeof(OrganizationFinancing))]
        public async Task<IHttpActionResult> PostOrganizationFinancing(OrganizationFinancing organizationFinancing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrganizationFinancings.Add(organizationFinancing);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = organizationFinancing.Id }, organizationFinancing);
        }

        // DELETE: api/OrganizationFinancings/5
        [ResponseType(typeof(OrganizationFinancing))]
        public async Task<IHttpActionResult> DeleteOrganizationFinancing(int id)
        {
            OrganizationFinancing organizationFinancing = await db.OrganizationFinancings.FindAsync(id);
            if (organizationFinancing == null)
            {
                return NotFound();
            }

            db.OrganizationFinancings.Remove(organizationFinancing);
            await db.SaveChangesAsync();

            return Ok(organizationFinancing);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrganizationFinancingExists(int id)
        {
            return db.OrganizationFinancings.Count(e => e.Id == id) > 0;
        }
    }
}