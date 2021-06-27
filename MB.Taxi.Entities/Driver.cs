using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilities.Enum;

namespace Entites
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhonoNumber { get; set; }
        public int Rating { get; set; }
        public Gender Gender { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<Car> Cars { get; set; }
    }
}
