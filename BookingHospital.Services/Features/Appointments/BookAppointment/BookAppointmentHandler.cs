using BookingHospital.Repositories.Models;
using BookingHospital.Repositories.Repositories;
using BookingHospital.Services.Shared;

namespace BookingHospital.Services.Features.Appointments.BookAppointment;

public sealed class BookAppointmentHandler
{
    private readonly IGenericRepository<Appointment> _appointmentRepo;
    private readonly IGenericRepository<Doctor> _doctorRepo;
    private readonly IGenericRepository<Patient> _patientRepo;

    public BookAppointmentHandler(
        IGenericRepository<Appointment> appointmentRepo,
        IGenericRepository<Doctor> doctorRepo,
        IGenericRepository<Patient> patientRepo)
    {
        _appointmentRepo = appointmentRepo;
        _doctorRepo = doctorRepo;
        _patientRepo = patientRepo;
    }

    public async Task<Result<int>> Handle(BookAppointmentRequest request)
    {
        if (request.AppointmentDate < System.DateTime.UtcNow)
        {
            return Result.Failure<int>(ErrorMap.Appointments.InvalidDate);
        }

        if (!await _doctorRepo.ExistsAsync(d => d.Id == request.DoctorId))
        {
            return Result.Failure<int>(ErrorMap.Appointments.DoctorNotFound);
        }

        if (!await _patientRepo.ExistsAsync(p => p.Id == request.PatientId))
        {
            return Result.Failure<int>(ErrorMap.Appointments.PatientNotFound);
        }

        var appointment = new Appointment
        {
            PatientId = request.PatientId,
            DoctorId = request.DoctorId,
            AppointmentDate = request.AppointmentDate,
            Reason = request.Reason,
            Status = AppointmentStatus.Pending
        };

        await _appointmentRepo.AddAsync(appointment);
        await _appointmentRepo.SaveChangesAsync();

        return Result.Success(appointment.Id);
    }
}