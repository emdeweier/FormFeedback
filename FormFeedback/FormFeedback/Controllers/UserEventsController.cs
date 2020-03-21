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
    public class UserEventsController : Controller
    {
        readonly HttpClient httpClient = new HttpClient();
        readonly HttpClient clientAdhy = new HttpClient();

        public UserEventsController()
        {
            httpClient.BaseAddress = new Uri("https://localhost:44370/api/");
            clientAdhy.BaseAddress = new Uri("http://192.168.128.233:1708/");
            clientAdhy.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE1ODUyNzQwNDEsImlzcyI6ImJvb3RjYW1wcmVzb3VyY2VtYW5hZ2VtZW50IiwiYXVkIjoicmVhZGVycyJ9.YA-M_KN25FWmUuIS1bd9F5ioiRkVY8NCas1Bjma8kjQ");
        }

        // GET: Events
        public ActionResult Index()
        {
            ViewBag.Events = Events();
            ViewBag.Points = Points();
            ViewBag.QuestionA = QuestionA(17);
            ViewBag.QuestionB = QuestionB(18);
            ViewBag.QuestionC = QuestionC(19);
            ViewBag.QuestionD = QuestionD(20);
            ViewBag.QuestionE = QuestionE(21);
            ViewBag.QuestionF = QuestionF(22);
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

        // GET: Points List
        public IList<Point> Points()
        {
            IList<Point> points = null;
            var responseTask = httpClient.GetAsync("Points");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Point>>();
                readTask.Wait();
                points = readTask.Result;
            }

            return points;
        }

        // GET: Question A List
        public IList<QuestionVM> QuestionA(int id)
        {
            IList<QuestionVM> questions = null;
            var responseTask = httpClient.GetAsync("Questions/GetQuest/"+id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<QuestionVM>>();
                readTask.Wait();
                questions = readTask.Result;
            }

            return questions;
        }
        
        // GET: Question B List
        public IList<QuestionVM> QuestionB(int id)
        {
            IList<QuestionVM> questions = null;
            var responseTask = httpClient.GetAsync("Questions/GetQuest/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<QuestionVM>>();
                readTask.Wait();
                questions = readTask.Result;
            }

            return questions;
        }

        // GET: Question C List
        public IList<QuestionVM> QuestionC(int id)
        {
            IList<QuestionVM> questions = null;
            var responseTask = httpClient.GetAsync("Questions/GetQuest/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<QuestionVM>>();
                readTask.Wait();
                questions = readTask.Result;
            }

            return questions;
        }

        // GET: Question D List
        public IList<QuestionVM> QuestionD(int id)
        {
            IList<QuestionVM> questions = null;
            var responseTask = httpClient.GetAsync("Questions/GetQuest/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<QuestionVM>>();
                readTask.Wait();
                questions = readTask.Result;
            }

            return questions;
        }

        // GET: Question E List
        public IList<QuestionVM> QuestionE(int id)
        {
            IList<QuestionVM> questions = null;
            var responseTask = httpClient.GetAsync("Questions/GetQuest/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<QuestionVM>>();
                readTask.Wait();
                questions = readTask.Result;
            }

            return questions;
        }

        // GET: Question F List
        public IList<QuestionVM> QuestionF(int id)
        {
            IList<QuestionVM> questions = null;
            var responseTask = httpClient.GetAsync("Questions/GetQuest/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<QuestionVM>>();
                readTask.Wait();
                questions = readTask.Result;
            }

            return questions;
        }

        public JsonResult Get(int id)
        {
            //httpClient.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("Token"));
            var cek = httpClient.GetAsync("Events/Get/" + id).Result;
            var read = cek.Content.ReadAsAsync<IList<EventVM>>().Result;
            return Json(new { data = read });
        }
    }
}