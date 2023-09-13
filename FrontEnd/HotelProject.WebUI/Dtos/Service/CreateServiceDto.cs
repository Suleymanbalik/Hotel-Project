using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.Service
{
    public class CreateServiceDto
    {

        // We do not need Id for this part
        [Required(ErrorMessage ="Enter link for Service Icon!")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Enter Title!")]
        [StringLength(100,ErrorMessage ="Max 100 characters!")]
        public string ServiceTitle { get; set; }

        [Required(ErrorMessage = "Enter Description!")]
        public string ServiceDescription { get; set; }
    }
}
