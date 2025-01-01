using RadioInventoryLibrary.Models;
using System.Collections.Generic;

namespace RadioInventoryLibrary.Factories
{
    public interface IDepartmentRadioTemplateFactory
    {
        List<DepartmentRadioTemplateModel> GetTemplatesForAllDepartments(int quantityToCreate = 10);
    }
}