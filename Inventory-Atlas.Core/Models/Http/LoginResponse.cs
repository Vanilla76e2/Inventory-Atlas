namespace Inventory_Atlas.Core.Models.Http
{
    public class LoginResponse
    {
        public string? Token { get; set; } = default!;
        public bool Success { get; set; }
        public string? ErrorCode { get; set; }
    
        public static LoginResponse Ok(string token) => new() { Success = true, Token = token };

        public static LoginResponse Fail(string errorCode) => new() { Success = false, ErrorCode = errorCode };
    }
}
