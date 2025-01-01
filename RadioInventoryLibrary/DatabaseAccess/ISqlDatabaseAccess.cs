using System.Collections.Generic;

namespace RadioInventoryLibrary.DatabaseAccess
{
    public interface ISqlDatabaseAccess
    {
        List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionStringName, bool isStoredProcedure);
        void SaveBulkData<T>(List<T> entities, string connectionStringName);
        void SaveData<T>(string sqlStatement, T parameters, string connectionStringName, bool isStoredProcedure);
    }
}