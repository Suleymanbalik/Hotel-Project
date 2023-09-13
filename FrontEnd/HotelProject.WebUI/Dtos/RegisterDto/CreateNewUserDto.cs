using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="Must Add First Name!")]
        public string RegisterFirstName { get; set; }

        [Required(ErrorMessage = "Must Add Last Name!")]
        public string RegisterLastName { get; set; }

        [Required(ErrorMessage = "Must Add User Name!")]
        public string RegisterUserName { get; set; }

        [Required(ErrorMessage = "Must Add Mail!")]
        public string RegisterMail { get; set; }

        [Required(ErrorMessage = "Must Add Password!")]
        public string RegisterPassword { get; set; }

        [Required(ErrorMessage = "Must Add Confirm Password!")]
        [Compare("RegisterPassword",ErrorMessage ="Password does not match!")]
        public string RegisterConfirmPassword { get; set; }
    }
}
