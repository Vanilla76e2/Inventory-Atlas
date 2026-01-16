using Audit.Core;
using Inventory_Atlas.Application.Services.DatabaseServices.Audit;
using Inventory_Atlas.Application.Services.DatabaseServices.Users;
using Inventory_Atlas.Infrastructure.Auditor.Service;
using Inventory_Atlas.Infrastructure.Services.Auth;
using Inventory_Atlas.Infrastructure.Services.JwtKeyProvider;
using Inventory_Atlas.Infrastructure.Services.PasswordHasher;
using Inventory_Atlas.Infrastructure.Services.PermissionService;
using Inventory_Atlas.Infrastructure.Services.TokenService;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory_Atlas.Infrastructure
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
            //services.AddScoped<Auditor.Scope.IAuditScope, Auditor.Scope.AuditScope>();
            services.AddSingleton<IAuditService, AuditService>();

            // CRUD services
            // Audit
            services.AddScoped<IUserSessionService, UserSessionService>();
            services.AddScoped<IUserProfileService, UserProfileService>();

            return services;
        }
    }
}
