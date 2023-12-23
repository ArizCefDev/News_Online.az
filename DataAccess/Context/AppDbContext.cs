using DataAccess.Entity;
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
            optionsBuilder.UseSqlServer("Server=WIN-VD08C7OPT8H\\SQLEXPRESS; Database=NewsOnlineDB2; integrated security=true;");
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<New> News { get; set; }

    }
}
