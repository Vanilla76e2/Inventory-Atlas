using System.Net;

namespace Inventory_Atlas.Application.Entities.Base
{
    public interface IHasIpAddress
    {
        IPAddress? IpAddress { get; set; }
    }
}
