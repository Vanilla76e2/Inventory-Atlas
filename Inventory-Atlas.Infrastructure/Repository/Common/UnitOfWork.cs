using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Auditor.Service;
using Inventory_Atlas.Infrastructure.Auditor;


namespace Inventory_Atlas.Infrastructure.Repository.Common
{
    /// <summary>
    /// Реализация Unit of Work для работы с репозиториями.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger<UnitOfWork> _logger;
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;
        private readonly IAuditService _audit;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="UnitOfWork"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="loggerFactory">Фабрика логгеров.</param>
        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory, IAuditService audit)
        {
            _logger = loggerFactory.CreateLogger<UnitOfWork>();
            _audit = audit;
            _context = context;
        }

        /// <inheritdoc/>
        public async Task SaveChangesAsync(CancellationToken ct = default, AuditContext? auditContext = null)
        {
            _logger.LogInformation("Saving changes to the database...");
            try
            {
                if (auditContext != null)
                    _audit.RegisterAudit(_context, auditContext);
                
                await _context.SaveChangesAsync(ct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving changes to the database.");
                throw;
            }
            _logger.LogInformation("Changes saved successfully.");
            _logger.LogDebug("Number of entities being saved: {Count}", _context.ChangeTracker.Entries().Count());
        }

        /// <inheritdoc/>
        public async Task BeginTransactionAsync(CancellationToken ct = default)
        {
            if (_transaction == null)
                throw new InvalidOperationException("Transaction alreadt started.");

            _transaction = await _context.Database.BeginTransactionAsync(ct);
            _logger.LogDebug("Transaction started.");
        }

        /// <inheritdoc/>
        public async Task CommitAsync(CancellationToken ct = default)
        {
            if (_transaction == null)
                throw new InvalidOperationException("No active transaction to commit.");

            await _context.SaveChangesAsync(ct);
            await _transaction.CommitAsync(ct);
            _logger.LogDebug("Transaction commited.");

            await DisposeTransactionAsync();
        }

        /// <inheritdoc/>
        public async Task RollbackAsync(CancellationToken ct = default)
        {
            if (_transaction == null)
                return;

            await _transaction.RollbackAsync(ct);
            _logger.LogDebug("Transaction rolled back.");

            await DisposeTransactionAsync();
        }

        /// <inheritdoc/>
        private async Task DisposeTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }
}
