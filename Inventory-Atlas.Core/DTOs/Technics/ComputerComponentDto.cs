namespace Inventory_Atlas.Core.DTOs.Technics
{
    public class ComputerComponentDto
    {
        public int Id { get; set; }
        public int ComputerId { get; set; }
        public Enums.ComponentType ComponentType { get; set; }
        public short Quantity { get; set; }
        public string? SerialNumber { get; set; }
    }
}
