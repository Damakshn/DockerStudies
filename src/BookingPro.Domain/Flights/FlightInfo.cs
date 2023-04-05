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

        public int FlightId { get; private set; }

        public DateTime ScheduledDeparture { get; private set; }

        public DateTime ScheduledArrival { get; private set; }

        public FlightStatus Status { get; private set; }

        public Dictionary<FareConditions, int> SeatsAvailable { get; private set; }

    }
}
