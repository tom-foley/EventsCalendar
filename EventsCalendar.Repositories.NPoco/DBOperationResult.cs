using EventsCalendar.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCalendar.Repositories
{
    public class DBOperationResult : IOperationResult
    {
        public bool IsError { get; set; }

        public long RecordID { get; set; }

        public string ErrorMessage { get; set; }

        public string CustomMessage { get; set; }

        public string StackTrace { get; set; }

        public string InnerException { get; set; }


        public DBOperationResult()
        {
            this.IsError = false;
            this.ErrorMessage = "";
            this.CustomMessage = "";
            this.StackTrace = "";
            this.InnerException = "";
        }

        public DBOperationResult(Exception ex)
        {
            this.IsError = true;
            if (ex.Message != null) this.ErrorMessage = ex.Message;
            if (ex.StackTrace != null) this.StackTrace = ex.StackTrace.ToString();
            if (ex.InnerException != null) this.InnerException = ex.InnerException.ToString();
        }

        public void Reset()
        {
            this.IsError = false;
            this.ErrorMessage = "";
            this.CustomMessage = "";
            this.StackTrace = "";
            this.InnerException = "";
        }
    }
}
