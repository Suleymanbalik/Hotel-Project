using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class UpdateRoomDto
    {    
            public int RoomID { get; set; }

            [Required(ErrorMessage = "Please Enter Room Number!")]
            public string RoomNumber { get; set; }
            [Required(ErrorMessage = "Please Enter Room Image!")]
            public string RoomCoverImage { get; set; }
            [Required(ErrorMessage = "Please Enter Price!")]
            public int RoomPrice { get; set; }
            [Required(ErrorMessage = "Please Enter Room Title!")]
            [StringLength(100,ErrorMessage ="Max 100 characters!")]
            public string RoomTitle { get; set; }
            [Required(ErrorMessage = "Please Enter Number Of Bed!")]
            public string RoomBedCount { get; set; }
            [Required(ErrorMessage = "Please Enter Number Of Bath!")]
            public string RoomBathCount { get; set; }
            [Required(ErrorMessage = "Please Enter Room Wifi Information!")]
            public string RoomWifi { get; set; }
            [Required(ErrorMessage = "Please Enter Room Description!")]
            public string RoomDescription { get; set; }
        
    }
}
