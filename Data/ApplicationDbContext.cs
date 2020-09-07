using Microsoft.EntityFrameworkCore;
using sportlife.Models;

namespace sportlife.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<MemberShip> Memberships { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ServiceHistory> ServiceHistories { get; set; }
        public DbSet<VisitHistory> VisitHistories { get; set; }
    }
}