using EventsCalendar.Interfaces;
using EventsCalendar.Interfaces.Repositories;
using EventsCalendar.Interfaces.Services;
using EventsCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCalendar.BusinessLogic
{
    public class EventService : IEventService
    {
        /*  ----- Attributes/Fields/Properties ----- */
        private static IOperationResult _result;
        private static IEventRepository eventContext;

        public IOperationResult Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }


        /*  ----- Constructors ----- */
        public EventService(IOperationResult result, IEventRepository eventR)
        {
            _result = result;
            eventContext = eventR;
        }


        /*  ----- Public Methods ----- */
        public IOperationResult CreateEvent(Event ev)
        {
            Result.Reset();

            Result = eventContext.Create(ev);

            if (Result.IsError)
            {
                Result = eventContext.Result;
                Result.CustomMessage = "There was a problem creating the Event";
            }

            return Result;
        }

        public Event ReadEvent(long eventID)
        {
            Result.Reset();

            Event ev = eventContext.Read(eventID);

            if (ev == null)
            {
                Result.CustomMessage = "Could not find the requested Event";
            }

            if (eventContext.Result.IsError)
            {
                Result = eventContext.Result;
                Result.CustomMessage = "There was a problem retrieving the requested Event";
            }

            return ev;
        }

        public IOperationResult UpdateEvent(Event ev)
        {
            Result.Reset();

            Result = eventContext.Update(ev);

            if (Result.IsError)
            {
                Result.CustomMessage = "There was a problem updating the requested Event";
            }

            return Result;
        }

        public IOperationResult DeleteEvent(Event ev)
        {
            Result.Reset();

            Result = eventContext.Delete(ev);

            if (Result.IsError)
            {
                Result.CustomMessage = "There was a problem deleting the requested Event";
            }

            return Result;
        }

        public List<Event> GetAllEvents()
        {
            Result.Reset();

            List<Event> events = eventContext.GetAll().ToList();

            if (events == null)
            {
                Result.CustomMessage = "Could not find the requested Events";
            }

            if (eventContext.Result.IsError)
            {
                Result = eventContext.Result;
                Result.CustomMessage = "There was a problem retrieving the requested Events";
            }

            return events;
        }

        public List<Event> GetAllEventsFromMonth(int year, int month)
        {
            Result.Reset();

            List<Event> events = eventContext.GetAllEventsFromMonth(year, month).ToList<Event>();

            if (events == null)
            {
                Result.CustomMessage = "Could not find the requested Events from month " + month.ToString();
            }

            if (eventContext.Result.IsError)
            {
                Result = eventContext.Result;
                Result.CustomMessage = "There was a problem retrieving the requested Event from month " + month.ToString();
            }

            return events;
        }

        public List<DateTime> GetAllEventDatesFromMonth(int year, int month)
        {
            Result.Reset();

            List<DateTime> eventDates = eventContext.GetAllEventDatesFromMonth(year, month).ToList<DateTime>();

            if (eventDates == null)
            {
                Result.CustomMessage = "Could not find the requested Event Dates";
            }

            if (eventContext.Result.IsError)
            {
                Result = eventContext.Result;
                Result.CustomMessage = "There was a problem retrieving the requested Event Dates";
            }

            return eventDates;
        }
    }
}
