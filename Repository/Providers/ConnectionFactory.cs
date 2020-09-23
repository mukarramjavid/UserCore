using Inferastructure.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Providers
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IDictionary<DatabaseConnectionName, string> _connectionDict;

        public ConnectionFactory(IDictionary<DatabaseConnectionName, string> connectionDict)
        {
            _connectionDict = connectionDict;
        }
        public IDbConnection CreateDbConnection(DatabaseConnectionName connectionName)
        {
            string connectionString = null;
            if (_connectionDict.TryGetValue(connectionName, out connectionString))
            {
                return new SqlConnection(connectionString);
            }
            throw new ArgumentNullException();
        }
    }
}
