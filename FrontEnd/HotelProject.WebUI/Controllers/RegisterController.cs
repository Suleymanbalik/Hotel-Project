using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.RegisterDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace HotelProject.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {           
            return View();
        }

       // This part put the propsfrom CreateNewUSerDto in to AppUser Class
        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto createNewUserDto)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var appUser = new AppUser() // This brings Props from AppUser-Class
            {
                AppUserFirstName = createNewUserDto.RegisterFirstName,
                AppUserLastName = createNewUserDto.RegisterLastName,
                Email = createNewUserDto.RegisterMail,
                UserName = createNewUserDto.RegisterUserName,

            };
            
            var result = await _userManager.CreateAsync(appUser,createNewUserDto.RegisterPassword);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
