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
        public IEnumerable<DateTime> GetAllEventsFromMonth(int month, int year)
        {
            ResetError();

            List<DateTime> events = null;

            try
            {
                events = _UnitOfWork.db.Query<DateTime>("SELECT DISTINCT(CONVERT(VARCHAR, CONVERT(DATETIME,[EventStart]),23)) AS StartDate FROM [dbo].[Event] WHERE Month([EventStart]) = @0 AND Year([EventStart]) = @1 ORDER BY StartDate ASC", month, year).ToList<DateTime>();
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return events;
        }
    }
}
