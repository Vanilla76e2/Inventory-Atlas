using Inventory_Atlas.Infrastructure.Converters;
using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Entities.Dictionaries;
using Inventory_Atlas.Infrastructure.Entities.Documents;
using Inventory_Atlas.Infrastructure.Entities.Employees;
using Inventory_Atlas.Infrastructure.Entities.Inventory;
using Inventory_Atlas.Infrastructure.Entities.References;
using Inventory_Atlas.Infrastructure.Entities.Services;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Entities.Technics.Components;
using Inventory_Atlas.Infrastructure.Entities.Users;
using Inventory_Atlas.Infrastructure.Entities.Сonsumables;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Inventory_Atlas.Infrastructure.Data
{
    /// <summary>
    /// Контекст базы данных приложения Inventory Atlas.
    /// </summary>
    public partial class AppDbContext : DbContext
    {
        /// <summary>
        /// Конструктор контекста базы данных.
        /// </summary>
        /// <param name="options">Параметры конфигурации DbContext.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        // Audit
        public DbSet<LogEntry> LogEntries { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }

        // Documents
        public DbSet<CheckoutDocument> CheckoutDocuments { get; set; }
        public DbSet<CheckoutDocumentItem> CheckoutDocumentItems { get; set; }
        public DbSet<ReturnDocument> ReturnDocuments { get; set; }
        public DbSet<ReturnDocumentItem> ReturnDocumentItems { get; set; }
        public DbSet<TransferDocument> TransferDocuments { get; set; }
        public DbSet<TransferDocumentItem> TransferDocumentsItems { get; set; }
        public DbSet<WriteOffDocument> WriteOffDocuments { get; set; }
        public DbSet<WriteOffDocumentItem> writeOffDocumentItems { get; set; }

        // Employees
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<MateriallyResponsible> materiallyResponsibles { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }

        // Inventory
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<FurnitureMaterialAssignment> FurnitureMaterialAssignments { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }

        // Dictionaries
        public DbSet<IpDictionary> IpAudits { get; set; }
        public DbSet<CpuDictionary> CPUReferences { get; set; }
        public DbSet<GpuDictionary> GPUReferences { get; set; }
        public DbSet<MoBoDictionary> MoBoReferences { get; set; }
        public DbSet<CustomFieldDefenition> CustomFieldDefenitions { get; set; }
        public DbSet<CustomFieldValue> CustomFieldValues { get; set; }

        // Services
        public DbSet<FurnitureMaterial> FurnitureMaterials { get; set; }
        public DbSet<FurnitureType> FurnitureTypes { get; set; }
        public DbSet<InventoryCategory> InventoryCategories { get; set; }
        public DbSet<InventoryPhoto> InventoryPhotos { get; set; }

        // Technics
        public DbSet<Computer> Computers { get; set; }
        public DbSet<ComputerComponent> ComputerComponents { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<MaintenanceLog> MaintenanceLogs { get; set; }
        public DbSet<Entities.Technics.Monitor> Monitors { get; set; }
        public DbSet<NetworkDevice> NetworkDevices { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Printer> Printers { get; set; }
        public DbSet<Scanner> Scanners { get; set; }
        public DbSet<Software> Software { get; set; }
        public DbSet<Tablet> Tablets { get; set; }
        public DbSet<UPS> UPS { get; set; }
        public DbSet<WorkplaceEquipment> WorkplaceEquipment { get; set; }

        // Components
        public DbSet<CpuComponent> CPUComponents { get; set; }
        public DbSet<GpuComponent> GPUComponents { get; set; }
        public DbSet<MoBoComponent> moBoComponents { get; set; }
        public DbSet<NetworkComponent> NetworkComponents { get; set; }
        public DbSet<PsuComponent> PSUComponents { get; set; }
        public DbSet<RamComponent> RAMComponents { get; set; }
        public DbSet<SoundComponent> SoundComponents { get; set; }
        public DbSet<StorageComponent> StorageComponents { get; set; }
        public DbSet<OtherComponent> OtherComponents { get; set; }

        // Users
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        // Consumables
        public DbSet<PrinterCartridge> PrinterCartridges { get; set; }

        /// <summary>
        /// Конфигурирует модель сущностей для базы данных.
        /// </summary>
        /// <param name="modelBuilder">Построитель модели.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            foreach (var relationship in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            AuditBuilder(modelBuilder);

            DocumentBuilder(modelBuilder);

            EmployeesBuilder(modelBuilder);

            InventoryBuilder(modelBuilder);

            DictionariesBuilder(modelBuilder);

            ComponentsBuilder(modelBuilder);
            
            TechnicsBuilder(modelBuilder);
            
            UsersBuilder(modelBuilder);
            
            ConsumablesBuilder(modelBuilder);
        }

        private void AuditBuilder(ModelBuilder mb)
        {
            mb.Entity<LogEntry>()
                .ToTable("LogEntrys", "Audit")
                .HasKey(x => x.Id);

            mb.Entity<UserSession>()
                .ToTable("UserSessions", "Audit")
                .HasKey(x => x.Id);

            mb.Entity<LogEntry>()
                .HasIndex(p => p.Details)
                .HasMethod("GIN")
                .HasDatabaseName("IX_LogEntry_Changes");
        }

        private void DictionariesBuilder(ModelBuilder mb)
        {
            mb.Entity<IpDictionary>()
                .ToTable("IpAddresses", "Dictionaries")
                .HasKey(x => x.Id);

            mb.Entity<CpuDictionary>()
                .ToTable("CPUs", "Dictionaries")
                .HasKey(x => x.Id);

            mb.Entity<GpuDictionary>()
                .ToTable("GPUs", "Dictionaries")
                .HasKey(x => x.Id);

            mb.Entity<MoBoDictionary>()
                .ToTable("MoBos", "Dictionaries")
                .HasKey(x => x.Id);

            mb.Entity<FurnitureType>()
                .ToTable("FurnitureTypes", "Dictionaries")
                .HasKey(x => x.Id);

            mb.Entity<FurnitureMaterial>()
                .ToTable("FurnitureMaterials", "Dictionaries")
                .HasKey(x => x.Id);

            mb.Entity<InventoryCategory>()
                .ToTable("InventoryCategories", "Dictionaries")
                .HasKey(x => x.Id);

            mb.Entity<CustomFieldDefenition>()
                .ToTable("CustomFieldDefenitions", "Dictionaries")
                .HasKey(x => x.Id);

            mb.Entity<CustomFieldValue>()
                .ToTable("CustomFieldValues", "Dictionaries")
                .HasKey(x => x.Id);
        }

        private void DocumentBuilder(ModelBuilder mb)
        {
            mb.Entity<CheckoutDocument>()
                .ToTable("CheckoutDocuments", "Documents")
                .HasKey(x => x.Id);

            mb.Entity<CheckoutDocumentItem>()
                .ToTable("CheckoutDocumentItems", "Documents")
                .HasKey(x => x.Id);

            mb.Entity<CheckoutDocumentItem>()
                .HasOne(i => i.Document)
                .WithMany(d => d.Items)
                .HasForeignKey(i => i.DocumentId)
                .OnDelete(DeleteBehavior.Cascade);

            mb.Entity<ReturnDocument>()
                .ToTable("ReturnDocuments", "Documents")
                .HasKey(x => x.Id);

            mb.Entity<ReturnDocumentItem>()
                .ToTable("ReturnDocumentItems", "Documents")
                .HasKey(x => x.Id);

            mb.Entity<ReturnDocumentItem>()
                .HasOne(i => i.Document)
                .WithMany(d => d.Items)
                .HasForeignKey(i => i.DocumentId)
                .OnDelete(DeleteBehavior.Cascade);

            mb.Entity<TransferDocument>()
                .ToTable("TransferDocuments", "Documents")
                .HasKey(x => x.Id);

            mb.Entity<TransferDocumentItem>()
                .ToTable("TransferDocumentItems", "Documents")
                .HasKey(x => x.Id);

            mb.Entity<TransferDocumentItem>()
                .HasOne(i => i.Document)
                .WithMany(d => d.Items)
                .HasForeignKey(i => i.DocumentId)
                .OnDelete(DeleteBehavior.Cascade);

            mb.Entity<WriteOffDocument>()
                .ToTable("WriteOffDocuments", "Documents")
                .HasKey(x => x.Id);

            mb.Entity<WriteOffDocumentItem>()
                .ToTable("WriteOffDocumentItems", "Documents")
                .HasKey(x => x.Id);

            mb.Entity<WriteOffDocumentItem>()
                .HasOne(i => i.Document)
                .WithMany(d => d.Items)
                .HasForeignKey(i => i.DocumentId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void EmployeesBuilder(ModelBuilder mb)
        {
            mb.Entity<Department>()
                .ToTable("Departments", "Employees")
                .HasKey(x => x.Id);

            mb.Entity<Employee>()
                .ToTable("Employees", "Employees")
                .HasKey(x => x.Id);

            mb.Entity<MateriallyResponsible>()
                .ToTable("MateriallyResponsibles", "Employees")
                .HasKey(x => x.Id);
        }

        private void InventoryBuilder(ModelBuilder mb)
        {
            mb.Entity<Furniture>()
                .ToTable("Furnitures", "Inventory")
            .HasBaseType<InventoryItem>();

            mb.Entity<FurnitureMaterialAssignment>()
                .ToTable("FurnitureMaterialAssignments", "Inventory")
                .HasKey(x => x.Id);

            mb.Entity<InventoryItem>()
                .ToTable("InventoryItems", "Inventory")
                .HasKey(x => x.Id);

            mb.Entity<InventoryPhoto>()
                .ToTable("InventoryPhotos", "Inventory")
                .HasKey(x => x.Id);

            mb.Entity<Workplace>()
                .ToTable("Workplaces", "Inventory")
                .HasKey(x => x.Id);

            mb.Entity<WorkplaceEquipment>()
                .ToTable("WorkplaceEquipment", "Inventory")
                .HasKey(x => x.Id);

            mb.Entity<WorkplaceEquipment>()
                .HasOne(i => i.Workplace)
                .WithMany(d => d.WorkplaceEquipments)
                .HasForeignKey(i => i.WorkplaceId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ComponentsBuilder(ModelBuilder mb)
        {
            mb.Entity<ComputerComponent>()
                .ToTable("ComputerComponents", "Technics")
                .HasKey(x => x.Id);

            mb.Entity<ComputerComponent>()
                .HasOne(i => i.Computer)
                .WithMany(d => d.ComputerComponents)
                .HasForeignKey(i => i.ComputerId)
                .OnDelete(DeleteBehavior.Cascade);

            mb.Entity<CpuComponent>()
                .ToTable("CPUComponents", "Technics")
                .HasBaseType<ComputerComponent>();

            mb.Entity<GpuComponent>()
                .ToTable("GPUComponents", "Technics")
                .HasBaseType<ComputerComponent>();

            mb.Entity<MoBoComponent>()
                .ToTable("MoBoComponents", "Technics")
                .HasBaseType<ComputerComponent>();

            mb.Entity<NetworkComponent>()
                .ToTable("NetworkComponents", "Technics")
                .HasBaseType<ComputerComponent>();

            mb.Entity<OtherComponent>()
                .ToTable("OtherComponents", "Technics")
                .HasBaseType<ComputerComponent>();

            mb.Entity<PsuComponent>()
                .ToTable("PSUComponents", "Technics")
                .HasBaseType<ComputerComponent>();

            mb.Entity<RamComponent>()
                .ToTable("RAMComponents", "Technics")
                .HasBaseType<ComputerComponent>();

            mb.Entity<SoundComponent>()
                .ToTable("SoundComponents", "Technics")
                .HasBaseType<ComputerComponent>();

            mb.Entity<StorageComponent>()
                .ToTable("StorageComponents", "Technics")
                .HasBaseType<ComputerComponent>();
        }

        private void TechnicsBuilder(ModelBuilder mb)
        {
            mb.Entity<Computer>()
                .ToTable("Computers", "Technics")
                .HasBaseType<Equipment>();

            mb.Entity<Equipment>()
                .ToTable("Equipments", "Technics")
                .HasBaseType<InventoryItem>();

            mb.Entity<Laptop>()
                .ToTable("Laptops", "Technics")
                .HasBaseType<Equipment>();

            mb.Entity<MaintenanceLog>()
                .ToTable("MaintenanceLogs", "Technics")
                .HasKey(x => x.Id);

            mb.Entity<Entities.Technics.Monitor>()
                .ToTable("Monitors", "Technics")
                .HasBaseType<Equipment>();

            mb.Entity<NetworkDevice>()
                .ToTable("NetworkDevices", "Technics")
                .HasBaseType<InventoryItem>();

            mb.Entity<NetworkDevice>()
                .Property(nd => nd.WiFiNetworksJson)
                .HasConversion(WiFiNetworkJsonConverter.Convert)
                .HasColumnType("jsonb");

            mb.Entity<Phone>()
                .ToTable("Phones", "Technics")
                .HasBaseType<Equipment>();

            mb.Entity<Printer>()
                .ToTable("Printers", "Technics")
                .HasBaseType<Equipment>();

            mb.Entity<Scanner>()
                .ToTable("Scanners", "Technics")
                .HasBaseType<Equipment>();

            mb.Entity<Software>()
                .ToTable("Software", "Technics")
                .HasBaseType<Equipment>();

            mb.Entity<Tablet>()
                .ToTable("Tablets", "Technics")
                .HasBaseType<Equipment>();

            mb.Entity<UPS>()
                .ToTable("UPS", "Technics")
                .HasBaseType<Equipment>();
        }

        private void UsersBuilder(ModelBuilder mb)
        {
            mb.Entity<Favourite>()
                .ToTable("Favourite", "Users")
                .HasKey(x => x.Id);

            mb.Entity<Favourite>()
                .HasOne(i => i.Item)
                .WithMany(d => d.Favourites)
                .HasForeignKey(i => i.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            mb.Entity<Favourite>()
                .HasOne(i => i.User)
                .WithMany(d => d.Favourites)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            mb.Entity<Role>()
                .ToTable("Roles", "Users")
                .HasKey(x => x.Id);

            mb.Entity<UserProfile>()
                .ToTable("UsersProfiles", "Users")
                .HasKey(x => x.Id);

            mb.Entity<UserProfile>()
                .HasOne(i => i.Employee)
                .WithMany(d => d.UserProfiles)
                .HasForeignKey(i => i.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);

            mb.Entity<Role>()
                .HasIndex(p => p.PermissionJson)
                .HasMethod("GIN")
                .HasDatabaseName("IX_Role_PermissionJson");
        }

        private void ConsumablesBuilder(ModelBuilder mb)
        {
            mb.Entity<PrinterCartridge>()
                .ToTable("PrinterCartridges", "Consumables")
                .HasKey(x => x.Id);
        }

        /// <summary>
        /// Частичный метод для дополнительной конфигурации модели.
        /// </summary>
        /// <param name="modelBuilder">Построитель модели.</param>
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
