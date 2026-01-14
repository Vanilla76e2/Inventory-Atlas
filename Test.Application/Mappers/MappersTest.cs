using ApplicationTests.Common;
using AutoMapper;
using Inventory_Atlas.Application.Mappings.Audit;
using Inventory_Atlas.Application.Mappings.Consumables;
using Inventory_Atlas.Application.Mappings.Dictionaries;
using Inventory_Atlas.Application.Mappings.Documents;
using Inventory_Atlas.Application.Mappings.Employees;
using Inventory_Atlas.Application.Mappings.Inventory;
using Inventory_Atlas.Application.Mappings.Technics;
using Inventory_Atlas.Application.Mappings.Users;
using Inventory_Atlas.Core.DTOs.Audit;
using Inventory_Atlas.Core.DTOs.Consumables;
using Inventory_Atlas.Core.DTOs.Dictionaries;
using Inventory_Atlas.Core.DTOs.Documents;
using Inventory_Atlas.Core.DTOs.Employees;
using Inventory_Atlas.Core.DTOs.Inventory;
using Inventory_Atlas.Core.DTOs.Technics;
using Inventory_Atlas.Core.DTOs.Users;
using System.Runtime.CompilerServices;

namespace ApplicationTests;

[TestFixture]
public class MappersTest
{
    private IMapper _mapper = null!;
    private TestDataSet _dataSet = new();

    [SetUp]
    public void Setup()
    {
        var config = new MapperConfiguration(cfg =>
        {
            // Audit
            cfg.AddProfile<LogEntryProfile>();
            cfg.AddProfile<UserSessionProfile>();
            // Consumables
            cfg.AddProfile<PrinterCartridgeProfile>();
            // Dictionaries
            cfg.AddProfile<CpuDictionaryProfile>();
            cfg.AddProfile<FurnitureMaterialProfile>();
            cfg.AddProfile<FurnitureTypeProfile>();
            cfg.AddProfile<GpuDictionaryProfile>();
            cfg.AddProfile<InventoryCategoryProfile>();
            cfg.AddProfile<IpDictionaryProfile>();
            cfg.AddProfile<MoBoDictionaryProfile>();
            // Documents
            cfg.AddProfile<CheckoutDocumentProfile>();
            cfg.AddProfile<ReturnDocumentProfile>();
            cfg.AddProfile<TransferDocumentProfile>();
            cfg.AddProfile<WriteOffDocumentProfile>();
            // Employees
            cfg.AddProfile<DepartmentProfile>();
            cfg.AddProfile<EmployeeProfile>();
            cfg.AddProfile<MateriallyResposibleProfile>();
            // Inventory
            cfg.AddProfile<FurnitureProfile>();
            cfg.AddProfile<InventoryItemProfile>();
            cfg.AddProfile<InventoryPhotoProfile>();
            cfg.AddProfile<WorkplaceProfile>();
            // Technics
            cfg.AddProfile<EquipmentProfile>();
            cfg.AddProfile<ComputerProfile>();
            cfg.AddProfile<LaptopProfile>();
            cfg.AddProfile<MaintenanceLogProfile>();
            cfg.AddProfile<MonitorProfile>();
            cfg.AddProfile<NetworkDeviceProfile>();
            cfg.AddProfile<PhoneProfile>();
            cfg.AddProfile<PrinterProfile>();
            cfg.AddProfile<ScannerProfile>();
            cfg.AddProfile<SoftwareProfile>();
            cfg.AddProfile<TabletProfile>();
            cfg.AddProfile<UpsProfile>();
            // Users
            cfg.AddProfile<FavouriteProfile>();
            cfg.AddProfile<RoleProfile>();
            cfg.AddProfile<UserProfileProfile>();
        });

        _mapper = config.CreateMapper();
    }

    // Audit
    [Test]
    public void LogEntry_Should_Map_Correctly()
    {
        //Arrange
        var logEntry = _dataSet.LogEntryTest;
        //Act
        var logEntryDto = _mapper.Map<LogEntryDto>(logEntry);
        //Assert
        Assert.IsNotNull(logEntryDto);
        Assert.That(logEntryDto.ActionTime.Equals(logEntry.ActionTime));
        Assert.That(logEntryDto.Username.Equals(logEntry.UserSession.Username));
        Assert.That(logEntryDto.Action.Equals(logEntry.Action));
    }

    [Test]
    public void PagedLogEntry_Should_Map_Correctly()
    {
        //Arrange
        var logEntries = new List<Inventory_Atlas.Application.Entities.Audit.LogEntry>
        {
            _dataSet.LogEntryTest,
            _dataSet.LogEntryTest
        };
        int totalCount = logEntries.Count();
        int pageNumber = 1;
        int pageSize = 10;
        var pagedLogEntriesSource = (items: logEntries, totalCount, pageNumber, pageSize);
        //Act
        var pagedLogEntriesDto = _mapper.Map<PagedLogEntryDto>(pagedLogEntriesSource);
        //Assert
        Assert.IsNotNull(pagedLogEntriesDto);
        Assert.That(pagedLogEntriesDto.TotalCount.Equals(2));
        Assert.That(pagedLogEntriesDto.PageNumber.Equals(pageNumber));
        Assert.That(pagedLogEntriesDto.PageSize.Equals(pageSize));
    }

