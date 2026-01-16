namespace Inventory_Atlas.Core.Models
{
    public class ClientInfo
    {
        public string? SessionToken { get; init; }
        public string? IpAddress { get; init; }
        public string? UserAgent { get; init; }
    }
}
