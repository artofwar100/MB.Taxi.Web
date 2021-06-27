using AutoMapper;
using Entites;
using MB.Taxi.Web.Models.Passanger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MB.Taxi.Web.AutoMapper
{
    public class PassangerProfile : Profile
    {
        public PassangerProfile()
        {
            CreateMap<Passanger, PassangerVM>().ReverseMap();
        }
    }
}
