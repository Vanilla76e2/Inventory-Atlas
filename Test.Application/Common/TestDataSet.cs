using Inventory_Atlas.Core.Enums;
using System.Net;
using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Entities.Inventory;
using Inventory_Atlas.Infrastructure.Entities.Users;
using Inventory_Atlas.Infrastructure.Entities.Consumables;
using Inventory_Atlas.Infrastructure.Entities.Documents;
using Inventory_Atlas.Infrastructure.Entities.Technics.Components;
using Inventory_Atlas.Infrastructure.Entities.Employees;
using Inventory_Atlas.Infrastructure.Entities.Dictionaries;

namespace ApplicationTests.Common
{
    internal class TestDataSet
    {
        internal LogEntry LogEntryTest;
        internal UserSession UserSessionTest;

        internal PrinterCartridge PrinterCartridgeTest;

        internal CpuDictionary CpuDictionaryTest;
        internal FurnitureMaterial FurnitureMaterialTest;
        internal FurnitureType FurnitureTypeTest;
        internal GpuDictionary GpuDictionaryTest;
        internal InventoryCategory InventoryCategoryTest;
        internal IpDictionary IpDictionaryTest;
        internal MoBoDictionary MoBoDictionaryTest;
        internal CustomFieldDefenition CustomFieldDefenitionTest;
        internal CustomFieldValue CustomFieldValueTest;

        internal CheckoutDocument CheckoutDocumentTest;
        internal CheckoutDocumentItem CheckoutDocumentItemTest;
        internal ReturnDocument ReturnDocumentTest;
        internal ReturnDocumentItem ReturnDocumentItemTest;
        internal TransferDocument TransferDocumentTest;
        internal TransferDocumentItem TransferDocumentItemTest;
        internal WriteOffDocument WriteOffDocumentTest;
        internal WriteOffDocumentItem WriteOffDocumentItemTest;

        internal Department Department1Test;
        internal Department Department2Test;
        internal Employee Employee1Test;
        internal Employee Employee2Test;
        internal MateriallyResponsible MateriallyResponsible1Test;
        internal MateriallyResponsible MateriallyResponsible2Test;

        internal Furniture FurnitureTest;
        internal FurnitureMaterialAssignment FurnitureMaterialAssignmentTest;
        internal InventoryPhoto InventoryPhotoTest;
        internal Workplace WorkplaceTest;
        internal WorkplaceEquipment WorkplaceEquipmentTest;
        internal InventoryItem InventoryItemTest;

        internal CpuComponent CpuComponentTest;
        internal GpuComponent GpuComponentTest = new();
        internal MoBoComponent MoBoComponentTest = new ();
        internal NetworkComponent NetworkComponentTest = new ();
        internal OtherComponent OtherComponentTest = new ();
        internal PsuComponent PsuComponentTest = new();
        internal RamComponent RamComponentTest = new();
        internal StorageComponent StorageComponentTest = new();

        internal Computer ComputerTest;
        internal Laptop LaptopTest;
        internal MaintenanceLog MaintenanceLogTest;
        internal Inventory_Atlas.Infrastructure.Entities.Technics.Monitor MonitorTest;
        internal Printer PrinterTest;
        internal NetworkDevice NetworkDeviceTest;
        internal Phone PhoneTest;
        internal Scanner ScannerTest;
        internal Software SoftwareTest;
        internal Tablet TabletTest;
        internal UPS UPSTest;

        internal Favourite FavouriteTest;
        internal Role RoleTest;
        internal UserProfile UserTest;

