namespace BookingHospital.Services.Shared;

public static class ErrorMap
{
    public static class Appointments
    {
        public const string InvalidDate = "APPOINTMENT_INVALID_DATE";
        public const string DoctorNotFound = "DOCTOR_NOT_FOUND";
        public const string PatientNotFound = "PATIENT_NOT_FOUND";
        public const string BookingFailed = "APPOINTMENT_BOOKING_FAILED";
    }
}