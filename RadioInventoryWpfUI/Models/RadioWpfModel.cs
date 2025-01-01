using RadioInventoryWpfUI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioInventoryWpfUI.Models
{
    public class RadioWpfModel : BindableBase
    {
        public int Id { get; set; }

		private string _departmentName = string.Empty;
		public string DepartmentName
		{
			get => _departmentName;
			set 
			{ 
				SetProperty(ref _departmentName, value);
			}
		}

        private int _designatedLabelNumber;
        public int DesignatedLabelNumber
        {
            get => _designatedLabelNumber;
            set
            {
                SetProperty(ref _designatedLabelNumber, value);
            }
        }

        private string _frontLabel = string.Empty;
        public string FrontLabel
        {
            get => _frontLabel;
            set
            {
                SetProperty(ref _frontLabel, value);
            }
        }

        private string _insideLabel = string.Empty;
        public string InsideLabel
        {
            get => _insideLabel;
            set
            {
                SetProperty(ref _insideLabel, value);
            }
        }

        private string _serialNumber = string.Empty;
        public string SerialNumber
        {
            get => _serialNumber;
            set
            {
                SetProperty(ref _serialNumber, value);
            }
        }
    }
}