        internal TestDataSet()
        {
            // Audit
            UserSessionTest = new UserSession()
            {
                Id = Guid.Parse("123e4567-e89b-12d3-a456-426614174000"),
                Username = "TestUser",
                StartTime = DateTime.Parse("2025-10-17 14:23:45+05"),
                EndTime = null,
                IsActive = true,
                IpAddress = IPAddress.Parse("192.168.0.130"),
                LogEntries = new List<LogEntry>()
            };

            LogEntryTest = new LogEntry()
            {
                Id = 1,
                ActionTime = DateTime.Parse("2025-10-17 14:23:45+05"),
                UserSessionId = Guid.Parse("123e4567-e89b-12d3-a456-426614174000"),
                UserSession = null!,
                Action = ActionType.Login,
                Details = "{\"Field1\":\"Value1\",\"Field2\":123,\"Field3\":true}"
            };

            // Consumables
            PrinterCartridgeTest = new PrinterCartridge()
            {
                Id = 1,
                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                Name = "248",
                Model = "XC248A",
                Quantity = 3,
                Printers = new List<Printer>()
            };

            // Dictionaries
            CpuDictionaryTest = new CpuDictionary()
            {
                Id = 1,
                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                Model = "i5-12400",
                Vendor = "Intel",
                CoreCount = 8,
                ThreadCount = 16,
                Clock = 2.6,
                Socket = "LGA1155",
                CPUs = new List<CpuComponent>()
            };

            FurnitureMaterialTest = new FurnitureMaterial()
            {
                Id = 1,
                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                Name = "Дерево",
                FurnitureMaterialAssignments = new List<FurnitureMaterialAssignment>()
            };

            FurnitureTypeTest = new FurnitureType()
            {
                Id = 1,
                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                Name = "Стол",
                Furnitures = new List<Furniture>()
            };

            GpuDictionaryTest = new GpuDictionary()
            {
                Id = 1,
                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                Vendor = "Asus",
                Model = "Nvidia RTX 3060",
                MemorySize = 12,
                MemoryType = GpuMemoryType.GDDR5,
                Vga = 0,
                Hdmi = 1,
                DisplayPort = 3,
                Dvi = 0,
                GPUs = new List<GpuComponent>()
            };

            IpDictionaryTest = new IpDictionary()
            {
                Id = 1,
                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                IpAddress = IPAddress.Parse("192.168.0.2"),
                Note = "Адресс для тех. обслуживания"
            };

            MoBoDictionaryTest = new MoBoDictionary()
            {
                Id = 1,
                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                Vendor = "MSI",
                Model = "B450XC",
                Socket = "LGA1155",
                Chipset = null,
                FormFactor = MoBoFormFactor.ATX,
                RamSlots = 4,
                PcieSlots = 2,
                M2Slots = 0,
                MoBos = new List<MoBoComponent>()
            };

            InventoryCategoryTest = new InventoryCategory()
            {
                Id = 1,
                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                Name = "CCTV",
                Description = "Камеры видеонаблюдения",
                CustomFields = null!
            };

            CustomFieldDefenitionTest = new CustomFieldDefenition()
            {
                Id = 1,
                CategoryId = 1,
                Category = InventoryCategoryTest,
                FieldName = "Угол обзора",
                IsRequired = true,
                DataType = DataTypeEnum.Int,
                Order = 1,
                FieldValues = null!
            };

            CustomFieldValueTest = new CustomFieldValue()
            {
                Id = 1, 
                FieldId = 1,
                FieldDefenition = CustomFieldDefenitionTest,
                InventoryItemId = 1,
                Item = null!,
                Value = "90"
            };

            // Documents
            CheckoutDocumentTest = new CheckoutDocument()
            {
                Id = 1,
                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                DocumentNumber = 1,
                DocumentDate = DateTime.Parse("2025-10-10 10:10:10+05"),
                DocumentName = "Выдача видеокамер операторам",
                Comment = "Сказали что вернут в течении недели",
                DocumentStatus = DocumentStatus.Approved,
                EmployeeId = 1,
                Employee = null!,
                Items = new List<CheckoutDocumentItem>()
            };

            CheckoutDocumentItemTest = new CheckoutDocumentItem()
            {
                Id = 1,
                DocumentId = 1,
                Document = null!,
                ItemId = 1,
                Item = null!
            };

            ReturnDocumentTest = new ReturnDocument()
            {
                Id = 1,
                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                DocumentNumber = 1,
                DocumentDate = DateTime.Parse("2025-10-10 10:10:10+05"),
                DocumentName = "Возврат видеокамер операторами",
                Comment = "Сказали что вернут в течении недели",
                DocumentStatus = DocumentStatus.Draft,
                EmployeeId = 1,
                Employee = null!,
                Items = new List<ReturnDocumentItem>()
            };

            ReturnDocumentItemTest = new ReturnDocumentItem()
            {
                Id = 1,
                DocumentId = 1,
                Document = null!,
                ItemId = 1,
                Item = null!
            };

            TransferDocumentTest = new TransferDocument()
            {
                Id = 1,
                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                DocumentNumber = 1,
                DocumentDate = DateTime.Parse("2025-10-10 10:10:10+05"),
                DocumentName = "Передача видеокамер операторам",
                Comment = "Отадйте уже им эти камеры, почему они у нас?",
                DocumentStatus = DocumentStatus.Waiting,
                FromEmployeeId = 1,
                FromEmployee = null!,
                ToEmployeeId = 2,
                ToEmployee = null!,
                Items = new List<TransferDocumentItem>()
            };

            TransferDocumentItemTest = new TransferDocumentItem()
            {
                Id = 1,
                DocumentId = 1,
                Document = null!,
                ItemId = 1,
                Item = null!
            };

            WriteOffDocumentTest = new WriteOffDocument()
            {
                Id = 1,
                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                DocumentNumber = 1,
                DocumentDate = DateTime.Parse("2025-10-10 10:10:10+05"),
                DocumentName = "Списание старых камер",
                Comment = "Нужно их списать, они убитые в хлам",
                DocumentStatus = DocumentStatus.Draft,
                Reason = "Износ 100%",
                Items = new List<WriteOffDocumentItem>()
            };

            WriteOffDocumentItemTest = new WriteOffDocumentItem()
            {
                Id = 1,
                DocumentId = 1,
                Document = null!,
                ItemId = 1,
                Item = null!
            };

            // Employees
            Department1Test = new Department()
            {
                Id = 1,
                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                Name = "Производственный отдел",
                Comment = null,
                Employees = new List<Employee>()
            };

            Department2Test = new Department()
            {
                Id = 2,
                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                Name = "Операторы",
                Comment = null,
                Employees = new List<Employee>()
            };

            Employee1Test = new Employee()
            {
                Id = 1,
                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                IsDeleted = false,
                DeletedAt = null,
                Surname = "Иванов",
                Firstname = "Иван",
                Patronymic = "Иванович",
                DepartmentId = 1,
                Department = null!,
                Position = "Начальник отдела",
                Comment = null,
                IsResponsible = true,
                Workplaces = new List<Workplace>(),
                MaintenanceLogs = new List<MaintenanceLog>(),
                CheckoutDocuments = new List<CheckoutDocument>(),
                ReturnDocuments = new List<ReturnDocument>(),
                FromTransferDocuments = new List<TransferDocument>(),
                ToTransferDocuments = new List<TransferDocument>(),
                MateriallyResponsibles = new List<MateriallyResponsible>(),
                UserProfiles = new List<UserProfile>()
            };

            Employee2Test = new Employee()
            {
                Id = 1,
                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                IsDeleted = false,
                DeletedAt = null,

                Surname = "Петров",
                Firstname = "Пётр",
                Patronymic = "Петрович",
                DepartmentId = 2,
                Department = null!,
                Position = "Начальник отдела",
                Comment = null,
                IsResponsible = true,

                Workplaces = new List<Workplace>(),
                MaintenanceLogs = new List<MaintenanceLog>(),
                CheckoutDocuments = new List<CheckoutDocument>(),
                ReturnDocuments = new List<ReturnDocument>(),
                FromTransferDocuments = new List<TransferDocument>(),
                ToTransferDocuments = new List<TransferDocument>(),
                MateriallyResponsibles = new List<MateriallyResponsible>(),
                UserProfiles = new List<UserProfile>()
            };

            MateriallyResponsible1Test = new MateriallyResponsible()
            {
                Id = 1,
                EmployeeId = 1,
                Employee = null!,
                DisplayName = "Производственный отдел",
                Items = new List<InventoryItem>()
            };

            MateriallyResponsible2Test = new MateriallyResponsible()
            {
                Id = 2,
                EmployeeId = 2,
                Employee = null!,
                DisplayName = "Операторы",
                Items = new List<InventoryItem>()
            };

            // Inventory
            InventoryItemTest = new InventoryItem()
            {
                Id = 1,
                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                IsDeleted = false,
                DeletedAt = null,

                Name = "Видеокамера в холе",
                InventoryNumber = "101333000333",
                RegistryNumber = "00:0000:0000",
                ResponsibleId = 1,
                Responsible = null!,
                Location = "Холл, 1 этаж",
                Status = InventoryStatus.InUse,
                Comment = "Чёрнобелая камера",
                CategoryId = 1,
                Category = InventoryCategoryTest,
                InventoryItemPhotos = new List<InventoryPhoto>(),
                TransferDocumentItems = new List<TransferDocumentItem>(),
                Favourites = new List<Favourite>()
            };

            FurnitureTest = new Furniture()
            {
                Id = 2,
                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                IsDeleted = false,
                DeletedAt = null,

                Name = "Стол офисный",
                InventoryNumber = "101342000218",
                RegistryNumber = "00:0012:2428",
                ResponsibleId = 2,
                Responsible = null!,
                Location = "202 кабинет",
                Status = InventoryStatus.InUse,
                Comment = "Офисный стол для сотрудников",
                InventoryItemPhotos = new List<InventoryPhoto>(),
                TransferDocumentItems = new List<TransferDocumentItem>(),
                Favourites = new List<Favourite>(),

                FurnitureTypeId = 1,
                FurnitureType = null!,
                Dimensions = "120x60x75",
                Weight = 25.5,
                Orientation = FurnitureOrientation.None,
                Materials = new List<FurnitureMaterialAssignment>()
            };

            FurnitureMaterialAssignmentTest = new FurnitureMaterialAssignment()
            {
                Id = 1,
                FurnitureId = 2,
                Furniture = null!,
                MaterialId = 1,
                FurnitureMaterial = null!
            };

            InventoryPhotoTest = new InventoryPhoto()
            {
                Id = 1,
                InventoryItemId = 1,
                PhotoPath = "C:\\User\\Images",
                IsPrimary = true
            };

            WorkplaceTest = new Workplace()
            {
                Id = 1,
                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),

                Name = "Основное рабочее место",
                Comment = null,
                EmployeeId = 1,
                Employee = null!,
                WorkplaceEquipments = new List<WorkplaceEquipment>()
            };

