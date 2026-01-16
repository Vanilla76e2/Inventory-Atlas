using AutoMapper;
using System.Text.Json;

namespace Inventory_Atlas.Infrastructure.Converters
{
    public class JsonStringToDictionaryConverter : IValueConverter<string?, Dictionary<string, object>?>
    {
        public Dictionary<string, object>? Convert(string? sourceMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(sourceMember))
            {
                return null;
            }
            try
            {
                var dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(sourceMember);
                return dictionary;
            }
            catch (JsonException)
            {
                // Handle JSON deserialization errors if necessary
                return null;
            }
        }
    } 
}
