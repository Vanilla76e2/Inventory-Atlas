using Inventory_Atlas.Infrastructure.Entities.Technics.Components;
using Inventory_Atlas.Infrastructure.Repository.Audit;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Repository.Consumables;
using Inventory_Atlas.Infrastructure.Repository.Dictionaries;
using Inventory_Atlas.Infrastructure.Repository.Documents;
using Inventory_Atlas.Infrastructure.Repository.Employees;
using Inventory_Atlas.Infrastructure.Repository.Inventory;
using Inventory_Atlas.Infrastructure.Repository.Technics;
using Inventory_Atlas.Infrastructure.Repository.Technics.Components;
using Inventory_Atlas.Infrastructure.Repository.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory_Atlas.Infrastructure.Repository
{
    /// <summary>
    /// Класс для конфигурации и регистрации репозиториев в контейнере зависимостей.
    /// </summary>
    public static class RepositoryConfiguration
    {
        /// <summary>
        /// Регистрирует репозитории и сервис Unit of Work в контейнере внедрения зависимостей.
        /// </summary>
        /// <remarks>
        /// Этот метод добавляет службы с областью действия (scoped) для различных репозиториев, включая
        /// обобщённые репозитории, специализированные репозитории для отдельных доменов (например, аудит, расходные материалы,
        /// справочники, документы, сотрудники, инвентарь, техника и пользователи), а также реализацию паттерна Unit of Work.
        /// Предназначен для упрощения регистрации сервисов доступа к данным в приложении.
        /// </remarks>
        /// <param name="services">Экземпляр <see cref="IServiceCollection"/>, в который будут добавлены сервисы.</param>
        /// <returns>Обновлённый экземпляр <see cref="IServiceCollection"/>.</returns>

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Общий репозиторий (Generic)
            services.AddScoped(typeof(IDatabaseRepository<>), typeof(DatabaseRepository<>));

            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Специализированные репозитории
            services.AddScoped<ILogEntryRepository, LogEntryRepository>();
            services.AddScoped<IUserSessionRepository, UserSessionRepository>();
            // Consumables
            services.AddScoped<IPrinterRepository, PrinterRepository>();
            // Dictionaries
            services.AddScoped<ICpuRepository, CpuRepository>();
            services.AddScoped<ICustomFieldDefenitionRepository, CustomFieldDefenitionRepository>();
            services.AddScoped<ICustomFieldValueRepository, CustomFieldValueRepository>();
            services.AddScoped<IFurnitureMaterialRepository, FurnitureMaterialRepository>();
            services.AddScoped<IFurnitureTypeRepository, FurnitureTypeRepository>();
            services.AddScoped<IGpuRepository, GpuRepository>();
            services.AddScoped<IInventoryCategoryRepository, InventoryCategoryRepository>();
            services.AddScoped<IIpAddressRepository, IpAddressRepository>();
            services.AddScoped<IMoBoRepository, IMoBoRepository>();
            // Documents
            services.AddScoped<ICheckoutDocumentRepository, CheckoutDocumentRepository>();
            services.AddScoped<ICheckoutDocumentItemRepository, CheckoutDocumentItemRepository>();
            services.AddScoped<IReturnDocumentRepository, ReturnDocumentRepository>();
            services.AddScoped<IReturnDocumentItemRepository, ReturnDocumentItemRepository>();
            services.AddScoped<ITransferDocumentRepository, TransferDocumentRepository>();
            services.AddScoped<ITransferDocumentItemRepository, TransferDocumentItemRepository>();
            services.AddScoped<IWriteOffDocumentRepository, WriteOffDocumentRepository>();
            services.AddScoped<IWriteOffDocumentItemRepository, WriteOffDocumentItemRepository>();
            // Employees
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IMateriallyResponsibleRepository, MateriallyResponsibleRepository>();
            // Inventory
            services.AddScoped<IFurnitureRepository, FurnitureRepository>();
            services.AddScoped<IFurnitureMaterialAssignmentRepository, FurnitureMaterialAssignmentRepository>();
            services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
            services.AddScoped<IInventoryPhotoRepository, InventoryPhotoRepository>();
            services.AddScoped<IWorkplaceRepository, WorkplaceRepository>();
            services.AddScoped<IWorkplaceEquipmentRepository, WorkplaceEquipmentRepository>();
            // Components
            services.AddScoped<IComputerComponentRepository<CpuComponent>, ComputerComponentRepository<CpuComponent>>();
            services.AddScoped<IComputerComponentRepository<GpuComponent>, ComputerComponentRepository<GpuComponent>>();
            services.AddScoped<IComputerComponentRepository<MoBoComponent>, ComputerComponentRepository<MoBoComponent>>();
            services.AddScoped<IComputerComponentRepository<NetworkComponent>, ComputerComponentRepository<NetworkComponent>>();
            services.AddScoped<IComputerComponentRepository<OtherComponent>, ComputerComponentRepository<OtherComponent>>();
            services.AddScoped<IComputerComponentRepository<PsuComponent>, ComputerComponentRepository<PsuComponent>>();
            services.AddScoped<IComputerComponentRepository<RamComponent>, ComputerComponentRepository<RamComponent>>();
            services.AddScoped<IComputerComponentRepository<SoundComponent>, ComputerComponentRepository<SoundComponent>>();
            services.AddScoped<IComputerComponentRepository<StorageComponent>, ComputerComponentRepository<StorageComponent>>();
            // Technics
            services.AddScoped<IComputerRepository, ComputerRepository>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<ILaptopRepository, LaptopRepository>();
            services.AddScoped<IMaintenanceLogRepository, MaintenanceLogRepository>();
            services.AddScoped<IMonitorRepository, MonitorRepository>();
            services.AddScoped<INetworkDeviceRepository, NetworkDeviceRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<IPrinterRepository, PrinterRepository>();
            services.AddScoped<IScannerRepository, ScannerRepository>();
            services.AddScoped<ISoftwareRepository, SoftwareRepository>();
            services.AddScoped<ITabletRepository, TabletRepository>();
            services.AddScoped<IUPSRepository, UPSRepository>();
            // Users
            services.AddScoped<IFavouriteRepository, FavouriteRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();

            return services;
        }
    }
}