            WorkplaceEquipmentTest = new WorkplaceEquipment()
            {
                Id = 1,
                WorkplaceId = 1,
                Workplace = null!,
                EquipmentId = 3,
                Equipment = null!
            };

            // Technics
            CpuComponentTest = new CpuComponent()
            {
                Id = 1,

                ComputerId = 3,
                Computer = null!,
                ComponentType = ComponentType.CPU,
                Quantity = 1,
                SerialNumber = "SN123456789",

                CPUId = 1,
                CPUReference = null!
            };

            GpuComponentTest = new GpuComponent()
            {
                Id = 2,

                ComputerId = 3,
                Computer = null!,
                ComponentType = ComponentType.GPU,
                Quantity = 2,
                SerialNumber = "SAfhih4423",

                GpuId = 1,
                GPUReference = null!
            };

            MoBoComponentTest = new MoBoComponent()
            {
                Id = 3,

                ComputerId = 3,
                Computer = null!,
                ComponentType = ComponentType.MoBo,
                Quantity = 1,
                SerialNumber = "sdjgfi1111",

                MoBoId = 1,
                MoBoReference = null!
            };

            NetworkComponentTest = new NetworkComponent
            {
                Id = 4,

                ComputerId = 3,
                Computer = null!,
                ComponentType = ComponentType.NetCard,
                Quantity = 1,
                SerialNumber = null,

                Model = "Realteck",
                Optical = false,
                Speed = 1000
            };

