using EventsCalendar.Interfaces;
using EventsCalendar.Interfaces.Repositories;
using EventsCalendar.Interfaces.Services;
using EventsCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCalendar.Repositories.NPoco
{
    public partial class EventRepository : IEventRepository
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
        public EventRepository()
        {
            ResetError();
            _UnitOfWork = new NPocoUnitOfWork();
        }

        public EventRepository(string connectionString)
        {
            ResetError();
            _UnitOfWork = new NPocoUnitOfWork(connectionString);
        }

        public EventRepository(IUnitOfWork unitOfWork)
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
            ResetError();

            try
            {
                _UnitOfWork.db.Insert("Event", "EventID", ev);
                _IOperationResult.RecordID = ev.EventID;
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return Result;
        }

        public Event Read(long eventID)
        {
            ResetError();

            Event ev = null;

            try
            {
                ev = _UnitOfWork.db.SingleOrDefault<Event>("SELECT * FROM [dbo].[Event] WHERE EventID = @0", eventID);
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return ev;
        }

        public IOperationResult Update(Event ev)
        {
            ResetError();

            try
            {
                _UnitOfWork.db.Update("Event", "EventID", ev);
                _IOperationResult.RecordID = ev.EventID;
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return Result;
        }

        public IOperationResult Update(Event ev, string[] fieldsToUpdate)
        {
            ResetError();

            try
            {
                _UnitOfWork.db.Update("Event", "EventID", ev);
                _IOperationResult.RecordID = ev.EventID;
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return Result;
        }

        public IOperationResult Delete(long eventID)
        {
            ResetError();

            try
            {
                _UnitOfWork.db.Execute("DELETE FROM [dbo].[Event] WHERE EventID = @0", eventID);
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return Result;
        }

        public IOperationResult Delete(Event ev)
        {
            ResetError();

            try
            {
                _UnitOfWork.db.Delete(ev);
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return Result;
        }

        public IEnumerable<Event> GetAll()
        {
            ResetError();

            List<Event> events = null;

            try
            {
                events = _UnitOfWork.db.Query<Event>("SELECT * FROM [dbo].[Event]").ToList<Event>();
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return events;
        }
    }
}