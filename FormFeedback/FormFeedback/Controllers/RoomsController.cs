using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FormFeedbackAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FormFeedback.Controllers
{
    public class RoomsController : Controller
    {
        readonly HttpClient httpClient = new HttpClient();

        public RoomsController()
        {
            httpClient.BaseAddress = new Uri("https://localhost:44370/api/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
        }

        // GET: Rooms
        public ActionResult Index()
        {
            ViewBag.Rooms = Rooms();
            return View();
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

        // POST: Rooms/Create
        public async Task<ActionResult> Create(Room room)
        {
            var myContent = JsonConvert.SerializeObject(room);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var affectedRow = httpClient.PostAsync("Rooms", byteContent).Result;
            return Json(new { data = affectedRow, affectedRow.StatusCode });
        }

        public JsonResult Get(int id)
        {
            //httpClient.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("Token"));
            var cek = httpClient.GetAsync("Rooms/" + id).Result;
            var read = cek.Content.ReadAsAsync<Room>().Result;
            return Json(new { data = read });
        }

        // POST: Rooms/Edit/
        public ActionResult Edit(int id, Room room)
        {
            var myContent = JsonConvert.SerializeObject(room);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var update = httpClient.PutAsync("Rooms/" + id, ByteContent).Result;
            return Json(new { data = update, update.StatusCode });
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete(int id)
        {
            var affectedRow = httpClient.DeleteAsync("Rooms/Delete/" + id).Result;
            return Json(new { data = affectedRow });
        }
    }
}