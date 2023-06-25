using BusinessLogic.Logics.CategoryLogic;
using BusinessLogic.Logics.ProductLogic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class BLDependencies
    {
        public static void BLInjection(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BLDependencies));
            services.AddScoped(typeof(ProductLogic));
            services.AddScoped(typeof(CategoryLogic));
        }
    }
}
