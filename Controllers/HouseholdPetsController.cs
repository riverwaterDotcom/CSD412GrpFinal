using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using week4assignment.Data;
using week4assignment.Models;

namespace week4assignment.Controllers
{
    public class HouseholdPetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HouseholdPetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HouseholdPets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Households.ToListAsync());
        }

        // GET: HouseholdPets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var householdPets = await _context.Households
                .FirstOrDefaultAsync(m => m.Id == id);
            if (householdPets == null)
            {
                return NotFound();
            }

            return View(householdPets);
        }

        // GET: HouseholdPets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HouseholdPets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DogCount,CatCount")] HouseholdPets householdPets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(householdPets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(householdPets);
        }

        // GET: HouseholdPets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var householdPets = await _context.Households.FindAsync(id);
            if (householdPets == null)
            {
                return NotFound();
            }
            return View(householdPets);
        }

        // POST: HouseholdPets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DogCount,CatCount")] HouseholdPets householdPets)
        {
            if (id != householdPets.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(householdPets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseholdPetsExists(householdPets.Id))
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
            return View(householdPets);
        }

        // GET: HouseholdPets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var householdPets = await _context.Households
                .FirstOrDefaultAsync(m => m.Id == id);
            if (householdPets == null)
            {
                return NotFound();
            }

            return View(householdPets);
        }

        // POST: HouseholdPets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var householdPets = await _context.Households.FindAsync(id);
            _context.Households.Remove(householdPets);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseholdPetsExists(int id)
        {
            return _context.Households.Any(e => e.Id == id);
        }
    }
}
