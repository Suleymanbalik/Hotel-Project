using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IStaffDal : IGenericDal<Staff>
    {
        // This part Count Staffs for the DashBoradWidGets
        int GetStaffCount();

        // This part will provide last 4 staffs as list on Dashboard
        List<Staff> GetLastFourStaffsList();


    }
}
