using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.Dtos.SentMessageDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // this part for list Messages For InboxPage
        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5171/api/Contact");

            // the part below for Viewbag which shows the ınformatipn inbox messagescount
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:5171/api/Contact/GetContactCount");

            // the part below for Viewbag which shows the ınformatipn Sentbox messagescount
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:5171/api/SentMessageController/GetSentMessagesCount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);

                //The part below for the ViewBag in Inboxpage and gives Inboxmessagescount
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.InboxMessagesCount = jsonData2;

                //The part below for the ViewBag in Inboxpage and gives SentBoxmessagescount
                var jsonData3 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.SentBoxMessagesCount = jsonData3;

                return View(values);               
            }
            return View();
        }

        // this part for list Messages For SentBox 
        public async Task<IActionResult> Sentbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5171/api/SentMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSentMessageDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        // this part for add SentMessage

        [HttpGet]
        public IActionResult AddSentMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSentMessage(CreateSentMessageDto createSentMessageDto)
        {
            createSentMessageDto.SentMessageSenderMail = "admin@gmail.com";
            createSentMessageDto.SentMessageSenderName = "admin";
            createSentMessageDto.SentMessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSentMessageDto); // this part serializing a data which comes from model
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5171/api/SentMessage", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SentBox");
            }
            return View();
        }

        // This Part Shows Details for the sentbox messages
        [HttpGet]
        public async Task<IActionResult> SentBoxMessageDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5171/api/SentMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultSentMessageDto>(jsonData);
                return View(values);
            }
            return View();
        }

        // This Part Shows Details for the ınbox messages
        [HttpGet]
        public async Task<IActionResult> InBoxMessageDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5171/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageDetailsByIDDto>(jsonData);
                return View(values);
            }
            return View();
        }


        public PartialViewResult AdminContactMailSideBarPartial()
        {
            return PartialView();
        }

        public PartialViewResult AdminContactMailCategorySideBarPartial()
        {
            return PartialView();
        }      
    }
}
