using System.ComponentModel.DataAnnotations;

namespace zadanie1.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int AppointmentSlotId { get; set; }
        public AppointmentSlot AppointmentSlot { get; set; } = default!;

        [Required, MaxLength(100)]
        public string FirstName { get; set; } = default!;

        [Required, MaxLength(100)]
        public string LastName { get; set; } = default!;

        [Required, EmailAddress, MaxLength(255)]
        public string Email { get; set; } = default!;

        [Required, Phone, MaxLength(50)]
        public string Phone { get; set; } = default!;

        [Required, MaxLength(300)]
        public string Address { get; set; } = default!;
    }
}
