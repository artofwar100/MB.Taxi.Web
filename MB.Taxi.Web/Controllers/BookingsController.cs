using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entites;
using MB.Taxi.Web.Data;
using AutoMapper;
using MB.Taxi.Web.Models.Booking;
using MB.Taxi.Web.Helper;

namespace MB.Taxi.Web.Controllers
{
    public class BookingsController : Controller
    {
        #region Data and Const
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILookUpService _lookUpService;

        public BookingsController(ApplicationDbContext context, IMapper mapper, ILookUpService lookUpService)
        {
            _context = context;
            _mapper = mapper;
            _lookUpService = lookUpService;
        }
        #endregion

        #region Public Actions
        public async Task<IActionResult> BookingPay(int BookingId)
        {
            var booking = await _context.Bookings.FindAsync(BookingId);

            booking.IsPaid = true;
            booking.PaymentDate = DateTime.Now;

            _context.Update(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Index()
        {
            var booking = await _context
                                       .Bookings
                                       .ToListAsync();

            var bookingVM = _mapper.Map<List<Booking>, List<BookingVM>>(booking);

            return View(bookingVM);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context
                                        .Bookings
                                        .Include(x => x.Passangers)
                                        .Include(x => x.Car)
                                        .Include(x => x.Driver)
                                        .Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();
            if (booking == null)
            {
                return NotFound();
            }

            var bookingVM = _mapper.Map<Booking, BookingVM>(booking);

            return View(bookingVM);
        }
        public async Task<IActionResult> Create()
        {
            var bookingCreateEditVM = new BookingCreateEditVM()
            {
                GetPassangersList = await _lookUpService.GetPassangersList(),
                GetDriverList = await _lookUpService.GetDriversList(),
                GetCarList = await _lookUpService.GetCarsList(),
                PaymentDate = DateTime.Now           
            };
            return View(bookingCreateEditVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingCreateEditVM bookingVM)
        {
            if (ModelState.IsValid)
            {
                var booking = _mapper.Map<BookingCreateEditVM, Booking>(bookingVM);

                var passanger = await _context
                                              .Passangers
                                              .Where(x => bookingVM.PassangerIds.Contains(x.Id))
                                              .ToListAsync();
                booking.Passangers.AddRange(passanger);

                var driver = await _context.Drivers.FindAsync(bookingVM.DriverIds);
                booking.Driver = driver;

                var car = await _context.Cars.FindAsync(bookingVM.CarIds);
                booking.Car = car;

                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            bookingVM.GetPassangersList = await _lookUpService.GetPassangersList();

            return View(bookingVM);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context
                                        .Bookings
                                        .Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();
            if (booking == null)
            {
                return NotFound();
            }

            var bookingVM = _mapper.Map<Booking, BookingCreateEditVM>(booking);

            bookingVM.GetPassangersList = await _lookUpService.GetPassangersList();
            bookingVM.GetDriverList = await _lookUpService.GetDriversList();
            bookingVM.GetCarList = await _lookUpService.GetCarsList();
            bookingVM.PaymentDate = DateTime.Now;

            return View(bookingVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookingCreateEditVM bookingVM)
        {
            if (id != bookingVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var booking = _mapper.Map<BookingCreateEditVM, Booking>(bookingVM);


                    var driver = await _context.Drivers.FindAsync(bookingVM.DriverIds);
                    booking.Driver = driver;

                    var car = await _context.Cars.FindAsync(bookingVM.CarIds);
                    booking.Car = car;

                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(bookingVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            bookingVM.GetPassangersList = await _lookUpService.GetPassangersList();

            return View(bookingVM);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        } 
        #endregion

        #region Private Actions
        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        } 
        #endregion
    }
}
