using MB.Taxi.Web.Models.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using utilities.Enum;

namespace MB.Taxi.Web.Models.Passanger
{
    public class PassangerVM
    {
        public PassangerVM()
        {
            Booking = new List<BookingVM>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhonoNumber { get; set; }
        public Gender Gender { get; set; }
        public List<BookingVM> Booking { get; set; }
    }
}
