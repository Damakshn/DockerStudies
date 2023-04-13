using BookingPro.Domain.Flights;

namespace BookingPro.Domain.Booking.BookingHistory
{
    /// <summary>
    /// Забронированный билет на рейс
    /// </summary>
    public class BookedFlight
    {
        public required string BookRef { get; init; }

        public required DateTime BookDate { get; init; }

        public required string PassengerId { get; init; }

        public required string PassengerName { get; init; }

        public required DateTime When { get; init; }

        public required string From { get; init;}

        public required string To { get; init; }

        public required string AircraftModel { get; init; }

        public required FlightStatus FlightStatus { get; init; }

        public required FareConditions FareConditions { get; init; }

        public required string SeatNo { get; init; }

        public required int Amount { get; init; }
    }
}
