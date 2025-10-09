using Inventory_Atlas.Core.DTOs.Common;
using System.Net;

namespace Inventory_Atlas.Core.DTOs.Dictionaries
{
    public class IpDictionaryDto : AuditableDto
    {
        public IPAddress Ip { get; set; } = null!;
        public string Note { get; set; } = null!;
    }
}
