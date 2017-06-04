using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EventPlanner3.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using EventPlanner3.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner3.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db_context;

        public HomeController(ApplicationDbContext context)
        {
            db_context = context;
        }

        public IActionResult Index(string searchString, int? eTypeFilter = 0)
        {
            // Create and populate 
            var eType = db_context.EventType.OrderBy(c => c.Label).Select(c => new { id = c.Id, value = c.Label }).ToList();
            ViewBag.EventTypeSelectList = new SelectList(eType, "id", "value");

            // Create an empty Event object
            IQueryable<Event> events;

            var e_all = db_context.Event.Include(a => a.EventType).Select(a => a);

            if (!String.IsNullOrEmpty(searchString))
            {
                eTypeFilter = 0;

                e_all = e_all.Where(a => a.Location.Contains(searchString));
            }
            else
            {
                // do nothing, all
                events = e_all.Select(s => s);
            }

            if (eTypeFilter > 0)
            {
                events = e_all.Where(a => a.EventTypeID == eTypeFilter);
            }
            else
            {
                // do nothing, all
                events = e_all.Select(s => s);
            }

            return View(events.ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
