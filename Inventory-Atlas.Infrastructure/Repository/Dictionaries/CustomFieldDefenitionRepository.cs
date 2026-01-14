using Inventory_Atlas.Application.Data;
using Inventory_Atlas.Application.Entities.Dictionaries;
using Inventory_Atlas.Application.Repository.Common;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Repository.Dictionaries
{
    public class CustomFieldDefenitionRepository : DatabaseRepository<CustomFieldDefenition>, ICustomFieldDefenitionRepository
    {
        public CustomFieldDefenitionRepository(AppDbContext context, ILogger<CustomFieldDefenitionRepository> logger)
            : base(context, logger)
        { }
    }
}
