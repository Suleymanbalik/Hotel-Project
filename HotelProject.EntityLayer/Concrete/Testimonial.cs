using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Testimonial
    {
        public int TestimonialID { get; set; }
        public string TestimonialFullName { get; set; }
        public string TestimonialTitle { get; set; }
        public string TestimonialDescripton { get; set; }
        public string TestimonialImage { get; set; }
    }
}
