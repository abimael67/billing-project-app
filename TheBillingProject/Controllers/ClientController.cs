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
    public class ClientController : Controller
    {
        string Baseurl = "https://billing-project-api.herokuapp.com/";
        HttpClient Clients()
        {
            var client = new HttpClient();


            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;

        }

        public async Task<ActionResult> Index()
        {
            List<Client> clientInfo = new List<Client>();
            HttpResponseMessage Res = await Clients().GetAsync("customers/get");

            if (Res.IsSuccessStatusCode)
            {
                var clientResponse = Res.Content.ReadAsStringAsync().Result;
                JObject jo = JObject.Parse(clientResponse);
                JToken data = jo["data"];
                var jsonResponse = JsonConvert.DeserializeObject(clientResponse);
                clientInfo = JsonConvert.DeserializeObject<List<Client>>(data.ToString());
            }
            return View(clientInfo);

        }

        public ActionResult Create(Client cli)
        {

            return View();
        }

        async public Task<ActionResult> Insert(Client cli)
        {
            string json = JsonConvert.SerializeObject(cli);
            HttpResponseMessage Res = await Clients().PostAsync("customers/insert", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        async public Task<ActionResult> UpdateClient(Client cli)
        {
            string json = JsonConvert.SerializeObject(cli);
            HttpResponseMessage Res = await Clients().PutAsync("customers/update", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        async public Task<ActionResult> DeleteClient(Client cli)
        {
            string json = JsonConvert.SerializeObject(cli);
            HttpResponseMessage Res = await Clients().PostAsync("customers/toggle_status", new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(Client cli)
        {

            return View(cli);
        }
        public ActionResult Delete(Client cli)
        {

            return View(cli);
        }
    }

}