    [Test]
    public void UserSession_Should_Map_Correctly()
    {
        //Arrange
        var userSession = _dataSet.UserSessionTest;
        // Act
        var dto = _mapper.Map<UserSessionDto>(userSession);

        // Assert простые поля
        Assert.That(dto.Username, Is.EqualTo(userSession.Username));
        Assert.That(dto.StartTime, Is.EqualTo(userSession.StartTime));
        Assert.That(dto.EndTime, Is.EqualTo(userSession.EndTime));
        Assert.That(dto.IsActive, Is.EqualTo(userSession.IsActive));
        Assert.That(dto.IpAddress, Is.EqualTo(userSession.IpAddress?.ToString()));

        Assert.That(dto.LogEntries, Is.Not.Null);
        Assert.That(dto.LogEntries, Has.Count.EqualTo(userSession.LogEntries.Count));
    }

    [Test]
    public void UserSessionList_Should_Map_Correctly()
    {
        // Arrange
        var userSession = _dataSet.UserSessionTest;
        // Act
        var userSessionListDto = _mapper.Map<UserSessionListDto>(userSession);
        // Assert
        Assert.NotNull(userSessionListDto);
        Assert.That(userSessionListDto.Username, Is.EqualTo(userSession.Username));
        Assert.That(userSessionListDto.StartTime, Is.EqualTo(userSession.StartTime));
        Assert.That(userSessionListDto.EndTime, Is.EqualTo(userSession.EndTime));
        Assert.That(userSessionListDto.IsActive, Is.EqualTo(userSession.IsActive));
        Assert.That(userSessionListDto.IpAddress, Is.EqualTo(userSession.IpAddress?.ToString()));
    }

    // Consumables
    [Test]
    public void PrinterCartridge_Should_Map_Correctly()
    {
        // Arrange
        var printerCartridge = _dataSet.PrinterCartridgeTest;
        // Act
        var printerCartidgeDto = _mapper.Map<PrinterCartridgeDto>(printerCartridge);
        // Assert
        Assert.That(printerCartidgeDto.Name, Is.EqualTo(printerCartridge.Name));
        Assert.That(printerCartidgeDto.Model, Is.EqualTo(printerCartridge.Model));
        Assert.That(printerCartidgeDto.Quantity, Is.EqualTo(printerCartridge.Quantity));
    }

    // Dictionaries
    [Test]
    public void CpuDictionary_Should_Map_Correctly()
    {
        // Arrange
        var cpuDictionary = _dataSet.CpuDictionaryTest;
        // Act
        var cpuDictionaryDto = _mapper.Map<CPUDto>(cpuDictionary);
        // Assert
        Assert.NotNull(cpuDictionaryDto);
        Assert.That(cpuDictionaryDto.Model, Is.EqualTo(cpuDictionary.Model));
        Assert.That(cpuDictionaryDto.Vendor, Is.EqualTo(cpuDictionary.Vendor));
        Assert.That(cpuDictionaryDto.CoreCount, Is.EqualTo(cpuDictionary.CoreCount));
        Assert.That(cpuDictionary.ThreadCount, Is.EqualTo(cpuDictionary!.ThreadCount));
        Assert.That(cpuDictionary.Clock, Is.EqualTo(cpuDictionary!.Clock));
        Assert.That(cpuDictionary.Socket, Is.EqualTo(cpuDictionary!.Socket));
    }

    [Test]
    public void FurnitureMaterial_Should_Map_Correctly()
    {
        // Arrange
        var furnitureMaterial = _dataSet.FurnitureMaterialTest;
        // Act
        var furnitureMaterialDto = _mapper.Map<FurnitureMaterialDto>(furnitureMaterial);
        // Assert
        Assert.NotNull(furnitureMaterialDto);
        Assert.That(furnitureMaterialDto.Name, Is.EqualTo(furnitureMaterial.Name));
    }

    [Test]
    public void FurnitureType_Should_Map_Correctly()
    {
        // Arrange
        var furnitureType = _dataSet.FurnitureTypeTest;
        // Act
        var furnitureTypeDto = _mapper.Map<FurnitureTypeDto>(furnitureType);
        // Arrange
        Assert.NotNull(furnitureTypeDto);
        Assert.That(furnitureTypeDto.Name, Is.EqualTo(furnitureType.Name));
    }