            OtherComponentTest = new OtherComponent
            {
                Id = 5,

                ComputerId = 3,
                Computer = null!,
                ComponentType = ComponentType.Other,
                Quantity = 1,
                SerialNumber = null,

                Name = "PCI-E порт",
                Description = "Гибкий шлейф для вертикальной установки видеокарты"
            };

            PsuComponentTest = new PsuComponent()
            {
                Id = 6,

                ComputerId = 3,
                Computer = null!,
                ComponentType = ComponentType.PSU,
                Quantity = 1,
                SerialNumber = null,

                Wattage = 750
            };

            RamComponentTest = new RamComponent()
            {
                Id = 7,

                ComputerId = 3,
                Computer = null!,
                ComponentType = ComponentType.RAM,
                Quantity = 1,
                SerialNumber = null,

                DdrType = DDRType.DDR4,
                Frequency = 3200,
                Size = 16
            };

            StorageComponentTest = new StorageComponent()
            {
                Id = 8,

                ComputerId = 3,
                Computer = null!,
                ComponentType = ComponentType.Drive,
                Quantity = 1,
                SerialNumber = null,

                StorageType = Inventory_Atlas.Core.Enums.DriveType.SSD,
                Capacity = 1000
            };

            ComputerTest = new Computer()
            {
                Id = 3,

                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                IsDeleted = false,
                DeletedAt = null,

                Name = "ПК",
                InventoryNumber = "101342000999",
                RegistryNumber = "00:0021:8989",
                ResponsibleId = 1,
                Responsible = null!,
                Location = "111 кабинет",
                Status = InventoryStatus.InUse,
                Comment = "Хорошо бы почистить",

                WorkplaceEquipments = null!,
                MaintenanceLogs = null!,

                IsServer = false,
                IpAddress = IPAddress.Parse("192.168.0.122"),
                OperatingSystem = "Windows",
                ComputerComponents = null!
            };

