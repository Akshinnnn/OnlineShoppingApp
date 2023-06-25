using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace UI
{
    public static class UIDependencies
    {
        public static void PresentationInjection(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UI", Version = "v1" });
            });
        }
    }
}
