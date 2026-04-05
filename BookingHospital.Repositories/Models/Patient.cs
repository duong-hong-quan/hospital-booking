namespace BookingHospital.Repositories.Models;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Address { get; set; }

    public int? AccountId { get; set; }
    public virtual Account? Account { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}