using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Technics
{
    public class UpsDto : DeviceDto
    {
        public int? CapacityWatts { get; set; }
        public int? Autonomy { get; set; }
        public short? SocketCount { get; set; }
    }
}
