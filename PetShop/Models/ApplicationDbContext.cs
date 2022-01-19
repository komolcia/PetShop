using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PetShop.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Spiecies> Species { get; set; }
        public DbSet<Buy> Buys { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}