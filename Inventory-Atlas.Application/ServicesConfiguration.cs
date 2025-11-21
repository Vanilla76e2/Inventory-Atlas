using Inventory_Atlas.Application.Services.Audit;
using Inventory_Atlas.Application.Services.Auth;
using Inventory_Atlas.Application.Services.PasswordHasher;
using Inventory_Atlas.Application.Services.PermissionService;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory_Atlas.Application
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IAuthService, AuthService>();


            // CRUD services
            // Audit
            services.AddScoped<IUserSessionService, UserSessionService>();
            services.AddScoped(typeof(ILogEntryService<>), typeof(LogEntryService<>));
            return services;
        }
    }
}
