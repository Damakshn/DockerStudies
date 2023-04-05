using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingPro.Domain.Flights;

namespace BookingPro.Domain.Booking.BookingHistory
{
    /// <summary>
    /// Забронированный билет на рейс
    /// </summary>
    public class BookedFlight
    {
        public DateTime When { get; set; }

        public string From { get; set;}

        public string To { get; set; }

        public string AircraftModel { get; set; }

        public FlightStatus FlightStatus { get; set; }

        public FareConditions FareConditions { get; set; }

        public string SeatNo { get; set; }

        public int Amount { get; set; }
    }
}
