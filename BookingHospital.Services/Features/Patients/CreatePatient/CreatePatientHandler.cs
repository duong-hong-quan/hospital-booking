using System.Threading.Tasks;
using BookingHospital.Repositories.Models;
using BookingHospital.Repositories.Repositories;
using BookingHospital.Services.Shared;

namespace BookingHospital.Services.Features.Patients.CreatePatient;

public sealed class CreatePatientHandler
{
    private readonly IGenericRepository<Patient> _patientRepo;

    public CreatePatientHandler(IGenericRepository<Patient> patientRepo)
    {
        _patientRepo = patientRepo;
    }

    public async Task<Result<int>> Handle(CreatePatientRequest request)
    {
        var patient = new Patient
        {
            Name = request.Name,
            DateOfBirth = request.DateOfBirth,
            Gender = request.Gender,
            Phone = request.Phone,
            Address = request.Address
        };

        await _patientRepo.AddAsync(patient);
        await _patientRepo.SaveChangesAsync();

        return Result.Success(patient.Id);
    }
}
