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
using MB.Taxi.Web.Models.Car;

namespace MB.Taxi.Web.Controllers
{
    public class CarsController : Controller
    {
        #region Data and Const
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CarsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        } 
        #endregion

        #region Private Actions
        public async Task<IActionResult> Index()
        {
            var car = await _context
                                    .Cars
                                    .ToListAsync();

            var carVM = _mapper.Map<List<Car>, List<CarVM>>(car);

            return View(carVM);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context
                                    .Cars
                                    .Where(x => x.Id == id)
                                    .FirstOrDefaultAsync();
                            
            if (car == null)
            {
                return NotFound();
            }

            var carVM = _mapper.Map<Car,CarVM>(car);

            return View(carVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarVM carVM)
        {
            if (ModelState.IsValid)
            {
                var car = _mapper.Map<CarVM, Car>(carVM);

                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carVM);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context
                                     .Cars
                                     .Where(x => x.Id == id)
                                     .FirstOrDefaultAsync();
            if (car == null)
            {
                return NotFound();
            }

            var carVM = _mapper.Map<Car,CarVM>(car);

            return View(carVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarVM carVM)
        {
            if (id != carVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var car = _mapper.Map<CarVM,Car>(carVM);

                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(carVM.Id))
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

            return View(carVM);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        } 
        #endregion

        #region Private Actions
        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        } 
        #endregion
    }
}
