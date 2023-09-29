using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        // this part for list Booking
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5171/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        // this part change the status of Bookings to Approved.
        public async Task<IActionResult> ApprovedBooking(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var client = _httpClientFactory.CreateClient();          
            var responseMessage = await client.GetAsync($"http://localhost:5171/api/Booking/UpdateBookingStatusToApproved?id={id}");

            // Mehmet Codes solution for Error 
            //var responseMessage = await client.PutAsync($"http://localhost:5171/api/Booking/UpdateBookingStatusToApproved/{id}", null);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> CancelBooking(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5171/api/Booking/UpdateBookingStatusToCancel?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
