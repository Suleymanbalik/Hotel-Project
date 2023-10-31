using HotelProject.BusinessLayer.Abstract;
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

        // this part for approve bookings (just changing teh status to approved!)
        //[HttpPut("UpdateBookingStatusToApproved/{id}")]
        [HttpGet("UpdateBookingStatusToApproved")]
        public IActionResult UpdateBookingStatusToApproved( int id /*int id*/)
        {
            //var approvedBookingDto = _bookingService.TGetByID(id);
            //approvedBookingDto.BookingStatus = "Approved!";
            _bookingService.TBookingStatusChangeApproved(id);
            return Ok();
        }

       
        [HttpGet("UpdateBookingStatusToCancel")]
        public IActionResult UpdateBookingStatusToCancel(int id)
        {
            _bookingService.TBookingStatusChangeCancel(id);
            return Ok();
        }

        [HttpGet("UpdateBookingStatusToDelay")]
        public IActionResult UpdateBookingStatusToDelay(int id)
        {
            _bookingService.TBookingStatusChangeDelay(id);
            return Ok();
        }

        [HttpGet("GetLastSixBookingItemsList")]
        public IActionResult GetLastSixBookingItemsList()
        {
            var values = _bookingService.TGetLastSixBookingItemsList();
            return Ok(values);
        }
    }
}
