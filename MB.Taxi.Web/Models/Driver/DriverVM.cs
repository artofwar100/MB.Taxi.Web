using MB.Taxi.Web.Models.Booking;
using MB.Taxi.Web.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using utilities.Enum;

namespace MB.Taxi.Web.Models.Driver
{
    public class DriverVM
    {
        public DriverVM()
        {
            Bookings = new List<BookingVM>();
            Cars = new List<CarVM>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhonoNumber { get; set; }
        public int Rating { get; set; }
        public Gender Gender { get; set; }
        public List<BookingVM> Bookings { get; set; }
        public List<CarVM> Cars { get; set; }
    }
}
