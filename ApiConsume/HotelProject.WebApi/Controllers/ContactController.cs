using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var contactlist = _contactService.TGetList();
            return Ok(contactlist);
        }
        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            contact.ContactDate = Convert.ToDateTime(DateTime.Now.ToString());
            _contactService.TInsert(contact);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletContact(int id)
        {
            var deleteContact = _contactService.TGetByID(id);
            _contactService.TDelete(deleteContact);
            return Ok();
        }


        [HttpPut]
        public IActionResult UpdateContact(Contact contact)
        {
            _contactService.TUpdate(contact);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var getContact = _contactService.TGetByID(id);
            return Ok(getContact);
        }

        //this part shows how much messsges in our inbox
        [HttpGet("GetContactCount")]
        public IActionResult GetContactCount()
        {
            return Ok(_contactService.TGetContactCount());
        }
    }
}
