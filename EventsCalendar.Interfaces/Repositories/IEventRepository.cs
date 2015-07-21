using EventsCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCalendar.Interfaces.Services
{
    public partial interface IEventRepository
    {
        IUnitOfWork UnitOfWork { get; set; }

        IOperationResult Result { get; set; }

        IOperationResult Create(Event ev);

        Event Read(long eventId);

        IOperationResult Update(Event ev);

        IOperationResult Update(Event ev, string[] fieldsToUpdate);

        IOperationResult Delete(long eventId);

        IOperationResult Delete(Event ev);

        IEnumerable<Event> GetAll();
    }
}
