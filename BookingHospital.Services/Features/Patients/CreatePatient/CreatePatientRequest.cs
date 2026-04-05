using System;

namespace BookingHospital.Services.Features.Patients.CreatePatient;

public record CreatePatientRequest(string Name, DateTime DateOfBirth, string Gender, string? Phone, string? Address);