    [Test]
    public void GpuDictionary_should_Map_Correctly()
    {
        // Arrange
        var gpuDictionary = _dataSet.GpuDictionaryTest;
        // Act
        var gpuDictionaryDto = _mapper.Map<GPUDto>(gpuDictionary);
        // Arrange
        Assert.NotNull(gpuDictionaryDto);
        Assert.That(gpuDictionaryDto.Vendor, Is.EqualTo(gpuDictionary.Vendor));
        Assert.That(gpuDictionaryDto.Model, Is.EqualTo(gpuDictionary.Model));
        Assert.That(gpuDictionaryDto.MemorySize, Is.EqualTo(gpuDictionary.MemorySize));
        Assert.That(gpuDictionaryDto.MemoryType, Is.EqualTo(gpuDictionary.MemoryType));
        Assert.That(gpuDictionaryDto.Vga, Is.EqualTo(gpuDictionary.Vga));
        Assert.That(gpuDictionaryDto.Hdmi, Is.EqualTo(gpuDictionary.Hdmi));
        Assert.That(gpuDictionaryDto.DisplayPort, Is.EqualTo(gpuDictionary.DisplayPort));
        Assert.That(gpuDictionaryDto.Dvi, Is.EqualTo(gpuDictionary.Dvi));
    }

    [Test]
    public void InventoryCategory_Should_Map_Correctly()
    {
        // Arrange
        var inventoryCategory = _dataSet.InventoryCategoryTest;
        // Act
        var inventoryCategoryDto = _mapper.Map<InventoryCategoryDto>(inventoryCategory);
        // Assert
        Assert.NotNull(inventoryCategoryDto);
        Assert.That(inventoryCategoryDto.Name, Is.EqualTo(inventoryCategory.Name));
        Assert.That(inventoryCategoryDto.Description, Is.EqualTo(inventoryCategory.Description));
        Assert.NotNull(inventoryCategoryDto.ItemIds);
    }

    [Test]
    public void IpDictionary_Should_Map_Correctly()
    {
        // Arrange
        var ipDictionary = _dataSet.IpDictionaryTest;
        // Act
        var ipDictionaryDto = _mapper.Map<IpDictionaryDto>(ipDictionary);
        // Assert
        Assert.NotNull(ipDictionaryDto);
        Assert.That(ipDictionaryDto.IpAddress, Is.EqualTo(ipDictionary.IpAddress));
        Assert.That(ipDictionaryDto.Note, Is.EqualTo(ipDictionary.Note));
    }

    [Test]
    public void MoBoDictionary_Should_Map_Correctly()
    {
        // Arrange
        var moboDictionary = _dataSet.MoBoDictionaryTest;
        // Act
        var moboDictionaryDto = _mapper.Map<MoBoDto>(moboDictionary);
        // Assert
        Assert.NotNull(moboDictionaryDto);
        Assert.That(moboDictionaryDto.Vendor, Is.EqualTo(moboDictionary.Vendor));
        Assert.That(moboDictionaryDto.Model, Is.EqualTo(moboDictionary.Model));
        Assert.That(moboDictionaryDto.Socket, Is.EqualTo(moboDictionary.Socket));
        Assert.That(moboDictionaryDto.Chipset, Is.EqualTo(moboDictionary.Chipset));
        Assert.That(moboDictionaryDto.FormFactor, Is.EqualTo(moboDictionary.FormFactor));
        Assert.That(moboDictionaryDto.RamSlots, Is.EqualTo(moboDictionary.RamSlots));
        Assert.That(moboDictionaryDto.PcieSlots, Is.EqualTo(moboDictionary.PcieSlots));
        Assert.That(moboDictionaryDto.M2Slots, Is.EqualTo(moboDictionary.M2Slots));
    }

    [Test]
    public void CheckoutDocument_Should_Map_Correctly()
    {
        // Arrange
        var checkoutDocument = _dataSet.CheckoutDocumentTest;
        // Act
        var checkoutDocumentDto = _mapper.Map<CheckoutDocumentDto>(checkoutDocument);
        // Assert
        Assert.NotNull(checkoutDocumentDto);
        Assert.That(checkoutDocumentDto.DocumentNumber, Is.EqualTo(checkoutDocument.DocumentNumber));
        Assert.That(checkoutDocumentDto.DocumentDate, Is.EqualTo(checkoutDocument.DocumentDate));
        Assert.That(checkoutDocumentDto.DocumentName, Is.EqualTo(checkoutDocument.DocumentName));
        Assert.That(checkoutDocumentDto.Comment, Is.EqualTo(checkoutDocument.Comment));
        Assert.That(checkoutDocumentDto.DocumentStatus, Is.EqualTo(checkoutDocument.DocumentStatus));
        Assert.That(checkoutDocumentDto.EmployeeId, Is.EqualTo(checkoutDocument.EmployeeId));
        Assert.That(checkoutDocumentDto.EmployeeName, Is.EqualTo(checkoutDocument.Employee.FullName));
    }

