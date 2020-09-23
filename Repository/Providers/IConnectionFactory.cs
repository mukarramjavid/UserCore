using Inferastructure.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Repository.Providers
{
    public interface IConnectionFactory
    {
        IDbConnection CreateDbConnection(DatabaseConnectionName connectionName);
    }
}
