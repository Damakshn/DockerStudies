using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using BookingPro.Domain.Booking;
using BookingPro.Infrastructure.Database.Booking;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace BookingPro.Infrastructure.Database.ServiceExtensions
{
    public static class DatabaseServiceExtensions
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddScoped((sp) => new NpgsqlConnection("Host=localhost; Port=5432; Username=postgres; Password=12345; Database=demo; Include Error Detail=true"));
            services.AddScoped<IBookingRepository, BookingRepository>();
        }
    }
}
