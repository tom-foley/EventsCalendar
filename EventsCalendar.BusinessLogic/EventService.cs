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
        public DBOperationResult CreateEvent(Event ev)
        {
            Result.Reset();

            Result = eventContext.Create(ev);

            if (Result.IsError)
            {
                Result = eventContext.Result;
                Result.CustomMessage = "There was a problem creating the Event";
            }

            return (DBOperationResult)Result;
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

        public DBOperationResult UpdateEvent(Event ev)
        {
            Result.Reset();

            Result = eventContext.Update(ev);

            if (Result.IsError)
            {
                Result = eventContext.Result;
                Result.CustomMessage = "There was a problem updating the requested Event";
            }

            return (DBOperationResult)Result;
        }

        public DBOperationResult UpdateEvent(Event ev, string[] fieldsToUpdate)
        {
            Result.Reset();

            Result = eventContext.Update(ev, fieldsToUpdate);

            if (Result.IsError)
            {
                Result = eventContext.Result;
                Result.CustomMessage = "There was a problem updating the requested Event";
            }

            return (DBOperationResult)Result;
        }

        public DBOperationResult DeleteEvent(long eventID)
        {
            Result.Reset();

            Result = eventContext.Delete(eventID);

            if (Result.IsError)
            {
                Result = eventContext.Result;
                Result.CustomMessage = "There was a problem deleting the requested Event";
            }

            return (DBOperationResult)Result;
        }

        public DBOperationResult DeleteEvent(Event ev)
        {
            Result.Reset();

            Result = eventContext.Delete(ev);

            if (Result.IsError)
            {
                Result = eventContext.Result;
                Result.CustomMessage = "There was a problem deleting the requested Event";
            }

            return (DBOperationResult)Result;
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
    }
}
