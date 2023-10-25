using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfSentMessageDal : GenericRepository<SentMessage>, ISentMessageDal
    {
        public EfSentMessageDal(Context context) : base(context)
        {

        }

        public int GetSentMessagesCount()
        {
            var context = new Context();
            return context.SentMessages.Count();
        }
    }
}