    [Test]
    public void CheckoutDocumentList_Should_Map_Correctly()
    {
        // Arrange
        var checkoutDocument = _dataSet.CheckoutDocumentTest;
        // Act
        var checkoutDocumentListDto = _mapper.Map<CheckoutDocumentListDto>(checkoutDocument);
        // Assert
        Assert.NotNull(checkoutDocumentListDto);
        Assert.That(checkoutDocumentListDto.DocumentNumber, Is.EqualTo(checkoutDocument.DocumentNumber));
        Assert.That(checkoutDocumentListDto.DocumentDate, Is.EqualTo(checkoutDocument.DocumentDate));
        Assert.That(checkoutDocumentListDto.DocumentName, Is.EqualTo(checkoutDocument.DocumentName));
        Assert.That(checkoutDocumentListDto.Comment, Is.EqualTo(checkoutDocument.Comment));
        Assert.That(checkoutDocumentListDto.DocumentStatus, Is.EqualTo(checkoutDocument.DocumentStatus));
        Assert.That(checkoutDocumentListDto.EmployeeName, Is.EqualTo(checkoutDocument.Employee.ShortName));
        Assert.That(checkoutDocumentListDto.ItemsCount, Is.EqualTo(checkoutDocument.Items.Count));
    }

    [Test]
    public void CheckoutDocumentItem_Should_Map_Correctly()
    {
        // Arrange
        var checkoutDocumentItem = _dataSet.CheckoutDocumentItemTest;
        // Act
        var checkoutDocumentItemDto = _mapper.Map<CheckoutDocumentItemDto>(checkoutDocumentItem);
        // Assert
        Assert.NotNull(checkoutDocumentItemDto);
        Assert.That(checkoutDocumentItemDto.ItemName, Is.EqualTo(checkoutDocumentItem.Item.Name));
        Assert.That(checkoutDocumentItemDto.ItemInventoryNumber, Is.EqualTo(checkoutDocumentItem.Item.InventoryNumber));
    }

    [Test]
    public void ReturnDocument_Should_Map_Correctly()
    {
        // Arrange
        var returnDocument = _dataSet.ReturnDocumentTest;
        // Act
        var returnDocumentDto = _mapper.Map<ReturnDocumentDto>(returnDocument);
        // Assert
        Assert.NotNull(returnDocumentDto);
        Assert.That(returnDocumentDto.DocumentNumber, Is.EqualTo(returnDocument.DocumentNumber));
        Assert.That(returnDocumentDto.DocumentDate, Is.EqualTo(returnDocument.DocumentDate));
        Assert.That(returnDocumentDto.DocumentName, Is.EqualTo(returnDocument.DocumentName));
        Assert.That(returnDocumentDto.Comment, Is.EqualTo(returnDocument.Comment));
        Assert.That(returnDocumentDto.DocumentStatus, Is.EqualTo(returnDocument.DocumentStatus));
        Assert.That(returnDocumentDto.EmployeeId, Is.EqualTo(returnDocument.EmployeeId));
        Assert.That(returnDocumentDto.EmployeeName, Is.EqualTo(returnDocument.Employee.FullName));
    }

    [Test]
    public void ReturnDocumentItem_Should_Map_Correctly()
    {
        // Arrange
        var returnDocumentItem = _dataSet.ReturnDocumentItemTest;
        // Act
        var returnDocumentItemDto = _mapper.Map<ReturnDocumentItemDto>(returnDocumentItem);
        // Assert
        Assert.NotNull(returnDocumentItemDto);
        Assert.That(returnDocumentItemDto.ItemName, Is.EqualTo(returnDocumentItem.Item.Name));
        Assert.That(returnDocumentItemDto.ItemInventoryNumber, Is.EqualTo(returnDocumentItem.Item.InventoryNumber));
    }

    [Test]
    public void ReturnDocumentList_Should_Map_Correctly()
    {
        // Arrange
        var returnDocument = _dataSet.ReturnDocumentTest;
        // Act
        var returnDocumentListDto = _mapper.Map<ReturnDocumentListDto>(returnDocument);
        // Assert
        Assert.NotNull(returnDocumentListDto);
        Assert.That(returnDocumentListDto.DocumentNumber, Is.EqualTo(returnDocument.DocumentNumber));
        Assert.That(returnDocumentListDto.DocumentDate, Is.EqualTo(returnDocument.DocumentDate));
        Assert.That(returnDocumentListDto.DocumentName, Is.EqualTo(returnDocument.DocumentName));
        Assert.That(returnDocumentListDto.Comment, Is.EqualTo(returnDocument.Comment));
        Assert.That(returnDocumentListDto.DocumentStatus, Is.EqualTo(returnDocument.DocumentStatus));
        Assert.That(returnDocumentListDto.EmployeeName, Is.EqualTo(returnDocument.Employee.ShortName));
        Assert.That(returnDocumentListDto.ItemsCount, Is.EqualTo(returnDocument.Items.Count));
    }

    [Test]
    public void TramsferDocument_Should_Map_Correctly()
    {
        // Arrange
        var transferDocument = _dataSet.TransferDocumentTest;
        // Act
        var transferDocumentDto = _mapper.Map<TransferDocumentDto>(transferDocument);
        // Assert
        Assert.NotNull(transferDocumentDto);
        Assert.That(transferDocumentDto.DocumentNumber, Is.EqualTo(transferDocument.DocumentNumber));
        Assert.That(transferDocumentDto.DocumentDate, Is.EqualTo(transferDocument.DocumentDate));
        Assert.That(transferDocumentDto.DocumentName, Is.EqualTo(transferDocument.DocumentName));
        Assert.That(transferDocumentDto.Comment, Is.EqualTo(transferDocument.Comment));
        Assert.That(transferDocumentDto.DocumentStatus, Is.EqualTo(transferDocument.DocumentStatus));
    }

