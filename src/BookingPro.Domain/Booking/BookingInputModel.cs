using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingPro.Domain.Flights;
using BookingPro.Domain.Passengers;

namespace BookingPro.Domain.Booking
{
    public class BookingInputModel
    {
        public int FlightId { get; set; }

        public FareConditions FareConditions { get; set; }

        public PassengerInfo PassengerInfo { get; set; }

    }
}
