using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WineData.Api.Models;

namespace WineData.Api.Controllers
{
    public class WinesController : ApiController
    {
        private WineDataEntities db = new WineDataEntities();

        // GET: api/Wines
        public IQueryable<Wine> GetWines()
        {
            return db.Wines;
        }

        // GET: api/Wines/5
        [ResponseType(typeof(Wine))]
        public IHttpActionResult GetWine(int id)
        {
            Wine wine = db.Wines.Find(id);
            if (wine == null)
            {
                return NotFound();
            }

            return Ok(wine);
        }

        // PUT: api/Wines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWine(int id, Wine wine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wine.ID)
            {
                return BadRequest();
            }

            db.Entry(wine).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WineExists(id))
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

        // POST: api/Wines
        [ResponseType(typeof(Wine))]
        public IHttpActionResult PostWine(Wine wine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Wines.Add(wine);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (WineExists(wine.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = wine.ID }, wine);
        }

        // DELETE: api/Wines/5
        [ResponseType(typeof(Wine))]
        public IHttpActionResult DeleteWine(int id)
        {
            Wine wine = db.Wines.Find(id);
            if (wine == null)
            {
                return NotFound();
            }

            db.Wines.Remove(wine);
            db.SaveChanges();

            return Ok(wine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WineExists(int id)
        {
            return db.Wines.Count(e => e.ID == id) > 0;
        }
    }
}