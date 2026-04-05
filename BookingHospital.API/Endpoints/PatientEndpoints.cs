using BookingHospital.Services.Features.Patients.CreatePatient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace BookingHospital.API.Endpoints;

public static class PatientEndpoints
{
    public static void MapPatientEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/patients");

        group.MapPost("/", async (CreatePatientRequest req, CreatePatientHandler handler) =>
        {
            var result = await handler.Handle(req);
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });
    }
}
