using Inventory_Atlas.Infrastructure.Entities.Dictionaries;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Dictionaries
{
    public class CustomFieldDefenitionRepository : DatabaseRepository<CustomFieldDefenition>, ICustomFieldDefenitionRepository
    {
        public CustomFieldDefenitionRepository(IDatabaseContextProvider provider, ILogger<CustomFieldDefenitionRepository> logger)
            : base(provider, logger)
        { }
    }
}
