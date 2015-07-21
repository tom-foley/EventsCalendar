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
        public DBOperationResult CreateEventType(EventType eventType)
        {
            Result.Reset();

            Result = eventTypeContext.Create(eventType);

            if (Result.IsError)
            {
                Result = eventTypeContext.Result;
                Result.CustomMessage = "There was a problem creating the EventType";
            }

            return (DBOperationResult)Result;
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

        public DBOperationResult UpdateEventType(EventType eventType)
        {
            Result.Reset();

            Result = eventTypeContext.Update(eventType);

            if (Result.IsError)
            {
                Result = eventTypeContext.Result;
                Result.CustomMessage = "There was a problem updating the requested EventType";
            }

            return (DBOperationResult)Result;
        }

        public DBOperationResult UpdateEventType(EventType eventType, string[] fieldsToUpdate)
        {
            Result.Reset();

            Result = eventTypeContext.Update(eventType, fieldsToUpdate);

            if (Result.IsError)
            {
                Result = eventTypeContext.Result;
                Result.CustomMessage = "There was a problem updating the requested EventType";
            }

            return (DBOperationResult)Result;
        }

        public DBOperationResult DeleteEventType(long eventTypeID)
        {
            Result.Reset();

            Result = eventTypeContext.Delete(eventTypeID);

            if (Result.IsError)
            {
                Result = eventTypeContext.Result;
                Result.CustomMessage = "There was a problem deleting the requested EventType";
            }

            return (DBOperationResult)Result;
        }

        public DBOperationResult DeleteEventType(EventType eventType)
        {
            Result.Reset();

            Result = eventTypeContext.Delete(eventType);

            if (Result.IsError)
            {
                Result = eventTypeContext.Result;
                Result.CustomMessage = "There was a problem deleting the requested EventType";
            }

            return (DBOperationResult)Result;
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
