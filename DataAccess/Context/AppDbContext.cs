using DataAccess.Entity;
using Helpers.CookieCrypto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WIN-VD08C7OPT8H\\SQLEXPRESS; Database=NewsOnlineDBTS11; integrated security=true;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    ID = 1,
                    Name = "Admin",
                });

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    ID = 2,
                    Name = "User",
                }
                );

            var salt = Crypto.GenerateSalt();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    ID = 1,
                    UserName = "Admin",
                    Salt = salt,
                    PasswordHash = Crypto.GenerateSHA256Hash("Admin1234", salt),
                    RoleId = 1,
                }
                );
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
