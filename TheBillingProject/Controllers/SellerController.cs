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
    public class SellerController : Controller
    {
        string Baseurl = "https://billing-project-api.herokuapp.com/";
        HttpClient sellerClient()
        {
            var client = new HttpClient();
            

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client;
            
        }
        public async Task<ActionResult> Index()
        {
            List<Seller> sellerInfo = new List<Seller>();                          
                HttpResponseMessage Res = await sellerClient().GetAsync("sellers/get");
            
                if (Res.IsSuccessStatusCode)
                {                   
                    var sellerResponse = Res.Content.ReadAsStringAsync().Result;
                    JObject jo = JObject.Parse(sellerResponse);
                    JToken data = jo["data"];
                    var jsonResponse = JsonConvert.DeserializeObject(sellerResponse);                   
                    sellerInfo = JsonConvert.DeserializeObject<List<Seller>>(data.ToString());
                }               
                return View(sellerInfo);
            
        }

        public ActionResult Create(Seller art)
        {
            
            return View();
        }

       async public Task<ActionResult> Insert(Seller art)
        {
            string json = JsonConvert.SerializeObject(art);
            HttpResponseMessage Res = await sellerClient().PostAsync("sellers/insert", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");           
        }

        async public Task<ActionResult> Updateseller(Seller art)
        {
            string json = JsonConvert.SerializeObject(art);
            HttpResponseMessage Res = await sellerClient().PutAsync("sellers/update", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
        async public Task<ActionResult> Deleteseller(Seller art)
        {
            string json = JsonConvert.SerializeObject(art);
            HttpResponseMessage Res = await sellerClient().PostAsync("sellers/toggle_status", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(Seller art)
        {

            return View(art);
        }
        public ActionResult Delete(Seller art)
        {

            return View(art);
        }
    }
}