using BookingPro.Domain.Booking;
using BookingPro.Domain.Booking.BookingHistory;

namespace BookingPro.API.DummyServices
{
    public class DummyBookingRepo : IBookingRepository
    {
        public string Add(IEnumerable<BookingInputModel> bookings)
        {
            throw new NotImplementedException();
        }

        public List<BookedFlight> GetTicketsForPassenger(string passengerId)
        {
            throw new NotImplementedException();
        }
    }
}
