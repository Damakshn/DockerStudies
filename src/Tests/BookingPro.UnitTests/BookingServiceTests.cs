using BookingPro.Domain.Common.ErrorHandling;
using BookingPro.Domain.Booking;
using BookingPro.Domain.Flights;
using FluentAssertions;

namespace BookingPro.UnitTests;

public class BookingServiceTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Booking_of_flight_without_available_seats_is_not_possible()
    {
        IBookingService bookingService = new BookingService();

        int flightId = 1;
        BookingInputModel input = new() 
        { 
            FareConditions = FareConditions.Economy, 
            FlightId = flightId, 
            PassengerInfo = new()
            {
                Name = "IVAN IVANOV",
                ContactInfo = "contact info goes here",
                PassengerId = "1234 567890"
            } 
        };
        Dictionary<FareConditions, int> seats = new()
        {
            { FareConditions.Economy, 0 }
        };
        DateTime departure = DateTime.SpecifyKind(DateTime.Now.AddMonths(1), DateTimeKind.Utc);
        DateTime arrival = departure.AddHours(3);
        FlightInfo flightInfo = new(flightId, departure, arrival, FlightStatus.Scheduled, seats);

        Action action = () => bookingService.CreateBooking(new List<BookingInputModel>() { input }, new List<FlightInfo>() { flightInfo });

        action
            .Should()
            .Throw<DomainException>()
            .WithMessage("Ќа выбранный рейс закончились билеты. ѕопробуйте выбрать другой класс обслуживани€ или посмотрите билеты на другую дату.");
    }
}