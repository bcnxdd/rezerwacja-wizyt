namespace zadanie1.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; } = default!;
        public ICollection<AppointmentSlot> Slots { get; set; } = new List<AppointmentSlot>();
    }
}
