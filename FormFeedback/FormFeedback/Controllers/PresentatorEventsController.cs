using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FormFeedbackAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormFeedback.Controllers
{
    public class PresentatorEventsController : Controller
    {
        readonly HttpClient httpClient = new HttpClient();

        public PresentatorEventsController()
        {
            httpClient.BaseAddress = new Uri("https://localhost:44370/api/");
        }

        // GET: PresentatorEvents
        public ActionResult Index()
        {
            ViewBag.Events = Events();
            return View();
        }

        // GET: Events List
        public IList<EventVM> Events()
        {
            IList<EventVM> events = null;
            var responseTask = httpClient.GetAsync("Events/Get");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<EventVM>>();
                readTask.Wait();
                events = readTask.Result;
            }
            return events;
        }
    }
}