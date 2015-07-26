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
    public partial class EventTypeRepository : IEventTypeRepository
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
        public EventTypeRepository()
        {
            ResetError();
            _UnitOfWork = new NPocoUnitOfWork();
        }

        public EventTypeRepository(string connectionString)
        {
            ResetError();
            _UnitOfWork = new NPocoUnitOfWork(connectionString);
        }

        public EventTypeRepository(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = (NPocoUnitOfWork)unitOfWork;
        }

        private void ResetError()
        {
            Result = new DBOperationResult();
        }


        /*  ----- Public Methods ----- */
        public IOperationResult Create(EventType eventType)
        {
            ResetError();

            try
            {
                _UnitOfWork.db.Insert("EventType", "TypeID", eventType);
                _IOperationResult.RecordID = eventType.TypeID;
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return Result;
        }

        public EventType Read(long typeID)
        {
            ResetError();

            EventType eventType = null;

            try
            {
                eventType = _UnitOfWork.db.SingleOrDefault<EventType>("SELECT * FROM [dbo].[EventType] WHERE TypeID = @0", typeID);
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return eventType;
        }

        public IOperationResult Update(EventType eventType)
        {
            ResetError();

            try
            {
                _UnitOfWork.db.Update("EventType", "TypeID", eventType);
                _IOperationResult.RecordID = eventType.TypeID;
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return Result;
        }

        public IOperationResult Delete(EventType eventType)
        {
            ResetError();

            try
            {
                _UnitOfWork.db.Delete(eventType);
                //_UnitOfWork.db.Execute("DELETE FROM [dbo].[EventType] WHERE TypeID = @0", eventTypeID);
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return Result;
        }

        public IEnumerable<EventType> GetAll()
        {
            ResetError();

            List<EventType> eventTypes = null;

            try
            {
                eventTypes = _UnitOfWork.db.Query<EventType>("SELECT * FROM [dbo].[EventType]").ToList<EventType>();
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return eventTypes;
        }
    }
}
