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
using Inventory_Atlas.Infrastructure.Repository.Dictionaries;
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
        }

        public IDatabaseRepository<LogEntry> LogEntry { get; }

        public IDatabaseRepository<UserSession> UserSession { get; }

        public IDatabaseRepository<PrinterCartridge> PrinterCartridge { get; }

        public IDatabaseRepository<CpuDictionary> CpuDictionary { get; }

        public IDatabaseRepository<FurnitureMaterial> FurnitureMaterial { get; }

        public IDatabaseRepository<FurnitureType> FurnitureType { get; }

        public IDatabaseRepository<InventoryCategory> InventoryCategory { get; }

        public IDatabaseRepository<IpDictionary> IpDictionary { get; }

        public IDatabaseRepository<MoBoDictionary> MoBoDictionary { get; }

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

        public IDatabaseRepository<GenericInventoryItem> GenericInventoryItem { get; }

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

        public IDatabaseRepository<GpuDictionary> GpuDictionary { get; }
    }
}
