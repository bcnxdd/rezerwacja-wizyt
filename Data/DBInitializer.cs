using zadanie1.Models;

namespace zadanie1.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext db)
        {
            if (db.Specializations.Any()) return;

            var spec1 = new Specialization { Name = "Kardiolog" };
            var spec2 = new Specialization { Name = "Dermatolog" };
            var spec3 = new Specialization { Name = "Pediatra" };

            db.Specializations.AddRange(spec1, spec2, spec3);

            var d1 = new Doctor { FirstName = "Anna", LastName = "Kowalska", Specialization = spec1 };
            var d2 = new Doctor { FirstName = "Jan", LastName = "Nowak", Specialization = spec2 };
            var d3 = new Doctor { FirstName = "Ewa", LastName = "Wiśniewska", Specialization = spec3 };

            db.Doctors.AddRange(d1, d2, d3);

            var baseDate = DateTime.Today.AddDays(1);
            db.AppointmentSlots.AddRange(
                new AppointmentSlot { Doctor = d1, Start = baseDate.AddHours(9), End = baseDate.AddHours(9.5) },
                new AppointmentSlot { Doctor = d1, Start = baseDate.AddHours(10), End = baseDate.AddHours(10.5) },
                new AppointmentSlot { Doctor = d2, Start = baseDate.AddHours(11), End = baseDate.AddHours(11.5) },
                new AppointmentSlot { Doctor = d3, Start = baseDate.AddHours(12), End = baseDate.AddHours(12.5) }
            );

            db.SaveChanges();
        }
    }
}
