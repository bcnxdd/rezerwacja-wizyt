namespace zadanie1.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
