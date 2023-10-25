namespace HotelProject.WebUI.Dtos.SentMessageDto
{
    public class ResultSentMessageDto
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
