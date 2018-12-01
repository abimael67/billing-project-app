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
        HttpClient CustomerClient()
        {
            var client = new HttpClient();
            

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client;
            
        }
        public async Task<ActionResult> Index()
        {
            List<Customer> CustomerInfo = new List<Customer>();                          
                HttpResponseMessage Res = await CustomerClient().GetAsync("Customers/get");
            
                if (Res.IsSuccessStatusCode)
                {                   
                    var CustomerResponse = Res.Content.ReadAsStringAsync().Result;
                    JObject jo = JObject.Parse(CustomerResponse);
                    JToken data = jo["data"];
                    var jsonResponse = JsonConvert.DeserializeObject(CustomerResponse);                   
                    CustomerInfo = JsonConvert.DeserializeObject<List<Customer>>(data.ToString());
                }               
                return View(CustomerInfo);
            
        }

        public ActionResult Create(Customer art)
        {
            
            return View();
        }

       async public Task<ActionResult> Insert(Customer art)
        {
            string json = JsonConvert.SerializeObject(art);
            HttpResponseMessage Res = await CustomerClient().PostAsync("Customers/insert", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");           
        }

        async public Task<ActionResult> UpdateCustomer(Customer art)
        {
            string json = JsonConvert.SerializeObject(art);
            HttpResponseMessage Res = await CustomerClient().PutAsync("Customers/update", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
        async public Task<ActionResult> DeleteCustomer(Customer art)
        {
            string json = JsonConvert.SerializeObject(art);
            HttpResponseMessage Res = await CustomerClient().PostAsync("Customers/toggle_status", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

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