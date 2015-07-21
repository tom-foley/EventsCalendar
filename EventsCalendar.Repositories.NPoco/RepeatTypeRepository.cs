using EventsCalendar.Interfaces;
using EventsCalendar.Interfaces.Services;
using EventsCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCalendar.Repositories.NPoco
{
    public partial class RepeatTypeRepository : IRepeatTypeRepository
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
        public RepeatTypeRepository()
        {
            ResetError();
            _UnitOfWork = new NPocoUnitOfWork();
        }

        public RepeatTypeRepository(string connectionString)
        {
            ResetError();
            _UnitOfWork = new NPocoUnitOfWork(connectionString);
        }

        public RepeatTypeRepository(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = (NPocoUnitOfWork)unitOfWork;
        }

        private void ResetError()
        {
            Result = new DBOperationResult();
        }


        /*  ----- Public Methods ----- */
        public IOperationResult Create(RepeatType repeatType)
        {
            ResetError();

            try
            {
                _UnitOfWork.db.Insert("RepeatType", "TypeID", repeatType);
                _IOperationResult.RecordID = repeatType.TypeID;
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return Result;
        }

        public RepeatType Read(long typeID)
        {
            ResetError();

            RepeatType repeatType = null;

            try
            {
                repeatType = _UnitOfWork.db.SingleOrDefault<RepeatType>("SELECT * FROM [dbo].[RepeatType] WHERE TypeID = @0", typeID);
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return repeatType;
        }

        public IOperationResult Update(RepeatType repeatType)
        {
            ResetError();

            try
            {
                _UnitOfWork.db.Update("RepeatType", "TypeID", repeatType);
                _IOperationResult.RecordID = repeatType.TypeID;
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return Result;
        }

        public IOperationResult Update(RepeatType repeatType, string[] fieldsToUpdate)
        {
            ResetError();

            try
            {
                _UnitOfWork.db.Update("RepeatType", "TypeID", repeatType);
                _IOperationResult.RecordID = repeatType.TypeID;
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return Result;
        }

        public IOperationResult Delete(long repeatTypeID)
        {
            ResetError();

            try
            {
                _UnitOfWork.db.Execute("DELETE FROM [dbo].[RepeatType] WHERE TypeID = @0", repeatTypeID);
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return Result;
        }

        public IOperationResult Delete(RepeatType repeatType)
        {
            ResetError();

            try
            {
                _UnitOfWork.db.Delete(repeatType);
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return Result;
        }

        public IEnumerable<RepeatType> GetAll()
        {
            ResetError();

            List<RepeatType> repeatTypes = null;

            try
            {
                repeatTypes = _UnitOfWork.db.Query<RepeatType>("SELECT * FROM [dbo].[RepeatType]").ToList<RepeatType>();
            }
            catch (Exception ex)
            {
                Result = new DBOperationResult(ex);
            }

            return repeatTypes;
        }
    }
}
