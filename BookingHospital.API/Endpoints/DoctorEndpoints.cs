using BookingHospital.Services.Features.Doctors.GetDoctors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace BookingHospital.API.Endpoints;

public static class DoctorEndpoints
{
    public static void MapDoctorEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/doctors");

        group.MapGet("/", async (GetDoctorsHandler handler) =>
        {
            var result = await handler.Handle();
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });
    }
}