    [Test]
    public void TransferDocumentItem_Should_Map_Correctly()
    {
        // Arrange
        var transferDocumentItem = _dataSet.TransferDocumentItemTest;
        // Act
        var transferDocumentItemDto = _mapper.Map<TransferDocumentItemDto>(transferDocumentItem);
        // Assert
        Assert.NotNull(transferDocumentItemDto);
        Assert.That(transferDocumentItemDto.ItemName, Is.EqualTo(transferDocumentItem.Item.Name));
        Assert.That(transferDocumentItemDto.ItemInventoryNumber, Is.EqualTo(transferDocumentItem.Item.InventoryNumber));
    }

    [Test]
    public void TransferDocumentList_Should_Map_Correctly()
    {
        // Arrange
        var transferDocument = _dataSet.TransferDocumentTest;
        // Act
        var transferDocumentListDto = _mapper.Map<TransferDocumentListDto>(transferDocument);
        // Assert
        Assert.NotNull(transferDocumentListDto);
        Assert.That(transferDocumentListDto.DocumentNumber, Is.EqualTo(transferDocument.DocumentNumber));
        Assert.That(transferDocumentListDto.DocumentDate, Is.EqualTo(transferDocument.DocumentDate));
        Assert.That(transferDocumentListDto.DocumentName, Is.EqualTo(transferDocument.DocumentName));
        Assert.That(transferDocumentListDto.Comment, Is.EqualTo(transferDocument.Comment));
        Assert.That(transferDocumentListDto.DocumentStatus, Is.EqualTo(transferDocument.DocumentStatus));
        Assert.That(transferDocumentListDto.ItemsCount, Is.EqualTo(transferDocument.Items.Count));
    }

    [Test]
    public void WriteOffDocument_Should_Map_Correctly()
    {
        // Arrange
        var writeOffDocument = _dataSet.WriteOffDocumentTest;
        // Act
        var writeOffDocumentDto = _mapper.Map<WriteOffDocumentDto>(writeOffDocument);
        // Assert
        Assert.NotNull(writeOffDocumentDto);
        Assert.That(writeOffDocumentDto.DocumentNumber, Is.EqualTo(writeOffDocument.DocumentNumber));
        Assert.That(writeOffDocumentDto.DocumentDate, Is.EqualTo(writeOffDocument.DocumentDate));
        Assert.That(writeOffDocumentDto.DocumentName, Is.EqualTo(writeOffDocument.DocumentName));
        Assert.That(writeOffDocumentDto.Comment, Is.EqualTo(writeOffDocument.Comment));
        Assert.That(writeOffDocumentDto.DocumentStatus, Is.EqualTo(writeOffDocument.DocumentStatus));
    }

    [Test]
    public void WriteOffDocumentItem_Should_Map_Correctly()
    {
        // Arrange
        var writeOffDocumentItem = _dataSet.WriteOffDocumentItemTest;
        // Act
        var writeOffDocumentItemDto = _mapper.Map<WriteOffDocumentItemDto>(writeOffDocumentItem);
        // Assert
        Assert.NotNull(writeOffDocumentItemDto);
        Assert.That(writeOffDocumentItemDto.ItemName, Is.EqualTo(writeOffDocumentItem.Item.Name));
        Assert.That(writeOffDocumentItemDto.ItemInventoryNumber, Is.EqualTo(writeOffDocumentItem.Item.InventoryNumber));
    }

    [Test]
    public void WriteOffDocumentList_Should_Map_Correctly()
    {
        // Arrange
        var writeOffDocument = _dataSet.WriteOffDocumentTest;
        // Act
        var writeOffDocumentListDto = _mapper.Map<WriteOffDocumentListDto>(writeOffDocument);
        // Assert
        Assert.NotNull(writeOffDocumentListDto);
        Assert.That(writeOffDocumentListDto.DocumentNumber, Is.EqualTo(writeOffDocument.DocumentNumber));
        Assert.That(writeOffDocumentListDto.DocumentDate, Is.EqualTo(writeOffDocument.DocumentDate));
        Assert.That(writeOffDocumentListDto.DocumentName, Is.EqualTo(writeOffDocument.DocumentName));
        Assert.That(writeOffDocumentListDto.Comment, Is.EqualTo(writeOffDocument.Comment));
        Assert.That(writeOffDocumentListDto.DocumentStatus, Is.EqualTo(writeOffDocument.DocumentStatus));
        Assert.That(writeOffDocumentListDto.ItemsCount, Is.EqualTo(writeOffDocument.Items.Count));
    }

