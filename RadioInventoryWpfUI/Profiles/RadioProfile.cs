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
    public class RadioProfile : Profile
    {
        public RadioProfile()
        {
            CreateMap<FullRadioModel, RadioWpfModel>();
        }
    }
}
