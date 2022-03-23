using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreWebAPI.Data;
using CoreWebAPI.Models;

namespace CoreWebAPI.Configurations
{
    public class MapperInitilizer :Profile 
    {
        public MapperInitilizer()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Hospital, HospitalDTO>().ReverseMap();
            CreateMap<Hospital, CreateHospitalDTO>().ReverseMap();
        }
    }
}
