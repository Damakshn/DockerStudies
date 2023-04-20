using BookingPro.API.DummyServices;
using BookingPro.Domain.Booking;
using BookingPro.Domain.Flights.Services;
using BookingPro.Infrastructure.Database.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabase();
//builder.Services.AddScoped<IBookingRepository, DummyBookingRepo>();
builder.Services.AddScoped<IFlightInfoService, DummyFlightInfoRepo>();
builder.Services.AddScoped<IBookingService, BookingService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();
