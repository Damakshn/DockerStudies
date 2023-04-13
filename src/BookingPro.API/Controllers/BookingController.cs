﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookingPro.Domain.Booking;
using BookingPro.Domain.Flights.Services;
using BookingPro.Domain.Common.ErrorHandling;
using System.Web.Http.Results;

namespace BookingPro.API.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IFlightInfoService _flightInfoService;

        public BookingController(IBookingService bookingService, IFlightInfoService flightInfoService)
        {
            _bookingService = bookingService;
            _flightInfoService = flightInfoService;
        }

        [HttpPost]
        public ActionResult<string> CreateBooking([FromBody] IEnumerable<BookingInputModel> input)
        {
            try
            {
                var flightIds = (from item in input select item.FlightId).ToList();
                var flightInfos = _flightInfoService.GetFlightInfos(flightIds);
                string bookingRef = _bookingService.CreateBooking(input, flightInfos);
                return Ok(bookingRef);
            }
            catch (DomainException dex)
            {
                return BadRequest(dex.Message);
            }
            catch (Exception ex)
            {   
                var result500 = StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                return result500;
            }
        }

        [HttpGet]
        public ActionResult<string> GetBooking()
        {
            return Ok("Booking service lives here");
        }
    }
}