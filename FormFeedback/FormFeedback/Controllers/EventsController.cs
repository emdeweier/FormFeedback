using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FormFeedbackAPI.Models;
using FormFeedbackAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FormFeedback.Controllers
{
    public class EventsController : Controller
    {
        readonly HttpClient httpClient = new HttpClient();
        readonly HttpClient clientAdhy = new HttpClient();

        public EventsController()
        {
            httpClient.BaseAddress = new Uri("https://localhost:44370/api/");
            clientAdhy.BaseAddress = new Uri("http://192.168.128.119:1708/");
            clientAdhy.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE1ODUyNzQwNDEsImlzcyI6ImJvb3RjYW1wcmVzb3VyY2VtYW5hZ2VtZW50IiwiYXVkIjoicmVhZGVycyJ9.YA-M_KN25FWmUuIS1bd9F5ioiRkVY8NCas1Bjma8kjQ");
        }

        // GET: Events
        public ActionResult Index()
        {
            ViewBag.Events = Events();
            ViewBag.Rooms = Rooms();
            ViewBag.Presentators = Presentators();
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

        // GET: Rooms List
        public IList<Room> Rooms()
        {
            IList<Room> rooms = null;
            var responseTask = httpClient.GetAsync("Rooms");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Room>>();
                readTask.Wait();
                rooms = readTask.Result;
            }

            return rooms;
        }

        // GET: Presentator List
        public IList<EmployeeVM> Presentators()
        {
            IList<EmployeeVM> employees = null;
            var responseTask = clientAdhy.GetAsync("Get");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<EmployeeVM>>();
                readTask.Wait();
                employees = readTask.Result;
            }

            return employees;
        }

        // POST: Events/Create
        public ActionResult Create(EventVM eventVM)
        {
            //httpClient.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("Token"));
            var myContent = JsonConvert.SerializeObject(eventVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var affectedRow = httpClient.PostAsync("Events/Post", byteContent).Result;
            return Json(new { data = affectedRow, affectedRow.StatusCode });
        }

        public JsonResult Get(int id)
        {
            //httpClient.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("Token"));
            var cek = httpClient.GetAsync("Events/Get/" + id).Result;
            var read = cek.Content.ReadAsAsync<IList<EventVM>>().Result;
            return Json(new { data = read });
        }

        // POST: Events/Edit/
        public ActionResult Edit(int id, EventVM eventVM)
        {
            eventVM.Date = Convert.ToDateTime(eventVM.Date.ToString("MM/dd/yyyy"));
            var myContent = JsonConvert.SerializeObject(eventVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var update = httpClient.PutAsync("Events/" + id, ByteContent).Result;
            return Json(new { data = update, update.StatusCode });
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int id)
        {
            var affectedRow = httpClient.DeleteAsync("Events/Delete/" + id).Result;
            return Json(new { data = affectedRow });
        }
    }
}