using Microsoft.EntityFrameworkCore;
using sportlife.Models;

namespace sportlife.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

       public DbSet<MemberShip> Memberships {get; set;}

        public DbSet<Client> Clients {get; set;}
    }
}