using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TheBillingProject.Models;

namespace TheBillingProject.Controllers
{
    public class AccountingMoveController : Controller
    {
        // GET: AccountingMove
     

        string Baseurl = "http://localhost:3000/";
        HttpClient AccountingClient()
        {
            var client = new HttpClient();


            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;

        }

        async public Task<ActionResult> Create()
        {
            
            HttpResponseMessage Res = await AccountingClient().PostAsync("accounting/insert", new StringContent("", UnicodeEncoding.UTF8, "application/json"));

            Res.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Index(string desc)
        {

            List<AccountingMove> accountingInfo = new List<AccountingMove>();
            HttpResponseMessage Res = null;
            if (string.IsNullOrEmpty(desc))
                Res = await AccountingClient().GetAsync("accounting/get");
            else
                Res = await AccountingClient().GetAsync("articles/get?desc=" + desc);
            if (Res.IsSuccessStatusCode)
            {
                var accountingResponse = Res.Content.ReadAsStringAsync().Result;
                JObject jo = JObject.Parse(accountingResponse);
                JToken data = jo["data"];
                var jsonResponse = JsonConvert.DeserializeObject(accountingResponse);
                accountingInfo = JsonConvert.DeserializeObject<List<AccountingMove>>(data.ToString());
            }
            return View(accountingInfo);

        }

        public async Task<ActionResult> Details(AccountingMove acc)
        {

            AccountingMove accountingInfo = new AccountingMove();
            HttpResponseMessage Res = null;
            if (!string.IsNullOrEmpty(acc._id))
                Res = await AccountingClient().GetAsync("accounting/get?_id="+ acc._id);           
            if (Res.IsSuccessStatusCode)
            {
                var accountingResponse = Res.Content.ReadAsStringAsync().Result;
                JObject jo = JObject.Parse(accountingResponse);
                JToken data = jo["data"][0];
                var jsonResponse = JsonConvert.DeserializeObject(accountingResponse);
                accountingInfo = JsonConvert.DeserializeObject<AccountingMove>(data.ToString());
            }
            return View(accountingInfo);

        }
    }
}