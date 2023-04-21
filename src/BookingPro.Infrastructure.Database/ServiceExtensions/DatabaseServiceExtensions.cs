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
        public static void AddDatabase(this IServiceCollection services, string? connectionString)
        {
            ArgumentNullException.ThrowIfNull(connectionString, nameof(connectionString));

            services.AddScoped((sp) => new NpgsqlConnection(connectionString));
            services.AddScoped<IBookingRepository, BookingRepository>();
        }
    }
}
