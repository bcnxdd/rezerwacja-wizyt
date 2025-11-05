using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zadanie1.Data;
using zadanie1.Models;

namespace zadanie1.Controllers
{
    public class AppointmentsController(AppDbContext db) : Controller
    {
        private readonly AppDbContext _db = db;

        public async Task<IActionResult> Available(int doctorId)
        {
            var doctor = await _db.Doctors.Include(d => d.Specialization).FirstOrDefaultAsync(d => d.Id == doctorId);
            if (doctor == null) return NotFound();

            var slots = await _db.AppointmentSlots
                .Where(s => s.DoctorId == doctorId && !s.IsBooked && s.Start > DateTime.Now)
                .OrderBy(s => s.Start)
                .ToListAsync();

            ViewBag.Doctor = doctor;
            return View(slots);
        }

        [HttpGet]
        public async Task<IActionResult> Book(int slotId)
        {
            var slot = await _db.AppointmentSlots
                .Include(s => s.Doctor).ThenInclude(d => d.Specialization)
                .FirstOrDefaultAsync(s => s.Id == slotId);

            if (slot == null || slot.IsBooked) return NotFound();

            var model = new Appointment
            {
                AppointmentSlotId = slotId
            };
            ViewBag.Slot = slot;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Book(Appointment model)
        {
            var slot = await _db.AppointmentSlots
                .Include(s => s.Doctor).ThenInclude(d => d.Specialization)
                .FirstOrDefaultAsync(s => s.Id == model.AppointmentSlotId);

            if (slot == null) return NotFound();

            /*if (!ModelState.IsValid)
            {
                ViewBag.Slot = slot;
                return View(model);
            }*/

            _db.Appointments.Add(model);

            _db.AppointmentSlots.Remove(slot);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Available), new { doctorId = slot.DoctorId });
        }
    }
    
}
