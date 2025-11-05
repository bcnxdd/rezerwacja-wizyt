using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zadanie1.Models
{
    public class AppointmentSlot
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = default!;

        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime End { get; set; }

        public bool IsBooked { get; set; } = false;
        public Appointment? Appointment { get; set; }
    }
}
