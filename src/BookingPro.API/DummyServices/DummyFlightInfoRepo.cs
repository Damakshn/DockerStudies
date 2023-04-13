using BookingPro.Domain.Flights;
using BookingPro.Domain.Flights.Services;

namespace BookingPro.API.DummyServices
{
    public class DummyFlightInfoRepo : IFlightInfoService
    {
        public List<FlightInfo> GetFlightInfos(IEnumerable<int> flightIds)
        {
            throw new NotImplementedException();
        }
    }
}
