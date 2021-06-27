using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilities.Enum;

namespace Entites
{
    public class Passanger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhonoNumber { get; set; }
        public Gender Gender { get; set; }
        public List<Booking> Booking { get; set; }
    }
}
