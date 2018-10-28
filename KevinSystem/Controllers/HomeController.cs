using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KevinSystem.Models;
using Microsoft.Extensions.Logging;

namespace KevinSystem.Controllers
{
    public class HomeController : Controller
    {

        private ILogger<HomeController> Logger { get; set; }
        public HomeController(ILogger<HomeController> logger)
        {
            this.Logger = logger;
        }
        public IActionResult Index()
        {
            this.Logger.LogWarning("Index");
            return View();
        }

        public IActionResult About()
        {
            this.Logger.LogWarning("About");
            ViewData["Message"] = "Your application description page.";
            
            return View();
        }

        public IActionResult Contact()
        {
            this.Logger.LogTrace("Contact");
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
