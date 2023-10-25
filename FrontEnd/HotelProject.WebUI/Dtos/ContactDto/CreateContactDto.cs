namespace HotelProject.WebUI.Dtos.ContactDto
{
    public class CreateContactDto
    {
       
        public string ContactName { get; set; }
        public string ContactMail { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
        public DateTime ContactDate { get; set; }

        // The prop below I have added after I created MessageCategory entity and ı get this from MessageCategory Entity
        // Because I need to use this id for dropdown to get Categories from controller
        public int MessageCategoryID { get; set; }

        
    }
}
