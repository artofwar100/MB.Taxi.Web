using AutoMapper;
using Entites;
using MB.Taxi.Web.Models.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MB.Taxi.Web.AutoMapper
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<Driver, DriverVM>().ReverseMap();
        }
    }
}
