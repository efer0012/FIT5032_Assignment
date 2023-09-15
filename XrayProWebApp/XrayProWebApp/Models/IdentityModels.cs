using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace XrayProWebApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        [Column("First_name")]
        public string FirstName { get; set; }

        [Column("Last_name")]
        public string LastName { get; set; }

        [Column("Gender")]
        public char Gender { get; set; }

        [Column("Dob")]
        public DateTime DateOfBirth { get; set; }

        [Column("Street_number")]
        public string StreetNumber { get; set; }

        [Column("Street")]
        public string Street { get; set; }

        [Column("Suburb")]
        public string Suburb { get; set; }

        [Column("State")]
        public string State { get; set; }

        [Column("Postcode")]
        public int Postcode { get; set; }

        [Column("PhoneNumber")]
        [StringLength(15)]
        [Phone]  // Uses built-in phone number validation
        public string PhoneNumber { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<XrayProWebApp.Models.Booking> Bookings { get; set; }

        public System.Data.Entity.DbSet<XrayProWebApp.Models.Room> Rooms { get; set; }
    }
}