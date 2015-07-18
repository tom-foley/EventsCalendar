using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using NPoco;
using NPoco.FluentMappings;
using System.Configuration;
using EventsCalendar.Interfaces;

namespace EventsCalendar.Repositories.NPoco
{
    public class NPocoUnitOfWork : IUnitOfWork
    {
        
        private IDatabase _db = null;
        private string _ConnectionString = "";

        public IDatabase db 
        {
            get
            {
                return _db;
            } 
        }

        public string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
        }

        public NPocoUnitOfWork()
        {
            _db = NPocoDatabaseFactory.InitializeFactory().GetDatabase();
            _ConnectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        }


        public NPocoUnitOfWork(string ConnectionString)
        {
            _db = NPocoDatabaseFactory.InitializeFactory(ConnectionString).GetDatabase();
            _ConnectionString = ConnectionString;
        }


        public NPocoUnitOfWork(IDatabase db)
        {
            _db = db;

            if (db.Connection != null)
            {
                _ConnectionString = db.Connection.ConnectionString;
            }
        }


        public void StartNew()
        {
            _db.BeginTransaction();
        }

        public void Commit()
        {
            _db.CompleteTransaction();
        }

        public void Rollback()
        {
            _db.AbortTransaction();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}