using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class AddRoomDto
    {
        [Required(ErrorMessage ="Please Enter Room Number!")]
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Please Enter Price!")]
        public int RoomPrice { get; set; }
        [Required(ErrorMessage = "Please Enter Room Title!")]
        public string RoomTitle { get; set; }
        [Required(ErrorMessage = "Please Enter Number Of Bed!")]
        public string RoomBedCount { get; set; }
        [Required(ErrorMessage = "Please Enter Number Of Bath!")]
        public string RoomBathCount { get; set; }
        public string RoomWifi { get; set; }
        public string RoomDescription { get; set; }
    }
}
