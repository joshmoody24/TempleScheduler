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
        private AppointmentContext _xContext { get; set; }

        public HomeController(Group _group, AppointmentContext x)
        {
            appointment = _group;
            _xContext = x;
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


        // Beginning of John's actions
        [HttpGet]
        public IActionResult Appointments()
        {
            var appointments = _xContext.Groups
                .ToList();

            return View(appointments);
        }

        [HttpGet]
        public IActionResult Edit(int appointmentid)
        {
            var appointment = _xContext.Groups
                .Single(x => x.AppointmentId == appointmentid);

            return View("Form", appointment);
        }

        [HttpPost]
        public IActionResult Edit(Group gr)
        {
            _xContext.Update(gr);
            _xContext.SaveChanges();

            return RedirectToAction("Appointments");
        }

        [HttpGet]
        public IActionResult Delete(int appointmentid)
        {
            var appointment = _xContext.Groups
                .Single(x => x.AppointmentId == appointmentid);

            return View(appointment);
        }

        [HttpPost]
        public IActionResult Delete(Group gr)
        {
            _xContext.Groups.Remove(gr);
            _xContext.SaveChanges();

            return RedirectToAction("Appointments");
        }
        // End of John's actions


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
