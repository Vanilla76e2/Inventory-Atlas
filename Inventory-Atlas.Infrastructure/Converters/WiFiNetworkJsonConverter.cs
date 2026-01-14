using Inventory_Atlas.Core.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace Inventory_Atlas.Application.Converters
{
    public static class WiFiNetworkJsonConverter
    {
        public static readonly ValueConverter<List<WiFiNetworkJsonModel>, string> Convert =
        new(
            v => v == null ? "{}" : JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
            v => string.IsNullOrEmpty(v) ? new List<WiFiNetworkJsonModel>() : JsonSerializer.Deserialize<List<WiFiNetworkJsonModel>>(v, (JsonSerializerOptions?)null) ?? new List<WiFiNetworkJsonModel>()
        );
    }
}
