using TaskManager.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace TaskManager.Persistence
{
    public static class DI
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["connection"];
            services.AddDbContext<NotesDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<INotesDbContext>(provider => provider.GetService<NotesDbContext>());
            return services;
        }
        public static IServiceCollection AddPersistenceIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DefaultConnection"];
            services.AddDbContext<AppUserDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddIdentityCore<AppUser>()
                .AddEntityFrameworkStores<AppUserDbContext>();
            return services;
        }
    }
}
