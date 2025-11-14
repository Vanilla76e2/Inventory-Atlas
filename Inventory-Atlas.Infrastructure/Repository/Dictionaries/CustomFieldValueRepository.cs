using Inventory_Atlas.Infrastructure.Entities.Dictionaries;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Dictionaries
{
    public class CustomFieldValueRepository : DatabaseRepository<CustomFieldValue>, ICustomFieldValueRepositiry
    {
        public CustomFieldValueRepository(IDatabaseContextProvider provider, ILogger<CustomFieldValueRepository> logger)
            : base(provider, logger) 
        { }
    }
}
