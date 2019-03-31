using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KevinSystem.Models;
using Microsoft.Extensions.Logging;
using KevinSystem.ViewModels.HomeViewModel;
using KevinSystem.DB;
using KevinSystem.Models.HomeModel;
using KevinSystem.Models.SystemModel;
using Newtonsoft.Json;

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
            //this.Logger.LogWarning("Index");
            HomeViewModel viewmodel = new HomeViewModel();
            Logger.LogWarning("asdasdsa");
            //var aa = new kevinSystemDB().MainFunction_Get();
            return View(viewmodel);
        }

        public string LeftManu_Get()
        {
            //this.Logger.LogWarning("Index");
            MainFunctionModel model = new MainFunctionModel();
            List<MainFunctionModel> Resuult = model.MainFunction_Get();
            //var aa = new kevinSystemDB().MainFunction_Get();
            return JsonConvert.SerializeObject(Resuult); ;
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
