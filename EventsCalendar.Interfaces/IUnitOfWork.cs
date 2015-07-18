using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCalendar.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void StartNew();

        void Commit();

        void Rollback();
    }
}
