using BookingPro.Domain.Common.ErrorHandling;
using BookingPro.Domain.Booking;
using BookingPro.Domain.Flights;
using FluentAssertions;
using BookingPro.UnitTests.Utils.CustomAttributes;
using BookingPro.UnitTests.Fixtures.Booking;
using AutoFixture;
using System.Text.RegularExpressions;
using Moq;

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

    [Test]
    [BookingData]
    public void Booking_can_be_created(Mock<IBookingRepository> mockedRepository, BookingInputModel input, FlightInfo flightInfo)
    {
        IBookingRepository repository = mockedRepository.Object;
        BookingService sut = new(repository);
        string bookingId = sut.CreateBooking(new List<BookingInputModel>() { input }, new List<FlightInfo>() { flightInfo });
        bookingId.Should().NotBeNullOrWhiteSpace();
        bookingId.Should().HaveLength(6);
        bookingId.Should().MatchRegex(new Regex(@"[\dA-F]{6}"));
        mockedRepository.Verify(repository => repository.Add(It.IsAny<IEnumerable<BookingInputModel>>()), Times.Exactly(1));
    }

    [TestCase("")]
    [TestCase("   ")]
    [TestCase(null)]
    public void Cannot_get_booking_history_without_passengerId(string passengerId)
    {
        IFixture fixture = new Fixture();
        fixture.Customize(new BookingFixtureCustomization());
        BookingService sut = fixture.Create<BookingService>();
        Action action = () => sut.GetBookingHistory(passengerId);

        action.Should().Throw<DomainException>().WithMessage(" од пассажира должен быть заполнен");
    }

    [Test]
    [BookingData]
    public void Can_retrieve_booking_history_from_repository(Mock<IBookingRepository> mockedRepository)
    {
        var repository = mockedRepository.Object;
        BookingService sut = new(repository);

        string passengerId = "1111 222333";

        _ = sut.GetBookingHistory(passengerId);

        mockedRepository.Verify(repository => repository.GetTicketsForPassenger(passengerId), Times.Exactly(1));
    }
}