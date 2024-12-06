using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using week4assignment.Data;
using week4assignment.Models;

namespace week4assignment.Controllers
{
    public class CatsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string searchString;

        public CatsController(ApplicationDbContext context)
        {
            _context = context;
            // _context = new ApplicationDbContext(ApplicationDbContext);
        }

        // GET: Cats
        public async Task<IActionResult> Index()
        {
            //_context = new DbContext();

            /* Cat cat1 = new Cat(171);
            cat1.CatName = "Shadow";
            cat1.CatPattern = "Pure black";
            cat1.CatSize = "Thin";
            cat1.CatWeight = 8.2f;

            _context.Cats.Add(cat1); */
            List<Cat> catList = await _context.Cats.ToListAsync();
            List<CatViewModel> catViewModels = new List<CatViewModel>();
            
            foreach (Cat cat in catList)
            {
                CatViewModel catView = new CatViewModel()
                {
                    Id = cat.Id,
                    CatName = cat.CatName,
                    CatPattern = cat.CatPattern
                };
                catViewModels.Add(catView);
            }
            await _context.SaveChangesAsync();
            //DbContext.set<Cat>
            //DbContext.SaveChanges();

            // have to change this to send the catViewModels and then all references to said view

            HttpClient httpClient = new HttpClient();
            //  sorrstring clientReq = await httpClient.GetStringAsync("https://localhost:44379/api/CatsInfo");

            // Search Feature for cats
            var cats = from c in _context.Cats
                       select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                cats = cats.Where(s => s.CatName.Contains(searchString));
            }

            return View(await _context.Cats.ToListAsync());
        }

        // GET: Cats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Cats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // GET: Cats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CatName,CatPattern,CatWeight,CatSize")] Cat cat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cat);
        }

        // GET: Cats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Cats.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        // POST: Cats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CatName,CatPattern,CatWeight,CatSize")] Cat cat)
        {
            if (id != cat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatExists(cat.Id))
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
            return View(cat);
        }

        // GET: Cats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Cats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // POST: Cats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cat = await _context.Cats.FindAsync(id);
            _context.Cats.Remove(cat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatExists(int id)
        {
            return _context.Cats.Any(e => e.Id == id);
        }
    }
}
