using EventsCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCalendar.Interfaces.Services
{
    public partial interface IEventTypeService
    {
        IOperationResult Result { get; set; }

        IOperationResult CreateEventType(EventType eventType);

        EventType ReadEventType(long eventTypeId);

        IOperationResult UpdateEventType(EventType eventType);

        IOperationResult DeleteEventType(EventType eventType);

        List<EventType> GetAllEventTypes();
    }
}
