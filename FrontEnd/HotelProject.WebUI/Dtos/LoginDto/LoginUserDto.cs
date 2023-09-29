using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage ="Please Enter User Name!")]
        public string LoginUserName { get; set; }

        [Required(ErrorMessage = "Please Enter Passord!")]
        public string LoginPassword { get; set; }
    }
}
