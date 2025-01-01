using AutoMapper;
using RadioInventoryLibrary.Models;
using RadioInventoryWpfUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioInventoryWpfUI.Profiles
{
    public class DepartmentRadioTemplateProfile : Profile
    {
        public DepartmentRadioTemplateProfile()
        {
            CreateMap<DepartmentRadioTemplateModel, DepartmentRadioTemplateWpfModel>();
            CreateMap<DepartmentRadioTemplateWpfModel, DepartmentRadioTemplateModel>();
        }
    }
}
