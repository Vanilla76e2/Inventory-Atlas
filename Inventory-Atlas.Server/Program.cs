using Audit.Core;
using Inventory_Atlas.Application;
using Inventory_Atlas.Application.Services.JwtKeyProvider;
using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Repository;
using Inventory_Atlas.Infrastructure.Services.DbInstaller;
using Inventory_Atlas.Server.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json;

namespace Inventory_Atlas.Server
{ 
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region build
            builder.Logging.AddConsole();
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            RegisterDatabase(builder);

            // Надо будет добавить services.AddExceptionHandler();

            RegisterProject(builder);

            AuthConfig(builder);

            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Введите JWT токен. Пример: Bearer {token}"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            builder.Services.AddScoped<IAuthorizationHandler, AdminRequirementHandler>();
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                {
                    policy.Requirements.Add(new AdminRequirement());
                });
            });

            #endregion

            //=====================================================================================//

            var app = builder.Build();

            #region app

            // DB initialization
            using (var scope = app.Services.CreateScope())
            {
                await DbInitializer.InstallOrUpdateDatabase(scope.ServiceProvider);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();

            #endregion
        }

        /// <summary>
        /// Регистрация базы данных.
        /// </summary>
        private static void RegisterDatabase(WebApplicationBuilder builder)
        {
            var services = builder.Services;

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("InventoryAtlasDatabase"));
            });

            services.AddScoped<IAuditScopeFactory, AuditScopeFactory>();

        }

        /// <summary>
        /// Регистрация сервисов проекта в DI-контейнере.
        /// </summary>
        private static void RegisterProject(WebApplicationBuilder builder)
        {
            var services = builder.Services;

            services.AddRepositories();
            services.AddAutoMapper(typeof(AssemblyMarker));
            services.AddApplicationServices();
            // Нужно будет добавить services.AddHealthChecks
        }

        /// <summary>
        /// Настройка JWT-аутентификации и авторизации.
        /// </summary>
        private static void AuthConfig(WebApplicationBuilder builder)
        {
            var services = builder.Services;

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var keyProvider = context.HttpContext.RequestServices.GetRequiredService<IJwtKeyProvider>();
                        var key = Encoding.UTF8.GetBytes(keyProvider.GetKey());
                        context.Options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(key);
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddAuthorization();
        }
    }
}
