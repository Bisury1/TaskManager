using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TaskManager.Application
{
    public static class DI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DI).Assembly);
            });
            return services;
        }
    }
}
