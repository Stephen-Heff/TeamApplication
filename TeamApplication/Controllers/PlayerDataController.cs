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
    public class PlayerDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<PlayerDto> PlayerDtos { get; private set; }

        // GET: api/PlayerData/ListPlayers
        [HttpGet]
        public IEnumerable<PlayerDto> ListPlayers()
        {
            List<Player> Players = db.Players.ToList();
            List<PlayerDto> PlayersDtos = new List<PlayerDto>();

            Players.ForEach(p => PlayersDtos.Add(new PlayerDto()
            {
                PlayerID = p.PlayerID,
                PlayerName = p.PlayerName,
                PlayerPosition = p.PlayerPosition
            }));

            return PlayersDtos;
        }

        // GET: api/PlayerData/FindPlayer/5
        [ResponseType(typeof(Player))]
        [HttpGet]
        public IHttpActionResult FindPlayer(int id)
        {
            Player player = db.Players.Find(id);
            PlayerDto PlayerDto = new PlayerDto() {
                PlayerID = player.PlayerID,
                PlayerName = player.PlayerName,
                PlayerPosition = player.PlayerPosition
            };
            if (player == null)
            {
                return NotFound();
            }

            return Ok(PlayerDto);
        }


        // POST: api/PlayerData/UpdatePlayer/30
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdatePlayer(int id, Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != player.PlayerID)
            {
                return BadRequest();
            }

            db.Entry(player).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        // POST: api/PlayerData/AddPlayer
        [ResponseType(typeof(Player))]
        [HttpPost]
        public IHttpActionResult AddPlayer(Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Players.Add(player);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = player.PlayerID }, player);
        }

        // DELETE: api/PlayerData/DeletePlayer/30
        [ResponseType(typeof(Player))]
        [HttpPost]
        public IHttpActionResult DeletePlayer(int id)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }

            db.Players.Remove(player);
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

        private bool PlayerExists(int id)
        {
            return db.Players.Count(e => e.PlayerID == id) > 0;
        }
    }
}

  