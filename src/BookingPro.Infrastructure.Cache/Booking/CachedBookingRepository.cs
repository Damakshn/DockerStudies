using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using BookingPro.Domain.Booking;
using BookingPro.Domain.Booking.BookingHistory;

namespace BookingPro.Infrastructure.Cache.Booking
{
    public class CachedBookingRepository : IBookingRepository
    {
        private IBookingRepository _decorated;
        private IDistributedCache _cache;

        public CachedBookingRepository(IBookingRepository decorated, IDistributedCache cache)
        {
            _decorated = decorated;
            _cache = cache;
        }

        public string Add(IEnumerable<BookingInputModel> bookings)
        {
            return _decorated.Add(bookings);
        }

        public async Task<List<BookedFlight>> GetTicketsForPassengerAsync(string passengerId, CancellationToken cancellationToken = default)
        {
            List<BookedFlight> result;
            string key = $"tickets:{passengerId}";
            var cacheEntry = await _cache.GetStringAsync(key, default);
            if (cacheEntry != null)
            {
                result = JsonSerializer.Deserialize<List<BookedFlight>>(cacheEntry) ?? new();
            } 
            else
            {
                result = await _decorated.GetTicketsForPassengerAsync(passengerId, cancellationToken);
                await _cache.SetStringAsync(
                    key,
                    JsonSerializer.Serialize(result),
                    new DistributedCacheEntryOptions()
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) 
                    },
                    cancellationToken);
            }
            return result;
        }
    }
}
