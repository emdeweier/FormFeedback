using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FormFeedbackAPI.ViewModels.Graph;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FormFeedback.Controllers
{
    public class DashboardController : Controller
    {
        readonly HttpClient httpClient = new HttpClient();

        public DashboardController()
        {
            httpClient.BaseAddress = new Uri("https://localhost:44370/api/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
        }

        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
        
        // GET: Count Room
        public JsonResult CountRoom()
        {
            IEnumerable<GraphRoomVM> graphVMs = null;
            var responseTask = httpClient.GetAsync("Rooms/GetCount");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<GraphRoomVM>>();
                readTask.Wait();
                graphVMs = readTask.Result;
            }

            return Json(JsonConvert.SerializeObject(graphVMs.ToList(), Formatting.Indented));
        }

        // GET: Count Room Event
        public JsonResult CountRoomEvent(int mth, int yrs)
        {
            IEnumerable<GraphRoomEventVM> graphVMs = null;
            var responseTask = httpClient.GetAsync("Rooms/GetCountEvent/"+mth+"/"+yrs);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<GraphRoomEventVM>>();
                readTask.Wait();
                graphVMs = readTask.Result;
            }

            return Json(JsonConvert.SerializeObject(graphVMs.ToList(), Formatting.Indented));
        }
    }
}