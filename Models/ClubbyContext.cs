using Microsoft.EntityFrameworkCore;

namespace Clubby.Models
{
    public class ClubbyContext : DbContext
    {
        public ClubbyContext(DbContextOptions<ClubbyContext> options)
            : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInClub> UserInClub { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasKey(x => x.ID);
            modelBuilder.Entity<Club>().HasKey(x => x.ID);
            modelBuilder.Entity<Event>().HasKey(x => x.ID);
            modelBuilder.Entity<User>().HasKey(x => x.ID);
            modelBuilder.Entity<UserInClub>().HasNoKey();
            modelBuilder.Entity<Admin>().HasNoKey();
        }
    }
}