using EventsCalendar.Interfaces;
using EventsCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCalendar.Interfaces.Services
{
    public partial interface IRepeatTypeService
    {
        IOperationResult Result { get; set; }

        IOperationResult CreateRepeatType(RepeatType repeatType);

        RepeatType ReadRepeatType(long repeatTypeId);

        IOperationResult UpdateRepeatType(RepeatType repeatType);

        IOperationResult UpdateRepeatType(RepeatType repeatType, string[] fieldsToUpdate);

        IOperationResult DeleteRepeatType(long repeatTypeId);

        IOperationResult DeleteRepeatType(RepeatType repeatType);

        List<RepeatType> GetAllRepeatTypes();
    }
}