using BookingPro.Domain.Booking;
using BookingPro.Infrastructure.Cache.Booking;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingPro.Infrastructure.Cache.ServiceExtensions
{
    public static class CachingServiceExtensions
    {
        public static void AddCaching(this IServiceCollection services)
        {
            services.AddStackExchangeRedisCache(options => 
            {
                options.Configuration = "bookingpro.cache.redis";
                options.InstanceName = "bookingpro:";
            });
            services.Decorate<IBookingRepository, CachedBookingRepository>();
        }
    }
}
