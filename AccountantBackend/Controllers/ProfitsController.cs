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
    public class ProfitsController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/Profits
        public IQueryable<Profit> GetProfits()
        {
            return db.Profits;
        }

        // GET: api/Profits/5
        [ResponseType(typeof(Profit))]
        public IHttpActionResult GetProfit(int id)
        {
            Profit profit = db.Profits.Find(id);
            if (profit == null)
            {
                return NotFound();
            }

            return Ok(profit);
        }

        // PUT: api/Profits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfit(int id, Profit profit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profit.ProfitId)
            {
                return BadRequest();
            }

            db.Entry(profit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfitExists(id))
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

        // POST: api/Profits
        [ResponseType(typeof(Profit))]
        public IHttpActionResult PostProfit(Profit profit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Profits.Add(profit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = profit.ProfitId }, profit);
        }

        // DELETE: api/Profits/5
        [ResponseType(typeof(Profit))]
        public IHttpActionResult DeleteProfit(int id)
        {
            Profit profit = db.Profits.Find(id);
            if (profit == null)
            {
                return NotFound();
            }

            db.Profits.Remove(profit);
            db.SaveChanges();

            return Ok(profit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfitExists(int id)
        {
            return db.Profits.Count(e => e.ProfitId == id) > 0;
        }
    }
}