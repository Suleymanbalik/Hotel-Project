using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.SettingsUserFirstName = user.AppUserFirstName;
            model.SettingsUserLastName = user.AppUserLastName;
            model.SettingsUserEmail = user.Email;
            model.SettingsUserName = user.UserName;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            if (userEditViewModel.SettingsUserPassword == userEditViewModel.SettingsUserConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.AppUserFirstName = userEditViewModel.SettingsUserFirstName;
                user.AppUserLastName = userEditViewModel.SettingsUserLastName;
                user.Email = userEditViewModel.SettingsUserEmail;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.SettingsUserPassword);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

    }
}
