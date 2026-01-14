using Inventory_Atlas.Application.Auditor.Service;
using Inventory_Atlas.Application.Services.Audit;
using Inventory_Atlas.Application.Services.Auditor;
using Inventory_Atlas.Application.Services.Auth;
using Inventory_Atlas.Application.Services.JwtKeyProvider;
using Inventory_Atlas.Application.Services.PasswordHasher;
using Inventory_Atlas.Application.Services.PermissionService;
using Inventory_Atlas.Application.Services.TokenService;
using Inventory_Atlas.Application.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory_Atlas.Application
{
    /// <summary>
    /// Класс конфигурации сервисов.
    /// </summary>
    public static class ServicesConfiguration
    {
        /// <summary>
        /// Заполняет сервисами коллекцию сервисов.
        /// </summary>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenGenerator, JwtTokenService>();
            services.AddSingleton<IJwtKeyProvider, FileJwtKeyProvider>();
            services.AddScoped<PasswordHashCreateResolver>();
            services.AddScoped<PasswordHashUpdateResolver>();
            services.AddHttpContextAccessor();
            services.AddSingleton<IAuditService, AuditService>();

            // CRUD services
            // Audit
            services.AddScoped<IUserSessionService, UserSessionService>();
            services.AddScoped<IUserProfileService, UserProfileService>();

            return services;
        }
    }
}
