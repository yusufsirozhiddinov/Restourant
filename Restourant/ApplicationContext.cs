using Microsoft.EntityFrameworkCore;
using Restourant.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restourant
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;userid=root;password=1234;database=foods;", new MySqlServerVersion(new Version(5, 7, 36)));
        }
        public DbSet<Dishes> Dishes { get; set; }
        public DbSet<Chose_Dish> Chose_Dish { get; set; }
    }
}
