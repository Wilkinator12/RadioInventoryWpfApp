using RadioInventoryLibrary.DatabaseAccess;
using RadioInventoryLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadioInventoryLibrary.DataAccess
{
    public class SqlDataAccess : IDataAccess
    {
        private readonly ISqlDatabaseAccess _db;
        private const string connectionStringName = "SqlDb";

        public SqlDataAccess(ISqlDatabaseAccess db)
        {
            _db = db;
        }


        public List<DepartmentModel> GetAllDepartments()
        {
            return _db.LoadData<DepartmentModel, dynamic>("select * from dbo.Departments", new { }, connectionStringName, false);
        }

        public void InsertBulkRadios(List<BasicRadioModel> radios)
        {
            _db.SaveBulkData(radios, connectionStringName);
        }

        public List<BasicRadioModel> GetAllBasicRadios()
        {
            return _db.LoadData<BasicRadioModel, dynamic>("dbo.spRadios_GetAll", new { }, connectionStringName, true);
        }

        public List<FullRadioModel> GetAllFullRadios()
        {
            return _db.LoadData<FullRadioModel, dynamic>("dbo.spRadios_GetAllWithDepartmentNames", new { }, connectionStringName, true);
        }

        public List<BasicRadioModel> GetRadiosByDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }

        public void UpdateRadioSerialNumber(FullRadioModel radio, string serialNumber)
        {
            radio.SerialNumber = serialNumber;

            _db.SaveData("update dbo.Radios set SerialNumber = @SerialNumber where Id = @Id",
                         new { radio.Id, radio.SerialNumber },
                         connectionStringName,
                         false);
        }

        public int GetHighestDesignatedLabelNumber(int departmentId)
        {
            return _db.LoadData<int, dynamic>("spRadios_GetHighestDesignatedLabelNumber", new { departmentId }, connectionStringName, true).FirstOrDefault();
        }
    }
}
