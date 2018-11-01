using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TheBillingProject.Models;

namespace TheBillingProject.Controllers
{
    public class ArticulosController : Controller
    {
        // GET: Articulos
        public async Task<ActionResult> Index()
        {
            List<articles> articulos = new List<articles>();
            //https://billing-project-api.herokuapp.com/articles/GET
            var httpclient = new HttpClient();
            var json = await httpclient.GetStringAsync("https://billing-project-api.herokuapp.com/articles/GET");


            var jObject = JObject.Parse(json);

            if (jObject != null)
            {
                var Data = jObject["data"];
                articulos = JsonConvert.DeserializeObject<List<articles>>(Data.ToString());

            }


            return View(articulos);
        }

        // GET: Articulos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Articulos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articulos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Articulos/Edit/5
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

        // GET: Articulos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Articulos/Delete/5
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
