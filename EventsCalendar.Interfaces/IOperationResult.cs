using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCalendar.Interfaces
{
    public interface IOperationResult
    {
        bool IsError { get; set; }

        string ErrorMessage { get; set; }

        string CustomMessage { get; set; }

        string StackTrace { get; set; }

        string InnerException { get; set; }

        void Reset();
    }
}
