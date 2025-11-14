using NUnit.Framework;
using AutoMapper;
using Inventory_Atlas.Core.DTOs.Inventory;
using ApplicationTests.Common;

namespace ApplicationTests;

[TestFixture]
public class MappersTest
{
    private IMapper _mapper = null!;

    [SetUp]
    public void Setup()
    {
        var config = new MapperConfiguration(cfg =>
        {
            // cfg.AddProfile<YourMappingProfile>();
        });

        _mapper = config.CreateMapper();
    }

    [Test]
    public void Computer_Should_Map_To_InventoryItemDto_Correctly()
    {
        // Arrange
        var dataSet = new TestDataSet();
        var computer = dataSet.ComputerTest;

        // Act
        var dto = _mapper.Map<InventoryItemDto>(computer);

        // Assert
        Assert.That(dto, Is.Not.Null);
        Assert.That(dto.Id, Is.EqualTo(computer.Id));
        Assert.That(dto.Name, Is.EqualTo(computer.Name));
        Assert.That(dto.InventoryNumber, Is.EqualTo(computer.InventoryNumber));
        Assert.That(dto.RegistryNumber, Is.EqualTo(computer.RegistryNumber));
        Assert.That(dto.ResponsibleId, Is.EqualTo(computer.ResponsibleId));
        Assert.That(dto.Comment, Is.EqualTo(computer.Comment));
    }
}
