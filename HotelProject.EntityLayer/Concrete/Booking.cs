﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Booking
    {
        public int BookingID { get; set; }
        public string BookingFullName { get; set; }
        public string BookingMail { get; set; }
        public DateTime BookingCheckIn { get; set; }
        public DateTime BookingCheckOut { get; set; }
        public string BookingAdultCount { get; set; }
        public string BookingChildCount { get; set; }
        public string BookingRoomCount { get; set; }
        public string BookingSpecialRequest{ get; set; }
        public string BookingDescription{ get; set; }
        public string BookingStatus{ get; set; }
    }
}
