using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCalendar.Models
{
    public interface IOperationResult
    {
        void Reset();
    }

    public class DBOperationResult : IOperationResult
    {
        public bool IsError { get; set; }

        public long RecordId { get; set; }

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
            this.ErrorMessage = ex.Message;
            this.StackTrace = ex.StackTrace.ToString();
            this.InnerException = ex.InnerException.ToString();
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
