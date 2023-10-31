using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {
        }

        public void BookingStatusChangeApproved(int id)
        {
            var context = new Context();
            var values = context.Bookings.Find(id);
            values.BookingStatus = "Approved!";
            context.SaveChanges();
        }

        public void BookingStatusChangeCancel(int id)
        {
            var context = new Context();
            var values = context.Bookings.Find(id);
            values.BookingStatus = "Cancelled!";
            context.SaveChanges();
        }

        public void BookingStatusChangeDelay(int id)
        {
            var context = new Context();
            var values = context.Bookings.Find(id);
            values.BookingStatus = "Delaying!!";
            context.SaveChanges();
        }

        // This part gets number of count for the DashboardWidgetPartial
        public int GetBookingCount()
        {
            var context = new Context();
            var value = context.Bookings.Count();
            return value;
        }

        // This part for listing last 6 bookings reserations
        public List<Booking> GetLastSixBookingItemsList()
        {
            var context = new Context();
            var values = context.Bookings.OrderByDescending(m => m.BookingID).Take(6).ToList();
            return values;

        }
    }
}
