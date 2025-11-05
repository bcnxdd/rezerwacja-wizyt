using Microsoft.EntityFrameworkCore;
using zadanie1.Models;

namespace zadanie1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Specialization> Specializations => Set<Specialization>();
        public DbSet<AppointmentSlot> AppointmentSlots => Set<AppointmentSlot>();
        public DbSet<Appointment> Appointments => Set<Appointment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialization>()
                .HasMany(s => s.Doctors)
                .WithOne(d => d.Specialization)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Slots)
                .WithOne(s => s.Doctor)
                .HasForeignKey(s => s.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppointmentSlot>()
                .HasOne(s => s.Appointment)
                .WithOne(a => a.AppointmentSlot)
                .HasForeignKey<Appointment>(a => a.AppointmentSlotId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppointmentSlot>()
                .HasIndex(s => new { s.DoctorId, s.Start, s.End })
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}