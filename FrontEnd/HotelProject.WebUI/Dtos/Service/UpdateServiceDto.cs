using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.Service
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "Enter link for Service Icon!")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Enter Title!")]
        [StringLength(100, ErrorMessage = "Max 100 characters!")]
        public string ServiceTitle { get; set; }

        [Required(ErrorMessage = "Enter Description!")]
        [StringLength(500,ErrorMessage ="Max 500 characters!")]
        public string ServiceDescription { get; set; }
    }
}
