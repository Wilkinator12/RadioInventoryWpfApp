using RadioInventoryWpfUI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioInventoryWpfUI.Models
{
    public class DepartmentWpfModel : BindableBase
    {
        public int Id { get; set; }

        private string _name = string.Empty;
		public string Name
		{
			get => _name;
			set 
			{ 
				SetProperty(ref _name, value);
			}
		}

        private string _frontLabelPrefix = string.Empty;
        public string FrontLabelPrefix
        {
            get => _frontLabelPrefix;
            set
            {
                SetProperty(ref _frontLabelPrefix, value);
            }
        }

        private string _insideLabelPrefix = string.Empty;
        public string InsideLabelPrefix
        {
            get => _insideLabelPrefix;
            set
            {
                SetProperty(ref _insideLabelPrefix, value);
            }
        }
    }
}
