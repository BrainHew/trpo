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
    public class FurnituresController : ApiController
    {
        private trpoContext db = new trpoContext();

        // GET: api/Furnitures
        public IQueryable<Furniture> GetFurnitures()
        {
            return db.Furnitures;
        }

        // GET: api/Furnitures/5
        [ResponseType(typeof(Furniture))]
        public async Task<IHttpActionResult> GetFurniture(int id)
        {
            Furniture furniture = await db.Furnitures.FindAsync(id);
            if (furniture == null)
            {
                return NotFound();
            }

            return Ok(furniture);
        }

        // PUT: api/Furnitures/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFurniture(int id, Furniture furniture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != furniture.Id)
            {
                return BadRequest();
            }

            db.Entry(furniture).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FurnitureExists(id))
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

        // POST: api/Furnitures
        [ResponseType(typeof(Furniture))]
        public async Task<IHttpActionResult> PostFurniture(Furniture furniture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Furnitures.Add(furniture);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = furniture.Id }, furniture);
        }

        // DELETE: api/Furnitures/5
        [ResponseType(typeof(Furniture))]
        public async Task<IHttpActionResult> DeleteFurniture(int id)
        {
            Furniture furniture = await db.Furnitures.FindAsync(id);
            if (furniture == null)
            {
                return NotFound();
            }

            db.Furnitures.Remove(furniture);
            await db.SaveChangesAsync();

            return Ok(furniture);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FurnitureExists(int id)
        {
            return db.Furnitures.Count(e => e.Id == id) > 0;
        }
    }
}