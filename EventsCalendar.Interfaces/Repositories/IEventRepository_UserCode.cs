using EventsCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCalendar.Interfaces.Repositories
{
    public partial interface IEventRepository
    {
        IEnumerable<Event> GetAllEventsFromMonth(int year, int month);

        IEnumerable<DateTime> GetAllEventDatesFromMonth(int year, int month);
    }
}