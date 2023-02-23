using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using TeamApplication.Models;
//using TeamApplication.Models.ViewModels;
using System.Web.Script.Serialization;

namespace TeamApplication.Controllers
{
    public class TeamController : Controller
    {
        private static readonly HttpClient client;
        JavaScriptSerializer jss = new JavaScriptSerializer();

        static TeamController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44388/api/teamdata/");
        }

        // GET: Team/List
        public ActionResult List()
        {
            //Objective: communicate with our team data api to retrieve a list of teamss
            // curl https://localhost:44388/api/teamdata/listteams
            string url = "listteams";
            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<TeamDto> teams = response.Content.ReadAsAsync<IEnumerable<TeamDto>>().Result;


            return View(teams);
        }

        // GET: Team/Details/5
        public ActionResult Details(int id)
        {
            //Objective: communicate with our team data api to retrieve one team
            // curl https://localhost:44388/api/teamdata/listteams{}id

            string url = "findstat/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            TeamDto selectedteam = response.Content.ReadAsAsync<TeamDto>().Result;

            return View(selectedteam);
        }

        public ActionResult Error()
        {
            return View();
        }

        // GET: Team/New
        public ActionResult Create()
        {
            return View();
        }

        // POST: Team/Create
        [HttpPost]
        public ActionResult Create(Team team)
        {
            //Objective: add a new team into our system using the API
            //curl -H "Content-Type:application/json" -d @team.json https://localhost:44388/api/teamdata/addteam
            string url = "addteam";

            String jsonpayload = jss.Serialize(team);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }

            //return RedirectToAction("List");
        }

        // GET: Team/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Team/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Team/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Team/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
