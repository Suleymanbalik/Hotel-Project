using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        public EfStaffDal(Context context) : base(context)
        {

        }

        public List<Staff> GetLastFourStaffsList()
        {
            using var context = new Context();
            //var values = context.Staffs.Skip(Math.Max(0, context.Staffs.Count()-4)).ToList();
            var values = context.Staffs.OrderByDescending(m => m.StaffID).Take(4).ToList();
            return values;
        }

        public int GetStaffCount()
        {
            using var context  = new Context();

            var value = context.Staffs.Count();
            return value;
        }
    }
}