    [Test]
    public void Department_Should_Map_Correctly()
    {
        // Arrange
        var department = _dataSet.Department1Test;
        // Act
        var departmentDto = _mapper.Map<DepartmentDto>(department);
        // Assert
        Assert.NotNull(departmentDto);
        Assert.That(departmentDto.Name, Is.EqualTo(department.Name));
        Assert.That(departmentDto.Comment, Is.EqualTo(department.Comment));
    }

    [Test]
    public void EmployeesDto_Should_Map_Correctly()
    {
        // Arrange
        var employee = _dataSet.Employee1Test;
        // Act
        var employeeDto = _mapper.Map<EmployeeDto>(employee);
        // Assert
        Assert.NotNull(employeeDto);
        Assert.That(employeeDto.Firstname, Is.EqualTo(employee.Firstname));
        Assert.That(employeeDto.Surname, Is.EqualTo(employee.Surname));
        Assert.That(employeeDto.Patronymic, Is.EqualTo(employee.Patronymic));
        Assert.That(employeeDto.Comment, Is.EqualTo(employee.Comment));
        Assert.That(employeeDto.DepartmentId, Is.EqualTo(employee.DepartmentId));
        Assert.That(employeeDto.DepartmentName, Is.EqualTo(employee.Department == null ? string.Empty : employee.Department.Name));
        Assert.That(employeeDto.Position, Is.EqualTo(employee.Position));
    }

    [Test]
    public void MaterillayResponsible_Should_Map_Correctly()
    {
        // Arrange
        var materiallyResponsible = _dataSet.MateriallyResponsible1Test;
        // Act
        var materiallyResponsibleDto = _mapper.Map<MateriallyResponsibleDto>(materiallyResponsible);
        // Assert
        Assert.NotNull(materiallyResponsibleDto);
        Assert.That(materiallyResponsibleDto.EmployeeId, Is.EqualTo(materiallyResponsible.EmployeeId));
        Assert.That(materiallyResponsibleDto.EmployeeName, Is.EqualTo(materiallyResponsible.Employee == null ? string.Empty : materiallyResponsible.Employee.FullName));
        Assert.That(materiallyResponsibleDto.DisplayName, Is.EqualTo(materiallyResponsible.DisplayName));
    }

    [Test]
    public void Furniture_Should_Map_Correctly()
    {
        // Arrange
        var furnitureItem = _dataSet.FurnitureTest;
        // Act
        var furnitureItemDto = _mapper.Map<FurnitureDto>(furnitureItem);
        // Assert
        Assert.NotNull(furnitureItemDto);
        Assert.That(furnitureItemDto.Name, Is.EqualTo(furnitureItem.Name));
        Assert.That(furnitureItemDto.InventoryNumber, Is.EqualTo(furnitureItem.InventoryNumber));
        Assert.That(furnitureItemDto.CategoryName, Is.EqualTo(furnitureItem.Category == null ? null : furnitureItem.Category.Name));
    }

    [Test]
    public void FurnitureMaterilaAssignment_Should_Map_Correctly()
    {
        // Arrange
        var furnitureMaterialAssignment = _dataSet.FurnitureMaterialAssignmentTest;
        // Act
        var furnitureMaterialAssignmentDto = _mapper.Map<FurnitureMaterialAssignmentDto>(furnitureMaterialAssignment);
        // Assert
        Assert.NotNull(furnitureMaterialAssignmentDto);
        Assert.That(furnitureMaterialAssignmentDto.FurnitureId, Is.EqualTo(furnitureMaterialAssignment.FurnitureId));
        Assert.That(furnitureMaterialAssignmentDto.MaterialId, Is.EqualTo(furnitureMaterialAssignment.MaterialId));
        Assert.That(furnitureMaterialAssignmentDto.MaterialName, Is.EqualTo(furnitureMaterialAssignment.FurnitureMaterial == null ? string.Empty : furnitureMaterialAssignment.FurnitureMaterial.Name));
    }

    [Test]
    public void InventoryItem_Should_Map_Correctly()
    {
        // Arrange
        var inventoryItem = _dataSet.InventoryItemTest;
        // Act
        var inventoryItemDto = _mapper.Map<InventoryItemDto>(inventoryItem);
        // Assert
        Assert.NotNull(inventoryItemDto);
        Assert.That(inventoryItemDto.Name, Is.EqualTo(inventoryItem.Name));
        Assert.That(inventoryItemDto.InventoryNumber, Is.EqualTo(inventoryItem.InventoryNumber));
        Assert.That(inventoryItemDto.CategoryName, Is.EqualTo(inventoryItem.Category == null ? string.Empty : inventoryItem.Category.Name));
    }

    [Test]
    public void InventoryPhoto_Should_Map_Correctly()
    {
        // Arrange
        var inventoryPhoto = _dataSet.InventoryPhotoTest;
        // Act
        var inventoryPhotoDto = _mapper.Map<InventoryPhotoDto>(inventoryPhoto);
        // Assert
        Assert.NotNull(inventoryPhotoDto);
        Assert.That(inventoryPhotoDto.InventoryItemId, Is.EqualTo(inventoryPhoto.InventoryItemId));
        Assert.That(inventoryPhotoDto.PhotoPath, Is.EqualTo(inventoryPhoto.PhotoPath));
    }

