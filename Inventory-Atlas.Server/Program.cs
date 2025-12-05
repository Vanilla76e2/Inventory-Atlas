using Audit.Core;
using Inventory_Atlas.Application;
using Inventory_Atlas.Application.Services.JwtKeyProvider;
using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Repository;
using Inventory_Atlas.Infrastructure.Services.DbInstaller;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace Inventory_Atlas.Server
{ 
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            #region build

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            RegisterDatabase(builder);

            // Нужно будет сделать services.AddExceptionHandler();

            RegisterProject(builder);

            AuthConfig(builder);

            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Введите JWT токен: Bearer {token}",
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
    {
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
                        Reference = new Microsoft.OpenApi.Models.OpenApiReference {
                            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }});
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
        /// Регистрирует базу данных.
        /// </summary>
        private static void RegisterDatabase(WebApplicationBuilder builder)
        {
            var services = builder.Services;

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("InventoryAtlasDatabase"));
            });

            Audit.Core.Configuration.Setup()
                .UseEntityFramework(x => x
                .AuditTypeMapper(t => typeof(AuditLog))
                .AuditEntityAction<AuditLog>((ev, entry, audit) =>
                {
                    audit.ActionDate = DateTime.UtcNow;

                    audit.Details = JsonConvert.SerializeObject(new
                    {
                        EventType = ev.EventType,
                        ev.StartDate,
                        ev.EndDate,
                        ev.Duration,
                        AuditContext.SessionToken,
                        AuditContext.ActionType,
                        EntryFrameworkEvent = entry
                    });
                }));
        }

        /// <summary>
        /// Регистрация сервисов в DI.
        /// </summary>
        private static void RegisterProject(WebApplicationBuilder builder)
        {
            var services = builder.Services;

            services.AddRepositories();
            services.AddAutoMapper(typeof(AssemblyMarker));
            services.AddApplicationServices();
            // Нужно будет сделать services.AddHealthChecks
        }

        /// <summary>
        /// Настройки JWT авторизации и аутентификации.
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
