using HotelProject.WebUI.Dtos.AboutDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        public readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // This part provide information about the number of Staff -Personel Sayisi
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5171/api/DashboardWidGets/GetStaffCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.StaffCount = jsonData;


            // This part provide information about the number of bookings -Rezervasyon Sayisi
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:5171/api/DashboardWidGets/GetBookingCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.BookingCount = jsonData2;


            // This part provide information about the number of Customer(AppUser) - Musteri sayisi
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:5171/api/DashboardWidGets/AppUserCustomerCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.CustomerCount = jsonData3;

            // This part provide information about the number of Room - Oda sayisi
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("http://localhost:5171/api/DashboardWidGets/GetRoomCount");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.RoomCount = jsonData4;

            return View();
        }
    }
}