    [Test]
    public void Workplace_Should_Map_Correctly()
    {
        // Arrange
        var workplace = _dataSet.WorkplaceTest;
        // Act
        var workplaceDto = _mapper.Map<WorkplaceDto>(workplace);
        // Assert
        Assert.NotNull(workplaceDto);
        Assert.That(workplaceDto.Comment, Is.EqualTo(workplace.Comment));
        Assert.That(workplaceDto.EmployeeId, Is.EqualTo(workplace.EmployeeId));
        Assert.That(workplaceDto.EmployeeName, Is.EqualTo(workplace.Employee == null ? string.Empty : workplace.Employee.ShortName));
    }

    [Test]
    public void WorkplaceInventoryItem_Should_Map_Correctly()
    {
        // Arrange
        var workplaceEquipment = _dataSet.WorkplaceEquipmentTest;
        // Act
        var workplaceEquipmentDto = _mapper.Map<WorkplaceEquipmentDto>(workplaceEquipment);
        // Assert
        Assert.NotNull(workplaceEquipmentDto);
        Assert.That(workplaceEquipmentDto.WorkplaceId, Is.EqualTo(workplaceEquipment.WorkplaceId));
        Assert.That(workplaceEquipmentDto.EquipmentId, Is.EqualTo(workplaceEquipment.EquipmentId));
    }

    [Test]
    public void Computer_Should_Map_Correctly()
    {
        // Arrange
        var computer = _dataSet.ComputerTest;
        // Act
        var computerDto = _mapper.Map<ComputerDto>(computer);
        // Assert
        Assert.NotNull(computerDto);
        Assert.That(computerDto.IsServer, Is.EqualTo(computer.IsServer));
        Assert.That(computerDto.IpAddress, Is.EqualTo(computer.IpAddress!.ToString()));
        Assert.That(computerDto.OperatingSystem, Is.EqualTo(computer.OperatingSystem));
    }

    [Test]
    public void ComputerComponent_Should_Map_Correctly()
    {
        // Arrange
        var component = _dataSet.CpuComponentTest;
        // Act
        var componentDto = _mapper.Map<ComputerComponentDto>(component);
        // Assert
        Assert.NotNull(componentDto);
        Assert.That(componentDto.ComponentType, Is.EqualTo(component.ComponentType));
        Assert.That(componentDto.Quantity, Is.EqualTo(component.Quantity));
    }

    [Test]
    public void Laptop_Should_Map_Correctly()
    {
        // Arrange
        var laptop = _dataSet.LaptopTest;
        // Act
        var laptopDto = _mapper.Map<LaptopDto>(laptop);
        // Assert
        Assert.NotNull(laptopDto);
        Assert.That(laptopDto.RAM, Is.EqualTo(laptop.RAM));
        Assert.That(laptopDto.Model, Is.EqualTo(laptop.Model));
        Assert.That(laptopDto.Vendor, Is.EqualTo(laptop.Vendor));
    }

    [Test]
    public void MaintenanceLog_Should_Map_Correctly()
    {
        // Arrange
        var maintenanceLog = _dataSet.MaintenanceLogTest;
        // Act
        var maintenanceLogDto = _mapper.Map<MaintenanceLogDto>(maintenanceLog);
        // Assert
        Assert.NotNull(maintenanceLogDto);
        Assert.That(maintenanceLogDto.MaintenanceType, Is.EqualTo(maintenanceLog.MaintenanceType));
        Assert.That(maintenanceLogDto.MaintenanceDate, Is.EqualTo(maintenanceLog.MaintenanceDate));
        Assert.That(maintenanceLogDto.DeviceId, Is.EqualTo(maintenanceLog.DeviceId));
        Assert.That(maintenanceLogDto.EmployeeName, Is.EqualTo(maintenanceLog.Employee == null ? string.Empty : maintenanceLog.Employee.ShortName));
    }

    [Test]
    public void Monitor_Should_Map_Correctly()
    {
        // Arrange
        var monitor = _dataSet.MonitorTest;
        // Act
        var monitorDto = _mapper.Map<MonitorDto>(monitor);
        // Assert
        Assert.NotNull(monitorDto);
        Assert.That(monitorDto.Diagonal, Is.EqualTo(monitor.Diagonal));
        Assert.That(monitorDto.Model, Is.EqualTo(monitor.Model));
        Assert.That(monitorDto.Vendor, Is.EqualTo(monitor.Vendor));
        Assert.That(monitorDto.PanelType, Is.EqualTo(monitor.PanelType));
    }

    [Test]
    public void NetworkDevice_Should_Map_Correctly()
    {
        // Arrange
        var networkDevice = _dataSet.NetworkDeviceTest;
        // Act
        var networkDeviceDto = _mapper.Map<NetworkDeviceDto>(networkDevice);
        // Assert
        Assert.NotNull(networkDeviceDto);
        Assert.That(networkDeviceDto.Model, Is.EqualTo(networkDevice.Model));
        Assert.That(networkDeviceDto.Vendor, Is.EqualTo(networkDevice.Vendor));
        Assert.That(networkDeviceDto.IpAddress, Is.EqualTo(networkDevice.IpAddress!.ToString()));
    }

