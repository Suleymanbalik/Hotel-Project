namespace HotelProject.WebApi.Models
{
    public class AppUserWorkLocationViewModel
    {
        public string AppUserFirstName { get; set; }
        public string AppUserLastName { get; set; }
        public string? AppUserCity { get; set; }
        public string? AppUserImage { get; set; }
        public string? AppUserCountry { get; set; }
        public string? AppUserGender { get; set; }
        public string? AppUserWorkUnit { get; set; }
        public string? WorkLocationName { get; set; }
        public string? WorkLocationCity { get; set; }
        public int WorkLocationID { get; set; }
    }
}
