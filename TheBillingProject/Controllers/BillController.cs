using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TheBillingProject.Models;

namespace TheBillingProject.Controllers
{
    public class BillController : Controller
    {
        string Baseurl = "https://billing-project-api.herokuapp.com/";
        HttpClient Bills()
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
            HttpResponseMessage Res = await Bills().GetAsync("bills/get");

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

        public ActionResult Create(Bill bi)
        {
            bi.details = new List<BillDetails>();
            return View(bi);
        }

        async public Task<ActionResult> Insert(Bill bi)
        {
            string json = JsonConvert.SerializeObject(bi);
            HttpResponseMessage Res = await Bills().PostAsync("bills/insert", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        async public Task<ActionResult> UpdateBill(Bill bi)
        {
            string json = JsonConvert.SerializeObject(bi);
            HttpResponseMessage Res = await Bills().PutAsync("bills/update", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
        async public Task<ActionResult> DeteleBill(Bill bi)
        {
            string json = JsonConvert.SerializeObject(bi);
            HttpResponseMessage Res = await Bills().PostAsync("bills/toggle_status", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(Bill bi)
        {

            return View(bi);
        }
        public ActionResult Delete(Bill bi)
        {

            return View(bi);
        }
        public async Task<ActionResult> Details(Bill bil)
        {

            Bill billInfo = new Bill();
            HttpResponseMessage Res = null;
            if (!string.IsNullOrEmpty(bil._id))
                Res = await Bills().GetAsync("bills/get?_id=" + bil._id);
            if (Res.IsSuccessStatusCode)
            {
                var accountingResponse = Res.Content.ReadAsStringAsync().Result;
                JObject jo = JObject.Parse(accountingResponse);
                JToken data = jo["data"][0];
              
                var jsonResponse = JsonConvert.DeserializeObject(accountingResponse);
                billInfo = JsonConvert.DeserializeObject<Bill>(data.ToString());
              //  var Billdetails = JsonConvert.DeserializeObject<Bill>(data.ToString()).billDetails;
            }
            return View(billInfo);

        }

    }
}