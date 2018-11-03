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
    public class BillController : Controller
    {
        string Baseurl = "https://billing-project-api.herokuapp.com/";
        HttpClient billClient()
        {
            var client = new HttpClient();
            

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client;
            
        }
        public async Task<ActionResult> Index()
        {
            List<Bill> billInfo = new List<Bill>();                          
                HttpResponseMessage Res = await billClient().GetAsync("bills/get");
            
                if (Res.IsSuccessStatusCode)
                {                   
                    var billResponse = Res.Content.ReadAsStringAsync().Result;
                    JObject jo = JObject.Parse(billResponse);
                    JToken data = jo["data"];
                    var jsonResponse = JsonConvert.DeserializeObject(billResponse);                   
                    billInfo = JsonConvert.DeserializeObject<List<Bill>>(data.ToString());
                }               
                return View(billInfo);
            
        }

        public ActionResult Create(Bill art)
        {
            
            return View();
        }

       async public Task<ActionResult> Insert(Bill art)
        {
            string json = JsonConvert.SerializeObject(art);
            HttpResponseMessage Res = await billClient().PostAsync("bills/insert", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");           
        }

        async public Task<ActionResult> Updatebill(Bill art)
        {
            string json = JsonConvert.SerializeObject(art);
            HttpResponseMessage Res = await billClient().PutAsync("bills/update", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
        async public Task<ActionResult> Deletebill(Bill art)
        {
            string json = JsonConvert.SerializeObject(art);
            HttpResponseMessage Res = await billClient().PostAsync("bills/toggle_status", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(Bill art)
        {

            return View(art);
        }
        public ActionResult Delete(Bill art)
        {

            return View(art);
        }
    }
}