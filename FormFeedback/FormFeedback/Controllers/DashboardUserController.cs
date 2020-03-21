using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FormFeedback.Controllers
{
    public class DashboardUserController : Controller
    {
        readonly HttpClient httpClient = new HttpClient();

        public DashboardUserController()
        {
            httpClient.BaseAddress = new Uri("https://localhost:44370/api/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}