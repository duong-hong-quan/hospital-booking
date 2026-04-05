namespace BookingHospital.Services.Features.Appointments.BookAppointment;

public record BookAppointmentRequest(int PatientId, int DoctorId, DateTime AppointmentDate, string? Reason);