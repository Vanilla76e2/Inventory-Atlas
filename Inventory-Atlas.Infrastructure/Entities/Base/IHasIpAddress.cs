using System.Net;

namespace Inventory_Atlas.Infrastructure.Entities.Base
{
    public interface IHasIpAddress
    {
        IPAddress? IpAddress { get; set; }
    }
}
