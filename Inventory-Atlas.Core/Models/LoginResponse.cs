namespace Inventory_Atlas.Core.Models
{
    public class LoginResponse
    {
        public string? Token { get; set; } = default!;
        public bool Success { get; set; }
        public string? ErrorCode { get; set; }
    }
}
