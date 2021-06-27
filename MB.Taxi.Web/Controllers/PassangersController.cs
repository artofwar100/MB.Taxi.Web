﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entites;
using MB.Taxi.Web.Data;

namespace MB.Taxi.Web.Controllers
{
    public class PassangersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PassangersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Passangers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Passangers.ToListAsync());
        }

        // GET: Passangers/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Passangers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Passangers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,PhonoNumber,Gender")] Passanger passanger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passanger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passanger);
        }

        // GET: Passangers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passanger = await _context.Passangers.FindAsync(id);
            if (passanger == null)
            {
                return NotFound();
            }
            return View(passanger);
        }

        // POST: Passangers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,PhonoNumber,Gender")] Passanger passanger)
        {
            if (id != passanger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passanger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassangerExists(passanger.Id))
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
            return View(passanger);
        }

        // GET: Passangers/Delete/5
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

        // POST: Passangers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passanger = await _context.Passangers.FindAsync(id);
            _context.Passangers.Remove(passanger);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassangerExists(int id)
        {
            return _context.Passangers.Any(e => e.Id == id);
        }
    }
}
