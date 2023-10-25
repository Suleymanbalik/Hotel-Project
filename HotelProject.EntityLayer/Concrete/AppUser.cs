using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string AppUserFirstName { get; set; }
        public string AppUserLastName { get; set; }
        public string? AppUserCity { get; set; }
        public string? AppUserImage { get; set; }
        public string? AppUserCountry { get; set; }
        public string? AppUserGender { get; set; }
        public string?  AppUserWorkUnit { get; set; }
        public int WorkLocationID { get; set; }
        public WorkLocation WorkLocation { get; set; }

    }
}
