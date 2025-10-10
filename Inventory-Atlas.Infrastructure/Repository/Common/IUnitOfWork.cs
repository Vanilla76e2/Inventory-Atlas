using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Entities.Сonsumables;
using Inventory_Atlas.Infrastructure.Entities.Dictionaries;
using Inventory_Atlas.Infrastructure.Entities.Documents;
using Inventory_Atlas.Infrastructure.Entities.Employees;
using Inventory_Atlas.Infrastructure.Entities.Inventory;
using Inventory_Atlas.Infrastructure.Entities.References;
using Inventory_Atlas.Infrastructure.Entities.Services;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Entities.Users;

namespace Inventory_Atlas.Infrastructure.Repository.Common
{
    public interface IUnitOfWork
    {
        // Audit
        IDatabaseRepository<LogEntry> LogEntry { get; }
        IDatabaseRepository<UserSession> UserSession { get; }

        // Consumables
        IDatabaseRepository<PrinterCartridge> PrinterCartridge { get; }

        // Dictionaries
        IDatabaseRepository<CpuDictionary> CpuDictionary { get; }
        IDatabaseRepository<FurnitureMaterial> FurnitureMaterial { get; }
        IDatabaseRepository<FurnitureType> FurnitureType { get; }
        IDatabaseRepository<GpuDictionary> GpuDictionary { get; }
        IDatabaseRepository<InventoryCategory> InventoryCategory { get; }
        IDatabaseRepository<IpDictionary> IpDictionary { get; }
        IDatabaseRepository<MoBoDictionary> MoBoDictionary { get; }

        // Documents
        IDatabaseRepository<CheckoutDocument> CheckoutDocument { get; }
        IDatabaseRepository<CheckoutDocumentItem> CheckoutDocumentItem { get; }
        IDatabaseRepository<ReturnDocument> ReturnDocument { get; }
        IDatabaseRepository<ReturnDocumentItem> ReturnDocumentItem { get; }
        IDatabaseRepository<TransferDocument> TransferDocument { get; }
        IDatabaseRepository<TransferDocumentItem> TransferDocumentItem { get; }
        IDatabaseRepository<WriteOffDocument> WriteOffDocument { get; }
        IDatabaseRepository<WriteOffDocumentItem> WriteOffDocumentItem { get; }

        // Employees
        IDatabaseRepository<Department> Department { get; }
        IDatabaseRepository<Employee> Employee { get; }
        IDatabaseRepository<MateriallyResponsible> MateriallyResponsible { get; }

        // Inventory
        IDatabaseRepository<Workplace> Workplace { get; }
        IDatabaseRepository<Furniture> FurnitureRepository { get; }
        IDatabaseRepository<GenericInventoryItem> GenericInventoryItem { get; }
        IDatabaseRepository<InventoryItem> InventoryItem { get; }
        IDatabaseRepository<InventoryPhoto> InventoryPhoto { get; }

        // Technics
        IDatabaseRepository<Computer> Computer { get; }
        IDatabaseRepository<Equipment> Equipment { get; }
        IDatabaseRepository<Laptop> Laptop { get; }
        IDatabaseRepository<MaintenanceLog> MaintenanceLog { get; }
        IDatabaseRepository<Entities.Technics.Monitor> Monitor { get; }
        IDatabaseRepository<NetworkDevice> NetworkDevice { get; }
        IDatabaseRepository<Phone> Phone { get; }
        IDatabaseRepository<Printer> Printer { get; }
        IDatabaseRepository<Scanner> Scanner { get; }
        IDatabaseRepository<Software> Software { get; }
        IDatabaseRepository<Tablet> Tables { get; }
        IDatabaseRepository<UPS> UPS { get; }

        // Users
        IDatabaseRepository<Favourite> Favourite { get; }
        IDatabaseRepository<Role> Role { get; }
        IDatabaseRepository<UserProfile> UserProfile { get; }
    }
}
