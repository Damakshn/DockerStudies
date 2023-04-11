using BookingPro.Domain.Common.ErrorHandling;
using BookingPro.Domain.Booking;
using BookingPro.Domain.Flights;
using FluentAssertions;
using BookingPro.UnitTests.Utils.CustomAttributes;

namespace BookingPro.UnitTests;

public class BookingServiceTests
{
    [Test]
    public void Booking_of_flight_without_available_seats_is_not_possible([Values]FareConditions conditions)
    {
        IBookingService sut = new BookingService();

        int flightId = 1;
        BookingInputModel input = new() 
        { 
            FareConditions = conditions, 
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
            { conditions, 0 }
        };
        DateTime departure = DateTime.SpecifyKind(DateTime.Now.AddMonths(1), DateTimeKind.Utc);
        DateTime arrival = departure.AddHours(3);
        FlightInfo flightInfo = new(flightId, departure, arrival, FlightStatus.Scheduled, seats);

        Action action = () => sut.CreateBooking(new List<BookingInputModel>() { input }, new List<FlightInfo>() { flightInfo });

        action
            .Should()
            .Throw<DomainException>()
            .WithMessage("Ќа выбранный рейс закончились билеты. ѕопробуйте выбрать другой класс обслуживани€ или посмотрите билеты на другую дату.");
    }

    [Test]
    public void Non_scheduled_flights_are_not_available_for_booking(
        [AllEnumValuesExcept(FlightStatus.Scheduled)] FlightStatus status, 
        [Values] FareConditions conditions)
    {
        IBookingService sut = new BookingService();

        int flightId = 1;
        List<BookingInputModel> bookings = new()
        {
            new() 
            {
                FareConditions = conditions,
                FlightId = flightId,
                PassengerInfo = new()
                {
                    Name = "IVAN IVANOV",
                    ContactInfo = "contact info goes here",
                    PassengerId = "1234 567890"
                }
            },
        };
        
        Dictionary<FareConditions, int> seats = new()
        {
            { FareConditions.Business, 10 },
            { FareConditions.Economy, 10 },
            { FareConditions.Comfort, 10 }
        };

        DateTime departure = DateTime.SpecifyKind(DateTime.Now.AddMonths(1), DateTimeKind.Utc);
        DateTime arrival = departure.AddHours(3);
        List<FlightInfo> flightInfos = new() { new(flightId, departure, arrival, status, seats) };

        Action action = () =>  sut.CreateBooking(bookings, flightInfos);

        action
            .Should()
            .Throw<DomainException>()
            .WithMessage("¬рем€ продажи билетов на данный рейс истекло.");
    }
}