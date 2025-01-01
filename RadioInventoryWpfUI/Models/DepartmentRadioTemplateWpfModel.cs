using RadioInventoryWpfUI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioInventoryWpfUI.Models
{
    public class DepartmentRadioTemplateWpfModel : BindableBase
    {
		private DepartmentWpfModel _department = null!;
		public DepartmentWpfModel Department
		{
			get => _department;
			set 
			{ 
				SetProperty(ref _department, value); 
			}
		}

		private int _quantityToCreate;
		public int QuantityToCreate
		{
			get => _quantityToCreate;
            set 
			{ 
				SetProperty(ref _quantityToCreate, value); 
			}
		}

	}
}
