namespace HotelProject.WebUI.Dtos.AppUserDto
{
    public class ResultAppUserDto
    {
        public string AppUserFirstName { get; set; }
        public string AppUserLastName { get; set; }
        public string? AppUserCity { get; set; }
        public string? AppUserImage { get; set; }
        public string? AppUserCountry { get; set; }
        public string? AppUserGender { get; set; }
        public string? AppUserWorkUnit { get; set; }
        public int WorkLocationID { get; set; }
    }
}
