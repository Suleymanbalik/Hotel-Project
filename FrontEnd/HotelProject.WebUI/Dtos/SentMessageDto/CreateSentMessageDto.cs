namespace HotelProject.WebUI.Dtos.SentMessageDto
{
    public class CreateSentMessageDto
    {
        public string SentMessageReceiverName { get; set; }
        public string SentMessageReceiverMail { get; set; }
        public string SentMessageSenderName { get; set; }
        public string SentMessageSenderMail { get; set; }
        public string SentMessageSubject { get; set; }
        public string SentMessageContent { get; set; }
        public DateTime SentMessageDate { get; set; }
    }
}
