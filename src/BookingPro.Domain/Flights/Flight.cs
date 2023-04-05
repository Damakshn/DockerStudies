using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingPro.Domain.Flights
{
    public class Flight
    {
        public int FlightId { get; set; }

        public string FlightNo { get; set; }

        public DateTime ScheduledDeparture { get; set; }

        public DateTime ScheduledArrival { get; set; }

        public string DepartureAirport { get; set; }

        public string ArrivalAirport { get; set; }

        public FlightStatus Status { get; set; }

        public string AircraftCode { get; set; }

        public DateTime ActualDeparture { get; set; }

        public DateTime ActualArrival { get; set; }
    }
}
