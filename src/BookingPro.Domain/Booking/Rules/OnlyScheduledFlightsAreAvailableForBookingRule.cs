using BookingPro.Domain.Common.Rules;
using BookingPro.Domain.Flights;

namespace BookingPro.Domain.Booking.Rules
{
    internal class OnlyScheduledFlightsAreAvailableForBookingRule : IRule
    {
        private readonly IEnumerable<FlightInfo> _flightInfos;

        public OnlyScheduledFlightsAreAvailableForBookingRule(IEnumerable<FlightInfo> flightInfos)
        {
            _flightInfos = flightInfos;
        }

        public string Message => "Время продажи билетов на данный рейс истекло.";

        public bool IsBroken()
        {
            return _flightInfos.Any(item => item.Status != FlightStatus.Scheduled);
        }
    }
}
