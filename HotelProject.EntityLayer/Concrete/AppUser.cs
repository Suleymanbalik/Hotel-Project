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
    }
}
