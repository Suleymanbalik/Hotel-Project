using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface ISentMessageDal : IGenericDal<SentMessage>
    {
        // this metot will count messages which have sent by admin
        public int GetSentMessagesCount();
    }
}
