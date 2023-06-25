using Data.Repository.Abstractions;
using Data.Repository.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class DataDependencies
    {
        public static void DataInjection(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<OnlineShoppingContext>(op =>
            {
                op.UseSqlServer("Server = DESKTOP-LO2ITE5\\SQLEXPRESS; Database = OnlineShoppingAPP; Integrated Security = true;");
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                   .AddEntityFrameworkStores<OnlineShoppingContext>()
                   .AddDefaultTokenProviders();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
