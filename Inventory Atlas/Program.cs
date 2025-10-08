using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Repository.UsersProfiles;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Inventory_Atlas.Infrastructure.Services.DbInstaller;

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

            RegisterInfrastructureServices(builder.Services);

            var app = builder.Build();

            DbInitializer.InstallOrUpdateDatabase(app.Services);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void RegisterInfrastructureServices(IServiceCollection services)
        {
            services.AddScoped<IDatabaseContextProvider, DatabaseContextProvider>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsersProfilesRepository, UsersProfilesRepository>();
            services.AddScoped(typeof(IDatabaseRepository<>), typeof(DatabaseRepository<>));

            // Сервисы инфраструктуры добавлять сюда
        }
    }
}
