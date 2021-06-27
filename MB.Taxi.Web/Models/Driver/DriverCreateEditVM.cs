using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using utilities.Enum;

namespace MB.Taxi.Web.Models.Driver
{
    public class DriverCreateEditVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhonoNumber { get; set; }
        public int Rating { get; set; }
        public Gender Gender { get; set; }
        public int CarVMid { get; set; }
        public SelectList GetCarList { get; set; }
    }
}
