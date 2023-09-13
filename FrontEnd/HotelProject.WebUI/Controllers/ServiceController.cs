using HotelProject.WebUI.Dtos.Service;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // this part for list Service
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5171/api/Service");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        // this part for add Service

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddService(CreateServiceDto createServiceDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createServiceDto); // this part serializing a data which comes from createServiceDto
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5171/api/Service", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //This part for delete Service

        public async Task<IActionResult> DeleteService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5171/api/Service/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // this part for Gets Service info to page for updating
        [HttpGet]
        public async Task<IActionResult> UpdateServiceData(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5171/api/Service/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
                return View(values);
            }
            return View();
        }

        // this part for updating Service Data
        [HttpPost]
        public async Task<IActionResult> UpdateServiceData(UpdateServiceDto updateServiceDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5171/api/Service", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
