using System.Collections.Generic;
using BookingPro.Domain.Booking;
using BookingPro.Domain.Booking.BookingHistory;

namespace BookingPro.API.DummyServices
{
    public class DummyBookingRepo : IBookingRepository
    {
        public string Add(IEnumerable<BookingInputModel> bookings)
        {
            return "000F1A";
        }

        public Task<List<BookedFlight>> GetTicketsForPassengerAsync(string passengerId, CancellationToken cancellationToken = default)
        {
            DateTime departure = DateTime.SpecifyKind(DateTime.Now.AddMonths(1), DateTimeKind.Utc);
            DateTime nowUtc = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            string passengerName = "ALEXEY IVANOV";
            return Task.FromResult<List<BookedFlight>>(new()
            {
                new()
                {
                    BookRef = "000001",
                    BookDate = nowUtc.AddDays(-2),
                    PassengerId = passengerId,
                    PassengerName = passengerName,
                    When = departure,
                    From = "IKT",
                    To = "OVB",
                    AircraftModel = "A320",
                    FlightStatus = Domain.Flights.FlightStatus.Scheduled,
                    FareConditions = Domain.Flights.FareConditions.Economy,
                    SeatNo = "7B",
                    Amount = 15000
                },
                new()
                {
                    BookRef = "000002",
                    BookDate = nowUtc.AddDays(-1),
                    PassengerId = passengerId,
                    PassengerName = passengerName,
                    When = departure.AddDays(10),
                    From = "OVB",
                    To = "IKT",
                    AircraftModel = "A320",
                    FlightStatus = Domain.Flights.FlightStatus.Scheduled,
                    FareConditions = Domain.Flights.FareConditions.Economy,
                    SeatNo = "8A",
                    Amount = 15000
                }
            });
        }
    }
}
