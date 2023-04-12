using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BookingPro.Domain.Flights
{
    /// <summary>
    /// Справочная информация о рейсе.
    /// Вспомогательный класс для проведения проверки, можно ли забронировать место на данный рейс.
    /// </summary>
    public class FlightInfo
    {
        public FlightInfo(int flightId, DateTime scheduledDeparture, DateTime scheduledArrival, FlightStatus status, Dictionary<FareConditions, int> seatsAvailable)
        {
            FlightId = flightId;
            ScheduledDeparture = scheduledDeparture;
            ScheduledArrival = scheduledArrival;
            Status = status;
            SeatsAvailable = seatsAvailable;
        }

        public int FlightId { get; set; }

        public DateTime ScheduledDeparture { get; set; }

        public DateTime ScheduledArrival { get; set; }

        public FlightStatus Status { get; set; }

        public Dictionary<FareConditions, int> SeatsAvailable { get; set; }

    }
}
