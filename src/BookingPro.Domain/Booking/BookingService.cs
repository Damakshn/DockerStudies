using BookingPro.Domain.Booking.BookingHistory;
using BookingPro.Domain.Flights;
using BookingPro.Domain.Common.Abstractions;
using BookingPro.Domain.Booking.Rules;

namespace BookingPro.Domain.Booking
{
    public class BookingService : DomainService, IBookingService
    {
        public string CreateBooking(IEnumerable<BookingInputModel> bookings, IEnumerable<FlightInfo> flightInfos)
        {
            CheckRule(new CannotBookAFlightIfNoSeatsAvailableRule(bookings, flightInfos));
            CheckRule(new OnlyScheduledFlightsAreAvailableForBookingRule(flightInfos));

            return "";
        }

        public List<BookingInfo> GetBookingHistory(string passengerId)
        {
            throw new NotImplementedException();
        }
    }
}
