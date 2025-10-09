namespace Inventory_Atlas.Core.DTOs.Technics
{
    public class ComputerDto : EquipmentDto
    {
        public bool IsServer { get; set; }

        public string? IpAddress { get; set; }

        public string? OperatingSystem { get; set; }

        public List<ComputerComponentDto>? Components { get; set; }
    }
}
