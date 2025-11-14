using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Entities.Dictionaries;
using Inventory_Atlas.Infrastructure.Entities.Documents;
using Inventory_Atlas.Infrastructure.Entities.Employees;
using Inventory_Atlas.Infrastructure.Entities.Inventory;
using Inventory_Atlas.Infrastructure.Entities.References;
using Inventory_Atlas.Infrastructure.Entities.Services;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Entities.Users;
using Inventory_Atlas.Infrastructure.Entities.Сonsumables;
using Inventory_Atlas.Infrastructure.Repository.Audit;
using Inventory_Atlas.Infrastructure.Repository.Consumables;
using Inventory_Atlas.Infrastructure.Repository.Dictionaries;
using Inventory_Atlas.Infrastructure.Repository.Documents;
using Inventory_Atlas.Infrastructure.Repository.Employees;
using Inventory_Atlas.Infrastructure.Repository.Inventory;
using Inventory_Atlas.Infrastructure.Repository.Technics;
using Inventory_Atlas.Infrastructure.Repository.Users;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Inventory_Atlas.Infrastructure.Repository.Common
{
    /// <summary>
    /// Реализация Unit of Work для работы с репозиториями.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="UnitOfWork"/>.
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных.</param>
        /// <param name="loggerFactory">Фабрика логгеров.</param>
        public UnitOfWork(IDatabaseContextProvider contextProvider, ILoggerFactory loggerFactory)
        {
            // Задать значения вида
            LogEntry = new LogEntryRepository(contextProvider, loggerFactory.CreateLogger<LogEntryRepository>());
            UserSession = new UserSessionRepository(contextProvider, loggerFactory.CreateLogger<UserSessionRepository>());

            PrinterCartridge = new PrinterCartridgeRepository(contextProvider, loggerFactory.CreateLogger<PrinterCartridgeRepository>());

            CpuDictionary = new CpuRepository(contextProvider, loggerFactory.CreateLogger<CpuRepository>());
            GpuDictionary = new GpuRepository(contextProvider, loggerFactory.CreateLogger<GpuRepository>());
            MoBoDictionary = new MoBoRepository(contextProvider, loggerFactory.CreateLogger<MoBoRepository>());
            IpDictionary = new IpAddressRepository(contextProvider, loggerFactory.CreateLogger<IpAddressRepository>());
            FurnitureMaterial = new FurnitureMaterialRepository(contextProvider, loggerFactory.CreateLogger<FurnitureMaterialRepository>());
            FurnitureType = new FurnitureTypeRepository(contextProvider, loggerFactory.CreateLogger<FurnitureTypeRepository>());
            InventoryCategory = new InventoryCategoryRepository(contextProvider, loggerFactory.CreateLogger<InventoryCategoryRepository>());
            CustomFieldDefenition = new CustomFieldDefenitionRepository(contextProvider, loggerFactory.CreateLogger<CustomFieldDefenitionRepository>());
            CustomFieldValue = new CustomFieldValueRepository(contextProvider, loggerFactory.CreateLogger<CustomFieldValueRepository>());

            CheckoutDocument = new CheckoutDocumentRepository(contextProvider, loggerFactory.CreateLogger<CheckoutDocumentRepository>());
            CheckoutDocumentItem = new CheckoutDocumentItemRepository(contextProvider, loggerFactory.CreateLogger<CheckoutDocumentItemRepository>());
            ReturnDocument = new ReturnDocumentRepository(contextProvider, loggerFactory.CreateLogger<ReturnDocumentRepository>());
            ReturnDocumentItem = new ReturnDocumentItemRepository(contextProvider, loggerFactory.CreateLogger<ReturnDocumentItemRepository>());
            TransferDocument = new TransferDocumentRepository(contextProvider, loggerFactory.CreateLogger<TransferDocumentRepository>());
            TransferDocumentItem = new TransferDocumentItemRepository(contextProvider, loggerFactory.CreateLogger<TransferDocumentItemRepository>());
            WriteOffDocument = new WriteOffDocumentRepository(contextProvider, loggerFactory.CreateLogger<WriteOffDocumentRepository>());
            WriteOffDocumentItem = new WriteOffDocumentItemRepository(contextProvider, loggerFactory.CreateLogger<WriteOffDocumentItemRepository>());

            Department = new DepartmentRepository(contextProvider, loggerFactory.CreateLogger<DepartmentRepository>());
            Employee = new EmployeeRepository(contextProvider, loggerFactory.CreateLogger<EmployeeRepository>());
            MateriallyResponsible = new MateriallyResponsibleRepository(contextProvider, loggerFactory.CreateLogger<MateriallyResponsibleRepository>());
            Workplace = new WorkplaceRepository(contextProvider, loggerFactory.CreateLogger<WorkplaceRepository>());
            FurnitureRepository = new FurnitureRepository(contextProvider, loggerFactory.CreateLogger<FurnitureRepository>());
            InventoryItem = new InventoryItemRepository(contextProvider, loggerFactory.CreateLogger<InventoryItemRepository>());
            InventoryPhoto = new InventoryPhotoRepository(contextProvider, loggerFactory.CreateLogger<InventoryPhotoRepository>());

            Computer = new ComputerRepository(contextProvider, loggerFactory.CreateLogger<ComputerRepository>());
            Equipment = new EquipmentRepository(contextProvider, loggerFactory.CreateLogger<EquipmentRepository>());
            Laptop = new LaptopRepository(contextProvider, loggerFactory.CreateLogger<LaptopRepository>());
            MaintenanceLog = new MaintenanceLogRepository(contextProvider, loggerFactory.CreateLogger<MaintenanceLogRepository>());
            Monitor = new MonitorRepository(contextProvider, loggerFactory.CreateLogger<MonitorRepository>());
            NetworkDevice = new NetworkDeviceRepository(contextProvider, loggerFactory.CreateLogger<NetworkDeviceRepository>());
            Phone = new PhoneRepository(contextProvider, loggerFactory.CreateLogger<PhoneRepository>());
            Printer = new PrinterRepository(contextProvider, loggerFactory.CreateLogger<PrinterRepository>());
            Scanner = new ScannerRepository(contextProvider, loggerFactory.CreateLogger<ScannerRepository>());
            Software = new SoftwareRepository(contextProvider, loggerFactory.CreateLogger<SoftwareRepository>());
            Tables = new TabletRepository(contextProvider, loggerFactory.CreateLogger<TabletRepository>());
            UPS = new UPSRepository(contextProvider, loggerFactory.CreateLogger<UPSRepository>());

            Favourite = new FavouriteRepository(contextProvider, loggerFactory.CreateLogger<FavouriteRepository>());
            Role = new RoleRepository(contextProvider, loggerFactory.CreateLogger<RoleRepository>());
            UserProfile = new UserProfileRepository(contextProvider, loggerFactory.CreateLogger<UserProfileRepository>());
        }

        public IDatabaseRepository<LogEntry> LogEntry { get; }
        public IDatabaseRepository<UserSession> UserSession { get; }

        public IDatabaseRepository<PrinterCartridge> PrinterCartridge { get; }

        public IDatabaseRepository<CpuDictionary> CpuDictionary { get; }
        public IDatabaseRepository<FurnitureMaterial> FurnitureMaterial { get; }
        public IDatabaseRepository<FurnitureType> FurnitureType { get; }
        public IDatabaseRepository<InventoryCategory> InventoryCategory { get; }
        public IDatabaseRepository<IpDictionary> IpDictionary { get; }
        public IDatabaseRepository<GpuDictionary> GpuDictionary { get; }
        public IDatabaseRepository<MoBoDictionary> MoBoDictionary { get; }
        public IDatabaseRepository<CustomFieldDefenition> CustomFieldDefenition { get; }
        public IDatabaseRepository<CustomFieldValue> CustomFieldValue { get; }

        public IDatabaseRepository<CheckoutDocument> CheckoutDocument { get; }
        public IDatabaseRepository<CheckoutDocumentItem> CheckoutDocumentItem { get; }
        public IDatabaseRepository<ReturnDocument> ReturnDocument { get; }
        public IDatabaseRepository<ReturnDocumentItem> ReturnDocumentItem { get; }
        public IDatabaseRepository<TransferDocument> TransferDocument { get; }
        public IDatabaseRepository<TransferDocumentItem> TransferDocumentItem { get; }
        public IDatabaseRepository<WriteOffDocument> WriteOffDocument { get; }
        public IDatabaseRepository<WriteOffDocumentItem> WriteOffDocumentItem { get; }

        public IDatabaseRepository<Department> Department { get; }
        public IDatabaseRepository<Employee> Employee { get; }
        public IDatabaseRepository<MateriallyResponsible> MateriallyResponsible { get; }
        public IDatabaseRepository<Workplace> Workplace { get; }

        public IDatabaseRepository<Furniture> FurnitureRepository { get; }
        public IDatabaseRepository<InventoryItem> InventoryItem { get; }
        public IDatabaseRepository<InventoryPhoto> InventoryPhoto { get; }

        public IDatabaseRepository<Computer> Computer { get; }
        public IDatabaseRepository<Equipment> Equipment { get; }
        public IDatabaseRepository<Laptop> Laptop { get; }
        public IDatabaseRepository<MaintenanceLog> MaintenanceLog { get; }
        public IDatabaseRepository<Entities.Technics.Monitor> Monitor { get; }
        public IDatabaseRepository<NetworkDevice> NetworkDevice { get; }
        public IDatabaseRepository<Phone> Phone { get; }
        public IDatabaseRepository<Printer> Printer { get; }
        public IDatabaseRepository<Scanner> Scanner { get; }
        public IDatabaseRepository<Software> Software { get; }
        public IDatabaseRepository<Tablet> Tables { get; }
        public IDatabaseRepository<UPS> UPS { get; }

        public IDatabaseRepository<Favourite> Favourite { get; }
        public IDatabaseRepository<Role> Role { get; }
        public IDatabaseRepository<UserProfile> UserProfile { get; }

    }
}
