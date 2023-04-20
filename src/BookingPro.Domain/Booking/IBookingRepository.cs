using BookingPro.Domain.Booking.BookingHistory;

namespace BookingPro.Domain.Booking
{
    public interface IBookingRepository
    {
        string Add(IEnumerable<BookingInputModel> bookings);

        Task<List<BookedFlight>> GetTicketsForPassenger(string passengerId);
    }
}
