using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var subscribeList = _subscribeService.TGetList();
            return Ok(subscribeList);
        }
        [HttpPost]
        public IActionResult AddSubscribe(Subscribe  subscribe)
        {
            _subscribeService.TInsert(subscribe);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubscribe(int id)
        {
            var deleteSubscribe = _subscribeService.TGetByID(id);
            _subscribeService.TDelete(deleteSubscribe);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe subscribe)
        {
            _subscribeService.TUpdate(subscribe);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetSubscribe(int id)
        {
            var getSubscribe = _subscribeService.TGetByID(id);
            return Ok(getSubscribe);
        }
    }
}
