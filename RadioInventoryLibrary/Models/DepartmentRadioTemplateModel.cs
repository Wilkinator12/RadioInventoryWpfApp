using System;
using System.Collections.Generic;
using System.Text;

namespace RadioInventoryLibrary.Models
{
    public class DepartmentRadioTemplateModel
    {
        public DepartmentModel Department { get; set; }
        public int QuantityToCreate { get; set; }
    }
}
