using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Core.DTOs.Audit
{
    /// <summary>
    /// DTO, представляющий запись лога действий пользователя.
    /// <para/>
    /// Тип: <see cref="LogEntryDto"/>
    /// <para/>
    /// Все свойства могут быть использованы для отображения и фильтрации логов.
    /// </summary>
    public class LogEntryDto : BaseDto
    {
        /// <summary>
        /// Время совершения действия пользователем.
        /// <para/>
        /// Тип: <see langword="DateTime"/>
        /// </summary>
        public DateTime ActionTime { get; set; }

        /// <summary>
        /// Имя пользователя, совершившего действие.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// Тип действия пользователя.
        /// <para/>
        /// Тип: <see cref="ActionType"/>
        /// </summary>
        public ActionType Action { get; set; }

        /// <summary>
        /// Изменения, внесённые в сущность.
        /// <para/>
        /// Тип: <see cref="Dictionary{String,Object}"/>
        /// <para/>
        /// Может быть <see langword="null"/> если изменений нет или действие не связано с сущностью.
        /// </summary>
        public Dictionary<string, object>? Details { get; set; }
    }

    /// <summary>
    /// DTO для пагинации логов действий пользователей.
    /// <para/>
    /// Тип: <see cref="PagedLogEntryDto"/>
    /// </summary>
    public class PagedLogEntryDto : BaseDto
    {
        /// <summary>
        /// Общее количество записей в логе.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Номер текущей страницы.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Размер страницы (количество записей на странице).
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Список записей лога на текущей странице.
        /// <para/>
        /// Тип: <see cref="List{LogEntryDto}"/>
        /// <para/>
        /// Всегда инициализирован пустым списком, не может быть <c>null</c>.
        /// </summary>
        public List<LogEntryDto> Items { get; set; } = new();
    }
}
