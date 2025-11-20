using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Entities.Dictionaries;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Dictionaries
{
    public class CustomFieldValueRepository : DatabaseRepository<CustomFieldValue>, ICustomFieldValueRepository
    {
        public CustomFieldValueRepository(AppDbContext context, ILogger<CustomFieldValueRepository> logger)
            : base(context, logger) 
        { }
    }
}
