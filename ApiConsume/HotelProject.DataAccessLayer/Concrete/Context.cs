using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-FJEHAAO\\SQLEXPRESS;initial catalog=HotelDbApi;integrated security=true");
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<About> Abouts { get; set; }      
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }    
        public DbSet<Contact> Contacts { get; set; }    
        public DbSet<SentMessage> SentMessages { get; set; }    
        public DbSet<MessageCategory> MessageCategories { get; set; }
        public DbSet<WorkLocation> WorkLocations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<Contact>().Property()
            // one-to-many relationship between Contact and MessageCategory
            modelBuilder.Entity<MessageCategory>()
        .HasMany(mc => mc.Contacts)       // One MessageCategory has many Contacts
        .WithOne(c => c.MessageCategory)  // Each Contact belongs to one MessageCategory
        .HasForeignKey(c => c.MessageCategoryID);
        }
    }

    
}
