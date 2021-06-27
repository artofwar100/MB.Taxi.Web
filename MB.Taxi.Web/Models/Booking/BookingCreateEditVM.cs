using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MB.Taxi.Web.Models.Booking
{
    public class BookingCreateEditVM
    {
        public int Id { get; set; }
        public DateTime PickUpTime { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string Price { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        [DisplayName("Passangers")]
        public List<int> PassangerIds { get; set; }
        public SelectList GetPassangersList { get; set; }
    }
}
