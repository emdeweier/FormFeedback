using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FormFeedbackAPI.Models;
using FormFeedbackAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FormFeedback.Controllers
{
    public class FeedbacksController : Controller

    {
        readonly HttpClient httpClient = new HttpClient();

        public FeedbacksController()
        {
            httpClient.BaseAddress = new Uri("https://localhost:44370/api/");
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            IEnumerable<Feedback> feedback = null;
            var responsetask = httpClient.GetAsync("Feedbacks");
            responsetask.Wait();
            var result = responsetask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Feedback>>();
                readTask.Wait();
                feedback = readTask.Result;
            }
            return Json(new { data = feedback });
        }

        public JsonResult Create(Feedback feedback)
        {
            var myContent = JsonConvert.SerializeObject(feedback);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var create = httpClient.PostAsync("Feedbacks/", ByteContent).Result;
            return Json(new { data = create });
        }
        public JsonResult GetbyId(int Id)
        {
            var cek = httpClient.GetAsync("Feedbacks/" + Id).Result;
            var read = cek.Content.ReadAsAsync<Feedback>().Result;
            return Json(new { data = read });
        }
        public JsonResult Edit(int Id, Feedback feedback)
        {
            var myContent = JsonConvert.SerializeObject(feedback);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var update = httpClient.PutAsync("Feedbacks/" + Id, ByteContent).Result;
            return Json(new { data = update });

        }
        public JsonResult Delete(int Id)
        {
            var delete = httpClient.DeleteAsync("Feedbacks/" + Id).ToString();
            return Json(new { data = delete });
        }


    }
}