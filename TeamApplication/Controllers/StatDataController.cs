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
using TeamApplication.Models;

namespace TeamApplication.Controllers
{
    public class StatDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/StatData/ListStats
        [HttpGet]
        public IEnumerable<StatDto> ListStats()
        {
           List<Stat> Stats = db.Stats.ToList();
           List<StatDto> StatDtos = new List<StatDto>();

           Stats.ForEach(a => StatDtos.Add(new StatDto()
            {
                StatID = a.StatID,
                PlayerName = a.Player.PlayerName,
                TeamScoredAgainst = a.Team.TeamName
            }));

            return StatDtos;
        }

        // GET: api/StatData/FindStat/5
        [ResponseType(typeof(Stat))]
        [HttpGet]
        public IHttpActionResult FindStat(int id)
        {
            Stat Stat = db.Stats.Find(id);
            StatDto StatDto = new StatDto()
            {
                StatID = Stat.StatID,
                PlayerName = Stat.Player.PlayerName,
                TeamScoredAgainst = Stat.Team.TeamName
            };
            if (Stat == null)
            {
                return NotFound();
            }

            return Ok(StatDto);
        }

        // POST: api/StatData/UpdateStat/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateStat(int id, Stat stat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stat.StatID)
            {
                return BadRequest();
            }

            db.Entry(stat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatExists(id))
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

        // POST: api/StatData/AddStat
        [ResponseType(typeof(Stat))]
        [HttpPost]
        public IHttpActionResult AddStat(Stat stat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stats.Add(stat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stat.StatID }, stat);
        }

        // POST: api/StatData/DeleteStat/5
        [ResponseType(typeof(Stat))]
        [HttpPost]
        public IHttpActionResult DeleteStat(int id)
        {
            Stat stat = db.Stats.Find(id);
            if (stat == null)
            {
                return NotFound();
            }

            db.Stats.Remove(stat);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatExists(int id)
        {
            return db.Stats.Count(e => e.StatID == id) > 0;
        }
    }
}