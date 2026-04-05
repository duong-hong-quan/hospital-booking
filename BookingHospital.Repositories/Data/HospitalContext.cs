using BookingHospital.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingHospital.Repositories.Data;

public class HospitalContext : DbContext
{
    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<Appointment> Appointments { get; set; }

    public HospitalContext()
    {
    }

    public HospitalContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=aws-1-ap-northeast-2.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.ygwgsdnqameioghmocfe;Password=booking_hospital123@;");
    }
}