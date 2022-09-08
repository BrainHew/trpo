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
    public class DocumentsController : ApiController
    {
        private trpoContext db = new trpoContext();

        // GET: api/Documents
        public IQueryable<Documents> GetDocuments()
        {
            return db.Documents;
        }

        // GET: api/Documents/5
        [ResponseType(typeof(Documents))]
        public async Task<IHttpActionResult> GetDocuments(int id)
        {
            Documents documents = await db.Documents.FindAsync(id);
            if (documents == null)
            {
                return NotFound();
            }

            return Ok(documents);
        }

        // PUT: api/Documents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDocuments(int id, Documents documents)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documents.Id)
            {
                return BadRequest();
            }

            db.Entry(documents).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentsExists(id))
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

        // POST: api/Documents
        [ResponseType(typeof(Documents))]
        public async Task<IHttpActionResult> PostDocuments(Documents documents)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Documents.Add(documents);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = documents.Id }, documents);
        }

        // DELETE: api/Documents/5
        [ResponseType(typeof(Documents))]
        public async Task<IHttpActionResult> DeleteDocuments(int id)
        {
            Documents documents = await db.Documents.FindAsync(id);
            if (documents == null)
            {
                return NotFound();
            }

            db.Documents.Remove(documents);
            await db.SaveChangesAsync();

            return Ok(documents);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DocumentsExists(int id)
        {
            return db.Documents.Count(e => e.Id == id) > 0;
        }
    }
}