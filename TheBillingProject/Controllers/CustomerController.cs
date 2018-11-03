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
    public class CustomerController : Controller
    {
        string Baseurl = "https://billing-project-api.herokuapp.com/";
        HttpClient customerClient()
        {
            var client = new HttpClient();
            

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client;
            
        }
        public async Task<ActionResult> Index()
        {
            List<Customer> customerInfo = new List<Customer>();                          
                HttpResponseMessage Res = await customerClient().GetAsync("customers/get");
            
                if (Res.IsSuccessStatusCode)
                {                   
                    var customerResponse = Res.Content.ReadAsStringAsync().Result;
                    JObject jo = JObject.Parse(customerResponse);
                    JToken data = jo["data"];
                    var jsonResponse = JsonConvert.DeserializeObject(customerResponse);                   
                    customerInfo = JsonConvert.DeserializeObject<List<Customer>>(data.ToString());
                }               
                return View(customerInfo);
            
        }

        public ActionResult Create(Customer art)
        {
            
            return View();
        }

       async public Task<ActionResult> Insert(Customer art)
        {
            string json = JsonConvert.SerializeObject(art);
            HttpResponseMessage Res = await customerClient().PostAsync("customers/insert", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");           
        }

        async public Task<ActionResult> Updatecustomer(Customer art)
        {
            string json = JsonConvert.SerializeObject(art);
            HttpResponseMessage Res = await customerClient().PutAsync("customers/update", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
        async public Task<ActionResult> Deletecustomer(Customer art)
        {
            string json = JsonConvert.SerializeObject(art);
            HttpResponseMessage Res = await customerClient().PostAsync("customers/toggle_status", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(Customer art)
        {

            return View(art);
        }
        public ActionResult Delete(Customer art)
        {

            return View(art);
        }
    }
}