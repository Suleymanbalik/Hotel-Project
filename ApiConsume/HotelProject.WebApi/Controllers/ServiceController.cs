using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var serviceList = _serviceService.TGetList();
            return Ok(serviceList);
        }

        [HttpPost]
        public IActionResult AddStaff(Service service)
        {
            _serviceService.TInsert(service);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var deleteService = _serviceService.TGetByID(id);
            _serviceService.TDelete(deleteService);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _serviceService.TUpdate(service);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetStaff(int id)
        {
            var getService = _serviceService.TGetByID(id);
            return Ok(getService);
        }
    }
}
