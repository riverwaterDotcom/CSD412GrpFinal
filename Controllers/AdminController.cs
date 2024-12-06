using Microsoft.AspNetCore.Mvc;
using week4assignment.Data;
using System.Linq;
using week4assignment.Models;

namespace week4assignment.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var catCount = _context.Cats.Count();
            var dogCount = _context.Dogs.Count();
            var householdCount = _context.Households.Count();

            var stats = new AdminDashboardViewModel
            {
                CatCount = catCount,
                DogCount = dogCount,
                HouseholdCount = householdCount
            };

            return View(stats);
        }
    }
}
