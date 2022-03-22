using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TempleScheduler.Models;

namespace TempleScheduler.Controllers
{
    public class HomeController : Controller
    {
        private Group appointment { get; set; }

        public HomeController(Group _group)
        {
            appointment = _group;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form(Group gr)
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SignUp()
        {
            return View();
        }
    }
}
