using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace MB.Taxi.Web.Helper
{
    public interface ILookUpService
    {
        public Task<SelectList> GetCarsList();
        public Task<SelectList> GetPassangersList();
        public Task<SelectList> GetBookingList();
        public Task<SelectList> GetDriversList();
    }
}
