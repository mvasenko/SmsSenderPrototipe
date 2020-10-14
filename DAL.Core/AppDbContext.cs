using DAL.Core.Configurations;
using DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Core
{
    public class AppDbContext : DbContext
    {
        public DbSet<Invitation> Invitations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InvitationConfiguration());
        }
    }
}
