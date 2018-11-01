using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheBillingProject.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace TheBillingProject.Controllers
{
    public class ArticlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Articles
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

        // GET: Articles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articles articles = await db.articles.FindAsync(id);
            if (articles == null)
            {
                return HttpNotFound();
            }
            return View(articles);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,status,_id,description,unit_price,__v")] articles articles)
        {
            if (ModelState.IsValid)
            {
                db.articles.Add(articles);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(articles);
        }

        // GET: Articles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articles articles = await db.articles.FindAsync(id);
            if (articles == null)
            {
                return HttpNotFound();
            }
            return View(articles);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,status,_id,description,unit_price,__v")] articles articles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articles).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(articles);
        }

        // GET: Articles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articles articles = await db.articles.FindAsync(id);
            if (articles == null)
            {
                return HttpNotFound();
            }
            return View(articles);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            articles articles = await db.articles.FindAsync(id);
            db.articles.Remove(articles);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
