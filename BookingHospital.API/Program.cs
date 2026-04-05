using BookingHospital.API.Endpoints;
using BookingHospital.Repositories.Data;
using BookingHospital.Repositories.Repositories;
using BookingHospital.Services.Features.Appointments.BookAppointment;
using BookingHospital.Services.Features.Doctors.GetDoctors;
using BookingHospital.Services.Features.Patients.CreatePatient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HospitalContext>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<BookAppointmentHandler>();
builder.Services.AddScoped<GetDoctorsHandler>();
builder.Services.AddScoped<CreatePatientHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapAppointmentEndpoints();
app.MapDoctorEndpoints();
app.MapPatientEndpoints();

app.Run();