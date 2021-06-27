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

            var carList = new SelectList(car,"Id", "Name");

            return carList;
        }
    }
}
