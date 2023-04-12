using AutoFixture;
using AutoFixture.NUnit3;

namespace BookingPro.UnitTests.Fixtures.Booking
{
    [AttributeUsage(AttributeTargets.Method)]
    public class BookingDataAttribute : AutoDataAttribute
    {
        public BookingDataAttribute() :
            base(() => 
            {
                var fixture = new Fixture();
                fixture.Customize(new BookingFixtureCustomization());
                return fixture;
            })
        {

        }
    }
}
