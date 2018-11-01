using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TheBillingProject.Models;


namespace TheBillingProject.Controllers
{
    public class ArticleController : Controller
    {
        string Baseurl = "https://billing-project-api.herokuapp.com/";
        HttpClient ArticleClient()
        {
            var client = new HttpClient();
            

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client;
            
        }
        public async Task<ActionResult> Index()
        {
            List<Article> articleInfo = new List<Article>();                          
                HttpResponseMessage Res = await ArticleClient().GetAsync("articles/get");
            
                if (Res.IsSuccessStatusCode)
                {                   
                    var articleResponse = Res.Content.ReadAsStringAsync().Result;
                    JObject jo = JObject.Parse(articleResponse);
                    JToken data = jo["data"];
                    var jsonResponse = JsonConvert.DeserializeObject(articleResponse);                   
                    articleInfo = JsonConvert.DeserializeObject<List<Article>>(data.ToString());
                }               
                return View(articleInfo);
            
        }

        public ActionResult Create(Article art)
        {
            
            return View();
        }

       async public Task<ActionResult> Insert(Article art)
        {
            string json = JsonConvert.SerializeObject(art);
            HttpResponseMessage Res = await ArticleClient().PostAsync("articles/insert", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");           
        }

        async public Task<ActionResult> UpdateArticle(Article art)
        {
            string json = JsonConvert.SerializeObject(art);
            HttpResponseMessage Res = await ArticleClient().PutAsync("articles/update", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
        async public Task<ActionResult> DeleteArticle(Article art)
        {
            string json = JsonConvert.SerializeObject(art);
            HttpResponseMessage Res = await ArticleClient().PostAsync("articles/toggle_status", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(Article art)
        {

            return View(art);
        }
        public ActionResult Delete(Article art)
        {

            return View(art);
        }
    }
}