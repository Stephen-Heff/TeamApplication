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
    public class PlayerController : Controller
    {
        private static readonly HttpClient client;
        JavaScriptSerializer jss = new JavaScriptSerializer();

        static PlayerController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44388/api/playerdata/");
        }



        // GET: Player/List
        public ActionResult List()
        {
            //Objective: communicate with our player data api to retrieve a list of players
            // curl https://localhost:44388/api/playerdata/listplayers
            string url = "listplayers";
            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<PlayerDto> players = response.Content.ReadAsAsync<IEnumerable<PlayerDto>>().Result;


            return View(players);
        }

        // GET: Player/Details/5
        public ActionResult Details(int id)
        {
            //Objective: communicate with our player data api to retrieve one player
            // curl https://localhost:44388/api/playerdata/listplayers{}id

            string url = "findstat/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            PlayerDto selectedstat = response.Content.ReadAsAsync<PlayerDto>().Result;

            return View(selectedstat);
        }

        public ActionResult Error()
        {
            return View();
        }


        // GET: Player/New
        public ActionResult New()
        {
            return View();
        }

        // POST: Player/Create
        [HttpPost]
        public ActionResult Create(Player player)
        {
            //Objective: add a new player into our system using the API
            //curl -H "Content-Type:application/json" -d @player.json https://localhost:44388/api/playerdata/addstat
            string url = "addstat";

            String jsonpayload = jss.Serialize(player);

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

        // GET: Player/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Player/Edit/5
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

        // GET: Player/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Player/Delete/5
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
