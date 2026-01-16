using Inventory_Atlas.Core.Models;

namespace Inventory_Atlas.Server.Controllers
{
    public static class HttpContextExtensions
    {
        public static ClientInfo GetClientInfo(this HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var token = context.Request.Headers["Authorization"].FirstOrDefault()
                ?.Replace("Bearer ", "")
                .Trim();

            var userAgent = context.Request.Headers["User-Agent"].FirstOrDefault();

            var ipAddress = context.Request.Headers["X-Forwarded-For"].FirstOrDefault()
                ?? context.Connection.RemoteIpAddress?.ToString();

            return new ClientInfo
            {
                SessionToken = string.IsNullOrEmpty(token) ? null : token,
                IpAddress = ipAddress,
                UserAgent = userAgent
            };
        }
    }
}
