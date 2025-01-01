using RadioInventoryLibrary.DataAccess;
using RadioInventoryLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadioInventoryLibrary.Factories
{
    public class DepartmentRadioTemplateFactory : IDepartmentRadioTemplateFactory
    {
        private readonly IDataAccess _data;

        public DepartmentRadioTemplateFactory(IDataAccess data)
        {
            _data = data;
        }

        public List<DepartmentRadioTemplateModel> GetTemplatesForAllDepartments(int quantityToCreate = 10)
        {
            List<DepartmentRadioTemplateModel> output = new List<DepartmentRadioTemplateModel>();


            List<DepartmentModel> departments = _data.GetAllDepartments();

            foreach (DepartmentModel department in departments)
            {
                output.Add(new DepartmentRadioTemplateModel()
                {
                    Department = department,
                    QuantityToCreate = quantityToCreate
                });
            }

            return output;
        }
    }
}
