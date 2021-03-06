using MB.Taxi.Web.Models.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using utilities.Enum;

namespace MB.Taxi.Web.Models.Car
{
    public class CarVM
    {
        public CarVM()
        {
            Bookings = new List<BookingVM>();
        }
        public int Id { get; set; }
        public int PlateNumber { get; set; }
        public string Name { get; set; }
        public DateTime MakeYear { get; set; }
        public FuelType FuelType { get; set; }
        public CarType CarType { get; set; }
        public List<BookingVM> Bookings { get; set; }
    }
}
