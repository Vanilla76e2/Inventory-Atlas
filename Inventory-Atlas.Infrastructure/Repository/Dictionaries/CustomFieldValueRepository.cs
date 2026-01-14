using Inventory_Atlas.Application.Data;
using Inventory_Atlas.Application.Entities.Dictionaries;
using Inventory_Atlas.Application.Repository.Common;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Repository.Dictionaries
{
    public class CustomFieldValueRepository : DatabaseRepository<CustomFieldValue>, ICustomFieldValueRepository
    {
        public CustomFieldValueRepository(AppDbContext context, ILogger<CustomFieldValueRepository> logger)
            : base(context, logger) 
        { }
    }
}
