using BookingHospital.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingHospital.Repositories.Data;

public class HospitalContext : DbContext
{
    public virtual DbSet<Account> Accounts { get; set; }

    protected HospitalContext()
    {
    }

    public HospitalContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseNpgsql("postgresql://postgres.ygwgsdnqameioghmocfe:booking_hospital123@@aws-1-ap-northeast-2.pooler.supabase.com:5432/postgres");
    }
}