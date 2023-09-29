﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var bookinglist = _bookingService.TGetList();
            return Ok(bookinglist);
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            _bookingService.TInsert(booking);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var deleteBooking = _bookingService.TGetByID(id);
            _bookingService.TDelete(deleteBooking);
            return Ok();
        }

        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var getBooking = _bookingService.TGetByID(id);
            return Ok(getBooking);
        }

        // this part does not work we will fix it after
        [HttpPut("UpdateBookingStatusToApproved/{id}")]
        public IActionResult UpdateBookingStatusToApproved(int id)
        {
            var approvedBookingDto = _bookingService.TGetByID(id);
            approvedBookingDto.BookingStatus = "Approved!";
            _bookingService.TBookingStatusChangeApproved(approvedBookingDto);
            return Ok();
        }
    }
}
