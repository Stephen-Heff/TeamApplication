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
    public class TeamDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        /// <summary>
        /// Returns all teams in the system.
        /// </summary>
        /// <returns>
        /// HEADER: 200 (OK)
        /// CONTENT: all teamss in the database
        /// </returns>
        /// <example>
        /// GET: api/TeamData/ListTeams
        /// </example>
        
        [HttpGet]
        public IEnumerable<TeamDto> Listteams()
        {
            List<Team> Teams = db.Teams.ToList();
            List<TeamDto> TeamsDtos = new List<TeamDto>();

            Teams.ForEach(t => TeamsDtos.Add(new TeamDto()
            {
                TeamID = t.TeamID,
                TeamName = t.TeamName,
                TeamCity = t.TeamCity,
                TeamCoachName = t.TeamCoachName
            }));

            return TeamsDtos;
        }

        // GET: api/TeamData/FindTeam/4
        [ResponseType(typeof(Team))]
        [HttpGet]
        public IHttpActionResult FindTeam(int id)
        {
            Team team = db.Teams.Find(id);
            TeamDto TeamDto = new TeamDto()
            {
                TeamID = team.TeamID,
                TeamName = team.TeamName,
                TeamCity = team.TeamCity,
                TeamCoachName = team.TeamCoachName
            };
            if (team == null)
            {
                return NotFound();
            }

            return Ok(TeamDto);
        }

        // POST: api/TeamData/UpdateTeam/4
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateTeam(int id, Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != team.TeamID)
            {
                return BadRequest();
            }

            db.Entry(team).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        // POST: api/TeamData/AddTeam
        [ResponseType(typeof(Team))]
        [HttpPost]
        public IHttpActionResult AddTeam(Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Teams.Add(team);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = team.TeamID }, team);
        }

        // POST: api/TeamData/DeleteTeam/4
        [ResponseType(typeof(Team))]
        [HttpPost]
        public IHttpActionResult DeleteTeam(int id)
        {
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return NotFound();
            }

            db.Teams.Remove(team);
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

        private bool TeamExists(int id)
        {
            return db.Teams.Count(e => e.TeamID == id) > 0;
        }
    }
}