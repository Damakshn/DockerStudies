using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingPro.Domain.Common.ErrorHandling;
using BookingPro.Domain.Common.Rules;
using BookingPro.Domain.Flights;

namespace BookingPro.Domain.Booking.Rules
{
    internal class CannotBookAFlightIfNoSeatsAvailableRule : IRule
    {
        private readonly IEnumerable<BookingInputModel> _bookings;
        private readonly IEnumerable<FlightInfo> _flightInfos;

        public CannotBookAFlightIfNoSeatsAvailableRule(IEnumerable<BookingInputModel> bookings, IEnumerable<FlightInfo> flightInfos)
        {
            _bookings = bookings;
            _flightInfos = flightInfos;
        }

        public string Message => "На выбранный рейс закончились билеты. Попробуйте выбрать другой класс обслуживания или посмотрите билеты на другую дату.";

        public bool IsBroken()
        {
            var mappedFlights = from booking in _bookings
                join flight in _flightInfos
                on booking.FlightId equals flight.FlightId
                select new { Booking = booking, Flight = flight };

            return mappedFlights.Any(item => item.Flight.SeatsAvailable[item.Booking.FareConditions] < 1);

        }
    }
}
