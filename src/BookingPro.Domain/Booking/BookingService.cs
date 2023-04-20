using BookingPro.Domain.Booking.BookingHistory;
using BookingPro.Domain.Flights;
using BookingPro.Domain.Common.Abstractions;
using BookingPro.Domain.Booking.Rules;

namespace BookingPro.Domain.Booking
{
    public class BookingService : DomainService, IBookingService
    {
        private readonly IBookingRepository _repository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _repository = bookingRepository;
        }

        public string CreateBooking(IEnumerable<BookingInputModel> bookings, IEnumerable<FlightInfo> flightInfos)
        {
            CheckRule(new CannotBookAFlightIfNoSeatsAvailableRule(bookings, flightInfos));
            CheckRule(new OnlyScheduledFlightsAreAvailableForBookingRule(flightInfos));
            return _repository.Add(bookings);
        }

        public Task<List<BookedFlight>> GetBookingHistory(string passengerId)
        {
            CheckRule(new PassengerIdMustNotBeEmptyRule(passengerId));

            return _repository.GetTicketsForPassenger(passengerId);
        }
    }
}
