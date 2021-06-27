using AutoMapper;
using Entites;
using MB.Taxi.Web.Models.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MB.Taxi.Web.AutoMapper
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingVM>().ReverseMap();
            CreateMap<Booking, BookingCreateEditVM>().ReverseMap();
        }
    }
}
