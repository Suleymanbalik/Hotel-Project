using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentMessageController : ControllerBase
    {
        private readonly ISentMessageService _sentMessageService;

        public SentMessageController(ISentMessageService sentMessageService)
        {
            _sentMessageService = sentMessageService;
        }

        [HttpGet]
        public IActionResult SentMessageList()
        {
            var sentMessagelist = _sentMessageService.TGetList();
            return Ok(sentMessagelist);
        }

        [HttpPost]
        public IActionResult AddSentMessage(SentMessage sentMessage)
        {
            _sentMessageService.TInsert(sentMessage);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSentMessage(int id)
        {
            var deleteSentMessage = _sentMessageService.TGetByID(id);
            _sentMessageService.TDelete(deleteSentMessage);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateSentMessage(SentMessage sentMessage)
        {
            _sentMessageService.TUpdate(sentMessage);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var getSentMessage = _sentMessageService.TGetByID(id);
            return Ok(getSentMessage);
        }

        [HttpGet("GetSentMessagesCount")]
        public IActionResult GetSentMessagesCount()
        {
            return Ok(_sentMessageService.TGetSentMessagesCount());
        }
    }
}
