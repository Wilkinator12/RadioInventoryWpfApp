using RadioInventoryLibrary.Models;
using System.Collections.Generic;

namespace RadioInventoryLibrary.DataAccess
{
    public interface IDataAccess
    {
        List<DepartmentModel> GetAllDepartments();
        List<BasicRadioModel> GetAllBasicRadios();
        int GetHighestDesignatedLabelNumber(int departmentId);
        List<BasicRadioModel> GetRadiosByDepartment(int departmentId);
        void InsertBulkRadios(List<BasicRadioModel> radios);
        void UpdateRadioSerialNumber(FullRadioModel radio, string serialNumber);
        List<FullRadioModel> GetAllFullRadios();
    }
}