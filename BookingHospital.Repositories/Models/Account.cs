namespace BookingHospital.Repositories.Models;

public class Account
{
    public int Id { get; set; }
    public string UserName { get; set; } = null !;
    public string Password { get; set; } = null !;
}