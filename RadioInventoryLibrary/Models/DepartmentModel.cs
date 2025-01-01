using System;
using System.Collections.Generic;
using System.Text;

namespace RadioInventoryLibrary.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FrontLabelPrefix { get; set; }
        public string InsideLabelPrefix { get; set; }
    }
}
