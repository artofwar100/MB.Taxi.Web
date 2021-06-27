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
using MB.Taxi.Web.Models.Passanger;

namespace MB.Taxi.Web.Controllers
{
    public class PassangersController : Controller
    {
        #region Data And Const
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PassangersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        } 
        #endregion

        #region Public Actions
        public async Task<IActionResult> Index()
        {
            var passanger = await _context
                                         .Passangers
                                         .ToListAsync();

            var passnagerVM = _mapper.Map<List<Passanger>, List<PassangerVM>>(passanger);

            return View(passnagerVM);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passanger = await _context
                                          .Passangers
                                          .Where(x => x.Id == id)
                                          .FirstOrDefaultAsync();
            if (passanger == null)
            {
                return NotFound();
            }

            var passangerVM = _mapper.Map<Passanger, PassangerVM>(passanger);

            return View(passangerVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PassangerVM passangerVM)
        {
            if (ModelState.IsValid)
            {
                var passanger = _mapper.Map<PassangerVM, Passanger>(passangerVM);

                _context.Add(passanger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passangerVM);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passanger = await _context
                                          .Passangers
                                          .Where(x => x.Id == id)
                                          .FirstOrDefaultAsync();
            if (passanger == null)
            {
                return NotFound();
            }

            var passangerVM = _mapper.Map<Passanger, PassangerVM>(passanger);

            return View(passangerVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PassangerVM passangerVM)
        {
            if (id != passangerVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var passanger = _mapper.Map<PassangerVM, Passanger>(passangerVM);

                    _context.Update(passanger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassangerExists(passangerVM.Id))
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
            return View(passangerVM);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passanger = await _context.Passangers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passanger == null)
            {
                return NotFound();
            }

            return View(passanger);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passanger = await _context.Passangers.FindAsync(id);
            _context.Passangers.Remove(passanger);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        } 
        #endregion

        #region Private Actions
        private bool PassangerExists(int id)
        {
            return _context.Passangers.Any(e => e.Id == id);
        } 
        #endregion
    }
}
