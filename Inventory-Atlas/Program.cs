using Inventory_Atlas.Application;
using Inventory_Atlas.Application.Services.Audit;
using Inventory_Atlas.Application.Services.AuthMiddleware;
using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Repository;
using Inventory_Atlas.Infrastructure.Services.DbInstaller;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Atlas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("InventoryAtlasDatabase"));
            });

            // Нужно будет сделать services.AddExceptionHandler();

            RegisterProject(builder.Services);

            var app = builder.Build();

            // DB initialization
            using var scope = app.Services.CreateScope();
            DbInitializer.InstallOrUpdateDatabase(scope.ServiceProvider);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<AuthMiddleware>();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void RegisterProject(IServiceCollection services)
        {
            services.AddRepositories();
            services.AddAutoMapper(typeof(AssemblyMarker));
            services.AddApplicationServices();
            // Нужно будет сделать services.AddHeaыlthChecks
        }
    }
}
