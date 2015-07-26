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
    public class EventTypeService : IEventTypeService
    {
        /*  ----- Attributes/Fields/Properties ----- */
        private static IOperationResult _result;
        private static IEventTypeRepository eventTypeContext;

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
        public EventTypeService(IOperationResult result, IEventTypeRepository eventTypeR)
        {
            _result = result;
            eventTypeContext = eventTypeR;
        }


        /*  ----- Public Methods ----- */
        public IOperationResult CreateEventType(EventType eventType)
        {
            Result.Reset();

            Result = eventTypeContext.Create(eventType);

            if (Result.IsError)
            {
                Result = eventTypeContext.Result;
                Result.CustomMessage = "There was a problem creating the EventType";
            }

            return Result;
        }

        public EventType ReadEventType(long eventTypeID)
        {
            Result.Reset();

            EventType eventType = eventTypeContext.Read(eventTypeID);

            if (eventType == null)
            {
                Result.CustomMessage = "Could not find the requested EventType";
            }

            if (eventTypeContext.Result.IsError)
            {
                Result = eventTypeContext.Result;
                Result.CustomMessage = "There was a problem retrieving the requested EventType";
            }

            return eventType;
        }

        public IOperationResult UpdateEventType(EventType eventType)
        {
            Result.Reset();

            Result = eventTypeContext.Update(eventType);

            if (Result.IsError)
            {
                Result = eventTypeContext.Result;
                Result.CustomMessage = "There was a problem updating the requested EventType";
            }

            return Result;
        }

        public IOperationResult DeleteEventType(EventType eventType)
        {
            Result.Reset();

            Result = eventTypeContext.Delete(eventType);

            if (Result.IsError)
            {
                Result = eventTypeContext.Result;
                Result.CustomMessage = "There was a problem deleting the requested EventType";
            }

            return Result;
        }

        public List<EventType> GetAllEventTypes()
        {
            Result.Reset();

            List<EventType> eventTypes = eventTypeContext.GetAll().ToList();

            if (eventTypes == null)
            {
                Result.CustomMessage = "Could not find the requested EventTypes";
            }

            if (eventTypeContext.Result.IsError)
            {
                Result = eventTypeContext.Result;
                Result.CustomMessage = "There was a problem retrieving the requested EventTypes";
            }

            return eventTypes;
        }
    }
}
