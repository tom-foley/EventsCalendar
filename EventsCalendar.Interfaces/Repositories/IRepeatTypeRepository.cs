using EventsCalendar.Interfaces;
using EventsCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCalendar.Interfaces.Repositories
{
    public partial interface IRepeatTypeRepository
    {
        IUnitOfWork UnitOfWork { get; set; }

        IOperationResult Result { get; set; }

        IOperationResult Create(RepeatType repeatType);

        RepeatType Read(long repeatTypeId);

        IOperationResult Update(RepeatType repeatType);

        IOperationResult Delete(RepeatType repeatType);

        IEnumerable<RepeatType> GetAll();
    }
}
