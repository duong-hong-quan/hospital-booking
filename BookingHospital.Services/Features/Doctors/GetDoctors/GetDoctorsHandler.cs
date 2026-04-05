using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookingHospital.Repositories.Models;
using BookingHospital.Repositories.Repositories;
using BookingHospital.Services.Shared;

namespace BookingHospital.Services.Features.Doctors.GetDoctors;

public sealed class GetDoctorsHandler
{
    private readonly IGenericRepository<Doctor> _doctorRepo;

    public GetDoctorsHandler(IGenericRepository<Doctor> doctorRepo)
    {
        _doctorRepo = doctorRepo;
    }

    public async Task<Result<List<GetDoctorsResponse>>> Handle()
    {
        var doctors = await _doctorRepo.GetQueryable()
            .Select(d => new GetDoctorsResponse(d.Id, d.Name, d.Specialization, d.Department.Name))
            .ToListAsync();

        return Result.Success(doctors);
    }
}
