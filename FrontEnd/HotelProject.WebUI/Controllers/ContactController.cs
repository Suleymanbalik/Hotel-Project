using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.MessageCategoryDto;
using HotelProject.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // this part hold the message categories by using DropDownList
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5171/api/MessageCategory");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMessageCategoryDto>>(jsonData);

            List<SelectListItem> messageCategory = (from m in values
                                                    select new SelectListItem
                                                    {
                                                        Text = m.MessageCategoryName,
                                                        Value = m.MessageCategoryID.ToString()
                                                    }).ToList();
            ViewBag.MessageCategory = messageCategory;
            return View();
        }


        [HttpGet]
        public PartialViewResult SendMessagePartial()
        {
            return PartialView();
        }

        // This part for the save messages on contact page (User part)
        [HttpPost]
        public async Task<IActionResult> SendMessagePartial(CreateContactDto createContactDto)
        {
            
            createContactDto.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto); // this part serializing a data which comes from createContactDto
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:5171/api/Contact", stringContent);
            return RedirectToAction("Index", "Default");

        }
    }
}
