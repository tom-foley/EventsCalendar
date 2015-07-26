using EventsCalendar.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventsCalendar.WebApp.Controllers
{
    public class EventsController : Controller
    {
        private static IEventService eventService;
        private static IEventTypeService eventTypeService;
        private static IRepeatTypeService repeatTypeService;

        public EventsController(IEventService eventServiceR, IEventTypeService eventTypeServiceR, IRepeatTypeService repeatTypeServiceR)
        {
            eventService = eventServiceR;
            eventTypeService = eventTypeServiceR;
            repeatTypeService = repeatTypeServiceR;
        }

        // GET: Events
        public ActionResult Index()
        {
            ViewBag.UseLayout = true;
            ViewBag.SelectedDate = DateTime.Today;
            return View();
        }

        // GET: NewMonth
        public ActionResult GetDay()
        {
            return View();
        }

        // GET: NewMonth
        public ActionResult GetMonth(int month, int day, int year)
        {
            ViewBag.UseLayout = false;
            ViewBag.SelectedDate = new DateTime(year, month, day);
            return View("Index");
        }

        // GET: NewMonth
        public ActionResult GetYear(int year)
        {
            return View();
        }
    }
}