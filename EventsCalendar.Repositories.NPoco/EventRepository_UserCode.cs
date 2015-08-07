using EventsCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCalendar.Repositories.NPoco
{
    public partial class EventRepository
    {
        public IEnumerable<Event> GetAllEventsFromMonth(int year, int month)
        {
            ResetError();

            List<Event> events = null;

            try
            {
                events = _UnitOfWork.db.Query<Event>("SELECT * FROM [dbo].[Event] WHERE Month([EventStart]) = @0 AND Year([EventStart]) = @1 ORDER BY StartDate ASC", month, year).ToList<Event>();
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return events;
        }
        

        public IEnumerable<DateTime> GetAllEventDatesFromMonth(int year, int month)
        {
            ResetError();

            List<DateTime> eventDates = null;

            try
            {
                eventDates = _UnitOfWork.db.Query<DateTime>("SELECT DISTINCT(CONVERT(VARCHAR, CONVERT(DATETIME,[EventStart]),23)) AS StartDate FROM [dbo].[Event] WHERE Month([EventStart]) = @0 AND Year([EventStart]) = @1 ORDER BY StartDate ASC", month, year).ToList<DateTime>();
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return eventDates;
        }
    }
}
