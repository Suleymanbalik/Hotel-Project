using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class SentMessage
    {
        public int SentMessageID { get; set; }
        public string SentMessageReceiverName { get; set; }
        public string SentMessageReceiverMail { get; set; }
        public string SentMessageSenderName { get; set; }
        public string SentMessageSenderMail { get; set; }      
        public string SentMessageSubject { get; set; }
        public string SentMessageContent { get; set; }      
        public DateTime SentMessageDate { get; set; }
    }
}
