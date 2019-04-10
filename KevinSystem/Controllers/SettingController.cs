using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KevinSystem.Controllers
{
    public class SettingController : Controller
    {
        public IActionResult FunctionSettingPage()
        {
            return View();
        }
    }
}