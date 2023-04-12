using System.Reflection;
using AutoFixture.Kernel;

namespace BookingPro.UnitTests.Fixtures.Booking
{
    internal class FlightIdSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (request is PropertyInfo pi && pi.PropertyType == typeof(int) && pi.Name == "FlightId")
            {
                return 42;
            }
            return new NoSpecimen();
        }
    }
}
