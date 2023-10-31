using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet("UserListWithWorkLocation")] // This part only for listing Users
        public IActionResult UserListWithWorkLocation()
        {
            var appUserlist = _appUserService.TUserListWithWorkLocation();
            return Ok(appUserlist);
        }


        [HttpGet("UserListWithWorkLocation2")]
        public IActionResult UserListWithWorkLocation2()
        {
            Context context = new Context();

            var values = context.Users.Include(m => m.WorkLocation).Select(n => new AppUserWorkLocationViewModel
            {

                AppUserFirstName = n.AppUserFirstName,
                AppUserLastName = n.AppUserLastName,
                AppUserCity = n.AppUserCity,
                AppUserCountry = n.AppUserCountry,
                AppUserGender = n.AppUserGender,
                AppUserImage = n.AppUserImage,
                AppUserWorkUnit = n.AppUserWorkUnit,
                WorkLocationID = n.WorkLocationID,
                WorkLocationCity = n.WorkLocation.WorkLocationCity,
                WorkLocationName = n.WorkLocation.WorkLocationName  
                
                
            }).ToList();
            return Ok(values);
        }
    }
}
