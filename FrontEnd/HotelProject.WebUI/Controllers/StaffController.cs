using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // this part for list Staff
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5171/api/Staff");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }

        // this part for add Staff

        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model); // this part serializing a data which comes from model
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5171/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //This part for delete Staff

        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5171/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // this part for Gets Staff info to page for updating
        [HttpGet]
        public async Task<IActionResult> UpdateStaffData(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5171/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData =await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View(values);
            }
            return View();
        }

        // this part fpr updating Staff Data
        [HttpPost]
        public async Task<IActionResult> UpdateStaffData(UpdateStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("http://localhost:5171/api/Staff",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
