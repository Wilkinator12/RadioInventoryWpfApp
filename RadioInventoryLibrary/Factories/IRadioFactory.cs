using RadioInventoryLibrary.Models;
using System.Collections.Generic;

namespace RadioInventoryLibrary.Factories
{
    public interface IRadioFactory
    {
        BasicRadioModel CreateRadioFromDepartment(DepartmentModel department, int labelNumber);
        List<BasicRadioModel> CreateRadiosFromDepartmentTemplate(DepartmentRadioTemplateModel departmentTemplate, int startingLabelNumber);
        List<BasicRadioModel> CreateRadiosFromDepartmentTemplates(List<DepartmentRadioTemplateModel> departmentTemplates);
    }
}