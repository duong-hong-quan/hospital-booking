namespace BookingHospital.Repositories.Models;

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Specialization { get; set; } = null!;
    public string? Phone { get; set; }

    public int DepartmentId { get; set; }
    public virtual Department Department { get; set; } = null!;

    public int? AccountId { get; set; }
    public virtual Account? Account { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}