using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class OnlineShoppingContext : IdentityDbContext<IdentityUser>
    {
        public OnlineShoppingContext()
        {

        }
        public OnlineShoppingContext(DbContextOptions<OnlineShoppingContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server = DESKTOP-LO2ITE5\\SQLEXPRESS; Database = OnlineShoppingAPP; Integrated Security = true;");
        //    }
        //}

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
