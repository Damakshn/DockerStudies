using AutoFixture;
using AutoFixture.AutoMoq;
using BookingPro.Domain.Booking;
using BookingPro.Domain.Flights;
using BookingPro.Domain.Passengers;
using Moq;

namespace BookingPro.UnitTests.Fixtures.Booking
{
    public class BookingFixtureCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize(new AutoMoqCustomization());
            var bookingRepositoryMock = fixture.Freeze<Mock<IBookingRepository>>();
            bookingRepositoryMock.Setup(m => m.Add(It.IsAny<IEnumerable<BookingInputModel>>())).Returns("00F012");

            fixture.Customizations.Add(new FlightIdSpecimenBuilder());

            fixture.Customize<ContactData>(
                c => c
                    .With(d => d.Phone, "+7111223334455")
                    .With(d => d.Email, "iivanov@mailbox.su"));

            fixture.Customize<PassengerInfo>(
                c => c
                    .With(p => p.Name, "IVAN IVANOV")
                    .With(p => p.PassengerId, "1111 222222"));

            fixture.Customize<Dictionary<FareConditions, int>>(
                c => c.FromFactory(() => new()
            {
                {FareConditions.Comfort, 10 },
                {FareConditions.Business, 20},
                {FareConditions.Economy, 30},
            }));

            DateTime departure = DateTime.SpecifyKind(DateTime.Now.AddMonths(1), DateTimeKind.Utc);
            DateTime arrival = departure.AddHours(3);
            fixture.Customize<FlightInfo>(
                c => c
                    .With(f => f.Status, FlightStatus.Scheduled)
                    .With(f => f.ScheduledArrival, arrival)
                    .With(f => f.ScheduledDeparture, departure));

            
        }
    }
}
