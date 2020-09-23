using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Repository.Providers
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Public Propertise
        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }
        #endregion

        #region Public Constructor
        public UnitOfWork(IDbConnection connection)
        {
            Connection = connection;
        }
        #endregion

        #region Public Methods
        public void Open()
        {
            Connection.Open();
        }

        public void Close()
        {
            if (Connection.State == ConnectionState.Open || Connection.State == ConnectionState.Broken)
                Connection.Close();
        }

        #region Transaction Block
        public IDbTransaction BeginTransaction()
        {
            return Transaction = Connection.BeginTransaction();
        }

        public void RollBackTransaction()
        {
            if (Transaction != null)
                Transaction.Rollback();
        }

        public void CommitTransaction()
        {
            Transaction.Commit();
        }
        #endregion

        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
                Close();
        }
        #endregion
    }
}
