using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IStaffService : IGenericService<Staff>
    {
        // This Gives Number of Staffs - Personel Sayısı
        int TGetStaffCount();

        // This gives last four staffs as a list- Son 4 personeli liste olarak getirir.
        List<Staff> TGetLastFourStaffsList();
    }
}
