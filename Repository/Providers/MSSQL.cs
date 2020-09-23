using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Providers
{
    public class MSSQL : IDbConnection
    {
        #region Propertise
        public string ConnectionString { get; set; }
        private SqlConnection _connection;
        #endregion

        #region Constructor
        public MSSQL(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("ConnectionString");
            _connection = new SqlConnection(ConnectionString);
        }
        #endregion

        #region Public Methods
        public void Open()
        {
            if (_connection.State == ConnectionState.Closed || _connection.State == ConnectionState.Broken)
                _connection.Open();
        }

        public void Close()
        {
            if (_connection.State == ConnectionState.Open || _connection != null)
                _connection.Close();
        }

        public void ChangeDatabase(string databaseName)
        {
            _connection.ChangeDatabase(databaseName);
        }

        public int ConnectionTimeout
        {
            get { return _connection.ConnectionTimeout; }
        }

        public string Database
        {
            get { return _connection.Database; }
        }

        public ConnectionState State
        {
            get { return _connection.State; }
        }

        public IDbCommand CreateCommand()
        {
            return _connection.CreateCommand();
        }
        #endregion

        #region Transaction Block
        public IDbTransaction BeginTransaction()
        {
            return _connection.BeginTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return _connection.BeginTransaction(il);
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                Close();
        }
        #endregion
    }
}
