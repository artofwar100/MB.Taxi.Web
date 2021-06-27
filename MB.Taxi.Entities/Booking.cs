using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime PickUpTime { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string Price { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public List<Passanger> Passangers { get; set; }
    }
}
