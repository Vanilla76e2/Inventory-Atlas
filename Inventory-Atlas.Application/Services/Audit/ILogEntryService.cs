using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Infrastructure.Entities.Audit;

namespace Inventory_Atlas.Application.Services.Audit
{
    /// <summary>
    /// Сервис логирования действий пользователя и сущностей доменной модели.
    /// Поддерживает атомарные операции логирования вместе с сохранением сущности.
    /// </summary>
    /// <typeparam name="T">Тип сущности, для которой ведётся лог.</typeparam>
    public interface ILogEntryService<T>
    {
        /// <summary>
        /// Добавляет запись лога в контекст без сохранения.
        /// </summary>
        /// <param name="action">Тип выполняемого действия.</param>
        /// <param name="details">Подробные данные о действии.</param>
        void Log(ActionType action, LogDetails<T>? details);

        /// <summary>
        /// Добавляет запись лога и сохраняет её в базе данных.
        /// </summary>
        /// <param name="action">Тип выполняемого действия.</param>
        /// <param name="details">Подробные данные о действии.</param>
        /// <param name="ct">Токен отмены.</param>
        Task LogAndSaveAsync(ActionType action, LogDetails<T>? details, CancellationToken ct = default);

        /// <summary>
        /// Добавляет запись лога для событий аутентификации и немедленно сохраняет её.
        /// Используется, когда пользовательская сессия ещё не существует в контексте.
        /// </summary>
        /// <param name="action">Тип выполняемого действия.</param>
        /// <param name="UserSessionId">Идентификатор пользовательской сессии.</param>
        /// <param name="ct">Токен отмены.</param>
        Task LogAuthAndSaveAsync(ActionType action, int UserSessionId, CancellationToken ct = default);

        /// <summary>
        /// Сохраняет сущность и логирует действие в рамках одной транзакции.
        /// В случае ошибки выполняет откат.
        /// </summary>
        /// <param name="entity">Сущность для сохранения.</param>
        /// <param name="action">Тип выполняемого действия.</param>
        /// <param name="details">Подробные данные о действии.</param>
        /// <param name="ct">Токен отмены.</param>
        /// <returns>Сохранённая сущность или null при ошибке.</returns>
        Task<T?> SaveEntityWithLogAsync(
            T entity,
            ActionType action,
            LogDetails<T>? details = null,
            CancellationToken ct = default);

        /// <summary>
        /// Возвращает все записи лога.
        /// </summary>
        /// <param name="ct">Токен отмены.</param>
        Task<IReadOnlyList<LogEntry>> GetAllAsync(CancellationToken ct = default);

        /// <summary>
        /// Возвращает записи лога по идентификатору пользовательской сессии.
        /// </summary>
        /// <param name="userSessionId">Идентификатор сессии пользователя.</param>
        /// <param name="ct">Токен отмены.</param>
        Task<IReadOnlyList<LogEntry>> GetByUserAsync(int userSessionId, CancellationToken ct = default);

        /// <summary>
        /// Возвращает записи лога по типу действия.
        /// </summary>
        /// <param name="action">Тип действия.</param>
        /// <param name="ct">Токен отмены.</param>
        Task<IReadOnlyList<LogEntry>> GetByActionAsync(ActionType action, CancellationToken ct = default);

        /// <summary>
        /// Возвращает записи лога в пределах указанного диапазона дат.
        /// </summary>
        /// <param name="from">Начало периода (UTC).</param>
        /// <param name="to">Конец периода (UTC).</param>
        /// <param name="ct">Токен отмены.</param>
        Task<IReadOnlyList<LogEntry>> GetByDateRangeAsync(DateTime from, DateTime to, CancellationToken ct = default);
    }

}
