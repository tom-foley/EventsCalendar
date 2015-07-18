using EventsCalendar.Models;
using EventsCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCalendar.Interfaces.Repositories
{
    public partial interface IEventTypeRepository
    {
        IUnitOfWork UnitOfWork { get; set; }

        IOperationResult Result { get; set; }

        IOperationResult Create(EventType eventType);

        EventType Read(long eventTypeId);

        IOperationResult Update(EventType eventType);

        IOperationResult Update(EventType eventType, string[] fieldsToUpdate);

        IOperationResult Delete(long eventTypeId);

        IOperationResult Delete(EventType eventType);

        IEnumerable<EventType> GetAll();
    }
}
