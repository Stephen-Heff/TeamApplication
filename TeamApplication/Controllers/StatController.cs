using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using TeamApplication.Models;
using System.Web.Script.Serialization;

namespace TeamApplication.Controllers
{
    public class StatController : Controller
    {
        private static readonly HttpClient client;
        JavaScriptSerializer jss = new JavaScriptSerializer();

        static StatController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44388/api/statdata/");
        }



        // GET: Stat/List
        public ActionResult List()
        {
            //Objective: communicate with our stat data api to retrieve a list of stats
            // curl https://localhost:44388/api/statdata/liststats
            string url = "liststats";
            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<StatDto> stats = response.Content.ReadAsAsync<IEnumerable<StatDto>>().Result;


            return View(stats);
        }

        // GET: Stat/Details/5
        public ActionResult Details(int id)
        {
            //Objective: communicate with our stat data api to retrieve one stat
            // curl https://localhost:44388/api/statdata/liststats{}id

            string url = "findstat/"+id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            StatDto selectedstat = response.Content.ReadAsAsync<StatDto>().Result;

            return View(selectedstat);
        }

        public ActionResult Error()
        {
            return View();
        }


        // GET: Stat/New
        public ActionResult New()
        {
            return View();
        }

        // POST: Stat/Create
        [HttpPost]
        public ActionResult Create(Stat stat)
        {
            //Objective: add a new stat into our system using the API
            //curl -H "Content-Type:application/json" -d @stat.json https://localhost:44388/api/statdata/addstat
            string url = "addstat";

            String jsonpayload = jss.Serialize(stat);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response =  client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }

            return RedirectToAction("List");
        }

        // GET: Stat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Stat/Edit/5
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

        // GET: Stat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Stat/Delete/5
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
