using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilities.Enum;

namespace Entites
{
    public class Car
    {
        public Car()
        {
            Bookings = new List<Booking>();
        }
        public int Id { get; set; }
        public int PlateNumber { get; set; }
        public string Name { get; set; }
        public DateTime MakeYear { get; set; }
        public FuelType FuelType { get; set; }
        public CarType CarType { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
