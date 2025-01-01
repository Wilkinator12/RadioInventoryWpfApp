using RadioInventoryLibrary.DataAccess;
using RadioInventoryLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadioInventoryLibrary.Factories
{
    public class RadioFactory : IRadioFactory
    {
        private readonly IDataAccess _data;

        public RadioFactory(IDataAccess data)
        {
            _data = data;
        }

        public List<BasicRadioModel> CreateRadiosFromDepartmentTemplates(List<DepartmentRadioTemplateModel> departmentTemplates)
        {
            List<BasicRadioModel> output = new List<BasicRadioModel>();

            foreach (var departmentTemplate in departmentTemplates)
            {
                int startingLabelNumber = _data.GetHighestDesignatedLabelNumber(departmentTemplate.Department.Id);

                output.AddRange(CreateRadiosFromDepartmentTemplate(departmentTemplate, startingLabelNumber + 1));
            }

            return output;
        }

        public List<BasicRadioModel> CreateRadiosFromDepartmentTemplate(DepartmentRadioTemplateModel departmentTemplate, int startingLabelNumber)
        {
            List<BasicRadioModel> output = new List<BasicRadioModel>();

            for (int i = 0; i < departmentTemplate.QuantityToCreate; i++)
            {
                output.Add(CreateRadioFromDepartment(departmentTemplate.Department, startingLabelNumber + i));
            }

            return output;
        }

        public BasicRadioModel CreateRadioFromDepartment(DepartmentModel department, int labelNumber)
        {
            return new BasicRadioModel()
            {
                DesignatedDepartmentId = department.Id,
                DesignatedLabelNumber = labelNumber,
                FrontLabel = $"{department.FrontLabelPrefix}{labelNumber}",
                InsideLabel = $"{department.InsideLabelPrefix}{labelNumber}"
            };
        }
    }
}
