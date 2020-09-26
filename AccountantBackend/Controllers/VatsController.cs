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
using AccountantBackend.Models;

namespace AccountantBackend.Controllers
{
    public class VatsController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/Vats
        public IQueryable<Vat> GetVats()
        {
            return db.Vats.Include(vat => vat.Expenses);
        }

        // GET: api/Vats/5
        [ResponseType(typeof(Vat))]
        public IHttpActionResult GetVat(int id)
        {
            Vat vat = db.Vats.Include(v => v.Expenses).SingleOrDefault(v => v.VatId == id);
            if (vat == null)
            {
                return NotFound();
            }

            return Ok(vat);
        }

        // PUT: api/Vats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVat(int id, Vat vat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vat.VatId)
            {
                return BadRequest();
            }

            db.Entry(vat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VatExists(id))
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

        // POST: api/Vats
        [ResponseType(typeof(Vat))]
        public IHttpActionResult PostVat(Vat vat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vats.Add(vat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vat.VatId }, vat);
        }

        // DELETE: api/Vats/5
        [ResponseType(typeof(Vat))]
        public IHttpActionResult DeleteVat(int id)
        {
            Vat vat = db.Vats.Find(id);
            if (vat == null)
            {
                return NotFound();
            }

            db.Vats.Remove(vat);
            db.SaveChanges();

            return Ok(vat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VatExists(int id)
        {
            return db.Vats.Count(e => e.VatId == id) > 0;
        }
    }
}