namespace Inventory_Atlas.Core.DTOs.Technics
{
    public class SoftwareDto : EquipmentDto
    {
        public string? Vendor { get; set; }
    }

    public class SoftwareAdminDto : SoftwareDto
    {
        public string? LicenceKey { get; set; }
    }
}
