using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    // Why we have to do this? Because Room Class Need To Interact to Generic For use Crud Methods
    public interface IRoomDal : IGenericDal<Room>
    {

        int GetRoomCount();
    }
}
