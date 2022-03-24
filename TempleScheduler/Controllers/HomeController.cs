using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private AppointmentContext context { get; set; }

        public HomeController(AppointmentContext x)
        {
            context = x;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Form(int timeslotid)
        {
            TimeSlot t = context.TimeSlots.Include(t => t.Group).FirstOrDefault(x => x.TimeSlotId == timeslotid);
            if(t.Group == null)
            {
                t.Group = new Group();
            }
            return View(t);
        }

        [HttpPost]
        public IActionResult Form(TimeSlot t)
        {
            if (ModelState.IsValid)
            {
                //context.Groups.Add(t.Group);
                context.TimeSlots.Update(t);
                context.SaveChanges();
                return RedirectToAction("Appointments");
            }
            return View();
        }


        // Beginning of John's actions
        [HttpGet]
        public IActionResult Appointments()
        {
            // get all time slots that have been reserved (have a group attached to them)
            List<TimeSlot> appointments = context.TimeSlots
                .Include(x => x.Group)
                .Where(x => x.GroupId != null)
                .ToList();

            return View(appointments);
        }

        [HttpGet]
        public IActionResult Edit(int groupid)
        {
            var appointment = context.TimeSlots
                .Include(x => x.Group)
                .Single(x => x.Group.GroupId == groupid);

            return View("Form", appointment);
        }

        [HttpPost]
        public IActionResult Edit(Group gr)
        {
            context.Update(gr);
            context.SaveChanges();

            return RedirectToAction("Appointments");
        }

        [HttpGet]
        public IActionResult Delete(int groupid)
        {
            var group = context.Groups
                .FirstOrDefault(x => x.GroupId == groupid);

            if (group != null)
            {
                return View(group);
            }
            else return RedirectToAction("Appointments");
        }

        [HttpPost]
        public IActionResult Delete(Group gr)
        {
            // first, remove the foreign key pointing to the group
            var timeSlot = context.TimeSlots.Single(x => x.Group.GroupId == gr.GroupId);
            timeSlot.Group = null;
            context.TimeSlots.Update(timeSlot);
            context.Groups.Remove(gr);
            context.SaveChanges();

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
            GenerateTimeSlots();
            List<TimeSlot> timeSlots = context.TimeSlots
                .Include(x => x.Group)
                .OrderBy(x => x.Date)
                .ThenBy(x => x.Time)
                .ToList<TimeSlot>();
            return View(timeSlots);
        }

        public void GenerateTimeSlots()
        {
            // fetch all timeslots from the database for faster searching
            List<TimeSlot> existingTimeSlots = context.TimeSlots.ToList<TimeSlot>();

            // automatically generate timeslots up to 90 days in advance whenever someone visits this page
            DateTime currentTime = DateTime.Now;
            const int NUM_DAYS_GENERATED_IN_ADVANCE = 90;
            for (int i = 0; i < NUM_DAYS_GENERATED_IN_ADVANCE; i++)
            {
                // skip days that are mondays or sundays (temples are closed those days)
                if (currentTime.DayOfWeek != DayOfWeek.Sunday && currentTime.DayOfWeek != DayOfWeek.Monday)
                {
                    // generate time slots from hour 8 to 20
                    for (int hour = 8; hour <= 20; hour++)
                    {
                        // check if a timeslot for this time already exists
                        DateTime date = currentTime.Date;
                        Console.WriteLine(date);
                        TimeSlot timeslot = existingTimeSlots.FirstOrDefault(t => t.Date.Equals(date) && t.Time == hour);
                        if (timeslot == null)
                        {
                            timeslot = new TimeSlot
                            {
                                GroupId = null,
                                Date = date,
                                Time = hour
                            };
                            context.TimeSlots.Add(timeslot);
                        }
                    }
                }
                currentTime += TimeSpan.FromDays(1);
            }
            context.SaveChanges();
        }
    }
}
