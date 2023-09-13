using HotelProject.WebUI.Models.Staff;
using HotelProject.WebUI.Models.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5171/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<TestimonialViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }

        // this part for add Testimonial

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonial(AddTestimonialViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model); // this part serializing a data which comes from model
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5171/api/Testimonial", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //This part for delete Testimonial

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5171/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // this part for Gets Testimonialinfo to page for updating
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonialData(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5171/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTestimonialViewModel>(jsonData);
                return View(values);
            }
            return View();
        }

        // this part fpr updating Testimonial Data
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonialData(UpdateTestimonialViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5171/api/Testimonial", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
