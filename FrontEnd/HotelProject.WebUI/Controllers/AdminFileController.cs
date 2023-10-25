using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Net.Http.Headers;

namespace HotelProject.WebUI.Controllers
{
    public class AdminFileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        // Index part for load Image
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes =stream.ToArray();

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.PostAsync("http://localhost:5171/api/File/UploadImage", multipartFormDataContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return View();
            }
            return View();
        }

        // this part for load Document

        [HttpGet]
        public IActionResult LoadTextFile()
        {
            return View();
        }

        // I had to put method ın url beacuse there are two methods in Api controller and both have HttpPost. We let know method to use specific method in api by this way. 
        [HttpPost]
        public async Task< IActionResult> LoadTextFile(IFormFile file)
        {
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.PostAsync("http://localhost:5171/api/File/UploadTextFile", multipartFormDataContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return View();
            }
            return View();
        }
    }
}
