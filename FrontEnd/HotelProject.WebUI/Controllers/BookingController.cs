using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult AddBookingPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddBookingPartial(CreateBookingDto createBookingDto)
        {

            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            createBookingDto.BookingStatus = "Waiting For Approval!";
            createBookingDto.BookingDescription = string.Empty;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto); // this part serializing a data which comes from createServiceDto
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage =
            await client.PostAsync("http://localhost:5171/api/Booking", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
