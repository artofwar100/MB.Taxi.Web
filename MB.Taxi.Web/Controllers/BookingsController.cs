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

namespace MB.Taxi.Web.Controllers
{
    public class BookingsController : Controller
    {
        #region Data and Const
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookingsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        } 
        #endregion

        #region Public Actions
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
                                        .Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();
            if (booking == null)
            {
                return NotFound();
            }

            var bookingVM = _mapper.Map<Booking, BookingVM>(booking);

            return View(bookingVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingVM bookingVM)
        {
            if (ModelState.IsValid)
            {
                var booking = _mapper.Map<BookingVM, Booking>(bookingVM);

                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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

            var bookingVM = _mapper.Map<Booking, BookingVM>(booking);

            return View(bookingVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookingVM bookingVM)
        {
            if (id != bookingVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var booking = _mapper.Map<BookingVM,Booking>(bookingVM);

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
