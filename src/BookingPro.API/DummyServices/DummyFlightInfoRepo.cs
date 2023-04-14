using BookingPro.Domain.Flights;
using BookingPro.Domain.Flights.Services;

namespace BookingPro.API.DummyServices
{
    public class DummyFlightInfoRepo : IFlightInfoService
    {
        public List<FlightInfo> GetFlightInfos(IEnumerable<int> flightIds)
        {
            DateTime departure = DateTime.SpecifyKind(DateTime.Now.AddMonths(1), DateTimeKind.Utc);
            DateTime arrival = departure.AddHours(3);
            Dictionary<FareConditions, int> seats = new()
            {
                {FareConditions.Comfort, 10 },
                {FareConditions.Business, 20},
                {FareConditions.Economy, 30},
            };
            var result = from id in flightIds
                         select new FlightInfo(id, departure, arrival, FlightStatus.Scheduled, seats);
            
            return result.ToList();
        }
    }
}