            LaptopTest = new Laptop()
            {
                Id = 4,

                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                IsDeleted = false,
                DeletedAt = null,

                Name = "Ноутбук Asus",
                InventoryNumber = "21341234",
                RegistryNumber = "00:3142:1231",
                ResponsibleId = 1,
                Responsible = null!,
                Location = "100 кабинет",
                Status = InventoryStatus.Stored,
                Comment = "",

                Model = "EA300",
                Vendor = "Asus",
                SerialNumber = "21341241wsd",

                Diagonal = 12.6,
                Resolution = "1920x1080",
                OperatingSystem = "Windows",
                Processor = "Intel i5",
                RAM = 8,
                Drive = 512,
                GPU = null,
                IpAddress = IPAddress.Parse("127.0.0.1")
            };

            MonitorTest = new Inventory_Atlas.Infrastructure.Entities.Technics.Monitor()
            {
                Id = 5,

                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                IsDeleted = false,
                DeletedAt = null,

                Name = "Монитор MSI",
                InventoryNumber = "45646545",
                RegistryNumber = "00:654:456",
                ResponsibleId = 1,
                Responsible = null!,
                Location = "100 кабинет",
                Status = InventoryStatus.InUse,
                Comment = "",

                Model = "EA241",
                Vendor = "MSI",
                SerialNumber = "43hdgsde5",

                Diagonal = 20.8,
                ResolutionWidth = 1920,
                ResolutionHeight = 1080,
                RefreshRate = 75,
                PanelType = DisplayType.IPS,
                Vga = 1,
                Hdmi = 1,
                DisplayPort = 1,
                Dvi = 1,
            };

