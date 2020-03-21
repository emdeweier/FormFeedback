using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FormFeedbackAPI.Models;
using FormFeedbackAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FormFeedback.Reports;

namespace FormFeedback.Controllers
{
    public class QuestionsController : Controller
    {
        readonly HttpClient httpClient = new HttpClient();
        //readonly HttpClient clientAdhy = new HttpClient();

        public QuestionsController()
        {
            httpClient.BaseAddress = new Uri("https://localhost:44370/api/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
        }

        // GET: Questions
        public ActionResult Index()
        {
            //var token = HttpContext.Session.GetString("Token");
            //var role = HttpContext.Session.GetString("Role");
            //if (token != null)
            //{
            //    httpClient.DefaultRequestHeaders.Add("Authorization", token);
            //    if(role != "Admin")
            //    {
            //        if(role == "Presentator")
            //        {
            //            return RedirectToAction("", "PresentatorEvents");
            //        }
            //        else
            //        {
            //            return RedirectToAction("","DashboardUser");
            //        }
            //    }
            //    else
            //    {
                    ViewBag.Questions = Questions();
                    ViewBag.Options = Options();
                    return View();
            //    }
            //}
            //return RedirectToAction("", "Home");
        }

        public ActionResult Report(QuestionVM question)
        {
            QuestionReport questionsReport = new QuestionReport();
            byte[] qbytes = questionsReport.PrepareReport(GetDataQuestion());
            return File(qbytes, "application/pdf", "Questions.pdf");
        }

        public List<QuestionVM> GetDataQuestion()
        {
            List<QuestionVM> questions = new List<QuestionVM>();
            var responseTask = httpClient.GetAsync("Questions/GetQuestOpt");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<QuestionVM>>();
                readTask.Wait();
                questions = readTask.Result;
            }
            return questions;
        }



        // GET: Questions List
        public IList<Question> Questions()
        {
            IList<Question> questions = null;
            var responseTask = httpClient.GetAsync("Questions");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Question>>();
                readTask.Wait();
                questions = readTask.Result;
            }

            return questions;
        }

        // GET: Options List
        public IList<Option> Options()
        {
            IList<Option> options = null;
            var responseTask = httpClient.GetAsync("Options");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Option>>();
                readTask.Wait();
                options = readTask.Result;
            }

            return options;
        }

        // GET: Questions/Create
        public async Task<ActionResult> Create(Question question)
        {
            //httpClient.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("Token"));
            var myContent = JsonConvert.SerializeObject(question);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var affectedRow = httpClient.PostAsync("Questions", byteContent).Result;
            return Json(new { data = affectedRow, affectedRow.StatusCode });
        }

        public JsonResult Get(int id)
        {
            //httpClient.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("Token"));
            var cek = httpClient.GetAsync("Questions/" + id).Result;
            var read = cek.Content.ReadAsAsync<QuestionVM>().Result;
            return Json(new { data = read });
        }

        // POST: Questions/Edit/
        public ActionResult Edit(int Id, QuestionVM questionVM)
        {
            var myContent = JsonConvert.SerializeObject(questionVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var update = httpClient.PutAsync("Questions/" + Id, ByteContent).Result;
            return Json(new { data = update, update.StatusCode });
        }

        // GET: Questions/Delete/
        public JsonResult Delete(int id)
        {
            var affectedRow = httpClient.DeleteAsync("Questions/Delete/" + id).Result;
            return Json(new { data = affectedRow });
        }
    }
}