using AutoMapper;
using Inventory_Atlas.Application.Services.Audit;
using Inventory_Atlas.Core.DTOs.Audit;
using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Services.Common
{
    public class AuditableCrudService<TEntity, TDto> : CrudService<TEntity, TDto>, IAuditableCrudService<TEntity, TDto>
        where TEntity : class
    {
        private readonly ILogEntryService _logService;

        protected AuditableCrudService(
            IUnitOfWork uow,
            IMapper mapper,
            ILogger logger,
            ILogEntryService logService,
            IDatabaseRepository<TEntity> repo)
        : base(uow, mapper, repo, logger)
        {
            _logService = logService;
        }

        public Task LogChangesAsync(TDto? oldValue, TDto? newValue, ActionType action)
        {
            throw new NotImplementedException();
        }

        //public Task LogChangesAsync(TDto? oldValue, TDto? newValue, ActionType action)
        //{
        //    var details = new Dictionary<string, object?>();
        //    if (oldValue != null) details["Old"] = oldValue;
        //    if (newValue != null) details["New"] = newValue;

        //    var logEntry = new LogEntryDto
        //    {
        //        ActionTime = DateTime.UtcNow,
        //        Username = _currentUser, // нужно передавать или получать через контекст
        //        Action = action,
        //        Details = details
        //    };

        //    await _logService.CreateAsync(logEntry);
        //}
    }
}