            NetworkDeviceTest = new NetworkDevice()
            {
                Id = 6,

                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                IsDeleted = false,
                DeletedAt = null,

                Name = "Роутер D-Link",
                InventoryNumber = "888888888",
                RegistryNumber = "00:8888:8888",
                ResponsibleId = 1,
                Responsible = null!,
                Location = "142 кабинет",
                Status = InventoryStatus.Reserved,
                Comment = "",

                Model = "SAD33",
                Vendor = "D-Link",
                SerialNumber = "dsgj439gre75h",
                IpAddress = IPAddress.Parse("192.168.10.22"),
                MacAddress = null,
                DhcpRange = "192.168.10.50-200",
                AdminLogin = "admin",
                AdminPassword = "nimda",
                PortCount = 8,
                WiFiNetworksJson =
                {
                    new WiFiNetworkJsonModel()
                    {
                        Band = "2.4G",
                        Ssid = "Office_WiFi",
                        Password = "office1234"
                    },
                    new WiFiNetworkJsonModel()
                    {
                        Band = "5G",
                        Ssid = "Office_WiFi_5G",
                        Password = "office1234"
                    }
                }, 
                NetworkBandwidth = 1000
            };

            PhoneTest = new Phone()
            {
                Id = 7,

                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                IsDeleted = false,
                DeletedAt = null,

                Name = "Xiaomi 5 Pro",
                InventoryNumber = "999999999",
                RegistryNumber = "00:9999:9999",
                ResponsibleId = 1,
                Responsible = null!,
                Location = "203 кабинет",
                Status = InventoryStatus.InUse,
                Comment = "",

                Model = "5 Pro",
                Vendor = "Xiaomi",
                SerialNumber = "asdhg23423",

                PhoneNumber = "+7(800)555-35-35",
            };

            PrinterTest = new Printer()
            {
                Id = 8,

                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                IsDeleted = false,
                DeletedAt = null,

                Name = "МФУ HP",
                InventoryNumber = "777777777",
                RegistryNumber = "00:7777:7777",
                ResponsibleId = 1,
                Responsible = null!,
                Location = "201 кабинет",
                Status = InventoryStatus.InUse,
                Comment = "",

                Model = "LaserJet Pro",
                Vendor = "HP",
                SerialNumber = "hgsdfg34534",

                IpAddress = IPAddress.Parse("192.168.0.152"),
                CartridgeId = 1,
                Cartridge = null!,
                Color = false,
                HasScanner = true
            };

            ScannerTest = new Scanner()
            {
                Id = 9,

                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                IsDeleted = false,
                DeletedAt = null,

                Name = "Сканер Canon",
                InventoryNumber = "666666666",
                RegistryNumber = "00:6666:6666",
                ResponsibleId = 1,
                Responsible = null!,
                Location = "201 кабинет",
                Status = InventoryStatus.InUse,
                Comment = "",

                Model = "ScanPro 2000",
                Vendor = "Canon",
                SerialNumber = "sdg34534",

                IpAddress = IPAddress.Parse("192.167.52"),
                Dpi = 1200,
                Color = true
            };

            SoftwareTest = new Software()
            {
                Id = 10,

                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                DeletedAt = null,
                IsDeleted = false,

                Name = "Microsoft Office",
                InventoryNumber = "111111i121",
                RegistryNumber = "00:1111:1212",
                ResponsibleId = 1,
                Responsible = null!,
                Location = "Установка на ПК Иванова И.И.",
                Status = InventoryStatus.InUse,
                Comment = "",

                LicenceKey = "XXXX-YYYY-ZZZZ-AAAA",
                Vendor = "Microsoft",
            };

            TabletTest = new Tablet()
            {
                Id = 11,

                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                IsDeleted = false,
                DeletedAt = null,

                Name = "iPad Pro",
                InventoryNumber = "1212121212",
                RegistryNumber = "00:1212:1212",
                ResponsibleId = 1,
                Responsible = null!,
                Location = "Кабинет директора",
                Status = InventoryStatus.InUse,
                Comment = "",

                Model = "Pro 11",
                Vendor = "Apple",
                SerialNumber = "asdasd123123",
                Diagonal = 11.0,
                Resolution = "2388x1668",
                OperatingSystem = "iOS",
                IpAddress = IPAddress.Parse("192.168.0.215")
            };

