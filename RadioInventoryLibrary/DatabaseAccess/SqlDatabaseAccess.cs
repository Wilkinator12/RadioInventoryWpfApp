using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Z.Dapper.Plus;

namespace RadioInventoryLibrary.DatabaseAccess
{
    public class SqlDatabaseAccess : ISqlDatabaseAccess
    {
        private readonly IConfiguration _config;

        public SqlDatabaseAccess(IConfiguration config)
        {
            _config = config;
        }


        public List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionStringName, bool isStoredProcedure = false)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            CommandType commandType = CommandType.Text;

            if (isStoredProcedure == true)
            {
                commandType = CommandType.StoredProcedure;
            }

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> output = connection.Query<T>(sqlStatement, parameters, commandType: commandType).ToList();
                return output;
            }
        }

        public void SaveData<T>(string sqlStatement, T parameters, string connectionStringName, bool isStoredProcedure = false)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            CommandType commandType = CommandType.Text;

            if (isStoredProcedure == true)
            {
                commandType = CommandType.StoredProcedure;
            }

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(sqlStatement, parameters, commandType: commandType);
            }
        }

        public void SaveBulkData<T>(List<T> entities, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.BulkInsert(entities);
            }
        }
    }
}
