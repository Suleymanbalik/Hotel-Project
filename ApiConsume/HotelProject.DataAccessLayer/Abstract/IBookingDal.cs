using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        void BookingStatusChangeApproved(int id);

        void BookingStatusChangeCancel(int id);
        void BookingStatusChangeDelay(int id);

        //This part Willg get the number of booking to View
        int GetBookingCount();

        // This Part will show us last six bookings list
        List<Booking> GetLastSixBookingItemsList();

    }
}
