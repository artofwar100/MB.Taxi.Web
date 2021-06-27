using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MB.Taxi.Web.Data;
using MB.Taxi.Web.Models;

namespace MB.Taxi.Web.Helper
{
    public class LookUpService : ILookUpService
    {
        private readonly ApplicationDbContext _context;

        public LookUpService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<SelectList> GetCarsList()
        {
            var car = await _context
                                .Cars
                                .Select(car => new LookUpVM()
                                {
                                    Id = car.Id,
                                    Name = car.Name
                                })
                                .ToListAsync();

            var carList = new SelectList(car, "Id", "Name");

            return carList;
        }
        public async Task<SelectList> GetPassangersList()
        {
            var passanger = await _context
                                .Passangers
                                .Select(passanger => new LookUpVM()
                                {
                                    Id = passanger.Id,
                                    Name = passanger.Name
                                })
                                .ToListAsync();

            var passangerList = new SelectList(passanger, "Id", "Name");

            return passangerList;
        }
        public async Task<SelectList> GetBookingList()
        {
            var booking = await _context
                                .Bookings
                                .Select(booking => new LookUpVM()
                                {
                                    Id = booking.Id,
                                    Name = booking.FromAddress
                                })
                                .ToListAsync();

            var bookingList = new SelectList(booking, "Id", "Name");

            return bookingList;
        }
        public async Task<SelectList> GetDriversList()
        {
            var driver = await _context
                                .Drivers
                                .Select(driver => new LookUpVM()
                                {
                                    Id = driver.Id,
                                    Name = driver.Name
                                })
                                .ToListAsync();

            var driverList = new SelectList(driver, "Id", "Name");

            return driverList;
        }
    }
}
