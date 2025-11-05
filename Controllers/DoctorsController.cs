using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zadanie1.Data;

namespace zadanie1.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly AppDbContext _db;
        public DoctorsController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Index(int? specializationId)
        {
            var specializations = await _db.Specializations.OrderBy(s => s.Name).ToListAsync();
            ViewBag.Specializations = specializations;

            var query = _db.Doctors.Include(d => d.Specialization).AsQueryable();
            if (specializationId.HasValue)
                query = query.Where(d => d.SpecializationId == specializationId.Value);

            var doctors = await query.OrderBy(d => d.LastName).ThenBy(d => d.FirstName).ToListAsync();
            return View(doctors);
        }
    }
}
