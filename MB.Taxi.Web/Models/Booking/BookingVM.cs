using MB.Taxi.Web.Models.Passanger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MB.Taxi.Web.Models.Booking
{
    public class BookingVM
    {
        public BookingVM()
        {
            Passangers = new List<PassangerVM>();
        }
        public int Id { get; set; }
        public DateTime PickUpTime { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string Price { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public List<PassangerVM> Passangers { get; set; }
    }
}
