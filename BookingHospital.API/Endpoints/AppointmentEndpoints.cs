using BookingHospital.Services.Features.Appointments.BookAppointment;

namespace BookingHospital.API.Endpoints;

public static class AppointmentEndpoints
{
    public static void MapAppointmentEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/appointments");

        group.MapPost("/", async (BookAppointmentRequest req, BookAppointmentHandler handler) =>
        {
            var result = await handler.Handle(req);
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });
    }
}