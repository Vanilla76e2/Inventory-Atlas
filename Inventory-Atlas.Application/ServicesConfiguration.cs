using Inventory_Atlas.Application.Services.Audit;
using Inventory_Atlas.Application.Services.PermissionService;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory_Atlas.Application
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPermissionService, PermissionService>();

            // CRUD services
            // Audit
            services.AddScoped<IUserSessionService, UserSessionService>();
            services.AddScoped<ILogEntryService, LogEntryService>();

            return services;
        }
    }
}
