using EventsCalendar.Interfaces;
using EventsCalendar.Interfaces.Repositories;
using EventsCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCalendar.Repositories.NPoco
{
    public partial class EventsRepository : IEventsRepository
    {
        /*  ----- Attributes/Fields/Properties ----- */
        DBOperationResult _IOperationResult = new DBOperationResult();

        public IOperationResult Result
        {
            get
            {
                return _IOperationResult;
            }
            set
            {
                _IOperationResult = (DBOperationResult)value;
            }
        }

        NPocoUnitOfWork _UnitOfWork = null;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _UnitOfWork;
            }
            set
            {
                _UnitOfWork = (NPocoUnitOfWork)value;
            }
        }


        /*  ----- Constructors ----- */
        public EventsRepository()
        {
            ResetError();
            _UnitOfWork = new NPocoUnitOfWork();
        }

        public EventsRepository(string connectionString)
        {
            ResetError();
            _UnitOfWork = new NPocoUnitOfWork(connectionString);
        }

        public EventsRepository(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = (NPocoUnitOfWork)unitOfWork;
        }

        private void ResetError()
        {
            Result = new DBOperationResult();
        }


        /*  ----- Public Methods ----- */
        public IOperationResult Create(Event ev)
        {

        }

        public Event Read(long eventId)
        {

        }

        public IOperationResult Update(Event ev)
        {

        }

        public IOperationResult Update(Event ev, string[] fieldsToUpdate)
        {

        }

        public IOperationResult Delete(long eventId)
        {

        }

        public IOperationResult Delete(Event ev)
        {

        }

        public IEnumerable<Event> GetAll()
        {

        }
    }
}