using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class SentMessageManager :ISentMessageService
    {
        private readonly ISentMessageDal _sentMessageDal;

        public SentMessageManager(ISentMessageDal sentMessageDal)
        {
            _sentMessageDal = sentMessageDal;
        }

        public void TDelete(SentMessage t)
        {
            _sentMessageDal.Delete(t);
        }

        public SentMessage TGetByID(int id)
        {
            return _sentMessageDal.GetByID(id);
        }

        public List<SentMessage> TGetList()
        {
            return _sentMessageDal.GetList();
        }

        public int TGetSentMessagesCount()
        {
            return _sentMessageDal.GetSentMessagesCount();
        }

        public void TInsert(SentMessage t)
        {
            _sentMessageDal.Insert(t);
        }

        public void TUpdate(SentMessage t)
        {
            _sentMessageDal.Update(t);
        }
    }
}
