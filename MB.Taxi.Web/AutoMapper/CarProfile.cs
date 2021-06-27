using AutoMapper;
using Entites;
using MB.Taxi.Web.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MB.Taxi.Web.AutoMapper
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarVM>().ReverseMap();
            CreateMap<Car, CarCreateEditVM>().ReverseMap();
        }
    }
}