    [Test]
    public void Phone_Should_Map_Correctly()
    {
        // Arrange
        var phone = _dataSet.PhoneTest;
        // Act
        var phoneDto = _mapper.Map<PhoneDto>(phone);
        // Assert
        Assert.NotNull(phoneDto);
        Assert.That(phoneDto.Model, Is.EqualTo(phone.Model));
        Assert.That(phoneDto.Vendor, Is.EqualTo(phone.Vendor));
        Assert.That(phoneDto.PhoneNumber, Is.EqualTo(phone.PhoneNumber));
    }

    [Test]
    public void Printer_Should_Map_Correctly()
    {
        // Arrange
        var printer = _dataSet.PrinterTest;
        // Act
        var printerDto = _mapper.Map<PrinterDto>(printer);
        // Assert
        Assert.NotNull(printerDto);
        Assert.That(printerDto.Model, Is.EqualTo(printer.Model));
        Assert.That(printerDto.Vendor, Is.EqualTo(printer.Vendor));
    }

    [Test]
    public void Scanner_Should_Map_Correctly()
    {
        // Arrange
        var scanner = _dataSet.ScannerTest;
        // Act
        var scannerDto = _mapper.Map<ScannerDto>(scanner);
        // Assert
        Assert.NotNull(scannerDto);
        Assert.That(scannerDto.Model, Is.EqualTo(scanner.Model));
        Assert.That(scannerDto.Vendor, Is.EqualTo(scanner.Vendor));
    }

    [Test]
    public void Software_Should_Map_Correctly()
    {
        // Arrange
        var software = _dataSet.SoftwareTest;
        // Act
        var softwareDto = _mapper.Map<SoftwareDto>(software);
        // Assert
        Assert.NotNull(softwareDto);
        Assert.That(softwareDto.Vendor, Is.EqualTo(software.Vendor));
    }

    [Test]
    public void Tablet_Should_Map_Correctly()
    {
        // Arrange
        var tablet = _dataSet.TabletTest;
        // Act
        var tabletDto = _mapper.Map<TabletDto>(tablet);
        // Assert
        Assert.NotNull(tabletDto);
        Assert.That(tabletDto.Model, Is.EqualTo(tablet.Model));
        Assert.That(tabletDto.Vendor, Is.EqualTo(tablet.Vendor));
    }

    [Test]
    public void UPS_Should_Map_Correctly()
    {
        // Arrange
        var ups = _dataSet.UPSTest;
        // Act
        var upsDto = _mapper.Map<UpsDto>(ups);
        // Assert
        Assert.NotNull(upsDto);
        Assert.That(upsDto.Model, Is.EqualTo(ups.Model));
        Assert.That(upsDto.Vendor, Is.EqualTo(ups.Vendor));
        Assert.That(upsDto.Autonomy, Is.EqualTo(ups.Autonomy));
    }

    [Test]
    public void Favourite_Should_Map_Correctly()
    {
        // Arrange
        var favourite = _dataSet.FavouriteTest;
        // Act
        var favouriteDto = _mapper.Map<FavouriteDto>(favourite);
        // Assert
        Assert.NotNull(favouriteDto);
        Assert.That(favouriteDto.InventoryNumber, Is.EqualTo(favourite.Item.InventoryNumber));
        Assert.That(favouriteDto.Name, Is.EqualTo(favourite.Item.Name));
        Assert.That(favouriteDto.Location, Is.EqualTo(favourite.Item.Location));
        Assert.That(favouriteDto.Status, Is.EqualTo(favourite.Item.Status));
        Assert.That(favouriteDto.Comment, Is.EqualTo(favourite.Item.Comment));
        Assert.That(favouriteDto.FavouritedAt, Is.EqualTo(favourite.FavouritedAt));
    }

    [Test]
    public void Role_Should_Map_Correctly()
    {
        // Arrange
        var role = _dataSet.RoleTest;
        // Act
        var roleDto = _mapper.Map<RoleDto>(role);
        // Assert
        Assert.NotNull(roleDto);
        Assert.That(roleDto.Name, Is.EqualTo(role.Name));
        Assert.That(roleDto.IsSystem, Is.EqualTo(role.IsSystem));
        Assert.That(roleDto.UserCount, Is.EqualTo(role.UserProfiles.Count()));
    }

    [Test]
    public void UserProfile_Should_Map_Correctly()
    {
        // Arrange
        var user = _dataSet.UserTest;
        // Act
        var userDto = _mapper.Map<UserProfileDto>(user);
        // Assert
        Assert.NotNull(userDto);
        Assert.That(userDto.Username, Is.EqualTo(user.Username));
        Assert.That(userDto.IsActive, Is.EqualTo(user.IsActive));
        Assert.That(userDto.EmployeeName, Is.EqualTo(user.Employee!.ShortName));
    }
}