            UPSTest = new UPS()
            {
                Id = 12,

                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                IsDeleted = false,
                DeletedAt = null,

                Name = "ИБП CyberPower",
                InventoryNumber = "1313131313",
                RegistryNumber = "00:1313:1313",
                ResponsibleId = 1,
                Responsible = null!,
                Location = "Серверная",
                Status = InventoryStatus.InUse,
                Comment = "",

                Model = "CP1500EPFCLCD",
                Vendor = "CyberPower",
                SerialNumber = "cyberpower12345",
                
                CapacityWatts = 900
            };

            MaintenanceLogTest = new MaintenanceLog()
            {
                Id = 1,

                DeviceId = 3,
                Device = null!,
                MaintenanceDate = DateTime.Parse("2025-10-15 10:10:10+05"),
                MaintenanceType = MaintenanceType.Inspection,
                PerformedBy = 1,
                Employee = null!,
                Comment = "Неисправностей не выявлено"
            };

            FavouriteTest = new Favourite()
            {
                Id = 1,

                FavouritedAt = DateTime.Parse("2025-10-15 10:10:10+05"),
                ItemId = 1,
                Item = InventoryItemTest,
                UserId = 1,
                User = null!                
            };

            RoleTest = new Role()
            {
                Id = 1,

                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),

                Name = "Админ",
                IsSystem = true,
                Description = "Администратор",
                PermissionJson = "[{\"Admin\":true}]",
                UserProfiles = new List<UserProfile>()
            };

            UserTest = new UserProfile()
            {
                Id = 1,

                CreatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),
                UpdatedAt = DateTime.Parse("2025-10-10 10:10:10+05"),

