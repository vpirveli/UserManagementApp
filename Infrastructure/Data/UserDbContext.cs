using Domain.Utilities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public partial class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("User");

            modelBuilder.Entity<UserProfile>()
                .ToTable("UserProfile");

            modelBuilder.Entity<User>().HasIndex(x=>x.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(x=>x.UserName).IsUnique();
            modelBuilder.Entity<UserProfile>().HasIndex(x => x.PersonalNumber).IsUnique();
            
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserProfile)
                .WithOne(up => up.User)
                .HasForeignKey<UserProfile>(up => up.Id);

            modelBuilder.Entity<User>().HasData(new User() { Id = 1, UserName = "admin", Password="password".ComputeMD5Hash(), Email ="email@email.com", IsActive = true});
            modelBuilder.Entity<UserProfile>().HasData(new UserProfile() { Id = 1, FirstName = "Admin", LastName="Adminashvili", PersonalNumber = "000000000000" });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
