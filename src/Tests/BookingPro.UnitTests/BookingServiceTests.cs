using BookingPro.Domain.Common.ErrorHandling;
using BookingPro.Domain.Booking;
using BookingPro.Domain.Flights;
using FluentAssertions;
using BookingPro.UnitTests.Utils.CustomAttributes;
using BookingPro.UnitTests.Fixtures.Booking;
using AutoFixture;

namespace BookingPro.UnitTests;

public class BookingServiceTests
{
    [Test]
    [BookingData]
    public void Booking_of_flight_without_available_seats_is_not_possible(BookingService sut, BookingInputModel input, FlightInfo flightInfo)
    {   
        Dictionary<FareConditions, int> noSeats = new()
        {
            { FareConditions.Economy, 0 }
        };

        flightInfo.SeatsAvailable = noSeats;

        Action action = () => sut.CreateBooking(new List<BookingInputModel>() { input }, new List<FlightInfo>() { flightInfo });

        action
            .Should()
            .Throw<DomainException>()
            .WithMessage("Ќа выбранный рейс закончились билеты. ѕопробуйте выбрать другой класс обслуживани€ или посмотрите билеты на другую дату.");
    }

    [Test]
    public void Non_scheduled_flights_are_not_available_for_booking(
        [AllEnumValuesExcept(FlightStatus.Scheduled)] FlightStatus status)
    {
        IFixture fixture = new Fixture();
        fixture.Customize(new BookingFixtureCustomization());
        BookingService sut = fixture.Create<BookingService>();
        List<BookingInputModel> bookings = new() { fixture.Create<BookingInputModel>() };
        FlightInfo flightInfo = fixture.Create<FlightInfo>();
        flightInfo.Status = status;
        List<FlightInfo> flightInfos = new() { flightInfo };

        Action action = () =>  sut.CreateBooking(bookings, flightInfos);

        action
            .Should()
            .Throw<DomainException>()
            .WithMessage("¬рем€ продажи билетов на данный рейс истекло.");
    }
}