                Username = "admin",
                EmployeeId = 1,
                Employee = Employee1Test,
                IsActive = true,
                PasswordHash = "password",
                RoleId = 1,
                Role = RoleTest,
                Favourites = new List<Favourite>()
            };

            // Navigation
            UserTest.Favourites.Add(FavouriteTest);
            RoleTest.UserProfiles.Add(UserTest);
            FavouriteTest.User = UserTest;

            CustomFieldValueTest.Item = InventoryItemTest;

            LogEntryTest.UserSession = UserSessionTest;
            UserSessionTest.LogEntries.Add(LogEntryTest);
            
            PrinterCartridgeTest.Printers.Add(PrinterTest);
            PrinterTest.Cartridge = PrinterCartridgeTest;

            CpuDictionaryTest.CPUs.Add(CpuComponentTest);
            CpuComponentTest.CPUReference = CpuDictionaryTest;

            FurnitureMaterialTest.FurnitureMaterialAssignments.Add(FurnitureMaterialAssignmentTest);
            FurnitureMaterialAssignmentTest.FurnitureMaterial = FurnitureMaterialTest;

            FurnitureTypeTest.Furnitures.Add(FurnitureTest);
            FurnitureTest.FurnitureType = FurnitureTypeTest;
            FurnitureMaterialAssignmentTest.FurnitureMaterial = FurnitureMaterialTest;

            GpuDictionaryTest.GPUs.Add(GpuComponentTest);
            GpuComponentTest.GPUReference = GpuDictionaryTest;

            MoBoDictionaryTest.MoBos.Add(MoBoComponentTest);
            MoBoComponentTest.MoBoReference = MoBoDictionaryTest;

            CheckoutDocumentTest.Items.Add(CheckoutDocumentItemTest);
            CheckoutDocumentItemTest.Document = CheckoutDocumentTest;

            ReturnDocumentTest.Items.Add(ReturnDocumentItemTest);
            ReturnDocumentItemTest.Document = ReturnDocumentTest;
            ReturnDocumentTest.Employee = Employee1Test;
            ReturnDocumentItemTest.Item = InventoryItemTest;

            TransferDocumentTest.Items.Add(TransferDocumentItemTest);
            TransferDocumentItemTest.Document = TransferDocumentTest;
            TransferDocumentTest.FromEmployee = Employee1Test;
            TransferDocumentTest.ToEmployee = Employee2Test;
            TransferDocumentItemTest.Item = InventoryItemTest;

            WriteOffDocumentTest.Items.Add(WriteOffDocumentItemTest);
            WriteOffDocumentItemTest.Document = WriteOffDocumentTest;
            WriteOffDocumentItemTest.Item = InventoryItemTest;

            Department1Test.Employees.Add(Employee1Test);
            Employee1Test.Department = Department1Test;

            Department2Test.Employees.Add(Employee2Test);
            Employee2Test.Department = Department2Test;

            MateriallyResponsible1Test.Employee = Employee1Test;
            Employee1Test.MateriallyResponsibles.Add(MateriallyResponsible1Test);

            MateriallyResponsible2Test.Employee = Employee2Test;
            Employee2Test.MateriallyResponsibles.Add(MateriallyResponsible2Test);
            
            WorkplaceTest.Employee = Employee1Test;
            Employee1Test.Workplaces.Add(WorkplaceTest);

            WorkplaceEquipmentTest.Workplace = WorkplaceTest;
            WorkplaceTest.WorkplaceEquipments.Add(WorkplaceEquipmentTest);

            CpuComponentTest.Computer = ComputerTest;
            GpuComponentTest.Computer = ComputerTest;
            MoBoComponentTest.Computer = ComputerTest;
            NetworkComponentTest.Computer = ComputerTest;
            OtherComponentTest.Computer = ComputerTest;
            PsuComponentTest.Computer = ComputerTest;
            RamComponentTest.Computer = ComputerTest;
            StorageComponentTest.Computer = ComputerTest;
            ComputerTest.ComputerComponents = new List<ComputerComponent>()
            {
                CpuComponentTest,
                GpuComponentTest,
                MoBoComponentTest,
                NetworkComponentTest,
                OtherComponentTest,
                PsuComponentTest,
                RamComponentTest,
                StorageComponentTest
            };

            LaptopTest.Responsible = MateriallyResponsible1Test;
            MateriallyResponsible1Test.Items.Add(LaptopTest);

            MonitorTest.Responsible = MateriallyResponsible1Test;
            MateriallyResponsible1Test.Items.Add(MonitorTest);

            NetworkDeviceTest.Responsible = MateriallyResponsible1Test;
            MateriallyResponsible1Test.Items.Add(NetworkDeviceTest);

            PhoneTest.Responsible = MateriallyResponsible1Test;
            MateriallyResponsible1Test.Items.Add(PhoneTest);

            PrinterTest.Responsible = MateriallyResponsible1Test;
            MateriallyResponsible1Test.Items.Add(PrinterTest);

            ScannerTest.Responsible = MateriallyResponsible1Test;
            MateriallyResponsible1Test.Items.Add(ScannerTest);

            SoftwareTest.Responsible = MateriallyResponsible1Test;
            MateriallyResponsible1Test.Items.Add(SoftwareTest);

            TabletTest.Responsible = MateriallyResponsible1Test;
            MateriallyResponsible1Test.Items.Add(TabletTest);

            UPSTest.Responsible = MateriallyResponsible1Test;
            MateriallyResponsible1Test.Items.Add(UPSTest);

            MaintenanceLogTest.Device = ComputerTest;
            MaintenanceLogTest.Employee = Employee1Test;
            ComputerTest.MaintenanceLogs = new List<MaintenanceLog>() { MaintenanceLogTest };

            CheckoutDocumentTest.Employee = Employee1Test;
            CheckoutDocumentItemTest.Item = InventoryItemTest;
        }
    }
}
